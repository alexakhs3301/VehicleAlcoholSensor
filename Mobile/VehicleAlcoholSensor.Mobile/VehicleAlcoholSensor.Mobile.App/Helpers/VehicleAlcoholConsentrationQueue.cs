using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Dto;

namespace VehicleAlcoholSensor.Mobile.App.Helpers
{
	internal static class VehicleAlcoholConsentrationQueue
	{
		public static Queue<DeviceResponse> _deviceResponses = new Queue<DeviceResponse>();
	}
}
