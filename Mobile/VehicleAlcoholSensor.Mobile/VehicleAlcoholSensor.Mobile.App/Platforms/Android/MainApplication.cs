using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Runtime;
using VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth;

namespace VehicleAlcoholSensor.Mobile.App
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            var receiver = new BluetoothReceiver();
            IntentFilter filter = new IntentFilter(BluetoothDevice.ActionFound);
            RegisterReceiver(receiver, filter);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}