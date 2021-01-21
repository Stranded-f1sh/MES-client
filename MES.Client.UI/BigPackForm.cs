using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FastReport;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils.PCB;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class BigPackForm : Form
    {
        public SaleOrder SaleOrderInfo; // 发货客户销售单信息
        private readonly Process _process; // 所在工序
        private readonly LoginInfo _loginInfo; // 操作员信息
        private BigPack _bigPackContext;
        private JToken _jTokenBigPack; // 大箱单列表
        private Report _rep;

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

            _bigPackContext = new BigPack {FrxFileModel = mainModuleFileName};
        }


        // 加载Frx文件
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
            if (frxModelName == String.Empty | _bigPackContext == null) return;

            _bigPackContext.FrxFileModel = frxModelName;
            comboBox1_SelectionChangeCommitted(sender, e);
        }



        // 加载销售单
        private void LoadSaleOrders_btn_Click(object sender, EventArgs e)
        {
            SaleOrderInfo = new SaleOrder();
            
            SaleOrdersSelectionForm saleOrdersSelectionForm = new SaleOrdersSelectionForm(_process, _loginInfo)
            {
                Owner = this,
                Text = @"请选择即将发货设备对应的客户销售订单"
            };
            saleOrdersSelectionForm.ShowDialog();

            if (SaleOrderInfo.OrderNo == String.Empty) return;
            label2.Text = SaleOrderInfo.OrderNo;

            // 预设计划大箱包装数量
            textBox3.Text = Math.Ceiling((decimal) (SaleOrderInfo.BuyNumber / 10.0)).ToString(CultureInfo.InvariantCulture);

            RefreshBigPackList(sender, e);
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            String imei = textBox1.Text;
            textBox1.Enabled = false;
            bool ret = NetServiceTools.InternetGetConnectedState();
            if (ret)
            {
                PackLink(imei);
            }
            else
            {
                MessageBox.Show(@"服务器连接不稳定");
            }
            textBox1.Enabled = true;
            textBox1.Clear();
        }



        #region 刷新销售订单的大箱单列表

        private int RefreshBigPackList(object sender, EventArgs e)
        {
            if (SaleOrderInfo == null) return -1;
            comboBox1?.Items.Clear();
            SaleOrderService saleOrderService = new SaleOrderService();
            _jTokenBigPack = saleOrderService.GetBigPack(_loginInfo, SaleOrderInfo.Id);

            IEnumerable<JToken> enumerable = _jTokenBigPack?.Reverse();
            // 遍历销售单下的所有大箱单
            if (enumerable == null) return -1;
            var jTokens = enumerable as JToken[] ?? enumerable.ToArray();
            if (jTokens.Any())
            {
                foreach (JToken jToken in jTokens)
                {
                    comboBox1?.Items.Add(jToken?.SelectToken("packNo") ?? String.Empty);
                }
                comboBox1.Text = comboBox1?.Items[0]?.ToString();
                comboBox1_SelectionChangeCommitted(sender, e);
            }
            return (_jTokenBigPack ?? -1).Count();
        }

        #endregion



        #region 刷新大箱单上下文

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_jTokenBigPack == null | _bigPackContext == null) return;
            IEnumerable<JToken> enumerable = _jTokenBigPack.Reverse();
            // 遍历销售单下的所有大箱单
            foreach (JToken jToken in enumerable)
            {
                if (jToken?.SelectToken("packNo")?.ToString() != comboBox1?.Text) continue;
                _bigPackContext.OrderNo = SaleOrderInfo?.OrderNo;
                _bigPackContext.CompanyFullName = SaleOrderInfo?.CompanyFullName;
                _bigPackContext.CustomerDeviceName = SaleOrderInfo?.CustomerDeviceName;
                _bigPackContext.CustomerDeviceModel = SaleOrderInfo?.CustomerDeviceModel;
                _bigPackContext.DeviceCount = textBox2.Text;
                _bigPackContext.PackNo = jToken?.SelectToken("packNo")?.ToString();
                _bigPackContext.PackId = jToken?.SelectToken("id")?.ToString();
                break;
            }

            _rep = new CodeScanHelper().PreviewFrxImg(_bigPackContext, previewControl1);
            DeviceRefresh(_bigPackContext);
        }

        #endregion



        #region 根据箱单获取设备列表

        private int DeviceRefresh(BigPack bigPack)
        {
            if (bigPack?.PackId == null) return -1;
            PackService packService = new PackService();
            JToken packLinkDevice = packService.GetPackLinkDevice(_loginInfo, bigPack);
            if (packLinkDevice == null | !packLinkDevice.Any())
            {
                PackLinkDeviceList_DataGridView.Rows.Clear();
                return -1;
            }
            if (PackLinkDeviceList_DataGridView == null) return -1;
            PackLinkDeviceList_DataGridView.Rows.Clear();
            int linkedDeviceCount = 0;
            foreach (JToken item in packLinkDevice)
            {
                DataGridViewRow rowOne = new DataGridViewRow();
                rowOne.CreateCells(PackLinkDeviceList_DataGridView);
                linkedDeviceCount++;
                rowOne.Cells[0].Value = linkedDeviceCount;
                rowOne.Cells[1].Value = item?.SelectToken("imei");
                rowOne.Cells[2].Value = item?.SelectToken("packId");
                rowOne.Cells[3].Value = "删除";
                PackLinkDeviceList_DataGridView.Rows.Add(rowOne);
            }

            return linkedDeviceCount;
        }

        #endregion



        #region 箱单绑定

        private void PackLink(String imei)
        {
            int deviceCount = DeviceRefresh(_bigPackContext);
            PackService packService = new PackService();

            // 如果大箱单下没有，并且销售单没有大箱单，说明此销售订单没有大箱单记录
            if (deviceCount <= 0 && !_jTokenBigPack.HasValues)
            {
                if (SaleOrderInfo == null) return;
                // 调用生成大箱单的接口，并且刷新UI
                packService.GenerateBigPack(_loginInfo, SaleOrderInfo.Id);
                int res = RefreshBigPackList(null, null);
                if (res != 1)
                {
                    MessageBox.Show(@"创建大箱单失败");
                    return;
                }
            }

            // 如果存在大箱单，但没有设备，则说明是进到新大箱单里了，不需要创建新大箱单

            // 如果当前切换的大箱单绑定的设备数量小于最大装箱数量，并且该销售订单生成了新的大箱单
            // 如果当前切换的大箱单绑定的设备数量小于最大装箱数量，并且该销售订单并没有生成新的大箱单(有可绑定设备的大箱单)
            if (deviceCount < Int32.Parse(textBox2.Text) && _bigPackContext?.PackId != string.Empty)
            {
                packService.LinkDeviceToBigPack(_loginInfo, imei, _bigPackContext?.PackId);
                deviceCount = DeviceRefresh(_bigPackContext);
            }

            // 绑定之后还是未满，结束。
            if (deviceCount < int.Parse(textBox2.Text)) return;

            // 如果满了，先打印，然后查询销售单下的设备，如果设备已达到销售订单计划数量上限，则不再创建新订单, 并提示用户
            new CodeScanHelper().PrintLabel(_rep);
            if ((_jTokenBigPack ?? -1).Count() >= int.Parse(textBox3.Text))
            {
                MessageBox.Show(@"温馨提示：大箱单数量已经达到预设数量");
                return;
            }

            if (SaleOrderInfo == null) return;
            // 反之，则创建新箱单，并刷新UI。
            packService.GenerateBigPack(_loginInfo, SaleOrderInfo.Id);
            RefreshBigPackList(null, null);
        }

        #endregion




        private void DataCache_ToolTrips_Button_Click(object sender, EventArgs e)
        {
            new CodeScanHelper().PrintLabel(_rep);
        }
    }
}
