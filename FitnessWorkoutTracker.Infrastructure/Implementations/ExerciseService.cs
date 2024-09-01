using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Infrastructure.Implementations
{
    public class ExerciseService : IExerciseService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public ExerciseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            try
            {
                return _unitOfWork.Exercise.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByExerciseNameAsync(string exerciseName)
        {
            try
            {
                return _unitOfWork.Exercise.GetAll(e => e.Name == exerciseName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Exercise>> GetUserExercisesAsync(string userId)
        {
            try
            {
                List<Exercise> exercises = new List<Exercise>();
                var workouts = _unitOfWork.Workout.GetAll(w => w.UserId == userId, includeProperties: "Exercises");

                foreach (var workout in workouts) 
                {
                    exercises.AddRange(workout.Exercises);
                }
                return exercises;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Exercise>> GetUserExercisesByExerciseNameAsync(string userId, string exerciseName)
        {
            try
            {
                List<Exercise> exercises = new List<Exercise>();
                var workouts = _unitOfWork.Workout.GetAll(w => w.UserId == userId, includeProperties: "Exercises");

                foreach (var workout in workouts)
                {
                    exercises.AddRange(workout.Exercises);
                }
                return exercises.Where(e => e.Name == exerciseName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateExerciseAsync(ExerciseCreateDTO exerciseCreateDTO)
        {
            try
            {
                Exercise exercise = new()
                {
                    Name = exerciseCreateDTO.Name,
                    Reps = exerciseCreateDTO.Reps,
                    Sets = exerciseCreateDTO.Sets,
                    WorkoutId = exerciseCreateDTO.WorkoutId
                };

                _unitOfWork.Exercise.Add(exercise);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task UpdateExerciseAsync(ExerciseUpdateDTO exerciseUpdateDTO)
        {
            try
            {
                var exerciseFromDb = _unitOfWork.Exercise.Get(e => e.Id == exerciseUpdateDTO.Id);
                
                exerciseFromDb.Name = exerciseUpdateDTO.Name;
                exerciseFromDb.Reps = exerciseUpdateDTO.Reps;
                exerciseFromDb.Sets = exerciseUpdateDTO.Sets;
                exerciseFromDb.WorkoutId = exerciseUpdateDTO.WorkoutId;

                _unitOfWork.Exercise.Update(exerciseFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveExerciseAsync(ExerciseRemoveDTO exerciseRemoveDTO)
        {
            try
            {
                var exerciseFromDb = _unitOfWork.Exercise.Get(e => e.Id == exerciseRemoveDTO.Id);

                _unitOfWork.Exercise.Remove(exerciseFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
