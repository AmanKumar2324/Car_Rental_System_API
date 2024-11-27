using Car_Rental_System_API.Models;
using Car_Rental_System_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Car_Rental_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            try
            {
                var registeredUser = await _userService.RegisterUserAsync(user);
                return Ok(registeredUser);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            try
            {
                var token = await _userService.AuthenticateUserAsync(email, password);
                return Ok(new { token });
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
