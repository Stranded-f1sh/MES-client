using System;
using System.Data;
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
        private DataSet _userPassWd;
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            UserName_TextBox.AutoCompleteCustomSource = null;
            PassWord_TextBox.AutoCompleteCustomSource = null;
            LoginService loginService = new LoginService();
            _userPassWd = loginService.GetUserPassWdCache();
            if (_userPassWd == null) return;
            if (_userPassWd?.Tables[0]?.Rows.Count != 0)
            {
                foreach (DataRow dr in _userPassWd.Tables[0].Rows)
                {
                    UserName_TextBox.AutoCompleteCustomSource?.Add(dr[1].ToString());
                    PassWord_TextBox.AutoCompleteCustomSource?.Add(dr[2].ToString());
                }

                foreach (DataRow dr in _userPassWd.Tables[0].Rows)
                {
                    UserName_TextBox.Text = dr[1].ToString();
                    break;
                }

            }
            UserName_TextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            PassWord_TextBox.AutoCompleteMode = AutoCompleteMode.Suggest;

            UserName_TextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            PassWord_TextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
                if (i?["userId"]?.ToString() == loginInfo.userId.ToString())
                {
                    loginInfo.User = i["username"]?.ToString();
                    loginInfo.UserProcessPrivilege = i["processnames"]?.ToString();
                    loginInfo.UserList = userList;
                    ProcessSelectionForm processSelectionForm = new ProcessSelectionForm(loginInfo);
                    new Thread(delegate () { processSelectionForm.ShowDialog(); }).Start();
                    if (RecordPassWd_CheckBox.Checked)
                    {
                        bool isFondRecord = false;
                        foreach (DataRow dr in _userPassWd.Tables[0].Rows)
                        {
                            if (loginInfo.userId.ToString() == dr[0].ToString())
                            {
                                isFondRecord = true;
                            }
                        }

                        if (!isFondRecord)
                        {
                            loginService.SetUserPassWd(loginInfo);
                        }
                        else
                        {
                            loginService.UpDateUserPassWd(loginInfo);
                        }
                    }
                    this.Close();
                }
            }
        }



        private void UserName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_userPassWd?.Tables[0] == null) return;
            foreach (DataRow dr in _userPassWd.Tables[0].Rows)
            {
                if (UserName_TextBox.Text == dr[1].ToString())
                {
                    UserName_TextBox.ForeColor = Color.Black;
                    PassWord_TextBox.ForeColor = Color.Black;
                    PassWord_TextBox.Text = dr[2].ToString();
                }
            }
        }

        private void Login_Btn_KeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            if (eventArgs != null && eventArgs.KeyChar != Convert.ToChar(13)) return;
            Login_Btn_Click(sender, eventArgs);
        }



        private void UserName_TextBox_Click(object sender, EventArgs e)
        {
            UserName_TextBox.Select(0, UserName_TextBox.Text.Length);
        }
    }
}
