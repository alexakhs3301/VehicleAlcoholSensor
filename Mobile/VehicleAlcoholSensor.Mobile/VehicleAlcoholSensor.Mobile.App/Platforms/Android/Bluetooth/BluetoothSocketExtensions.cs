using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth
{
	public static class BluetoothSocketExtensions
	{
		public static async Task ConnectAsync(this BluetoothSocket socket, CancellationToken cancellationToken = default)
		{
			if (socket == null)
			{
				throw new ArgumentNullException(nameof(socket));
			}

			if (socket.IsConnected)
			{
				return;
			}

			using (cancellationToken.Register(() => socket.Close()))
			{
				TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
				try
				{
					await Task.Run(() => socket.Connect());
					tcs.SetResult(true);
				}
				catch (Exception ex)
				{
					tcs.SetException(ex);
				}

				await tcs.Task.ConfigureAwait(false);
			}
		}
	}
}
