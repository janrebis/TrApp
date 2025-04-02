using Microsoft.EntityFrameworkCore;
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

        public async Task<List<TrainingPlan>> GetTrainingPlanByTraineeIdAsync(Guid traineeId)
        {
            List<TrainingPlan> ? trainingPlan = await _dbContext.TrainingPlans.Where(temp => temp.TraineeId == traineeId).ToListAsync();
            if (trainingPlan == null)
            {
                throw new ApplicationException("Nie znaleziono planu treningowego o podanym id");
            }

            return trainingPlan;
        }

        public async Task<TrainingPlan> UpdateTrainingPlanAsync(TrainingPlan trainingPlan)
        {
            TrainingPlan? updateTraining = await _dbContext.TrainingPlans.FindAsync(trainingPlan.TrainingPlanId);
            if (updateTraining == null)
            {
                throw new ApplicationException("Nie znaleziono planu treningowego o podanym id");
            }

            updateTraining.TrainingPlanName = trainingPlan.TrainingPlanName;
            updateTraining.TrainingPlanStatus = trainingPlan.TrainingPlanStatus;
            updateTraining.TrainingType = trainingPlan.TrainingType;
            updateTraining.Exercises = trainingPlan.Exercises;
            await _dbContext.SaveChangesAsync();
            return updateTraining;
        }
    }
}
