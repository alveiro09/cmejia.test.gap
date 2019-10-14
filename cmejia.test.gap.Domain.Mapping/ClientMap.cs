using cmejia.test.gap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmejia.test.gap.Domain.Mapping
{
    internal class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.HasKey(item => item.ClientId);

            builder.Property(item => item.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(item => item.Description)
                   .HasColumnName("description");

            builder.Property(item => item.DateOfBirth)
                      .HasColumnName("dateOfBirth");

            builder.Property(item => item.Idnumber)
                      .HasColumnName("idnumber");

        }
    }
}
