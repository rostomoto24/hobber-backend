using Microsoft.EntityFrameworkCore;
using Hobber.Application.Abstractions;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;

namespace Hobber.Application.Auth;

/// <summary>Issues an access + refresh token pair for a user and persists the refresh token.</summary>
public sealed class TokenIssuer(IAppDbContext db, ITokenService tokens, IClock clock)
{
    public async Task<AuthResponse> IssueAsync(User user, CancellationToken cancellationToken)
    {
        var now = clock.UtcNow;
        var access = tokens.CreateAccessToken(user);
        var refresh = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = tokens.CreateRefreshToken(),
            CreatedAt = now,
            ExpiresAt = now.Add(tokens.RefreshTokenLifetime),
        };

        db.RefreshTokens.Add(refresh);
        await db.SaveChangesAsync(cancellationToken);

        var withInterests = await db.Users
            .Include(u => u.Interests).ThenInclude(i => i.Category)
            .AsNoTracking()
            .FirstAsync(u => u.Id == user.Id, cancellationToken);

        return new AuthResponse(withInterests.ToDto(), access.Token, access.ExpiresAt, refresh.Token, refresh.ExpiresAt);
    }
}
