namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class UpdateCommentModel
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string Text { get; set; }
    }
}
