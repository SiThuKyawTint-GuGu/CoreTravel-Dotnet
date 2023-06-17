using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CoreTravel.Data;
using CoreTravel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreTravel
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public UserController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(User request)
        {
            string password = request.Password;
            string hashedPassword = HashPassword(password);

            User user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            // Generate token
            var token = GenerateToken(user);

            // Save token to the database
            Token tokenEntity = new Token
            {
                UserId = user.Id,
                Value = token
            };
            _dbContext.Tokens.Add(tokenEntity);
            _dbContext.SaveChanges();

            return new JsonResult(new { user, token });
        }

        [HttpGet("getUser")]
        public IActionResult GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _dbContext.Users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }

            return new JsonResult(user);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] passwordByte = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordByte);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private string GenerateToken(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GenerateRandomKey(32); // Generate a 256-bit (32-byte) random key
            string userId = user.Id.ToString();
            string userEmail = user.Email ?? string.Empty;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userEmail),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set the token's expiration time to 1 hour from now
                IssuedAt = DateTime.UtcNow, // Set the token's issued time
                NotBefore = DateTime.UtcNow, // Set the token's not-before time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private byte[] GenerateRandomKey(int size)
        {
            using var provider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var key = new byte[size];
            provider.GetBytes(key);
            return key;
        }
    }
}

