using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;

namespace VehicleAlcoholSensor.Mobile.App.Infrastructure.Intefaces
{
    public interface IBluetoothConnector
    {
        public void SearchForDevives();
        public List<BluetoothDevice> GetConnectedDevices();
        public void Connect(string deviceName);
    }
}
