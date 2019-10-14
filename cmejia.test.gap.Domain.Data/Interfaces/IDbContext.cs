using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace cmejia.test.gap.Domain.Data.Interfaces
{
    public interface IDbContext
    {
        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        void Dispose();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
