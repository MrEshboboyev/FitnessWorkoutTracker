using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetByIdAsync(Guid id);
        Task<IEnumerable<Exercise>> GetByWorkoutIdAsync(Guid workoutId);
        Task AddAsync(Exercise Exercise);
        Task UpdateAsync(Exercise Exercise);
        Task RemoveAsync(Guid id);
    }
}
