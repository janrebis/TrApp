using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.InterfaceRepositories;
using TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions;

namespace TrApp.Infrastructure.Persistence.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TrainerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(Guid trainerId)
        {
            var trainer = await GetTrainerAsync(trainerId);
            _dbContext.Remove(trainer);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Trainer> FindByIdAsync(Guid trainerId)
        {
            return GetTrainerAsync(trainerId);
        }

        public async Task SaveAsync(Trainer trainer)
        {
            var existingTrainer = await _dbContext.Trainers
                .Include(tr => tr.TrainerId)
                .FirstOrDefaultAsync(tr => tr.TrainerId == trainer.TrainerId);

            if (existingTrainer == null) { _dbContext.Trainers.Add(trainer); }
            else {  _dbContext.Entry(existingTrainer).CurrentValues.SetValues(trainer); }
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Trainer> GetTrainerAsync(Guid trainerId)
        {
            var trainer = await _dbContext.Trainers.FindAsync(trainerId);
            if(trainer == null) {  throw new TrainerNotFoundException(); }
            return trainer;
        }
    }
}
