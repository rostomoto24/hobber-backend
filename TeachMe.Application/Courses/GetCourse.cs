using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Application.Common;
using TeachMe.Application.Contracts;
using TeachMe.Domain.Entities;
using TeachMe.Domain.Enums;

namespace TeachMe.Application.Courses;

internal static class CourseErrors
{
    public static readonly Error NotFound = Error.NotFound("course_not_found", "This course does not exist.");
}

/// <summary>Course details (screen 11, undesigned): what a card on Home opens.</summary>
public sealed class GetCourseHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result<CourseDetailsDto>> HandleAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var course = await db.Courses
            .AsNoTracking()
            .Include(c => c.Tutor)
            .Include(c => c.Category)
            .Include(c => c.Sessions)
            .FirstOrDefaultAsync(c => c.Id == courseId, cancellationToken);

        if (course is null || course.Tutor is null || course.Category is null)
        {
            return CourseErrors.NotFound;
        }

        var enrolled = await db.Enrollments.CountAsync(e => e.CourseId == courseId, cancellationToken);
        var userId = current.UserId;
        var isEnrolled = userId is not null &&
            await db.Enrollments.AnyAsync(e => e.CourseId == courseId && e.StudentId == userId, cancellationToken);

        ProfileType? profile = null;
        if (userId is not null)
        {
            profile = await db.Users.Where(u => u.Id == userId).Select(u => (ProfileType?)u.ProfileType).FirstOrDefaultAsync(cancellationToken);
        }

        var canEnroll = userId is not null
            && profile == ProfileType.Student
            && !isEnrolled
            && course.TutorId != userId
            && Course.HasFreeSeat(enrolled, course.Capacity);

        return new CourseDetailsDto(
            course.Id,
            course.Title,
            course.Description,
            course.ImageUrl,
            course.TutorId,
            course.Tutor.FullName,
            course.Tutor.AvatarUrl,
            course.Category.ToDto(),
            course.Format.ToString(),
            course.Location,
            course.Price,
            enrolled,
            course.Capacity,
            course.Sessions.OrderBy(s => s.StartsAt).Select(s => new CourseSessionDto(s.Id, s.StartsAt, s.EndsAt)).ToList(),
            isEnrolled,
            canEnroll);
    }
}
