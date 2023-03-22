using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using VehicleAlcoholSensor.Domain.Entities.Base;

namespace VehicleAlcoholSensor.EF.SchemaConfiguration
{
    public class MetricConfig : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSerialColumn();
            builder.HasOne(x => x.VehicleDriverDevice).WithMany(x => x.Metrics);

        }
    }
}
