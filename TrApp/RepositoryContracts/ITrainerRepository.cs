using TrApp.Models;

namespace TrApp.RepositoryContracts
{
    public interface ITrainerRepository
    {
        public Task<Trainer> AddTrainerAsync(Guid trainerId);
        public Task<bool> DeleteTrainerAsync(Guid trainerId);
        public Task<Trainer?> FindTrainerById(Guid trainerId);
    }
}
