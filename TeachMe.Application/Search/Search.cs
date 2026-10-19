using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Application.Common;
using TeachMe.Application.Contracts;
using TeachMe.Domain.Enums;

namespace TeachMe.Application.Search;

/// <summary>Home search bar: "Search courses, tutors, profiles, etc."</summary>
public sealed class SearchHandler(IAppDbContext db, IClock clock)
{
    public const int Limit = 20;

    public async Task<Result<SearchResultDto>> HandleAsync(string? q, CancellationToken cancellationToken)
    {
        var term = q?.Trim();
        if (string.IsNullOrEmpty(term) || term.Length < 2)
        {
            return Error.Validation("q", "Type at least 2 characters");
        }

        var now = clock.UtcNow;

        var courses = await db.Courses.AsNoTracking()
            .Where(c => c.Title.Contains(term)
                || (c.Description != null && c.Description.Contains(term))
                || c.Category!.Name.Contains(term))
            .OrderByDescending(c => c.Enrollments.Count)
            .Take(Limit)
            .ToSummaryListAsync(now, cancellationToken);

        var tutorRows = await db.Users.AsNoTracking()
            .Where(u => u.ProfileType == ProfileType.Tutor)
            .Where(u => (u.FirstName != null && u.FirstName.Contains(term))
                || (u.LastName != null && u.LastName.Contains(term)))
            .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
            .Take(Limit)
            .Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.AvatarUrl,
                CourseCount = db.Courses.Count(c => c.TutorId == u.Id),
            })
            .ToListAsync(cancellationToken);

        var tutors = tutorRows
            .Select(t => new TutorSummaryDto(t.Id, Mapping.PersonName(t.FirstName, t.LastName, t.Email), t.AvatarUrl, t.CourseCount))
            .ToList();

        return new SearchResultDto(courses, tutors);
    }
}
