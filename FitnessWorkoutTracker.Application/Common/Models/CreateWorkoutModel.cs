namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class CreateWorkoutModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
