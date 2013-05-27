using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.SerialPortRemoteControl
{
    /// <summary>
    /// based on http://www.freqofnature.com/software/protocols.html#SI
    /// </summary>
    class ProtocolUniden : RemoteControlProtocol
    {
        public ProtocolUniden(ISharpControl control)
            : base(control)
        {
            _radio.FilterAudio = false;
            _radio.SquelchEnabled = false;
        }

        override public void DataReceived(string data)
        {
            string[] tokens = data.Split(new char[]{'\r'});
            foreach (string cmnd in tokens)
            {
                if (cmnd.Length < 2)
                    continue;
                switch (cmnd.Substring(0,2).ToUpper())
                {
                    case "SI": //Scanner Information
                        SendData("SI BC250D,0000000000,104");
                        break;
                    case "KE":
                        int code = int.Parse(cmnd.Substring(3,2));
                        switch (code)
                        {
                            case 00: // scan
                                break;
                            case 01: // manual
                                break;
                        }
                        break;
                    case "MU":
                        if (cmnd.Length > 2)
                        {
                            /*
                            if (cmnd.Substring(2,1) == "A") // automatic
                                _radio.SquelchEnabled = true;
                            else if (cmnd.Substring(2,1) == "N") // muted (speaker allways off)
                                _radio.SquelchEnabled = true;
                            else if (cmnd.Substring(2,1) == "F") // not muted
                                _radio.SquelchEnabled = false;
                             */
                            SendData("OK\r");
                        }
                        else // query status
                        {
                            if (_radio.SquelchEnabled)
                                SendData("MUA\r");
                            else
                                SendData("MUF\r");
                        }
                        break;
                    case "RF":
                        if (cmnd.Length > 2)
                        {
                            int freq = int.Parse(cmnd.Substring(2,8));
                            _radio.Frequency = (long)(freq * 100);
                            SendData("OK\r");
                            ShowMessage(cmnd);
                        }
                        else // query status
                        {
                            long freq = _radio.Frequency / 100;
                            SendData ("RF"+freq.ToString("D8"));
                        }
                        break;
                    default:
                        ShowMessage(cmnd);
                        break;
                }
            }
        }
    }
}
