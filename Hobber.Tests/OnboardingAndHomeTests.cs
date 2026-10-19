using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Persistance.Seeding;

namespace Hobber.Tests;

public sealed class OnboardingAndHomeTests(HobberApiFactory factory) : IClassFixture<HobberApiFactory>
{
    [Fact]
    public async Task Categories_are_public_ordered_and_carry_an_accent()
    {
        var client = factory.CreateClient();

        var categories = await client.GetFromJsonAsync<List<CategoryDto>>("/api/categories");

        Assert.NotNull(categories);
        Assert.Equal(8, categories!.Count);
        Assert.Equal("Pilates", categories[0].Name);
        Assert.Equal("Coral", categories[0].Accent);
        Assert.Equal(categories.OrderBy(c => c.DisplayOrder).Select(c => c.Id), categories.Select(c => c.Id));
    }

    [Fact]
    public async Task Set_interests_replaces_the_set_and_requires_at_least_one()
    {
        var client = factory.CreateClient();
        var auth = await (await client.PostAsJsonAsync("/api/auth/register", new
        {
            email = "interests@example.com", password = "Secret123", repeatPassword = "Secret123", profileType = "student", acceptTerms = true,
        })).Content.ReadFromJsonAsync<AuthResponse>();
        client.DefaultRequestHeaders.Authorization = new("Bearer", auth!.AccessToken);
        var categories = (await client.GetFromJsonAsync<List<CategoryDto>>("/api/categories"))!;

        var empty = await client.PutAsJsonAsync("/api/me/interests", new { categoryIds = Array.Empty<Guid>() });
        Assert.Equal(HttpStatusCode.BadRequest, empty.StatusCode);

        var unknown = await client.PutAsJsonAsync("/api/me/interests", new { categoryIds = new[] { Guid.NewGuid() } });
        Assert.Equal(HttpStatusCode.BadRequest, unknown.StatusCode);

        var first = await client.PutAsJsonAsync("/api/me/interests", new { categoryIds = categories.Take(3).Select(c => c.Id) });
        Assert.Equal(HttpStatusCode.OK, first.StatusCode);
        Assert.Equal(3, (await first.Content.ReadFromJsonAsync<UserDto>())!.Interests.Count);

        var second = await client.PutAsJsonAsync("/api/me/interests", new { categoryIds = new[] { categories[5].Id } });
        var user = await second.Content.ReadFromJsonAsync<UserDto>();
        Assert.Single(user!.Interests);
        Assert.Equal(categories[5].Name, user.Interests[0].Name);
    }

