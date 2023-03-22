using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using VehicleAlcoholSensor.Mobile.App.Infrastructure.Bluetooth;
using VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth;

namespace VehicleAlcoholSensor.Mobile.App
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            this.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
			DependencyService.RegisterSingleton<IBluetoothConnectionManager>(new BluetoothConnectionManager());
		}
    }
}