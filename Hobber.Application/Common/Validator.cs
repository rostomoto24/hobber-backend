using System.Text.RegularExpressions;

namespace Hobber.Application.Common;

/// <summary>Collects field errors; <see cref="ToError"/> yields null when everything passed.</summary>
public sealed partial class Validator
{
    private readonly Dictionary<string, List<string>> _errors = new(StringComparer.OrdinalIgnoreCase);

    public bool HasErrors => _errors.Count > 0;

    public Validator Add(string field, string message)
    {
        if (!_errors.TryGetValue(field, out var list))
        {
            list = [];
            _errors[field] = list;
        }

        list.Add(message);
        return this;
    }

    public Validator Required(string field, string? value, string message = "Required") =>
        string.IsNullOrWhiteSpace(value) ? Add(field, message) : this;

    public Validator Email(string field, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value) && !EmailPattern().IsMatch(value.Trim()))
        {
            Add(field, "Enter a valid e-mail");
        }

        return this;
    }

    public Validator Phone(string field, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value) && !PhonePattern().IsMatch(value.Trim()))
        {
            Add(field, "Enter a valid phone number");
        }

        return this;
    }

    public Validator Password(string field, string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return this;
        }

        if (value.Length < 8 || !value.Any(char.IsLetter) || !value.Any(char.IsDigit))
        {
            Add(field, "Use at least 8 characters with a letter and a number");
        }

        return this;
    }

    public Validator MaxLength(string field, string? value, int max)
    {
        if (value is not null && value.Length > max)
        {
            Add(field, $"Must be at most {max} characters");
        }

        return this;
    }

    public Error? ToError() => HasErrors
        ? Error.Validation(_errors.ToDictionary(kv => kv.Key, kv => kv.Value.ToArray()))
        : null;

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailPattern();

    [GeneratedRegex(@"^\+?[0-9 ()-]{6,20}$")]
    private static partial Regex PhonePattern();
}
