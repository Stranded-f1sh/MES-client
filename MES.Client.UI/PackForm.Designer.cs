
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class PackForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackForm));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PageNum_Label = new System.Windows.Forms.Label();
            this.Exit_Form = new System.Windows.Forms.Button();
            this.BaoGongDeviceList = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.isPrint_CheckBox = new System.Windows.Forms.CheckBox();
            this.Qualify_ComboBox = new System.Windows.Forms.ComboBox();
            this.label_orderId_imei = new System.Windows.Forms.Label();
            this.Imei_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaleOrderNo_TextBox = new System.Windows.Forms.TextBox();
            this.PackNum_TextBox = new System.Windows.Forms.TextBox();
            this.label_region = new System.Windows.Forms.Label();
            this.label_buynum = new System.Windows.Forms.Label();
            this.CompanyFullName_TextBox = new System.Windows.Forms.TextBox();
            this.label_deviceModel = new System.Windows.Forms.Label();
            this.label_companyName = new System.Windows.Forms.Label();
            this.BuyNumber_TextBox = new System.Windows.Forms.TextBox();
            this.label_orderno = new System.Windows.Forms.Label();
            this.DeviceModel_TextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.process_num = new System.Windows.Forms.Label();
            this.INFO = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateProductOrder_Btn = new System.Windows.Forms.ToolStripButton();
            this.LoadSaleOrders_btn = new System.Windows.Forms.ToolStripButton();
            this.OrderSelect_Btn = new System.Windows.Forms.ToolStripButton();
            this.Find_Button = new System.Windows.Forms.ToolStripButton();
            this.DBCache_Button = new System.Windows.Forms.ToolStripButton();
            this.PLC_Communication_Button = new System.Windows.Forms.ToolStripButton();
            this.BigPackFormLoad_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BackPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.NextPage_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Setting_Button = new System.Windows.Forms.ToolStripButton();
            this.export_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.DataCache_ToolTrips_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.User_Label = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaoGongDeviceList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox5.BackColor = System.Drawing.Color.LightGray;
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.PageNum_Label);
            this.groupBox5.Location = new System.Drawing.Point(839, 727);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(141, 31);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "页码：";
            // 
            // PageNum_Label
            // 
            this.PageNum_Label.AutoSize = true;
            this.PageNum_Label.Location = new System.Drawing.Point(87, 14);
            this.PageNum_Label.Name = "PageNum_Label";
            this.PageNum_Label.Size = new System.Drawing.Size(11, 12);
            this.PageNum_Label.TabIndex = 25;
            this.PageNum_Label.Text = "1";
            // 
            // Exit_Form
            // 
            this.Exit_Form.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Exit_Form.BackColor = System.Drawing.Color.LightGray;
            this.Exit_Form.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.Exit_Form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_Form.ForeColor = System.Drawing.Color.Black;
            this.Exit_Form.Location = new System.Drawing.Point(549, 732);
            this.Exit_Form.Name = "Exit_Form";
            this.Exit_Form.Size = new System.Drawing.Size(108, 23);
            this.Exit_Form.TabIndex = 35;
            this.Exit_Form.Text = "退出程序";
            this.Exit_Form.UseVisualStyleBackColor = false;
            this.Exit_Form.Click += new System.EventHandler(this.Exit_Form_Click);
            // 
            // BaoGongDeviceList
            // 
            this.BaoGongDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaoGongDeviceList.BackgroundColor = System.Drawing.Color.White;
            this.BaoGongDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BaoGongDeviceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.BaoGongDeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BaoGongDeviceList.DefaultCellStyle = dataGridViewCellStyle4;
            this.BaoGongDeviceList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.BaoGongDeviceList.Location = new System.Drawing.Point(3, 384);
            this.BaoGongDeviceList.Name = "BaoGongDeviceList";
            this.BaoGongDeviceList.RowTemplate.Height = 20;
            this.BaoGongDeviceList.Size = new System.Drawing.Size(1173, 336);
            this.BaoGongDeviceList.TabIndex = 33;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox4.Location = new System.Drawing.Point(2, 362);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(1174, 23);
            this.textBox4.TabIndex = 32;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "已报工设备";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.Qualify_ComboBox);
            this.groupBox3.Controls.Add(this.label_orderId_imei);
            this.groupBox3.Controls.Add(this.Imei_TextBox);
            this.groupBox3.Location = new System.Drawing.Point(600, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 207);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户输入";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox3);
            this.groupBox7.Controls.Add(this.checkBox4);
            this.groupBox7.Location = new System.Drawing.Point(135, 85);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(197, 34);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "是否合格";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(38, 13);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "合格";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.Color.Black;
            this.checkBox4.Location = new System.Drawing.Point(103, 13);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(60, 16);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "不合格";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Location = new System.Drawing.Point(135, 122);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 34);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "自动报工";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(35, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "报工";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(486, 95);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 23);
            this.button7.TabIndex = 22;
            this.button7.Text = "新增";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.isPrint_CheckBox);
            this.groupBox4.Location = new System.Drawing.Point(136, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 34);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动打印";
            // 
            // isPrint_CheckBox
            // 
            this.isPrint_CheckBox.AutoSize = true;
            this.isPrint_CheckBox.Checked = true;
            this.isPrint_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isPrint_CheckBox.ForeColor = System.Drawing.Color.Black;
            this.isPrint_CheckBox.Location = new System.Drawing.Point(34, 14);
            this.isPrint_CheckBox.Name = "isPrint_CheckBox";
            this.isPrint_CheckBox.Size = new System.Drawing.Size(48, 16);
            this.isPrint_CheckBox.TabIndex = 15;
            this.isPrint_CheckBox.Text = "条码";
            this.isPrint_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Qualify_ComboBox
            // 
            this.Qualify_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Qualify_ComboBox.FormattingEnabled = true;
            this.Qualify_ComboBox.Location = new System.Drawing.Point(349, 96);
            this.Qualify_ComboBox.Name = "Qualify_ComboBox";
            this.Qualify_ComboBox.Size = new System.Drawing.Size(131, 20);
            this.Qualify_ComboBox.TabIndex = 13;
            this.Qualify_ComboBox.Visible = false;
            // 
            // label_orderId_imei
            // 
            this.label_orderId_imei.AutoSize = true;
            this.label_orderId_imei.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_orderId_imei.ForeColor = System.Drawing.Color.Black;
            this.label_orderId_imei.Location = new System.Drawing.Point(144, 31);
            this.label_orderId_imei.Name = "label_orderId_imei";
            this.label_orderId_imei.Size = new System.Drawing.Size(61, 16);
            this.label_orderId_imei.TabIndex = 4;
            this.label_orderId_imei.Text = "IMEI号";
            this.label_orderId_imei.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Imei_TextBox
            // 
            this.Imei_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Imei_TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Imei_TextBox.Location = new System.Drawing.Point(273, 28);
            this.Imei_TextBox.Name = "Imei_TextBox";
            this.Imei_TextBox.Size = new System.Drawing.Size(283, 21);
            this.Imei_TextBox.TabIndex = 0;
            this.Imei_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Imei_TextBox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.SaleOrderNo_TextBox);
            this.groupBox1.Controls.Add(this.PackNum_TextBox);
            this.groupBox1.Controls.Add(this.label_region);
            this.groupBox1.Controls.Add(this.label_buynum);
            this.groupBox1.Controls.Add(this.CompanyFullName_TextBox);
            this.groupBox1.Controls.Add(this.label_deviceModel);
            this.groupBox1.Controls.Add(this.label_companyName);
            this.groupBox1.Controls.Add(this.BuyNumber_TextBox);
            this.groupBox1.Controls.Add(this.label_orderno);
            this.groupBox1.Controls.Add(this.DeviceModel_TextBox);
            this.groupBox1.Location = new System.Drawing.Point(2, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 207);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售单信息";
            // 
            // SaleOrderNo_TextBox
            // 
            this.SaleOrderNo_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaleOrderNo_TextBox.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaleOrderNo_TextBox.Location = new System.Drawing.Point(102, 32);
            this.SaleOrderNo_TextBox.Name = "SaleOrderNo_TextBox";
            this.SaleOrderNo_TextBox.ReadOnly = true;
            this.SaleOrderNo_TextBox.Size = new System.Drawing.Size(241, 22);
            this.SaleOrderNo_TextBox.TabIndex = 5;
            // 
            // PackNum_TextBox
            // 
            this.PackNum_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PackNum_TextBox.Font = new System.Drawing.Font("等线", 10.5F);
            this.PackNum_TextBox.Location = new System.Drawing.Point(102, 165);
            this.PackNum_TextBox.Name = "PackNum_TextBox";
            this.PackNum_TextBox.ReadOnly = true;
            this.PackNum_TextBox.Size = new System.Drawing.Size(241, 22);
            this.PackNum_TextBox.TabIndex = 9;
            // 
            // label_region
            // 
            this.label_region.AutoSize = true;
            this.label_region.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_region.ForeColor = System.Drawing.Color.Black;
            this.label_region.Location = new System.Drawing.Point(5, 170);
            this.label_region.Name = "label_region";
            this.label_region.Size = new System.Drawing.Size(82, 14);
            this.label_region.TabIndex = 4;
            this.label_region.Text = "已报工数量";
            // 
            // label_buynum
            // 
            this.label_buynum.AutoSize = true;
            this.label_buynum.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_buynum.ForeColor = System.Drawing.Color.Black;
            this.label_buynum.Location = new System.Drawing.Point(6, 138);
            this.label_buynum.Name = "label_buynum";
            this.label_buynum.Size = new System.Drawing.Size(67, 14);
            this.label_buynum.TabIndex = 3;
            this.label_buynum.Text = "订单数量";
            // 
            // CompanyFullName_TextBox
            // 
            this.CompanyFullName_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CompanyFullName_TextBox.Font = new System.Drawing.Font("等线", 10.5F);
            this.CompanyFullName_TextBox.Location = new System.Drawing.Point(102, 66);
            this.CompanyFullName_TextBox.Name = "CompanyFullName_TextBox";
            this.CompanyFullName_TextBox.ReadOnly = true;
            this.CompanyFullName_TextBox.Size = new System.Drawing.Size(241, 22);
            this.CompanyFullName_TextBox.TabIndex = 6;
            // 
            // label_deviceModel
            // 
            this.label_deviceModel.AutoSize = true;
            this.label_deviceModel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_deviceModel.ForeColor = System.Drawing.Color.Black;
            this.label_deviceModel.Location = new System.Drawing.Point(6, 105);
            this.label_deviceModel.Name = "label_deviceModel";
            this.label_deviceModel.Size = new System.Drawing.Size(67, 14);
            this.label_deviceModel.TabIndex = 2;
            this.label_deviceModel.Text = "发货设备";
            // 
            // label_companyName
            // 
            this.label_companyName.AutoSize = true;
            this.label_companyName.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_companyName.ForeColor = System.Drawing.Color.Black;
            this.label_companyName.Location = new System.Drawing.Point(6, 71);
            this.label_companyName.Name = "label_companyName";
            this.label_companyName.Size = new System.Drawing.Size(67, 14);
            this.label_companyName.TabIndex = 1;
            this.label_companyName.Text = "发货客户";
            // 
            // BuyNumber_TextBox
            // 
            this.BuyNumber_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BuyNumber_TextBox.Font = new System.Drawing.Font("等线", 10.5F);
            this.BuyNumber_TextBox.Location = new System.Drawing.Point(102, 133);
            this.BuyNumber_TextBox.Name = "BuyNumber_TextBox";
            this.BuyNumber_TextBox.ReadOnly = true;
            this.BuyNumber_TextBox.Size = new System.Drawing.Size(241, 22);
            this.BuyNumber_TextBox.TabIndex = 8;
            // 
            // label_orderno
            // 
            this.label_orderno.AutoSize = true;
            this.label_orderno.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_orderno.ForeColor = System.Drawing.Color.Black;
            this.label_orderno.Location = new System.Drawing.Point(6, 37);
            this.label_orderno.Name = "label_orderno";
            this.label_orderno.Size = new System.Drawing.Size(82, 14);
            this.label_orderno.TabIndex = 0;
            this.label_orderno.Text = "发货销售单";
            // 
            // DeviceModel_TextBox
            // 
            this.DeviceModel_TextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeviceModel_TextBox.Font = new System.Drawing.Font("等线", 10.5F);
            this.DeviceModel_TextBox.Location = new System.Drawing.Point(102, 100);
            this.DeviceModel_TextBox.Name = "DeviceModel_TextBox";
            this.DeviceModel_TextBox.ReadOnly = true;
            this.DeviceModel_TextBox.Size = new System.Drawing.Size(241, 22);
            this.DeviceModel_TextBox.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox3.Location = new System.Drawing.Point(2, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1174, 23);
            this.textBox3.TabIndex = 28;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Green;
            this.groupBox2.Controls.Add(this.process_num);
            this.groupBox2.Controls.Add(this.INFO);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.LawnGreen;
            this.groupBox2.Location = new System.Drawing.Point(2, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1174, 56);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // process_num
            // 
            this.process_num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.process_num.AutoSize = true;
            this.process_num.Font = new System.Drawing.Font("明黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.process_num.ForeColor = System.Drawing.Color.Lime;
            this.process_num.Location = new System.Drawing.Point(902, 27);
            this.process_num.Name = "process_num";
            this.process_num.Size = new System.Drawing.Size(121, 23);
            this.process_num.TabIndex = 7;
            this.process_num.Text = "工序日产量:";
            // 
            // INFO
            // 
            this.INFO.AutoSize = true;
            this.INFO.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.INFO.Location = new System.Drawing.Point(7, 24);
            this.INFO.Name = "INFO";
            this.INFO.Size = new System.Drawing.Size(22, 14);
            this.INFO.TabIndex = 0;
            this.INFO.Text = "无";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.PLC_Communication_Button,
            this.BigPackFormLoad_Button,
            this.toolStripSeparator3,
            this.BackPage_Btn,
            this.NextPage_Btn,
            this.toolStripSeparator1,
            this.Setting_Button,
            this.export_Button,
            this.toolStripSeparator,
            this.DataCache_ToolTrips_Button,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1173, 85);
            this.toolStrip1.TabIndex = 27;
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
            this.OrderSelect_Btn.Click += new System.EventHandler(this.OrderSelect_Btn_Click);
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
            this.DBCache_Button.Click += new System.EventHandler(this.DBCache_Button_Click);
            // 
            // PLC_Communication_Button
            // 
            this.PLC_Communication_Button.AutoSize = false;
            this.PLC_Communication_Button.Image = ((System.Drawing.Image)(resources.GetObject("PLC_Communication_Button.Image")));
            this.PLC_Communication_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PLC_Communication_Button.Name = "PLC_Communication_Button";
            this.PLC_Communication_Button.Size = new System.Drawing.Size(84, 68);
            this.PLC_Communication_Button.Text = "下位机通讯";
            this.PLC_Communication_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PLC_Communication_Button.Click += new System.EventHandler(this.PLC_Communication_Button_Click);
            // 
            // BigPackFormLoad_Button
            // 
            this.BigPackFormLoad_Button.AutoSize = false;
            this.BigPackFormLoad_Button.Image = ((System.Drawing.Image)(resources.GetObject("BigPackFormLoad_Button.Image")));
            this.BigPackFormLoad_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BigPackFormLoad_Button.Name = "BigPackFormLoad_Button";
            this.BigPackFormLoad_Button.Size = new System.Drawing.Size(84, 68);
            this.BigPackFormLoad_Button.Text = "大箱包装";
            this.BigPackFormLoad_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BigPackFormLoad_Button.Click += new System.EventHandler(this.BigPackFormLoad_Button_Click);
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
            this.BackPage_Btn.Click += new System.EventHandler(this.BackPage_Btn_Click);
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
            this.NextPage_Btn.Click += new System.EventHandler(this.NextPage_Btn_Click);
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
            this.Setting_Button.Click += new System.EventHandler(this.Setting_Button_Click);
            // 
            // export_Button
            // 
            this.export_Button.AutoSize = false;
            this.export_Button.Image = ((System.Drawing.Image)(resources.GetObject("export_Button.Image")));
            this.export_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export_Button.Name = "export_Button";
            this.export_Button.Size = new System.Drawing.Size(84, 68);
            this.export_Button.Text = "导出";
            this.export_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.export_Button.Click += new System.EventHandler(this.Export_Button_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 85);
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
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 85);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(1052, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "当前操作员：";
            // 
            // User_Label
            // 
            this.User_Label.AutoSize = true;
            this.User_Label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.User_Label.Location = new System.Drawing.Point(1126, 36);
            this.User_Label.Name = "User_Label";
            this.User_Label.Size = new System.Drawing.Size(0, 12);
            this.User_Label.TabIndex = 38;
            // 
            // PackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 766);
            this.ControlBox = false;
            this.Controls.Add(this.User_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Exit_Form);
            this.Controls.Add(this.BaoGongDeviceList);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PackForm";
            this.Load += new System.EventHandler(this.PackForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaoGongDeviceList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PageNum_Label;
        private System.Windows.Forms.Button Exit_Form;
        private System.Windows.Forms.DataGridView BaoGongDeviceList;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox isPrint_CheckBox;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox Qualify_ComboBox;
        private System.Windows.Forms.Label label_orderId_imei;
        private System.Windows.Forms.TextBox Imei_TextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SaleOrderNo_TextBox;
        private System.Windows.Forms.TextBox PackNum_TextBox;
        private System.Windows.Forms.Label label_region;
        private System.Windows.Forms.Label label_buynum;
        private System.Windows.Forms.TextBox CompanyFullName_TextBox;
        private System.Windows.Forms.Label label_deviceModel;
        private System.Windows.Forms.Label label_companyName;
        private System.Windows.Forms.TextBox BuyNumber_TextBox;
        private System.Windows.Forms.Label label_orderno;
        private System.Windows.Forms.TextBox DeviceModel_TextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label process_num;
        private System.Windows.Forms.Label INFO;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateProductOrder_Btn;
        private System.Windows.Forms.ToolStripButton LoadSaleOrders_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BackPage_Btn;
        private System.Windows.Forms.ToolStripButton NextPage_Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Setting_Button;
        private System.Windows.Forms.ToolStripButton export_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton DataCache_ToolTrips_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripButton OrderSelect_Btn;
        private ToolStripButton Find_Button;
        private ToolStripButton DBCache_Button;
        private Label label3;
        private Label User_Label;
        private ToolStripButton PLC_Communication_Button;
        private ToolStripButton BigPackFormLoad_Button;
    }
}