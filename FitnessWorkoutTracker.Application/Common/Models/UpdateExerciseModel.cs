namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class UpdateExerciseModel
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
