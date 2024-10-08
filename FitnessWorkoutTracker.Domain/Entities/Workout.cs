﻿namespace FitnessWorkoutTracker.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; } = false;

        // Navigation Properties
        public ApplicationUser User { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
