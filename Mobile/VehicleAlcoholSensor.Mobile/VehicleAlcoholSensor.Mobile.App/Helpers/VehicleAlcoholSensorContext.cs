using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;

namespace VehicleAlcoholSensor.Mobile.App.Helpers
{
    public static class VehicleAlcoholSensorContext
    {
        public static bool IsConnectedToBluetooth = false;
        public static BluetoothDevice BluetoothDevice;
    }
}
