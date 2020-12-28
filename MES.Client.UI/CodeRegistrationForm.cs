using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using XPTable.Models;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class CodeRegistrationForm : Form
    {
        private ColumnModel _columnModel;
        private TableModel _tableModel;
        private Process _process;
        private LoginInfo _loginInfo;
        public ProductOrderInfo ProductOrderInfo;
        private readonly JToken _productOrders;


        public CodeRegistrationForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {

            _loginInfo = loginInfo;
            _process = process;
            _productOrders = productOrders;
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitInfoTable();
        }


        
        #region SetColumns

        private void InitInfoTable()
        {

/*            if (_columnModel.Columns == null) return;
            _columnModel.Columns.Add(new TextColumn("序号", 40));
            _columnModel.Columns.Add(new TextColumn("产品名称", 135));
            _columnModel.Columns.Add(new TextColumn("产品型号", 5));
            _columnModel.Columns.Add(new TextColumn("量程", 5));
            _columnModel.Columns.Add(new TextColumn("设备号（IMEI）", 115));
            _columnModel.Columns.Add(new TextColumn("IMSI", 105));
            _columnModel.Columns.Add(new TextColumn("SIM类型", 55));
            _columnModel.Columns.Add(new TextColumn("备注", 5));
            _columnModel.Columns.Add(new TextColumn("注册平台", 75));
            _columnModel.Columns.Add(new TextColumn("平台类型", 60));
            _columnModel.Columns.Add(new TextColumn("注册状态", 65));
            _columnModel.Columns.Add(new TextColumn("在线状态", 80));
            _columnModel.Columns.Add(new TextColumn("操作员", 60));
            _columnModel.Columns.Add(new TextColumn("录入时间", 128));
            _columnModel.Columns.Add(new TextColumn("数据上报时间", 128));
            _columnModel.Columns.Add(new TextColumn("数据值", 50));
            _columnModel.Columns.Add(new TextColumn("ICCID", 130));*/


            if (RegisteredDeviceList == null) return;
            RegisteredDeviceList.Columns.Add("id", "序号");
            RegisteredDeviceList.Columns.Add("orderNo", "产品名称");
            RegisteredDeviceList.Columns.Add("saleOrderid", "产品型号");
            RegisteredDeviceList.Columns.Add("companyFullName", "量程");
            RegisteredDeviceList.Columns.Add("deviceModel", "设备号（IMEI）");
            RegisteredDeviceList.Columns.Add("buyNumber", "IMSI");

            // 设置自动列宽
            RegisteredDeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置字体样式
            Font font = new Font("微软雅黑", 8);
            RegisteredDeviceList.Font = font;

            //设置文本居中
            RegisteredDeviceList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;




        }



        #endregion



        private void LoadWorkOrder_btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrderInfo();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();
            LoadProductOrderInfo();
        }


        #region 选择或切换工单


        private void LoadProductOrderInfo()
        {
            label_orderno.Text = "当前工单：" + ProductOrderInfo?.OrderNo;
            label_companyName.Text = "客户名称: " + ProductOrderInfo?.CompanyFullName;
            label_deviceModel.Text = "设备型号: " + ProductOrderInfo?.DeviceModel;
            label_buynum.Text = "订单数量: " + ProductOrderInfo?.BuyNumber;
        }

        #endregion

    }
}
