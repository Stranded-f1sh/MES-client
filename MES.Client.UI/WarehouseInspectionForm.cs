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
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            comboBox1.SelectedItem = comboBox1.Items[0]?.ToString();

        }

        private SerialPort SerialPortComImplement(SerialPortConfig serialPortConfig)
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
