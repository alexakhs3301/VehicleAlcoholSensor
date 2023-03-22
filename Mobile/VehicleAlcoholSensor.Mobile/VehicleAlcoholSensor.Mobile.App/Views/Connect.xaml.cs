using VehicleAlcoholSensor.Mobile.App.Helpers;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Bluetooth;
using System.Diagnostics;
using VehicleAlcoholSensor.Application.Commands.Metric;
using MetricHandler = VehicleAlcoholSensor.Application.Commands.Metric.Handler;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Connect : ContentPage
{
	TapGestureRecognizer btnConnectGestureRecognizer;
	private IBluetoothConnectionManager _bluetoothConnectionManager;
	CancellationTokenSource _cancellationTokenSource;
	private readonly MetricHandler _metricHandler;

	public Connect(MetricHandler metricHandler)
	{
		InitializeComponent();
		btnConnectGestureRecognizer = new TapGestureRecognizer();
		btnConnectGestureRecognizer.Tapped += ConnectButtonGesture;
		this.BtnConnect.GestureRecognizers.Add(btnConnectGestureRecognizer);
		_bluetoothConnectionManager = DependencyService.Get<IBluetoothConnectionManager>();



		this.Appearing += Connect_Appearing;
		_metricHandler = metricHandler;
	}

	private void Connect_Appearing(object sender, EventArgs e)
	{
		VehicleAlcoholSensorContext.BluetoothDevice = new BluetoothDevice
		{
			Name = Preferences.Default.Get("BluetoothDeviceName", "Unknown"),
			Address = Preferences.Default.Get("BluetoothDeviceAddress", "Unknown")
		};

		if (VehicleAlcoholSensorContext.BluetoothDevice is null)
		{
			LblConnectedDevice.Text = "Connected Device: Unknown";
		}
		else
		{
			LblConnectedDevice.Text = $"Connected Device: {VehicleAlcoholSensorContext.BluetoothDevice.Name}({VehicleAlcoholSensorContext.BluetoothDevice.Address})";
		}
	}

	private async void ConnectButtonGesture(object sender, EventArgs e)
	{
		var textMessage = "";
		if (VehicleAlcoholSensorContext.IsConnectedToBluetooth)
		{
			//Disconnect
			this.BtnConnect.BackgroundColor = Colors.Red;
			VehicleAlcoholSensorContext.IsConnectedToBluetooth = false;
			_cancellationTokenSource.Cancel();
			_bluetoothConnectionManager.Disconnect();
			textMessage = $"The device has been disconncted.";
		}
		else
		{
			this.BtnConnect.BackgroundColor = Colors.Green;
			VehicleAlcoholSensorContext.IsConnectedToBluetooth = true;
			ConnectToDevice();
			textMessage = $"The device has been connected.";


		}
		await App.Current.MainPage.DisplayAlert("Connectivity", textMessage, "OK");

	}

	private async void ConnectToDevice()
	{
		try
		{
			string deviceAddress = VehicleAlcoholSensorContext.BluetoothDevice.Address; // Replace with your Bluetooth device's address
			bool isConnected = await _bluetoothConnectionManager.ConnectToDeviceAsync(deviceAddress);
			if (isConnected)
			{
				// Send AT Command
				WriteData("connected");
				_cancellationTokenSource = new CancellationTokenSource();
				Task.Run(async () => await MessageReader(_cancellationTokenSource.Token));
				Task.Run(async () => await SendToApi(_cancellationTokenSource.Token));
				
			}
		}
		catch (System.IO.IOException)
		{

		}
		catch (Exception)
		{
			await DisplayAlert("Error", "The Device runs a problem. Maybe you connect this device to another device.", "OK");
		}
	}


	private async void WriteData(string data)
	{
		await _bluetoothConnectionManager.WriteDataAsync(data);
	}


	public async Task MessageReader(CancellationToken cancellationToken)
	{
		while (!cancellationToken.IsCancellationRequested)
		{
			try
			{
				string data = await _bluetoothConnectionManager.ReadDataAsync();
#if DEBUG
				Debug.WriteLine($"The raw data from Bluetooth adaptor is: {data}");
#endif
				var split = data.Split(new string[] {",","\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

				if(split.Length <= 0)
				{
					continue;
				}

				foreach(var value in split)
				{
					var actual = value.Split("|", StringSplitOptions.RemoveEmptyEntries);

#if DEBUG
					Debug.WriteLine($"The Actual Data is: {actual[0]} and {actual[1]}");
#endif

					VehicleAlcoholConsentrationQueue._deviceResponses.Enqueue(new Domain.Dto.DeviceResponse()
					{
						DeviceSerialNumber = actual[0].Trim(),
						ConcenstrationValue = Convert.ToInt32(actual[1].Trim())
					});
				}

				
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error while reading the data from Bluetooth: {ex.Message}");
			}
		}
	}

	public async Task SendToApi(CancellationToken cancellationToken)
	{
		while(!cancellationToken.IsCancellationRequested)
		{
			if(VehicleAlcoholConsentrationQueue._deviceResponses.Count < 0)
			{
				continue;
			}

			while(VehicleAlcoholConsentrationQueue._deviceResponses.Count > 0)
			{
				var deviceResponse = VehicleAlcoholConsentrationQueue._deviceResponses.Dequeue();

				var command = new Application.Commands.Metric.Command
				{
					Concentration = deviceResponse.ConcenstrationValue,
					DeviceId = deviceResponse.DeviceSerialNumber == VehicleAlcoholSensorContext.Driver.Device.SerialNumber ? VehicleAlcoholSensorContext.Driver.Device.Id : 0,
					DriverId = VehicleAlcoholSensorContext.Driver.Id,
					VehicleId = VehicleAlcoholSensorContext.Driver.Vehicle.Id,
					Timestamp = DateTime.UtcNow
				};

				await _metricHandler.ExecuteAsync(command);
			}
		}
	}

}