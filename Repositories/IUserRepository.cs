using Car_Rental_System_API.Models;

namespace Car_Rental_System_API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
