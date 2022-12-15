using Android.Bluetooth;
using VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth;
using BluetoothDevice = VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain.BluetoothDevice;

namespace VehicleAlcoholSensor.Mobile.App
{
    public partial class BluetoothConnector
    {
        private BluetoothAdapter _adapter;
        public partial void Connect(string deviceName)
        {
            throw new NotImplementedException();
        }

        public partial List<BluetoothDevice> GetConnectedDevices()
        {
            _adapter = BluetoothAdapter.DefaultAdapter;
            var _mret = new List<BluetoothDevice>();
            if(_adapter is null)
            {
                throw new NullReferenceException("There is not any bluetooth device.");
            }

            if(!_adapter.IsEnabled)
            {
                _adapter.Enable();
            }

            if(_adapter.BondedDevices.Count > 0)
            {
                foreach(var device in _adapter.BondedDevices)
                {
                    _mret.Add(new BluetoothDevice() { Name = device.Name, Address = device.Address });
                }
            }

            return _mret;
        }

        public partial void SearchForDevives()
        {
            if(_adapter is null)
            {
                _adapter = BluetoothAdapter.DefaultAdapter;
            }

            if (!_adapter.IsEnabled)
            {
                _adapter.Enable();
            }

            _adapter.StartDiscovery();
        }
    }
}
