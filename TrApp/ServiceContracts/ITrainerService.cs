using TrApp.Models;

namespace TrApp.ServiceContracts
{
    public interface ITrainerService
    {
        public Task<Trainer> CreateTrainerAsync(Guid id);
        public Task<Trainer> FindTrainerByIdAsync(Guid id);

        public Task<bool> DeleteTrenerAsync(Guid id);
    }
}
