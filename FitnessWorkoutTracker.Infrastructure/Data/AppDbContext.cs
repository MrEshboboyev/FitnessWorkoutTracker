using FitnessWorkoutTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring One-to-Many relationship between User and Workouts
            modelBuilder.Entity<ApplicationUser>()
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
