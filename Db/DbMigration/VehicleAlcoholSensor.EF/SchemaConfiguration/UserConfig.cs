﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleAlcoholSensor.Domain.Entities.Security;

namespace VehicleAlcoholSensor.EF.SchemaConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSerialColumn();
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(300).IsRequired();
            builder.Property(x => x.EMail).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.VehicleDriverDevices).WithOne(x => x.Driver);

            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.HasIndex(x=>x.EMail).IsUnique(true);
        }
    }
}
