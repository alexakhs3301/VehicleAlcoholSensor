namespace VehicleAlcoholSensor.Mobile.App.ServicesExtensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient("AlcoholSensor", @as =>
            {
                @as.BaseAddress = new Uri("http://192.168.1.8:8080");
            });

            return services;
        }
    }
}
