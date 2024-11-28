//using Car_Rental_System_API.Data;
//using Car_Rental_System_API.Models;
//using Microsoft.EntityFrameworkCore;
//using Car_Rental_System_API.Data;

//namespace Car_Rental_System_API.Repositories
//{
//    public class CarRepository: ICarRepository
//    {
//        private readonly CarRentalDbContext _context;
//        public CarRepository(CarRentalDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IEnumerable<Car>> GetAllCarsAsync()
//        {
//            return await _context.Cars.ToListAsync();
//        }
//        public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
//        {
//            return await _context.Cars.Where(car => car.IsAvailable).ToListAsync();
//        }
//        public async Task<Car> GetCarByIdAsync(int id)
//        {
//            return await _context.Cars.FindAsync(id);
//            //return await _context.Cars.FromSqlInterpolated($"EXEC GetCarById @Id = {id}").FirstOrDefaultAsync();
//        }
//        public async Task AddCarAsync(Car car)
//        {
//            await _context.Cars.AddAsync(car);
//            await _context.SaveChangesAsync();
//            //await _context.Database.ExecuteSqlInterpolated($"EXEC AddCar @make = {car.Make}, @Model = {car.Model}, @Year = {car.Year}, @PricePerDay = {car.PricePerDay}, @IsAvailable = {car.IsAvailable}");
//        }
//        public async Task UpdateCarAsync(Car car)
//        {
//            _context.Cars.Update(car);
//            await _context.SaveChangesAsync();
//        }
//        public async Task DeleteCarAsync(int id)
//        {
//            var car = await _context.Cars.FindAsync(id);
//            if (car != null)
//            {
//                _context.Cars.Remove(car);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

using Car_Rental_System_API.Data;
using Car_Rental_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System_API.Repositories
{
    public class CarRepository : ICarRepository
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
            // Used stored procedure to fetch a car by ID
            var cars = await _context.Cars.FromSqlInterpolated($"EXEC GetCarById @Id = {id}").ToListAsync();
            return cars.FirstOrDefault();
        }

        public async Task AddCarAsync(Car car)
        {
            // Used stored procedure to add a new car
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddCar @Make = {car.Make}, @Model = {car.Model}, @Year = {car.Year}, @PricePerDay = {car.PricePerDay}, @IsAvailable = {car.IsAvailable}");
        }

        public async Task UpdateCarAsync(Car car)
        {
            // Used stored procedure to update a car's details
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateCar @Id = {car.Id}, @Make = {car.Make}, @Model = {car.Model}, @Year = {car.Year}, @PricePerDay = {car.PricePerDay}, @IsAvailable = {car.IsAvailable}");
        }

        public async Task DeleteCarAsync(int id)
        {
            // Used stored procedure to delete a car
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteCar @Id = {id}");
        }
    }
}

