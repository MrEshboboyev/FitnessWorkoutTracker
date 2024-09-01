using FitnessWorkoutTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring One-to-Many relationship between User and Workouts
            modelBuilder.Entity<User>()
                .HasMany(u => u.Workouts)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring One-to-Many relationship between Workout and Exercises
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring One-to-Many relationship between Workout and Comments
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Comments)
                .WithOne(c => c.Workout)
                .HasForeignKey(c => c.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
