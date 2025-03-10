using ChedidAPIBusiness.UserBusiness;
using ChedidAPIData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChedidPolicyAPI.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _userBusiness;

        public LoginController(IConfiguration configuration, IUserBusiness userBusiness)
        {
            _configuration = configuration;
            _userBusiness = userBusiness;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _userBusiness.AuthenticateUserAsync(loginModel.Username, loginModel.Password);

            if (user != null)
            {
                // Generate JWT token if authentication is successful
                var tokenString = GenerateJWTToken(user);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized("Invalid username or password");
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
