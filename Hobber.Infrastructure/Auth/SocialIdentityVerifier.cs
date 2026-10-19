using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.Apis.Auth;
using Hobber.Application.Abstractions;
using Hobber.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hobber.Infrastructure.Auth;

/// <summary>Routes to the Google or Facebook verifier and reports which ones have credentials.</summary>
public sealed class SocialIdentityVerifier(
    IOptions<SocialAuthOptions> options,
    GoogleIdentityVerifier google,
    FacebookIdentityVerifier facebook) : ISocialIdentityVerifier
{
    public IReadOnlyCollection<string> ConfiguredProviders { get; } =
    [
        .. options.Value.Google.IsConfigured ? new[] { ExternalLogin.Google } : [],
        .. options.Value.Facebook.IsConfigured ? new[] { ExternalLogin.Facebook } : [],
    ];

    public Task<SocialIdentity?> VerifyAsync(string provider, string token, CancellationToken cancellationToken) =>
        provider switch
        {
            ExternalLogin.Google => google.VerifyAsync(token, cancellationToken),
            ExternalLogin.Facebook => facebook.VerifyAsync(token, cancellationToken),
            _ => Task.FromResult<SocialIdentity?>(null),
        };
}

/// <summary>Validates a Google ID token (signature, expiry, issuer, audience) with Google's public keys.</summary>
public sealed class GoogleIdentityVerifier(IOptions<SocialAuthOptions> options, ILogger<GoogleIdentityVerifier> logger)
{
    public async Task<SocialIdentity?> VerifyAsync(string idToken, CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = options.Value.Google.ClientIds.Where(id => !string.IsNullOrWhiteSpace(id)).ToArray(),
        };

        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            return new SocialIdentity(
                ExternalLogin.Google,
                payload.Subject,
                payload.Email,
                payload.EmailVerified,
                payload.GivenName,
                payload.FamilyName,
                payload.Picture);
        }
        catch (InvalidJwtException ex)
        {
            logger.LogInformation("Rejected Google ID token: {Reason}", ex.Message);
            return null;
        }
    }
}

/// <summary>
/// Validates a Facebook user access token: /debug_token must say it is valid and issued for our app,
/// then /me supplies the profile. Facebook only returns e-mails it has verified.
/// </summary>
public sealed class FacebookIdentityVerifier(HttpClient http, IOptions<SocialAuthOptions> options, ILogger<FacebookIdentityVerifier> logger)
{
    private const string GraphBase = "https://graph.facebook.com/v19.0";

    public async Task<SocialIdentity?> VerifyAsync(string accessToken, CancellationToken cancellationToken)
    {
        var fb = options.Value.Facebook;
        try
        {
            var appToken = Uri.EscapeDataString($"{fb.AppId}|{fb.AppSecret}");
            var debug = await http.GetFromJsonAsync<DebugTokenResponse>(
                $"{GraphBase}/debug_token?input_token={Uri.EscapeDataString(accessToken)}&access_token={appToken}",
                cancellationToken);

            if (debug?.Data is not { IsValid: true } data || data.AppId != fb.AppId || string.IsNullOrEmpty(data.UserId))
            {
                logger.LogInformation("Rejected Facebook token: valid={Valid} app={App}", debug?.Data?.IsValid, debug?.Data?.AppId);
                return null;
            }

            var me = await http.GetFromJsonAsync<MeResponse>(
                $"{GraphBase}/me?fields=id,first_name,last_name,email,picture.type(large)&access_token={Uri.EscapeDataString(accessToken)}",
                cancellationToken);

            if (me is null || me.Id != data.UserId)
            {
                return null;
            }

            return new SocialIdentity(
                ExternalLogin.Facebook,
                me.Id,
                me.Email,
                EmailVerified: me.Email is not null,
                me.FirstName,
                me.LastName,
                me.Picture?.Data?.Url);
        }
        catch (Exception ex) when (ex is HttpRequestException or JsonException or TaskCanceledException)
        {
            logger.LogWarning(ex, "Facebook token verification failed");
            return null;
        }
    }

    private sealed record DebugTokenResponse([property: JsonPropertyName("data")] DebugTokenData? Data);

    private sealed record DebugTokenData(
        [property: JsonPropertyName("app_id")] string? AppId,
        [property: JsonPropertyName("is_valid")] bool IsValid,
        [property: JsonPropertyName("user_id")] string? UserId);

    private sealed record MeResponse(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("first_name")] string? FirstName,
        [property: JsonPropertyName("last_name")] string? LastName,
        [property: JsonPropertyName("email")] string? Email,
        [property: JsonPropertyName("picture")] PictureResponse? Picture);

    private sealed record PictureResponse([property: JsonPropertyName("data")] PictureData? Data);

    private sealed record PictureData([property: JsonPropertyName("url")] string? Url);
}
