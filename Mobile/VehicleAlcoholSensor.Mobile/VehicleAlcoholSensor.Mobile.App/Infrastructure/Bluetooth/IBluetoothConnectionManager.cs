using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Mobile.App.Infrastructure.Bluetooth
{
	public interface IBluetoothConnectionManager
	{
		Task<bool> ConnectToDeviceAsync(string deviceAddress);
		Task<string> ReadDataAsync();
		Task WriteDataAsync(string data);
		void Disconnect();
	}
}
