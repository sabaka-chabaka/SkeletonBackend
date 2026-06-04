using System.Security.Claims;

namespace SkeletonBackend.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userIdString))
        {
            throw new UnauthorizedAccessException("User ID not found in claims.");
        }

        if (!Guid.TryParse(userIdString, out var userId))
        {
            throw new UnauthorizedAccessException("User ID is not a valid GUID.");
        }

        return userId;
    }
}
