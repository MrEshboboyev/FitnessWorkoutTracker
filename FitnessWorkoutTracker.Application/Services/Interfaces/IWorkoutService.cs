using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
        Task<IEnumerable<Workout>> GetUserWorkoutsAsync(string userId);
        Task<IEnumerable<Workout>> GetUserWorkoutsByWorkoutNameAsync(string userId, string workoutName);
        Task<IEnumerable<Workout>> GetWorkoutsByWorkoutNameAsync(string workoutName);
        Task CreateUserWorkoutAsync(WorkoutCreateDTO workoutCreateDTO);
        Task UpdateUserWorkoutAsync(WorkoutUpdateDTO workoutUpdateDTO);
        Task RemoveUserWorkoutAsync(WorkoutRemoveDTO workoutRemoveDTO);
    }
}
