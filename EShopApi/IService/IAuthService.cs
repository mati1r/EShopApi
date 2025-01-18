using ApiTemplate.DTO.AuthDTO;
using ApiTemplate.Models;

namespace ApiTemplate.IService;

public interface IAuthService
{
    UserDTO register(string email, string name, string password);

    UserDTO login(string name, string password);

    void logout(int userId);

    bool isValidAccessToken(string token);

    Tokens? isValidRefreshToken(string token);

    string getNewAccessToken(string refreshToken);
}
