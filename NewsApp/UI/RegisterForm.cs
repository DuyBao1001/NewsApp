using System;
using System.Windows.Forms;
using NewsApp.BLL;
using NewsApp.Data;

namespace NewsApp.UI
{
    public partial class RegisterForm : Form
    {
        private readonly AccountServices _accountServices;

        public RegisterForm()
        {
            InitializeComponent();

            // Cài đặt mặc định
            tbPassword.PasswordChar = '●';
            tbConfirmPass.PasswordChar = '●';

            // Mặc định chọn role là Reader
            cboxReader.Checked = true;
            cboxWriter.Checked = false;

            // Khởi tạo AccountServices
            _accountServices = new AccountServices();

            // Subscribe events
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

            _accountServices.RegisterResult += (success, message) =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => ProcessRegisterResult(success, message)));
                }
                else
                {
                    ProcessRegisterResult(success, message);
                }
            };

            this.btnRegister.Click += new EventHandler(BtnRegister_Click);
            this.linkLabelLogin.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabelLogin_LinkClicked);


            this.cboxReader.CheckedChanged += new EventHandler(cboxReader_CheckedChanged);
            this.cboxWriter.CheckedChanged += new EventHandler(cboxWriter_CheckedChanged);
        }

        private void ProcessRegisterResult(bool success, string message)
        {
            
        }

        private void cboxReader_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cboxWriter_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        // --- XỬ LÝ ĐĂNG KÝ ---

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}