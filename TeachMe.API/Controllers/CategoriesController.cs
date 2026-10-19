using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMe.Application.Categories;
using TeachMe.Application.Contracts;

namespace TeachMe.API.Controllers;

[ApiController]
[Route("api/categories")]
[AllowAnonymous]
[Produces("application/json")]
public sealed class CategoriesController : ControllerBase
{
    /// <summary>All categories with their accent colour, in display order. Used by Home "Categories" and screen 03.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> Get([FromServices] GetCategoriesHandler handler, CancellationToken ct) =>
        Ok(await handler.HandleAsync(ct));
}
