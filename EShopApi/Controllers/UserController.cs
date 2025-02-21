using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("Api/User/[controller]")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class UserController : ControllerBase
    {
    }
}
