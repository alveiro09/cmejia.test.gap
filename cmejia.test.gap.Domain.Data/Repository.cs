using cmejia.test.gap.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace cmejia.test.gap.Domain.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext context;

        private readonly DbSet<T> dbSet;

        public Repository(IDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public EntityState Create(T t)
        {
            var newEntry = dbSet.Add(t).State;
            context.SaveChanges();
            return newEntry;
        }

        public EntityState Delete(T t)
        {
            return dbSet.Remove(t).State;
        }
        public virtual EntityState Update(T t)
        {
            return dbSet.Update(t).State;
        }

        public T Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAsQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;
            if (include != null)
                query = include(query);

            return query;
        }

        public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public async Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}