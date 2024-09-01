namespace FitnessWorkoutTracker.Application.Common.Models
{
    public class UpdateWorkoutModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
