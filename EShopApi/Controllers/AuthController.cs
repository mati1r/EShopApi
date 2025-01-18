using ApiTemplate.DTO.AuthDTO;
using ApiTemplate.Exceptions;
using ApiTemplate.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IAuthService _authService;
        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                UserDTO userDTO = _authService.register(registerDTO.email, registerDTO.username, registerDTO.password);
                return Ok(userDTO);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            UserDTO userDTO = _authService.login(loginDTO.username, loginDTO.password);

            return Ok(userDTO);
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        public IActionResult Refresh([FromBody] string refreshToken)
        {
            try
            {
                string newAccessToken = _authService.getNewAccessToken(refreshToken);
                return Ok(newAccessToken);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if(userId == null)
                {
                    throw new BadRequestException("Access token was not provided or it was invalid");
                }
                int useIdInt = Int32.Parse(userId);
                _authService.logout(useIdInt);

                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetDefaultData")]
        public string TestAuth()
        {
            return "worksNoAuth";
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAdminData")]
        public string TestAuth2()
        {
            return "works";
        }

        [Authorize(Roles = "User")]
        [HttpGet("GetUserData")]
        public string TestAuth3()
        {
            return "works";
        }
    }
}
