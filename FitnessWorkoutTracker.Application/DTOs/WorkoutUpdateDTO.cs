namespace FitnessWorkoutTracker.Application.DTOs
{
    public class WorkoutUpdateDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }    
    }
}
