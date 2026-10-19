namespace TeachMe.Infrastructure.Auth;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = "Hobber";

    public string Audience { get; set; } = "Hobber";

    /// <summary>HMAC-SHA256 signing key, at least 32 bytes. Set per environment; the dev value lives in appsettings.Development.json.</summary>
    public string Key { get; set; } = string.Empty;

    public int AccessTokenMinutes { get; set; } = 60;

    public int RefreshTokenDays { get; set; } = 30;
}
