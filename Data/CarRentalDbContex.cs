using Car_Rental_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System_API.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
