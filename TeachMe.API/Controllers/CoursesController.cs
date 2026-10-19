using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMe.API.Infrastructure;
using TeachMe.Application.Common;
using TeachMe.Application.Contracts;
using TeachMe.Application.Courses;

namespace TeachMe.API.Controllers;

[ApiController]
[Route("api/courses")]
[Produces("application/json")]
public sealed class CoursesController : ControllerBase
{
    /// <summary>
    /// Browse courses. <c>section</c> selects a Home section: <c>all</c> (default, newest first),
    /// <c>forYou</c> (requires auth; interest categories, free seats, not enrolled), <c>lastCall</c>
    /// (90 % full or first session within 7 days), <c>popular</c> (most enrolled).
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PagedResult<CourseSummaryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List(
        [FromQuery] CourseSection section = CourseSection.All,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] string? search = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromServices] ListCoursesHandler handler = null!,
        CancellationToken ct = default) =>
        (await handler.HandleAsync(new ListCoursesQuery(section, categoryId, search, page, pageSize), ct)).ToActionResult(this);

    /// <summary>Course details, including sessions and whether the current user can enrol.</summary>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CourseDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id, [FromServices] GetCourseHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(id, ct)).ToActionResult(this);

    /// <summary>Enrol the current student. 409 when full or already enrolled, 403 for tutors or own course.</summary>
    [HttpPost("{id:guid}/enrollments")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Enroll(Guid id, [FromServices] EnrollHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(id, ct)).ToActionResult(this);

    /// <summary>Leave a course the current user is enrolled in.</summary>
    [HttpDelete("{id:guid}/enrollments/me")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Unenroll(Guid id, [FromServices] UnenrollHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(id, ct)).ToActionResult(this);
}
