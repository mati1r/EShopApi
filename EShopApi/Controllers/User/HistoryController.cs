using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.User;

public class HistoryController : UserController
{
    [HttpGet("GetList")]
    public IActionResult GetMyInfo()
    {
        if (CurrentUserId is null)
            return Unauthorized();

        return Ok(new { userId = CurrentUserId });
    }
}
