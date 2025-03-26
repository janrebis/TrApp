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
        private readonly ApplicationDbContext _db;

        public TrainerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Trainer> AddTrainerAsync(Guid trainerId)
        {
            Trainer trainer = new Trainer(trainerId);
            await _db.Trainers.AddAsync(trainer);
            await _db.SaveChangesAsync();
            return trainer;
        }

        public async Task DeleteTrainerAsync(Trainer trainer)
        {
            _db.Trainers.Remove(trainer);
            await _db.SaveChangesAsync();

        }

        public async Task<bool> DeleteTrainerAsync(Guid trainerId)
        {
            Trainer trainer = await _db.Trainers.FirstOrDefaultAsync(temp => temp.Id == trainerId);
            _db.Trainers.Remove(trainer);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<Trainer?> FindTrainerById(Guid trainerId)
        {
           Trainer? trainer =  await _db.Trainers.FirstOrDefaultAsync(temp => temp.Id == trainerId);
            return trainer;
        }

   
    }
}
