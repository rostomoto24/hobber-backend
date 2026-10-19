using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Application.Common;
using TeachMe.Application.Contracts;

namespace TeachMe.Application.Notifications;

/// <summary>Badge on the Home bell.</summary>
public sealed class GetUnreadCountHandler(IAppDbContext db, ICurrentUser current)
{
    public async Task<Result<UnreadCountDto>> HandleAsync(CancellationToken cancellationToken)
    {
        if (current.UserId is not { } userId)
        {
            return Error.Unauthorized("not_authenticated", "Log in to continue.");
        }

        var count = await db.Notifications.CountAsync(n => n.UserId == userId && n.ReadAt == null, cancellationToken);
        return new UnreadCountDto(count);
    }
}
