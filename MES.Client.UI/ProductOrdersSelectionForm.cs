using System;
using System.Drawing;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;


namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class ProductOrdersSelectionForm : Form
    {
        private readonly JToken _productOrders;
        private readonly Process _process;
        private int _index = -1;
        private bool _isFond;
        public ProductOrdersSelectionForm(JToken productOrders, Process process, String tipsSaleOrderNo)
        {
            _productOrders = productOrders;
            _process = process;
            InitializeComponent();

            if (tipsSaleOrderNo == String.Empty || _productOrders == null || ProductOrder_TextBox == null) return;
            foreach (var jTokenItem in _productOrders)
            {
                if (jTokenItem?.SelectToken("saleOrderno")?.ToString() != tipsSaleOrderNo) continue;
                ProductOrder_TextBox.Text = jTokenItem?.SelectToken("id")?.ToString();
                break;
            }
        }


        private void ProductOrdersSelectionForm_Load(object sender, EventArgs e)
        {
            InitInfoTable();
            UpdateTable();
            ProductOrderList?.ClearSelection();
            ProductOrder_TextBox?.Select();
        }



        #region SetColumns

        private void InitInfoTable()
        {
            if (ProductOrderList == null) return;
            ProductOrderList.Columns.Add("id", "工单id");
            ProductOrderList.Columns.Add("orderNo", "工单号");
            ProductOrderList.Columns.Add("saleOrderid", "销售单id");
            ProductOrderList.Columns.Add("companyFullName", "客户公司名称");
            ProductOrderList.Columns.Add("deviceModel", "设备型号");
            ProductOrderList.Columns.Add("buyNumber", "购买数量");
            ProductOrderList.Columns.Add("orderDate", "订单日期");
            // ProductOrderList.Columns.Add("customerDeviceName", "产品名称");

            // 设置自动列宽
            ProductOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置字体样式
            Font font = new Font("微软雅黑", 8);
            ProductOrderList.Font = font;

            //设置文本居中
            if (ProductOrderList.RowsDefaultCellStyle != null)
            {
                ProductOrderList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }
        #endregion



        #region SetTableData


        private void UpdateTable()
        {
            if (_productOrders == null) return;
            if (ProductOrderList == null) return;

            foreach (var i in _productOrders)
            {
                int index = ProductOrderList.Rows.Add();
                if (ProductOrderList.Rows[index].Cells[0] != null)
                {
                    ProductOrderList.Rows[index].Cells[0].Value = MyJsonConverter.JTokenTransformer(i?["id"]);
                }

                if (ProductOrderList.Rows[index].Cells[1] != null)
                {
                    ProductOrderList.Rows[index].Cells[1].Value = MyJsonConverter.JTokenTransformer(i?["orderNo"]);
                }

                if (ProductOrderList.Rows[index].Cells[2] != null)
                {
                    ProductOrderList.Rows[index].Cells[2].Value = MyJsonConverter.JTokenTransformer(i?["saleOrderid"]);
                }

                if (ProductOrderList.Rows[index].Cells[3] != null)
                {
                    ProductOrderList.Rows[index].Cells[3].Value = MyJsonConverter.JTokenTransformer(i?["companyFullName"]);
                }

                if (ProductOrderList.Rows[index].Cells[4] != null)
                {
                    ProductOrderList.Rows[index].Cells[4].Value = MyJsonConverter.JTokenTransformer(i?["deviceModel"]);
                }

                if (ProductOrderList.Rows[index].Cells[5] != null)
                {
                    ProductOrderList.Rows[index].Cells[5].Value = MyJsonConverter.JTokenTransformer(i?["buyNumber"]);
                }

                if (ProductOrderList.Rows[index].Cells[6] != null)
                {

                    DateTime _dtStart = new DateTime(1970, 1, 1, 8, 0, 0);
                    ProductOrderList.Rows[index].Cells[6].Value = _dtStart.AddMilliseconds(Convert.ToInt64(i?["orderDate"]));
                }
            }
        }

        #endregion



        #region 查找工单


        private void Go_Button_Click(object sender, EventArgs e)
        {
            if (ProductOrder_TextBox == null | ProductOrder_TextBox?.Text?.Length == 0) return;
            ProductOrderList?.ClearSelection();
            _isFond = false;
            _index = 0;
            for (int i = 0; i < ProductOrderList?.Rows.Count; i++)
            {
                if (ProductOrderList.Rows[i].Cells[0]?.Value != null)
                {
                    if (ProductOrderList.Rows[i].Cells[0].Value.ToString() == ProductOrder_TextBox.Text)
                    {
                        ProductOrderList.Rows[i].Selected = true; // 选中
                        ProductOrderList.FirstDisplayedScrollingRowIndex = i; // 定位
                        MessageBox.Show(@"已找到工单id为" + ProductOrder_TextBox.Text + @"的工单");
                        _isFond = true;
                        break;
                    }

                    ProductOrderList.Rows[i].Selected = false;
                    _index++;
                }
            }

            if (_isFond)
            {
                Submit_Button?.Select();
                return;
            }
            MessageBox.Show(@"未找到工单id为" + ProductOrder_TextBox.Text + @"的工单");
        }

        #endregion



        private void Submit_Button_Click(object sender, EventArgs e)
        {
            if (ProductOrderList?.CurrentRow == null) return;
            if (_isFond == false)
            {
                MessageBox.Show(@"未选择有效项！");
                return;
            }

            ProductOrder productOrderInfo = new ProductOrder
            {
                OrderId = int.Parse(ProductOrderList.Rows[_index].Cells["Id"]?.Value?.ToString() ?? string.Empty),
                SaleOrderId = int.Parse(ProductOrderList.Rows[_index].Cells["saleOrderId"]?.Value?.ToString() ?? string.Empty),
                OrderNo = ProductOrderList.Rows[_index].Cells["orderNo"]?.Value?.ToString() ?? string.Empty,
                CompanyFullName = ProductOrderList.Rows[_index].Cells["companyFullName"]?.Value?.ToString() ?? string.Empty,
                DeviceModel = ProductOrderList.Rows[_index].Cells["deviceModel"]?.Value?.ToString() ?? string.Empty,
                BuyNumber = int.Parse(ProductOrderList.Rows[_index].Cells["buyNumber"]?.Value?.ToString() ?? string.Empty),
                BuyDate = Convert.ToDateTime(ProductOrderList.Rows[_index].Cells["orderDate"]?.Value?.ToString())
            };


            switch (_process?.SelectedProcessName)
            {
                case ProcessNameEnum.CodeRegistration:
                    CodeRegistrationForm codeRegistrationForm = (CodeRegistrationForm) this.Owner;
                    if (codeRegistrationForm?.ProductOrderInfo != null)
                    {
                        codeRegistrationForm.ProductOrderInfo = productOrderInfo;
                    }
                    break;
                case ProcessNameEnum.Pack:
                    PackForm packForm = (PackForm) this.Owner;
                    if (packForm?.ProductOrderInfo != null)
                    {
                        packForm.ProductOrderInfo = productOrderInfo;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.Close();
        }


        private void ProductOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isFond = true;
        }



        private void ProductOrder_TextBox_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            Go_Button_Click(sender, eventArgs);
        }


        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
