using Application.DTO.AuthDTO;
using Core.DTO.AuthDTO;
using Core.Exceptions;
using Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Application.Controllers
{
    [Route("Api/[controller]")]
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
        public async Task<UserDTO> Register([FromBody] RegisterDTO registerDTO)
        {
            UserDTO userDTO = await _authService.Register(registerDTO.email, registerDTO.username, registerDTO.password);
            return userDTO;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<UserDTO> Login([FromBody] LoginDTO loginDTO)
        {
            UserDTO userDTO = await _authService.Login(loginDTO.username, loginDTO.password);

            return userDTO;
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        public async Task<string> Refresh([FromBody] string refreshToken)
        {
            string newAccessToken = await _authService.GetNewAccessTokenAsync(refreshToken);
            return newAccessToken;
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null)
            {
                throw new BadRequestException("Access token was not provided or it was invalid");
            }
            int useIdInt = Int32.Parse(userId);
            await _authService.Logout(useIdInt);
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
