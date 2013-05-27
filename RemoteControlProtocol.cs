using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.SerialPortRemoteControl
{
    public delegate void DataReadyDelegate(string data);

    public abstract class RemoteControlProtocol
    {
        protected readonly ISharpControl _radio;
        public event DataReadyDelegate OnDataToSend;
        public event DataReadyDelegate OnShowMessage;

        public RemoteControlProtocol(ISharpControl control)
        {
            _radio = control;
        }

        protected void SendData(string data)
        {
            if (OnDataToSend != null)
                OnDataToSend(data);
        }

        protected void ShowMessage(string data)
        {
            if (OnShowMessage != null)
                OnShowMessage(data);
        }

        abstract public void DataReceived(string data);
    }
}
