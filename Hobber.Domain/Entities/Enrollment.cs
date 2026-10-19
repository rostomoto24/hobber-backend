namespace Hobber.Domain.Entities;

public sealed class Enrollment
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public Guid StudentId { get; set; }

    public User? Student { get; set; }

    public DateTime CreatedAt { get; set; }
}
