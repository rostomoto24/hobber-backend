using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hobber.API.Infrastructure;
using Hobber.Application.Auth;
using Hobber.Application.Contracts;

namespace Hobber.API.Controllers;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
[Produces("application/json")]
public sealed class AuthController : ControllerBase
{
    /// <summary>Screen 02: create an account with the profile type chosen on screen 01.</summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, [FromServices] RegisterHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this, r => StatusCode(StatusCodes.Status201Created, r));

    /// <summary>Screen 04: log in with e-mail and password.</summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] LoginHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);

    /// <summary>Exchange a refresh token for a new access + refresh pair (the old refresh token is revoked).</summary>
    [HttpPost("refresh")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request, [FromServices] RefreshHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);

    /// <summary>Revoke a refresh token. Always 204.</summary>
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request, [FromServices] LogoutHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);

    /// <summary>"Forgot password?": issues a reset token (e-mailed; logged in development). Always 202 for a valid e-mail format.</summary>
    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request, [FromServices] ForgotPasswordHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this, () => Accepted());

    /// <summary>Set a new password using a reset token. Revokes all sessions.</summary>
    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request, [FromServices] ResetPasswordHandler handler, CancellationToken ct) =>
        (await handler.HandleAsync(request, ct)).ToActionResult(this);
}
