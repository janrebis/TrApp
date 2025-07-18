﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.InterfaceRepositories;

namespace TrApp.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IAggregateRootRepository<T> where T : class, IAggregateRoot
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbContext.Attach(entity);  // Dołączamy encję do kontekstu
                entry.State = EntityState.Modified; // Ustawiamy jej stan na Modified
            }

            await _dbContext.SaveChangesAsync();
        }


        public virtual async Task SaveAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var entity = await FindByIdAsync(id); 
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public abstract Task<T> FindByIdAsync(Guid id); 
    }
}

