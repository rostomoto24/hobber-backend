using Hobber.Application.Abstractions;
using Hobber.Infrastructure.Auth;
using Hobber.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hobber.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.Configure<SocialAuthOptions>(configuration.GetSection(SocialAuthOptions.SectionName));

        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<IPasswordHasher, IdentityPasswordHasher>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddSingleton<IEmailSender, LoggingEmailSender>();

        services.AddSingleton<GoogleIdentityVerifier>();
        services.AddHttpClient<FacebookIdentityVerifier>(client => client.Timeout = TimeSpan.FromSeconds(10));
        services.AddScoped<ISocialIdentityVerifier, SocialIdentityVerifier>();

        return services;
    }
}
