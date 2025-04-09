using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Models;
using TrApp.Models.Enum;

namespace TrApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<TrainingPlan> TrainingPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trainer>(builder =>
            {
                builder.HasKey(t => t.TrainerId);

                builder.Ignore(t => t.Trainees);

                builder
                    .HasMany<Trainee>("_trainees") // <- Powiedz EF, że to jest kolekcja z prywatnym polem
                    .WithOne(t => t.Trainer)
                    .HasForeignKey(t => t.TrainerId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Navigation("_trainees").UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Trainee>(builder =>
            {
                builder.HasKey(t => t.TraineeId);
            });
        

        modelBuilder.Entity<TrainingPlan>()
                .HasMany<Exercise>("_exercises")
                .WithOne(e => e.TrainingPlan)
                .HasForeignKey(e => e.TrainingPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingPlan>()
                .HasKey(tp => tp.TrainingPlanId);

            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.ExerciseId);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        } 
    }
}
        
