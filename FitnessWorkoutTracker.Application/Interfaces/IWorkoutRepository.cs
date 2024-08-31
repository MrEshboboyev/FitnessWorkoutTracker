using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<Workout> GetByIdAsync(Guid id);
        Task<IEnumerable<Workout>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Workout Workout);
        Task UpdateAsync(Workout Workout);
        Task RemoveAsync(Guid id);
    }
}
