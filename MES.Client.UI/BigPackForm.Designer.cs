
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class BigPackForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigPackForm));
            this.panel6 = new System.Windows.Forms.Panel();
            this.PackLinkDeviceList_DataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BigPackId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateProductOrder_Btn = new System.Windows.Forms.ToolStripButton();
            this.LoadSaleOrders_btn = new System.Windows.Forms.ToolStripButton();
            this.LoadFrxFile_Button = new System.Windows.Forms.ToolStripButton();
            this.OrderSelect_Btn = new System.Windows.Forms.ToolStripButton();
            this.Find_Button = new System.Windows.Forms.ToolStripButton();
            this.DBCache_Button = new System.Windows.Forms.ToolStripButton();
            this.ScanCode_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BackPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.NextPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Setting_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.DataCache_ToolTrips_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.command_TextBox = new System.Windows.Forms.RichTextBox();
            this.BackProcessSelection = new System.Windows.Forms.ToolStripButton();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackLinkDeviceList_DataGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.PackLinkDeviceList_DataGridView);
            this.panel6.Location = new System.Drawing.Point(517, 134);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(461, 488);
            this.panel6.TabIndex = 40;
            // 
            // PackLinkDeviceList_DataGridView
            // 
            this.PackLinkDeviceList_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PackLinkDeviceList_DataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PackLinkDeviceList_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PackLinkDeviceList_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.PackLinkDeviceList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PackLinkDeviceList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.imei,
            this.BigPackId,
            this.operate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PackLinkDeviceList_DataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.PackLinkDeviceList_DataGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.PackLinkDeviceList_DataGridView.Location = new System.Drawing.Point(5, 2);
            this.PackLinkDeviceList_DataGridView.Name = "PackLinkDeviceList_DataGridView";
            this.PackLinkDeviceList_DataGridView.RowTemplate.Height = 20;
            this.PackLinkDeviceList_DataGridView.Size = new System.Drawing.Size(447, 479);
            this.PackLinkDeviceList_DataGridView.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            // 
            // imei
            // 
            this.imei.HeaderText = "imei号";
            this.imei.Name = "imei";
            // 
            // BigPackId
            // 
            this.BigPackId.HeaderText = "大箱单id";
            this.BigPackId.Name = "BigPackId";
            // 
            // operate
            // 
            this.operate.HeaderText = "操作";
            this.operate.Name = "operate";
            this.operate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operate.Text = "删除";
            this.operate.ToolTipText = "删除";
            this.operate.UseColumnTextForButtonValue = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(979, 177);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 445);
            this.panel5.TabIndex = 39;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(979, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 43);
            this.panel4.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "产品信息";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(979, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 43);
            this.panel3.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前销售单:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(96, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(517, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 43);
            this.panel2.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "设备列表";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateProductOrder_Btn,
            this.LoadSaleOrders_btn,
            this.LoadFrxFile_Button,
            this.OrderSelect_Btn,
            this.Find_Button,
            this.DBCache_Button,
            this.ScanCode_Button,
            this.toolStripSeparator3,
            this.BackPage_Btn,
            this.NextPage_Btn,
            this.toolStripSeparator1,
            this.Setting_Button,
            this.toolStripButton2,
            this.toolStripSeparator,
            this.DataCache_ToolTrips_Button,
            this.BackProcessSelection,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(4, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1223, 87);
            this.toolStrip1.TabIndex = 34;
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
            this.LoadSaleOrders_btn.Click += new System.EventHandler(this.LoadSaleOrders_btn_Click);
            // 
            // LoadFrxFile_Button
            // 
            this.LoadFrxFile_Button.AutoSize = false;
            this.LoadFrxFile_Button.Image = ((System.Drawing.Image)(resources.GetObject("LoadFrxFile_Button.Image")));
            this.LoadFrxFile_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadFrxFile_Button.Name = "LoadFrxFile_Button";
            this.LoadFrxFile_Button.Size = new System.Drawing.Size(84, 68);
            this.LoadFrxFile_Button.Text = "导入Frx文件";
            this.LoadFrxFile_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoadFrxFile_Button.Click += new System.EventHandler(this.LoadFrxFile_Button_Click);
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
            // ScanCode_Button
            // 
            this.ScanCode_Button.AutoSize = false;
            this.ScanCode_Button.Image = ((System.Drawing.Image)(resources.GetObject("ScanCode_Button.Image")));
            this.ScanCode_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScanCode_Button.Name = "ScanCode_Button";
            this.ScanCode_Button.Size = new System.Drawing.Size(84, 68);
            this.ScanCode_Button.Text = "扫码出库";
            this.ScanCode_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ScanCode_Button.ToolTipText = "扫码出库";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 87);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 87);
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
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 87);
            // 
            // DataCache_ToolTrips_Button
            // 
            this.DataCache_ToolTrips_Button.AutoSize = false;
            this.DataCache_ToolTrips_Button.Image = ((System.Drawing.Image)(resources.GetObject("DataCache_ToolTrips_Button.Image")));
            this.DataCache_ToolTrips_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DataCache_ToolTrips_Button.Name = "DataCache_ToolTrips_Button";
            this.DataCache_ToolTrips_Button.Size = new System.Drawing.Size(84, 68);
            this.DataCache_ToolTrips_Button.Text = "数据缓存";
            this.DataCache_ToolTrips_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DataCache_ToolTrips_Button.Click += new System.EventHandler(this.DataCache_ToolTrips_Button_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 87);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 43);
            this.panel1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "箱单信息";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(3, 134);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(513, 288);
            this.panel7.TabIndex = 41;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.comboBox1);
            this.panel9.Location = new System.Drawing.Point(73, -1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(344, 43);
            this.panel9.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.previewControl1);
            this.panel8.Location = new System.Drawing.Point(73, 41);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(344, 239);
            this.panel8.TabIndex = 0;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(0, 4);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(356, 227);
            this.previewControl1.StatusbarVisible = false;
            this.previewControl1.TabIndex = 0;
            this.previewControl1.ToolbarVisible = false;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.VistaGlass;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.groupBox1);
            this.panel10.Location = new System.Drawing.Point(3, 422);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(513, 200);
            this.panel10.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(73, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 130);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "大箱计划包装数量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "最大装箱数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "绑定设备输入";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(309, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(62, 21);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(309, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "10";
            // 
            // command_TextBox
            // 
            this.command_TextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.command_TextBox.ForeColor = System.Drawing.Color.Black;
            this.command_TextBox.Location = new System.Drawing.Point(3, 628);
            this.command_TextBox.Name = "command_TextBox";
            this.command_TextBox.Size = new System.Drawing.Size(1220, 107);
            this.command_TextBox.TabIndex = 43;
            this.command_TextBox.Text = "command 命令";
            // 
            // BackProcessSelection
            // 
            this.BackProcessSelection.AutoSize = false;
            this.BackProcessSelection.Image = ((System.Drawing.Image)(resources.GetObject("BackProcessSelection.Image")));
            this.BackProcessSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackProcessSelection.Name = "BackProcessSelection";
            this.BackProcessSelection.Size = new System.Drawing.Size(84, 68);
            this.BackProcessSelection.Text = "返回工序选择";
            this.BackProcessSelection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BackProcessSelection.Click += new System.EventHandler(this.BackProcessSelection_Click);
            // 
            // BigPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 738);
            this.Controls.Add(this.command_TextBox);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BigPackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BigPackForm";
            this.Load += new System.EventHandler(this.BigPackForm_Load);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PackLinkDeviceList_DataGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView PackLinkDeviceList_DataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateProductOrder_Btn;
        private System.Windows.Forms.ToolStripButton LoadSaleOrders_btn;
        private System.Windows.Forms.ToolStripButton OrderSelect_Btn;
        private System.Windows.Forms.ToolStripButton Find_Button;
        private System.Windows.Forms.ToolStripButton DBCache_Button;
        private System.Windows.Forms.ToolStripButton ScanCode_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BackPage_Btn;
        private System.Windows.Forms.ToolStripButton NextPage_Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Setting_Button;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton DataCache_ToolTrips_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn BigPackId;
        private System.Windows.Forms.DataGridViewButtonColumn operate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox comboBox1;
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ToolStripButton LoadFrxFile_Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox command_TextBox;
        private System.Windows.Forms.ToolStripButton BackProcessSelection;
    }
}