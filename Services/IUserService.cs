using Car_Rental_System_API.Models;

namespace Car_Rental_System_API.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<string> AuthenticateUserAsync(string email, string password);
    }
}
