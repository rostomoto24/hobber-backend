using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Domain.Entities;
using Hobber.Domain.Enums;

namespace Hobber.Application.Courses;

/// <summary>
/// Enrol the current student. Rules: only students enrol, never in their own course, never twice,
/// never past capacity. Enrolment is free in MVP (D5).
/// </summary>
public sealed class EnrollHandler(IAppDbContext db, ICurrentUser current, IClock clock)
{
    public async Task<Result> HandleAsync(Guid courseId, CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return Result.Failure(Error.Unauthorized("not_authenticated", "Log in to enrol."));
        }

        var user = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is null)
        {
            return Result.Failure(Error.Unauthorized("user_not_found", "This account no longer exists."));
        }

        if (user.ProfileType != ProfileType.Student)
        {
            return Result.Failure(Error.Forbidden("students_only", "Only student profiles can enrol in courses."));
        }

        var course = await db.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == courseId, cancellationToken);
        if (course is null)
        {
            return Result.Failure(CourseErrors.NotFound);
        }

        if (course.TutorId == userId)
        {
            return Result.Failure(Error.Forbidden("own_course", "You cannot enrol in your own course."));
        }

        if (await db.Enrollments.AnyAsync(e => e.CourseId == courseId && e.StudentId == userId, cancellationToken))
        {
            return Result.Failure(Error.Conflict("already_enrolled", "You are already enrolled in this course."));
        }

        var enrolled = await db.Enrollments.CountAsync(e => e.CourseId == courseId, cancellationToken);
        if (!Course.HasFreeSeat(enrolled, course.Capacity))
        {
            return Result.Failure(Error.Conflict("course_full", "This course is full."));
        }

        db.Enrollments.Add(new Enrollment
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            StudentId = userId,
            CreatedAt = clock.UtcNow,
        });

        db.Notifications.Add(new Notification
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = $"You're enrolled in {course.Title}",
            Body = "See your sessions in the Calendar tab.",
            CreatedAt = clock.UtcNow,
        });

        try
        {
            await db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException)
        {
            // Unique index on (CourseId, StudentId) caught a concurrent duplicate.
            return Result.Failure(Error.Conflict("already_enrolled", "You are already enrolled in this course."));
        }

        return Result.Success();
    }
}

public sealed class UnenrollHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result> HandleAsync(Guid courseId, CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return Result.Failure(Error.Unauthorized("not_authenticated", "Log in to continue."));
        }

        var enrollment = await db.Enrollments
            .FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == userId, cancellationToken);

        if (enrollment is null)
        {
            return Result.Failure(Error.NotFound("not_enrolled", "You are not enrolled in this course."));
        }

        db.Enrollments.Remove(enrollment);
        await db.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
