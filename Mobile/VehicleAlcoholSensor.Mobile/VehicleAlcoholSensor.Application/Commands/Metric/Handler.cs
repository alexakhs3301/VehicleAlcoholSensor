using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Application.Abstraction;

namespace VehicleAlcoholSensor.Application.Commands.Metric
{
    public class Handler : IHandler<bool>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Handler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ExecuteAsync(ICommand entity)
        {
            if(entity == null)
            {
                return false;
            }

            if(entity is not Command command)
            {
                return false;
            }

            var client = _httpClientFactory.CreateClient("AlcoholSensor");
            var responseMessage = await client.PostAsync("/sensordatapost", new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));

            var jsonContent = await responseMessage.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<bool>(jsonContent);

            return result;
        }
    }
}
