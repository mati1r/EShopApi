
using Core.DTO.AuthDTO;
using Core.Exceptions;
using Core.IServices;
using Core.Models;
using Core.Specifications.Core;
using Core.Validation;
using Microsoft.Extensions.Configuration;

namespace Core.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Tokens> _tokensRepository;

    public AuthService(
        IConfiguration config,
        IRepository<User> userRepository, 
        IRepository<Tokens> tokensRepository
    )
    {

        _config = config;
        _userRepository = userRepository;
        _tokensRepository = tokensRepository;
    }

    private async Task<bool> IsUserNameTaken(string name)
    {
        var userSpec = new UniversalSpecification<User>(filter: u => u.Name == name).AddAsNoTracking();
        var userList = await _userRepository.ListAsync(userSpec);
        return userList.Any();
    }

    private async Task<bool> IsEmailAlreadyUsed(string email)
    {
        var userSpec = new UniversalSpecification<User>(filter: u => u.Email == email).AddAsNoTracking();
        var userList = await _userRepository.ListAsync(userSpec);
        return userList.Any();
    }

    private async Task<User> GetLogingUser(string name, string password)
    {
        var userSpec = new UniversalSpecification<User>(filter: u => u.Name == name).AddAsNoTracking();
        User? user = await _userRepository.FirstOrDefaultAsync(userSpec);

        if (user == null)
        {
            throw new AuthorizationErrorException("Invalid credentials.");
        }

        if(user.Password == null || user.Salt == null || !Hash.VerifyPassword(password, user.Password, user.Salt))
        {
            throw new AuthorizationErrorException("Invalid credentials.");
        }

        return user;
    }

    private Tokens GenerateTokens(User user, IConfiguration _config)
    {
        var accessToken = AuthHelper.GenerateJWTToken(user, _config);
        var refreshToken = AuthHelper.GenerateRefreshToken(user.Id);

        var tokens = new Tokens
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Expiration = DateTime.UtcNow.AddDays(7),
            UserId = user.Id
        };

        user.Tokens.Add(tokens);

        return tokens;
    }

    private async Task SetOldTokensToInvalid(int userId)
    {
        var tokenSpec = new UniversalSpecification<Tokens>(filter: t => t.UserId == userId);
        List<Tokens> oldTokens = await _tokensRepository.ListAsync(tokenSpec);

        foreach (Tokens token in oldTokens)
        {
            token.IsValid = false;
        }

        await _tokensRepository.SaveChangesAsync();
    }

    public async Task<UserDTO> Login(string name, string password)
    {
        User user = await GetLogingUser(name, password);

        Tokens tokens = GenerateTokens(user, _config);

        //set invalid for all tokens that were used priviously (if user didn't used logout call)
        await SetOldTokensToInvalid(user.Id);

        await _userRepository.UpdateAsync(user);

        var userDto = new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };

        return userDto;
    }

    public async Task<UserDTO> Register(string email, string name, string password)
    {
        if (await IsUserNameTaken(name))
        {
            throw new BadRequestException("Username is already taken.");
        }

        if (await IsEmailAlreadyUsed(email))
        {
            throw new BadRequestException("Email is already in use.");
        }


        User newUser = new User();
        newUser.Email = email;
        newUser.Name = name;

        newUser.Salt = Hash.GenerateSalt(16);
        newUser.Password = Hash.HashPassword(password, newUser.Salt);
        newUser.Roles = ["User"];

        Tokens tokens = GenerateTokens(newUser, _config);


        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

        var userDto = new UserDTO
        {
            Id = newUser.Id,
            Name = newUser.Name,
            Email = newUser.Email,
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };

        return userDto;
    }

    public async Task Logout(int userId)
    {
        await SetOldTokensToInvalid(userId);
    }

    public async Task<bool> IsValidAccessToken(string tokenValue)
    {
        var tokenSpec = new UniversalSpecification<Tokens>(filter: t => t.AccessToken == tokenValue && t.IsValid == true);
        var token = await _tokensRepository.FirstOrDefaultAsync(tokenSpec);

        if (token == null || token.Expiration < DateTime.UtcNow)
        {
            return false;
        }

        return true;
    }

    public async Task<Tokens?> IsValidRefreshToken(string tokenValue)
    {
        var tokenSpec = new UniversalSpecification<Tokens>(filter: t => t.RefreshToken == tokenValue && t.IsValid == true);
        var token = await _tokensRepository.FirstOrDefaultAsync(tokenSpec);

        if (token == null || token.Expiration < DateTime.UtcNow)
        {
            return null;
        }

        return token;
    }

    public async Task<string> GetNewAccessTokenAsync(string refreshToken)
    {
        var refreshValid = await IsValidRefreshToken(refreshToken);
        if (refreshValid == null)
        {
            throw new AuthorizationErrorException("Token has expired or is invalid");
        }

        //get user of token
        var userSpec = new UniversalSpecification<User>(filter: u => u.Id == refreshValid.UserId);
        var user = await _userRepository.FirstOrDefaultAsync(userSpec);

        if(user == null)
        {
            throw new AuthorizationErrorException("User assigned to a token doesn't exist");
        }

        var accessToken = AuthHelper.GenerateJWTToken(user, _config);

        refreshValid.AccessToken = accessToken;
        await _tokensRepository.SaveChangesAsync();

        return accessToken;
    }
}
