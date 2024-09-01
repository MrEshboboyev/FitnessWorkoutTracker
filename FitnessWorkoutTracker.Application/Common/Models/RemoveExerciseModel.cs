namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class RemoveExerciseModel
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
    }
}
