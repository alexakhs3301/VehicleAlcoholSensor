using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.Domain.Entities.Base
{
    /// <summary>
    /// Vehicle Entity
    /// </summary>
    public sealed class Vehicle : BaseEntity
    {
        public string LicensePlate { get; set; }

        public ICollection<VehicleDriver> VehicleDrivers { get; set; }
    }
}
