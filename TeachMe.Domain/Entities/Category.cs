using TeachMe.Domain.Enums;

namespace TeachMe.Domain.Entities;

/// <summary>
/// Single taxonomy for Home "Categories" and onboarding "Interests" (D11).
/// A student's interests are the categories they selected.
/// </summary>
public sealed class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>Stable chip colour so a category looks the same on every screen.</summary>
    public Accent Accent { get; set; }

    public int DisplayOrder { get; set; }
}
