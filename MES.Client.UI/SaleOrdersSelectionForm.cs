using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class SaleOrdersSelectionForm : Form
    {
        private readonly Process _process;
        private readonly LoginInfo _loginInfo;
        private Dictionary<Int32, JToken> _getSaleOrdersDictionary;

        public SaleOrdersSelectionForm(Process process, LoginInfo loginInfo)
        {
            _process = process;
            _loginInfo = loginInfo;
            InitializeComponent();
        }


        private void SaleOrdersSelectionForm_Load(object sender, EventArgs e)
        {
            InitInfoTable();
            _getSaleOrdersDictionary = InitYearList();
            YearSelection_ComboBox_TextChanged(sender, e);
        }



        #region 初始化年份菜单并加载销售单数据

        public Dictionary<Int32, JToken> InitYearList()
        {
            DateTime startTime = new DateTime(2020, 1, 1, 8, 0, 0);
            int startTimeYear = startTime.Year;
            DateTime endTime = DateTime.Now;
            int endTimeYear = endTime.Year;
            int saleOrderCreateYears = endTimeYear - startTimeYear;

            SaleOrderService saleOrderService = new SaleOrderService();

            Dictionary<Int32, JToken> getSaleOrdersDictionary = new Dictionary<Int32, JToken>();

            for (int i = 0; i <= saleOrderCreateYears; i++)
            {
                YearSelection_ComboBox?.Items.Add(startTimeYear);
                JToken saleOrders = saleOrderService.GetSaleOrders(_loginInfo, startTimeYear);
                if (getSaleOrdersDictionary.ContainsKey(startTimeYear) == false)
                {
                    getSaleOrdersDictionary.Add(startTimeYear, saleOrders);
                }
                else
                {
                    MessageBox.Show(@"你他妈的");
                }

                if (YearSelection_ComboBox != null) YearSelection_ComboBox.SelectedIndex = i;
                startTimeYear++;
            }
            return getSaleOrdersDictionary;
        }
        #endregion



        #region SetColumns

        private void InitInfoTable()
        {
            if (SaleOrderList == null) return;
            SaleOrderList.Columns.Add("id", "销售单id");
            SaleOrderList.Columns.Add("orderNo", "销售单号");
            SaleOrderList.Columns.Add("companyFullName", "客户公司名称");
            SaleOrderList.Columns.Add("deviceModel", "设备类型");
            SaleOrderList.Columns.Add("buyNumber", "订单数量");
            SaleOrderList.Columns.Add("buyDate", "购买时间");

            // 设置自动列宽
            SaleOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置字体样式
            Font font = new Font("微软雅黑", 8);
            SaleOrderList.Font = font;

            //设置文本居中
            if (SaleOrderList.RowsDefaultCellStyle != null)
            {
                SaleOrderList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion



        #region 更新列表

        private void UpdateTable(JToken saleOrders)
        {
            if (saleOrders == null) return;
            if (SaleOrderList == null) return;
            SaleOrderList.Rows.Clear();
            foreach (var i in saleOrders)
            {
                int index = SaleOrderList.Rows.Add();
                if (SaleOrderList.Rows[index].Cells[0] != null)
                {
                    SaleOrderList.Rows[index].Cells[0].Value = MyJsonConverter.JTokenTransformer(i?["id"]);
                }

                if (SaleOrderList.Rows[index].Cells[1] != null)
                {
                    SaleOrderList.Rows[index].Cells[1].Value = MyJsonConverter.JTokenTransformer(i?["orderNo"]);
                }

                if (SaleOrderList.Rows[index].Cells[2] != null)
                {
                    SaleOrderList.Rows[index].Cells[2].Value = MyJsonConverter.JTokenTransformer(i?["companyFullName"]);
                }

                if (SaleOrderList.Rows[index].Cells[3] != null)
                {
                    SaleOrderList.Rows[index].Cells[3].Value = MyJsonConverter.JTokenTransformer(i?["deviceModel"]);
                }

                if (SaleOrderList.Rows[index].Cells[4] != null)
                {
                    SaleOrderList.Rows[index].Cells[4].Value = MyJsonConverter.JTokenTransformer(i?["buyNumber"]);
                }

                if (SaleOrderList.Rows[index].Cells[5] != null)
                {
                    SaleOrderList.Rows[index].Cells[5].Value = MyJsonConverter.JTokenTransformer(i?["buyDate"]);
                }
            }
        }

        #endregion



        private void Go_Button_Click(object sender, EventArgs e)
        {
            SaleOrderService saleOrderService = new SaleOrderService();
            JToken saleOrderInfo = saleOrderService.GetSaleOrderInfo(_loginInfo, SaleOrder_TextBox?.Text);
            SaleOrder orderInfo = saleOrderService.SetSaleOrderInfo(saleOrderInfo);
            Console.WriteLine(orderInfo.Address);
            Console.WriteLine(orderInfo.BuyDate);
            Console.WriteLine(orderInfo.BuyNumber);
            Console.WriteLine(orderInfo.CompanyFullName);
            Console.WriteLine(orderInfo.CustomerDeviceModel);
            Console.WriteLine(orderInfo.CustomerDeviceName);
            Console.WriteLine(orderInfo.DefaultConfig);
            Console.WriteLine(orderInfo.OrderNo);
        }



        private void YearSelection_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (_getSaleOrdersDictionary == null) return;
            if (YearSelection_ComboBox?.Text == null) return;

            if (_getSaleOrdersDictionary.ContainsKey(Int32.Parse(YearSelection_ComboBox?.Text)))
            {
                _getSaleOrdersDictionary.TryGetValue(Int32.Parse(YearSelection_ComboBox?.Text), out JToken saleOrders);
                UpdateTable(saleOrders);
            }
            else
            {
                MessageBox.Show(@"妈的把在");
            }
        }
    }
}
