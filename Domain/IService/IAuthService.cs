using Core.DTO.AuthDTO;
using Core.Models;

namespace Core.IService;

public interface IAuthService
{
    public Task<UserDTO> register(string email, string name, string password);

    public Task<UserDTO> login(string name, string password);

    public Task logout(int userId);

    public Task<bool> isValidAccessToken(string token);

    public Task<Tokens?> isValidRefreshToken(string token);

    public Task<string> getNewAccessTokenAsync(string refreshToken);
}
