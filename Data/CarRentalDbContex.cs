using Car_Rental_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System_API.Data
{
    public class CarRentalDbContex : DbContext
    {
        public CarRentalDbContex(DbContextOptions<CarRentalDbContex> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
