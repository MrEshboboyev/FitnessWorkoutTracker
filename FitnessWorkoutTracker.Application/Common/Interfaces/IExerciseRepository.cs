using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        void Update(Exercise exercise); 
    }
}
