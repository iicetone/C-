using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VWMS.CommonClass;
using Microsoft.Win32;

namespace VWMS
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        SoftReg softreg = new SoftReg();
        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtMNum.Text = softreg.getMNum();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtRNum.Text.Equals(softreg.getRNum()))
            {
                RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("wxk").CreateSubKey("wxk.INI").CreateSubKey(txtRNum.Text);
                retkey.SetValue("UserName", "tsoft");
                MessageBox.Show("ע��ɹ�!", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showMain();
            }
            else
            {
                MessageBox.Show("ע�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            showMain();
        }
        //����ע�ᴰ�壬��ʾ������
        public void showMain()
        {
            this.Hide();
            frmMain frmmain = new frmMain();
            frmmain.Show();
        }
    }
}