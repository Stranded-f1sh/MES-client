
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class OutBoundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutBoundForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadSaleOrders_btn = new System.Windows.Forms.ToolStripButton();
            this.ScanCode_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BackProcessSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.IPAddress_Label = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.PlatformType_Label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BuyDate_Label = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BuyNumber_Label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DeviceModel_Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CompanyFullName_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.outBound_DataGirdView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handleResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outBoundUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Exit_Form = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outBound_DataGirdView)).BeginInit();
            this.SuspendLayout();
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
            this.LoadSaleOrders_btn,
            this.ScanCode_Button,
            this.toolStripSeparator1,
            this.BackProcessSelection,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, -5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(970, 97);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
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
            this.ScanCode_Button.Click += new System.EventHandler(this.ScanCode_Button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 97);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 97);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 43);
            this.panel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(78, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前销售单:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(303, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 43);
            this.panel2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "出库列表";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(1, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 43);
            this.panel4.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "产品信息";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.IPAddress_Label);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.PlatformType_Label);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.BuyDate_Label);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.BuyNumber_Label);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.DeviceModel_Label);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.CompanyFullName_Label);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(1, 172);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 441);
            this.panel5.TabIndex = 32;
            // 
            // IPAddress_Label
            // 
            this.IPAddress_Label.AutoSize = true;
            this.IPAddress_Label.ForeColor = System.Drawing.Color.Maroon;
            this.IPAddress_Label.Location = new System.Drawing.Point(73, 157);
            this.IPAddress_Label.Name = "IPAddress_Label";
            this.IPAddress_Label.Size = new System.Drawing.Size(0, 12);
            this.IPAddress_Label.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "IP地址：";
            // 
            // PlatformType_Label
            // 
            this.PlatformType_Label.AutoSize = true;
            this.PlatformType_Label.ForeColor = System.Drawing.Color.Maroon;
            this.PlatformType_Label.Location = new System.Drawing.Point(73, 128);
            this.PlatformType_Label.Name = "PlatformType_Label";
            this.PlatformType_Label.Size = new System.Drawing.Size(0, 12);
            this.PlatformType_Label.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "平台类型：";
            // 
            // BuyDate_Label
            // 
            this.BuyDate_Label.AutoSize = true;
            this.BuyDate_Label.ForeColor = System.Drawing.Color.Maroon;
            this.BuyDate_Label.Location = new System.Drawing.Point(73, 101);
            this.BuyDate_Label.Name = "BuyDate_Label";
            this.BuyDate_Label.Size = new System.Drawing.Size(0, 12);
            this.BuyDate_Label.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "订单日期：";
            // 
            // BuyNumber_Label
            // 
            this.BuyNumber_Label.AutoSize = true;
            this.BuyNumber_Label.ForeColor = System.Drawing.Color.Maroon;
            this.BuyNumber_Label.Location = new System.Drawing.Point(75, 72);
            this.BuyNumber_Label.Name = "BuyNumber_Label";
            this.BuyNumber_Label.Size = new System.Drawing.Size(0, 12);
            this.BuyNumber_Label.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "设备数量：";
            // 
            // DeviceModel_Label
            // 
            this.DeviceModel_Label.AutoSize = true;
            this.DeviceModel_Label.ForeColor = System.Drawing.Color.Maroon;
            this.DeviceModel_Label.Location = new System.Drawing.Point(73, 44);
            this.DeviceModel_Label.Name = "DeviceModel_Label";
            this.DeviceModel_Label.Size = new System.Drawing.Size(0, 12);
            this.DeviceModel_Label.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "产品型号：";
            // 
            // CompanyFullName_Label
            // 
            this.CompanyFullName_Label.AutoSize = true;
            this.CompanyFullName_Label.ForeColor = System.Drawing.Color.Maroon;
            this.CompanyFullName_Label.Location = new System.Drawing.Point(71, 14);
            this.CompanyFullName_Label.Name = "CompanyFullName_Label";
            this.CompanyFullName_Label.Size = new System.Drawing.Size(0, 12);
            this.CompanyFullName_Label.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "客户名称：";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.outBound_DataGirdView);
            this.panel6.Location = new System.Drawing.Point(303, 130);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(665, 488);
            this.panel6.TabIndex = 33;
            // 
            // outBound_DataGirdView
            // 
            this.outBound_DataGirdView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outBound_DataGirdView.BackgroundColor = System.Drawing.Color.White;
            this.outBound_DataGirdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.outBound_DataGirdView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.outBound_DataGirdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outBound_DataGirdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.imei,
            this.imsi,
            this.userName,
            this.platform,
            this.handleResult,
            this.outBoundUser,
            this.operate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.outBound_DataGirdView.DefaultCellStyle = dataGridViewCellStyle6;
            this.outBound_DataGirdView.GridColor = System.Drawing.Color.Gainsboro;
            this.outBound_DataGirdView.Location = new System.Drawing.Point(2, 2);
            this.outBound_DataGirdView.Name = "outBound_DataGirdView";
            this.outBound_DataGirdView.RowTemplate.Height = 20;
            this.outBound_DataGirdView.Size = new System.Drawing.Size(656, 479);
            this.outBound_DataGirdView.TabIndex = 17;
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
            // imsi
            // 
            this.imsi.HeaderText = "imsi号";
            this.imsi.Name = "imsi";
            // 
            // userName
            // 
            this.userName.HeaderText = "客户名";
            this.userName.Name = "userName";
            // 
            // platform
            // 
            this.platform.HeaderText = "平台类型";
            this.platform.Name = "platform";
            // 
            // handleResult
            // 
            this.handleResult.HeaderText = "注册状态";
            this.handleResult.Name = "handleResult";
            // 
            // outBoundUser
            // 
            this.outBoundUser.HeaderText = "出库操作员";
            this.outBoundUser.Name = "outBoundUser";
            // 
            // operate
            // 
            this.operate.HeaderText = "操作";
            this.operate.Name = "operate";
            this.operate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operate.Text = "出库";
            this.operate.ToolTipText = "出库";
            this.operate.UseColumnTextForButtonValue = true;
            // 
            // Exit_Form
            // 
            this.Exit_Form.BackColor = System.Drawing.Color.Ivory;
            this.Exit_Form.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.Exit_Form.FlatAppearance.BorderSize = 2;
            this.Exit_Form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_Form.ForeColor = System.Drawing.Color.Black;
            this.Exit_Form.Location = new System.Drawing.Point(451, 645);
            this.Exit_Form.Name = "Exit_Form";
            this.Exit_Form.Size = new System.Drawing.Size(108, 27);
            this.Exit_Form.TabIndex = 34;
            this.Exit_Form.Text = "退出程序";
            this.Exit_Form.UseVisualStyleBackColor = false;
            this.Exit_Form.Click += new System.EventHandler(this.Exit_Form_Click);
            // 
            // OutBoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 694);
            this.Controls.Add(this.Exit_Form);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OutBoundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OutBoundForm";
            this.Shown += new System.EventHandler(this.OutBoundForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outBound_DataGirdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton LoadSaleOrders_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView outBound_DataGirdView;
        private System.Windows.Forms.ToolStripButton ScanCode_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn imsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn platform;
        private System.Windows.Forms.DataGridViewTextBoxColumn handleResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn outBoundUser;
        private System.Windows.Forms.DataGridViewButtonColumn operate;
        private System.Windows.Forms.ToolStripButton BackProcessSelection;
        private System.Windows.Forms.Button Exit_Form;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CompanyFullName_Label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label DeviceModel_Label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label BuyNumber_Label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label BuyDate_Label;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label PlatformType_Label;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label IPAddress_Label;
    }
}