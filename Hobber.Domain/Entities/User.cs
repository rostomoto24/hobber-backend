using Hobber.Domain.Enums;

namespace Hobber.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }

    /// <summary>Stored lower-cased; unique.</summary>
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>Optional until D9 decides where the name is collected. Home greets by first name.</summary>
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AvatarUrl { get; set; }

    public ProfileType ProfileType { get; set; }

    public DateTime AcceptedTermsAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<UserInterest> Interests { get; set; } = new List<UserInterest>();

    /// <summary>Name shown in "Hi, {name}"; falls back to the e-mail local part when no name is known.</summary>
    public string DisplayName =>
        !string.IsNullOrWhiteSpace(FirstName) ? FirstName : Email.Split('@')[0];

    public string FullName =>
        string.Join(' ', new[] { FirstName, LastName }.Where(s => !string.IsNullOrWhiteSpace(s)))
        is { Length: > 0 } full ? full : DisplayName;
}
