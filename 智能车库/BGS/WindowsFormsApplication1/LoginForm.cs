using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.DataManager;
using Cheku.BGSystem;

namespace Cheku
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProName = new ErrorProvider();
            if (textName.Text == "")
            {
                errorProName.SetError(textName, "用户名不能为空!");
            }
            else
            {

                errorProName.Clear();


                if (DataOperater.VerifyUser_DO(textName.Text, textPwd.Text))
               
                {
                    this.Hide();
                    MainForm mainF = new MainForm();
                    mainF.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textPwd.Focus();
                e.Handled = true;
            }

        }
        private void textPwd_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
                e.Handled = true;
            }

        }
}
}

