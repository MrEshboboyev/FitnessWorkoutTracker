namespace FitnessWorkoutTracker.Application.DTOs
{
    public class CommentUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
