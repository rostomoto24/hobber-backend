using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;

namespace Hobber.Application.Auth;

public sealed record RefreshRequest(string? RefreshToken);

/// <summary>Rotates the refresh token: the presented one is revoked and a fresh pair is issued.</summary>
public sealed class RefreshHandler(IAppDbContext db, TokenIssuer issuer, IClock clock)
{
    public async Task<Result<AuthResponse>> HandleAsync(RefreshRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
        {
            return Error.Validation("refreshToken", "Required");
        }

        var token = await db.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == request.RefreshToken, cancellationToken);

        var now = clock.UtcNow;
        if (token is null || token.User is null || !token.IsActive(now))
        {
            return Error.Unauthorized("invalid_refresh_token", "Session expired. Log in again.");
        }

        token.RevokedAt = now;
        await db.SaveChangesAsync(cancellationToken);

        return await issuer.IssueAsync(token.User, cancellationToken);
    }
}

public sealed record LogoutRequest(string? RefreshToken);

public sealed class LogoutHandler(IAppDbContext db, IClock clock)
{
    public async Task<Result> HandleAsync(LogoutRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
        {
            return Result.Success();
        }

        var token = await db.RefreshTokens.FirstOrDefaultAsync(t => t.Token == request.RefreshToken, cancellationToken);
        if (token is { RevokedAt: null })
        {
            token.RevokedAt = clock.UtcNow;
            await db.SaveChangesAsync(cancellationToken);
        }

        return Result.Success();
    }
}
