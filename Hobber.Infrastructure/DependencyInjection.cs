using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hobber.Application.Abstractions;
using Hobber.Infrastructure.Auth;
using Hobber.Infrastructure.Services;

namespace Hobber.Infrastructure;

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
