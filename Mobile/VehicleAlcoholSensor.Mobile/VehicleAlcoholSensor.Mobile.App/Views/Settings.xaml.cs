using VehicleAlcoholSensor.Mobile.App.Helpers;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Domain;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Settings : ContentPage
{
	public List<BluetoothDevice> BluetoothDevices;
	public Settings()
	{
		InitializeComponent();
		FillTable();
        this.BluetoothDevicesListView.ItemSelected += BluetoothDevicesListView_ItemSelected;
	}

    private async void BluetoothDevicesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var bluetoothDevice = (BluetoothDevice)e.SelectedItem;
		var answer = await DisplayAlert("Connect to device", "Do you want to connect to this device?" + Environment.NewLine +
			$"{bluetoothDevice.Name}({bluetoothDevice.Address})", "Yes", "No");

		if(answer)
		{
			VehicleAlcoholSensorContext.BluetoothDevice = bluetoothDevice;
			Preferences.Default.Set("BluetoothDeviceName", bluetoothDevice.Name);
			Preferences.Default.Set("BluetoothDeviceAddress", bluetoothDevice.Address);
		}
    }

    private void FillTable()
    {
		var bluetoothConnector = new BluetoothConnector();
		BluetoothDevices = bluetoothConnector.GetConnectedDevices();
		this.BluetoothDevicesListView.ItemsSource = BluetoothDevices;
    }
}