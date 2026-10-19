using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;

namespace Hobber.Application.Me;

internal static class MeErrors
{
    public static readonly Error NotAuthenticated = Error.Unauthorized("not_authenticated", "Log in to continue.");
    public static readonly Error UserGone = Error.Unauthorized("user_not_found", "This account no longer exists.");
}

/// <summary>Home header: greeting name, avatar, profile type, interests.</summary>
public sealed class GetMeHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result<UserDto>> HandleAsync(CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return MeErrors.NotAuthenticated;
        }

        var user = await db.Users
            .Include(u => u.Interests).ThenInclude(i => i.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        return user is null ? MeErrors.UserGone : user.ToDto();
    }
}

public sealed record UpdateMeRequest(string? FirstName, string? LastName, string? Phone, string? AvatarUrl);

/// <summary>Partial update; a null field leaves the current value untouched, an empty string clears it.</summary>
public sealed class UpdateMeHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result<UserDto>> HandleAsync(UpdateMeRequest request, CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return MeErrors.NotAuthenticated;
        }

        var v = new Validator()
            .MaxLength("firstName", request.FirstName, 100)
            .MaxLength("lastName", request.LastName, 100)
            .Phone("phone", request.Phone).MaxLength("phone", request.Phone, 32)
            .MaxLength("avatarUrl", request.AvatarUrl, 2048);

        if (v.ToError() is { } error)
        {
            return error;
        }

        var user = await db.Users
            .Include(u => u.Interests).ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null)
        {
            return MeErrors.UserGone;
        }

        if (request.FirstName is not null) user.FirstName = Clear(request.FirstName);
        if (request.LastName is not null) user.LastName = Clear(request.LastName);
        if (request.Phone is not null) user.Phone = Clear(request.Phone);
        if (request.AvatarUrl is not null) user.AvatarUrl = Clear(request.AvatarUrl);

        await db.SaveChangesAsync(cancellationToken);
        return user.ToDto();
    }

    private static string? Clear(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
}

public sealed record SetInterestsRequest(IReadOnlyList<Guid>? CategoryIds);

/// <summary>Screen 03 "What do you want to learn?". Replaces the whole set.</summary>
public sealed class SetInterestsHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result<UserDto>> HandleAsync(SetInterestsRequest request, CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return MeErrors.NotAuthenticated;
        }

        var ids = (request.CategoryIds ?? []).Distinct().ToList();
        if (ids.Count == 0)
        {
            return Error.Validation("categoryIds", "Pick at least one topic");
        }

        var known = await db.Categories.Where(c => ids.Contains(c.Id)).Select(c => c.Id).ToListAsync(cancellationToken);
        if (known.Count != ids.Count)
        {
            return Error.Validation("categoryIds", "One or more topics do not exist");
        }

        var user = await db.Users
            .Include(u => u.Interests)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null)
        {
            return MeErrors.UserGone;
        }

        db.UserInterests.RemoveRange(user.Interests);
        foreach (var id in ids)
        {
            db.UserInterests.Add(new UserInterest { UserId = userId, CategoryId = id });
        }

        await db.SaveChangesAsync(cancellationToken);

        var refreshed = await db.Users
            .Include(u => u.Interests).ThenInclude(i => i.Category)
            .AsNoTracking()
            .FirstAsync(u => u.Id == userId, cancellationToken);
        return refreshed.ToDto();
    }
}

/// <summary>My Courses tab: enrolled courses for a student, own courses for a tutor.</summary>
public sealed class GetMyCoursesHandler(IAppDbContext db, ICurrentUser current, IClock clock)
{
    public async Task<Result<IReadOnlyList<CourseSummaryDto>>> HandleAsync(CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return MeErrors.NotAuthenticated;
        }

        var user = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null)
        {
            return MeErrors.UserGone;
        }

        var now = clock.UtcNow;
        var query = user.ProfileType == Domain.Enums.ProfileType.Tutor
            ? db.Courses.Where(c => c.TutorId == userId)
            : db.Courses.Where(c => c.Enrollments.Any(e => e.StudentId == userId));

        var items = await query
            .OrderBy(c => c.Sessions.Where(s => s.StartsAt > now).Min(s => (DateTime?)s.StartsAt) ?? DateTime.MaxValue)
            .ThenByDescending(c => c.CreatedAt)
            .ToSummaryListAsync(now, cancellationToken);

        return items;
    }
}
