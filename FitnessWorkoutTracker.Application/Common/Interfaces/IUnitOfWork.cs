namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IWorkoutRepository Workout { get; }
        IExerciseRepository Exercise { get; }
        ICommentRepository Comment { get; }
        void Save();
    }
}
