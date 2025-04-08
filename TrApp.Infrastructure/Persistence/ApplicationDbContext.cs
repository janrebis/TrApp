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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Trainer>()
                .HasMany<Trainee>("_trainees")
                .WithOne(te => te.Trainer)  
                .HasForeignKey(te => te.TrainerId) 
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<Trainer>()
                .HasKey(tr => tr.TrainerId);

            builder.Entity<Trainee>()
                .HasKey(te => te.TraineeId);

            builder.Entity<TrainingPlan>()
                .HasMany<Exercise>("_exercises")
                .WithOne(e => e.TrainingPlan)
                .HasForeignKey(e => e.TrainingPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TrainingPlan>()
                .HasKey(tp => tp.TrainingPlanId);

            builder.Entity<Exercise>()
                .HasKey(e => e.ExerciseId);
        } 
    }
}
        
