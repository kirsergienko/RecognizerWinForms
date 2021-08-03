using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VisioForge.Shared.NAudio.CoreAudioApi;

namespace Recognizer
{
    public static class AudioDevices
    {

        public static Dictionary<string, string> GetDeviceID()
        {
            Dictionary<string, string> devices = new Dictionary<string, string>();
            var enumerator = new MMDeviceEnumerator();
            foreach (var endpoint in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                devices.Add(endpoint.FriendlyName, endpoint.ID);
            }
            return devices;
        }
    }
}

