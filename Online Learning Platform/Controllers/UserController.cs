using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security;
using System.Security.Claims;
using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Online_Learning_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(JWT jwt, ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPost]
        private string AuthenticateUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JWT.SigningKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = JWT.Issuer,
                Audience = JWT.Audience,
                Expires = DateTime.UtcNow.AddHours(2), // Token expires in 2 hours
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        })
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserRegisterDTO newUser)
        {
            if(await _context.Users.AnyAsync(u => u.Email == newUser.Email))
            {
                return BadRequest("User with this email already exists.");
            }
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                UserName = newUser.UserName,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,
                DateOfBirth = newUser.DateOfBirth,

            };
            var passordHasher = new PasswordHasher<User>();
            user.PasswordHash = passordHasher.HashPassword(user , newUser.Password);

           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();

            
            return Ok(new {Message = "User registered successfully!", User = user });
        }
        [HttpPost("Login")]
         public async Task<IActionResult> LoginAsync([FromBody]UserLogin userLogin)
         {
            if (userLogin == null)
            {
                return BadRequest("Enter valid credentials.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLogin.Email);

            if(user == null)
            {
                return BadRequest("User not found. Try again or register.");
            }

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user,user.PasswordHash, userLogin.Password);

            if (result != PasswordVerificationResult.Success)
            {
                return BadRequest("Invalid password. Try again.");
            }
            var token = AuthenticateUser(user);

            return Ok(new {Token = token, Message = "Login successful!" });
         }


    }

}
