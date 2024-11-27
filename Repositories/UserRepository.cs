using System.Runtime.CompilerServices;
using Car_Rental_System_API.Data;
using Car_Rental_System_API.Models;
using Microsoft.EntityFrameworkCore;
namespace Car_Rental_System_API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly CarRentalDbContext _context;
        public UserRepository(CarRentalDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
