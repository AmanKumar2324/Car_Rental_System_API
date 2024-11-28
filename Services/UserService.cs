using Car_Rental_System_API.Models;
using Car_Rental_System_API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }
        public async Task<User> RegisterUserAsync(User user)
        {
            try
            {
                if (await _userRepository.GetUserByEmailAsync(user.Email) != null)
                    throw new Exception("Email is already in use.");

                // Hash the password (replace with a secure hashing mechanism)
                user.PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(user.PasswordHash));

                await _userRepository.AddUserAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                // Log the detailed error
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                throw;
            }
        }


        //public async Task<string> AuthenticateUserAsync(string email, string password)
        //{
        //    var user = await _userRepository.GetUserByEmailAsync(email);
        //    if (user == null || user.PasswordHash != Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)))
        //        throw new Exception("Invalid email or password.");

        //    // Generatint a JWT token (use a library like System.IdentityModel.Tokens.Jwt)
        //    return "temp-jwt-token"; // Replace with actual JWT generation logic
        //}
        public async Task<string> AuthenticateUserAsync(string email, string password)
        {
            // Validate user credentials
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || user.PasswordHash != Convert.ToBase64String(Encoding.UTF8.GetBytes(password)))
                throw new Exception("Invalid email or password.");

            // Validate user properties
            if (string.IsNullOrEmpty(user.Id.ToString()) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Role))
                throw new Exception("Invalid user data for token generation.");

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
