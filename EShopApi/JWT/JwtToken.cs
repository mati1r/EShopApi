using Core.IService;
using Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.JWT;

public static class JwtToken
{
    public static void AddCustomJwtBearer(this IServiceCollection services, IConfiguration config)
    {
        string? JWTsecret = config["Jwt:Secret"];

        if (string.IsNullOrWhiteSpace(JWTsecret))
        {
            throw new Exception("JWT Secret is not configured in appsettings.json.");
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(token =>
        {
            token.RequireHttpsMetadata = false;
            token.SaveToken = false;
            token.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JWTsecret)
                ),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero,
            };
            token.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();

                    var token = context.SecurityToken;

                    if (token == null) { 
                        context.Fail("Token is not valid.");
                    }

                    var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
                    string tokenValue = authorizationHeader.StartsWith("Bearer ")
                        ? authorizationHeader.Substring("Bearer ".Length).Trim() : authorizationHeader;

                    if (! await tokenValidatorService.isValidAccessToken(tokenValue))
                    {
                        context.Fail("Token is not valid.");
                    }
                }
            };
        });
    }
}
