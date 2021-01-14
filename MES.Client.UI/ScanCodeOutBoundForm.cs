using System;
using System.Threading;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class ScanCodeOutBoundForm : Form
    {
        private int _insertId;
        private readonly SaleOrder _saleOrderInfo;
        private readonly LoginInfo _loginInfo;


        public ScanCodeOutBoundForm(LoginInfo loginInfo, SaleOrder saleOrderInfo)
        {
            _saleOrderInfo = saleOrderInfo;
            _loginInfo = loginInfo;

            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }


        private void imeiInput_TextBox_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            DataGridViewInsert(imeiInput_TextBox?.Text);
        }


        private void DataGridViewInsert(String imei)
        {
            if(cacheList_DataGirdView == null) return;
            DataGridViewRow rowOne = new DataGridViewRow();

            rowOne.CreateCells(cacheList_DataGirdView);
            rowOne.Cells[0].Value = _insertId;
            rowOne.Cells[1].Value = imei;
            rowOne.Cells[2].Value = "金宇";
            rowOne.Cells[3].Value = "删除";

            cacheList_DataGirdView.Rows.Add(rowOne);
            imeiInput_TextBox?.Clear();
            _insertId++;
        }

        private void cacheList_DataGirdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e?.RowIndex < 0) return;
            DataGridViewColumn column = cacheList_DataGirdView?.Columns[e.ColumnIndex];
            if (!(column is DataGridViewButtonColumn)) return;
            DataGridViewRow rowOne = new DataGridViewRow();
            cacheList_DataGirdView.Rows.RemoveAt(e.RowIndex);
        }


        private void outBound_Button_Click(object sender, EventArgs e)
        {
            // richTextBox1?.Clear();
            bool canActive = MessageBox.Show(@"出库后是否转客户？", "", MessageBoxButtons.OKCancel) == DialogResult.OK;
            bool canDelete = MessageBox.Show(@"出库后是否删除注册？", "", MessageBoxButtons.OKCancel) == DialogResult.OK;
            if (MessageBox.Show(@"确定要执行此操作吗？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            OutBoundService outBoundService = new OutBoundService();
            SaleOrderService saleOrderService = new SaleOrderService();
            RegistrationService registrationService = new RegistrationService();

            int row = cacheList_DataGirdView.Rows.Count;//得到总行数 
            richTextBox1.HideSelection = false;
            new Thread(() =>
            {
                for (int i = 0; i < row - 1; i++)
                {
                    richTextBox1.AppendText("*************************** \r\n");
                    string imei = cacheList_DataGirdView.Rows[i].Cells[1]?.Value?.ToString();

                    JToken jTokenPostOutBound = outBoundService.PostOutBound(_loginInfo, new Device{Imei = imei });
                    string postOutBound = MyJsonConverter.JTokenTransformer(jTokenPostOutBound);

                    if (postOutBound == "ok")
                    {
                        richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 出库成功 [" + imei + "]\r\n");
                    }
                    else
                    {
                        richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 出库失败 [" + imei + "]\r\n");
                    }
                    
                    
                    Thread.Sleep(50);
                    if (canActive)
                    {
                        JToken jTokenPublishDevice = saleOrderService.PublishDevice(_loginInfo, new Device {Imei = imei, SaleOrderId = _saleOrderInfo?.Id});
                        string publishDevice = MyJsonConverter.JTokenTransformer(jTokenPublishDevice);
                        if (publishDevice == "ok")
                        {
                            richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 转客户成功 [" + imei + "]\r\n");
                            
                        }
                        else
                        {
                            richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 转客户失败 [" + imei + "]\r\n");
                        }
                        Thread.Sleep(50);
                    }

                    if (canDelete)
                    {
                        JToken jTokenDelDevice = registrationService.DelDevice(_loginInfo, new Device {Imei = imei}, _saleOrderInfo);
                        string delDevice = MyJsonConverter.JTokenTransformer(jTokenDelDevice);
                        if (delDevice == "ok")
                        {
                            richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 删除成功[" + imei + "]\r\n");
                        }
                        else
                        {
                            richTextBox1.AppendText("[" + DateTime.Now.ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ") + "] 删除失败[" + imei + "]\r\n");
                        }
                        
                        Thread.Sleep(50);
                    }
                }
                richTextBox1.AppendText(" Done！ \r\n");
            }).Start();
        }
    }
}
