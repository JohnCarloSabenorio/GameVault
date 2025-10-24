using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using server.Interfaces;
using server.Models;

namespace server.Services;

public class TokenService : ITokenService
{

    public readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"] ?? string.Empty));
    }
    public string CreateToken(User user)
    {

        var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
        new Claim(JwtRegisteredClaimNames.GivenName, user.UserName ?? string.Empty) };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor { Subject = new ClaimsIdentity(claims), Expires = DateTime.Now.AddDays(7), SigningCredentials = creds, Issuer = _config["JWT:Issuer"], Audience = _config["JWT:Audience"] };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}