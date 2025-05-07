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
<<<<<<< HEAD
        public Task UpdateAsync(T entity);
        public Task InsertAsync(T entity);
        
=======
        Task SaveAsync(T entity);
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4
        Task RemoveAsync(Guid id);
    }
}
