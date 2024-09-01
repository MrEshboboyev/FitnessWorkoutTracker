using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using FitnessWorkoutTracker.Infrastructure.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessExerciseTracker.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        // inject Exercise Service
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        #region Private Methods
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
        #endregion

        [HttpGet("get-all-exercises")]
        public async Task<IActionResult> GetAllExercisesAsync()
        {
            try
            {
                return Ok(await _exerciseService.GetAllExercisesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-user-exercises")]
        public async Task<IActionResult> GetUserExercisesAsync()
        {
            try
            {
                return Ok(await _exerciseService.GetUserExercisesAsync(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-all-exercises-by-name")]
        public async Task<IActionResult> GetAllExercisesByNameAsync(string exerciseName)
        {
            try
            {
                return Ok(await _exerciseService.GetExercisesByExerciseNameAsync(exerciseName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-user-exercises-by-name")]
        public async Task<IActionResult> GetUserExercisesByNameAsync(string exerciseName)
        {
            try
            {
                return Ok(await _exerciseService.GetUserExercisesByExerciseNameAsync(GetUserId(), exerciseName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create-exercise")]
        public async Task<IActionResult> CreateExerciseAsync([FromBody] CreateExerciseModel model)
        {
            try
            {
                ExerciseCreateDTO exerciseCreateDTO = new()
                {
                    Name = model.Name,
                    Reps = model.Reps,
                    Sets = model.Sets,
                    WorkoutId = model.WorkoutId,
                    UserId = GetUserId()
                };

                await _exerciseService.CreateExerciseAsync(exerciseCreateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update-user-exercise")]
        public async Task<IActionResult> UpdateExerciseAsync(Guid exerciseId, [FromBody] UpdateExerciseModel model)
        {
            if (exerciseId != model.Id || !ModelState.IsValid)
                return BadRequest("Error with entered values!");

            try
            {
                ExerciseUpdateDTO exerciseUpdateDTO = new()
                {
                    Id = model.Id,
                    Name = model.Name,
                    WorkoutId = model.WorkoutId,
                    Reps = model.Reps,
                    Sets = model.Sets,  
                    UserId = GetUserId()
                };

                await _exerciseService.UpdateExerciseAsync(exerciseUpdateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove-user-exercise")]
        public async Task<IActionResult> RemoveExerciseAsync([FromBody] RemoveExerciseModel model)
        {
            try
            {
                ExerciseRemoveDTO exerciseRemoveDTO = new()
                {
                    Id = model.Id,
                    WorkoutId = model.WorkoutId,
                    UserId = GetUserId()
                };

                await _exerciseService.RemoveExerciseAsync(exerciseRemoveDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
