using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Infrastructure.Data;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // inject Db Context, IDbContextTransaction
        private readonly AppDbContext _db;

        public IUserRepository User { get; private set; }
        public IWorkoutRepository Workout { get; private set; }
        public IExerciseRepository Exercise { get; private set; }
        public ICommentRepository Comment { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            User = new UserRepository(db);
            Workout = new WorkoutRepository(db);
            Exercise = new ExerciseRepository(db);
            Comment = new CommentRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
