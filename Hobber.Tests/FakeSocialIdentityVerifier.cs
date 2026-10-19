using Hobber.Application.Abstractions;
using Hobber.Domain.Entities;

namespace Hobber.Tests;

/// <summary>
/// Stands in for Google/Facebook in tests. Tokens are strings of the form "provider:subject:email[:unverified]";
/// anything else is rejected like an invalid token.
/// </summary>
public sealed class FakeSocialIdentityVerifier : ISocialIdentityVerifier
{
    public IReadOnlyCollection<string> ConfiguredProviders { get; } = [ExternalLogin.Google, ExternalLogin.Facebook];

    public Task<SocialIdentity?> VerifyAsync(string provider, string token, CancellationToken cancellationToken)
    {
        var parts = token.Split(':');
        if (parts.Length < 3 || parts[0] != provider)
        {
            return Task.FromResult<SocialIdentity?>(null);
        }

        var email = parts[2] == "-" ? null : parts[2];
        var verified = parts.Length < 4 || parts[3] != "unverified";
        return Task.FromResult<SocialIdentity?>(new SocialIdentity(
            provider,
            parts[1],
            email,
            verified,
            FirstName: "Keti",
            LastName: "Datish",
            AvatarUrl: "https://example.test/avatar.png"));
    }
}
