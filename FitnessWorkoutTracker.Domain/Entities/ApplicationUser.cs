using Microsoft.AspNetCore.Identity;

namespace FitnessWorkoutTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        // Navigation Property
        public ICollection<Workout> Workouts { get; set; }
    }
}
