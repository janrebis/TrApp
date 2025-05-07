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
<<<<<<< HEAD
                .Include("_trainees")
=======
                .Include(tr => tr.Trainees) 
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4
                .FirstOrDefaultAsync(tr => tr.TrainerId == id);
            if (trainer == null) throw new TrainerNotFoundException();
            return trainer;
        }
    }
}