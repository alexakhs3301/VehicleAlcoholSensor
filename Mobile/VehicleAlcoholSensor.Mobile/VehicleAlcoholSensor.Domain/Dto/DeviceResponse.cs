using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Domain.Dto
{
	public class DeviceResponse
	{
		public string DeviceSerialNumber { get; set; }
		public int ConcenstrationValue { get; set; }
	}
}
