using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetUserWorkoutsAsync(string userId);
        Task<IEnumerable<Workout>> GetUserWorkoutsByWorkoutNameAsync(string workoutName);
        Task CreateUserWorkoutAsync(CreateWorkoutModel model);
        Task UpdateUserWorkoutAsync(UpdateWorkoutModel model);
        Task RemoveUserWorkoutAsync(RemoveUserWorkout model);
    }
}
