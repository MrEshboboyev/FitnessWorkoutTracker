using FitnessWorkoutTracker.Application.Common.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using FitnessWorkoutTracker.Infrastructure.Data;

namespace FitnessWorkoutTracker.Infrastructure.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser user)
        {
            _db.Users.Update(user);
        }
    }
}
