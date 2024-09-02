using System.Text.Json.Serialization;

namespace FitnessWorkoutTracker.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [JsonIgnore]
        public Workout Workout { get; set; }
        public ApplicationUser User { get; set; }
    }
}
