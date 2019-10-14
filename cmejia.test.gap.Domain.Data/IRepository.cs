using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace cmejia.test.gap.Domain.Data
{
    public interface IRepository<T> where T : class
    {
        EntityState Create(T t);
        EntityState Delete(T t);
        EntityState Update(T t);
        T Get<TKey>(TKey id);
        IQueryable<T> GetAsQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
