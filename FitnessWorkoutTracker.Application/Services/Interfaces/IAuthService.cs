using FitnessWorkoutTracker.Application.Common.Models;
using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel model);
        Task RegisterAsync(RegisterModel model);
        Task<string> GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
