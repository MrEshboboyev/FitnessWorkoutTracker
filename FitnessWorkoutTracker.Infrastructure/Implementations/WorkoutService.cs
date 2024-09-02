using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Infrastructure.Implementations
{
    public class WorkoutService : IWorkoutService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            try
            {
                return _unitOfWork.Workout.GetAll(includeProperties: "Exercises,Comments"); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Workout>> GetUserWorkoutsAsync(string userId)
        {
            try
            {
                return _unitOfWork.Workout.GetAll(w => w.UserId == userId,
                    includeProperties: "Exercises,Comments"); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByWorkoutNameAsync(string workoutName)
        {
            try
            {
                return _unitOfWork.Workout.GetAll(w => w.Name == workoutName, 
                    includeProperties: "Exercises,Comments");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Workout>> GetUserWorkoutsByWorkoutNameAsync(string userId, string workoutName)
        {
            try
            {
                return _unitOfWork.Workout.GetAll(w => w.UserId == userId && w.Name == workoutName, 
                    includeProperties: "Exercises,Comments");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateUserWorkoutAsync(WorkoutCreateDTO workoutCreateDTO)
        {
            try
            {
                Workout workout = new()
                {
                    Name = workoutCreateDTO.Name,
                    Date = workoutCreateDTO.Date,
                    UserId = workoutCreateDTO.UserId
                };
                _unitOfWork.Workout.Add(workout);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUserWorkoutAsync(WorkoutUpdateDTO workoutUpdateDTO)
        {
            try
            {
                var workoutFromDb = _unitOfWork.Workout.Get(w => w.UserId == workoutUpdateDTO.UserId 
                    && w.Id == workoutUpdateDTO.Id);

                if (workoutFromDb == null)
                    throw new Exception("Workout not found!");

                // update fields
                workoutFromDb.Date = workoutUpdateDTO.Date;
                workoutFromDb.Name = workoutUpdateDTO.Name;

                _unitOfWork.Workout.Update(workoutFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveUserWorkoutAsync(WorkoutRemoveDTO workoutRemoveDTO)
        {
            try
            {
                var workoutFromDb = _unitOfWork.Workout.Get(w => w.UserId == workoutRemoveDTO.UserId 
                    && w.Id == workoutRemoveDTO.Id);

                if (workoutFromDb == null)
                    throw new Exception("Workout not found!");

                _unitOfWork.Workout.Remove(workoutFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
