namespace Hobber.Domain.Entities;

/// <summary>
/// A dated time slot of a course. Drives the Calendar tab, the "starting soon" half of "Last call" and the
/// weekday / time-of-day filters. Times are the course's local wall-clock time.
/// </summary>
public sealed class CourseSession
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime EndsAt { get; set; }

    /// <summary>0 = Sunday … 6 = Saturday (same numbering as <see cref="System.DayOfWeek"/>). Denormalised for filtering.</summary>
    public int DayOfWeek { get; set; }

    /// <summary>Minutes since midnight of <see cref="StartsAt"/>. Denormalised for filtering.</summary>
    public int StartMinutes { get; set; }

    public static CourseSession Create(Guid id, Guid courseId, DateTime startsAt, DateTime endsAt) => new()
    {
        Id = id,
        CourseId = courseId,
        StartsAt = startsAt,
        EndsAt = endsAt,
        DayOfWeek = (int)startsAt.DayOfWeek,
        StartMinutes = startsAt.Hour * 60 + startsAt.Minute,
    };
}
