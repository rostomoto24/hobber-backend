using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachMe.Application.Abstractions;
using TeachMe.Infrastructure.Auth;
using TeachMe.Infrastructure.Services;

namespace TeachMe.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<IPasswordHasher, IdentityPasswordHasher>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddSingleton<IEmailSender, LoggingEmailSender>();

        return services;
    }
}
