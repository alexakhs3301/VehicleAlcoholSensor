using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Domain.Entities
{
    public class Report
    {
        public int Concentration { get; set; }
        [JsonProperty("event_timestamp")]
        public DateTime EventTimestamp { get; set; }
        public float MgL { get; set; }
    }
}
