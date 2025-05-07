using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.Entities.Enum;
using TrApp.Domain.Exception;
using TrApp.Domain.Validators;

namespace TrApp.Models
{
    public class Exercise
    {
        [Key]
        public Guid ExerciseId { get; private set; }
        [Required]
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int? Sets { get; private set; }
        public int? Repetitions { get; private set; }
        public TimeSpan? ExerciseDuration { get; private set; }
        public int? Weight { get; private set; }
        public WeightUnit? WeightUnit { get; private set; }
        public Guid TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; private set; }
        public Exercise(string name, string? description, int? sets, int? repetitions, TimeSpan? exerciseDuration, int? weight, WeightUnit? weightUnit, Guid trainingPlanId)
        {
            ExerciseId = Guid.NewGuid();
            ExerciseValidator.EnsureNonNegative(sets, nameof(sets));
            ExerciseValidator.EnsureNonNegative(repetitions, nameof(repetitions));
            ExerciseValidator.EnsureNonNegative(weight, nameof(weight));

            Name = name;
            Description = description;
            Sets = sets;
            Repetitions = repetitions;
            ExerciseDuration = exerciseDuration;
            Weight = weight;
            WeightUnit = weightUnit;
            TrainingPlanId= trainingPlanId;
        }

        internal void UpdateDescription(string? description) => Description = description;
        internal void UpdateSets(int? sets) 
        {
            Sets = sets;
        }
        internal void UpdateRepetitions(int? repetitions)
        {
            Repetitions = repetitions;
        }
        internal void UpdateExerciseDuration(TimeSpan? exerciseDuration) => ExerciseDuration = exerciseDuration;
        internal void UpdateWeight(int? weight)
        {
            Weight = weight;
        }

        internal void UpdateWeightUnit(WeightUnit? weightUnit) 
        {
            WeightUnit = weightUnit;
        } 

    }
}
