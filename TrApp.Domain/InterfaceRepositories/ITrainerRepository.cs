using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrApp.Domain.Entities.AggregateRoots;

namespace TrApp.Domain.InterfaceRepositories
{
    public interface ITrainerRepository
    {
        public Task<Trainer> FindByIdAsync(Guid Trainerid);
        public Task SaveAsync(Trainer trainer);
        public Task DeleteAsync(Guid TrainerId);
    }
}
