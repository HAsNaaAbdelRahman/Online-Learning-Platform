using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security;
using System.Security.Claims;

namespace Online_Learning_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(JWT jwt) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(AuthenticationRequest request)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = JWT.Issuer,
                Audience = JWT.Audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.SigningKey))
                , SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, request.UserName),
                    new(ClaimTypes.Email, "email.gmail.com")


                })
            };
            var SecurityToken = TokenHandler.CreateToken(TokenDescriptor);
            var accessToken = TokenHandler.WriteToken(SecurityToken);
            return Ok(accessToken);
        }
    }
}
