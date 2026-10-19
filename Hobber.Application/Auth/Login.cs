using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hobber.Application.Auth;

/// <summary>Screen 04 Welcome back.</summary>
public sealed record LoginRequest(string? Email, string? Password);

public sealed class LoginHandler(IAppDbContext db, IPasswordHasher hasher, TokenIssuer issuer)
{
    private static readonly Error InvalidCredentials =
        Error.Unauthorized("invalid_credentials", "E-mail or password is incorrect");

    public async Task<Result<AuthResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var v = new Validator()
            .Required("email", request.Email)
            .Required("password", request.Password);

        if (v.ToError() is { } error)
        {
            return error;
        }

        var email = request.Email!.Trim().ToLowerInvariant();
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        // Accounts created through Google/Facebook have no password until they set one via "Forgot password".
        if (user is null || user.PasswordHash is null || !hasher.Verify(user.PasswordHash, request.Password!))
        {
            return InvalidCredentials;
        }

        return await issuer.IssueAsync(user, cancellationToken);
    }
}
