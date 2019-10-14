using cmejia.test.gap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmejia.test.gap.Domain.Mapping
{
    internal class PolicyMap : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("policy");

            builder.HasKey(item => item.PolicyId);

            builder.Property(item => item.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(item => item.Description)
                   .HasColumnName("description");

            builder.Property(item => item.Price)
                      .HasColumnName("price");

            builder.Property(item => item.StartVadilityTime)
                      .HasColumnName("startVadilityTime");
        }
    }
}
