namespace FitnessWorkoutTracker.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation Property
        public ICollection<Workout> Workouts { get; set; }
    }
}
