using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("Api/User/[controller]")]
    [Authorize(Roles = "User")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "user")]
    public class UserController : ControllerBase
    {
        protected int? CurrentUserId
        {
            get
            {
                var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdStr, out var id))
                    return id;
                return null;
            }
        }
    }
}
