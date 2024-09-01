using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;
using FitnessWorkoutTracker.Infrastructure.Repositories;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly AppDbContext _db;

        public ExerciseRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Exercise exercise)
        {
            _db.Exercises.Update(exercise);
        }
    }
}
