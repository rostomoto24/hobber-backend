using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Application.Common;
using TeachMe.Domain.Entities;

namespace TeachMe.Application.Auth;

public sealed record ForgotPasswordRequest(string? Email);

/// <summary>
/// "Forgot password?" on screen 04. Always succeeds so the response does not reveal whether the e-mail exists.
/// The reset token is delivered through <see cref="IEmailSender"/> (a logging stub in development).
/// </summary>
public sealed class ForgotPasswordHandler(IAppDbContext db, IEmailSender email, IClock clock)
{
    public static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(1);

    public async Task<Result> HandleAsync(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        var v = new Validator().Required("email", request.Email).Email("email", request.Email);
        if (v.ToError() is { } error)
        {
            return Result.Failure(error);
        }

        var address = request.Email!.Trim().ToLowerInvariant();
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == address, cancellationToken);
        if (user is null)
        {
            return Result.Success();
        }

        var now = clock.UtcNow;
        var token = new PasswordResetToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = Convert.ToHexString(RandomNumberGenerator.GetBytes(32)),
            CreatedAt = now,
            ExpiresAt = now.Add(TokenLifetime),
        };

        db.PasswordResetTokens.Add(token);
        await db.SaveChangesAsync(cancellationToken);
        await email.SendPasswordResetAsync(user.Email, token.Token, cancellationToken);

        return Result.Success();
    }
}

public sealed record ResetPasswordRequest(string? Token, string? NewPassword, string? RepeatPassword);

public sealed class ResetPasswordHandler(IAppDbContext db, IPasswordHasher hasher, IClock clock)
{
    public async Task<Result> HandleAsync(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var v = new Validator()
            .Required("token", request.Token)
            .Required("newPassword", request.NewPassword).Password("newPassword", request.NewPassword);

        if (request.NewPassword is not null && request.NewPassword != request.RepeatPassword)
        {
            v.Add("repeatPassword", "Passwords do not match");
        }

        if (v.ToError() is { } error)
        {
            return Result.Failure(error);
        }

        var now = clock.UtcNow;
        var token = await db.PasswordResetTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == request.Token, cancellationToken);

        if (token is null || token.User is null || !token.IsUsable(now))
        {
            return Result.Failure(Error.Validation("token", "This reset link is invalid or has expired"));
        }

        token.User.PasswordHash = hasher.Hash(request.NewPassword!);
        token.UsedAt = now;

        var sessions = await db.RefreshTokens
            .Where(t => t.UserId == token.UserId && t.RevokedAt == null)
            .ToListAsync(cancellationToken);
        foreach (var session in sessions)
        {
            session.RevokedAt = now;
        }

        await db.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
