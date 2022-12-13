using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleAlcoholSensor.Domain.Entities.Base;

namespace VehicleAlcoholSensor.EF.SchemaConfiguration
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LicensePlate).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.VehicleDrivers).WithOne(x => x.Vehicle);
        }
    }
}
