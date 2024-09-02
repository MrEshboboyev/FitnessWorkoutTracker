namespace FitnessWorkoutTracker.Application.DTOs
{
    public class WorkoutQueryDTO
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
