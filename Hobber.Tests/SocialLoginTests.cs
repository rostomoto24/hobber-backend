using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Hobber.Application.Auth;
using Hobber.Application.Contracts;
using Hobber.Persistance.Seeding;

namespace Hobber.Tests;

public sealed class SocialLoginTests(HobberApiFactory factory) : IClassFixture<HobberApiFactory>
{
    private static async Task<string> CodeOf(HttpResponseMessage response) =>
        (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("code").GetString()!;

    [Fact]
    public async Task Providers_reflect_server_configuration()
    {
        var client = factory.CreateClient();

        var providers = await client.GetFromJsonAsync<AuthProvidersDto>("/api/auth/providers");

        Assert.True(providers!.Google);
        Assert.True(providers.Facebook);
    }

    [Fact]
    public async Task New_person_with_profile_type_gets_an_account_then_logs_in_with_the_same_identity()
    {
        var client = factory.CreateClient();

        var first = await client.PostAsJsonAsync("/api/auth/social", new { provider = "google", token = "google:sub-1:keti@example.com", profileType = "student" });
        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        var created = (await first.Content.ReadFromJsonAsync<AuthResponse>())!;
        Assert.True(created.IsNewUser);
        Assert.Equal("keti@example.com", created.User.Email);
        Assert.Equal("Keti", created.User.DisplayName);
        Assert.Equal("Student", created.User.ProfileType);
        Assert.NotNull(created.User.AvatarUrl);

        var second = await client.PostAsJsonAsync("/api/auth/social", new { provider = "google", token = "google:sub-1:keti@example.com" });
        var again = (await second.Content.ReadFromJsonAsync<AuthResponse>())!;
        Assert.False(again.IsNewUser);
        Assert.Equal(created.User.Id, again.User.Id);

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", again.AccessToken);
        var me = await client.GetFromJsonAsync<UserDto>("/api/me");
        Assert.Equal(created.User.Id, me!.Id);

        var passwordLogin = await client.PostAsJsonAsync("/api/auth/login", new { email = "keti@example.com", password = "anything1" });
        Assert.Equal(HttpStatusCode.Unauthorized, passwordLogin.StatusCode);
    }

    [Fact]
    public async Task Verified_email_matching_an_existing_account_links_and_logs_in()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/social", new { provider = "facebook", token = $"facebook:fb-9:{DevSeeder.DemoStudentEmail}" });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var auth = (await response.Content.ReadFromJsonAsync<AuthResponse>())!;
        Assert.False(auth.IsNewUser);
        Assert.Equal("Salome", auth.User.DisplayName);
    }

    [Fact]
    public async Task Unverified_email_matching_an_existing_account_is_refused()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/social", new { provider = "google", token = $"google:sub-7:{DevSeeder.DemoTutorEmail}:unverified" });

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        Assert.Equal("email_in_use", await CodeOf(response));
    }

    [Fact]
    public async Task Unknown_identity_without_profile_type_is_not_found()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/social", new { provider = "google", token = "google:sub-404:nobody@example.com" });

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Equal("account_not_found", await CodeOf(response));
    }

    [Fact]
    public async Task Invalid_token_and_unknown_provider_are_rejected()
    {
        var client = factory.CreateClient();

        var bad = await client.PostAsJsonAsync("/api/auth/social", new { provider = "google", token = "garbage", profileType = "student" });
        Assert.Equal(HttpStatusCode.Unauthorized, bad.StatusCode);
        Assert.Equal("invalid_social_token", await CodeOf(bad));

        var unknown = await client.PostAsJsonAsync("/api/auth/social", new { provider = "twitter", token = "x" });
        Assert.Equal(HttpStatusCode.BadRequest, unknown.StatusCode);

        var noEmail = await client.PostAsJsonAsync("/api/auth/social", new { provider = "facebook", token = "facebook:fb-1:-", profileType = "tutor" });
        Assert.Equal(HttpStatusCode.BadRequest, noEmail.StatusCode);
    }
}
