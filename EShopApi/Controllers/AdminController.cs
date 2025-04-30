using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("Api/Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class AdminController : ControllerBase
    {
    }
}
