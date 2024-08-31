namespace FitnessWorkoutTracker.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
