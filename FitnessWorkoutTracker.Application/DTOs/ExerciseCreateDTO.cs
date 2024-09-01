namespace FitnessWorkoutTracker.Application.DTOs
{
    public class ExerciseCreateDTO
    {
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
