using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.InterfaceRepositories;
using TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions;
using TrApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace TrApp.Infrastructure.Persistence.Repositories
{
    public class TrainerRepository : BaseRepository<Trainer>, IAggregateRootRepository<Trainer>
    {
        public TrainerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<Trainer> FindByIdAsync(Guid id)
        {
            var trainer = await _dbContext.Trainers
                .Include("_trainees")
                .FirstOrDefaultAsync(tr => tr.TrainerId == id);
            if (trainer == null) throw new TrainerNotFoundException();
            return trainer;
        }
    }
}