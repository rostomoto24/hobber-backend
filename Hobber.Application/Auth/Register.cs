using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;
using Hobber.Domain.Enums;

namespace Hobber.Application.Auth;

/// <summary>Screen 02 Create an account. <paramref name="ProfileType"/> comes from screen 01.</summary>
public sealed record RegisterRequest(
    string? Email,
    string? Phone,
    string? Password,
    string? RepeatPassword,
    string? ProfileType,
    bool AcceptTerms,
    string? FirstName = null,
    string? LastName = null);

public sealed class RegisterHandler(IAppDbContext db, IPasswordHasher hasher, TokenIssuer issuer, IClock clock)
{
    public async Task<Result<AuthResponse>> HandleAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var v = new Validator()
            .Required("email", request.Email).Email("email", request.Email).MaxLength("email", request.Email, 256)
            .Phone("phone", request.Phone).MaxLength("phone", request.Phone, 32)
            .Required("password", request.Password).Password("password", request.Password)
            .MaxLength("firstName", request.FirstName, 100)
            .MaxLength("lastName", request.LastName, 100);

        if (request.Password is not null && request.Password != request.RepeatPassword)
        {
            v.Add("repeatPassword", "Passwords do not match");
        }

        if (!Enum.TryParse<ProfileType>(request.ProfileType, ignoreCase: true, out var profileType))
        {
            v.Add("profileType", "Choose Student or Tutor");
        }

        if (!request.AcceptTerms)
        {
            v.Add("acceptTerms", "Accept the Terms and Privacy Policy to continue");
        }

        if (v.ToError() is { } error)
        {
            return error;
        }

        var email = request.Email!.Trim().ToLowerInvariant();
        if (await db.Users.AnyAsync(u => u.Email == email, cancellationToken))
        {
            return Error.Conflict("email_taken", "This e-mail is already registered.");
        }

        var now = clock.UtcNow;
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim(),
            PasswordHash = hasher.Hash(request.Password!),
            FirstName = Clean(request.FirstName),
            LastName = Clean(request.LastName),
            ProfileType = profileType,
            AcceptedTermsAt = now,
            CreatedAt = now,
        };

        db.Users.Add(user);
        await db.SaveChangesAsync(cancellationToken);

        return await issuer.IssueAsync(user, cancellationToken);
    }

    private static string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
}
