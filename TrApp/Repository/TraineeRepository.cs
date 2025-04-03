using Microsoft.EntityFrameworkCore;
using TrApp.Identity;
using TrApp.Models;
using TrApp.RepositoryContracts;

namespace TrApp.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TraineeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trainee> AddClientAsync(Trainee trainee)
        {
            await _dbContext.Trainees.AddAsync(trainee);
            await _dbContext.SaveChangesAsync();
            return trainee;
        }

        public async Task<bool> DeleteClientAsync(Guid clientId)
        {
            Trainee? trainee = await _dbContext.Trainees.FindAsync(clientId);
            if (trainee == null)
            {
                throw new ArgumentNullException("Nie udało się wyszukać klienta");
            }
            _dbContext.Trainees.Remove(trainee);
            _dbContext.SaveChanges();
            return true;

        }

        public async Task<Trainee> GetClientByIdAsync(Guid clientId)
        {
            Trainee? trainee = await _dbContext.Trainees.FirstOrDefaultAsync(temp => temp.Id == clientId);
            return trainee;
        }

        public Task<Trainee> UpdateClientAsync(Trainee trainee)
        {
            throw new NotImplementedException();
        }
    }
}
