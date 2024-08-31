using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string userName);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);
    }
}
