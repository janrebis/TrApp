using TrApp.Models;

namespace TrApp.RepositoryContracts
{
    public interface ITraineeRepository
    {
        public Task<Trainee> AddClientAsync(Trainee trainee);
        public Task<Trainee> UpdateClientAsync(Trainee trainee);
        public Task<bool> DeleteClientAsync(Guid clientId);
        public Task<Trainee> GetClientByIdAsync(Guid clientId);

    }
}
