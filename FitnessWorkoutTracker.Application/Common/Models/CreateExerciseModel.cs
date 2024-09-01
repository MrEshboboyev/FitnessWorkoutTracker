namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class CreateExerciseModel
    {
        public Guid WorkoutId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
