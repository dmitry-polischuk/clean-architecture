using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCqrs.Domain.Entities;

namespace MyCqrs.Infrastructure.Persistance.Configurations
{
    public class DesireConfiguration : IEntityTypeConfiguration<Desire>
    {
        public void Configure(EntityTypeBuilder<Desire> builder)
        {
            builder.Property(t => t.DesireId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(255);

            builder.HasKey(d => d.DesireId);
        }
    }
}
