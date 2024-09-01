using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // inject IAuthService
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            try
            {
                return Ok(await _authService.LoginAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _authService.RegisterAsync(model);
                return Ok("Registration successful!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
