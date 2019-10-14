using cmejia.test.gap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmejia.test.gap.Domain.Mapping
{
    internal class TypeRiskMap : IEntityTypeConfiguration<TypeRisk>
    {
        public void Configure(EntityTypeBuilder<TypeRisk> builder)
        {
            builder.ToTable("TypeRisk");

            builder.HasKey(item => item.TypeRiskId);

            builder.Property(item => item.Name)
                   .HasColumnName("name")
                   .IsRequired();
        }
    }
}
