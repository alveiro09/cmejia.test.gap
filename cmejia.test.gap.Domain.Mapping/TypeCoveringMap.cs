using cmejia.test.gap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmejia.test.gap.Domain.Mapping
{
    internal class TypeCoveringMap : IEntityTypeConfiguration<TypeCovering>
    {
        public void Configure(EntityTypeBuilder<TypeCovering> builder)
        {
            builder.ToTable("TypeCovering");

            builder.HasKey(item => item.TypeCoveringId);

            builder.Property(item => item.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(item => item.Percentage)
                   .HasColumnName("Percentage");

            builder.Property(item => item.Descripcion)
                      .HasColumnName("description");
        }
    }
}
