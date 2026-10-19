using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;
using Hobber.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hobber.Application.Courses;

public enum CourseSection
{
    /// <summary>Newest first.</summary>
    All,

    /// <summary>Home "For you" for a logged-in user: courses in their interest categories that still have seats and they are not enrolled in.</summary>
    ForYou,

    /// <summary>Home "Last call": at least 90 % full or first upcoming session within 7 days, still has a seat.</summary>
    LastCall,

    /// <summary>Home "Popular courses": most enrolments first.</summary>
    Popular,

    /// <summary>
    /// Home "For you" for anonymous visitors (and the fallback when a user has no matches): courses with a free
    /// seat, those in the hinted <see cref="ListCoursesQuery.CategoryIds"/> first, then most enrolled, then newest.
    /// </summary>
    Recommended,
}

/// <summary>
/// Browse/filter query. Category ids may be parents (expanded to their subcategories) or leaves. For
/// <see cref="CourseSection.Recommended"/> the category ids are a ranking hint, not a filter.
/// </summary>
public sealed record ListCoursesQuery(
    CourseSection Section = CourseSection.All,
    IReadOnlyList<Guid>? CategoryIds = null,
    string? Search = null,
    IReadOnlyList<CourseLevel>? Levels = null,
    IReadOnlyList<int>? Weekdays = null,
    int? TimeFromMinutes = null,
    int? TimeToMinutes = null,
    int Page = 1,
    int PageSize = 10);

public sealed class ListCoursesHandler(IAppDbContext db, ICurrentUser current, IClock clock)
{
    public const int MaxPageSize = 50;
    public static readonly TimeSpan LastCallWindow = TimeSpan.FromDays(7);

    public async Task<Result<PagedResult<CourseSummaryDto>>> HandleAsync(ListCoursesQuery query, CancellationToken cancellationToken)
    {
        var v = new Validator();
        if (query.Page < 1) v.Add("page", "Must be 1 or greater");
        if (query.PageSize is < 1 or > MaxPageSize) v.Add("pageSize", $"Must be between 1 and {MaxPageSize}");
        if (query.Weekdays is not null && query.Weekdays.Any(d => d is < 0 or > 6)) v.Add("weekdays", "Use 0 (Sunday) to 6 (Saturday)");
        if (query.TimeFromMinutes is < 0 or > 1439) v.Add("timeFrom", "Use HH:mm between 00:00 and 23:59");
        if (query.TimeToMinutes is < 0 or > 1439) v.Add("timeTo", "Use HH:mm between 00:00 and 23:59");
        if (query.TimeFromMinutes is { } f && query.TimeToMinutes is { } t && f > t) v.Add("timeTo", "Must not be earlier than timeFrom");
        if (v.ToError() is { } error) return error;

        if (query.Section == CourseSection.ForYou && current.UserId is null)
        {
            return Error.Unauthorized("not_authenticated", "Log in to get recommendations.");
        }

        var now = clock.UtcNow;
        IQueryable<Course> courses = db.Courses.AsNoTracking();

        var categoryIds = await ExpandCategoriesAsync(query.CategoryIds, cancellationToken);
        if (categoryIds is { Count: > 0 } && query.Section != CourseSection.Recommended)
        {
            courses = courses.Where(c => categoryIds.Contains(c.CategoryId));
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var term = query.Search.Trim();
            courses = courses.Where(c => c.Title.Contains(term) || (c.Description != null && c.Description.Contains(term)) || c.Category!.Name.Contains(term));
        }

        if (query.Levels is { Count: > 0 } levels)
        {
            courses = courses.Where(c => levels.Contains(c.Level));
        }

        if (query.Weekdays is { Count: > 0 } || query.TimeFromMinutes is not null || query.TimeToMinutes is not null)
        {
            var weekdays = query.Weekdays is { Count: > 0 } w ? w : null;
            var from = query.TimeFromMinutes ?? 0;
            var to = query.TimeToMinutes ?? 1439;
            courses = courses.Where(c => c.Sessions.Any(s =>
                (weekdays == null || weekdays.Contains(s.DayOfWeek)) &&
                s.StartMinutes >= from && s.StartMinutes <= to));
        }

        courses = query.Section switch
        {
            CourseSection.ForYou => ForYou(courses, current.UserId!.Value),
            CourseSection.LastCall => LastCall(courses, now),
            CourseSection.Popular => courses.OrderByDescending(c => c.Enrollments.Count).ThenByDescending(c => c.CreatedAt),
            CourseSection.Recommended => Recommended(courses, categoryIds),
            _ => courses.OrderByDescending(c => c.CreatedAt),
        };

        var total = await courses.CountAsync(cancellationToken);
        var items = await courses
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToSummaryListAsync(now, cancellationToken);

        return new PagedResult<CourseSummaryDto>(items, query.Page, query.PageSize, total);
    }

