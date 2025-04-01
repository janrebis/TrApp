using System.ComponentModel.DataAnnotations;
using TrApp.Models.Enum;

namespace TrApp.Models
{
    public class TrainingPlan
    {
        [Key]
        public Guid TrainingPlanId { get; set; }
        public Guid TraineeId { get; set; }
        public string? TrainingPlanName { get; set; }
        public TrainingType? TrainingType { get; set; }
        public List<Exercise> Exercises { get; set; }
        public TimeSpan? TotalDuration
        {
            get => Exercises?.Aggregate(TimeSpan.Zero, (sum, exercise) => sum + (exercise.ExerciseDuration ?? TimeSpan.Zero)) ?? TimeSpan.Zero;
        } 
        public TrainingPlanStatus TrainingPlanStatus { get; set; } = TrainingPlanStatus.ACTIVE;
        public DateTime CreationTime { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Notes { get; set; }
    }
}
