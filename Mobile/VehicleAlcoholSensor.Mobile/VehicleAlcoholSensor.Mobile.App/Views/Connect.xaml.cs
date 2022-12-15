using CommunityToolkit.Maui.Markup;
using VehicleAlcoholSensor.Mobile.App.Helpers;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Connect : ContentPage
{
	TapGestureRecognizer btnConnectGestureRecognizer;
	public Connect()
	{
		InitializeComponent();
		btnConnectGestureRecognizer= new TapGestureRecognizer();
        btnConnectGestureRecognizer.Tapped += ConnectButtonGesture;
		this.BtnConnect.GestureRecognizers.Add(btnConnectGestureRecognizer);

		

        this.Appearing += Connect_Appearing;
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
		if(VehicleAlcoholSensorContext.IsConnectedToBluetooth)
		{
			//Disconnect
			this.BtnConnect.BackgroundColor = Colors.Red;
			VehicleAlcoholSensorContext.IsConnectedToBluetooth = false;
			textMessage = $"The device has been disconncted.";
		}
		else
		{
			this.BtnConnect.BackgroundColor = Colors.Green;
			VehicleAlcoholSensorContext.IsConnectedToBluetooth = true;
			textMessage = $"The device has been connected.";
		}
		await App.Current.MainPage.DisplayAlert("Connectivity", textMessage, "OK");

    }

}