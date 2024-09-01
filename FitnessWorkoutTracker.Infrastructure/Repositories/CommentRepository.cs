using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment comment)
        {
            _db.Comments.Update(comment);
        }
    }
}
