using FitnessWorkoutTracker.Application.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommentTracker.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            return await _db.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetByWorkoutIdAsync(Guid workoutId)
        {
            return await _db.Comments
                .Where(c => c.WorkoutId == workoutId)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var comment = await GetByIdAsync(id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Comment comment)
        {
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync();
        }
    }
}
