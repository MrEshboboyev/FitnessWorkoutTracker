namespace FitnessWorkoutTracker.Domain.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkoutId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }


        // Navigation Property
        public Workout Workout { get; set; }
    }
}
