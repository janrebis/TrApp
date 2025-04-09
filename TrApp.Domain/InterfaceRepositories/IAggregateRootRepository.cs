using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrApp.Domain.Entities.AggregateRoots;

namespace TrApp.Domain.InterfaceRepositories
{
    public interface IAggregateRootRepository<T> where T : class, IAggregateRoot
    {
        Task<T> FindByIdAsync(Guid id);
        public Task UpdateAsync(T entity);
        public Task InsertAsync(T entity);
        
        Task RemoveAsync(Guid id);
    }
}
