namespace Hobber.Domain.Entities;

public sealed class PasswordResetToken
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UsedAt { get; set; }

    public bool IsUsable(DateTime now) => UsedAt is null && ExpiresAt > now;
}
