using Hobber.Application.Abstractions;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Domain.Entities;
using Hobber.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hobber.Application.Auth;

/// <summary>
/// "Sign Up with Google/Facebook" (screen 02) and "Log in with Google/Facebook" (screen 04).
/// <paramref name="Token"/> is a Google ID token or a Facebook user access token obtained on the device.
/// <paramref name="ProfileType"/> is only needed when the person has no Hobber account yet (sign-up path).
/// </summary>
public sealed record SocialLoginRequest(string? Provider, string? Token, string? ProfileType = null);

public sealed record AuthProvidersDto(bool Google, bool Facebook);

public sealed class SocialLoginHandler(IAppDbContext db, ISocialIdentityVerifier verifier, TokenIssuer issuer, IClock clock)
{
    private static readonly string[] KnownProviders = [ExternalLogin.Google, ExternalLogin.Facebook];

    public async Task<Result<AuthResponse>> HandleAsync(SocialLoginRequest request, CancellationToken cancellationToken)
    {
        var provider = request.Provider?.Trim().ToLowerInvariant() ?? string.Empty;
        var v = new Validator().Required("token", request.Token);
        if (!KnownProviders.Contains(provider))
        {
            v.Add("provider", "Use google or facebook");
        }

        ProfileType? profileType = null;
        if (!string.IsNullOrWhiteSpace(request.ProfileType))
        {
            if (Enum.TryParse<ProfileType>(request.ProfileType, ignoreCase: true, out var parsed))
            {
                profileType = parsed;
            }
            else
            {
                v.Add("profileType", "Choose Student or Tutor");
            }
        }

        if (v.ToError() is { } error)
        {
            return error;
        }

        if (!verifier.ConfiguredProviders.Contains(provider))
        {
            return Error.Conflict("provider_not_configured", $"Signing in with {Capitalize(provider)} is not available yet.");
        }

        var identity = await verifier.VerifyAsync(provider, request.Token!, cancellationToken);
        if (identity is null)
        {
            return Error.Unauthorized("invalid_social_token", $"We could not verify your {Capitalize(provider)} sign-in. Try again.");
        }

        var now = clock.UtcNow;

        // 1. Already linked: plain login.
        var link = await db.ExternalLogins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.Provider == provider && l.ProviderSubjectId == identity.SubjectId, cancellationToken);
        if (link?.User is { } linkedUser)
        {
            return await issuer.IssueAsync(linkedUser, cancellationToken);
        }

        var email = identity.Email?.Trim().ToLowerInvariant();

        // 2. Same verified e-mail as an existing account: link and log in.
        if (email is not null)
        {
            var existing = await db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            if (existing is not null)
            {
                if (!identity.EmailVerified)
                {
                    return Error.Conflict("email_in_use", "An account with this e-mail already exists. Log in with your password first.");
                }

                db.ExternalLogins.Add(NewLink(existing.Id, provider, identity.SubjectId, now));
                if (existing.AvatarUrl is null && identity.AvatarUrl is not null)
                {
                    existing.AvatarUrl = identity.AvatarUrl;
                }

                await db.SaveChangesAsync(cancellationToken);
                return await issuer.IssueAsync(existing, cancellationToken);
            }
        }

        // 3. Nobody yet: sign up, but only when the caller told us which profile to create.
        if (profileType is null)
        {
            return Error.NotFound("account_not_found", $"No Hobber account is linked to this {Capitalize(provider)} account yet. Sign up first.");
        }

        if (email is null)
        {
            return Error.Validation("email", $"Your {Capitalize(provider)} account did not share an e-mail address we can use.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = null,
            FirstName = Clean(identity.FirstName),
            LastName = Clean(identity.LastName),
            AvatarUrl = identity.AvatarUrl,
            ProfileType = profileType.Value,
            AcceptedTermsAt = now,
            CreatedAt = now,
        };
        db.Users.Add(user);
        db.ExternalLogins.Add(NewLink(user.Id, provider, identity.SubjectId, now));
        await db.SaveChangesAsync(cancellationToken);

        var auth = await issuer.IssueAsync(user, cancellationToken);
        return auth with { IsNewUser = true };
    }

    private static ExternalLogin NewLink(Guid userId, string provider, string subject, DateTime now) => new()
    {
        Id = Guid.NewGuid(),
        UserId = userId,
        Provider = provider,
        ProviderSubjectId = subject,
        CreatedAt = now,
    };

    private static string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

    private static string Capitalize(string s) => s.Length == 0 ? s : char.ToUpperInvariant(s[0]) + s[1..];
}

/// <summary>Lets the frontend enable the Google/Facebook buttons only when the backend can verify them.</summary>
public sealed class GetAuthProvidersHandler(ISocialIdentityVerifier verifier)
{
    public AuthProvidersDto Handle() => new(
        verifier.ConfiguredProviders.Contains(ExternalLogin.Google),
        verifier.ConfiguredProviders.Contains(ExternalLogin.Facebook));
}
