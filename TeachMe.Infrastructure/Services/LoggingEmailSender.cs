using Microsoft.Extensions.Logging;
using TeachMe.Application.Abstractions;

namespace TeachMe.Infrastructure.Services;

/// <summary>
/// Development stand-in for a real mail provider: writes the reset token to the log.
/// Replace with an SMTP/SendGrid implementation before release (Phase 5).
/// </summary>
public sealed class LoggingEmailSender(ILogger<LoggingEmailSender> logger) : IEmailSender
{
    public Task SendPasswordResetAsync(string email, string token, CancellationToken cancellationToken)
    {
        logger.LogInformation("Password reset requested for {Email}. Token: {Token}", email, token);
        return Task.CompletedTask;
    }
}

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
