using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Entities.Base;

namespace VehicleAlcoholSensor.EF.SchemaConfiguration
{
	public class DeviceConfig : IEntityTypeConfiguration<Device>
	{
		public void Configure(EntityTypeBuilder<Device> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseSerialColumn();
			builder.Property(x => x.SerialNumber).HasMaxLength(50).IsRequired(true);
			builder.HasMany(x => x.VehicleDriverDevices).WithOne(x=>x.Device);

			builder.HasIndex(x => x.SerialNumber).IsUnique(true);
		}
	}
}
