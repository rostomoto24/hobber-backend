namespace Hobber.Domain.Entities;

/// <summary>A Google or Facebook identity linked to a Hobber user. One row per (provider, subject).</summary>
public sealed class ExternalLogin
{
    public const string Google = "google";
    public const string Facebook = "facebook";

    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    /// <summary>Lower-case provider key: <see cref="Google"/> or <see cref="Facebook"/>.</summary>
    public string Provider { get; set; } = string.Empty;

    /// <summary>The provider's stable user id (Google <c>sub</c>, Facebook <c>id</c>).</summary>
    public string ProviderSubjectId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
