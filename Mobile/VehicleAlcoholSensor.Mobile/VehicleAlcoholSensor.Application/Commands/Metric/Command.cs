using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Application.Abstraction;

namespace VehicleAlcoholSensor.Application.Commands.Metric
{
    public class Command : ICommand
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public double Percentage { get; set; }
    }
}
