using TrApp.Models;

namespace TrApp.RepositoryContracts
{
    public interface ITrainingPlanRepository
    {
        public Task<TrainingPlan> AddTrainingPlanAsync(TrainingPlan trainingPlan);
        public Task<bool> DeleteTrainingPlanAsync(Guid trainingPlanId);
        public Task<TrainingPlan> UpdateTrainingPlanAsync(TrainingPlan trainingPlan);
        public Task<List<TrainingPlan>> GetTrainingPlanByTraineeIdAsync(Guid traineeId);
    }
}
