//  ******************************************
//  Frequency Entry Collapsible Panel
//  Copyright © Jeff Knapp 2013 
//
//  This plugin restores the ability to enter a frequency
//  into SDR# instead of scrolling individual digits up and 
//  using the SDR# ginormous numbers.
//  ******************************************
//  Date        Changes
//  01/01/13    initial release
//  01/08/13    updated trimHeight config key to new name
//  01/10/13    disabled trimheight because it adversely affected panel state
//  ******************************************

using System;
using System.ComponentModel;
using System.Windows.Forms;
using SDRSharp.CollapsiblePanel;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.SerialPortRemoteControl
{
    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("SerialPortControl Panel")]
    public sealed partial class SerialPortControlCollapsiblePanel : UserControl
    {
        #region FreqEntry Panel setup

        private const String Copyright = "Copyright © Ido Roseman 2013";
        private const String NumericFormat = "N0"; 
        private readonly ISharpControl _controlInterface;
        private RemoteControlProtocol _protocol;


        /// <summary>
        /// Constructor.  
        /// </summary>
        public SerialPortControlCollapsiblePanel(ISharpControl control)
        {
            try
            {
                InitializeComponent();
                _controlInterface = control;
                _controlInterface.PropertyChanged += ControlPropertyChanged;
                Load += SerialPortControlPanelLoad;
            }
            catch (Exception ex)
            {
                String msg = String.Format("An error occurred.  The error was: \n\r{0}",
                                           ex.Message + "\n\r" + ex.StackTrace.Trim());
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// GUI-specific one-time setup work.
        /// </summary>
        private void SerialPortControlPanelLoad(object sender, EventArgs e)
        {
            try
            {
                // _mf = ParentForm;
                ////trim parent control height to remove excess bottom margin
                //if (Utils.GetBooleanSetting("freqMgrTrimPanelHeight"))
                //{
                //    Control[] feArray = _mf.Controls.Find("FreqEntryCollapsiblePanel", true);
                //    var fe = (FreqEntryCollapsiblePanel)feArray[0];
                //    var cp = (CollapsiblePanel.CollapsiblePanel)fe.Parent;
                //    PanelStateOptions exp = cp.PanelState;
                //    cp.Height = Height;
                //    cp.PanelState = exp;
                //}
                //init updown controls
                //frequencyNumericUpDown.Value = _controlInterface.Frequency;
                //frequencyNumericUpDown.Increment = _controlInterface.StepSize;
                //centerFreqNumericUpDown.Value = _controlInterface.CenterFrequency;
                //centerFreqNumericUpDown.Increment = _controlInterface.StepSize;
                ProtocolSelectionBox.Items.Add("APT");
                ProtocolSelectionBox.Items.Add("Uniden");
                string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
                PortSelectionBox.Items.AddRange(theSerialPortNames);
            }
            catch (Exception ex)
            {
                //frequencyNumericUpDown.Enabled = false;
                //centerFreqNumericUpDown.Enabled = false;
                String msg = String.Format("An error occurred.  The error was: \n\r{0}",
                                           ex.Message + "\n\r" + ex.StackTrace.Trim());
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region control events 

        /// <summary>
        /// handle notifications from SDR# that one of its properties has changed
        /// </summary>
        private void ControlPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Frequency":
                    //frequencyNumericUpDown.Text = _controlInterface.Frequency.ToString(NumericFormat);
                    break;
                case "CenterFrequency":
                    //centerFreqNumericUpDown.Text = _controlInterface.CenterFrequency.ToString(NumericFormat);
                    break;
                case "StepSize":
                    //frequencyNumericUpDown.Increment = _controlInterface.StepSize;
                    //centerFreqNumericUpDown.Increment = _controlInterface.StepSize;
                    break;
            }
        }

        /// <summary>
        /// fires when value changes, we then change the value in the radio
        /// </summary>
        private void CenterFreqNumericUpDownValueChanged(object sender, EventArgs e)
        {
            //_controlInterface.CenterFrequency = (long) centerFreqNumericUpDown.Value;
        }

        /// <summary>
        /// fires when value changes, we then change the value in the radio
        /// </summary>
        private void FrequencyNumericUpDownValueChanged(object sender, EventArgs e)
        {
            //_controlInterface.Frequency = (long) frequencyNumericUpDown.Value;
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = PortSelectionBox.SelectedItem.ToString();
            EnableBox.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableBox.Checked)
            {
                switch (ProtocolSelectionBox.SelectedItem.ToString())
                {
                    case "APT" :
                        _protocol = new ProtocolAPT(_controlInterface);
                        break;
                    case "Uniden" :
                        _protocol = new ProtocolUniden(_controlInterface);
                        break;
                }
                if (_protocol != null)
                {
                    _protocol.OnDataToSend += SendData;
                    _protocol.OnShowMessage += ShowMessage;
                }
                serialPort1.Open();
                PortSelectionBox.Enabled = false;
                ProtocolSelectionBox.Enabled = false;
            }
            else
            {
                serialPort1.Close();
                PortSelectionBox.Enabled = true;
                ProtocolSelectionBox.Enabled = true;
            }

        }

        private void ShowMessage(string data)
        {
            textBox1.Text = data;
        }

        private void SendData(string data)
        {
            serialPort1.Write(data);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string msg = serialPort1.ReadExisting();
            if (_protocol != null)
                _protocol.DataReceived(msg);
        }

    }
}