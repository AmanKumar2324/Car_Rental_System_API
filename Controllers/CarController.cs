using Car_Rental_System_API.Models;
using Car_Rental_System_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRentalService _carRentalService;

        public CarController(ICarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        // GET: api/Car/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
        {
            var cars = await _carRentalService.GetAvailableCarsAsync();
            return Ok(cars);
        }

        // POST: api/Car/rent/{carId}/user/{userId}
        [HttpPost("rent/{carId}/user/{userId}")]
        public async Task<ActionResult<Car>> RentCar(int carId, int userId)
        {
            try
            {
                var rentedCar = await _carRentalService.RentCarAsync(carId, userId);
                return Ok(rentedCar);
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
                await _carRentalService.ReturnCarAsync(carId);
                return Ok(new { message = "Car returned successfully." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
