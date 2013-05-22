//  ******************************************
//  This is the "plug" for the plugin.  It defines properties
//  for your plugin that get referenced by SDRSharp.
//  ******************************************

using System.Windows.Forms;
using SDRSharp.Common;

namespace SDRSharp.SerialPortControl
{
    public class SerialPortControlPlugin : ISharpPlugin
    {
        private const string MyDisplayName = "Serial Port Control";
        private ISharpControl _controlInterface;
        private SerialPortControlCollapsiblePanel _freqEntryPanel;

        #region ISharpPlugin Members

        public bool HasGui
        {
            get { return true; }
            //todo - return true or false depending on whether your plugin must display in the control panel
        }

        public UserControl GuiControl
        {
            get { return _freqEntryPanel; }
        }

        public string DisplayName
        {
            get { return MyDisplayName; }
        }

        public void Close()
        {
        }

        public void Initialize(ISharpControl control)
        {
            _controlInterface = control;
            _freqEntryPanel = new SerialPortControlCollapsiblePanel(_controlInterface);
        }

        #endregion
    }
}