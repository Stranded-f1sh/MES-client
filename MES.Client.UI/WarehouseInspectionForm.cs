using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Mapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class WarehouseInspectionForm : Form
    {
        private readonly LoginInfo _loginInfo; // 操作员信息
        SerialPort serialPortContext; // 打开的串口;

        private StringBuilder _appendStrings; // COM口读取数据缓存buffer

        public WarehouseInspectionForm(LoginInfo loginInfo)
        {
            InitializeComponent();
            _loginInfo = loginInfo;
        }


        private void WarehouseInspectionForm_Load(object sender, EventArgs e)
        {
            RoutePosition_ComboBox.Text = "1";
            DeviceType_ComboBox.SelectedIndex = 0;
            PortStatus.ForeColor = Color.Red;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + HardwareEnum.Win32_SerialPort);
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
            serialPort.DataReceived += SerialPort_DataReceivedEventHandler;
            return serialPort;
        }

        private String GetSelectCOMNUM()
        {
            int index = PortName_ComboBox.SelectedItem.ToString().Replace(")", "").IndexOf("COM");
            return PortName_ComboBox.SelectedItem.ToString().Replace(")", "").Substring(index);
        }

        private void OpenDangle_Btn_Click(object sender, EventArgs e)
        {
            SerialPortConfig config = new SerialPortConfig
            {

                PortName = GetSelectCOMNUM(),
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

                DeviceLimitAndScan_Btn.Enabled = true;
                DeviceClean_Btn.Enabled = true;
                DataReceive_Btn.Enabled = true;
            }
            catch (Exception ex)
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
                DeviceLimitAndScan_Btn.Enabled = false;
                DeviceClean_Btn.Enabled = false;
                DataReceive_Btn.Enabled = false;
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
        private void SerialPort_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
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

            INFO.Text = "当前端口选择：" + PortName_ComboBox.SelectedItem.ToString();
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
            for (int i = 0; i < imeiCount; i++)
            {
                String cmd = imeiList[i].Substring(imeiList[i].Length - 4);
                String ble_cmd = "imeiset" + i + cmd + "id";
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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


        private double[] GetValueArray()
        {
            var arr = new double[10];
            if (Value1_TextBox.Text != String.Empty)
            {
                arr[0] = double.Parse(Value1_TextBox.Text);
            }
            if (Value2_TextBox.Text != String.Empty)
            {
                arr[1] = double.Parse(Value2_TextBox.Text);
            }
            if (Value3_TextBox.Text != String.Empty)
            {
                arr[2] = double.Parse(Value3_TextBox.Text);
            }
            if (Value4_TextBox.Text != String.Empty)
            {
                arr[3] = double.Parse(Value4_TextBox.Text);
            }
            if (Value5_TextBox.Text != String.Empty)
            {
                arr[4] = double.Parse(Value5_TextBox.Text);
            }
            if (Value6_TextBox.Text != String.Empty)
            {
                arr[5] = double.Parse(Value6_TextBox.Text);
            }
            if (Value7_TextBox.Text != String.Empty)
            {
                arr[6] = double.Parse(Value7_TextBox.Text);
            }
            if (Value8_TextBox.Text != String.Empty)
            {
                arr[7] = double.Parse(Value8_TextBox.Text);
            }
            if (Value9_TextBox.Text != String.Empty)
            {
                arr[8] = double.Parse(Value9_TextBox.Text);
            }
            if (Value10_TextBox.Text != String.Empty)
            {
                arr[9] = double.Parse(Value10_TextBox.Text);
            }
            return arr;
        }

        /// <summary>
        /// 获取即将校准设备列表
        /// </summary>
        /// <returns></returns>
        private List<String> GetDeviceList()
        {
            List<String> str = new List<String>();

            str.Add(Imei_1_TextBox.Text);


            str.Add(Imei_2_TextBox.Text);


            str.Add(Imei_3_TextBox.Text);


            str.Add(Imei_4_TextBox.Text);


            str.Add(Imei_5_TextBox.Text);


            str.Add(Imei_6_TextBox.Text);


            str.Add(Imei_7_TextBox.Text);


            str.Add(Imei_8_TextBox.Text);


            str.Add(Imei_9_TextBox.Text);

            str.Add(Imei_10_TextBox.Text);
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
            // GetDeviceValue();

            new WarehouseInspactionService().ReportGenerate(_loginInfo, "862675059815973");
        }


        private void RefreshInspectDataToListView(JToken jTokenData)
        {
            InspactData_ListView.Items.Clear();
            var ret = jTokenData.GroupBy(x => x["imei"].ToString());
            foreach (var items in ret)
            {
                JToken item = items.OrderBy(x => x["updatetime"]).Reverse().First();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.SelectToken("imei").ToString();
                string strDate = item.SelectToken("updatetime").ToString();
                double timeVal = double.Parse(strDate);
                var time = Convert.ToDateTime(DateTime.Parse(DateTime.Now.ToString("1970-01-01 08:00:00")).AddMilliseconds(timeVal).ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                listViewItem.SubItems.Add(time);
                listViewItem.SubItems.Add(item.SelectToken("value1").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value2").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value3").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value4").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value5").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value6").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value7").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value8").ToString());
                listViewItem.SubItems.Add(item.SelectToken("value9").ToString());
                InspactData_ListView.Items.Add(listViewItem);
            }
        }


        private void DataUpon_Btn_Click(object sender, EventArgs e)
        {
            DataUpon_Btn.Enabled = false;
            WareHouseInspactValueCacheMapper mapper = new WareHouseInspactValueCacheMapper();
            mapper.CreateTableIfNotExist();
            var items = GetDeviceList();
            var values = GetValueArray();
            if (items.Count == 0) return;
            int index = 0;
            foreach (var item in items)
            {
                if (item == string.Empty)
                {
                    index++;
                    continue;
                }
                bool isDataExists = mapper.IsDataExists(item, double.Parse(RoutePosition_ComboBox.Text));
                if (isDataExists)
                {
                    mapper.ReplaceData(item, values[index], double.Parse(RoutePosition_ComboBox.Text));
                    index++;
                    continue;
                }
                mapper.InsertIntoDeviceCache(item, values[index], double.Parse(RoutePosition_ComboBox.Text), "UnCommit", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                index++;
            }
            LabelLightColorChangeGreen(RoutePosition_ComboBox);
            if ((label11.ForeColor == Color.Green) &&
                (label12.ForeColor == Color.Green) &&
                (label13.ForeColor == Color.Green) &&
                (label15.ForeColor == Color.Green) &&
                (label16.ForeColor == Color.Green) &&
                (label17.ForeColor == Color.Green) &&
                (label18.ForeColor == Color.Green) &&
                (label19.ForeColor == Color.Green) &&
                (label20.ForeColor == Color.Green))
            {
                INFO.Text = "正在上报。。。请稍后";
                Application.DoEvents();
                WarehouseInspactionService warehouseInspactionService = new WarehouseInspactionService();
                var jt = warehouseInspactionService.DataUpon(_loginInfo, mapper);

                RefreshInspectDataToListView(jt);
                RoutePosition_ComboBox.SelectedIndex = 0;
                LabelLightColorChangeRed(RoutePosition_ComboBox);
                INFO.Text = "";
                MessageBox.Show("执行完毕");
                return;
            }
            if (RoutePosition_ComboBox.SelectedIndex == 8) return;
            MessageBox.Show("数据缓存完成，自动切至下一行程");
            RoutePosition_ComboBox.SelectedIndex++;
        }


        /// <summary>
        /// x是误差值,y是标准值.输出实际值
        /// </summary>
        Func<String, double, String> _01PTransFunc;
        Func<int, double> _01PStardardPressFunc;

        private void Value1_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value2_TextBox.Focus();
            }
        }


        private void Value2_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value3_TextBox.Focus();
            }
        }

        private void Value3_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value4_TextBox.Focus();
            }
        }

        private void Value4_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value5_TextBox.Focus();
            }
        }

        private void Value5_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value6_TextBox.Focus();
            }
        }

        private void Value6_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value7_TextBox.Focus();
            }
        }

        private void Value7_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value8_TextBox.Focus();
            }
        }

        private void Value8_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value9_TextBox.Focus();
            }
        }

        private void Value9_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value10_TextBox.Focus();
            }
        }

        private void Value10_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                DelayRefresh((TextBox)sender);
                Value2_TextBox.Focus();
            }
        }

        private void DeviceType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DeviceType_ComboBox.SelectedItem.ToString())
            {
                case "01P":
                    _01PTransFunc = (x, y) => (y + double.Parse(x) * 0.0001).ToString("0.0000");
                    break;
                case "04P":
                    _01PTransFunc = (x, y) => (y + double.Parse(x) * 0.001).ToString("0.000");
                    break;
            }
            TextBoxValueClear();
            Value1_TextBox.Focus();
        }

        private void RoutePosition_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoutePosition_ComboBox.SelectedIndex < 5)
            {
                _01PStardardPressFunc = (x) => 0.5 * x;
            }
            else
            {
                _01PStardardPressFunc = (x) => 2.5 - (x - 5) * 0.5;
            }
            TextBoxValueClear();
            Value1_TextBox.Focus();
        }

        public void DelayRefresh(TextBox textBox)
        {
            new Thread(() => 
            {
                this.Invoke(new Action(
                   () =>
                   { DataUpon_Btn.Enabled = false; }));
                
                Thread.Sleep(1000);
                this.Invoke(new Action(
                    () => 
                    {
                        if (textBox.Text == string.Empty) return;
                        textBox.Text = _01PTransFunc(textBox.Text, _01PStardardPressFunc(int.Parse(RoutePosition_ComboBox.SelectedItem.ToString())));
                    }
                ));

                this.Invoke(new Action(
                   () =>
                   { 
                       DataUpon_Btn.Enabled = true; 
                   }));
            }
            ).Start();
        }



        private void TextBoxValueClear()
        {
            Value1_TextBox.Clear();
            Value2_TextBox.Clear();
            Value3_TextBox.Clear();
            Value4_TextBox.Clear();
            Value5_TextBox.Clear();
            Value6_TextBox.Clear();
            Value7_TextBox.Clear();
            Value8_TextBox.Clear();
            Value9_TextBox.Clear();
            Value10_TextBox.Clear();
        }


        private void LabelLightColorChangeGreen(ComboBox routePosition_ComboBox)
        {
            switch (routePosition_ComboBox.SelectedIndex)
            {
                case 0:
                    label11.ForeColor = Color.Green;
                    break;
                case 1:
                    label12.ForeColor = Color.Green;
                    break;
                case 2:
                    label13.ForeColor = Color.Green;
                    break;
                case 3:
                    label15.ForeColor = Color.Green;
                    break;
                case 4:
                    label16.ForeColor = Color.Green;
                    break;
                case 5:
                    label17.ForeColor = Color.Green;
                    break;
                case 6:
                    label18.ForeColor = Color.Green;
                    break;
                case 7:
                    label19.ForeColor = Color.Green;
                    break;
                case 8:
                    label20.ForeColor = Color.Green;
                    break;
            }
        }

        private void LabelLightColorChangeRed(ComboBox routePosition_ComboBox)
        {
            label11.ForeColor = Color.Red;

            label12.ForeColor = Color.Red;

            label13.ForeColor = Color.Red;

            label15.ForeColor = Color.Red;

            label16.ForeColor = Color.Red;

            label17.ForeColor = Color.Red;

            label18.ForeColor = Color.Red;

            label19.ForeColor = Color.Red;

            label20.ForeColor = Color.Red;
        }

        private void FindData_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                JObject valueRet = null;
                if (FindData_TextBox.Text.Length < 5)
                {
                    valueRet = WareHouseInspactApi.FindValueByOrderIdApi(_loginInfo, int.Parse(FindData_TextBox.Text));
                }
                else
                {
                    valueRet = WareHouseInspactApi.FindValueByImeiApi(_loginInfo, FindData_TextBox.Text);
                }
                var ret = MyJsonConverter.GetJToken(valueRet);
                RefreshInspectDataToListView(ret);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            WarehouseInspactionService warehouseInspactionService = new WarehouseInspactionService();
            warehouseInspactionService.ReportGenerate(_loginInfo, "862675059815973");
        }
    }
}