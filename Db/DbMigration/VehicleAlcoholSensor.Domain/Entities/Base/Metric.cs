using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.Domain.Entities.Base
{
    /// <summary>
    /// Metric Class
    /// </summary>
    public sealed class Metric : BaseEntity
    {
        public int? VehicleDriverId { get; set; }
        public VehicleDriver VechicleDriver { get; set; }
        public float Percentage { get; set; }
    }
}
