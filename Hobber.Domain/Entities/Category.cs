using Hobber.Domain.Enums;

namespace Hobber.Domain.Entities;

/// <summary>
/// Two-level taxonomy shared by Home "Categories", onboarding "Interests" and the search filters (D11, D14).
/// Top-level categories (Sport, Arts &amp; crafts, …) have no parent; courses and interests point at a
/// leaf subcategory (Padel, Knitting, …).
/// </summary>
public sealed class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>Stable chip colour so a category looks the same on every screen.</summary>
    public Accent Accent { get; set; }

    public int DisplayOrder { get; set; }

    /// <summary>Null for a top-level category.</summary>
    public Guid? ParentId { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> Children { get; set; } = new List<Category>();
}
