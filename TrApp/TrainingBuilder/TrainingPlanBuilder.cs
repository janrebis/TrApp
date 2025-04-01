using TrApp.Models.Enum;
using TrApp.Models;

namespace TrApp.TrainingBuilder
{
    public class TrainingPlanBuilder
    {
        private readonly TrainingPlan _trainingPlan;

        public TrainingPlanBuilder(Guid traineeId)
        {
            _trainingPlan = new TrainingPlan
            {
                TrainingPlanId = Guid.NewGuid(),
                TraineeId = traineeId,
                TrainingPlanName = string.Empty,
                Exercises = new List<Exercise>(),
                CreationTime = DateTime.UtcNow,
                TrainingPlanStatus = TrainingPlanStatus.ACTIVE,
            };
        }

        public TrainingPlanBuilder WithScheduledDate(DateTime scheduledDate)
        {
            _trainingPlan.ScheduledDate = scheduledDate;
            return this;
        }

        public TrainingPlanBuilder AddExercise(Exercise exercise)
        {
            _trainingPlan.Exercises.Add(exercise);
            return this;
        }

        public TrainingPlanBuilder WithName(string trainingPlanName)
        {
            _trainingPlan.TrainingPlanName = trainingPlanName;
            return this;
        } 
        public TrainingPlanBuilder WithNotes(string notes)
        {
            _trainingPlan.Notes = notes;
            return this;
        }

        public TrainingPlan Build()
        {
            return _trainingPlan;
        }
    }
}