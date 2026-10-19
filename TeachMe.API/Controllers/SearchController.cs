using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMe.API.Infrastructure;
using TeachMe.Application.Contracts;
using TeachMe.Application.Notifications;
using TeachMe.Application.Search;

namespace TeachMe.API.Controllers;

[ApiController]
[Route("api/search")]
[AllowAnonymous]
[Produces("application/json")]
public sealed class SearchController : ControllerBase
{
    /// <summary>Home search bar: courses (title, description, category) and tutors (name) matching <c>q</c>.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(SearchResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Search([FromQuery] string? q, [FromServices] SearchHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(q, ct)).ToActionResult(this);
}

[ApiController]
[Route("api/notifications")]
[Authorize]
[Produces("application/json")]
public sealed class NotificationsController : ControllerBase
{
    /// <summary>Badge count for the Home bell.</summary>
    [HttpGet("unread-count")]
    [ProducesResponseType(typeof(UnreadCountDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UnreadCount([FromServices] GetUnreadCountHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(ct)).ToActionResult(this);
}
