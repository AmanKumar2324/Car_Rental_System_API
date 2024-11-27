using Car_Rental_System_API.Models;
using Car_Rental_System_API.Repositories;
using System;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            if (await _userRepository.GetUserByEmailAsync(user.Email) != null)
                throw new Exception("Email is already in use.");

            // Hash the password (this is a placeholder, use a library like BCrypt)
            user.PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(user.PasswordHash));
            await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task<string> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || user.PasswordHash != Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)))
                throw new Exception("Invalid email or password.");

            // Generate a JWT token (use a library like System.IdentityModel.Tokens.Jwt)
            return "fake-jwt-token"; // Replace with actual JWT generation logic
        }
    }
}
