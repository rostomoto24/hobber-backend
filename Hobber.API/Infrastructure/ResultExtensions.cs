using Microsoft.AspNetCore.Mvc;
using Hobber.Application.Common;

namespace Hobber.API.Infrastructure;

/// <summary>
/// Maps <see cref="Result"/> failures to RFC 7807 problem responses.
/// Shape: { type, title, status, detail, code, errors? } where <c>code</c> is the stable machine-readable code
/// and <c>errors</c> (validation only) maps field name to messages.
/// </summary>
public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller) =>
        result.IsSuccess ? controller.Ok(result.Value) : controller.Problem(result.Error);

    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller, Func<T, IActionResult> onSuccess) =>
        result.IsSuccess ? onSuccess(result.Value) : controller.Problem(result.Error);

    public static IActionResult ToActionResult(this Result result, ControllerBase controller, Func<IActionResult>? onSuccess = null) =>
        result.IsSuccess ? (onSuccess?.Invoke() ?? controller.NoContent()) : controller.Problem(result.Error);

    public static IActionResult Problem(this ControllerBase controller, Error error)
    {
        var status = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        ProblemDetails problem = error.Fields is { } fields
            ? new ValidationProblemDetails(fields.ToDictionary(kv => kv.Key, kv => kv.Value)) { Status = status, Title = error.Message }
            : new ProblemDetails { Status = status, Title = error.Message, Detail = error.Message };

        problem.Type = $"https://hobber.app/errors/{error.Code}";
        problem.Extensions["code"] = error.Code;

        return new ObjectResult(problem) { StatusCode = status, ContentTypes = { "application/problem+json" } };
    }
}
