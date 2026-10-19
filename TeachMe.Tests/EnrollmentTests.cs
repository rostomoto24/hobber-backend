using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using TeachMe.Application.Common;
using TeachMe.Application.Contracts;
using TeachMe.Domain.Entities;
using TeachMe.Persistance.Seeding;

namespace TeachMe.Tests;

public sealed class EnrollmentTests(HobberApiFactory factory) : IClassFixture<HobberApiFactory>
{
    private async Task<CourseSummaryDto> FindAsync(HttpClient client, string title)
    {
        var all = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?pageSize=50"))!;
        return all.Items.First(c => c.Title == title);
    }

    private static async Task<string> CodeOf(HttpResponseMessage response) =>
        (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("code").GetString()!;

    [Fact]
    public async Task Student_enrols_once_appears_in_my_courses_and_can_leave()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);
        var course = await FindAsync(client, "Ceramic bowls");

        var enrol = await client.PostAsync($"/api/courses/{course.Id}/enrollments", null);
        Assert.Equal(HttpStatusCode.NoContent, enrol.StatusCode);

        var again = await client.PostAsync($"/api/courses/{course.Id}/enrollments", null);
        Assert.Equal(HttpStatusCode.Conflict, again.StatusCode);
        Assert.Equal("already_enrolled", await CodeOf(again));

        var mine = (await client.GetFromJsonAsync<List<CourseSummaryDto>>("/api/me/courses"))!;
        Assert.Contains(mine, c => c.Id == course.Id);

        var details = (await client.GetFromJsonAsync<CourseDetailsDto>($"/api/courses/{course.Id}"))!;
        Assert.True(details.IsEnrolled);
        Assert.False(details.CanEnroll);
        Assert.Equal(course.EnrolledCount + 1, details.EnrolledCount);

        var forYou = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?section=forYou&pageSize=50"))!;
        Assert.DoesNotContain(forYou.Items, c => c.Id == course.Id);

        var leave = await client.DeleteAsync($"/api/courses/{course.Id}/enrollments/me");
        Assert.Equal(HttpStatusCode.NoContent, leave.StatusCode);
        var leaveAgain = await client.DeleteAsync($"/api/courses/{course.Id}/enrollments/me");
        Assert.Equal(HttpStatusCode.NotFound, leaveAgain.StatusCode);
    }

    [Fact]
    public async Task Full_course_rejects_enrolment()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);
        var course = await FindAsync(client, "Pilates for beginners"); // seeded 19/20

        using (var db = factory.CreateDbContext())
        {
            var filler = db.Users.First(u => u.Email == "student149@hobber.dev");
            if (!db.Enrollments.Any(e => e.CourseId == course.Id && e.StudentId == filler.Id))
            {
                db.Enrollments.Add(new Enrollment { Id = Guid.NewGuid(), CourseId = course.Id, StudentId = filler.Id, CreatedAt = DateTime.UtcNow });
                db.SaveChanges();
            }
        }

        var response = await client.PostAsync($"/api/courses/{course.Id}/enrollments", null);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        Assert.Equal("course_full", await CodeOf(response));

        var lastCall = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?section=lastCall&pageSize=50"))!;
        Assert.DoesNotContain(lastCall.Items, c => c.Id == course.Id);
    }

    [Fact]
    public async Task Tutor_cannot_enrol_and_sees_own_courses_in_my_courses()
    {
        var client = await factory.CreateClientAsAsync(DevTutor());
        var course = await FindAsync(client, "Street photography walk");

        var response = await client.PostAsync($"/api/courses/{course.Id}/enrollments", null);
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        Assert.Equal("students_only", await CodeOf(response));

        var mine = (await client.GetFromJsonAsync<List<CourseSummaryDto>>("/api/me/courses"))!;
        Assert.Equal(3, mine.Count);
        Assert.All(mine, c => Assert.Equal("Ana Sarajishvili", c.TutorName));
    }

    [Fact]
    public async Task Enrolling_in_an_unknown_course_is_not_found()
    {
        var client = await factory.CreateClientAsAsync(DevSeeder.DemoStudentEmail);

        var response = await client.PostAsync($"/api/courses/{Guid.NewGuid()}/enrollments", null);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    private static string DevTutor() => DevSeeder.DemoTutorEmail;
}
