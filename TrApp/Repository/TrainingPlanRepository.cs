using TrApp.Identity;
using TrApp.Models;
using TrApp.RepositoryContracts;

namespace TrApp.Repository
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public async Task<TrainingPlan> AddTrainingPlanAsync(TrainingPlan trainingPlan)
        {
            await _dbContext.TrainingPlans.AddAsync(trainingPlan);
            await _dbContext.SaveChangesAsync();
            return trainingPlan;
        }

        public async Task<bool> DeleteTrainingPlanAsync(Guid trainingPlanId)
        {
            TrainingPlan? trainingPlanToDelete = await _dbContext.TrainingPlans.FindAsync(trainingPlanId);
            if (trainingPlanToDelete == null)
            {
                throw new ApplicationException("Nie znaleziono planu treningowego o podanym id");
            }

            _dbContext.TrainingPlans.Remove(trainingPlanToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TrainingPlan> GetTrainingPlanByIdAsync(Guid trainingPlanId)
        {
            TrainingPlan? trainingPlan = await _dbContext.TrainingPlans.FindAsync(trainingPlanId);
            if (trainingPlan == null)
            {
                throw new ApplicationException("Nie znaleziono planu treningowego o podanym id");
            }

            return trainingPlan;
        }

        public async Task<TrainingPlan> UpdateTrainingPlanAsync(TrainingPlan trainingPlan)
        {
            TrainingPlan? trainingPlanToUpdate = await _dbContext.TrainingPlans.FindAsync(trainingPlan.TrainingPlanId);
            if (trainingPlanToUpdate == null)
            {
                throw new ApplicationException("Nie znaleziono planu treningowego o podanym id");
            }

            trainingPlanToUpdate.TrainingPlanName = trainingPlan.TrainingPlanName;
            trainingPlanToUpdate.TrainingPlanStatus = trainingPlan.TrainingPlanStatus;
            trainingPlanToUpdate.TrainingType = trainingPlan.TrainingType;
            trainingPlanToUpdate.Exercises = trainingPlan.Exercises;
            await _dbContext.SaveChangesAsync();
            return trainingPlanToUpdate;
        }
    }
}
