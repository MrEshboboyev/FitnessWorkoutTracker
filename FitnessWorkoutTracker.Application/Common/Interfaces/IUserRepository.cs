using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser user); 
    }
}
