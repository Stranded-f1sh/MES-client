using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class OutBoundForm : Form
    {
        public SaleOrder SaleOrderInfo;
        private readonly Process _process;
        private readonly LoginInfo _loginInfo;


        public OutBoundForm(LoginInfo loginInfo, Process process)
        {
            _process = process;
            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private void OutBoundForm_Load(object sender, EventArgs e)
        {

        }


        private void ScanCode_Button_Click(object sender, EventArgs e)
        {
            ScanCodeOutBoundForm scanCodeOutBoundForm = new ScanCodeOutBoundForm(_loginInfo, SaleOrderInfo);
            new Thread(delegate () { scanCodeOutBoundForm.ShowDialog(); }).Start();
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
            if (SaleOrderInfo.OrderNo == null) return;

            OutBoundService outBoundService = new OutBoundService();
            JToken ret = outBoundService.GetOutBoundProductDevices(_loginInfo, SaleOrderInfo.Id, (int)_process.SelectedProcessName);

            Console.WriteLine(ret);

            InitComponent();
        }

        private void InitComponent()
        {
            label2.Text = SaleOrderInfo?.OrderNo;
        }
    }
}
