using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.InterfaceRepositories;
using TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions;
using TrApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class TrainerRepository : ITrainerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrainerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Trainer> FindByIdAsync(Guid trainerId)
    {
        var trainer = await _dbContext.Trainers
            .Include(t => t.Trainees) 
            .FirstOrDefaultAsync(t => t.TrainerId == trainerId);
        if (trainer == null) throw new TrainerNotFoundException();
        return trainer;
    }

    public async Task SaveAsync(Trainer trainer)
    {
        _dbContext.Update(trainer); 
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid trainerId)
    {
        var trainer = await FindByIdAsync(trainerId); 
        _dbContext.Trainers.Remove(trainer);
        await _dbContext.SaveChangesAsync();
    }
}