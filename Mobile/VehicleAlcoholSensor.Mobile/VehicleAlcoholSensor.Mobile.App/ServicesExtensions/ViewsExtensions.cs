using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Mobile.App.Views;

namespace VehicleAlcoholSensor.Mobile.App.ServicesExtensions
{
    public static class ViewsExtensions
    {
        public static IServiceCollection AddViewConstrunction(this IServiceCollection services)
        {
            services.AddSingleton<Connect>();
            services.AddSingleton<Report>();
            services.AddSingleton<Settings>();

            return services;
        }
    }
}
