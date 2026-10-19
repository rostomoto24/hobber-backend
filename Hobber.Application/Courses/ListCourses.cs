using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;

namespace Hobber.Application.Courses;

public enum CourseSection
{
    /// <summary>Newest first.</summary>
    All,

    /// <summary>Home "For you": courses in the user's interest categories that still have seats and the user is not enrolled in.</summary>
    ForYou,

    /// <summary>Home "Last call": at least 90 % full or first upcoming session within 7 days, still has a seat.</summary>
    LastCall,

    /// <summary>Home "Popular courses": most enrolments first.</summary>
    Popular,
}

public sealed record ListCoursesQuery(
    CourseSection Section = CourseSection.All,
    Guid? CategoryId = null,
    string? Search = null,
    int Page = 1,
    int PageSize = 10);

public sealed class ListCoursesHandler(IAppDbContext db, ICurrentUser current, IClock clock)
{
    public const int MaxPageSize = 50;
    public static readonly TimeSpan LastCallWindow = TimeSpan.FromDays(7);

    public async Task<Result<PagedResult<CourseSummaryDto>>> HandleAsync(ListCoursesQuery query, CancellationToken cancellationToken)
    {
        if (query.Page < 1)
        {
            return Error.Validation("page", "Must be 1 or greater");
        }

        if (query.PageSize is < 1 or > MaxPageSize)
        {
            return Error.Validation("pageSize", $"Must be between 1 and {MaxPageSize}");
        }

        if (query.Section == CourseSection.ForYou && current.UserId is null)
        {
            return Error.Unauthorized("not_authenticated", "Log in to get recommendations.");
        }

        var now = clock.UtcNow;
        IQueryable<Course> courses = db.Courses.AsNoTracking();

        if (query.CategoryId is { } categoryId)
        {
            courses = courses.Where(c => c.CategoryId == categoryId);
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var term = query.Search.Trim();
            courses = courses.Where(c => c.Title.Contains(term) || (c.Description != null && c.Description.Contains(term)));
        }

        courses = query.Section switch
        {
            CourseSection.ForYou => ForYou(courses, current.UserId!.Value),
            CourseSection.LastCall => LastCall(courses, now),
            CourseSection.Popular => courses.OrderByDescending(c => c.Enrollments.Count).ThenByDescending(c => c.CreatedAt),
            _ => courses.OrderByDescending(c => c.CreatedAt),
        };

        var total = await courses.CountAsync(cancellationToken);
        var items = await courses
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToSummaryListAsync(now, cancellationToken);

        return new PagedResult<CourseSummaryDto>(items, query.Page, query.PageSize, total);
    }

    private IQueryable<Course> ForYou(IQueryable<Course> courses, Guid userId)
    {
        var interestIds = db.UserInterests.Where(i => i.UserId == userId).Select(i => i.CategoryId);

        return courses
            .Where(c => interestIds.Contains(c.CategoryId))
            .Where(c => c.TutorId != userId)
            .Where(c => !c.Enrollments.Any(e => e.StudentId == userId))
            .Where(c => c.Enrollments.Count < c.Capacity)
            .OrderByDescending(c => c.CreatedAt);
    }

    private static IQueryable<Course> LastCall(IQueryable<Course> courses, DateTime now)
    {
        var horizon = now.Add(LastCallWindow);

        return courses
            .Where(c => c.Enrollments.Count < c.Capacity)
            .Where(c =>
                c.Enrollments.Count * 10 >= c.Capacity * 9 ||
                c.Sessions.Any(s => s.StartsAt > now && s.StartsAt <= horizon))
            .OrderBy(c => c.Capacity - c.Enrollments.Count)
            .ThenBy(c => c.Sessions.Where(s => s.StartsAt > now).Min(s => (DateTime?)s.StartsAt) ?? DateTime.MaxValue);
    }
}
