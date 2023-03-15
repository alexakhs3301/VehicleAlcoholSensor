using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.RestSharp.DependencyInjection
{
	public static class ServicesCollection
	{
		public static IServiceCollection AddRestSharpClient(this IServiceCollection source, string name, Action<RestClient> action)
		{
			if(source is null) throw new ArgumentNullException(nameof(source));

			if(action is null) throw new ArgumentNullException(nameof(action));

			if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

			source.AddTransient(provider =>
			{
				var restSharpClient = new RestClient();

				action?.Invoke(restSharpClient);

				Internals.RestSharpSingleton._restSharpClients.Add(name, restSharpClient);
				
				return 
			})



			return source;
		}
	}
}
