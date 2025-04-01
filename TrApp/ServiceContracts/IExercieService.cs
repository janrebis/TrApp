using TrApp.Models;

namespace TrApp.ServiceContracts
{
    public interface IExercieService
    {
        public Task<Exercise> CreateExersiceAsync(Guid trainerId, string name, string? description, int? sets, int? repetitions, int? weight, TimeSpan? exerciseDuration);
        public Task<Exercise> UpdateExerciseAsyns(Guid exerciseId, string name, string? description, int? sets, int? repetitions, int? weight, TimeSpan? exerciseDuration);
        public Task<bool> DeleteExerciseAsyn(Guid exerciseId);
        public Task<List<Exercise>> GetExerciseListAsync(Guid trainerId);
    }
}
