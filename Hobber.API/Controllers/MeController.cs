using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hobber.API.Infrastructure;
using Hobber.Application.Contracts;
using Hobber.Application.Me;

namespace Hobber.API.Controllers;

[ApiController]
[Route("api/me")]
[Authorize]
[Produces("application/json")]
public sealed class MeController : ControllerBase
{
    /// <summary>Home header: display name, avatar, profile type and interests of the current user.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Get([FromServices] GetMeHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(ct)).ToActionResult(this);

    /// <summary>Partial profile update. Omit a field to keep it, send "" to clear it.</summary>
    [HttpPatch]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateMeRequest request, [FromServices] UpdateMeHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);

    /// <summary>Screen 03: replace the user's interests with the given category ids (at least one).</summary>
    [HttpPut("interests")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetInterests([FromBody] SetInterestsRequest request, [FromServices] SetInterestsHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);

    /// <summary>My Courses tab: enrolled courses (student) or own courses (tutor), soonest session first.</summary>
    [HttpGet("courses")]
    [ProducesResponseType(typeof(IReadOnlyList<CourseSummaryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> MyCourses([FromServices] GetMyCoursesHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(ct)).ToActionResult(this);
}
