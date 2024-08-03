﻿using DreamDriven.Application.Repositories;
using DreamDriven.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DreamDriven.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> _entities { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => _entities.Remove(entity));
        }

        public async Task HardDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => _entities.RemoveRange(entities));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _entities.Update(entity));

            return entity;
        }
    }
}
