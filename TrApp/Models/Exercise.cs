using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TrApp.Models
{
    public class Exercise
    {
        [Key]
        public Guid ExerciseId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public TimeSpan? ExerciseDuration { get; set; }
        public int? Weight { get; set; }

        public Guid TrainingPlanId { get; set; }
        [ForeignKey("TrainingPlanId")]
        public TrainingPlan? TrainingPlan { get; set; }
    }
}
