using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Intefaces;

namespace VehicleAlcoholSensor.Mobile.App
{
    public partial class BluetoothConnector : IBluetoothConnector
    {
        public partial void SearchForDevives();

        public partial List<BluetoothDevice> GetConnectedDevices();

        public partial void Connect(string deviceName);

    }
}
