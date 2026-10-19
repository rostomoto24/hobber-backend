namespace Hobber.Application.Common;

public enum ErrorType
{
    Validation,
    Unauthorized,
    Forbidden,
    NotFound,
    Conflict,
}

/// <summary>
/// A failure the API turns into an RFC 7807 problem response.
/// <see cref="Code"/> is a stable machine-readable identifier the frontend can switch on.
/// </summary>
public sealed record Error(ErrorType Type, string Code, string Message, IReadOnlyDictionary<string, string[]>? Fields = null)
{
    public static Error Validation(IReadOnlyDictionary<string, string[]> fields) =>
        new(ErrorType.Validation, "validation_failed", "One or more fields are invalid.", fields);

    public static Error Validation(string field, string message) =>
        Validation(new Dictionary<string, string[]> { [field] = [message] });

    public static Error Unauthorized(string code, string message) => new(ErrorType.Unauthorized, code, message);

    public static Error Forbidden(string code, string message) => new(ErrorType.Forbidden, code, message);

    public static Error NotFound(string code, string message) => new(ErrorType.NotFound, code, message);

    public static Error Conflict(string code, string message) => new(ErrorType.Conflict, code, message);
}
