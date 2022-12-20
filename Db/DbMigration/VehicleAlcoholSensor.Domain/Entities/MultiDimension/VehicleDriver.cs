using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.Base;
using VehicleAlcoholSensor.Domain.Entities.Security;

namespace VehicleAlcoholSensor.Domain.Entities.MultiDimension
{
    /// <summary>
    /// Vehicle Driver Multi Table Entity
    /// </summary>
    public sealed class VehicleDriver : BaseEntity
    {
        public int? DriverId { get; set; }
        public User Driver { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public ICollection<Metric> Metrics { get; set; }
    }
}
