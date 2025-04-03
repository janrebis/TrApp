using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrApp.Models;
using TrApp.Models.Enum;

namespace TrApp.Identity
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<TrainingPlan> TrainingPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
            builder.Entity<Trainer>().ToTable("Trainers");
            builder.Entity<Trainee>().ToTable("Trainees");
            builder.Entity<Exercise>().ToTable("Exercises");
            builder.Entity<TrainingPlan>().ToTable("TrainingPlans");

            builder.Entity<Trainer>(entity =>
            {
                entity.HasKey(t => t.Id);
            });

            //Table Relations
            builder.Entity<Trainee>(entity =>
            {
                entity.HasOne<Trainer>(c => c.Trainer)
                   .WithMany(p => p.Trainees)
                   .HasForeignKey(p => p.TrainerId)
                   .IsRequired();
            });

            builder.Entity<TrainingPlan>(entity =>
            {
                entity.HasOne(tp => tp.Trainee)
                      .WithMany(t => t.TrainingPlans) 
                      .HasForeignKey(tp => tp.TraineeId)
                      .IsRequired();
            });


            builder.Entity<Exercise>(entity =>
            {
                entity.HasOne(e => e.TrainingPlan)
                      .WithMany(tp => tp.Exercises)
                      .HasForeignKey(e => e.TrainingPlanId)
                      .IsRequired();
            });
        }

    }
}

