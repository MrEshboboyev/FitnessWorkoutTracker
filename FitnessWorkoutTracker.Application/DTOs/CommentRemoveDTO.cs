﻿namespace FitnessWorkoutTracker.Application.DTOs
{
    public class CommentRemoveDTO
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string UserId { get; set; }
    }
}
