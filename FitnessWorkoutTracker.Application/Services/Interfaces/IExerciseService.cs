using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<IEnumerable<Exercise>> GetUserExercisesAsync(string userId);
        Task<IEnumerable<Exercise>> GetExercisesByExerciseNameAsync(string exerciseName);
        Task<IEnumerable<Exercise>> GetUserExercisesByExerciseNameAsync(string userId, string exerciseName);
        Task CreateExerciseAsync(ExerciseCreateDTO exerciseCreateDTO);
        Task UpdateExerciseAsync(ExerciseUpdateDTO exerciseUpdateDTO);
        Task RemoveExerciseAsync(ExerciseRemoveDTO exerciseRemoveDTO);
    }
}
