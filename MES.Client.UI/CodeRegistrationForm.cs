using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
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
        private readonly JToken _productOrders; // 缓存的所有工单
        private Qualify _qualify;

        public CodeRegistrationForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {
            _loginInfo = loginInfo;
            _process = process;
            _productOrders = productOrders;
            Control.CheckForIllegalCrossThreadCalls = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _appSettingsSection = config.AppSettings;
            InitializeComponent();
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
            RegisteredDeviceList.Columns.Add("orderNo", "产品名称");
            RegisteredDeviceList.Columns.Add("saleOrderid", "产品型号");
            RegisteredDeviceList.Columns.Add("companyFullName", "量程");
            RegisteredDeviceList.Columns.Add("deviceModel", "设备号（IMEI）");
            RegisteredDeviceList.Columns.Add("imsi", "IMSI");
            RegisteredDeviceList.Columns.Add("SIMType", "SIM类型");
            RegisteredDeviceList.Columns.Add("Remarks", "备注");
            RegisteredDeviceList.Columns.Add("userName", "注册平台");
            RegisteredDeviceList.Columns.Add("platform", "平台类型");
            RegisteredDeviceList.Columns.Add("handleResult", "注册状态");
            RegisteredDeviceList.Columns.Add("status", "在线状态");
            RegisteredDeviceList.Columns.Add("mUserName", "操作员");
            RegisteredDeviceList.Columns.Add("startTime", "录入时间");
            RegisteredDeviceList.Columns.Add("onlineTime", "数据上报时间");
            RegisteredDeviceList.Columns.Add("value", "数据值");
            RegisteredDeviceList.Columns.Add("ICCID", "ICCID");


            // 设置自动列宽
            RegisteredDeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        private void CutOverProductOrder(ProductOrder poi)
        {
            if (poi?.OrderNo == null) return;
            OrderNo_TextBox.Text = poi.OrderNo;
            CompanyFullName_TextBox.Text = poi.CompanyFullName;
            DeviceModel_TextBox.Text = poi.DeviceModel;
            BuyNumber_TextBox.Text = poi.BuyNumber.ToString();

            SaleOrderService saleOrderService = new SaleOrderService();

            JToken saleOrderInfo = saleOrderService.GetSaleOrderInfo(_loginInfo, poi.SaleOrderId.ToString());
            SaleOrder saleOrder = saleOrderService.SetSaleOrderInfo(saleOrderInfo);

            ProductOrderService productOrderService = new ProductOrderService();

            JToken registrationDeviceRecord = productOrderService.GetRegistrationDeviceRecord(
                _loginInfo,
                poi.OrderId.ToString(),
                ((int)ProcessNameEnum.CodeRegistration).ToString()
            );

            InitInfoTable();
            UpdateTable(registrationDeviceRecord, saleOrder);
        }

        #endregion



        #region 刷新设备列表数据

        private void UpdateTable(JToken registrationDeviceRecord, SaleOrder saleOrder)
        {
            if (registrationDeviceRecord == null) return;
            if (RegisteredDeviceList == null) return;
            if (saleOrder == null) return;

            DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);

            foreach (var i in registrationDeviceRecord)
            {
                int index = RegisteredDeviceList.Rows.Add();


                if (RegisteredDeviceList.Rows[index].Cells[0] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[0].Value = JsonConverter.JTokenTransformer(index);
                }

                if (RegisteredDeviceList.Rows[index].Cells[1] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[1].Value = saleOrder.customerDeviceName;
                }

                if (RegisteredDeviceList.Rows[index].Cells[2] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[2].Value = saleOrder.customerDeviceModel;
                }

                if (RegisteredDeviceList.Rows[index].Cells[3] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[3].Value = saleOrder.defaultConfig;
                }

                if (RegisteredDeviceList.Rows[index].Cells[4] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[4].Value = JsonConverter.JTokenTransformer(i["imei"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[5] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[5].Value = JsonConverter.JTokenTransformer(i["imsi"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[6] != null)
                {
                    string imsi = JsonConverter.JTokenTransformer(i["imsi"]);

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
                    RegisteredDeviceList.Rows[index].Cells[8].Value = JsonConverter.JTokenTransformer(i["userName"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[9] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[9].Value = JsonConverter.JTokenTransformer(i["platform"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[10] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[10].Value = JsonConverter.JTokenTransformer(i["handleResult"]);
                }

                // status
                var status = JsonConverter.JTokenTransformer(i["status"]);
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
                    RegisteredDeviceList.Rows[index].Cells[12].Value = _loginInfo.User;
                }

                if (RegisteredDeviceList.Rows[index].Cells[13] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[13].Value = _loginInfo.User;

                    var time = JsonConverter.JTokenTransformer(i["startTime"]);
                    if (time.Length == 0)
                    {
                        time = "0";
                    }
                    var startTime = dtStart.AddMilliseconds(Convert.ToInt64(time));
                    RegisteredDeviceList.Rows[index].Cells[13].Value = startTime.ToString("yyyy-MM-dd HH:mm:ss:f");
                }

                if (RegisteredDeviceList.Rows[index].Cells[14] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[14].Value = JsonConverter.JTokenTransformer(i["onlineTime"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[15] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[15].Value = JsonConverter.JTokenTransformer(i["value"]);
                }

                if (RegisteredDeviceList.Rows[index].Cells[16] != null)
                {
                    RegisteredDeviceList.Rows[index].Cells[16].Value = JsonConverter.JTokenTransformer(i["iccid"]);
                }
            }
        }


        #endregion



        private void LoadWorkOrder_btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrder();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();

            CutOverProductOrder(ProductOrderInfo);
        }


        private void CreateProductOrder_Btn_Click(object sender, EventArgs e)
        {
            //调用系统默认的浏览器 
            System.Diagnostics.Process.Start(_appSettingsSection?.Settings?["SaleOrdersPage"]?.Value ?? String.Empty);
        }



        private void Imei_TextBox_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            CodeScanHelper codeScanHelper = new CodeScanHelper();
            string imei = codeScanHelper.CodeScanFilter(Imei_TextBox?.Text);
            BaoGongService baoGongService = new BaoGongService();
            if (_qualify == null)
            {
                _qualify = new Qualify {Id = 0, Reason = "无"};
            }

            PassJudge passJudge = checkBox3.Checked ? PassJudge.Qualified : PassJudge.Unqualified;

            // 报工到烧录配置工序
            baoGongService.DeviceBaoGong(_loginInfo, imei, ProductOrderInfo?.OrderId.ToString(), ((int)ProcessNameEnum.BurnConfiguration).ToString(), _loginInfo.userId, passJudge, _qualify.Id, _qualify.Reason);

            if (checkBox1.Checked)
            {
                // 报工到编码注册工序
                JToken baoGongResult = baoGongService.DeviceBaoGong(_loginInfo, imei, ProductOrderInfo?.OrderId.ToString(), ((int)_process.SelectedProcessName).ToString(), _loginInfo.userId, passJudge, _qualify.Id, _qualify.Reason);
                INFO.Text = imei + @"报工:" + baoGongResult;
            }

            if (checkBox2.Checked)
            {
                Device registerDevice = new Device {imei = imei, imsi = Imsi_TextBox?.Text};
                RegistrationService registrationService = new RegistrationService();
                // 设备注册
                JToken registerResult = registrationService.PostRegisterDevice(_loginInfo, ProductOrderInfo?.SaleOrderId.ToString(), registerDevice);
                INFO.Text = imei + @"注册:" + registerResult;
            }
            CutOverProductOrder(ProductOrderInfo);
            
            Imei_TextBox?.Clear();
        }



        private void Qualify_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _qualify = new Qualify
            {
                Id = Qualify_ComboBox.SelectedIndex + 1, Reason = Qualify_ComboBox.SelectedItem?.ToString()
            };
        }

        private void Setting_Button_Click(object sender, EventArgs e)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.ShowDialog();
        }
    }
}
