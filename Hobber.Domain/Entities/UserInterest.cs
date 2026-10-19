namespace Hobber.Domain.Entities;

public sealed class UserInterest
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }
}
