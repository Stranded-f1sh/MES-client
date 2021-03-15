using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;


namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class CodeRegistrationForm : Form
    {
        private readonly AppSettingsSection _appSettingsSection;
        private readonly Process _process;
        private readonly LoginInfo _loginInfo;
        public ProductOrder ProductOrderInfo; // 切换的工单实体类
        private JToken _productOrders; // 缓存的所有工单
        private Qualify _qualify;
        private int _pageCount; // 总页数
        private int _pageNum;  // 当前页

        public CodeRegistrationForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {
            _loginInfo = loginInfo;
            _process = process;
            _productOrders = productOrders;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _appSettingsSection = config.AppSettings;
            InitializeComponent();
            
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }



        #region FormLoad


        private void CodeRegistrationForm_Load(object sender, EventArgs e)
        {
            QualifyService qualifyService = new QualifyService();
            if (_process?.SelectedProcessName == null) return;

            JToken unQualifyReason = qualifyService.GetUnQualifyReason(_loginInfo, ((int)_process?.SelectedProcessName).ToString());
            if (unQualifyReason == null) return;
            foreach (JToken reasonItems in unQualifyReason)
            {
                Qualify_ComboBox?.Items.Add(reasonItems?.SelectToken("reason") ?? String.Empty);
            }
            
            checkBox3.Checked = true;
            ProcessProductRefresh();
        }
        #endregion



        #region 界面交互逻辑


        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (checkBox1.Checked)
            {
                case true:
                    checkBox2.Checked = false;
                    break;
                case false:
                    checkBox1.Checked = true;
                    break;
            }
        }

        private void checkBox2_MouseUp(object sender, MouseEventArgs e)
        {
            switch (checkBox2.Checked)
            {
                case true:
                    checkBox1.Checked = false;
                    break;
                case false:
                    checkBox1.Checked = true;
                    break;
            }
        }

        private void checkBox3_MouseUp(object sender, MouseEventArgs e)
        {
            switch (checkBox3.Checked)
            {
                case true:
                    checkBox4.Checked = false;
                    Qualify_ComboBox.Visible = false;
                    button7.Visible = false;
                    break;
                case false:
                    checkBox4.Checked = true;
                    Qualify_ComboBox.Visible = true;
                    button7.Visible = true;
                    break;
            }
        }

        private void checkBox4_MouseUp(object sender, MouseEventArgs e)
        {
            switch (checkBox4.Checked)
            {
                case true:
                    checkBox3.Checked = false;
                    Qualify_ComboBox.Visible = true;
                    button7.Visible = true;
                    break;
                case false:
                    checkBox3.Checked = true;
                    Qualify_ComboBox.Visible = false;
                    button7.Visible = false;
                    break;
            }
        }

        #endregion



        #region SetColumns

        private void InitInfoTable()
        {
            if (RegisteredDeviceList == null) return;
            RegisteredDeviceList.Rows.Clear();
            RegisteredDeviceList.Columns.Clear();
            RegisteredDeviceList.Columns.Add("index", "序号");
            RegisteredDeviceList.Columns[0].Width = 30;
            RegisteredDeviceList.Columns.Add("orderNo", "产品名称");
            RegisteredDeviceList.Columns[1].Width = 150;
            RegisteredDeviceList.Columns.Add("saleOrderid", "产品型号");
            RegisteredDeviceList.Columns[2].Width = 80;
            RegisteredDeviceList.Columns.Add("companyFullName", "量程");
            RegisteredDeviceList.Columns[3].Width = 10;
            RegisteredDeviceList.Columns.Add("deviceModel", "设备号（IMEI）");
            RegisteredDeviceList.Columns[4].Width = 150;
            RegisteredDeviceList.Columns.Add("imsi", "IMSI");
            RegisteredDeviceList.Columns[5].Width = 130;
            RegisteredDeviceList.Columns.Add("SIMType", "SIM类型");
            RegisteredDeviceList.Columns[6].Width = 80;
            RegisteredDeviceList.Columns.Add("Remarks", "备注");
            RegisteredDeviceList.Columns[7].Width = 10;
            RegisteredDeviceList.Columns.Add("userName", "注册平台");
            RegisteredDeviceList.Columns[8].Width = 80;
            RegisteredDeviceList.Columns.Add("platform", "平台类型");
            RegisteredDeviceList.Columns[9].Width = 80;
            RegisteredDeviceList.Columns.Add("handleResult", "注册状态");
            RegisteredDeviceList.Columns[10].Width = 80;
            RegisteredDeviceList.Columns.Add("status", "在线状态");
            RegisteredDeviceList.Columns[11].Width = 80;
            RegisteredDeviceList.Columns.Add("mUserName", "操作员");
            RegisteredDeviceList.Columns[12].Width = 70;
            RegisteredDeviceList.Columns.Add("startTime", "录入时间");
            RegisteredDeviceList.Columns[13].Width = 80;
            RegisteredDeviceList.Columns.Add("onlineTime", "数据上报时间");
            RegisteredDeviceList.Columns[14].Width = 70;
            RegisteredDeviceList.Columns.Add("value", "数据值");
            RegisteredDeviceList.Columns[15].Width = 70;
            RegisteredDeviceList.Columns.Add("ICCID", "ICCID");
            RegisteredDeviceList.Columns[16].Width = 10;


            NextPage_Btn.Enabled = _pageCount != _pageNum;

            BackPage_Btn.Enabled = _pageNum != 1;

            PageNum_Label.Text = _pageNum.ToString();

            // 设置自动列宽
            RegisteredDeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            RegisteredDeviceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            // 设置字体样式
            Font font = new Font("宋体", 9);
            RegisteredDeviceList.Font = font;

            //设置文本居中
            RegisteredDeviceList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Type dgvType = RegisteredDeviceList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(this.RegisteredDeviceList, true, null);
        }


        #endregion



        #region 选择或切换工单

        /// <summary>
        /// 选择或者切换工单，在此方法加载时，需要将 [销售订单信息]、[工单信息]、[工序报工记录信息预加载]
        /// </summary>
        private void CutOverProductOrder(ProductOrder poi, int pageSize)
        {
            if (poi?.OrderNo == null) return;
            INFO.Text = @"刷新中.......";
            Application.DoEvents();
            
            OrderNo_TextBox.Text = poi.OrderNo;
            CompanyFullName_TextBox.Text = poi.CompanyFullName;
            DeviceModel_TextBox.Text = poi.DeviceModel;
            BuyNumber_TextBox.Text = poi.BuyNumber.ToString();
            

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
                            ((int)ProcessNameEnum.CodeRegistration).ToString()
                            );
            }
            else
            {
                productDeviceRecord = productOrderService.GetProductDeviceRecord(
                            _loginInfo,
                            poi.OrderId.ToString(),
                            ((int)ProcessNameEnum.CodeRegistration).ToString(),
                            pageSize,
                            _pageNum
                            );
            }


            RegistNum_TextBox.Text = productDeviceRecord?.SelectToken("count")?.ToString();

            _pageCount = (int)Math.Ceiling(double.Parse(productDeviceRecord?.SelectToken("count")?.ToString() ?? String.Empty) / pageSize);
            if (pageSize == -1)
            {
                _pageCount = 1;
                _pageNum = 1;
            }
            InitInfoTable();
            UpdateTable(productDeviceRecord, saleOrder);
            INFO.Text = String.Empty;
            Imei_TextBox.Focus();
        }

        #endregion



        #region 刷新设备列表数据

        private void UpdateTable(JToken registrationDeviceRecord, SaleOrder saleOrder)
        {
            if (registrationDeviceRecord?.SelectToken("list") == null) return;
            if (RegisteredDeviceList == null) return;
            if (saleOrder == null) return;

            DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);

            foreach (var i in registrationDeviceRecord.SelectToken("list") ?? String.Empty)
            {
                int index = RegisteredDeviceList.Rows.Add();

                

                if (RegisteredDeviceList.Rows[index].Cells[0] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[0].Value = MyJsonConverter.JTokenTransformer((_pageNum - 1) * 100 + index + 1);
                }

                if (RegisteredDeviceList.Rows[index].Cells[1] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[1].Value = saleOrder.CustomerDeviceName;
                }

                if (RegisteredDeviceList.Rows[index].Cells[2] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[2].Value = saleOrder.CustomerDeviceModel;
                }

                if (RegisteredDeviceList.Rows[index].Cells[3] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[3].Value = saleOrder.DefaultConfig;
                }

                if (RegisteredDeviceList.Rows[index].Cells[4] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[4].Value = MyJsonConverter.JTokenTransformer(i["imei"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[5] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[5].Value = MyJsonConverter.JTokenTransformer(i["imsi"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[6] != null)
                {
                    string imsi = MyJsonConverter.JTokenTransformer(i["imsi"]);

                    // SIM卡类型
                    if (imsi != "" && imsi.Length > 4)
                    {
                        if ("4600" == imsi.Substring(0, 4))
                        {
                            RegisteredDeviceList.Rows[index].Cells[6].Value = "移动";
                        }
                        else if ("4601" == imsi.Substring(0, 4))
                        {
                            RegisteredDeviceList.Rows[index].Cells[6].Value = "电信";
                        }
                        else
                        {
                            RegisteredDeviceList.Rows[index].Cells[6].Value = "未刷新";
                        }
                    }
                    else
                    {
                        RegisteredDeviceList.Rows[index].Cells[6].Value = "未刷新";
                    }
                }

                if (RegisteredDeviceList.Rows[index].Cells[7] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[7].Value = "";
                }

                if (RegisteredDeviceList.Rows[index].Cells[8] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[8].Value = MyJsonConverter.JTokenTransformer(i["userName"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[9] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[9].Value = MyJsonConverter.JTokenTransformer(i["platform"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[10] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[10].Value = MyJsonConverter.JTokenTransformer(i["handleResult"]);
                }

                // status
                var status = MyJsonConverter.JTokenTransformer(i["status"]);
                if (status == "0")
                {
                    RegisteredDeviceList.Rows[index].Cells[11].Value = "离线";
                }
                else if (status == "1")
                {
                    RegisteredDeviceList.Rows[index].Cells[11].Value = "在线";
                }
                else
                {
                    RegisteredDeviceList.Rows[index].Cells[11].Value = "未上报数据";
                }

                if (RegisteredDeviceList.Rows[index].Cells[12] != null)
                {
                    foreach (var itm in _loginInfo.UserList)
                    {
                        if (itm?["userId"]?.ToString() == MyJsonConverter.JTokenTransformer(i["userId"]))
                        {
                            RegisteredDeviceList.Rows[index].Cells[12].Value = itm?["username"]?.ToString();
                            break;
                        }
                    }
                }

                if (RegisteredDeviceList.Rows[index].Cells[13] != null)
                {
                    var time = MyJsonConverter.JTokenTransformer(i["startTime"]);
                    if (time.Length == 0)
                    {
                        time = "0";
                    }
                    var startTime = dtStart.AddMilliseconds(Convert.ToInt64(time));
                    RegisteredDeviceList.Rows[index].Cells[13].Value = startTime.ToString("yyyy-MM-dd HH:mm:ss:f");
                }

                if (RegisteredDeviceList.Rows[index].Cells[14] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[14].Value = MyJsonConverter.JTokenTransformer(i["onlineTime"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[15] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[15].Value = MyJsonConverter.JTokenTransformer(i["value"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[16] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[16].Value = MyJsonConverter.JTokenTransformer(i["iccid"]);
                }
            }
        }


        #endregion



        private void LoadWorkOrder_btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrder();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders, _process, 0)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();
            _pageNum = 1;
            CutOverProductOrder(ProductOrderInfo, 100);
        }


        private void CreateProductOrder_Btn_Click(object sender, EventArgs e)
        {
            //调用系统默认的浏览器 
            System.Diagnostics.Process.Start(_appSettingsSection?.Settings?["SaleOrdersPage"]?.Value ?? String.Empty);
        }



        #region 报工或注册
        object objLock = new object();

        private void Imei_TextBox_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            lock (objLock)
            {
                bool canPrint = false;
                if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;

                LogInfoHelper _logger = new LogInfoHelper();
                _logger.printLog("[注册]扫描imei: " + Imei_TextBox?.Text + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);

                Application.DoEvents();
                CodeScanHelper codeScanHelper = new CodeScanHelper();
                string imei = codeScanHelper.CodeScanFilter(Imei_TextBox?.Text, out String pinDian);

                if (imei == null) return;

                INFO.Text = "正在执行，请稍后。。。。";

                BaoGongService baoGongService = new BaoGongService();
                if (_qualify == null)
                {
                    _qualify = new Qualify { Id = 0, Reason = "无" };
                }

                PassJudge passJudge = checkBox3.Checked ? PassJudge.Qualified : PassJudge.Unqualified;
                Device device = new Device { Imei = imei, Imsi = Imsi_TextBox?.Text, PinDian = pinDian };
                // 报工到烧录配置工序3
                baoGongService.DeviceBaoGong(_loginInfo, imei, ProductOrderInfo.OrderId, ProcessNameEnum.BurnConfiguration, String.Empty);


                if (checkBox2.Checked)
                {
                    RegistrationService registrationService = new RegistrationService();
                    // 设备注册
                    JToken registerResult = registrationService.PostRegisterDevice(_loginInfo, ProductOrderInfo?.SaleOrderId.ToString(), device);
                    
                    if (registerResult != null && registerResult.ToString() == "注册到iot.device_detail成功")
                    {
                        canPrint = true;
                        INFO.Text = imei + @"注册到iot成功";
                        Application.DoEvents();
                    }
                    else
                    {
                        canPrint = false;
                        MessageBox.Show("注册失败");
                        INFO.Text = string.Empty;
                        Imei_TextBox?.Clear();
                        return;
                    }
                }

                // 报工到编码注册工序
                JToken baoGongResult = baoGongService.DeviceBaoGong(_loginInfo, imei, ProductOrderInfo.OrderId, _process.SelectedProcessName, String.Empty);
                INFO.Text = imei + @"报工:" + baoGongResult;
                if (baoGongResult != null && baoGongResult.ToString() == "ok")
                {
                    canPrint = true;
                }
                else
                {
                    canPrint = false;
                    MessageBox.Show(baoGongResult.ToString());
                }
                
                if (isPrint_CheckBox.Checked && canPrint)
                {
                    codeScanHelper.PrintQrCode(device, pinDian != String.Empty ? @"loraQrCode.frx" : @"generalQrCode.frx");
                }
                CutOverProductOrder(ProductOrderInfo, 100);
                ProcessProductRefresh();
                INFO.Text = string.Empty;
                Imei_TextBox?.Clear();
            }
        }

        #endregion



        private void Qualify_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _qualify = new Qualify
            {
                Id = Qualify_ComboBox.SelectedIndex + 1, Reason = Qualify_ComboBox.SelectedItem?.ToString()
            };
        }

        private void Setting_Button_Click(object sender, EventArgs e)
        {
            PrinterSettingsForm printerSettings = new PrinterSettingsForm();
            printerSettings.ShowDialog();
        }



        private void BackPage_Btn_Click(object sender, EventArgs e)
        {
            _pageNum -= 1;
            CutOverProductOrder(ProductOrderInfo, 100);
        }


        private void NextPage_Btn_Click(object sender, EventArgs e)
        {
            _pageNum += 1;
            CutOverProductOrder(ProductOrderInfo, 100);
        }



        private void Exit_Form_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }



        private void Export_Button_Click(object sender, EventArgs e)
        {
            ExcelHelper excelHelper = new ExcelHelper();

            CutOverProductOrder(ProductOrderInfo, -1);

            excelHelper.ExportDataToExcel(ProductOrderInfo, RegisteredDeviceList);

            CutOverProductOrder(ProductOrderInfo, 100);
            MessageBox.Show("已导出至项目文件夹。");
        }


        private void ScanAll_Button_Click(object sender, EventArgs e)
        {

        }


        private void CodeRegistrationForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadWorkOrder_btn_Click(sender, e);
        }


        private void BackProcessSelection_Click(object sender, EventArgs e)
        {
            ProcessSelectionForm processSelectionForm = new ProcessSelectionForm(_loginInfo);
            new Thread(delegate () { processSelectionForm.ShowDialog(); }).Start();
            this.Close();
        }


        private void RefreshOrder_Btn_Click(object sender, EventArgs e)
        {
            // 加载缓存工单
            ProductOrderService productOrderService = new ProductOrderService();
            _productOrders = productOrderService.GetProductOrders(_loginInfo);
            MessageBox.Show("工单刷新完成!");
        }



        private void btn_delDevice_Click(object sender, EventArgs e)
        {
            CodeScanHelper codeScanHelper = new CodeScanHelper();
            string imei = codeScanHelper.CodeScanFilter(RegisteredDeviceList.CurrentCell.Value.ToString(), out String pinDian);
            if (imei == string.Empty) 
            {
                MessageBox.Show("必须选中需要删除的设备号!");
                return;
             };
            string PlatFormType = RegisteredDeviceList.Rows[RegisteredDeviceList.CurrentRow.Index].Cells[9].Value.ToString();
            if (PlatFormType == string.Empty)
            {
                MessageBox.Show("平台类型不能为空!");
                return;
            }
            RegistrationService registrationService = new RegistrationService();
            JToken jTokenDelDevice = registrationService.DelDevice(_loginInfo, new Device { Imei = imei }, new SaleOrder { PlatFormType = PlatFormType });
            MessageBox.Show(jTokenDelDevice.ToString());
            CutOverProductOrder(ProductOrderInfo, 100);
        }


        /// <summary>
        /// 工序日产量刷新
        /// </summary>
        private void ProcessProductRefresh()
        {
            Thread threadProcessProdcueNum = new Thread(() =>
            {
                BaoGongService bgService = new BaoGongService();

                var msgs = bgService.ProcessProdcueNum(_loginInfo);

                foreach (var i in msgs)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") == i["day"].ToString())
                    {
                        if ((int)_process.SelectedProcessName == (int)i["process_id"])
                        {
                            Invoke(new Action(() => { process_num.Text = "工序日产量：" + i["num"]; }));
                        }
                    }
                }
            });
            threadProcessProdcueNum.Start();
        }
    }
}
