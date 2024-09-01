namespace FitnessWorkoutTracker.Application.DTOs
{
    public class ExerciseRemoveDTO
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
    }
}
