using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.BGSystem;
using Cheku.Types;
namespace Cheku
{
    public partial class SystemManageForm : Form
    {
        private static String DEBUG = "debugging：*************in SystemManageForm.cs: "; //DEBUG注释

        private CardOperater cardOpt;
        private BGSOperater bgsOpt;
        private EntranceSettingStr setting;
        private ChargeModeStr cms;




        public SystemManageForm()
        {
            InitializeComponent();
            cardOpt = CardOperater.GetInstance();
            bgsOpt = BGSOperater.GetInstance();
            //setting = bgsOpt.GetCurrentEntranceSetting();
            cms = bgsOpt.GetCurrentChargeMode(1);
            initComboBox();
        }

        private void initComboBox()
        {
            foreach (Command.enableOpt typeCode in Enum.GetValues(typeof(Command.enableOpt)))
            {
                String typeName = typeCode.ToString();//获取名称
                this.manageForm_enableCameraCombo.Items.Add(typeName);
                this.manageForm_enableManualCombo.Items.Add(typeName);
                this.manageForm_enableCReaderCombo.Items.Add(typeName);
                this.manageForm_enableCSenderCombo.Items.Add(typeName);
                this.manageForm_enableBGOffCombo.Items.Add(typeName);
                this.manageForm_enableBGOnCombo.Items.Add(typeName);
                this.manageForm_enableBGSCombo.Items.Add(typeName);
                this.manageForm_enableBGStopCombo.Items.Add(typeName);


                this.chargeMode_EnableMCValue_ComboBox.Items.Add(typeName);
                this.chargeMode_EnableFCValue_ComboBox.Items.Add(typeName);
                this.chargeMode_EnablePCValue_ComboBox.Items.Add(typeName);
                this.chargeMode_EnableTCValue_ComboBox.Items.Add(typeName);



            }
            for (int i = 1; i <=6; i++)
            {

                
                this.chargeMode_PCUnitValue_ComboBox.Items.Add(i*30);
                this.chargeMode_TCUnitValue_ComboBox.Items.Add(i*30);

            }
            for (int i = 1; i <= 50; i++)
            {
                this.chargeMode_PCUnitPayValue_ComboBox.Items.Add(i);
                this.chargeMode_TCUnitPayValue_ComboBox.Items.Add(i);
            }


            foreach (Command.SoftMode cm in (Command.SoftMode[])System.Enum.GetValues(typeof(Command.SoftMode)))
            manageForm_SystemModeCombo.Items.Add(cm.ToString());

            manageForm_SystemModeCombo.SelectedItem = bgsOpt.SMode.ToString();

            manageForm_ServerAddrText.Text = bgsOpt.ServerAddr;

            if (bgsOpt.SMode == Command.SoftMode.主机)
            {
                manageForm_ServerAddrText.Enabled = false;
                manageForm_ChannelApplyButton.Enabled = false;
            }
            else
            {
                manageForm_ServerAddrText.Enabled = true;
                manageForm_ChannelApplyButton.Enabled = true;

            }

        }


        private void reLoadCurrentSetting()
        {
            setting = bgsOpt.GetCurrentEntranceSetting(Convert.ToInt32(this.manageForm_ModeNameCombo.SelectedValue.ToString()));
            loadSetting();

        }
        private void loadSetting()
        {
            this.manageForm_enableCameraCombo.SelectedItem = boolToString(setting.enableCamera);
            this.manageForm_enableManualCombo.SelectedItem = boolToString(setting.enableBGManual);
            this.manageForm_enableCReaderCombo.SelectedItem = boolToString(setting.enableCReader);
            this.manageForm_enableCSenderCombo.SelectedItem = boolToString(setting.enableCSender);
            this.manageForm_enableBGOffCombo.SelectedItem = boolToString(setting.enableBGOff);
            this.manageForm_enableBGOnCombo.SelectedItem = boolToString(setting.enableBGOn);
            this.manageForm_enableBGSCombo.SelectedItem = boolToString(setting.enableBGS);
        }
        private bool saveCurrentSetting()
        {
            setting.modeName = this.manageForm_SettingRenameText.Text == String.Empty ? setting.modeName : this.manageForm_SettingRenameText.Text; 
            setting.enableCamera=stringToBool( this.manageForm_enableCameraCombo.SelectedItem.ToString()); 
            setting.enableBGManual=stringToBool(this.manageForm_enableManualCombo.SelectedItem.ToString());
            setting.enableCReader=stringToBool(this.manageForm_enableCReaderCombo.SelectedItem.ToString());
            setting.enableCSender=stringToBool(this.manageForm_enableCSenderCombo.SelectedItem.ToString());
            setting.enableBGOff  =stringToBool(this.manageForm_enableBGOffCombo.SelectedItem.ToString());
            setting.enableBGOn  =stringToBool(this.manageForm_enableBGOnCombo.SelectedItem.ToString());
            setting.enableBGS = stringToBool(this.manageForm_enableBGSCombo.SelectedItem.ToString());

            return bgsOpt.SetCurrentEntranceSetting(setting);

        }

