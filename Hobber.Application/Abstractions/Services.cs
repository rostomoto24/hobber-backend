using Hobber.Domain.Entities;

namespace Hobber.Application.Abstractions;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string hash, string password);
}

public sealed record AccessToken(string Token, DateTime ExpiresAt);

public interface ITokenService
{
    AccessToken CreateAccessToken(User user);

    /// <summary>Opaque, cryptographically random refresh token string.</summary>
    string CreateRefreshToken();

    TimeSpan RefreshTokenLifetime { get; }
}

public interface IEmailSender
{
    Task SendPasswordResetAsync(string email, string token, CancellationToken cancellationToken);
}

public interface IClock
{
    DateTime UtcNow { get; }
}

public interface ICurrentUser
{
    Guid? UserId { get; }

    bool IsAuthenticated => UserId.HasValue;
}

/// <summary>What a provider tells us about the person after their token was verified.</summary>
public sealed record SocialIdentity(
    string Provider,
    string SubjectId,
    string? Email,
    bool EmailVerified,
    string? FirstName,
    string? LastName,
    string? AvatarUrl);

/// <summary>Verifies Google ID tokens and Facebook access tokens against the provider. Implemented in Infrastructure.</summary>
public interface ISocialIdentityVerifier
{
    /// <summary>Providers with credentials present in configuration (lower-case keys).</summary>
    IReadOnlyCollection<string> ConfiguredProviders { get; }

    /// <summary>Returns null when the token is invalid, expired or issued for another app.</summary>
    Task<SocialIdentity?> VerifyAsync(string provider, string token, CancellationToken cancellationToken);
}
