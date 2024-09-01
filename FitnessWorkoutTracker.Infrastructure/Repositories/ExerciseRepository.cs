using FitnessWorkoutTracker.Application.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessExerciseTracker.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _db;

        public ExerciseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Exercise exercise)
        {
            await _db.Exercises.AddAsync(exercise);
            await _db.SaveChangesAsync();
        }

        public async Task<Exercise> GetByIdAsync(Guid id)
        {
            return await _db.Exercises.FindAsync(id);
        }

        public async Task<IEnumerable<Exercise>> GetByWorkoutIdAsync(Guid workoutId)
        {
            return await _db.Exercises
                .Where(e => e.WorkoutId == workoutId)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var exercise = await GetByIdAsync(id);
            if (exercise != null)
            {
                _db.Exercises.Remove(exercise);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            _db.Exercises.Update(exercise);
            await _db.SaveChangesAsync();
        }
    }
}
