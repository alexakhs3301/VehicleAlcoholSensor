using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Domain.Abstraction;

namespace VehicleAlcoholSensor.Domain.Entities
{
	public class Vehicle : BaseEntity
	{
		public string LicensePlate { get; set; }
	}
}
