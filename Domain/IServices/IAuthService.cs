using Core.DTO.AuthDTO;
using Core.Models;

namespace Core.IServices;

public interface IAuthService
{
    public Task<UserDTO> Register(string email, string name, string password);

    public Task<UserDTO> Login(string name, string password);

    public Task Logout(int userId);

    public Task<bool> IsValidAccessToken(string token);

    public Task<Tokens?> IsValidRefreshToken(string token);

    public Task<string> GetNewAccessTokenAsync(string refreshToken);
}
