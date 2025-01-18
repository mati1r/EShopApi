using ApiTemplate.DB;
using ApiTemplate.DTO.AuthDTO;
using ApiTemplate.Exceptions;
using ApiTemplate.IService;
using ApiTemplate.Models;
using Aplikacja_webowa_do_zarządzania_zespołami.Validation;

namespace ApiTemplate.Services;

public class AuthService : IAuthService
{
    private readonly DatabaseContext _dbContext;
    private IConfiguration _config;

    public AuthService(DatabaseContext dbContext, IConfiguration config)
    {
        _dbContext = dbContext;
        _config = config;
    }

    private bool isUserNameTaken(string name)
    {
        return _dbContext.Users.Where(user => user.Name == name).Any();
    }

    private bool isEmailAlreadyUsed(string email)
    {
       return _dbContext.Users.Where(user => user.Email == email).Any();
    }

    private User getLogingUser(string name, string password)
    {
        User? user = _dbContext.Users.FirstOrDefault(u => u.Name == name);

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

    private Tokens generateTokens(User user, IConfiguration _config)
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

    private void setOldTokensToInvalid(int userId)
    {
        List<Tokens> oldTokens = _dbContext.Tokens.Where(t => t.UserId == userId).ToList();

        foreach (Tokens token in oldTokens)
        {
            token.IsValid = false;
        }

        _dbContext.SaveChanges();
    }

    public UserDTO login(string name, string password)
    {
        User user = getLogingUser(name, password);

        Tokens tokens = generateTokens(user, _config);

        //set invalid for all tokens that were used priviously (if user didn't used logout call)
        setOldTokensToInvalid(user.Id);

        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();

        var userDto = new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        };

        return userDto;
    }

    public UserDTO register(string email, string name, string password)
    {
        if (isUserNameTaken(name))
        {
            throw new BadRequestException("Username is already taken.");
        }

        if (isEmailAlreadyUsed(email))
        {
            throw new BadRequestException("Email is already in use.");
        }


        User newUser = new User();
        newUser.Email = email;
        newUser.Name = name;

        newUser.Salt = Hash.GenerateSalt(16);
        newUser.Password = Hash.HashPassword(password, newUser.Salt);
        newUser.Roles = ["User"];

        Tokens tokens = generateTokens(newUser, _config);


        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();

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

    public void logout(int userId)
    {
        setOldTokensToInvalid(userId);
    }

    public bool isValidAccessToken(string tokenValue)
    {
        var token = _dbContext.Tokens.FirstOrDefault(t => t.AccessToken == tokenValue && t.IsValid == true);

        if (token == null || token.Expiration < DateTime.UtcNow)
        {
            return false;
        }

        return true;
    }

    public Tokens? isValidRefreshToken(string tokenValue)
    {
        var token = _dbContext.Tokens.FirstOrDefault(t => t.RefreshToken == tokenValue && t.IsValid == true);

        if (token == null || token.Expiration < DateTime.UtcNow)
        {
            return null;
        }

        return token;
    }

    public string getNewAccessToken(string refreshToken)
    {
        var refreshValid = isValidRefreshToken(refreshToken);
        if (refreshValid == null)
        {
            throw new AuthorizationErrorException("Token has expired or is invalid");
        }

        //get user of token
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == refreshValid.UserId);

        if(user == null)
        {
            throw new AuthorizationErrorException("User assigned to a token doesn't exist");
        }

        var accessToken = AuthHelper.GenerateJWTToken(user, _config);

        refreshValid.AccessToken = accessToken;
        _dbContext.SaveChanges();

        return accessToken;
    }
}
