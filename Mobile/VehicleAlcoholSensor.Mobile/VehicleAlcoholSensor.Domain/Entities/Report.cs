using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Domain.Entities
{
    public class Report
    {
        public float Percentage { get; set; }
        public DateTime EventTimestamp { get; set; }
    }
}
