using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NumberFromFileAPI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IConfiguration _configuration;
        public SecurityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            // Validate user (This is a simple example, you'd usually validate from a DB)
            if (login.Username == "test" && login.Password == "password") // Replace with actual validation
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "User")
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
