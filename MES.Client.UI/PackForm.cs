using System;
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
    public partial class PackForm : Form
    {
        private readonly JToken _productOrders; // 缓存的所有工单
        public ProductOrder ProductOrderInfo; // 切换的工单实体类
        private readonly Process _process;
        private readonly LoginInfo _loginInfo;
        private int _pageCount; // 总页数
        private int _pageNum;  // 当前页


        public PackForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {
            _productOrders = productOrders;
            _process = process;
            _loginInfo = loginInfo;
            InitializeComponent();
        }


        private void LoadSaleOrders_btn_Click(object sender, EventArgs e)
        {
            SaleOrdersSelectionForm saleOrdersSelectionForm = new SaleOrdersSelectionForm(_process, _loginInfo)
            {
                Owner = this
            };
            saleOrdersSelectionForm.ShowDialog();
        }


        private void OrderSelect_Btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrder();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders, _process)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();
            _pageNum = 1;
            SelectProductOrder(ProductOrderInfo, 20);
        }



        #region 工单查询
        
        
        private void SelectProductOrder(ProductOrder poi, int pageSize)
        {
            if (poi?.OrderNo == null) return;
            INFO.Text = @"刷新中.......";
            Application.DoEvents();

            SaleOrderService saleOrderService = new SaleOrderService();

            JToken saleOrderInfo = saleOrderService.GetSaleOrderInfo(_loginInfo, poi.SaleOrderId.ToString());
            SaleOrder saleOrder = saleOrderService.SetSaleOrderInfo(saleOrderInfo);

            ProductOrderService productOrderService = new ProductOrderService();

            JToken productDeviceRecord = productOrderService.GetProductDeviceRecord(
                _loginInfo,
                poi.OrderId.ToString(),
                ((int)ProcessNameEnum.CodeRegistration).ToString(),
                pageSize,
                _pageNum
            );

            PackNum_TextBox.Text = productDeviceRecord?.SelectToken("count")?.ToString();

            _pageCount = (int)Math.Ceiling(double.Parse(productDeviceRecord?.SelectToken("count")?.ToString() ?? String.Empty) / pageSize);
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
                    BaoGongDeviceList.Rows[index].Cells[0].Value = MyJsonConverter.JTokenTransformer((_pageNum - 1) * 20 + index + 1);
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
                    BaoGongDeviceList.Rows[index].Cells[12].Value = _loginInfo.User;
                }

                if (BaoGongDeviceList.Rows[index].Cells[13] != null)
                {
                    BaoGongDeviceList.Rows[index].Cells[13].Value = _loginInfo.User;

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
            SelectProductOrder(ProductOrderInfo, 20);
        }

        private void NextPage_Btn_Click(object sender, EventArgs e)
        {
            _pageNum += 1;
            SelectProductOrder(ProductOrderInfo, 20);
        }
    }
}
