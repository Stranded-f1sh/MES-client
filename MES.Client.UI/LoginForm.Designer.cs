
namespace ManufacturingExecutionSystem.MES.Client.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.TopsailLogo_PictureBox = new System.Windows.Forms.PictureBox();
            this.Titie = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserName_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PassWord_TextBox = new System.Windows.Forms.TextBox();
            this.ForgetPasswd_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.CreateUser_Button = new System.Windows.Forms.Button();
            this.RecordPassWd_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TopsailLogo_PictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopsailLogo_PictureBox
            // 
            this.TopsailLogo_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("TopsailLogo_PictureBox.Image")));
            this.TopsailLogo_PictureBox.Location = new System.Drawing.Point(23, 65);
            this.TopsailLogo_PictureBox.Name = "TopsailLogo_PictureBox";
            this.TopsailLogo_PictureBox.Size = new System.Drawing.Size(209, 82);
            this.TopsailLogo_PictureBox.TabIndex = 0;
            this.TopsailLogo_PictureBox.TabStop = false;
            // 
            // Titie
            // 
            this.Titie.AutoSize = true;
            this.Titie.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titie.Location = new System.Drawing.Point(1, -2);
            this.Titie.Name = "Titie";
            this.Titie.Size = new System.Drawing.Size(37, 19);
            this.Titie.TabIndex = 1;
            this.Titie.Text = "MES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(276, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "登录到MES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "如果您有用户名和密码，请在这里输入。如果遇到问题，请联系管理员";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // UserName_TextBox
            // 
            this.UserName_TextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName_TextBox.ForeColor = System.Drawing.Color.Gray;
            this.UserName_TextBox.Location = new System.Drawing.Point(353, 157);
            this.UserName_TextBox.Name = "UserName_TextBox";
            this.UserName_TextBox.Size = new System.Drawing.Size(215, 22);
            this.UserName_TextBox.TabIndex = 5;
            this.UserName_TextBox.Text = "UserName";
            this.UserName_TextBox.Click += new System.EventHandler(this.UserName_TextBox_Click);
            this.UserName_TextBox.TextChanged += new System.EventHandler(this.UserName_TextBox_TextChanged);
            this.UserName_TextBox.Enter += new System.EventHandler(this.UserName_TextBox_Enter);
            this.UserName_TextBox.Leave += new System.EventHandler(this.UserName_TextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // PassWord_TextBox
            // 
            this.PassWord_TextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWord_TextBox.ForeColor = System.Drawing.Color.Gray;
            this.PassWord_TextBox.Location = new System.Drawing.Point(353, 185);
            this.PassWord_TextBox.Name = "PassWord_TextBox";
            this.PassWord_TextBox.Size = new System.Drawing.Size(215, 22);
            this.PassWord_TextBox.TabIndex = 7;
            this.PassWord_TextBox.Text = "PassWord";
            this.PassWord_TextBox.UseSystemPasswordChar = true;
            this.PassWord_TextBox.Enter += new System.EventHandler(this.PassWord_TextBox_Enter);
            this.PassWord_TextBox.Leave += new System.EventHandler(this.PassWord_TextBox_Leave);
            // 
            // ForgetPasswd_LinkLabel
            // 
            this.ForgetPasswd_LinkLabel.AutoSize = true;
            this.ForgetPasswd_LinkLabel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.ForgetPasswd_LinkLabel.Location = new System.Drawing.Point(278, 227);
            this.ForgetPasswd_LinkLabel.Name = "ForgetPasswd_LinkLabel";
            this.ForgetPasswd_LinkLabel.Size = new System.Drawing.Size(137, 12);
            this.ForgetPasswd_LinkLabel.TabIndex = 8;
            this.ForgetPasswd_LinkLabel.TabStop = true;
            this.ForgetPasswd_LinkLabel.Text = "忘记了用户名或密码吗？";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.Cancel_Button);
            this.panel1.Controls.Add(this.Login_Btn);
            this.panel1.Controls.Add(this.CreateUser_Button);
            this.panel1.Location = new System.Drawing.Point(-2, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 68);
            this.panel1.TabIndex = 9;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(600, 21);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(94, 23);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Login_Btn
            // 
            this.Login_Btn.Location = new System.Drawing.Point(423, 21);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(104, 23);
            this.Login_Btn.TabIndex = 1;
            this.Login_Btn.Text = "登录(S)";
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            this.Login_Btn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_Btn_KeyPress);
            // 
            // CreateUser_Button
            // 
            this.CreateUser_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.CreateUser_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CreateUser_Button.Location = new System.Drawing.Point(25, 21);
            this.CreateUser_Button.Name = "CreateUser_Button";
            this.CreateUser_Button.Size = new System.Drawing.Size(167, 23);
            this.CreateUser_Button.TabIndex = 0;
            this.CreateUser_Button.Text = "创建新用户(N)";
            this.CreateUser_Button.UseVisualStyleBackColor = false;
            // 
            // RecordPassWd_CheckBox
            // 
            this.RecordPassWd_CheckBox.AutoSize = true;
            this.RecordPassWd_CheckBox.Checked = true;
            this.RecordPassWd_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecordPassWd_CheckBox.Location = new System.Drawing.Point(580, 188);
            this.RecordPassWd_CheckBox.Name = "RecordPassWd_CheckBox";
            this.RecordPassWd_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.RecordPassWd_CheckBox.TabIndex = 10;
            this.RecordPassWd_CheckBox.Text = "记住密码";
            this.RecordPassWd_CheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(714, 311);
            this.ControlBox = false;
            this.Controls.Add(this.RecordPassWd_CheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ForgetPasswd_LinkLabel);
            this.Controls.Add(this.PassWord_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserName_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Titie);
            this.Controls.Add(this.TopsailLogo_PictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TopsailLogo_PictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TopsailLogo_PictureBox;
        private System.Windows.Forms.Label Titie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserName_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PassWord_TextBox;
        private System.Windows.Forms.LinkLabel ForgetPasswd_LinkLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateUser_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.CheckBox RecordPassWd_CheckBox;
    }
}