        private void reLoadCurrentChargeMode()
        {
            cms = bgsOpt.GetCurrentChargeMode(Convert.ToInt32(manageForm_ChargeModeNameCombo.SelectedValue.ToString()));
            loadChargeMode();
           
        }

        private void loadChargeMode()
        {
            this.chargeMode_EnableMCValue_ComboBox.SelectedItem = boolToString(cms.enableYCard);
            this.chargeMode_EnableFCValue_ComboBox.SelectedItem = boolToString(cms.enableMFCard);
            this.chargeMode_EnablePCValue_ComboBox.SelectedItem = boolToString(cms.enableCZCard);
            this.chargeMode_EnableTCValue_ComboBox.SelectedItem = boolToString(cms.enableLSCard);
            this.chargeMode_PCUnitValue_ComboBox.SelectedItem = cms.unitCZCard;
            this.chargeMode_TCUnitValue_ComboBox.SelectedItem = cms.unitLSCard;
            this.chargeMode_PCUnitPayValue_ComboBox.SelectedItem = cms.unitPayCZCard;
            this.chargeMode_TCUnitPayValue_ComboBox.SelectedItem = cms.unitPayLSCard;
        }
        private bool saveCurrentChargeMode()
        {

            cms.enableYCard = stringToBool(this.chargeMode_EnableMCValue_ComboBox.SelectedItem.ToString());
            cms.enableMFCard = stringToBool(this.chargeMode_EnableFCValue_ComboBox.SelectedItem.ToString());
            cms.enableCZCard = stringToBool(this.chargeMode_EnablePCValue_ComboBox.SelectedItem.ToString());
            cms.enableLSCard = stringToBool(this.chargeMode_EnableTCValue_ComboBox.SelectedItem.ToString());
            cms.unitCZCard = Convert.ToInt32(this.chargeMode_PCUnitValue_ComboBox.SelectedItem.ToString());
            cms.unitLSCard = Convert.ToInt32(this.chargeMode_TCUnitValue_ComboBox.SelectedItem.ToString());
            cms.unitPayCZCard = Convert.ToInt32(this.chargeMode_PCUnitPayValue_ComboBox.SelectedItem.ToString());
            cms.unitPayLSCard = Convert.ToInt32(this.chargeMode_TCUnitPayValue_ComboBox.SelectedItem.ToString());

            return bgsOpt.SetCurrentChargeMode(cms);

        }

        private String boolToString(bool flag)
        {
            String str = flag ? Command.enableOpt.开启.ToString() : Command.enableOpt.关闭.ToString();
            return str;
        }
        private bool stringToBool (string str)
        {
            return  String.Equals(str,"开启") ;
        }

  

        private void manageForm_ModeNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            reLoadCurrentSetting();
        }

        private void manageForm_ChargeModeNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           reLoadCurrentChargeMode();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveCurrentSetting()) MessageBox.Show("道闸模式保存成功! (更改名称将在下次打开程序生效)", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("保存失败", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (saveCurrentSetting() && saveCurrentChargeMode()) MessageBox.Show("保存成功! (更改名称将在下次打开程序生效)", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("保存失败", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void ManageForm_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbChargeMode”中。您可以根据需要移动或删除它。
            this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbConfigModel”中。您可以根据需要移动或删除它。
            this.dbConfigModeTableAdapter.Fill(this.dbBGSDataSet.dbConfigMode);
            reLoadCurrentSetting();
            reLoadCurrentChargeMode();
        }

        private void manageForm_enableBGSCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void manageForm_ModeRenameButton_Click(object sender, EventArgs e)
        {

        }

        private void manageForm_SettingRenameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void manageForm_SavaChargeModeButton_Click(object sender, EventArgs e)
        {
            if (saveCurrentChargeMode()) MessageBox.Show("收费模式保存成功 (更改名称将在下次打开程序生效)", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("保存失败", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (saveCurrentSetting() && saveCurrentChargeMode()) MessageBox.Show("保存成功 (更改名称将在下次打开程序生效)", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("保存失败", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void manageForm_ChargeModeRenameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void manageForm_SettingRenameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bgsOpt.SMode = (Command.SoftMode)Enum.Parse(typeof(Command.SoftMode), this.manageForm_SystemModeCombo.SelectedItem.ToString());
             bgsOpt.ServerAddr = manageForm_ServerAddrText.Text;
            if (manageForm_Rs485PortCombo.SelectedItem != null)
            {
                bgsOpt.Rs485PortSetter(manageForm_Rs485PortCombo.SelectedItem.ToString());
            }
            else
            {
                Console.WriteLine(DEBUG + "manageForm_Rs485PortCombo.SelectedItem  == null");   //*******************DEBUGGING*****************
            }
            bgsOpt.saveDefaultSetting();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bgsOpt.ChannelApply();
        }

        private void manageForm_SystemModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
