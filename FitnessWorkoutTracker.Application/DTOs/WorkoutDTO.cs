namespace FitnessWorkoutTracker.Application.DTOs
{
    public class WorkoutDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public List<ExerciseDTO> Exercises { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
