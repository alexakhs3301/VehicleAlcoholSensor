﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleAlcoholSensor.Application.Abstraction;
using VehicleAlcoholSensor.Domain;
using ReportModel = VehicleAlcoholSensor.Domain.Entities.Report;

namespace VehicleAlcoholSensor.Application.Commands.Report
{
    public class Handler : IHandler<IEnumerable<ReportModel>>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Handler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ReportModel>> HandleAsync(ICommand entity)
        {
            if(entity == null)
            {
                return Enumerable.Empty<ReportModel>();
            }

            if (entity is not Command command)
            {
                return Enumerable.Empty<ReportModel>();
            }

            var client = _httpClientFactory.CreateClient("AlcoholSensor");
            var responseMessage = await client.GetAsync($"/sensordataget?driverID={command.DriverId}&vehicleID={command.VehicleId}");

            var jsonContent = await responseMessage.Content.ReadAsStringAsync();

            var mRet = JsonConvert.DeserializeObject<IEnumerable<ReportModel>>(jsonContent);

            return mRet??Enumerable.Empty<ReportModel>();
        }
    }
}
