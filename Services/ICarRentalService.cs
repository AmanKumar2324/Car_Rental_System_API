using Car_Rental_System_API.Models;

namespace Car_Rental_System_API.Services
{
    public interface ICarRentalService
    {
        Task<IEnumerable<Car>> GetAvailableCarsAsync();
        Task<Car> RentCarAsync(int carId, int userId);
        Task ReturnCarAsync(int carId);
    }
}
