using Android.Bluetooth;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Bluetooth;

namespace VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth
{
	public class BluetoothConnectionManager : IBluetoothConnectionManager
	{
		private BluetoothAdapter _bluetoothAdapter;
		private BluetoothDevice _device;
		private BluetoothSocket _socket;
		private Stream _inputStream;
		private Stream _outputStream;

		public BluetoothConnectionManager(Context context)
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
		}

		public BluetoothConnectionManager()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
		}

		public async Task<bool> ConnectToDeviceAsync(string deviceAddress)
		{
			_device = _bluetoothAdapter.GetRemoteDevice(deviceAddress);
			if (_device == null)
			{
				return false;
			}

			_socket = _device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
			await _socket.ConnectAsync();
			_inputStream = _socket.InputStream;
			_outputStream = _socket.OutputStream;
			return true;
		}

		public async Task<string> ReadDataAsync()
		{
			if (_inputStream == null)
			{
				return null;
			}

			byte[] buffer = new byte[1024];
			int bytesRead = await _inputStream.ReadAsync(buffer, 0, buffer.Length);
			return Encoding.ASCII.GetString(buffer, 0, bytesRead);
		}

		public async Task WriteDataAsync(string data)
		{
			if (_outputStream == null)
			{
				return;
			}

			byte[] buffer = Encoding.ASCII.GetBytes(data);
			await _outputStream.WriteAsync(buffer, 0, buffer.Length);
		}

		public void Disconnect()
		{
			_inputStream?.Close();
			_outputStream?.Close();
			_socket?.Close();
		}
	}
}
