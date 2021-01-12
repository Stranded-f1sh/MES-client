using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Service;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class SqLiteDataBaseOperateForm : Form
    {
        public SqLiteDataBaseOperateForm()
        {
            InitializeComponent();
        }


        private void SqLiteDataBase_TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
        }

        private void SqLiteDataBase_TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (SqLiteDataBase_TreeView?.SelectedNode?.Name)
            {
                case "DataCache":
                    InitTable();
                    ReFreshTable();
                    break;
            }
            
        }



        private void InitTable()
        {
            if (SqliteTable_listview == null) return;
            SqliteTable_listview.Items.Clear();
            SqliteTable_listview.Columns.Clear();
            SqliteTable_listview.GridLines = true;
            SqliteTable_listview.Columns.Add("id", 80);
            SqliteTable_listview.Columns.Add("imei", 135);
            SqliteTable_listview.Columns.Add("imsi", 80);
            SqliteTable_listview.Columns.Add("passed", 105);
            SqliteTable_listview.Columns.Add("orderId", 80);
            SqliteTable_listview.Columns.Add("userId", 80);
            SqliteTable_listview.Columns.Add("processId", 80);
            SqliteTable_listview.Columns.Add("reasonId", 80);
            SqliteTable_listview.Columns.Add("reasonContext", 80);
            SqliteTable_listview.Columns.Add("baoGongStatus", 105);
        }



        private void ReFreshTable()
        {
            DataCacheService dataCacheService = new DataCacheService();
            DataSet ds = dataCacheService.FindAllDataRecord();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr?[0]?.ToString();
                item.SubItems.Add(dr?[1]?.ToString());
                item.SubItems.Add(dr?[2]?.ToString());
                item.SubItems.Add(dr?[3]?.ToString());
                item.SubItems.Add(dr?[4]?.ToString());
                item.SubItems.Add(dr?[5]?.ToString());
                item.SubItems.Add(dr?[6]?.ToString());
                item.SubItems.Add(dr?[7]?.ToString());
                item.SubItems.Add(dr?[8]?.ToString());
                item.SubItems.Add(dr?[9]?.ToString());
                SqliteTable_listview?.Items.Add(item);
            }

        }

        private void deleteData_Button_Click(object sender, EventArgs e)
        {
            if (SqliteTable_listview?.SelectedItems.Count == 0) return;

            if (MessageBox.Show(@"确认删除？", @"此删除不可恢复", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            DataCacheService dataCacheService = new DataCacheService();
            dataCacheService.DeleteDeviceCacheById(int.Parse(SqliteTable_listview?.SelectedItems[0].SubItems[0].Text));
            InitTable();
            ReFreshTable();
        }
    }
}
