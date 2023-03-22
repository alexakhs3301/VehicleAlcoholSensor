using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Entities;
using VehicleAlcoholSensor.Mobile.App.Helpers;

namespace VehicleAlcoholSensor.Mobile.App.ServicesExtensions
{
	public static class ApplicationContextServiceExtensions
	{
		public static IServiceCollection AddDefaultContextForDebugOnly(this IServiceCollection services)
		{
#if DEBUG
			VehicleAlcoholSensorContext.Driver ??= new Driver()
			{
				Id = 1,
				DriverName = "Default Driver",
				DeviceId = 1,
				Device = new Domain.Entities.Device()
				{
					Id = 1,
					SerialNumber = "ALC_00001"
				},
				Vehicle = new Domain.Entities.Vehicle()
				{
					Id = 1,
					LicensePlate = "ABC-0123"
				}
		
			};
#endif

			return services;
		}
	}
}
