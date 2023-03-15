using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace VehicleAlcoholSensor.RestSharp.DependencyInjection.Internals
{
	internal class RestSharpSingleton
	{
		internal static Dictionary<string, RestClient> _restSharpClients = new Dictionary<string, RestClient>();
	}
}
