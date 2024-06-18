using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using FeedbackSystem.API.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FeedbackSystem.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{v:apiVersion}/authentication")]
public class AuthenticationController : Controller
{
    private readonly AuthenticationOptions _authOptions;

    public AuthenticationController(AuthenticationOptions authOptions)
    {
        _authOptions = authOptions;
    }

    [HttpPost("token")]
    public IActionResult GenerateToken()
    {
        var claims = new[]
{
            new Claim(JwtRegisteredClaimNames.Sub, _authOptions.UserId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecurityKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _authOptions.Issuer,
            audience: _authOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_authOptions.ExpiryTimeInMinutes),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
