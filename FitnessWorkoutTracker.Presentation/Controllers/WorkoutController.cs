using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessWorkoutTracker.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        // inject Workout Service
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        #region Private Methods
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
        #endregion

        [HttpGet("get-all-workouts")]
        public async Task<IActionResult> GetAllWorkoutsAsync()
        {
            try
            {
                return Ok(await _workoutService.GetAllWorkoutsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-user-workouts")]
        public async Task<IActionResult> GetUserWorkoutsAsync()
        {
            try
            {
                return Ok(await _workoutService.GetUserWorkoutsAsync(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-all-workouts-by-name")]
        public async Task<IActionResult> GetAllWorkoutsByNameAsync(string workoutName)
        {
            try
            {
                return Ok(await _workoutService.GetWorkoutsByWorkoutNameAsync(workoutName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-user-workouts-by-name")]
        public async Task<IActionResult> GetUserWorkoutsByNameAsync(string workoutName)
        {
            try
            {
                return Ok(await _workoutService.GetUserWorkoutsByWorkoutNameAsync(GetUserId(), workoutName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-active-workouts")]
        public async Task<IActionResult> GetUserActiveWorkoutsAsync()
        {
            try
            {
                return Ok(await _workoutService.GetUserActiveWorkoutsAsync(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("get-user-past-workouts")]
        public async Task<IActionResult> GetUserPastWorkoutsAsync([FromBody] QueryWorkoutModel model)
        {
            try
            {
                WorkoutQueryDTO workoutQueryDTO = new()
                { 
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    UserId = GetUserId()
                };


                return Ok(await _workoutService.GetPastWorkoutsAsync(workoutQueryDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-finished-workouts-percentage")]
        public async Task<IActionResult> GetUserFinishedWorkoutsPercentageAsync([FromBody] QueryWorkoutModel model)
        {
            try
            {
                WorkoutQueryDTO workoutQueryDTO = new()
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    UserId = GetUserId()
                };

                return Ok(await _workoutService.GetFinishedWorkoutsPercentageAsync(workoutQueryDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create-workout")]
        public async Task<IActionResult> CreateWorkoutAsync([FromBody] CreateWorkoutModel model)
        {
            try
            {
                WorkoutCreateDTO workoutCreateDTO = new()
                {
                    Date = model.Date,
                    Name = model.Name,
                    UserId = GetUserId()
                };

                await _workoutService.CreateUserWorkoutAsync(workoutCreateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-user-workout")]
        public async Task<IActionResult> UpdateWorkoutAsync(Guid workoutId, [FromBody] UpdateWorkoutModel model)
        {
            if (workoutId != model.Id || !ModelState.IsValid)
                return BadRequest("Error with entered values!");

            try
            {
                WorkoutUpdateDTO workoutUpdateDTO = new()
                {
                    Id = model.Id,
                    Date = DateTime.UtcNow,
                    Name = model.Name,
                    UserId = GetUserId()
                };

                await _workoutService.UpdateUserWorkoutAsync(workoutUpdateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("remove-user-workout")]
        public async Task<IActionResult> RemoveUserWorkoutAsync([FromBody] RemoveWorkoutModel model)
        {
            try
            {
                WorkoutRemoveDTO workoutRemoveDTO = new()
                {
                    Id = model.Id,
                    UserId = GetUserId()
                };

                await _workoutService.RemoveUserWorkoutAsync(workoutRemoveDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
