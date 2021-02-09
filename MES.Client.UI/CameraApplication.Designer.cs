
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class CameraApplication
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trackBar_Gain = new System.Windows.Forms.TrackBar();
            this.trackBar_FrameRate = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_ExposureTime = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_MessageInfo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_SaveAsBmp = new System.Windows.Forms.Button();
            this.label_Gain = new System.Windows.Forms.Label();
            this.label_ExposureTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_StopCollect = new System.Windows.Forms.Button();
            this.btn_StartCollect = new System.Windows.Forms.Button();
            this.radio_TriggerAcquisitionMode = new System.Windows.Forms.RadioButton();
            this.Radio_ContinuousAcquisitionMode = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label_FrameRate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ShutDevice = new System.Windows.Forms.Button();
            this.comb_DeviceList = new System.Windows.Forms.ComboBox();
            this.btn_OpenDevice = new System.Windows.Forms.Button();
            this.btn_ScanDevice = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MsgInfoClear_Timer = new System.Windows.Forms.Timer(this.components);
            this.GetParam_Timer = new System.Windows.Forms.Timer(this.components);
            this.detection_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FrameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ExposureTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.trackBar_Gain);
            this.groupBox4.Controls.Add(this.trackBar_FrameRate);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.trackBar_ExposureTime);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(818, 468);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 142);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参数调节";
            // 
            // trackBar_Gain
            // 
            this.trackBar_Gain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Gain.Location = new System.Drawing.Point(62, 91);
            this.trackBar_Gain.Name = "trackBar_Gain";
            this.trackBar_Gain.Size = new System.Drawing.Size(196, 45);
            this.trackBar_Gain.TabIndex = 16;
            // 
            // trackBar_FrameRate
            // 
            this.trackBar_FrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_FrameRate.Location = new System.Drawing.Point(62, 54);
            this.trackBar_FrameRate.Name = "trackBar_FrameRate";
            this.trackBar_FrameRate.Size = new System.Drawing.Size(196, 45);
            this.trackBar_FrameRate.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "增益";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "采集帧率";
            // 
            // trackBar_ExposureTime
            // 
            this.trackBar_ExposureTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_ExposureTime.Location = new System.Drawing.Point(61, 19);
            this.trackBar_ExposureTime.Name = "trackBar_ExposureTime";
            this.trackBar_ExposureTime.Size = new System.Drawing.Size(197, 45);
            this.trackBar_ExposureTime.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "曝光时间";
            // 
            // label_MessageInfo
            // 
            this.label_MessageInfo.AutoSize = true;
            this.label_MessageInfo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label_MessageInfo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MessageInfo.ForeColor = System.Drawing.Color.Lavender;
            this.label_MessageInfo.Location = new System.Drawing.Point(24, 14);
            this.label_MessageInfo.Name = "label_MessageInfo";
            this.label_MessageInfo.Size = new System.Drawing.Size(0, 16);
            this.label_MessageInfo.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.textBox1.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(1, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(814, 46);
            this.textBox1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_SaveAsBmp);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Location = new System.Drawing.Point(820, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 124);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "bitmap图像";
            // 
            // btn_SaveAsBmp
            // 
            this.btn_SaveAsBmp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_SaveAsBmp.Location = new System.Drawing.Point(46, 52);
            this.btn_SaveAsBmp.Name = "btn_SaveAsBmp";
            this.btn_SaveAsBmp.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveAsBmp.TabIndex = 0;
            this.btn_SaveAsBmp.Text = "识别";
            this.btn_SaveAsBmp.UseVisualStyleBackColor = true;
            this.btn_SaveAsBmp.Click += new System.EventHandler(this.btn_SaveAsBmp_Click);
            // 
            // label_Gain
            // 
            this.label_Gain.AutoSize = true;
            this.label_Gain.BackColor = System.Drawing.Color.Black;
            this.label_Gain.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_Gain.Location = new System.Drawing.Point(30, 139);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(59, 12);
            this.label_Gain.TabIndex = 20;
            this.label_Gain.Text = "增益：0.0";
            // 
            // label_ExposureTime
            // 
            this.label_ExposureTime.AutoSize = true;
            this.label_ExposureTime.BackColor = System.Drawing.Color.Black;
            this.label_ExposureTime.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_ExposureTime.Location = new System.Drawing.Point(29, 89);
            this.label_ExposureTime.Name = "label_ExposureTime";
            this.label_ExposureTime.Size = new System.Drawing.Size(89, 12);
            this.label_ExposureTime.TabIndex = 19;
            this.label_ExposureTime.Text = "曝光时间： 0.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_StopCollect);
            this.groupBox2.Controls.Add(this.btn_StartCollect);
            this.groupBox2.Controls.Add(this.radio_TriggerAcquisitionMode);
            this.groupBox2.Controls.Add(this.Radio_ContinuousAcquisitionMode);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(820, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 121);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像采集";
            // 
            // btn_StopCollect
            // 
            this.btn_StopCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_StopCollect.Enabled = false;
            this.btn_StopCollect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_StopCollect.Location = new System.Drawing.Point(148, 51);
            this.btn_StopCollect.Name = "btn_StopCollect";
            this.btn_StopCollect.Size = new System.Drawing.Size(83, 23);
            this.btn_StopCollect.TabIndex = 4;
            this.btn_StopCollect.Text = "停止采集";
            this.btn_StopCollect.UseVisualStyleBackColor = true;
            this.btn_StopCollect.Click += new System.EventHandler(this.btn_StopCollect_Click);
            // 
            // btn_StartCollect
            // 
            this.btn_StartCollect.Enabled = false;
            this.btn_StartCollect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_StartCollect.Location = new System.Drawing.Point(32, 51);
            this.btn_StartCollect.Name = "btn_StartCollect";
            this.btn_StartCollect.Size = new System.Drawing.Size(83, 23);
            this.btn_StartCollect.TabIndex = 3;
            this.btn_StartCollect.Text = "开始采集";
            this.btn_StartCollect.UseVisualStyleBackColor = true;
            this.btn_StartCollect.Click += new System.EventHandler(this.btn_StartCollect_Click);
            // 
            // radio_TriggerAcquisitionMode
            // 
            this.radio_TriggerAcquisitionMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radio_TriggerAcquisitionMode.AutoSize = true;
            this.radio_TriggerAcquisitionMode.Enabled = false;
            this.radio_TriggerAcquisitionMode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radio_TriggerAcquisitionMode.Location = new System.Drawing.Point(148, 20);
            this.radio_TriggerAcquisitionMode.Name = "radio_TriggerAcquisitionMode";
            this.radio_TriggerAcquisitionMode.Size = new System.Drawing.Size(95, 16);
            this.radio_TriggerAcquisitionMode.TabIndex = 1;
            this.radio_TriggerAcquisitionMode.TabStop = true;
            this.radio_TriggerAcquisitionMode.Text = "触发采集模式";
            this.radio_TriggerAcquisitionMode.UseVisualStyleBackColor = true;
            // 
            // Radio_ContinuousAcquisitionMode
            // 
            this.Radio_ContinuousAcquisitionMode.AutoSize = true;
            this.Radio_ContinuousAcquisitionMode.Enabled = false;
            this.Radio_ContinuousAcquisitionMode.Location = new System.Drawing.Point(20, 20);
            this.Radio_ContinuousAcquisitionMode.Name = "Radio_ContinuousAcquisitionMode";
            this.Radio_ContinuousAcquisitionMode.Size = new System.Drawing.Size(95, 16);
            this.Radio_ContinuousAcquisitionMode.TabIndex = 0;
            this.Radio_ContinuousAcquisitionMode.TabStop = true;
            this.Radio_ContinuousAcquisitionMode.Text = "连续采集模式";
            this.Radio_ContinuousAcquisitionMode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(30, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "带宽：0.0Mbps";
            // 
            // label_FrameRate
            // 
            this.label_FrameRate.AutoSize = true;
            this.label_FrameRate.BackColor = System.Drawing.Color.Black;
            this.label_FrameRate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_FrameRate.Location = new System.Drawing.Point(29, 115);
            this.label_FrameRate.Name = "label_FrameRate";
            this.label_FrameRate.Size = new System.Drawing.Size(119, 12);
            this.label_FrameRate.TabIndex = 16;
            this.label_FrameRate.Text = "采集帧率：0.00帧/秒";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_ShutDevice);
            this.groupBox1.Controls.Add(this.comb_DeviceList);
            this.groupBox1.Controls.Add(this.btn_OpenDevice);
            this.groupBox1.Controls.Add(this.btn_ScanDevice);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(820, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 150);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化";
            // 
            // btn_ShutDevice
            // 
            this.btn_ShutDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShutDevice.AutoSize = true;
            this.btn_ShutDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ShutDevice.Enabled = false;
            this.btn_ShutDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ShutDevice.Location = new System.Drawing.Point(145, 108);
            this.btn_ShutDevice.Name = "btn_ShutDevice";
            this.btn_ShutDevice.Size = new System.Drawing.Size(63, 22);
            this.btn_ShutDevice.TabIndex = 2;
            this.btn_ShutDevice.Text = "关闭设备";
            this.btn_ShutDevice.UseVisualStyleBackColor = true;
            this.btn_ShutDevice.Click += new System.EventHandler(this.btn_ShutDevice_Click);
            // 
            // comb_DeviceList
            // 
            this.comb_DeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comb_DeviceList.BackColor = System.Drawing.SystemColors.Menu;
            this.comb_DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_DeviceList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comb_DeviceList.FormattingEnabled = true;
            this.comb_DeviceList.Location = new System.Drawing.Point(5, 20);
            this.comb_DeviceList.Name = "comb_DeviceList";
            this.comb_DeviceList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comb_DeviceList.Size = new System.Drawing.Size(245, 20);
            this.comb_DeviceList.TabIndex = 1;
            // 
            // btn_OpenDevice
            // 
            this.btn_OpenDevice.AutoSize = true;
            this.btn_OpenDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_OpenDevice.Enabled = false;
            this.btn_OpenDevice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_OpenDevice.Location = new System.Drawing.Point(30, 108);
            this.btn_OpenDevice.Name = "btn_OpenDevice";
            this.btn_OpenDevice.Size = new System.Drawing.Size(63, 22);
            this.btn_OpenDevice.TabIndex = 1;
            this.btn_OpenDevice.Text = "打开设备";
            this.btn_OpenDevice.UseVisualStyleBackColor = true;
            this.btn_OpenDevice.Click += new System.EventHandler(this.btn_OpenDevice_Click);
            // 
            // btn_ScanDevice
            // 
            this.btn_ScanDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ScanDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ScanDevice.Location = new System.Drawing.Point(30, 60);
            this.btn_ScanDevice.Name = "btn_ScanDevice";
            this.btn_ScanDevice.Size = new System.Drawing.Size(198, 23);
            this.btn_ScanDevice.TabIndex = 0;
            this.btn_ScanDevice.Text = "查询设备";
            this.btn_ScanDevice.UseVisualStyleBackColor = true;
            this.btn_ScanDevice.Click += new System.EventHandler(this.btn_ScanDevice_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(2, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 567);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // MsgInfoClear_Timer
            // 
            this.MsgInfoClear_Timer.Interval = 3000;
            this.MsgInfoClear_Timer.Tick += new System.EventHandler(this.MsgInfoClear_Timer_Tick);
            // 
            // GetParam_Timer
            // 
            this.GetParam_Timer.Interval = 2000;
            this.GetParam_Timer.Tick += new System.EventHandler(this.GetParam_Timer_Tick);
            // 
            // CameraApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1089, 617);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label_MessageInfo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label_Gain);
            this.Controls.Add(this.label_ExposureTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_FrameRate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CameraApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraApplication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraApplication_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FrameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ExposureTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackBar_Gain;
        private System.Windows.Forms.TrackBar trackBar_FrameRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_ExposureTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_MessageInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_SaveAsBmp;
        private System.Windows.Forms.Label label_Gain;
        private System.Windows.Forms.Label label_ExposureTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_StopCollect;
        private System.Windows.Forms.Button btn_StartCollect;
        private System.Windows.Forms.RadioButton radio_TriggerAcquisitionMode;
        private System.Windows.Forms.RadioButton Radio_ContinuousAcquisitionMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_FrameRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ShutDevice;
        private System.Windows.Forms.ComboBox comb_DeviceList;
        private System.Windows.Forms.Button btn_OpenDevice;
        private System.Windows.Forms.Button btn_ScanDevice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer MsgInfoClear_Timer;
        private System.Windows.Forms.Timer GetParam_Timer;
        private System.Windows.Forms.Timer detection_Timer;
    }
}

