using FitnessWorkoutTracker.Domain.Entities;

namespace FitnessWorkoutTracker.Application.Common.Interfaces
{
    public interface IWorkoutRepository : IRepository<Workout>
    {
        void Update(Workout workout); 
    }
}