    [Fact]
    public async Task Me_returns_greeting_data_for_the_demo_student()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);

        var me = await client.GetFromJsonAsync<UserDto>("/api/me");

        Assert.Equal("Salome", me!.DisplayName);
        Assert.NotNull(me.AvatarUrl);
        Assert.Equal(new[] { "Pilates", "Drawing and painting", "Knitting" }, me.Interests.Select(i => i.Name));
    }

    [Fact]
    public async Task For_you_only_contains_interest_categories_with_free_seats_not_enrolled()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);
        var me = (await client.GetFromJsonAsync<UserDto>("/api/me"))!;
        var interestIds = me.Interests.Select(i => i.Id).ToHashSet();

        var page = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?section=forYou"))!;

        Assert.NotEmpty(page.Items);
        Assert.All(page.Items, c => Assert.Contains(c.Category.Id, interestIds));
        Assert.All(page.Items, c => Assert.True(c.EnrolledCount < c.Capacity));
        Assert.Contains(page.Items, c => c.Title == "Knitting for beginners" && c.EnrolledCount == 5 && c.Capacity == 20 && c.TutorName == "Ana Sarajishvili");
        Assert.DoesNotContain(page.Items, c => c.Title == "Cooking - Advanced");
    }

    [Fact]
    public async Task Last_call_contains_nearly_full_and_starting_soon_courses_with_a_seat_left()
    {
        var client = factory.CreateClient();

        var page = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?section=lastCall"))!;

        var titles = page.Items.Select(c => c.Title).ToList();
        Assert.Contains("Pilates for beginners", titles);   // 19/20
        Assert.Contains("Cooking - Advanced", titles);      // 19/20
        Assert.Contains("Padel for beginners", titles);     // starts in 2 days
        Assert.DoesNotContain("Street photography walk", titles); // 0/25, starts in 40 days
        Assert.All(page.Items, c => Assert.True(c.EnrolledCount < c.Capacity));
        Assert.Equal("Pilates for beginners", titles[0]);
    }

    [Fact]
    public async Task Popular_is_ordered_by_enrolments_and_paginates()
    {
        var client = factory.CreateClient();

        var page = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?section=popular&pageSize=3"))!;

        Assert.Equal(3, page.Items.Count);
        Assert.Equal(3, page.PageSize);
        Assert.True(page.HasMore);
        Assert.True(page.TotalCount >= 9);
        Assert.Equal(page.Items.OrderByDescending(c => c.EnrolledCount).Select(c => c.Id), page.Items.Select(c => c.Id));
        Assert.Equal(110, page.Items[0].EnrolledCount);
    }

    [Fact]
    public async Task Courses_can_be_filtered_by_category_and_reject_bad_paging()
    {
        var client = factory.CreateClient();
        var pilates = (await client.GetFromJsonAsync<List<CategoryDto>>("/api/categories"))!.First(c => c.Name == "Pilates");

        var page = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>($"/api/courses?categoryId={pilates.Id}"))!;
        Assert.Equal(2, page.TotalCount);
        Assert.All(page.Items, c => Assert.Equal("Pilates", c.Category.Name));

        Assert.Equal(HttpStatusCode.BadRequest, (await client.GetAsync("/api/courses?page=0")).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await client.GetAsync("/api/courses?pageSize=500")).StatusCode);
    }

    [Fact]
    public async Task Course_details_include_sessions_and_enrol_eligibility()
    {
        var anonymous = factory.CreateClient();
        var all = (await anonymous.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?pageSize=50"))!;
        var knitting = all.Items.First(c => c.Title == "Knitting for beginners");

        var asAnonymous = (await anonymous.GetFromJsonAsync<CourseDetailsDto>($"/api/courses/{knitting.Id}"))!;
        Assert.Equal(4, asAnonymous.Sessions.Count);
        Assert.False(asAnonymous.CanEnroll);
        Assert.Equal("Offline", asAnonymous.Format);
        Assert.NotNull(asAnonymous.Location);

        var student = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);
        var asStudent = (await student.GetFromJsonAsync<CourseDetailsDto>($"/api/courses/{knitting.Id}"))!;
        Assert.True(asStudent.CanEnroll);
        Assert.False(asStudent.IsEnrolled);

        Assert.Equal(HttpStatusCode.NotFound, (await anonymous.GetAsync($"/api/courses/{Guid.NewGuid()}")).StatusCode);
    }

    [Fact]
    public async Task Search_finds_courses_and_tutors_and_needs_two_characters()
    {
        var client = factory.CreateClient();

        Assert.Equal(HttpStatusCode.BadRequest, (await client.GetAsync("/api/search?q=p")).StatusCode);

        var result = (await client.GetFromJsonAsync<SearchResultDto>("/api/search?q=pilates"))!;
        Assert.Equal(2, result.Courses.Count);
        Assert.Empty(result.Tutors);

        var byTutor = (await client.GetFromJsonAsync<SearchResultDto>("/api/search?q=Mariam"))!;
        Assert.Equal(2, byTutor.Tutors.Count);
        Assert.All(byTutor.Tutors, t => Assert.True(t.CourseCount > 0));
    }

    [Fact]
    public async Task Unread_count_reflects_seeded_notification()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);

        var count = await client.GetFromJsonAsync<UnreadCountDto>("/api/notifications/unread-count");

        Assert.True(count!.Count >= 1);
    }
}
