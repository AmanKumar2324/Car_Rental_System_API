using Car_Rental_System_API.Models;
using Car_Rental_System_API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Services
{
    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public CarRentalService(ICarRepository carRepository, IUserRepository userRepository, INotificationService notificationService)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
        {
            return await _carRepository.GetAvailableCarsAsync();
        }

        public async Task<Car> RentCarAsync(int carId, int userId)
        {
            var car = await _carRepository.GetCarByIdAsync(carId);
            if (car == null || !car.IsAvailable)
                throw new Exception("Car is not available.");

            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            car.IsAvailable = false;
            await _carRepository.UpdateCarAsync(car);

            // Send rental confirmation email
            //TODO: To implement this
            await _notificationService.SendRentalConfirmationAsync(user.Email, $"{car.Make} {car.Model}");

            return car;
        }

        public async Task ReturnCarAsync(int carId)
        {
            var car = await _carRepository.GetCarByIdAsync(carId);
            if (car == null)
                throw new Exception("Car not found.");

            car.IsAvailable = true;
            await _carRepository.UpdateCarAsync(car);
        }
    }
}
