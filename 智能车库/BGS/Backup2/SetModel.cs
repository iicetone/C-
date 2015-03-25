using System;
using System.Collections.Generic;
using System.Text;

namespace TestSettings
{
    public class SetModel
    {
        public bool Checbox1
        {
            get
            {
                return MainForm.Default.chk1;
            }
            set
            {
                MainForm.Default.chk1 = value;
            }
        }

        public bool Checbox2
        {
            get
            {
                return MainForm.Default.chk2;
            }
            set
            {
                MainForm.Default.chk2 = value;
            }
        }

        public bool Checbox3
        {
            get
            {
                return MainForm.Default.chk3;
            }
            set
            {
                MainForm.Default.chk3 = value;
            }
        }

        public bool Checbox4
        {
            get
            {
                return MainForm.Default.chk4;
            }
            set
            {
                MainForm.Default.chk4 = value;
            }
        }
    }
}
