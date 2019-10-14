using cmejia.test.gap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cmejia.test.gap.Domain.Mapping
{
    public class Context : DbContext, IDisposable
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<TypeCovering> TypeCovering { get; set; }
        public DbSet<TypeRisk> TypeRisk { get; set; }


        public Context(DbContextOptions<Context> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new PolicyMap());
            modelBuilder.ApplyConfiguration(new TypeCoveringMap());
            modelBuilder.ApplyConfiguration(new TypeRiskMap());
        }
    }
}