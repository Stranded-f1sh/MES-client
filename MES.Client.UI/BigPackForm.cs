using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FastReport;
using FastReport.Barcode;
using FastReport.Table;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class BigPackForm : Form
    {
        public SaleOrder SaleOrderInfo; // 发货客户销售单信息
        private readonly Process _process; // 所在工序
        private readonly LoginInfo _loginInfo; // 操作员信息
        private BigPack _bigPackInfo;
        private JToken _jTokenBigPack; // 大箱单列表


        public BigPackForm(LoginInfo loginInfo, Process process)
        {
            InitializeComponent();

            _process = process;
            _loginInfo = loginInfo;
        }

        private void BigPackForm_Load(object sender, EventArgs e)
        {
            String mainModuleFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            String exeName = "ManufacturingExecutionSystem.exe";
            mainModuleFileName = mainModuleFileName?.Substring(0, mainModuleFileName.Length - exeName.Length);
            mainModuleFileName += "FrxModelFiles\\bigpackList.frx";

            _bigPackInfo = new BigPack {FrxFileModel = mainModuleFileName};
        }


        private void LoadFrxFile_Button_Click(object sender, EventArgs e)
        {
            String mainModuleFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            String exeName = "ManufacturingExecutionSystem.exe";
            mainModuleFileName = mainModuleFileName?.Substring(0, mainModuleFileName.Length - exeName.Length);
            mainModuleFileName += "FrxModelFiles\\";

            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = mainModuleFileName,
                Filter = @"模板文件|*.frx",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            openFileDialog.ShowDialog();

            string frxModelName = openFileDialog.FileName;
            if (frxModelName == String.Empty | _bigPackInfo == null) return;

            _bigPackInfo.FrxFileModel = frxModelName;
            comboBox1_SelectionChangeCommitted(sender, e);
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

            label2.Text = SaleOrderInfo.OrderNo;


            RefreshBigPackList(sender, e);
        }



        //刷新销售订单的大箱单列表
        private int RefreshBigPackList(object sender, EventArgs e)
        {
            comboBox1?.Items.Clear();
            SaleOrderService saleOrderService = new SaleOrderService();
            _jTokenBigPack = saleOrderService.GetBigPack(_loginInfo, SaleOrderInfo?.Id);

            IEnumerable<JToken> enumerable = _jTokenBigPack?.Reverse();
            // 遍历销售单下的所有大箱单
            if (enumerable == null) return -1;
            foreach (JToken jToken in enumerable)
            {
                comboBox1?.Items.Add(jToken?.SelectToken("packNo") ?? String.Empty);
            }
            comboBox1.Text = comboBox1?.Items[0]?.ToString();

            comboBox1_SelectionChangeCommitted(sender, e);
            return (_jTokenBigPack ?? -1).Count();
        }



        //切换大箱单
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_jTokenBigPack == null | _bigPackInfo == null) return;
            IEnumerable<JToken> enumerable = _jTokenBigPack.Reverse();
            // 遍历销售单下的所有大箱单
            foreach (JToken jToken in enumerable)
            {
                if (jToken?.SelectToken("packNo")?.ToString() != comboBox1?.Text) continue;
                _bigPackInfo.PackNo = jToken?.SelectToken("packNo")?.ToString();
                _bigPackInfo.PackId = jToken?.SelectToken("id")?.ToString();
                _bigPackInfo.OrderNo = SaleOrderInfo?.OrderNo;
                _bigPackInfo.CompanyFullName = SaleOrderInfo?.CompanyFullName;
                _bigPackInfo.CustomerDeviceName = SaleOrderInfo?.CustomerDeviceName;
                _bigPackInfo.CustomerDeviceModel = SaleOrderInfo?.CustomerDeviceModel;
                _bigPackInfo.DeviceCount = "10";
                break;
            }

            new CodeScanHelper().PreviewFrxImg(_bigPackInfo, previewControl1);
            DeviceRefresh(_bigPackInfo);
        }



        private int DeviceRefresh(BigPack bigPack)
        {
            PackService packService = new PackService();
            JToken packLinkDevice = packService.GetPackLinkDevice(_loginInfo, bigPack);
            if (packLinkDevice == null) return -1;

            if (PackLinkDeviceList_DataGridView == null) return -1;
            int linkedDeviceCount = 0;
            foreach (JToken item in packLinkDevice)
            {
                DataGridViewRow rowOne = new DataGridViewRow();
                rowOne.CreateCells(PackLinkDeviceList_DataGridView);

                rowOne.Cells[0].Value = item?.SelectToken("id");
                rowOne.Cells[1].Value = item?.SelectToken("imei");
                rowOne.Cells[2].Value = item?.SelectToken("packId");
                rowOne.Cells[3].Value = "删除";
                PackLinkDeviceList_DataGridView.Rows.Add(rowOne);
                linkedDeviceCount++;
            }

            return linkedDeviceCount;
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;

            DataCacheService dataCacheService = new DataCacheService();
            //dataCacheService.DeviceCache()
        }


        /// <summary>
        /// 箱单绑定
        /// </summary>
        private void PackLink(BigPack bigPack)
        {
            int deviceCount = DeviceRefresh(bigPack);

            // 如果大箱单下没有，并且销售单没有大箱单，说明此销售订单没有大箱单记录
            if (deviceCount <= 0 && !(_jTokenBigPack ?? String.Empty).Any())
            {
                // 调用生成大箱单的接口
            }


        }

    }
}
