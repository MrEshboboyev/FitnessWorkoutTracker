using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
    {
        private readonly AppDbContext _db;

        public WorkoutRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Workout workout)
        {
            _db.Workouts.Update(workout);
        }
    }
}
