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
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using Newtonsoft.Json.Linq;


namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class ProcessSelectionForm : Form
    {
        private readonly LoginInfo _loginInfo;
        private JToken _productOrders;
        public ProcessSelectionForm(LoginInfo loginInfo)
        {
            this._loginInfo = loginInfo;
            InitializeComponent();
            ButtonInit();
            ButtonIsEnableInit();
        }

        private void ProcessSelectionForm_Load(object sender, EventArgs e)
        {
            // 加载缓存工单
            ProductOrderService productOrderService = new ProductOrderService();
            _productOrders = productOrderService.GetProductOrders(_loginInfo);

            // 加载缓存销售单
        }



        #region 按钮初始化
        
        
        private void ButtonInit()
        {
            if (BurnConfigurition_Button == null) return;
            BurnConfigurition_Button.BackColor = Color.White;
            BurnConfigurition_Button.ForeColor = Color.Black;
            BurnConfigurition_Button.Enabled = false;
            

            if (CodeRegistration_Button == null) return;
            CodeRegistration_Button.BackColor = Color.White;
            CodeRegistration_Button.Enabled = false;
            CodeRegistration_Button.ForeColor = Color.Black;

            if (PowerConsumption_Button == null) return;
            PowerConsumption_Button.BackColor = Color.White;
            PowerConsumption_Button.Enabled = false;
            PowerConsumption_Button.ForeColor = Color.Black;

            if (SensorCalibration_Button == null) return;
            SensorCalibration_Button.BackColor = Color.White;
            SensorCalibration_Button.Enabled = false;
            SensorCalibration_Button.ForeColor = Color.Black;

            if (Assembly_Button == null) return;
            Assembly_Button.BackColor = Color.White;
            Assembly_Button.Enabled = false;
            Assembly_Button.ForeColor = Color.Black;

            if (WarehouseInspection_Button == null) return;
            WarehouseInspection_Button.BackColor = Color.White;
            WarehouseInspection_Button.Enabled = false;
            WarehouseInspection_Button.ForeColor = Color.Black;

            if (OutboundInspection_Button == null) return;
            OutboundInspection_Button.BackColor = Color.White;
            OutboundInspection_Button.Enabled = false;
            OutboundInspection_Button.ForeColor = Color.Black;

            if (Pack_Button == null) return;
            Pack_Button.BackColor = Color.White;
            Pack_Button.Enabled = false;
            Pack_Button.ForeColor = Color.Black;

            if (OutBound_Button == null) return;
            OutBound_Button.BackColor = Color.White;
            OutBound_Button.Enabled = false;
            OutBound_Button.ForeColor = Color.Black;

            if (Ship_Button == null) return;
            Ship_Button.BackColor = Color.White;
            Ship_Button.Enabled = false;
            Ship_Button.ForeColor = Color.Black;

            if (Repair_Button == null) return;
            Repair_Button.BackColor = Color.White;
            Repair_Button.Enabled = false;
            Repair_Button.ForeColor = Color.Black;

            if (button12 == null) return;
            button12.BackColor = Color.White;
            button12.Enabled = false;
            button12.ForeColor = Color.Black;
        }

        #endregion



        #region 可用按钮初始化

        private void ButtonIsEnableInit()
        {
            if (_loginInfo?.UserProcessPrivilege == null) return;
            if (_loginInfo.UserProcessPrivilege.Contains("烧录配置"))
            {
                BurnConfigurition_Button.Enabled = true;
                BurnConfigurition_Button.ForeColor = Color.DarkGreen;
                BurnConfigurition_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("编码注册"))
            {
                CodeRegistration_Button.Enabled = true;
                CodeRegistration_Button.ForeColor = Color.DarkGreen;
                CodeRegistration_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("功耗"))
            {
                PowerConsumption_Button.Enabled = true;
                PowerConsumption_Button.ForeColor = Color.DarkGreen;
                PowerConsumption_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("传感器校验"))
            {
                SensorCalibration_Button.Enabled = true;
                SensorCalibration_Button.ForeColor = Color.DarkGreen;
                SensorCalibration_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("组装"))
            {
                Assembly_Button.Enabled = true;
                Assembly_Button.ForeColor = Color.DarkGreen;
                Assembly_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("检验") && !_loginInfo.UserProcessPrivilege.Contains("成品"))
            {
                WarehouseInspection_Button.Enabled = true;
                WarehouseInspection_Button.ForeColor = Color.DarkGreen;
                WarehouseInspection_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("成品"))
            {
                OutboundInspection_Button.Enabled = true;
                OutboundInspection_Button.ForeColor = Color.DarkGreen;
                OutboundInspection_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("包装"))
            {
                Pack_Button.Enabled = true;
                Pack_Button.ForeColor = Color.DarkGreen;
                Pack_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("出库"))
            {
                OutBound_Button.Enabled = true;
                OutBound_Button.ForeColor = Color.DarkGreen;
                OutBound_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("发货"))
            {
                Ship_Button.Enabled = true;
                Ship_Button.ForeColor = Color.DarkGreen;
                Ship_Button.BackColor = Color.WhiteSmoke;
            }
            if (_loginInfo.UserProcessPrivilege.Contains("维修"))
            {
                Repair_Button.Enabled = true;
                Repair_Button.ForeColor = Color.DarkGreen;
                Repair_Button.BackColor = Color.WhiteSmoke;
            }
        }



        #endregion




        // 编码注册
        private void CodeRegistration_Button_Click(object sender, EventArgs e)
        {
            Process process = new Process {SelectedProcessName = ProcessNameEnum.CodeRegistration};
            CodeRegistrationForm codeRegistrationForm = new CodeRegistrationForm(_loginInfo, process, _productOrders);
            new Thread(delegate () 
            {
                codeRegistrationForm.ShowDialog();
                    
            }).Start();
            this.Close();
        }


        // 出库
        private void OutBound_Button_Click(object sender, EventArgs e)
        {
            Process process = new Process { SelectedProcessName = ProcessNameEnum.OutBound };
            OutBoundForm outBoundForm = new OutBoundForm(_loginInfo, process);
            new Thread(delegate () { outBoundForm.ShowDialog(); }).Start();
            this.Close();
        }

        // 包装
        private void Pack_Button_Click(object sender, EventArgs e)
        {
            Process process = new Process { SelectedProcessName = ProcessNameEnum.Pack };
            PackForm packForm = new PackForm(_loginInfo, process, _productOrders);
            new Thread(delegate () { packForm.ShowDialog(); }).Start();
            this.Close();
        }



    }
}
