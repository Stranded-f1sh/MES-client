
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class SqLiteDataBaseOperateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("生产数据缓存");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("打印机设置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("用户密码缓存");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("表格", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MES缓存数据库", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqLiteDataBaseOperateForm));
            this.SqLiteDataBase_TreeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateProductOrder_Btn = new System.Windows.Forms.ToolStripButton();
            this.LoadSaleOrders_btn = new System.Windows.Forms.ToolStripButton();
            this.OrderSelect_Btn = new System.Windows.Forms.ToolStripButton();
            this.Find_Button = new System.Windows.Forms.ToolStripButton();
            this.DBCache_Button = new System.Windows.Forms.ToolStripButton();
            this.deleteData_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BackPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.NextPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Setting_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SqliteTable_listview = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SqLiteDataBase_TreeView
            // 
            this.SqLiteDataBase_TreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.SqLiteDataBase_TreeView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SqLiteDataBase_TreeView.FullRowSelect = true;
            this.SqLiteDataBase_TreeView.HotTracking = true;
            this.SqLiteDataBase_TreeView.Indent = 13;
            this.SqLiteDataBase_TreeView.ItemHeight = 18;
            this.SqLiteDataBase_TreeView.Location = new System.Drawing.Point(0, 85);
            this.SqLiteDataBase_TreeView.Name = "SqLiteDataBase_TreeView";
            treeNode1.BackColor = System.Drawing.Color.AliceBlue;
            treeNode1.Name = "DataCache";
            treeNode1.Text = "生产数据缓存";
            treeNode2.BackColor = System.Drawing.Color.AliceBlue;
            treeNode2.Name = "PrinterSetting";
            treeNode2.Text = "打印机设置";
            treeNode3.BackColor = System.Drawing.Color.AliceBlue;
            treeNode3.Name = "UserPassWdCache";
            treeNode3.Text = "用户密码缓存";
            treeNode4.BackColor = System.Drawing.Color.AliceBlue;
            treeNode4.Name = "Table";
            treeNode4.Text = "表格";
            treeNode5.BackColor = System.Drawing.Color.AliceBlue;
            treeNode5.Name = "MESDataBase";
            treeNode5.Text = "MES缓存数据库";
            this.SqLiteDataBase_TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.SqLiteDataBase_TreeView.ShowNodeToolTips = true;
            this.SqLiteDataBase_TreeView.Size = new System.Drawing.Size(146, 534);
            this.SqLiteDataBase_TreeView.TabIndex = 0;
            this.SqLiteDataBase_TreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.SqLiteDataBase_TreeView_AfterLabelEdit);
            this.SqLiteDataBase_TreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SqLiteDataBase_TreeView_NodeMouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateProductOrder_Btn,
            this.LoadSaleOrders_btn,
            this.OrderSelect_Btn,
            this.Find_Button,
            this.DBCache_Button,
            this.deleteData_Button,
            this.toolStripSeparator3,
            this.BackPage_Btn,
            this.NextPage_Btn,
            this.toolStripSeparator1,
            this.Setting_Button,
            this.toolStripButton2,
            this.toolStripSeparator,
            this.toolStripButton6,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(-3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1097, 85);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateProductOrder_Btn
            // 
            this.CreateProductOrder_Btn.AutoSize = false;
            this.CreateProductOrder_Btn.Image = ((System.Drawing.Image)(resources.GetObject("CreateProductOrder_Btn.Image")));
            this.CreateProductOrder_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateProductOrder_Btn.Name = "CreateProductOrder_Btn";
            this.CreateProductOrder_Btn.Size = new System.Drawing.Size(84, 68);
            this.CreateProductOrder_Btn.Text = "创建工单";
            this.CreateProductOrder_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // LoadSaleOrders_btn
            // 
            this.LoadSaleOrders_btn.AutoSize = false;
            this.LoadSaleOrders_btn.Image = ((System.Drawing.Image)(resources.GetObject("LoadSaleOrders_btn.Image")));
            this.LoadSaleOrders_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadSaleOrders_btn.Name = "LoadSaleOrders_btn";
            this.LoadSaleOrders_btn.Size = new System.Drawing.Size(84, 68);
            this.LoadSaleOrders_btn.Text = "加载销售单(&N)";
            this.LoadSaleOrders_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoadSaleOrders_btn.ToolTipText = "加载工单(N)";
            // 
            // OrderSelect_Btn
            // 
            this.OrderSelect_Btn.AutoSize = false;
            this.OrderSelect_Btn.Image = ((System.Drawing.Image)(resources.GetObject("OrderSelect_Btn.Image")));
            this.OrderSelect_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OrderSelect_Btn.Name = "OrderSelect_Btn";
            this.OrderSelect_Btn.Size = new System.Drawing.Size(84, 68);
            this.OrderSelect_Btn.Text = "工单查询";
            this.OrderSelect_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OrderSelect_Btn.ToolTipText = "工单查询";
            // 
            // Find_Button
            // 
            this.Find_Button.AutoSize = false;
            this.Find_Button.Image = ((System.Drawing.Image)(resources.GetObject("Find_Button.Image")));
            this.Find_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Find_Button.Name = "Find_Button";
            this.Find_Button.Size = new System.Drawing.Size(84, 68);
            this.Find_Button.Text = "IMEI查找";
            this.Find_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // DBCache_Button
            // 
            this.DBCache_Button.AutoSize = false;
            this.DBCache_Button.Image = ((System.Drawing.Image)(resources.GetObject("DBCache_Button.Image")));
            this.DBCache_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DBCache_Button.Name = "DBCache_Button";
            this.DBCache_Button.Size = new System.Drawing.Size(84, 68);
            this.DBCache_Button.Text = "报工缓存";
            this.DBCache_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // deleteData_Button
            // 
            this.deleteData_Button.AutoSize = false;
            this.deleteData_Button.Image = ((System.Drawing.Image)(resources.GetObject("deleteData_Button.Image")));
            this.deleteData_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteData_Button.Name = "deleteData_Button";
            this.deleteData_Button.Size = new System.Drawing.Size(84, 68);
            this.deleteData_Button.Text = "删除";
            this.deleteData_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteData_Button.Click += new System.EventHandler(this.deleteData_Button_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 85);
            // 
            // BackPage_Btn
            // 
            this.BackPage_Btn.AutoSize = false;
            this.BackPage_Btn.Enabled = false;
            this.BackPage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("BackPage_Btn.Image")));
            this.BackPage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackPage_Btn.Name = "BackPage_Btn";
            this.BackPage_Btn.Size = new System.Drawing.Size(84, 68);
            this.BackPage_Btn.Text = "上一页";
            this.BackPage_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BackPage_Btn.ToolTipText = "上一页";
            // 
            // NextPage_Btn
            // 
            this.NextPage_Btn.AutoSize = false;
            this.NextPage_Btn.Enabled = false;
            this.NextPage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("NextPage_Btn.Image")));
            this.NextPage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextPage_Btn.Name = "NextPage_Btn";
            this.NextPage_Btn.Size = new System.Drawing.Size(84, 68);
            this.NextPage_Btn.Text = "下一页";
            this.NextPage_Btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 85);
            // 
            // Setting_Button
            // 
            this.Setting_Button.AutoSize = false;
            this.Setting_Button.Image = ((System.Drawing.Image)(resources.GetObject("Setting_Button.Image")));
            this.Setting_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Setting_Button.Name = "Setting_Button";
            this.Setting_Button.Size = new System.Drawing.Size(84, 68);
            this.Setting_Button.Text = "设置";
            this.Setting_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 68);
            this.toolStripButton2.Text = "导出";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 85);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(84, 68);
            this.toolStripButton6.Text = "帮助";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 85);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "设备号";
            this.columnHeader1.Text = "设备号";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IMSI";
            this.columnHeader2.Width = 88;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "录入时间";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "在线状态";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "数据上报时间";
            this.columnHeader5.Width = 147;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "数据值";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "操作员";
            this.columnHeader7.Width = 115;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "平台类型";
            this.columnHeader8.Width = 103;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Tag = "设备号";
            this.columnHeader9.Text = "设备号";
            this.columnHeader9.Width = 103;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "IMSI";
            this.columnHeader10.Width = 88;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "录入时间";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "在线状态";
            this.columnHeader12.Width = 109;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "数据上报时间";
            this.columnHeader13.Width = 147;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "数据值";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "操作员";
            this.columnHeader15.Width = 115;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "平台类型";
            this.columnHeader16.Width = 103;
            // 
            // SqliteTable_listview
            // 
            this.SqliteTable_listview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SqliteTable_listview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SqliteTable_listview.FullRowSelect = true;
            this.SqliteTable_listview.HideSelection = false;
            this.SqliteTable_listview.Location = new System.Drawing.Point(144, 85);
            this.SqliteTable_listview.Name = "SqliteTable_listview";
            this.SqliteTable_listview.Size = new System.Drawing.Size(950, 534);
            this.SqliteTable_listview.SmallImageList = this.imageList1;
            this.SqliteTable_listview.TabIndex = 29;
            this.SqliteTable_listview.UseCompatibleStateImageBehavior = false;
            this.SqliteTable_listview.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(18, 18);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SqLiteDataBaseOperateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 619);
            this.Controls.Add(this.SqliteTable_listview);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SqLiteDataBase_TreeView);
            this.Name = "SqLiteDataBaseOperateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SqLiteDataBaseOperateForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SqLiteDataBase_TreeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateProductOrder_Btn;
        private System.Windows.Forms.ToolStripButton LoadSaleOrders_btn;
        private System.Windows.Forms.ToolStripButton OrderSelect_Btn;
        private System.Windows.Forms.ToolStripButton Find_Button;
        private System.Windows.Forms.ToolStripButton DBCache_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BackPage_Btn;
        private System.Windows.Forms.ToolStripButton NextPage_Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Setting_Button;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ListView SqliteTable_listview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton deleteData_Button;
    }
}