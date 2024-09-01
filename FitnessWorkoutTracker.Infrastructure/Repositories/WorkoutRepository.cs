using FitnessWorkoutTracker.Application.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _db;

        public WorkoutRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Workout workout)
        {
            await _db.Workouts.AddAsync(workout);
            await _db.SaveChangesAsync();
        }

        public async Task<Workout> GetByIdAsync(Guid id)
        {
            return await _db.Workouts   
                .Include(w => w.Exercises)
                .Include(w => w.Comments)
                .SingleOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Workout>> GetByUserIdAsync(Guid userId)
        {
            return await _db.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.Comments)
                .Include(w => w.Exercises)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var workout = await GetByIdAsync(id);
            if (workout != null)
            {
                _db.Workouts.Remove(workout);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Workout workout)
        {
            _db.Workouts.Update(workout);
            await _db.SaveChangesAsync();
        }
    }
}
