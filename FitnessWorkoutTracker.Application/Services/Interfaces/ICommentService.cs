using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetUserComments(string userId);
        Task<IEnumerable<Comment>> GetWorkoutComments(Guid workoutId);
        Task CreateCommentAsync(CommentCreateDTO commentCreateDTO);
        Task UpdateCommentAsync(CommentUpdateDTO commentUpdateDTO);
        Task RemoveCommentAsync(CommentRemoveDTO commentRemoveDTO);
    }
}
