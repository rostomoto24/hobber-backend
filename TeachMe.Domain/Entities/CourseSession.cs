namespace TeachMe.Domain.Entities;

/// <summary>A dated time slot of a course. Drives the Calendar tab and the "starting soon" half of "Last call".</summary>
public sealed class CourseSession
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime EndsAt { get; set; }
}
