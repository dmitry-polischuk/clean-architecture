using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCqrs.Infrastructure.Persistance.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(t => t.DeviceId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasKey(d => d.DeviceId);
        }
    }
}
