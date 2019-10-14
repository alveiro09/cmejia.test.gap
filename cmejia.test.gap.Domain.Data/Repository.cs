using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace cmejia.test.gap.Domain.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IDbContext context;

        private readonly DbSet<TEntity> dbSet;

        public Repository(IDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public EntityState Create(TEntity t)
        {
            var newEntry = dbSet.Add(t).State;
            context.SaveChanges();
            return newEntry;
        }

        public EntityState Delete(TEntity t)
        {
            return dbSet.Remove(t).State;
        }
        public virtual EntityState Update(TEntity t)
        {
            return dbSet.Update(t).State;
        }

        public TEntity Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAsQueryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (include != null)
                query = include(query);

            return query;
        }

        public IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}