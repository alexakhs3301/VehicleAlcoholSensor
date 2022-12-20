using Android.Bluetooth;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Mobile.App.Platforms.Android.Bluetooth
{
    [BroadcastReceiver(Enabled = true)]
    public class BluetoothReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;

            if (action != BluetoothDevice.ActionFound)
            {
                return;
            }

            if (BluetoothDevice.ActionFound.Equals(action))
            {
                var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                var ConnectState = device.BondState;
                /*
                switch (ConnectState)
                {
                    case Bond.None:
                        break;
                    case Bond.Bonded:
                        break;
                    case Bond.Bonding:
                        break;
                }
                */
            }
        }
    }
}
