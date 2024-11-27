using Car_Rental_System_API.Data;
using Car_Rental_System_API.Models;
using Microsoft.EntityFrameworkCore;
using Car_Rental_System_API.Data;

namespace Car_Rental_System_API.Repositories
{
    public class CarRepository: ICarRepository
    {
        private readonly CarRentalDbContext _context;
        public CarRepository(CarRentalDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
        {
            return await _context.Cars.Where(car => car.IsAvailable).ToListAsync();
        }
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }
        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
