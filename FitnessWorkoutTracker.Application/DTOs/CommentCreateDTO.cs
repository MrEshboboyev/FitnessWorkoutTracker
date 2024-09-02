namespace FitnessWorkoutTracker.Application.DTOs
{
    public class CommentCreateDTO
    {
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
