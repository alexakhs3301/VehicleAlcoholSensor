using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.EF.SchemaConfiguration
{
    public class VehicleDriverConfig : IEntityTypeConfiguration<VehicleDriverDevice>
    {
        public void Configure(EntityTypeBuilder<VehicleDriverDevice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSerialColumn();
        }
    }
}
