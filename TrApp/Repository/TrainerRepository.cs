using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrApp.Identity;
using TrApp.Models;
using TrApp.RepositoryContracts;

namespace TrApp.Repository
{
    public class TrainerRepository : ITrainerRepository

    {
        private readonly ApplicationDbContext _dbContext;

        public TrainerRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public async Task<Trainer> AddTrainerAsync(Guid trainerId)
        {
            Trainer trainer = new Trainer(trainerId);
            await _dbContext.Trainers.AddAsync(trainer);
            await _dbContext.SaveChangesAsync();
            return trainer;
        }

        public async Task DeleteTrainerAsync(Trainer trainer)
        {
            _dbContext.Trainers.Remove(trainer);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> DeleteTrainerAsync(Guid trainerId)
        {
            Trainer trainer = await _dbContext.Trainers.FirstOrDefaultAsync(temp => temp.Id == trainerId);
            _dbContext.Trainers.Remove(trainer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Trainer?> FindTrainerById(Guid trainerId)
        {
           Trainer? trainer =  await _dbContext.Trainers.FirstOrDefaultAsync(temp => temp.Id == trainerId);
            return trainer;
        }

   
    }
}
