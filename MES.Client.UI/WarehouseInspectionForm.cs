using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class WarehouseInspectionForm : Form
    {

        SerialPort serialPortContext; // 打开的串口;


        private StringBuilder _appendStrings; // COM口读取数据缓存buffer

        public WarehouseInspectionForm()
        {
            InitializeComponent();
        }


        private void WarehouseInspectionForm_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + HardwareEnum.Win32_SerialPort);
            Console.WriteLine(searcher.Get());
            var serialPortInfos = searcher.Get();
            foreach (var serialPortInfo in serialPortInfos)
            {
                if (serialPortInfo.Properties["Name"] != null)
                {
                    Console.WriteLine(serialPortInfo.Properties["Name"].Value);
                    PortName_ComboBox.Items.Add(serialPortInfo.Properties["Name"].Value);
                }
            }

            PortName_ComboBox.SelectedIndex = 0;
            RoutePosition_ComboBox.Text = "1";
            PortStatus.ForeColor = Color.Red;
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
            serialPort.DataReceived += serialPort_DataReceivedEventHandler;
            return serialPort;
        }

        private String getSelectCOMNUM()
        {
            int index = PortName_ComboBox.SelectedItem.ToString().Replace(")", "").IndexOf("COM");
            return PortName_ComboBox.SelectedItem.ToString().Replace(")", "").Substring(index);
        }

        private void OpenDangle_Btn_Click(object sender, EventArgs e)
        {
            SerialPortConfig config = new SerialPortConfig
            {

                PortName = getSelectCOMNUM(),
                BaudRate = 115200,
                DataBits = 8,
                StopBits = StopBits.One,
                ReadTimeout = 2000,
                WriteBufferSize = 1024,
                ReadBufferSize = 1024
            };
            serialPortContext = SerialPortInit(config);
            try
            {
                if (serialPortContext.IsOpen) return;
                serialPortContext.Open();
                PortStatus.ForeColor = Color.Green;
                INFO.Text = "端口已打开";
                OpenDangle_Btn.Enabled = false;
                CloseDangle_Btn.Enabled = true;
                _appendStrings = new StringBuilder();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CloseDangle_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPortContext == null) return;
                if (serialPortContext.IsOpen)
                {
                    serialPortContext.Close();
                    PortStatus.ForeColor = Color.Red;
                    INFO.Text = "端口已关闭";
                    OpenDangle_Btn.Enabled = true;
                    CloseDangle_Btn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public const String BLECONN_PATTERN = @"\A\w{13}\d[0-9a-f]{12}\r\n";

        public const String VALUERECEIVE_PATTERN = @"[#]*\r\n+\b+battery_level:\d*\r\n+\b+CSQ:\d*\r\n+\b+IMEI:\d*\r\n+\b+IMSI:\d*\r\n+\b+sensor_value:\d*\r\n+\b+warn_upper:\d*\D\s+\b+warn_lower:\d*\D\s+\b+warn_dt:\d*\r\n+\b+IOT_COM\s+\b+cmd_index:\d*\r\n";

        /// <summary>
        /// 串口数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            ReadLine((SerialPort)sender);
            int itemCount = GetDeviceList().Count;

            // Console.WriteLine("Buffer存储数据["+ _appendStrings.ToString() + "]");

            foreach (Match match in Regex.Matches(_appendStrings.ToString(), BLECONN_PATTERN))
            {
                if (match.Value.StartsWith("bleconnbyname"))
                {
                    Console.WriteLine("接收到了设备名称方式的连接");
                    _appendStrings = _appendStrings.Remove(match.Index, match.Length);
                }
                if (match.Value.StartsWith("bleconnbyaddr"))
                {
                    Console.WriteLine("设备蓝牙异常断开重连，接收到了设备地址方式的连接");
                    Console.WriteLine("设备地址为:" + match.Value.Substring(14, 12));
                    _appendStrings = _appendStrings.Remove(match.Index, match.Length);
                }
            }

            foreach (Match match in Regex.Matches(_appendStrings.ToString(), VALUERECEIVE_PATTERN))
            {
                _appendStrings = _appendStrings.Remove(match.Index, match.Length);
                Console.WriteLine("输出值*****************************************//");
                Console.WriteLine(match.Value);
            }
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



        private void PortName_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseDangle_Btn_Click(sender, e);

            INFO.Text = "当前端口选择："+ PortName_ComboBox.SelectedItem.ToString();
            OpenDangle_Btn.Enabled = true;
            CloseDangle_Btn.Enabled = false;
        }


        /// <summary>
        /// 蓝牙搜索设备限定
        /// </summary>
        /// <param name="imeiList"></param>
        private void DeviceConnectLimit(List<String> imeiList)
        {
            if (imeiList == null) return;
            int imeiCount = imeiList.Count;
            for (int i =  0; i < imeiCount; i++)
            {
                String cmd = imeiList[i].Substring(imeiList[i].Length - 4);
                String ble_cmd = "imeiset" +i+ cmd + "id";
                serialPortContext.Write(ble_cmd);
            }
            INFO.Text = "蓝牙搜索设备已限定";
            Application.DoEvents();
        }


        /// <summary>
        /// 蓝牙搜索设备清除限定
        /// </summary>
        /// <param name="imeiList"></param>
        private void DeviceConnectUnlimit(List<String> imeiList)
        {
            if (imeiList == null) return;
            try
            {
                int imeiCount = imeiList.Count;
                for (int i = 0; i < imeiCount; i++)
                {
                    String ble_cmd_1 = "imeiclr" + i + "id";
                    serialPortContext.Write(ble_cmd_1);
                }
                INFO.Text = "蓝牙连接限定已清除";
                Application.DoEvents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 蓝牙搜索
        /// </summary>
        private void BlueToothScan()
        {
            try
            {
                if (!serialPortContext.IsOpen) return;
                String START_SCAN_CMD = "tpslstsciot";
                serialPortContext.Write(START_SCAN_CMD);
                INFO.Text = "开始搜索设备";
                Application.DoEvents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 蓝牙取消搜索
        /// </summary>
        private void BlueToothScanCancel()
        {
            if (!serialPortContext.IsOpen) return;
            String ble_cmd_1 = "tpslspsciot";
            try
            {
                serialPortContext.Write(ble_cmd_1);
                INFO.Text = "蓝牙搜索断开";
                Application.DoEvents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 获取数据值
        /// </summary>
        private void GetDeviceValue()
        {
            if (!serialPortContext.IsOpen)
            {
                MessageBox.Show("端口未打开");
            }
            String ble_cmd = "tpslgetdiot";
            _appendStrings.Clear();
            serialPortContext.Write(ble_cmd);
        }


        /// <summary>
        /// 获取即将校准设备列表
        /// </summary>
        /// <returns></returns>
        private List<String> GetDeviceList()
        {
            List<String> str = new List<String>();
            if (Imei_1_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_1_TextBox.Text);
            }
            if (Imei_2_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_2_TextBox.Text);
            }
            if (Imei_3_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_3_TextBox.Text);
            }
            if (Imei_4_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_4_TextBox.Text);
            }
            if (Imei_5_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_5_TextBox.Text);
            }
            if (Imei_6_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_6_TextBox.Text);
            }
            if (Imei_7_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_7_TextBox.Text);
            }
            if (Imei_8_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_8_TextBox.Text);
            }
            if (Imei_9_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_9_TextBox.Text);
            }
            if (Imei_10_TextBox.Text.Length >= 15)
            {
                str.Add(Imei_10_TextBox.Text);
            }

            return str;
        }

        private void DeviceLimitAndScan_Btn_Click(object sender, EventArgs e)
        {
            DeviceConnectLimit(GetDeviceList());
            BlueToothScan();
        }



        private void DeviceClean_Btn_Click(object sender, EventArgs e)
        {
            DeviceConnectUnlimit(GetDeviceList());
            BlueToothScanCancel();
        }



        private void DataReceive_Btn_Click(object sender, EventArgs e)
        {
            GetDeviceValue();
        }
    }
}
