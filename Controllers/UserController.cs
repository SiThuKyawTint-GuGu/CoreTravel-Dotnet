
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using CoreTravel.Data;
using CoreTravel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MySqlConnector;
using System.Security.Cryptography;

namespace CoreTravel.Controllers
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
            try
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
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException mySqlEx && mySqlEx.Number == 1062)
                {
                    var data = new
                    {
                        message = "Email Already Exist"
                    };
                   
                    // Duplicate entry exception
                    return new JsonResult(data)
                    {
                        StatusCode = 500 // Internal Server Error
                    };
                }

                // Handle other DbUpdateException scenarios or rethrow the exception.
                throw;
            }
        }


        [HttpPost("login")]
        public IActionResult login(User request)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.Email == request.Email);
            if (user != null)
            {
                bool isPasswordCorrect = VerifyPassword(request.Password, user.Password);
                if (isPasswordCorrect)
                {
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
                else
                {
                    return new JsonResult("Wrong Password");
                }
            }
            else
            {
                var data = new 
                {
                    message = "User not Found"
                };

                return new JsonResult(data){
                    StatusCode = 500 // Internal Server Error
                };
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout(Token request)
        {
            Token token = _dbContext.Tokens.FirstOrDefault(t => t.Value == request.Value);
            if (token != null)
            {
                _dbContext.Tokens.Remove(token);
                _dbContext.SaveChanges();
            }

            return new JsonResult("Logged out successfully");
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

        private bool VerifyPassword(string password, string hashpassword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordByte = Encoding.UTF8.GetBytes(password);
                byte[] hasbytes = sha256.ComputeHash(passwordByte);
                string converthash = Convert.ToBase64String(hasbytes);
                return hashpassword == converthash;
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
