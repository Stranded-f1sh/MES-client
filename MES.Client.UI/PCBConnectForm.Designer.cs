
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class PCBConnectForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Parity_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StopBits_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DataBits_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudRate_TextBox = new System.Windows.Forms.TextBox();
            this.btn_ShutDevice = new System.Windows.Forms.Button();
            this.PortName_ComboBox = new System.Windows.Forms.ComboBox();
            this.btn_OpenPort = new System.Windows.Forms.Button();
            this.btn_ScanDevice = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Parity_TextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StopBits_TextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DataBits_TextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BaudRate_TextBox);
            this.groupBox1.Controls.Add(this.btn_ShutDevice);
            this.groupBox1.Controls.Add(this.PortName_ComboBox);
            this.groupBox1.Controls.Add(this.btn_OpenPort);
            this.groupBox1.Controls.Add(this.btn_ScanDevice);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(865, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 285);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化";
            // 
            // Parity_TextBox
            // 
            this.Parity_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.Parity_TextBox.Location = new System.Drawing.Point(95, 193);
            this.Parity_TextBox.Name = "Parity_TextBox";
            this.Parity_TextBox.Size = new System.Drawing.Size(53, 21);
            this.Parity_TextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "校验位";
            // 
            // StopBits_TextBox
            // 
            this.StopBits_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.StopBits_TextBox.Location = new System.Drawing.Point(95, 163);
            this.StopBits_TextBox.Name = "StopBits_TextBox";
            this.StopBits_TextBox.Size = new System.Drawing.Size(53, 21);
            this.StopBits_TextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "停止位";
            // 
            // DataBits_TextBox
            // 
            this.DataBits_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.DataBits_TextBox.Location = new System.Drawing.Point(95, 133);
            this.DataBits_TextBox.Name = "DataBits_TextBox";
            this.DataBits_TextBox.Size = new System.Drawing.Size(53, 21);
            this.DataBits_TextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "数据位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "波特率";
            // 
            // BaudRate_TextBox
            // 
            this.BaudRate_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.BaudRate_TextBox.Location = new System.Drawing.Point(95, 103);
            this.BaudRate_TextBox.Name = "BaudRate_TextBox";
            this.BaudRate_TextBox.Size = new System.Drawing.Size(53, 21);
            this.BaudRate_TextBox.TabIndex = 3;
            // 
            // btn_ShutDevice
            // 
            this.btn_ShutDevice.Enabled = false;
            this.btn_ShutDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ShutDevice.Location = new System.Drawing.Point(160, 239);
            this.btn_ShutDevice.Name = "btn_ShutDevice";
            this.btn_ShutDevice.Size = new System.Drawing.Size(83, 23);
            this.btn_ShutDevice.TabIndex = 2;
            this.btn_ShutDevice.Text = "关闭端口";
            this.btn_ShutDevice.UseVisualStyleBackColor = true;
            // 
            // PortName_ComboBox
            // 
            this.PortName_ComboBox.BackColor = System.Drawing.SystemColors.Menu;
            this.PortName_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName_ComboBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.PortName_ComboBox.FormattingEnabled = true;
            this.PortName_ComboBox.Location = new System.Drawing.Point(18, 20);
            this.PortName_ComboBox.Name = "PortName_ComboBox";
            this.PortName_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PortName_ComboBox.Size = new System.Drawing.Size(245, 20);
            this.PortName_ComboBox.TabIndex = 1;
            // 
            // btn_OpenPort
            // 
            this.btn_OpenPort.Enabled = false;
            this.btn_OpenPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_OpenPort.Location = new System.Drawing.Point(45, 239);
            this.btn_OpenPort.Name = "btn_OpenPort";
            this.btn_OpenPort.Size = new System.Drawing.Size(83, 23);
            this.btn_OpenPort.TabIndex = 1;
            this.btn_OpenPort.Text = "打开端口";
            this.btn_OpenPort.UseVisualStyleBackColor = true;
            this.btn_OpenPort.Click += new System.EventHandler(this.btn_OpenPort_Click);
            // 
            // btn_ScanDevice
            // 
            this.btn_ScanDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ScanDevice.Location = new System.Drawing.Point(45, 60);
            this.btn_ScanDevice.Name = "btn_ScanDevice";
            this.btn_ScanDevice.Size = new System.Drawing.Size(198, 23);
            this.btn_ScanDevice.TabIndex = 0;
            this.btn_ScanDevice.Text = "查询端口";
            this.btn_ScanDevice.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 586);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(1, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(839, 46);
            this.textBox1.TabIndex = 10;
            // 
            // PCBConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1168, 633);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PCBConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCBConnectForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ShutDevice;
        private System.Windows.Forms.ComboBox PortName_ComboBox;
        private System.Windows.Forms.Button btn_OpenPort;
        private System.Windows.Forms.Button btn_ScanDevice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BaudRate_TextBox;
        private System.Windows.Forms.TextBox DataBits_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Parity_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StopBits_TextBox;
        private System.Windows.Forms.Label label3;
    }
}