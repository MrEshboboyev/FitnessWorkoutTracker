namespace FitnessWorkoutTracker.Application.DTOs
{
    public class WorkoutCreateDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
