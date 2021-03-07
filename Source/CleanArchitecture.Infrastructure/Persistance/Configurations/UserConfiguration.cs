using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.UserId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(d => d.Email)
                .HasMaxLength(255);

            builder.HasKey(d => d.UserId);
        }
    }
}
