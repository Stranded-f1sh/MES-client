using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils.PCB;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class PackForm : Form
    {
        private readonly JToken _productOrders; // 缓存的所有工单
        public ProductOrder ProductOrderInfo; // 切换的工单实体类
        public SaleOrder SaleOrderInfo; // 发货客户销售单信息
        private readonly Process _process; // 所在工序
        private readonly LoginInfo _loginInfo; // 操作员信息
        private int _pageCount; // 总页数
        private int _pageNum;  // 当前页

        private Thread _dataUpLoadThread; // 缓存数据上传线程
        private static Mutex _mut; // 互斥锁
        private bool _startScan; // 为true时缓存数据上传线程开始检索缓存数据库
        private int _tipsSaleOrderId; // 选择销售单时提示的工单id

        private StringBuilder _appendStrings; // COM口读取数据缓存buffer
        private StringBuilder _appendImei1; // 扫码枪内容1缓存buffer
        private StringBuilder _appendImei2; // 扫码枪内容2缓存buffer
        private StringBuilder _appendImei3; // 扫码枪内容3缓存buffer
        private Boolean _scanner1IsSent; // 扫码枪1是否发送
        private Boolean _scanner2IsSent; // 扫码枪2是否发送
        private Boolean _scanner3IsSent; // 扫码枪2是否发送
        public SignStatusEnum signStatus;
        public SignStatusEnum lastSignStatus;


        public String Sign;

        public DateTime scannerILastSignDate;
        public DateTime scannerIILastSignDate;
        public DateTime scannerIIILastSignDate;
        public DateTime CameraLastSignDate;
        Thread ObjectDetectionFuncThread;




        public PackForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {
            _productOrders = productOrders;
            _process = process;
            _loginInfo = loginInfo;
            
            InitializeComponent();

            User_Label.Text = _loginInfo.User ?? String.Empty;
        }


        private void PackForm_Load(object sender, EventArgs e)
        {
             _dataUpLoadThread = new Thread(ThreadCache);
            if (_dataUpLoadThread.ThreadState != ThreadState.Running)
            {
                _dataUpLoadThread.Start();
            }

            _mut = new Mutex();

            
        }


        private void LoadSaleOrders_btn_Click(object sender, EventArgs e)
        {
            SaleOrderInfo = new SaleOrder();
            SaleOrdersSelectionForm saleOrdersSelectionForm = new SaleOrdersSelectionForm(_process, _loginInfo)
            {
                Owner = this,
                Text = @"请选择即将发货设备对应的客户销售订单"
            };
            saleOrdersSelectionForm.ShowDialog();

            SelectSaleOrder(SaleOrderInfo);
            // if (ProductOrderInfo != null) return;
            if (SaleOrderInfo?.Id == 0) return;

            if (MessageBox.Show(@"是否显示对应工单报工信息？", "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            _tipsSaleOrderId = SaleOrderInfo.Id;
            OrderSelect_Btn_Click(sender, e);
        }


        private void OrderSelect_Btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrder();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders, _process, _tipsSaleOrderId)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();
            _pageNum = 1;
            SelectProductOrder(ProductOrderInfo, 100);
            Imei_TextBox?.Focus();
        }


        #region 发货客户销售单
        
        private void SelectSaleOrder(SaleOrder soi)
        {
            if (soi.OrderNo == null) return;
            SaleOrderNo_TextBox.Text = soi.OrderNo;
            CompanyFullName_TextBox.Text = soi.CompanyFullName;
            DeviceModel_TextBox.Text = soi.CustomerDeviceModel;
            BuyNumber_TextBox.Text = soi.BuyNumber.ToString();
        }
        
        #endregion

        
        
        #region 工单查询
        
        
        private void SelectProductOrder(ProductOrder poi, int pageSize)
        {
            if (poi?.OrderNo == null) return;
            // INFO.Text = @"刷新中.......";
            Application.DoEvents();

            SaleOrderService saleOrderService = new SaleOrderService();

            JToken saleOrderInfo = saleOrderService.GetSaleOrderInfo(_loginInfo, poi.SaleOrderId.ToString());
            SaleOrder saleOrder = saleOrderService.SetSaleOrderInfo(saleOrderInfo);

            ProductOrderService productOrderService = new ProductOrderService();

            JToken productDeviceRecord;

            if (pageSize == -1)
            {
                productDeviceRecord = productOrderService.GetProductDeviceRecord(
                            _loginInfo,
                            poi.OrderId.ToString(),
                            ((int)_process.SelectedProcessName).ToString()
                            );
            }
            else
            {
                productDeviceRecord = productOrderService.GetProductDeviceRecord(
                            _loginInfo,
                            poi.OrderId.ToString(),
                            ((int)_process.SelectedProcessName).ToString(),
                            pageSize,
                            _pageNum
                            );
            }

            if (productDeviceRecord == null) return;

            PackNum_TextBox.Text = productDeviceRecord?.SelectToken("count")?.ToString();

            _pageCount = (int)Math.Ceiling(double.Parse(productDeviceRecord?.SelectToken("count")?.ToString() ?? String.Empty) / pageSize);

            if (pageSize == -1)
            {
                _pageCount = 1;
                _pageNum = 1;
            }

            InitInfoTable();
            UpdateTable(productDeviceRecord, saleOrder);
            INFO.Text = String.Empty;
        }

        #endregion

        
        
        #region SetColumns

        private void InitInfoTable()
        {
            if (BaoGongDeviceList == null) return;
            BaoGongDeviceList.Rows.Clear();
            BaoGongDeviceList.Columns.Clear();
            BaoGongDeviceList.Columns.Add("index", "序号");
            BaoGongDeviceList.Columns[0].Width = 30;
            BaoGongDeviceList.Columns.Add("orderNo", "产品名称");
            BaoGongDeviceList.Columns[1].Width = 150;
            BaoGongDeviceList.Columns.Add("saleOrderid", "产品型号");
            BaoGongDeviceList.Columns[2].Width = 80;
            BaoGongDeviceList.Columns.Add("companyFullName", "量程");
            BaoGongDeviceList.Columns[3].Width = 10;
            BaoGongDeviceList.Columns.Add("deviceModel", "设备号（IMEI）");
            BaoGongDeviceList.Columns[4].Width = 150;
            BaoGongDeviceList.Columns.Add("imsi", "IMSI");
            BaoGongDeviceList.Columns[5].Width = 130;
            BaoGongDeviceList.Columns.Add("SIMType", "SIM类型");
            BaoGongDeviceList.Columns[6].Width = 80;
            BaoGongDeviceList.Columns.Add("Remarks", "备注");
            BaoGongDeviceList.Columns[7].Width = 10;
            BaoGongDeviceList.Columns.Add("userName", "注册平台");
            BaoGongDeviceList.Columns[8].Width = 80;
            BaoGongDeviceList.Columns.Add("platform", "平台类型");
            BaoGongDeviceList.Columns[9].Width = 80;
            BaoGongDeviceList.Columns.Add("handleResult", "注册状态");
            BaoGongDeviceList.Columns[10].Width = 80;
            BaoGongDeviceList.Columns.Add("status", "在线状态");
            BaoGongDeviceList.Columns[11].Width = 80;
            BaoGongDeviceList.Columns.Add("mUserName", "操作员");
            BaoGongDeviceList.Columns[12].Width = 70;
            BaoGongDeviceList.Columns.Add("startTime", "录入时间");
            BaoGongDeviceList.Columns[13].Width = 80;
            BaoGongDeviceList.Columns.Add("onlineTime", "数据上报时间");
            BaoGongDeviceList.Columns[14].Width = 70;
            BaoGongDeviceList.Columns.Add("value", "数据值");
            BaoGongDeviceList.Columns[15].Width = 70;
            BaoGongDeviceList.Columns.Add("ICCID", "ICCID");
            BaoGongDeviceList.Columns[16].Width = 10;


            NextPage_Btn.Enabled = _pageCount != _pageNum;

            BackPage_Btn.Enabled = _pageNum != 1;

            PageNum_Label.Text = _pageNum.ToString();

            // 设置自动列宽
            BaoGongDeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            BaoGongDeviceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            // 设置字体样式
            Font font = new Font("宋体", 9);
            BaoGongDeviceList.Font = font;

            //设置文本居中
            BaoGongDeviceList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Type dgvType = BaoGongDeviceList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(this.BaoGongDeviceList, true, null);
        }


        #endregion



        #region 刷新设备列表数据

        private void UpdateTable(JToken productDeviceRecord, SaleOrder saleOrder)
        {
            if (productDeviceRecord?.SelectToken("list") == null) return;
            if (BaoGongDeviceList == null) return;
            if (saleOrder == null) return;

            DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);

            foreach (var i in productDeviceRecord.SelectToken("list") ?? String.Empty)
            {
                int index = BaoGongDeviceList.Rows.Add();



                if (BaoGongDeviceList.Rows[index].Cells[0] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[0].Value = MyJsonConverter.JTokenTransformer((_pageNum - 1) * 100 + index + 1);
                }

                if (BaoGongDeviceList.Rows[index].Cells[1] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[1].Value = saleOrder.CustomerDeviceName;
                }

                if (BaoGongDeviceList.Rows[index].Cells[2] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[2].Value = saleOrder.CustomerDeviceModel;
                }

                if (BaoGongDeviceList.Rows[index].Cells[3] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[3].Value = saleOrder.DefaultConfig;
                }

                if (BaoGongDeviceList.Rows[index].Cells[4] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[4].Value = MyJsonConverter.JTokenTransformer(i["imei"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[5] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[5].Value = MyJsonConverter.JTokenTransformer(i["imsi"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[6] != null)
                {
                    string imsi = MyJsonConverter.JTokenTransformer(i["imsi"]);

                    // SIM卡类型
                    if (imsi != "" && imsi.Length > 4)
                    {
                        if ("4600" == imsi.Substring(0, 4))
                        {
                            BaoGongDeviceList.Rows[index].Cells[6].Value = "移动";
                        }
                        else if ("4601" == imsi.Substring(0, 4))
                        {
                            BaoGongDeviceList.Rows[index].Cells[6].Value = "电信";
                        }
                        else
                        {
                            BaoGongDeviceList.Rows[index].Cells[6].Value = "未刷新";
                        }
                    }
                    else
                    {
                        BaoGongDeviceList.Rows[index].Cells[6].Value = "未刷新";
                    }
                }

                if (BaoGongDeviceList.Rows[index].Cells[7] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[7].Value = "";
                }

                if (BaoGongDeviceList.Rows[index].Cells[8] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[8].Value = MyJsonConverter.JTokenTransformer(i["userName"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[9] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[9].Value = MyJsonConverter.JTokenTransformer(i["platform"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[10] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[10].Value = MyJsonConverter.JTokenTransformer(i["handleResult"]);
                }

                // status
                var status = MyJsonConverter.JTokenTransformer(i["status"]);
                if (status == "0")
                {
                    BaoGongDeviceList.Rows[index].Cells[11].Value = "离线";
                }
                else if (status == "1")
                {
                    BaoGongDeviceList.Rows[index].Cells[11].Value = "在线";
                }
                else
                {
                    BaoGongDeviceList.Rows[index].Cells[11].Value = "未上报数据";
                }

                if (BaoGongDeviceList.Rows[index].Cells[12] != null)
                {
                    foreach (var itm in _loginInfo.UserList)
                    {
                        if (itm?["userId"]?.ToString() == MyJsonConverter.JTokenTransformer(i["userId"]))
                        {
                            BaoGongDeviceList.Rows[index].Cells[12].Value = itm?["username"]?.ToString();
                            break;
                        }
                    }
                }

                if (BaoGongDeviceList.Rows[index].Cells[13] != null)
                {
                    var time = MyJsonConverter.JTokenTransformer(i["startTime"]);
                    if (time.Length == 0)
                    {
                        time = "0";
                    }
                    var startTime = dtStart.AddMilliseconds(Convert.ToInt64(time));
                    BaoGongDeviceList.Rows[index].Cells[13].Value = startTime.ToString("yyyy-MM-dd HH:mm:ss:f");
                }

                if (BaoGongDeviceList.Rows[index].Cells[14] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[14].Value = MyJsonConverter.JTokenTransformer(i["onlineTime"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[15] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[15].Value = MyJsonConverter.JTokenTransformer(i["value"]);
                }

                if (BaoGongDeviceList.Rows[index].Cells[16] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[16].Value = MyJsonConverter.JTokenTransformer(i["iccid"]);
                }
            }
        }

        #endregion



        private void BackPage_Btn_Click(object sender, EventArgs e)
        {
            _pageNum -= 1;
            SelectProductOrder(ProductOrderInfo, 100);
        }


        
        private void NextPage_Btn_Click(object sender, EventArgs e)
        {
            _pageNum += 1;
            SelectProductOrder(ProductOrderInfo, 100);
        }


        
        private void Imei_TextBox_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            eventArgs.Handled = true;
            _startScan = false;

            DataCacheService dataCacheService = new DataCacheService();
            CodeScanHelper codeScanHelper = new CodeScanHelper();
            string imei = codeScanHelper.CodeScanFilter(Imei_TextBox?.Text, out String pinDian);

            if (imei == null) return;

            if (checkBox3.Checked)
            {
                _mut?.WaitOne();

                int cacheResult = dataCacheService.DeviceCache(imei, _loginInfo.userId, _process.SelectedProcessName, SubmitStatus.UnCommit);

                _mut?.ReleaseMutex();

                _startScan = cacheResult == 1;
            }
            else if (checkBox4.Checked)
            {
                dataCacheService.DeviceCache(
                    imei,
                    0,
                    String.Empty,
                    _loginInfo.userId,
                    _process.SelectedProcessName,
                    SubmitStatus.UnCommit
                );
            }
            Imei_TextBox.Clear();
        }



        #region 缓存报工

        private void ThreadCache()
        {
            DataCacheService dataCacheService = new DataCacheService();
            BaoGongService baoGongService = new BaoGongService();
            CodeScanHelper codeScanHelper = new CodeScanHelper();

            while (true)
            {
                Application.DoEvents();
                if (!_startScan)
                {
                    Thread.Sleep(200);
                    continue;
                }

                DataSet ds = dataCacheService.FindUnUploadDataRecord();
                BackProcessSelection.Name = "数据缓存(" + ds.Tables[0].Rows.Count + ")";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    String context = dr[1].ToString().Replace("\r", "");
                    JToken ret = baoGongService.DeviceBaoGong(_loginInfo,
                        context,
                        (ProcessNameEnum)Enum.ToObject(typeof(ProcessNameEnum), int.Parse(dr[6].ToString())), dr[10]?.ToString());

                    LogInfoHelper _logger = new LogInfoHelper();

                    _logger.printLog("小箱单报工info："+ context + "\r\n" + ret + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);

                    if ("ok" == ret?.ToString())
                    {
                        _mut?.WaitOne(); //安全时才可以访问共享资源，否则挂起。检测到安全并访问的同时会上锁。

                        int updateRet = dataCacheService.UpdateDeviceSubmitStatusById(int.Parse(dr[0].ToString()));

                        if (updateRet != 1)
                        {
                            MessageBox.Show(@"未成功更新缓存数据库");
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                INFO.Text = @"设备" + dr[1] + @"报工成功";
                            }));
                        }

                        // 打印小箱单
                        if (isPrint_CheckBox.Checked)
                        {
                            string imei = codeScanHelper.CodeScanFilter(context, out _);

                            codeScanHelper.PreviewSmallPackList(new Device { Imei = imei }, SaleOrderInfo, "packlist.frx");
                        }

                        MediaHandler.SyncPlayWAV_Succ();
                        _mut?.ReleaseMutex(); //释放锁
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            INFO.Text = @"设备" + dr[1] + @"报工失败";
                        }));
                        MediaHandler.SyncPlayWAV_Fail();
                    }
                }
                _startScan = false;

                Invoke(new Action(() =>
                {
                    if (ProductOrderInfo != null)
                    {
                        SelectProductOrder(ProductOrderInfo, 100);
                    }
                }));
            }
        }

        #endregion



        private void Exit_Form_Click(object sender, EventArgs e)
        {
            _dataUpLoadThread?.Abort();
            Close();
            Environment.Exit(Environment.ExitCode);
        }



        private void DBCache_Button_Click(object sender, EventArgs e)
        {
            SqLiteDataBaseOperateForm sqLiteDataBaseOperateForm = new SqLiteDataBaseOperateForm();
            new Thread(delegate () { sqLiteDataBaseOperateForm.ShowDialog(); }).Start();
        }



        private void Setting_Button_Click(object sender, EventArgs e)
        {
            PrinterSettingsForm printerSettings = new PrinterSettingsForm();
            printerSettings.ShowDialog();
        }



#region 下位机PLC通讯


        private static SerialPort Initialize_RS485_IO(SerialPortConfig serialPortConfig)
        {
            if (serialPortConfig == null) return null;
            SerialPort serialPort = new SerialPort
            {
                PortName = serialPortConfig.PortName,
                BaudRate = serialPortConfig.BaudRate,
                DataBits = serialPortConfig.DataBits,
                ReadTimeout = serialPortConfig.ReadTimeout,
                WriteBufferSize = serialPortConfig.WriteBufferSize,
                ReadBufferSize = serialPortConfig.ReadBufferSize,
                StopBits = serialPortConfig.StopBits,
                Parity = serialPortConfig.Parity,
                Encoding = Encoding.Unicode,
                RtsEnable = true,  //启用请求发送信号
                DtrEnable = true, //启用控制终端就续信号
                ReceivedBytesThreshold = serialPortConfig.ReceivedBytesThreshold
            };

            return serialPort;
        }


        #region readLine

        /*
        *  Get String From readBuffer
        */
        private void DeviceReadLine(SerialPort serialPort)
        {
            if (serialPort == null) return;
            if (!serialPort.IsOpen) return;
            if (_appendStrings == null) return;


            int bytes = serialPort.BytesToRead;

            byte[] readBuffer = new byte[bytes];

            int count = serialPort.Read(readBuffer, 0, readBuffer.Length);

            if (count <= 0) return;

            StringBuilder sb = new StringBuilder();

            foreach (byte b in readBuffer)
            {
                //{0:X2} 大写方式
                sb.AppendFormat("{0:x2}", b);
            }

            _appendStrings.Append(sb);
        }



        /*
         *  Get String From readBuffer
         */
        private void Imei1ReadLine(SerialPort serialPort)
        {
            
            if (serialPort == null) return;
            if (!serialPort.IsOpen) return;
            if (_appendImei1 == null) return;

            int bytes = serialPort.BytesToRead;

            byte[] readBuffer = new byte[bytes];

            int count = serialPort.Read(readBuffer, 0, readBuffer.Length);

            if (count <= 0) return;


            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            string strCharacter = asciiEncoding.GetString(readBuffer);
            _appendImei1.Append(strCharacter);
            if (strCharacter.Contains("\r") | _appendImei1.Length >= 15)
            {
                _scanner1IsSent = true;
            }
        }



       /*
         *  Get String From readBuffer
         */
        private void Imei2ReadLine(SerialPort serialPort)
        {

            if (serialPort == null) return;
            if (!serialPort.IsOpen) return;
            if (_appendImei2 == null ) return;

            int bytes = serialPort.BytesToRead;

            byte[] readBuffer = new byte[bytes];

            int count = serialPort.Read(readBuffer, 0, readBuffer.Length);

            if (count <= 0) return;


            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            string strCharacter = asciiEncoding.GetString(readBuffer);

            if (strCharacter.Contains("\r"))
            {
                _scanner2IsSent = true;
            }
            _appendImei2.Append(strCharacter);
        }



        /*
          *  Get String From readBuffer
          */
        private void Imei3ReadLine(SerialPort serialPort)
        {

            if (serialPort == null) return;
            if (!serialPort.IsOpen) return;
            if (_appendImei3 == null) return;

            int bytes = serialPort.BytesToRead;

            byte[] readBuffer = new byte[bytes];

            int count = serialPort.Read(readBuffer, 0, readBuffer.Length);

            if (count <= 0) return;


            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            string strCharacter = asciiEncoding.GetString(readBuffer);

            if (strCharacter.Contains("\r"))
            {
                _scanner3IsSent = true;
            }
            _appendImei3.Append(strCharacter);
        }

        #endregion


        #region serialPortReceivedEventHandler

        /*
         * Port Data Receive Event
         */
        private void devicePort_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            DeviceReadLine((SerialPort)sender);
        }


        /*
         * Port Data Receive Event
          */
        private void scannerPort1_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Imei1ReadLine((SerialPort)sender);
        }


       /*
         * Port Data Receive Event
         */
        private void scannerPort2_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Imei2ReadLine((SerialPort)sender);
        }


        /*
          * Port Data Receive Event
          */
        private void scannerPort3_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Imei3ReadLine((SerialPort)sender);
        }
        #endregion


        #region openPort



        private Boolean OpenPort(SerialPort serialPort, SerialDataReceivedEventHandler handler)
        {
            if (serialPort == null) return false;
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            serialPort.DataReceived += handler;

            return true;
        }

        #endregion


        private void PLC_Communication_Button_Click(object sender, EventArgs e)
        {
            #region portConfig

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            #region 设备通讯
            SerialPortConfig devicePortConfig = new SerialPortConfig
            {
                PortName = config.AppSettings.Settings["devicePortConfig"].Value,
                BaudRate = 9600,
                DataBits = 8,
                ReadTimeout = 2000,
                WriteBufferSize = 2048,
                ReadBufferSize = 40480,
                StopBits = StopBits.One,
                Parity = Parity.None,
                ReceivedBytesThreshold = 1
            };

            SerialPort devicePort = Initialize_RS485_IO(devicePortConfig);

            #endregion


            #region 扫码枪1通讯
            SerialPortConfig scannerPortConfig1 = new SerialPortConfig
            {
                PortName = config.AppSettings.Settings["scanner1PortName"].Value,
                BaudRate = 9600,
                DataBits = 8,
                ReadTimeout = 2000,
                WriteBufferSize = 2048,
                ReadBufferSize = 40480,
                StopBits = StopBits.One,
                Parity = Parity.None,
                ReceivedBytesThreshold = 1
            };

            SerialPort scannerPort1 = Initialize_RS485_IO(scannerPortConfig1);
            #endregion


            #region 扫码枪2通讯
            SerialPortConfig scannerPortConfig2 = new SerialPortConfig
            {
                PortName = config.AppSettings.Settings["scanner2PortName"].Value,
                BaudRate = 9600,
                DataBits = 8,
                ReadTimeout = 2000,
                WriteBufferSize = 2048,
                ReadBufferSize = 40480,
                StopBits = StopBits.One,
                Parity = Parity.None,
                ReceivedBytesThreshold = 1
            };

            SerialPort scannerPort2 = Initialize_RS485_IO(scannerPortConfig2);
            #endregion


            #region 扫码枪3通讯
            SerialPortConfig scannerPortConfig3 = new SerialPortConfig
            {
                PortName = config.AppSettings.Settings["scanner3PortName"].Value,
                BaudRate = 9600,
                DataBits = 8,
                ReadTimeout = 2000,
                WriteBufferSize = 2048,
                ReadBufferSize = 40480,
                StopBits = StopBits.One,
                Parity = Parity.None,
                ReceivedBytesThreshold = 1
            };

            SerialPort scannerPort3 = Initialize_RS485_IO(scannerPortConfig3);

            #endregion

            #endregion

            new Thread(() =>
            {
                try
                {
                    Boolean deviceIsOpen = OpenPort(devicePort, devicePort_DataReceivedEventHandler);
                    Boolean scanner1IsOpen = OpenPort(scannerPort1, scannerPort1_DataReceivedEventHandler);
                    Boolean scanner2IsOpen = OpenPort(scannerPort2, scannerPort2_DataReceivedEventHandler);
                    Boolean scanner3IsOpen = OpenPort(scannerPort3, scannerPort3_DataReceivedEventHandler);
                    Application.DoEvents();
                    if (!deviceIsOpen | !scanner1IsOpen | !scanner2IsOpen | !scanner3IsOpen)
                    {
                        INFO.Text = @"端口开启失败";
                        return;
                    }
                    else
                    {
                        INFO.Text = @"端口开启成功";
                    }
                    _appendStrings = new StringBuilder();
                    _appendImei1 = new StringBuilder();
                    _appendImei2 = new StringBuilder();
                    _appendImei3 = new StringBuilder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    AutoPackProgramRun(devicePort, scannerPort1, scannerPort2, scannerPort3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }).Start();


            // objectDetection

            new Thread(delegate () { cameraApplication.ShowDialog(); ObjectDetectionFuncThread?.Abort(); }).Start();
            ObjectDetectionFuncExcute();
        }
        CameraApplication cameraApplication = new CameraApplication();



        #region 判断接收的数据是否符合规范


        public static bool TimeTest(DateTime lastTime)
        {
            DateTime nowTime = DateTime.Now;

            if (nowTime.Subtract(lastTime).TotalSeconds > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // ==============================判断接收的数据是否符合规范=================================
        private void IsReceivedCorrectPcbData(SerialPort serialPort)
        {
            _appendStrings.Clear();

            try
            {
                serialPort?.Write(CommandDefinition.XReadDI ?? Array.Empty<byte>(), 0, 8);
            }catch(Exception ex)
            {
                INFO.Text = "IsReceivedCorrectPcbData" + ex.Message;
                // Console.WriteLine(ex.Message);
                while(!OpenPort(serialPort, devicePort_DataReceivedEventHandler))
                {
                    Thread.Sleep(100);
                    INFO.Text = "IsReceivedCorrectPcbData" + ex.Message;
                }

                serialPort?.Write(CommandDefinition.XReadDI ?? Array.Empty<byte>(), 0, 8);
                // Sign = "";
                // return;
            }
            
            Thread.Sleep(500);
            if (_appendStrings.Length < 14) return;
            string data = _appendStrings.ToString();
            // data = "010304000000023BF3";
            data = data.Replace("\r", String.Empty);
            data = data.Replace("\n", String.Empty);

            if (data.StartsWith("010304") && data.Length == 18)
            {

            }
            else if (data.Contains("010304") && data.Length > 18)
            {
                int dataStartIndex = data.IndexOf("010304");
                data = data.Substring(dataStartIndex, 18);
            }
            else
            {
                signStatus = SignStatusEnum.None;
            }

            switch(data.Substring(12, 2))
            {
                case "01":
                    if (TimeTest(scannerILastSignDate))
                    {
                        Sign = "1";
                        scannerILastSignDate = DateTime.Now;
                        break;
                    }
                    Sign = "";
                    break;
                case "08":
                    if (TimeTest(scannerIILastSignDate))
                    {
                        Sign = "2";
                        scannerIILastSignDate = DateTime.Now;
                        break;
                    }
                    Sign = "";
                    break;
                case "02":
                    if (TimeTest(CameraLastSignDate))
                    {
                        // MessageBox.Show("================================进了02");
                        Sign = "3";
                        CameraLastSignDate = DateTime.Now;
                        break;
                    }
                    Sign = "";
                    break;
                case "09":
                    Sign = "12";

                    if (!TimeTest(scannerILastSignDate))
                    {
                        Sign = Sign.Replace("1", "");
                    }
                    else
                    {
                        scannerILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(scannerIILastSignDate))
                    {
                        Sign = Sign.Replace("2", "");
                    }
                    else
                    {
                        scannerIILastSignDate = DateTime.Now;
                    }
                    break;
                case "0b":
                    Sign = "123";

                    if (!TimeTest(scannerILastSignDate))
                    {
                        Sign = Sign.Replace("1", "");
                    }
                    else
                    {
                        scannerILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(scannerIILastSignDate))
                    {
                        Sign = Sign.Replace("2", "");
                    }
                    else
                    {
                        scannerIILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(CameraLastSignDate))
                    {
                        Sign = Sign.Replace("3", "");
                    }
                    else
                    {
                        CameraLastSignDate = DateTime.Now;
                    }
                    break;
                case "0a":
                    Sign = "23";

                    if (!TimeTest(scannerILastSignDate))
                    {
                        Sign = Sign.Replace("2", "");
                    }
                    else
                    {
                        scannerILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(CameraLastSignDate))
                    {
                        Sign = Sign.Replace("3", "");
                    }
                    else
                    {
                        CameraLastSignDate = DateTime.Now;
                    }
                    break;
                case "03":
                    Sign = "13";

                    if (!TimeTest(scannerILastSignDate))
                    {
                        Sign = Sign.Replace("1", "");
                    }
                    else
                    {
                        scannerILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(CameraLastSignDate))
                    {
                        Sign = Sign.Replace("3", "");
                    }
                    else
                    {
                        CameraLastSignDate = DateTime.Now;
                    }
                    break;
                case "00":
                    Sign = "";
                    scannerILastSignDate = new DateTime(0001, 1, 1, 0, 00, 00);
                    scannerIILastSignDate = new DateTime(0001, 1, 1, 0, 00, 00);
                    scannerIIILastSignDate = new DateTime(0001, 1, 1, 0, 00, 00);
                    CameraLastSignDate = new DateTime(0001, 1, 1, 0, 00, 00);
                    break;
                case "20":
                    if (TimeTest(scannerIIILastSignDate))
                    {
                        Sign = "4";
                        scannerIIILastSignDate = DateTime.Now;
                        break;
                    }
                    Sign = "";
                    break;
                case "28":
                    Sign = "42";

                    if (!TimeTest(scannerIIILastSignDate))
                    {
                        Sign = Sign.Replace("4", "");
                    }
                    else
                    {
                        scannerIIILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(scannerIILastSignDate))
                    {
                        Sign = Sign.Replace("2", "");
                    }
                    else
                    {
                        scannerIILastSignDate = DateTime.Now;
                    }
                    break;
                case "2a":
                    Sign = "423";

                    if (!TimeTest(scannerIIILastSignDate))
                    {
                        Sign = Sign.Replace("4", "");
                    }
                    else
                    {
                        scannerIIILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(scannerIILastSignDate))
                    {
                        Sign = Sign.Replace("2", "");
                    }
                    else
                    {
                        scannerIILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(CameraLastSignDate))
                    {
                        Sign = Sign.Replace("3", "");
                    }
                    else
                    {
                        CameraLastSignDate = DateTime.Now;
                    }
                    break;
                case "22":
                    Sign = "43";

                    if (!TimeTest(scannerIIILastSignDate))
                    {
                        Sign = Sign.Replace("4", "");
                    }
                    else
                    {
                        scannerIIILastSignDate = DateTime.Now;
                    }

                    if (!TimeTest(CameraLastSignDate))
                    {
                        Sign = Sign.Replace("3", "");
                    }
                    else
                    {
                        CameraLastSignDate = DateTime.Now;
                    }
                    break;
            }
        }



        private Boolean IsScanner1ReceivedCorrectScanData(SerialPort serialPort, byte[] xInput)
        {
            //int reTriedTimes = 0;
            _scanner1IsSent = false;
            do
            {
                _appendImei1?.Clear();
                //reTriedTimes++;
                //if (reTriedTimes > 5) return false;
                try
                {
                    serialPort?.Write(xInput ?? Array.Empty<byte>(), 0, 7);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    INFO.Text = "IsScanner1ReceivedCorrectScanData" + ex.Message;
                    if (serialPort != null)
                    {
                        OpenPort(serialPort, scannerPort1_DataReceivedEventHandler);
                    }

                    Console.WriteLine(ex.Message);
                }
                
                Thread.Sleep(1000);
            } while (!_scanner1IsSent);

            return true;
        }


        private Boolean IsScanner2ReceivedCorrectScanData(SerialPort serialPort, byte[] xInput)
        {
            int reTriedTimes = 0;
            _scanner2IsSent = false;
            do
            {
                reTriedTimes++;
                if (reTriedTimes > 10) return false;
                _appendImei2?.Clear();
                try
                {
                    serialPort?.Write(xInput ?? Array.Empty<byte>(), 0, 7);
                }
                catch (Exception ex)
                {
                    INFO.Text = "IsScanner2ReceivedCorrectScanData" + ex.Message;
                    if (serialPort != null)
                    {
                        OpenPort(serialPort, scannerPort1_DataReceivedEventHandler);
                    }
                    // Console.WriteLine(ex.Message);
                }
                
                Thread.Sleep(1000);
            } while (!_scanner2IsSent);

            return true;
        }


        private Boolean IsScanner3ReceivedCorrectScanData(SerialPort serialPort, byte[] xInput)
        {
            //int reTriedTimes = 0;
            _scanner3IsSent = false;
            do
            {
                _appendImei3?.Clear();
                //reTriedTimes++;
                //if (reTriedTimes > 5) return false;
                try
                {
                    serialPort?.Write(xInput ?? Array.Empty<byte>(), 0, 7);
                }
                catch (Exception ex)
                {
                    INFO.Text = "IsScanner3ReceivedCorrectScanData" + ex.Message;
                    if (serialPort != null)
                    {
                        OpenPort(serialPort, scannerPort3_DataReceivedEventHandler);
                    }

                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(1000);
            } while (!_scanner3IsSent);

            return true;
        }

        // ==============================判断接收的数据是否符合规范=================================
        #endregion


        CatalogItemList catalogItemList;
        private void AutoPackProgramRun(SerialPort devicePort, SerialPort scannerPort1, SerialPort scannerPort2, SerialPort scannerPort3)
        {
            while (true)
            {
                Application.DoEvents();
                Sign = "";
                IsReceivedCorrectPcbData(devicePort);
                INFO.Text = "_appendStrings的值是{" + _appendStrings + "}并且信号是" + Sign;
                Thread.Sleep(500);

                if (Sign.Contains("1"))
                {
                    ScannerIFuncExcute(devicePort, scannerPort1);
                }
                if (Sign.Contains("4"))
                {
                    ScannerIIIFuncExcute(devicePort, scannerPort3);
                }
                if (Sign.Contains("2"))
                {
                    ScannerIIFuncExcute(scannerPort2);
                }
                if (Sign.Contains("3"))
                {
                    CameraFuncExcute(devicePort);
                }

                if (catalogItemList?.catalogItemList != null)
                {
                    bool detectionRes = false;
                    var items = catalogItemList.catalogItemList.GetEnumerator();
                    while (items.MoveNext())
                    {
                        if (items.Current.Name == "certificate")
                        {
                            detectionRes = true;
                            // MessageBox.Show(items.Current.id + " " + items.Current.Name + " " + items.Current.Score);
                            INFO.Text = items.Current.id + " " + items.Current.Name + " " + items.Current.Score;
                            try
                            {
                                // MessageBox.Show("准备发N6");
                                devicePort?.Write(CommandDefinition.N6Connect ?? Array.Empty<byte>(), 0, 8);
                                Thread.Sleep(2000);
                                devicePort?.Write(CommandDefinition.N6DisConnect ?? Array.Empty<byte>(), 0, 8);
                            }
                            catch
                            {
                                try
                                {
                                    // MessageBox.Show("N6 exception");
                                    Boolean deviceIsOpen = OpenPort(devicePort, devicePort_DataReceivedEventHandler);
                                    devicePort?.Write(CommandDefinition.N6DisConnect ?? Array.Empty<byte>(), 0, 8);
                                }
                                catch (Exception exc)
                                {
                                    INFO.Text = exc.Message;
                                }
                            }
                            INFO.Text = "发送N6完成";
                            break;
                        }
                    }
                    catalogItemList.catalogItemList = null;
                    if (detectionRes == false)
                    {
                        INFO.Text = "检测完成，未检测到目标合格证";
                        Thread.Sleep(1000);
                        CameraFuncExcute(devicePort);
                    }
                }
            }
        }




        #region 扫码枪1调用方法
        public void ScannerIFuncExcute(SerialPort devicePort, SerialPort scannerPort1)
        {
            INFO.Text = @"收到皮带传送表到位信号，发送扫码指令";
            IsScanner1ReceivedCorrectScanData(scannerPort1, CommandDefinition.ScannerScanCode);
            INFO.Text = "收到" + _appendImei1.ToString() + "并发送N5";
            devicePort?.Write(CommandDefinition.N5Connect ?? Array.Empty<byte>(), 0, 8);
            Thread.Sleep(2000);
            devicePort?.Write(CommandDefinition.N5DisConnect ?? Array.Empty<byte>(), 0, 8);
            INFO.Text = "N5发送结束，并缓存报工打印";
            DataCacheService dataCacheService = new DataCacheService();
            String imei1;
            imei1 = _appendImei1.ToString();
            imei1 = imei1.Replace("\r", "");
            imei1 = imei1.Replace("\n", "");
            int cacheResult = dataCacheService.DeviceCache(imei1, _loginInfo.userId, _process.SelectedProcessName, SubmitStatus.UnCommit);
            _startScan = cacheResult == 1;
        }
        #endregion


        #region 扫码枪2调用方法
        public void ScannerIIFuncExcute(SerialPort scannerPort2)
        {
            INFO.Text = @"收到机械臂到位信号，发送扫码指令";
            bool ret = IsScanner2ReceivedCorrectScanData(scannerPort2, CommandDefinition.ScannerScanCode);
            if (!ret)
            {
                INFO.Text = @"未识别到内容";
                return;
            }
            String imei1;
            String imei2;
            imei1 = _appendImei1.ToString();
            imei1 = imei1.Replace("\r", "");
            imei1 = imei1.Replace("\n", "");

            imei2 = _appendImei2.ToString();
            imei2 = imei2.Replace("\r", "");
            imei2 = imei2.Replace("\n", "");


            if (imei2.Contains(imei1) | imei1.Contains(imei2))
            {
                INFO.Text = @"信息比对成功一致";
                MediaHandler.SyncPlayWAV_Succ();
            }
            else
            {
                MessageBox.Show(imei1 + @"信息比对失败" + imei2);
            }
        }
        #endregion


        #region 相机调用方法
        public void CameraFuncExcute(SerialPort devicePort)
        {
            INFO.Text = @"收到调用相机指令";
            cameraApplication.btn_SaveAsBmp_Click(null, null);
            //Thread.Sleep(5000);
            //INFO.Text = "准备发送N6";
        }
        #endregion


        #region 扫码枪3调用方法
        public void ScannerIIIFuncExcute(SerialPort devicePort, SerialPort scannerPort3)
        {
            INFO.Text = @"收到皮带传送表到位信号，发送扫码指令";
            IsScanner3ReceivedCorrectScanData(scannerPort3, CommandDefinition.ScannerScanCode);
            INFO.Text = "收到" + _appendImei3.ToString() + "并发送N8";
            devicePort?.Write(CommandDefinition.N8Connect ?? Array.Empty<byte>(), 0, 8);
            Thread.Sleep(2000);
            devicePort?.Write(CommandDefinition.N8DisConnect ?? Array.Empty<byte>(), 0, 8);
            INFO.Text = "N5发送结束，并缓存报工打印";
            DataCacheService dataCacheService = new DataCacheService();
            String imei3;
            imei3 = _appendImei3.ToString();
            imei3 = imei3.Replace("\r", "");
            imei3 = imei3.Replace("\n", "");
            int cacheResult = dataCacheService.DeviceCache(imei3, _loginInfo.userId, _process.SelectedProcessName, SubmitStatus.UnCommit);
            _startScan = cacheResult == 1;
        }


        #endregion


        #region 目标检测调用

        public void ObjectDetectionFuncExcute()
        {
            ObjectDetectionFuncThread = new Thread(delegate () 
            {
                try
                {
                    ObjectDetectionProgram.ImageIdentification.ObjectDetection.Run(out catalogItemList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("视觉："+ex.Message);
                }
            });

            ObjectDetectionFuncThread.Start();
            Application.DoEvents();
        }
        #endregion



        #endregion


        private void BigPackFormLoad_Button_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Close();
            BigPackForm bigPackForm = new BigPackForm(_loginInfo, _process);
            Thread invokeThread = new Thread(() => { bigPackForm.ShowDialog(); });
            invokeThread.SetApartmentState(ApartmentState.STA);
            invokeThread.Start();
        }

        private void Export_Button_Click(object sender, EventArgs e)
        {
            ExcelHelper excelHelper = new ExcelHelper();
            SelectProductOrder(ProductOrderInfo, -1);
            excelHelper.ExportDataToExcel(ProductOrderInfo, BaoGongDeviceList);
            SelectProductOrder(ProductOrderInfo, 100);
        }


        private void BackProcessSelection_Click(object sender, EventArgs e)
        {
            ProcessSelectionForm processSelectionForm = new ProcessSelectionForm(_loginInfo);
            new Thread(delegate () { processSelectionForm.ShowDialog(); }).Start();
            this.Close();
        }


        private void PackForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadSaleOrders_btn_Click(null, null);
        }
    }
}

