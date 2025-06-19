using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[Route("Api/User/[controller]")]
[AllowAnonymous]
[ApiController]
[ApiExplorerSettings(GroupName = "user")]
public class AnonymusController : ControllerBase
{
}