    /// <summary>Parents expand to their subcategories; unknown ids are kept (they simply match nothing).</summary>
    private async Task<List<Guid>?> ExpandCategoriesAsync(IReadOnlyList<Guid>? ids, CancellationToken cancellationToken)
    {
        if (ids is null || ids.Count == 0) return null;
        var distinct = ids.Distinct().ToList();
        var children = await db.Categories
            .Where(c => c.ParentId != null && distinct.Contains(c.ParentId.Value))
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);
        return distinct.Concat(children).Distinct().ToList();
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

    private static IQueryable<Course> Recommended(IQueryable<Course> courses, List<Guid>? hintIds)
    {
        var withSeat = courses.Where(c => c.Enrollments.Count < c.Capacity);
        return hintIds is { Count: > 0 }
            ? withSeat
                .OrderBy(c => hintIds.Contains(c.CategoryId) ? 0 : 1)
                .ThenByDescending(c => c.Enrollments.Count)
                .ThenByDescending(c => c.CreatedAt)
            : withSeat
                .OrderByDescending(c => c.Enrollments.Count)
                .ThenByDescending(c => c.CreatedAt);
    }
}

/// <summary>Turns the comma-separated query-string filters of GET /api/courses into a typed query, with field errors.</summary>
public static class CourseQueryParser
{
    public static Result<ListCoursesQuery> Parse(
        CourseSection section,
        Guid? categoryId,
        string? categoryIds,
        string? search,
        string? levels,
        string? weekdays,
        string? timeFrom,
        string? timeTo,
        int page,
        int pageSize)
    {
        var v = new Validator();

        var ids = new List<Guid>();
        if (categoryId is { } single) ids.Add(single);
        foreach (var raw in Split(categoryIds))
        {
            if (Guid.TryParse(raw, out var id)) ids.Add(id);
            else v.Add("categoryIds", $"'{raw}' is not a category id");
        }

        var parsedLevels = new List<CourseLevel>();
        foreach (var raw in Split(levels))
        {
            if (Enum.TryParse<CourseLevel>(raw, ignoreCase: true, out var level)) parsedLevels.Add(level);
            else v.Add("levels", $"'{raw}' is not a level (NotApplicable, Beginner, Advanced, Professional)");
        }

        var parsedDays = new List<int>();
        foreach (var raw in Split(weekdays))
        {
            if (int.TryParse(raw, out var n) && n is >= 0 and <= 6) parsedDays.Add(n);
            else if (Enum.TryParse<DayOfWeek>(raw, ignoreCase: true, out var day)) parsedDays.Add((int)day);
            else v.Add("weekdays", $"'{raw}' is not a weekday (0-6 or Monday…Sunday)");
        }

        var from = ParseTime(timeFrom, "timeFrom", v);
        var to = ParseTime(timeTo, "timeTo", v);

        if (v.ToError() is { } error) return error;

        return new ListCoursesQuery(
            section,
            ids.Count > 0 ? ids : null,
            search,
            parsedLevels.Count > 0 ? parsedLevels : null,
            parsedDays.Count > 0 ? parsedDays : null,
            from,
            to,
            page,
            pageSize);
    }

    private static IEnumerable<string> Split(string? csv) =>
        string.IsNullOrWhiteSpace(csv) ? [] : csv.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    private static int? ParseTime(string? raw, string field, Validator v)
    {
        if (string.IsNullOrWhiteSpace(raw)) return null;
        if (TimeOnly.TryParseExact(raw.Trim(), "HH:mm", out var time)) return time.Hour * 60 + time.Minute;
        v.Add(field, "Use HH:mm, e.g. 18:30");
        return null;
    }
}
