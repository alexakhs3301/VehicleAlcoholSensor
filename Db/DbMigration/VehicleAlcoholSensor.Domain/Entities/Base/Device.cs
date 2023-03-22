using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Abstraction;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;

namespace VehicleAlcoholSensor.Domain.Entities.Base
{
	public class Device : BaseEntity
	{
		public string SerialNumber { get; set; }
		public ICollection<VehicleDriverDevice> VehicleDriverDevices { get; set; }
	}
}
