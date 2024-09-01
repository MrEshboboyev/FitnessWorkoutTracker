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
                var workout = _unitOfWork.Workout.Get(w => w.Id == exerciseCreateDTO.WorkoutId
                    && w.UserId == exerciseCreateDTO.UserId);

                if (workout == null)
                    throw new Exception($"Workout Id : '{exerciseCreateDTO.WorkoutId}' not found.");

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
                var workout = _unitOfWork.Workout.Get(w => w.Id == exerciseUpdateDTO.WorkoutId
                    && w.UserId == exerciseUpdateDTO.UserId);

                if (workout == null)
                    throw new Exception("Workout not found.");

                var exerciseFromDb = _unitOfWork.Exercise.Get(e => e.Id == exerciseUpdateDTO.Id && 
                    e.WorkoutId == workout.Id);

                if (workout == null || exerciseFromDb == null)
                    throw new Exception("Exercise not found."); 

                exerciseFromDb.Name = exerciseUpdateDTO.Name;
                exerciseFromDb.Reps = exerciseUpdateDTO.Reps;
                exerciseFromDb.Sets = exerciseUpdateDTO.Sets;

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
                var workout = _unitOfWork.Workout.Get(w => w.Id == exerciseRemoveDTO.WorkoutId
                    && w.UserId == exerciseRemoveDTO.UserId);

                if (workout == null)
                    throw new Exception("Workout not found.");

                var exerciseFromDb = _unitOfWork.Exercise.Get(e => e.Id == exerciseRemoveDTO.Id &&
                    e.WorkoutId == workout.Id);

                if (exerciseFromDb == null)
                    throw new Exception("Exercise not found.");

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
