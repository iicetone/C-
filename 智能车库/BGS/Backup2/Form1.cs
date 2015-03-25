using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestSettings
{
    public partial class Form1 : Form
    {
        private MainForm maiformSetting = new MainForm();

        public Form1()
        {
            InitializeComponent();

            ReadSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            maiformSetting.chk1 = this.checkBox1.Checked;

            maiformSetting.chk2 = this.checkBox2.Checked;

            maiformSetting.chk3 = this.checkBox3.Checked;

            maiformSetting.chk4 = this.checkBox4.Checked;

            maiformSetting.Save();
        }

        private void ReadSetting()
        {
            this.checkBox1.Checked = maiformSetting.chk1;

            this.checkBox2.Checked = maiformSetting.chk2;

            this.checkBox3.Checked = maiformSetting.chk3;

            this.checkBox4.Checked = maiformSetting.chk4;

            this.Update();
        }
    }
}
