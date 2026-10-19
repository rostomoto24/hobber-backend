namespace Hobber.Infrastructure.Auth;

/// <summary>
/// Bound from the "Authentication" configuration section. Values are secrets: keep them out of
/// appsettings.json and set them with `dotnet user-secrets` (development) or environment variables
/// (`Authentication__Google__ClientIds__0`, `Authentication__Facebook__AppSecret`, ...).
/// </summary>
public sealed class SocialAuthOptions
{
    public const string SectionName = "Authentication";

    public GoogleOptions Google { get; set; } = new();

    public FacebookOptions Facebook { get; set; } = new();

    public sealed class GoogleOptions
    {
        /// <summary>
        /// OAuth client ids whose ID tokens we accept: the Web client id, plus the iOS and Android client ids
        /// when the native apps sign in with their own. Empty = Google sign-in disabled.
        /// </summary>
        public string[] ClientIds { get; set; } = [];

        public bool IsConfigured => ClientIds.Any(id => !string.IsNullOrWhiteSpace(id));
    }

    public sealed class FacebookOptions
    {
        public string AppId { get; set; } = string.Empty;

        public string AppSecret { get; set; } = string.Empty;

        public bool IsConfigured => !string.IsNullOrWhiteSpace(AppId) && !string.IsNullOrWhiteSpace(AppSecret);
    }
}
