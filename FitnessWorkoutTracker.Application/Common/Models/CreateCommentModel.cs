namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class CreateCommentModel
    {
        public Guid WorkoutId { get; set; }
        public string Text { get; set; }
    }
}
