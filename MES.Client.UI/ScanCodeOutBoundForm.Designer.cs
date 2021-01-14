
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class ScanCodeOutBoundForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imeiInput_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outBound_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cacheList_DataGirdView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inBoundUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cacheList_DataGirdView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.imeiInput_TextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 96);
            this.panel1.TabIndex = 0;
            // 
            // imeiInput_TextBox
            // 
            this.imeiInput_TextBox.Location = new System.Drawing.Point(316, 53);
            this.imeiInput_TextBox.Name = "imeiInput_TextBox";
            this.imeiInput_TextBox.Size = new System.Drawing.Size(167, 21);
            this.imeiInput_TextBox.TabIndex = 2;
            this.imeiInput_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imeiInput_TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "待出库列表";
            // 
            // outBound_Button
            // 
            this.outBound_Button.BackColor = System.Drawing.Color.Aquamarine;
            this.outBound_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outBound_Button.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outBound_Button.Location = new System.Drawing.Point(400, 472);
            this.outBound_Button.Name = "outBound_Button";
            this.outBound_Button.Size = new System.Drawing.Size(84, 28);
            this.outBound_Button.TabIndex = 0;
            this.outBound_Button.Text = "出库";
            this.outBound_Button.UseVisualStyleBackColor = false;
            this.outBound_Button.Click += new System.EventHandler(this.outBound_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.cacheList_DataGirdView);
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 357);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Location = new System.Drawing.Point(451, 8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(413, 336);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // cacheList_DataGirdView
            // 
            this.cacheList_DataGirdView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cacheList_DataGirdView.BackgroundColor = System.Drawing.Color.White;
            this.cacheList_DataGirdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cacheList_DataGirdView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cacheList_DataGirdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cacheList_DataGirdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.imei,
            this.inBoundUser,
            this.operate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cacheList_DataGirdView.DefaultCellStyle = dataGridViewCellStyle2;
            this.cacheList_DataGirdView.GridColor = System.Drawing.Color.Gainsboro;
            this.cacheList_DataGirdView.Location = new System.Drawing.Point(3, 8);
            this.cacheList_DataGirdView.Name = "cacheList_DataGirdView";
            this.cacheList_DataGirdView.RowTemplate.Height = 20;
            this.cacheList_DataGirdView.Size = new System.Drawing.Size(511, 336);
            this.cacheList_DataGirdView.TabIndex = 18;
            this.cacheList_DataGirdView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cacheList_DataGirdView_CellContentClick);
            // 
            // id
            // 
            this.id.FillWeight = 200F;
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            // 
            // imei
            // 
            this.imei.HeaderText = "imei号";
            this.imei.Name = "imei";
            // 
            // inBoundUser
            // 
            this.inBoundUser.HeaderText = "出库操作员";
            this.inBoundUser.Name = "inBoundUser";
            // 
            // operate
            // 
            this.operate.HeaderText = "操作";
            this.operate.Name = "operate";
            this.operate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operate.Text = "删除";
            this.operate.UseColumnTextForButtonValue = true;
            // 
            // ScanCodeOutBoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.outBound_Button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanCodeOutBoundForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cacheList_DataGirdView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button outBound_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView cacheList_DataGirdView;
        private System.Windows.Forms.TextBox imeiInput_TextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn inBoundUser;
        private System.Windows.Forms.DataGridViewButtonColumn operate;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}