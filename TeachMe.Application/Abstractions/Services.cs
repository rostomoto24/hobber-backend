using TeachMe.Domain.Entities;

namespace TeachMe.Application.Abstractions;

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
