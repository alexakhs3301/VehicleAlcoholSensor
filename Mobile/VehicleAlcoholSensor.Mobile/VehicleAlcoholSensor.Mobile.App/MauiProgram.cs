using Microsoft.Maui.LifecycleEvents;
using CommunityToolkit.Maui;
using VehicleAlcoholSensor.Mobile.App.ServicesExtensions;
using VehicleAlcoholSensor.Mobile.App.Views;

namespace VehicleAlcoholSensor.Mobile.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddDefaultContextForDebugOnly();
            builder.Services.AddHttpClients();
            builder.Services.AddCommands();
            builder.Services.AddViewConstrunction();

            return builder.Build();
        }
    }
}