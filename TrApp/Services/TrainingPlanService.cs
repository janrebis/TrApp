using TrApp.Models;
using TrApp.RepositoryContracts;
using TrApp.ServiceContracts;
using TrApp.TrainingBuilder;

namespace TrApp.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<TrainingPlan> CreateTrainingPlan(Guid traineeId, string name, List<Exercise> exercises, DateTime scheduledDate, string? notes)
        {
            var trainingPlan = new TrainingPlanBuilder(traineeId)
                .WithScheduledDate(scheduledDate)
                .WithName(name)
                .WithNotes(notes);

            foreach(var exercise in exercises)
            {
                trainingPlan.AddExercise(exercise);
            }

            return trainingPlan.Build();

           
            
        }

        public Task<bool> DeleteTrainingPlan()
        {
            throw new NotImplementedException();
        }

        public Task<TrainingPlan> GetTrainingPlanByClientId(Guid ClientId)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingPlan> UpdateTrainingPlan()
        {
            throw new NotImplementedException();
        }
    }
}
