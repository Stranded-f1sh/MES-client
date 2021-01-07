
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class SaleOrdersSelectionForm
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
            this.SaleOrderList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Go_Button = new System.Windows.Forms.Button();
            this.SaleOrder_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Submit_Button = new System.Windows.Forms.Button();
            this.YearSelection_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaleOrderList
            // 
            this.SaleOrderList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.SaleOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SaleOrderList.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.SaleOrderList.Location = new System.Drawing.Point(26, 95);
            this.SaleOrderList.Name = "SaleOrderList";
            this.SaleOrderList.RowTemplate.Height = 23;
            this.SaleOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SaleOrderList.Size = new System.Drawing.Size(669, 265);
            this.SaleOrderList.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "销售单信息：";
            // 
            // Go_Button
            // 
            this.Go_Button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Go_Button.Location = new System.Drawing.Point(620, 39);
            this.Go_Button.Name = "Go_Button";
            this.Go_Button.Size = new System.Drawing.Size(75, 23);
            this.Go_Button.TabIndex = 10;
            this.Go_Button.Text = "Go";
            this.Go_Button.UseVisualStyleBackColor = true;
            this.Go_Button.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // SaleOrder_TextBox
            // 
            this.SaleOrder_TextBox.Location = new System.Drawing.Point(144, 39);
            this.SaleOrder_TextBox.Name = "SaleOrder_TextBox";
            this.SaleOrder_TextBox.Size = new System.Drawing.Size(443, 21);
            this.SaleOrder_TextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "通过销售单id查找：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cancel_Button);
            this.groupBox1.Controls.Add(this.Submit_Button);
            this.groupBox1.Location = new System.Drawing.Point(-4, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 57);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cancel_Button.Location = new System.Drawing.Point(624, 20);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Submit_Button
            // 
            this.Submit_Button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Submit_Button.Location = new System.Drawing.Point(516, 20);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(75, 23);
            this.Submit_Button.TabIndex = 0;
            this.Submit_Button.Text = "OK";
            this.Submit_Button.UseVisualStyleBackColor = true;
            // 
            // YearSelection_ComboBox
            // 
            this.YearSelection_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearSelection_ComboBox.FormattingEnabled = true;
            this.YearSelection_ComboBox.Location = new System.Drawing.Point(26, 39);
            this.YearSelection_ComboBox.Name = "YearSelection_ComboBox";
            this.YearSelection_ComboBox.Size = new System.Drawing.Size(112, 20);
            this.YearSelection_ComboBox.TabIndex = 13;
            this.YearSelection_ComboBox.TextChanged += new System.EventHandler(this.YearSelection_ComboBox_TextChanged);
            // 
            // SaleOrdersSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.YearSelection_ComboBox);
            this.Controls.Add(this.SaleOrderList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Go_Button);
            this.Controls.Add(this.SaleOrder_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SaleOrdersSelectionForm";
            this.Text = "SaleOrdersSelectionForm";
            this.Load += new System.EventHandler(this.SaleOrdersSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SaleOrderList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Go_Button;
        private System.Windows.Forms.TextBox SaleOrder_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.ComboBox YearSelection_ComboBox;
    }
}