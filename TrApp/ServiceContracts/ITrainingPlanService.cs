using TrApp.Models;

namespace TrApp.ServiceContracts
{
    public interface ITrainingPlanService
    {
        public Task<TrainingPlan> CreateTrainingPlan(Guid traineeId, string name, List<Exercise> exercises, DateTime scheduledDate, string? notes);
        public Task<TrainingPlan> UpdateTrainingPlan();
        public Task<bool> DeleteTrainingPlan();
        public Task<TrainingPlan> GetTrainingPlanByClientId(Guid ClientId);
    }
}
