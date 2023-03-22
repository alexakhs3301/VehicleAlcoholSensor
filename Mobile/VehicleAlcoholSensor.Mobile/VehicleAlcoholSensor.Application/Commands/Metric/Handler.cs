using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            try
            {
                var client = _httpClientFactory.CreateClient("AlcoholSensor");
                var responseMessage = await client.PostAsync("/sensordatapost", new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));
                if(responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
