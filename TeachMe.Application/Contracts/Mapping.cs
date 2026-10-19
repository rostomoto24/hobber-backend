using Microsoft.EntityFrameworkCore;
using TeachMe.Domain.Entities;
using TeachMe.Domain.Enums;

namespace TeachMe.Application.Contracts;

/// <summary>Flat, SQL-translatable projection of a course card; enums are converted to strings in memory.</summary>
public sealed record CourseSummaryRow(
    Guid Id,
    string Title,
    string? ImageUrl,
    Guid TutorId,
    string? TutorFirstName,
    string? TutorLastName,
    string TutorEmail,
    Guid CategoryId,
    string CategoryName,
    Accent CategoryAccent,
    int CategoryDisplayOrder,
    CourseFormat Format,
    decimal Price,
    int EnrolledCount,
    int Capacity,
    DateTime? NextSessionAt);

public static class Mapping
{
    public static CategoryDto ToDto(this Category category) =>
        new(category.Id, category.Name, category.Accent.ToString(), category.DisplayOrder);

    public static UserDto ToDto(this User user) =>
        new(
            user.Id,
            user.Email,
            user.Phone,
            user.FirstName,
            user.LastName,
            user.DisplayName,
            user.AvatarUrl,
            user.ProfileType.ToString(),
            user.Interests
                .Where(i => i.Category is not null)
                .OrderBy(i => i.Category!.DisplayOrder)
                .Select(i => i.Category!.ToDto())
                .ToList());

    public static string PersonName(string? firstName, string? lastName, string email)
    {
        var full = string.Join(' ', new[] { firstName, lastName }.Where(s => !string.IsNullOrWhiteSpace(s)));
        return full.Length > 0 ? full : email.Split('@')[0];
    }

    public static IQueryable<CourseSummaryRow> ProjectToRows(this IQueryable<Course> courses, DateTime now) =>
        courses.Select(c => new CourseSummaryRow(
            c.Id,
            c.Title,
            c.ImageUrl,
            c.TutorId,
            c.Tutor!.FirstName,
            c.Tutor.LastName,
            c.Tutor.Email,
            c.Category!.Id,
            c.Category.Name,
            c.Category.Accent,
            c.Category.DisplayOrder,
            c.Format,
            c.Price,
            c.Enrollments.Count,
            c.Capacity,
            c.Sessions.Where(s => s.StartsAt > now).Min(s => (DateTime?)s.StartsAt)));

    public static CourseSummaryDto ToDto(this CourseSummaryRow r) =>
        new(
            r.Id,
            r.Title,
            r.ImageUrl,
            r.TutorId,
            PersonName(r.TutorFirstName, r.TutorLastName, r.TutorEmail),
            new CategoryDto(r.CategoryId, r.CategoryName, r.CategoryAccent.ToString(), r.CategoryDisplayOrder),
            r.Format.ToString(),
            r.Price,
            r.EnrolledCount,
            r.Capacity,
            r.NextSessionAt);

    /// <summary>Runs the query (keep ordering, Skip and Take before this call) and maps to card DTOs.</summary>
    public static async Task<List<CourseSummaryDto>> ToSummaryListAsync(this IQueryable<Course> courses, DateTime now, CancellationToken cancellationToken)
    {
        var rows = await courses.ProjectToRows(now).ToListAsync(cancellationToken);
        return rows.Select(r => r.ToDto()).ToList();
    }
}
