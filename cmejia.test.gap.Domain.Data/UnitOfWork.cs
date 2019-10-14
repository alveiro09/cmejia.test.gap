using cmejia.test.gap.Domain.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace cmejia.test.gap.Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext dbContext;

        private Dictionary<Type, object> repositories;

        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(obj: this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<T>(dbContext);
            }

            return (IRepository<T>)repositories[type];
        }

        private void Dispose(bool disposing)
        {
            if (disposing && dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }
    }
}