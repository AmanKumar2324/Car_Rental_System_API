using Car_Rental_System_API.Models;
using Car_Rental_System_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/Car/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
        {
            var cars = await _carRepository.GetAvailableCarsAsync();
            return Ok(cars);
        }

        // POST: api/Car/rent/{carId}/user/{userId}
        [HttpPost("rent/{carId}/user/{userId}")]
        public async Task<ActionResult<Car>> RentCar(int carId, int userId)
        {
            try
            {
                var car = await _carRepository.GetCarByIdAsync(carId);
                if (car == null || !car.IsAvailable)
                    return BadRequest(new { message = "Car is not available." });

                car.IsAvailable = false;
                await _carRepository.UpdateCarAsync(car);

                return Ok(car);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Car/return/{carId}
        [HttpPost("return/{carId}")]
        public async Task<IActionResult> ReturnCar(int carId)
        {
            try
            {
                var car = await _carRepository.GetCarByIdAsync(carId);
                if (car == null)
                    return NotFound();

                car.IsAvailable = true;
                await _carRepository.UpdateCarAsync(car);

                return Ok(new { message = "Car returned successfully." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Car/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        // POST: api/Car
        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            try
            {
                await _carRepository.AddCarAsync(car);
                return Ok(new { message = "Car added successfully." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Car
        [HttpPut]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            try
            {
                await _carRepository.UpdateCarAsync(car);
                return Ok(new { message = "Car updated successfully." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Car/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carRepository.DeleteCarAsync(id);
                return Ok(new { message = "Car deleted successfully." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
