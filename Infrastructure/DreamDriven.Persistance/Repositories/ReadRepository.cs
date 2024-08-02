using DreamDriven.Application.Repositories;
using DreamDriven.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DreamDriven.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> _entities { get => dbContext.Set<T>(); }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            _entities.AsNoTracking();
            if ( predicate is not null ) _entities.Where(predicate);

            return await _entities.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if ( !enableTracking ) _entities.AsNoTracking();
            return _entities.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> query = _entities;
            if ( !enableTracking ) query = query.AsNoTracking();
            if ( include is not null ) query = include(query);
            if ( predicate is not null ) query = query.Where(predicate);
            if ( orderBy is not null )
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
        {
            IQueryable<T> query = _entities;
            if ( !enableTracking ) query = query.AsNoTracking();
            if ( include is not null ) query = include(query);
            //query.Where(predicate);

            return await query.FirstOrDefaultAsync(predicate);
        }
    }
}
