using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Mobile.Infrastructure.Bluetooth
{
    public interface IBluetoothConnector
    {
        public List<string> GetConnectedDevices();
        public void Connect(string deviceName);
    }
}
