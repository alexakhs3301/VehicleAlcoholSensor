using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.Domain.Entities.Security
{
    /// <summary>
    /// User Entity
    /// </summary>
    public sealed class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }

		public ICollection<VehicleDriverDevice> VehicleDriverDevices { get; set; }
	}
}
