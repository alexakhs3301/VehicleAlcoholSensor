using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Abstraction;

namespace VehicleAlcoholSensor.Domain.Entities
{
	public class Driver : BaseEntity
	{
		public string? DriverName { get; set; }
		public int? DeviceId { get; set; }
		public Device Device { get; set; }
		public int? VehicleId { get; set; }
		public Vehicle Vehicle { get; set; }
	}
}
