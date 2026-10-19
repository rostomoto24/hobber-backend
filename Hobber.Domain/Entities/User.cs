using Hobber.Domain.Enums;

namespace Hobber.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }

    /// <summary>Stored lower-cased; unique.</summary>
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    /// <summary>Null for accounts created through Google or Facebook that never set a password.</summary>
    public string? PasswordHash { get; set; }

    /// <summary>Optional until D9 decides where the name is collected. Home greets by first name.</summary>
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AvatarUrl { get; set; }

    public ProfileType ProfileType { get; set; }

    public DateTime AcceptedTermsAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<UserInterest> Interests { get; set; } = new List<UserInterest>();

    public ICollection<ExternalLogin> ExternalLogins { get; set; } = new List<ExternalLogin>();

    /// <summary>Name shown in "Hi, {name}"; falls back to the e-mail local part when no name is known.</summary>
    public string DisplayName =>
        !string.IsNullOrWhiteSpace(FirstName) ? FirstName : Email.Split('@')[0];

    public string FullName =>
        string.Join(' ', new[] { FirstName, LastName }.Where(s => !string.IsNullOrWhiteSpace(s)))
        is { Length: > 0 } full ? full : DisplayName;
}
