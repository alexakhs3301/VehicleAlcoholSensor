using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Mobile.App.ServicesExtensions
{
    public static class ApplicationCommandsExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<Application.Commands.Report.Handler>();

            return services;
        }
    }
}
