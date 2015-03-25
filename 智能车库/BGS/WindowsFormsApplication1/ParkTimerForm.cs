using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.Types;
using Cheku.BGSystem;

namespace Cheku
{
    public partial class ParkTimerForm : Form
    {
        private BGSOperater bgsOpt;
        private int id;
        private Command.TimerType type;
        public ParkTimerForm(Command.TimerType type , int id)
        {
             bgsOpt = BGSOperater.GetInstance();
             this.id = id;
             this.type = type;
            InitializeComponent();

            if (type == Command.TimerType.PARK)
            {
                this.pTForm_TimerMode_Combo.DataSource = this.dbChargeModeBindingSource;
                this.pTForm_AfterTimerMode_Combo.DataSource = this.dbChargeModeBindingSource1;
                ParkUnit park = bgsOpt.GetCurrentPark(id);
                pTForm_Name_Label.Text = park.parkName + " 定时设置";
                if (park.TimerList != null)
                {
                    foreach (BGSTimerStr timer in park.TimerList)
	                {
                        pTForm_TimerList_ListBox.Items.Add(timerToString(timer,true));
	                }
                }

            }
            else if (type == Command.TimerType.ENTRANCE)
            {
                this.pTForm_TimerMode_Combo.DataSource = this.dbConfigModeBindingSource;
                this.pTForm_AfterTimerMode_Combo.DataSource = this.dbConfigModeBindingSource1;
                EntranceUnit entr = bgsOpt.GetCurrentEntrance(id);
                pTForm_Name_Label.Text = entr.entranceName + " 定时设置";
                if (entr.TimerList != null)
                {
                    foreach (BGSTimerStr timer in entr.TimerList)
                    {
                        pTForm_TimerList_ListBox.Items.Add(timerToString(timer, false));
                    }
                }
            }
            this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);
            this.dbConfigModeTableAdapter.Fill(this.dbBGSDataSet.dbConfigMode);

            pTForm_AfterTimerMode_Combo.SelectedIndex = 0;
            pTForm_TimerMode_Combo.SelectedIndex = 0;
            pTForm_EndTimeHour_Combo.SelectedIndex = 0;
            pTForm_EndTimeMinute_Combo.SelectedIndex = 0;
            pTForm_StartTimeHour_Combo.SelectedIndex = 0;
            pTForm_StartTimeMinute_Combo.SelectedIndex = 0;

        }

        private String timerToString(BGSTimerStr timer,bool isChannel)
        {
            string modeName = isChannel ? bgsOpt.GetCurrentChargeMode(timer.ChargeModeID).modeName 
                :bgsOpt.GetCurrentEntranceSetting(timer.EntranceSettingID).modeName;
            return "" + timer.StartTimeHour.ToString() + " 时 " + timer.StartTimeMinute.ToString() + " 分 " + "\r\n"
                + "===> " + timer.EndTimeHour.ToString() + " 时 " + timer.EndTimeMinute.ToString() + " 分 " + "\r\n"
                + " : " + modeName;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pTForm_AddTimer_Button_Click(object sender, EventArgs e)
        {
            BGSTimerStr timer = new BGSTimerStr();

            timer.StartTimeHour = Convert.ToInt32(pTForm_StartTimeHour_Combo.SelectedItem.ToString());
            timer.StartTimeMinute = Convert.ToInt32(pTForm_StartTimeMinute_Combo.SelectedItem.ToString());
            timer.EndTimeHour = Convert.ToInt32(pTForm_EndTimeHour_Combo.SelectedItem.ToString());
            timer.EndTimeMinute = Convert.ToInt32(pTForm_EndTimeMinute_Combo.SelectedItem.ToString());
            if (type == Command.TimerType.PARK)
            {
                timer.ParkID = id;
                timer.ChargeModeID = Convert.ToInt32(pTForm_TimerMode_Combo.SelectedValue.ToString());
                timer.AfterChargeModeID = Convert.ToInt32(pTForm_AfterTimerMode_Combo.SelectedValue.ToString());
                pTForm_TimerList_ListBox.Items.Add(timerToString(timer, true));
            }
            else
            {
                timer.EntranceID = id;
                timer.EntranceSettingID = Convert.ToInt32(pTForm_TimerMode_Combo.SelectedValue.ToString());
                timer.AfterEntranceSettingID = Convert.ToInt32(pTForm_AfterTimerMode_Combo.SelectedValue.ToString());
                pTForm_TimerList_ListBox.Items.Add(timerToString(timer, false));
            }

            bgsOpt.bgsTimerAdd(type,id,timer);
        }

        private void pTForm_DeleteTimer_Button_Click(object sender, EventArgs e)
        {
            if (pTForm_TimerList_ListBox.SelectedIndex >= 0)
            {
                bgsOpt.bgsTimerDelete(type, id, pTForm_TimerList_ListBox.SelectedIndex);
                pTForm_TimerList_ListBox.Items.Remove(pTForm_TimerList_ListBox.SelectedItem);
            }
        }

        private void pTForm_ClearTimer_Button_Click(object sender, EventArgs e)
        {
            pTForm_TimerList_ListBox.Items.Clear();
            bgsOpt.bgsTimerClear(type, id);

        }
    }
}
