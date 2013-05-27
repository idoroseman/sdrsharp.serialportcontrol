using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.SerialPortRemoteControl
{
    

    class ProtocolAPT : RemoteControlProtocol
    {
        private int[] Frequencies = { 137200000, 137100000, 137400000, 137500000, 137620000, 137912500, 137300000, 137700000, 137800000, 137850000 };
        private string[] names = { "", "NOAA 19", "", "", "NOAA15", "NOAA 18", "", "", "", "" };

        public ProtocolAPT(ISharpControl control) : base(control)
        {
        }

        override public void DataReceived(string data)
        {
            string msg = data.ToUpper();
            ShowMessage(msg);
            if (msg[0] == 'S') // scan command
                msg = msg.Remove(0, 1);

            if (msg.StartsWith("F")) // freq command
            {
                int index = int.Parse(msg.Substring(1, 1));
                _radio.CenterFrequency = (long)137500000;
                _radio.Frequency = (long)(Frequencies[index] );
                _radio.DetectorType = DetectorType.NFM;
                _radio.FilterBandwidth = 45000;
                ShowMessage(" => " + names[index]);
            }
        }
    }
}
