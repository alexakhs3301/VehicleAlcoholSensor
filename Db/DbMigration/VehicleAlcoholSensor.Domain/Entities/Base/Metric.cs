using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.Domain.Entities.Base
{
    /// <summary>
    /// Metric Class
    /// </summary>
    public sealed class Metric : BaseEntity
    {
        public int? VehicleDriverDeviceId { get; set; }
        public VehicleDriverDevice VehicleDriverDevice { get; set; }
        public int Concentration { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
