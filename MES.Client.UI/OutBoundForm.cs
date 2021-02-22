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
        JToken outBoundDeviceRet;

        public OutBoundForm(LoginInfo loginInfo, Process process)
        {
            _process = process;
            _loginInfo = loginInfo;

            InitializeComponent();
        }


        private void ScanCode_Button_Click(object sender, EventArgs e)
        {
            ScanCodeOutBoundForm scanCodeOutBoundForm = new ScanCodeOutBoundForm(_loginInfo, SaleOrderInfo);
            Thread thr = new Thread(delegate () { 
                scanCodeOutBoundForm.ShowDialog(); 
                InitComponent();
                DeviceRefresh(outBoundDeviceRet);
            });
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();

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
            outBoundDeviceRet = outBoundService.GetOutBoundProductDevices(_loginInfo, SaleOrderInfo.Id, (int)_process.SelectedProcessName);

            // Console.WriteLine(ret);
            JToken jTokenOrderConfig = outBoundService.GetIpAddressByUserName(_loginInfo, SaleOrderInfo);
            SaleOrderInfo.IpAddress = jTokenOrderConfig.SelectToken("ip") +":"+ jTokenOrderConfig.SelectToken("port");
            InitComponent();
            DeviceRefresh(outBoundDeviceRet);
        }



        private void InitComponent()
        {
            label2.Text = SaleOrderInfo?.OrderNo;
            CompanyFullName_Label.Text = SaleOrderInfo.CompanyFullName;
            DeviceModel_Label.Text = SaleOrderInfo.CustomerDeviceModel;
            BuyNumber_Label.Text = SaleOrderInfo.BuyNumber.ToString();
            BuyDate_Label.Text = SaleOrderInfo.BuyDate;
            PlatformType_Label.Text = SaleOrderInfo.PlatFormType;
            IPAddress_Label.Text = SaleOrderInfo.IpAddress;
        }



        private void DeviceRefresh(JToken outboundDevice)
        {
            if (outBound_DataGirdView == null) return;
            outBound_DataGirdView.Rows.Clear();

            int outBoundDeviceCount = 0;
            if (!outboundDevice.Any()) return;
            foreach(var item in outboundDevice)
            {
                DataGridViewRow rowOne = new DataGridViewRow();
                rowOne.CreateCells(outBound_DataGirdView);
                outBoundDeviceCount++;
                rowOne.Cells[0].Value = outBoundDeviceCount;
                rowOne.Cells[1].Value = item?.SelectToken("imei");
                rowOne.Cells[2].Value = item?.SelectToken("imsi");
                rowOne.Cells[3].Value = item?.SelectToken("userName");
                rowOne.Cells[4].Value = item?.SelectToken("platform");
                rowOne.Cells[5].Value = item?.SelectToken("handleResult");
                rowOne.Cells[6].Value = item?.SelectToken("userId");
                rowOne.Cells[7].Value = "删除";
                outBound_DataGirdView.Rows.Add(rowOne);
            }
        }



        private void BackProcessSelection_Click(object sender, EventArgs e)
        {
            ProcessSelectionForm processSelectionForm = new ProcessSelectionForm(_loginInfo);
            new Thread(delegate () { processSelectionForm.ShowDialog(); }).Start();
            this.Close();
        }



        private void Exit_Form_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }


        private void OutBoundForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadSaleOrders_btn_Click(sender, e);
        }
    }
}
