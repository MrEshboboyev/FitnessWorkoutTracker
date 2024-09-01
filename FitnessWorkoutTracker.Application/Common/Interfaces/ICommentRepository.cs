using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment comment); 
    }
}
