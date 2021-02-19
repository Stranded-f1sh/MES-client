using ManufacturingExecutionSystem.MES.Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class WarehouseInspectionForm : Form
    {
        public WarehouseInspectionForm()
        {
            InitializeComponent();
        }


        private void WarehouseInspectionForm_Load(object sender, EventArgs e)
        {
            PortName_ComboBox.Items.AddRange(SerialPort.GetPortNames());
            try
            {
                PortName_ComboBox.SelectedIndex = 0;
                RoutePosition_ComboBox.Text = "1";
                PortStatus.ForeColor = Color.Red;
            }
            catch
            {

            }
        }

        private SerialPort SerialPortInit(SerialPortConfig serialPortConfig)
        {
            if (serialPortConfig == null) return null;
            SerialPort serialPort = new SerialPort
            {
                DataBits = serialPortConfig.DataBits,
                StopBits = serialPortConfig.StopBits,
                ReadTimeout = serialPortConfig.ReadTimeout,
                WriteBufferSize = serialPortConfig.WriteBufferSize,
                ReadBufferSize = 1024,
                RtsEnable = true,
                DtrEnable = true,
                ReceivedBytesThreshold = 1
            };
            return null;
        }
    }
}
