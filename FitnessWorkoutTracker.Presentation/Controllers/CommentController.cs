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
    public class CommentController : ControllerBase
    {
        // inject Comment Service
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        #region Private Methods
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
        #endregion

        [HttpGet("get-user-comments")]
        public async Task<IActionResult> GetAllCommentsAsync()
        {
            try
            {
                return Ok(await _commentService.GetUserCommentsAsync(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-workout-comments")]
        public async Task<IActionResult> GetWorkoutCommentsAsync(Guid workoutId)
        {
            try
            {
                return Ok(await _commentService.GetWorkoutCommentsAsync(workoutId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create-comment")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentModel model)
        {
            try
            {
                CommentCreateDTO commentCreateDTO = new()
                {
                    WorkoutId = model.WorkoutId,
                    Text = model.Text,
                    UserId = GetUserId()
                };

                await _commentService.CreateCommentAsync(commentCreateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update-user-comment")]
        public async Task<IActionResult> UpdateCommentAsync(Guid commentId, [FromBody] UpdateCommentModel model)
        {
            if (commentId != model.Id || !ModelState.IsValid)
                return BadRequest("Error with entered values!");

            try
            {
                CommentUpdateDTO commentUpdateDTO = new()
                {
                    Id = model.Id,
                    Text = model.Text,
                    WorkoutId = model.WorkoutId,
                    UserId = GetUserId()
                };

                await _commentService.UpdateCommentAsync(commentUpdateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove-user-comment")]
        public async Task<IActionResult> RemoveCommentAsync([FromBody] RemoveCommentModel model)
        {
            try
            {
                CommentRemoveDTO commentRemoveDTO = new()
                {
                    Id = model.Id,
                    WorkoutId = model.WorkoutId,
                    UserId = GetUserId()
                };

                await _commentService.RemoveCommentAsync(commentRemoveDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
