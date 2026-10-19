namespace Hobber.Domain.Entities;

public sealed class Notification
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Body { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ReadAt { get; set; }
}
