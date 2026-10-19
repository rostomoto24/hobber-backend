using Hobber.API.Infrastructure;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Application.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hobber.API.Controllers;

[ApiController]
[Route("api/courses")]
[Produces("application/json")]
public sealed class CoursesController : ControllerBase
{
    /// <summary>
    /// Browse and filter courses. <c>section</c>: <c>all</c> (default, newest first), <c>forYou</c> (requires auth;
    /// interest categories, free seats, not enrolled), <c>lastCall</c> (90 % full or first session within 7 days),
    /// <c>popular</c> (most enrolled), <c>recommended</c> (free seats; <c>categoryIds</c> act as a ranking hint).
    /// Filters (comma-separated): <c>categoryIds</c> (parents expand to their subcategories), <c>levels</c>
    /// (NotApplicable, Beginner, Advanced, Professional), <c>weekdays</c> (0 = Sunday … 6, or names),
    /// <c>timeFrom</c>/<c>timeTo</c> (HH:mm, matches a session starting in the range), <c>search</c> (title, description, category).
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PagedResult<CourseSummaryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> List(
        [FromQuery] CourseSection section = CourseSection.All,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] string? categoryIds = null,
        [FromQuery] string? search = null,
        [FromQuery] string? levels = null,
        [FromQuery] string? weekdays = null,
        [FromQuery] string? timeFrom = null,
        [FromQuery] string? timeTo = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromServices] ListCoursesHandler handler = null!,
        CancellationToken ct = default)
    {
        var parsed = CourseQueryParser.Parse(section, categoryId, categoryIds, search, levels, weekdays, timeFrom, timeTo, page, pageSize);
        if (!parsed.IsSuccess)
        {
            return this.Problem(parsed.Error);
        }

        return (await handler.HandleAsync(parsed.Value, ct)).ToActionResult(this);
    }

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
