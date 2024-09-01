using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user); 
    }
}
