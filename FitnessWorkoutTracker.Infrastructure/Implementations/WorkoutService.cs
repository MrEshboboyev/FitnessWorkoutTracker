using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Application.Common.Models;
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

        public async Task<IEnumerable<Workout>> GetUserWorkoutsAsync(string userId)
        {
            try
            {
                return _unitOfWork.Workout.GetAll(w => w.UserId == userId); 
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
                return _unitOfWork.Workout.GetAll(w => w.Name == workoutName);
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
                return _unitOfWork.Workout.GetAll(w => w.UserId == userId && w.Name == workoutName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateUserWorkoutAsync(CreateWorkoutModel model)
        {
            try
            {
                Workout workout = new()
                {
                    Name = model.Name,
                    Date = model.Date,
                    UserId = model.UserId
                };
                _unitOfWork.Workout.Add(workout);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUserWorkoutAsync(UpdateWorkoutModel model)
        {
            try
            {
                var workoutFromDb = _unitOfWork.Workout.Get(w => w.UserId == model.UserId && w.Id == model.Id);

                // update fields
                workoutFromDb.Date = model.Date;
                workoutFromDb.Name = model.Name;

                _unitOfWork.Workout.Update(workoutFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveUserWorkoutAsync(RemoveUserWorkout model)
        {
            try
            {
                var workoutFromDb = _unitOfWork.Workout.Get(w => w.UserId == model.UserId && w.Id == model.Id);

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
