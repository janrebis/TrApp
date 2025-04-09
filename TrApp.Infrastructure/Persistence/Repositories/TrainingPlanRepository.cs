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
    public class TrainingPlanRepository : BaseRepository<TrainingPlan>, IAggregateRootRepository<TrainingPlan>
    {
        public TrainingPlanRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<TrainingPlan> FindByIdAsync(Guid id)
        {
            var trainingPlan = await _dbContext.TrainingPlans
                .Include(tp => tp.Exercises)
                .FirstOrDefaultAsync(tp => tp.TrainingPlanId == id);
            if (trainingPlan == null) throw new TrainerNotFoundException();
            return trainingPlan;
        }
    }
}
