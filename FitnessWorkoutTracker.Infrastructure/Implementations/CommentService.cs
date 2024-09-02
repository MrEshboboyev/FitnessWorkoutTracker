using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Services.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Infrastructure.Implementations
{
    public class CommentService : ICommentService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Comment>> GetUserComments(string userId)
        {
            try
            {
                return _unitOfWork.Comment.GetAll(c => c.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Comment>> GetWorkoutComments(Guid workoutId)
        {
            try
            {
                return _unitOfWork.Comment.GetAll(c => c.WorkoutId == workoutId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateCommentAsync(CommentCreateDTO commentCreateDTO)
        {
            try
            {
                var isWorkoutExist = _unitOfWork.Workout.Any(w => w.Id == commentCreateDTO.WorkoutId);

                if (!isWorkoutExist)
                    throw new Exception("Workout not found!");

                Comment comment = new()
                {
                    WorkoutId = commentCreateDTO.WorkoutId,
                    UserId = commentCreateDTO.UserId,
                    CreatedAt = DateTime.UtcNow,
                    Text = commentCreateDTO.Text
                };

                _unitOfWork.Comment.Add(comment);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCommentAsync(CommentUpdateDTO commentUpdateDTO)
        {
            try
            {
                var commentFromDb = _unitOfWork.Comment.Get(
                    c => c.Id == commentUpdateDTO.Id 
                    && c.WorkoutId == commentUpdateDTO.WorkoutId 
                    && c.UserId == commentUpdateDTO.UserId);

                if (commentFromDb is null)
                    throw new Exception("Workout/Comment not found!");

                //  update fields
                commentFromDb.Text = commentUpdateDTO.Text;

                _unitOfWork.Comment.Update(commentFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveCommentAsync(CommentRemoveDTO commentRemoveDTO)
        {
            try
            {
                var commentFromDb = _unitOfWork.Comment.Get(
                    c => c.Id == commentRemoveDTO.Id
                    && c.WorkoutId == commentRemoveDTO.WorkoutId
                    && c.UserId == commentRemoveDTO.UserId);

                if (commentFromDb is null)
                    throw new Exception("Workout/Comment not found!");

                _unitOfWork.Comment.Remove(commentFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
