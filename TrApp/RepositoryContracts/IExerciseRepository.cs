using TrApp.Models;

namespace TrApp.RepositoryContracts
{
    public interface IExerciseRepository
    {
        public Task<Exercise> AddExerciseAsync(Exercise exercise);
        public Task<Exercise> UpdateExerciseAsync(Exercise exercise);
        public Task<bool> DeleteExerciseAsync(Guid exerciseId);
        public Task<List<Exercise>> GetAllExercises(Guid trainerId);

        public Task<Exercise> FindExerciseByIdAsyns(Guid exerciseId);
    }
}
