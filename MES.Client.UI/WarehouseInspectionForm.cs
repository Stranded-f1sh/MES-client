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
        private StringBuilder _appendStrings; // COM口读取数据缓存buffer

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
                PortName = serialPortConfig.PortName,
                BaudRate = serialPortConfig.BaudRate,
                DataBits = serialPortConfig.DataBits,
                StopBits = serialPortConfig.StopBits,
                ReadTimeout = serialPortConfig.ReadTimeout,
                WriteBufferSize = serialPortConfig.WriteBufferSize,
                ReadBufferSize = serialPortConfig.ReadBufferSize,
                RtsEnable = true,
                DtrEnable = true,
                ReceivedBytesThreshold = 1
            };
            return serialPort;
        }



        private void OpenDangle_Btn_Click(object sender, EventArgs e)
        {
            SerialPortConfig config = new SerialPortConfig
            {
                PortName = PortName_ComboBox.Text,
                BaudRate = 115200,
                DataBits = 8,
                StopBits = StopBits.One,
                ReadTimeout = 2000,
                WriteBufferSize = 1024,
                ReadBufferSize = 1024
            };
            SerialPort port = SerialPortInit(config);

        }


        /// <summary>
        /// 串口数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            ReadLine((SerialPort)sender);
        }



        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        private void ReadLine(SerialPort serialPort)
        {
            if (serialPort == null) return;
            if (!serialPort.IsOpen) return;
            if (_appendStrings == null) return;

            int bytes = serialPort.BytesToRead;
            byte[] readBuffer = new Byte[bytes];

            int count = serialPort.Read(readBuffer, 0, readBuffer.Length);

            if (count <= 0) return;

            string result = System.Text.Encoding.UTF8.GetString(readBuffer);

            _appendStrings.Append(result);

        }


        #region 扫码自动跳下一行
        private void Imei_1_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_2_TextBox.Focus();
            }
        }

        private void Imei_2_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_3_TextBox.Focus();
            }
        }

        private void Imei_3_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_4_TextBox.Focus();
            }
        }

        private void Imei_4_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_5_TextBox.Focus();
            }
        }

        private void Imei_5_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_6_TextBox.Focus();
            }
        }

        private void Imei_6_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_7_TextBox.Focus();
            }
        }

        private void Imei_7_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_8_TextBox.Focus();
            }
        }

        private void Imei_8_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_9_TextBox.Focus();
            }
        }

        private void Imei_9_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                Imei_10_TextBox.Focus();
            }
        }

        #endregion
    }
}
