using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(Guid id);
        Task<IEnumerable<Comment>> GetByWorkoutIdAsync(Guid workoutId);
        Task AddAsync(Comment Comment);
        Task UpdateAsync(Comment Comment);
        Task RemoveAsync(Guid id);
    }
}
