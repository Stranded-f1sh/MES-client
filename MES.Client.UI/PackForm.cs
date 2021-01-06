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

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class PackForm : Form
    {
        private readonly JToken _productOrders; // 缓存的所有工单
        public ProductOrder ProductOrderInfo; // 切换的工单实体类
        private readonly Process _process;
        public PackForm(LoginInfo loginInfo, Process process, JToken productOrders)
        {
            _productOrders = productOrders;
            _process = process;
            InitializeComponent();
        }

        private void LoadWorkOrder_btn_Click(object sender, EventArgs e)
        {
            ProductOrderInfo = new ProductOrder();
            ProductOrdersSelectionForm productOrdersSelectionForm = new ProductOrdersSelectionForm(_productOrders, _process)
            {
                Owner = this
            };
            productOrdersSelectionForm.ShowDialog();
        }
    }
}
