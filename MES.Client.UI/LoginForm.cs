using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Service;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            Login_Btn?.Select();
        }

        
        private void UserName_TextBox_Enter(object sender, EventArgs e)
        {
            if (UserName_TextBox?.Text == @"UserName")
            {
                UserName_TextBox.Clear();
                UserName_TextBox.ForeColor = Color.Black;
            }
        }


        private void PassWord_TextBox_Enter(object sender, EventArgs e)
        {
            if (PassWord_TextBox?.Text == @"PassWord")
            {
                PassWord_TextBox.Clear();
                PassWord_TextBox.ForeColor = Color.Black;
            }
        }


        private void UserName_TextBox_Leave(object sender, EventArgs e)
        {
            if (UserName_TextBox?.Text == String.Empty)
            {
                UserName_TextBox.ForeColor = Color.Gray;
                UserName_TextBox.Text = @"UserName";
            }
        }


        private void PassWord_TextBox_Leave(object sender, EventArgs e)
        {
            if (PassWord_TextBox?.Text == String.Empty)
            {
                PassWord_TextBox.ForeColor = Color.Gray;
                PassWord_TextBox.Text = @"PassWord";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(Environment.ExitCode);
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            LoginService loginService = new LoginService();
            LoginInfo loginInfo = loginService.GetToken(UserName_TextBox?.Text, PassWord_TextBox?.Text);
            if (loginInfo == null)
            {
                MessageBox.Show(Properties.Resources.LoginPassWordErro);
                return;
            }
            JToken userList = loginService.GetUserList(loginInfo);

            if (userList == null)
            {
                MessageBox.Show(Properties.Resources.RequestTimeOut);
                return;
            }

            foreach (var i in userList)
            {
                if (i?["userId"]?.ToString() == loginInfo.userId)
                {
                    loginInfo.User = i?["username"]?.ToString();
                    loginInfo.UserProcessPrivilege = i?["processnames"]?.ToString();
                    ProcessSelectionForm processSelectionForm = new ProcessSelectionForm(loginInfo);
                    new Thread(delegate () { processSelectionForm.ShowDialog(); }).Start();
                    this.Close();
                }
            }
        }
    }
}
