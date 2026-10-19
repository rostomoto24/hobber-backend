using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Hobber.Application.Contracts;
using Hobber.Persistance.Seeding;

namespace Hobber.Tests;

public sealed class AuthTests(HobberApiFactory factory) : IClassFixture<HobberApiFactory>
{
    private static object ValidRegistration(string email) => new
    {
        email,
        phone = "+995 555 123 456",
        password = "Secret123",
        repeatPassword = "Secret123",
        profileType = "student",
        acceptTerms = true,
        firstName = "Keti",
    };

    [Fact]
    public async Task Register_then_me_returns_profile_and_display_name()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/register", ValidRegistration("keti@example.com"));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var auth = (await response.Content.ReadFromJsonAsync<AuthResponse>())!;
        Assert.Equal("keti@example.com", auth.User.Email);
        Assert.Equal("Student", auth.User.ProfileType);
        Assert.Equal("Keti", auth.User.DisplayName);
        Assert.NotEmpty(auth.AccessToken);
        Assert.NotEmpty(auth.RefreshToken);

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
        var me = await client.GetFromJsonAsync<UserDto>("/api/me");
        Assert.Equal(auth.User.Id, me!.Id);
        Assert.Empty(me.Interests);
    }

    [Fact]
    public async Task Register_without_name_greets_by_email_local_part()
    {
        var client = factory.CreateClient();
        var body = new
        {
            email = "nameless@example.com",
            password = "Secret123",
            repeatPassword = "Secret123",
            profileType = "tutor",
            acceptTerms = true,
        };

        var auth = await (await client.PostAsJsonAsync("/api/auth/register", body)).Content.ReadFromJsonAsync<AuthResponse>();

        Assert.Equal("nameless", auth!.User.DisplayName);
        Assert.Equal("Tutor", auth.User.ProfileType);
    }

    [Fact]
    public async Task Register_validates_every_field_from_the_spec()
    {
        var client = factory.CreateClient();
        var body = new
        {
            email = "not-an-email",
            phone = "abc",
            password = "short",
            repeatPassword = "different",
            profileType = "admin",
            acceptTerms = false,
        };

        var response = await client.PostAsJsonAsync("/api/auth/register", body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("validation_failed", problem.GetProperty("code").GetString());
        var errors = problem.GetProperty("errors");
        foreach (var field in new[] { "email", "phone", "password", "repeatPassword", "profileType", "acceptTerms" })
        {
            Assert.True(errors.TryGetProperty(field, out _), $"expected an error for {field}");
        }
    }

    [Fact]
    public async Task Register_with_taken_email_is_conflict()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/register", ValidRegistration(DevSeeder.DemoStudentEmail.ToUpperInvariant()));

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("email_taken", problem.GetProperty("code").GetString());
    }

    [Fact]
    public async Task Login_with_wrong_password_is_unauthorized_without_revealing_which_field()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new { email = DevSeeder.DemoStudentEmail, password = "wrong" });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("invalid_credentials", problem.GetProperty("code").GetString());
    }

    [Fact]
    public async Task Refresh_rotates_token_and_rejects_the_old_one()
    {
        var client = factory.CreateClient();
        var login = await (await client.PostAsJsonAsync("/api/auth/login", new { email = DevSeeder.DemoTutorEmail, password = DevSeeder.DemoPassword }))
            .Content.ReadFromJsonAsync<AuthResponse>();

        var first = await client.PostAsJsonAsync("/api/auth/refresh", new { refreshToken = login!.RefreshToken });
        var second = await client.PostAsJsonAsync("/api/auth/refresh", new { refreshToken = login.RefreshToken });

        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        var rotated = await first.Content.ReadFromJsonAsync<AuthResponse>();
        Assert.NotEqual(login.RefreshToken, rotated!.RefreshToken);
        Assert.Equal(HttpStatusCode.Unauthorized, second.StatusCode);
    }

    [Fact]
    public async Task Forgot_password_accepts_unknown_email_and_reset_works_with_a_real_token()
    {
        var client = factory.CreateClient();
        await client.PostAsJsonAsync("/api/auth/register", ValidRegistration("reset-me@example.com"));

        var unknown = await client.PostAsJsonAsync("/api/auth/forgot-password", new { email = "nobody@example.com" });
        Assert.Equal(HttpStatusCode.Accepted, unknown.StatusCode);

        var known = await client.PostAsJsonAsync("/api/auth/forgot-password", new { email = "reset-me@example.com" });
        Assert.Equal(HttpStatusCode.Accepted, known.StatusCode);

        string token;
        using (var db = factory.CreateDbContext())
        {
            token = db.PasswordResetTokens.OrderByDescending(t => t.CreatedAt).First().Token;
        }

        var reset = await client.PostAsJsonAsync("/api/auth/reset-password", new { token, newPassword = "NewSecret123", repeatPassword = "NewSecret123" });
        Assert.Equal(HttpStatusCode.NoContent, reset.StatusCode);

        var oldLogin = await client.PostAsJsonAsync("/api/auth/login", new { email = "reset-me@example.com", password = "Secret123" });
        var newLogin = await client.PostAsJsonAsync("/api/auth/login", new { email = "reset-me@example.com", password = "NewSecret123" });
        Assert.Equal(HttpStatusCode.Unauthorized, oldLogin.StatusCode);
        Assert.Equal(HttpStatusCode.OK, newLogin.StatusCode);

        var reuse = await client.PostAsJsonAsync("/api/auth/reset-password", new { token, newPassword = "Another123", repeatPassword = "Another123" });
        Assert.Equal(HttpStatusCode.BadRequest, reuse.StatusCode);
    }

    [Fact]
    public async Task Protected_endpoints_require_a_token()
    {
        var client = factory.CreateClient();

        Assert.Equal(HttpStatusCode.Unauthorized, (await client.GetAsync("/api/me")).StatusCode);
        Assert.Equal(HttpStatusCode.Unauthorized, (await client.GetAsync("/api/notifications/unread-count")).StatusCode);
        Assert.Equal(HttpStatusCode.Unauthorized, (await client.GetAsync("/api/courses?section=forYou")).StatusCode);
    }
}
