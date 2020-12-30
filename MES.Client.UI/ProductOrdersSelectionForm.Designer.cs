
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class ProductOrdersSelectionForm
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
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Submit_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductOrder_TextBox = new System.Windows.Forms.TextBox();
            this.Go_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductOrderList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cancel_Button);
            this.groupBox1.Controls.Add(this.Submit_Button);
            this.groupBox1.Location = new System.Drawing.Point(-4, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 57);
            this.groupBox1.TabIndex = 0;
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
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "通过工单id查找：";
            // 
            // ProductOrder_TextBox
            // 
            this.ProductOrder_TextBox.Location = new System.Drawing.Point(24, 39);
            this.ProductOrder_TextBox.Name = "ProductOrder_TextBox";
            this.ProductOrder_TextBox.Size = new System.Drawing.Size(563, 21);
            this.ProductOrder_TextBox.TabIndex = 2;
            // 
            // Go_Button
            // 
            this.Go_Button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Go_Button.Location = new System.Drawing.Point(620, 39);
            this.Go_Button.Name = "Go_Button";
            this.Go_Button.Size = new System.Drawing.Size(75, 23);
            this.Go_Button.TabIndex = 3;
            this.Go_Button.Text = "Go";
            this.Go_Button.UseVisualStyleBackColor = true;
            this.Go_Button.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "工单列表：";
            // 
            // ProductOrderList
            // 
            this.ProductOrderList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.ProductOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductOrderList.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.ProductOrderList.Location = new System.Drawing.Point(26, 95);
            this.ProductOrderList.Name = "ProductOrderList";
            this.ProductOrderList.RowTemplate.Height = 23;
            this.ProductOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductOrderList.Size = new System.Drawing.Size(669, 265);
            this.ProductOrderList.TabIndex = 6;
            this.ProductOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductOrderList_CellClick);
            // 
            // ProductOrdersSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.ProductOrderList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Go_Button);
            this.Controls.Add(this.ProductOrder_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductOrdersSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工单选择";
            this.Load += new System.EventHandler(this.ProductOrdersSelectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductOrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProductOrder_TextBox;
        private System.Windows.Forms.Button Go_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductOrderList;
    }
}