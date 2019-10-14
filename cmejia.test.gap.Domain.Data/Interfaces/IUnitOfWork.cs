using System;

namespace cmejia.test.gap.Domain.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        int Commit();
    }
}
