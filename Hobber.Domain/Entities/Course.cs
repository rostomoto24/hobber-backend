using Hobber.Domain.Enums;

namespace Hobber.Domain.Entities;

public sealed class Course
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid TutorId { get; set; }

    public User? Tutor { get; set; }

    /// <summary>A leaf category (subcategory), e.g. Padel under Sport.</summary>
    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }

    public CourseFormat Format { get; set; }

    public CourseLevel Level { get; set; }

    /// <summary>Required for offline courses, null for online.</summary>
    public string? Location { get; set; }

    /// <summary>Kept in the model from day one (D5); enrolment is free in MVP.</summary>
    public decimal Price { get; set; }

    public int Capacity { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<CourseSession> Sessions { get; set; } = new List<CourseSession>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    /// <summary>Capacity rule for the "Last call" section: 90 % or more of the seats are taken.</summary>
    public static bool IsNearlyFull(int enrolled, int capacity) =>
        capacity > 0 && enrolled * 10 >= capacity * 9;

    /// <summary>Domain rule: a course never exceeds its capacity.</summary>
    public static bool HasFreeSeat(int enrolled, int capacity) => enrolled < capacity;
}
