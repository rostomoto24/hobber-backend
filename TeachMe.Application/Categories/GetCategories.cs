using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Application.Contracts;

namespace TeachMe.Application.Categories;

/// <summary>Home "Categories" row and the chip cloud on screen 03 (one taxonomy, D11).</summary>
public sealed class GetCategoriesHandler(IAppDbContext db)
{
    public async Task<IReadOnlyList<CategoryDto>> HandleAsync(CancellationToken cancellationToken)
    {
        var categories = await db.Categories
            .AsNoTracking()
            .OrderBy(c => c.DisplayOrder).ThenBy(c => c.Name)
            .ToListAsync(cancellationToken);

        return categories.Select(c => c.ToDto()).ToList();
    }
}
