using System.Security.Claims;
using Hobber.Application.Abstractions;

namespace Hobber.API.Infrastructure;

/// <summary>Reads the user id from the bearer token's <c>sub</c> claim.</summary>
public sealed class CurrentUser(IHttpContextAccessor accessor) : ICurrentUser
{
    public Guid? UserId
    {
        get
        {
            var principal = accessor.HttpContext?.User;
            var sub = principal?.FindFirstValue(ClaimTypes.NameIdentifier) ?? principal?.FindFirstValue("sub");
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
