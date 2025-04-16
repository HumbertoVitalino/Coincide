using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers.v1;

public abstract class BaseController : ControllerBase
{
    protected Guid UserId
    {
        get
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                throw new UnauthorizedAccessException("User ID not found in token.");

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
                throw new UnauthorizedAccessException("Invalid User ID format.");

            return userId;
        }
    }
}
