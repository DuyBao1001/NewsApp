using NewsApp.BLL;
using NewsApp.Data;
using System;
using System.Windows.Forms;

namespace NewsApp.UI
{
    public partial class LoginForm : Form
    {
        private readonly AccountServices _accountServices;

        public LoginForm()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '●';

            _accountServices = new AccountServices();
            _accountServices.ConnectionStatusChanged += (status) =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => MessageBox.Show(status, "Thông tin kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information)));
                }
                else
                {
                    MessageBox.Show(status, "Thông tin kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            _accountServices.LoginResult += (user, message) =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => ProcessLoginResult(user, message)));
                }
                else
                {
                    ProcessLoginResult(user, message);
                }
            };
        }

        private void ProcessLoginResult(User? user, string message)
        {
            
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void LinkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}