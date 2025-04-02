using TrApp.Models;

namespace TrApp.ServiceContracts
{
    public interface ITrainingPlanService
    {
        public Task<TrainingPlan> CreateTrainingPlan(Guid traineeId, string name, List<Exercise> exercises, DateTime scheduledDate, string? notes);
        public Task<TrainingPlan> UpdateTrainingPlan(TrainingPlan trainingPlan);
        public Task<bool> DeleteTrainingPlan(Guid trainingPlanId);
        public Task<List<TrainingPlan>> GetTrainingPlanByTraineeId(Guid traineeId);
    }
}
