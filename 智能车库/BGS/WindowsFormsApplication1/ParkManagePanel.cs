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
    public partial class ParkManagerPanel : Panel

    {
        private BGSOperater bgsOpt;
        private ChannelUnit curChan;
        private EntranceUnit curEntr;
        private ParkUnit curPark;

        public ParkManagerPanel() 
        {
            InitializeComponent();
            bgsOpt = BGSOperater.GetInstance();

            //   this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);

            foreach (Command.ChannelMode cm in (Command.ChannelMode[])System.Enum.GetValues(typeof(Command.ChannelMode)))
                pMForm_ChannelMode_Combo.Items.Add(cm.ToString());
            foreach (EntranceTypeEnum cm in (EntranceTypeEnum[])System.Enum.GetValues(typeof(EntranceTypeEnum)))
                pMForm_DeviceType_Combo.Items.Add(cm.ToString());
            foreach (EntranceModeEnum cm in (EntranceModeEnum[])System.Enum.GetValues(typeof(EntranceModeEnum)))
                pMForm_DeviceContectType_Combo.Items.Add(cm.ToString());


            loadTreeView();
            loadPanel();
            loadConfigPanel();
            loadChargePanel();


            bgsOpt.entranceStatusMessageArrived += displayEntranceStatusMessage;
            bgsOpt.channelStatusMessageArrived += displayChannelStatusMessage;

        }

        private void loadTreeView()
        {

            foreach (ParkUnit park in bgsOpt.ParkList)
            {
                if (park.channelCount == 0) continue; 

                TreeNode rootnode = new TreeNode();
                rootnode.Tag = park.parkID;
                rootnode.Text = park.parkName;
                pMForm_ChannelManager_TreeView.Nodes.Add(rootnode);
             foreach (ChannelUnit chan in bgsOpt.ChannelList)
            {
                TreeNode node = new TreeNode();
                node.Tag = chan.channelID;
                node.Text = chan.channelName;
                rootnode.Nodes.Add(node);
                if (chan.entranceCount == 0) continue; 
                    foreach (EntranceUnit ent in bgsOpt.EntranceList)
                    {
                        if (ent.channelID != chan.channelID) continue;
                        
                            TreeNode childNode = new TreeNode();
                            childNode.Tag = ent.entranceID;
                            childNode.Text = ent.entranceName;
                            node.Nodes.Add(childNode);
                        
                    }
            }
             rootnode.ExpandAll();

        }
        }

        private void loadConfigPanel()
        {
            if (curEntr.entranceID != 0)
	        {
            groupBox5.Enabled = true;
            this.dbConfigModeTableAdapter.Fill(this.dbBGSDataSet.dbConfigMode);

            pMForm_EntranceConfig_Combo.SelectedValue = curEntr.entranceSetting.settingID;

            if (curEntr.entranceSetting.settingID < 4)
                groupBox4.Enabled = false;
            else
                groupBox4.Enabled = true;

            pMForm_EnableBGS_Check.Checked = curEntr.entranceSetting.enableBGS;
            pMForm_EnableBGSR_Check.Checked = curEntr.entranceSetting.enableBGSRpeat;
            pMForm_EnableBGSOn_Check.Checked = curEntr.entranceSetting.enableBGOn;
            pMForm_EnableBGSOnUp_Check.SelectedItem = curEntr.entranceSetting.enableBGOnUp.ToString();
            pMForm_EnableBGSOff_Check.Checked = curEntr.entranceSetting.enableBGOff;
            pMForm_EnableBGSOffDelay_Check.SelectedItem = curEntr.entranceSetting.enableBGOffDelay.ToString();
            pMForm_EnableBGManual_Check.Checked = curEntr.entranceSetting.enableBGManual;
            pMForm_EnableCReader_Check.Checked = curEntr.entranceSetting.enableCReader;
            pMForm_EnableCReaderB_Check.Checked = curEntr.entranceSetting.enableCReaderB;
            pMForm_EnableCReaderI_Check.Checked = curEntr.entranceSetting.enableCReaderI;
            pMForm_EnableCSender_Check.Checked = curEntr.entranceSetting.enableCSender;
            pMForm_EnableCCam_Check.Checked = curEntr.entranceSetting.enableCamera;
            pMForm_EnableCDG1_Check.Checked = curEntr.entranceSetting.enableDG1;
            pMForm_EnableCDG1P_Check.Checked = curEntr.entranceSetting.enableDG1P;
            pMForm_EnableCDG2_Check.Checked = curEntr.entranceSetting.enableDG2;
            pMForm_EnableCDG2P_Check.Checked = curEntr.entranceSetting.enableDG2P;
            pMForm_EnableLED_Check.Checked = curEntr.entranceSetting.enableLED;
            pMForm_EnableVoice_Check.Checked = curEntr.entranceSetting.enableVoice;

            }
            else 
           {
            groupBox5.Enabled = false;
           }

        }
        private void   loadChargePanel()
        {
            if (curPark.parkID != 0)
            {
                groupBox11.Enabled = true;
                this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);

                manageForm_ChargeModeName_Combo.SelectedValue = curPark.parkChargeModeID;
                pMForm_enableCZCard_Radio.Checked = curPark.parkChargeMode.enableCZCard;
                pMForm_enableLSCard_Radio.Checked = curPark.parkChargeMode.enableLSCard;
                pMForm_enableRCard_Radio.Checked = curPark.parkChargeMode.enableRCard;
                pMForm_enableYCard_Radio.Checked = curPark.parkChargeMode.enableYCard;
                pMForm_enableYGCard_Radio.Checked = curPark.parkChargeMode.enableYGCard;
                pMForm_enableTQCard_Radio.Checked = curPark.parkChargeMode.enableTQCard;
                pMForm_enableSQCard_Radio.Checked = curPark.parkChargeMode.enableSQCard;
                pMForm_enableMFCard_Radio.Checked = curPark.parkChargeMode.enableMFCard;
                if (curPark.parkChargeMode.modeSQCard)
                {
                    pMForm_SQCardModeS_Radio.Checked = true;
                }
                else pMForm_SQCardModeD_Radio.Checked = true;


            }
            else
            {
                groupBox11.Enabled = false;
            }

        }
        private void   loadPanel()
        {
            if (curPark.parkID != 0)
            {
                pMForm_Park_Panel.Enabled = true;

                pMForm_TotalSpace_Text.Text = bgsOpt.TotalSpace.ToString();
                pMForm_OccupiedSpace_Text.Text = bgsOpt.OccupiedSpace.ToString();
                pMForm_RamainSpace_Text.Text = bgsOpt.RemainSpace.ToString();
                if (curChan.channelID != 0)
                {
                    pMForm_Channel_Panel.Enabled = true;

                    pMForm_ChannelID_Text.Text = curChan.channelID.ToString();
                    pMForm_ChannelName_Text.Text = curChan.channelName;
                    pMForm_ChannelMode_Combo.SelectedItem = curChan.channelMode.ToString();
                    //  pMForm_ChannelChargeMode_Combo.SelectedItem = curChan.channelChargeMode.modeName.ToString();
                    pMForm_ChannelAddr_Text.Text = curChan.stationAddr;
                    pMForm_ChannelStatus_Text.Text = curChan.channelStatus.ToString();

                    if (curEntr.entranceID != 0)
                    {
                        pMForm_Device_Panel.Enabled = true;
                        pMForm_DeviceID_Text.Text = curEntr.entranceID.ToString();
                        pMForm_DeviceName_Text.Text = curEntr.entranceName.ToString();
                        pMForm_DeviceType_Combo.SelectedItem = curEntr.entranceType.ToString();
                        pMForm_DeviceContectType_Combo.SelectedItem = curEntr.entranceMode.ToString();
                        pMForm_DeviceStatus_Text.Text = curEntr.entranceStatus.statusBGS.ToString();
                        pMForm_DeviceAddr_Text.Text = curEntr.entranceMode == EntranceModeEnum.RS485 ? curEntr.rs485Addr : curEntr.tcpAddr;

                    }
                    else
                    {
                        pMForm_DeviceID_Text.Text = "请选择设备";
                        pMForm_Device_Panel.Enabled = false;
                    }
                }
                else
                {
                    pMForm_ChannelID_Text.Text = "请选择通道";
                    pMForm_Channel_Panel.Enabled = false;
                    pMForm_DeviceID_Text.Text = "请选择设备";
                    pMForm_Device_Panel.Enabled = false;
                }
            }
            else
            {
                pMForm_TotalSpace_Text.Text ="请选择停车场";
                pMForm_Park_Panel.Enabled = false;
                pMForm_ChannelID_Text.Text = "请选择通道";
                pMForm_Channel_Panel.Enabled = false;
                pMForm_DeviceID_Text.Text = "请选择设备";
                pMForm_Device_Panel.Enabled = false;
            }


        }
        private void getChannelFormInfo()
        {

            curChan.channelName = pMForm_ChannelName_Text.Text;
            curChan.channelMode = (Command.ChannelMode)Enum.Parse(typeof(Command.ChannelMode), pMForm_ChannelMode_Combo.SelectedItem.ToString());
            curChan.stationAddr = pMForm_ChannelAddr_Text.Text;


        }
        private void getDeviceFormInfo()
        {

            curEntr.entranceName = pMForm_DeviceName_Text.Text;
            curEntr.entranceType = (EntranceTypeEnum)Enum.Parse(typeof(EntranceTypeEnum), pMForm_DeviceType_Combo.SelectedItem.ToString());
            curEntr.entranceMode = (EntranceModeEnum)Enum.Parse(typeof(EntranceModeEnum), pMForm_DeviceContectType_Combo.SelectedItem.ToString());
            curEntr.entranceStatus.statusBGS = (Command.BGSstatus)Enum.Parse(typeof(Command.BGSstatus), pMForm_DeviceStatus_Text.Text);
            if (curEntr.entranceMode == EntranceModeEnum.RS485)
            {
                curEntr.rs485Addr = pMForm_DeviceAddr_Text.Text;
            }
            else curEntr.tcpAddr = pMForm_DeviceAddr_Text.Text;
        }
        private void updateChannel()
        {
            if (pMForm_ChannelManager_TreeView.SelectedNode != null && pMForm_ChannelManager_TreeView.SelectedNode.Level == 1)
            {
            getChannelFormInfo();
            ChannelUnit temp = bgsOpt.GetCurrentChannel(curChan.channelID);
            temp.channelID = curChan.channelID;
            temp.channelName = curChan.channelName;
            temp.channelMode = curChan.channelMode;
            //  temp.channelChargeMode = curChan.channelChargeMode;
            temp.stationAddr = curChan.stationAddr;
            //  temp.channelStatus = curChan.channelStatus;

                temp.entranceCount = pMForm_ChannelManager_TreeView.SelectedNode.Nodes.Count;
            
            curChan = temp;
            bgsOpt.SetCurrentChannel(temp);
            pMForm_ChannelManager_TreeView.SelectedNode.Text = curChan.channelName;

            }
            //else
            //{
            //    //未选择通道,不进行更新
            //}
        }
        private void updateDevice()
        {

            if (pMForm_ChannelManager_TreeView.SelectedNode != null && pMForm_ChannelManager_TreeView.SelectedNode.Level == 2)
            {
            getDeviceFormInfo();
            EntranceUnit tempE = bgsOpt.GetCurrentEntrance(curEntr.entranceID);
            tempE.entranceID = curEntr.entranceID;
            tempE.entranceName = curEntr.entranceName;
            tempE.entranceType = curEntr.entranceType;
            tempE.entranceMode = curEntr.entranceMode;
            //     tempE.entranceStatus = curEntr.entranceStatus;
            if (curEntr.entranceMode == EntranceModeEnum.RS485)
                tempE.rs485Addr = curEntr.rs485Addr;
            else tempE.tcpAddr = curEntr.tcpAddr;
            curEntr = tempE;
            bgsOpt.SetCurrentEntrance(tempE);
            pMForm_ChannelManager_TreeView.SelectedNode.Text = curEntr.entranceName;



            }


        }

        private void addChannel()
        {
            if (pMForm_ChannelManager_TreeView.SelectedNode != null && pMForm_ChannelManager_TreeView.SelectedNode.Level == 0)
            {
                curChan = new ChannelUnit();
                curChan.channelName = "新通道";
                curChan.entranceCount = 0;
                curChan.stationAddr = "0";
                curChan.parkID = curPark.parkID;
                curChan.channelID = bgsOpt.AddCurrentChannel(curChan);

                TreeNode newCNode = new TreeNode();
                newCNode.Tag = curChan.channelID;
                newCNode.Text = curChan.channelName;
                pMForm_ChannelManager_TreeView.SelectedNode.Nodes.Add(newCNode);
                pMForm_ChannelManager_TreeView.SelectedNode = newCNode;
                loadPanel();

                addDevice();
                pMForm_ChannelManager_TreeView.SelectedNode = newCNode;

                addDevice();
                pMForm_ChannelManager_TreeView.SelectedNode = newCNode;
               // updateChannel();
            }
            else
            {
                MessageBox.Show("请先选择一个停车场！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void addDevice()
        {
            if (pMForm_ChannelManager_TreeView.SelectedNode != null && pMForm_ChannelManager_TreeView.SelectedNode.Level == 1)
            {
                curEntr = new EntranceUnit();
                curEntr.entranceName = "新设备";
                curEntr.entranceMode = EntranceModeEnum.RS485;
                curEntr.entranceType = EntranceTypeEnum.入库控制器;
                curEntr.entranceSettingID = 1;
                curEntr.rs485Addr = "0";
                curEntr.tcpAddr = "0";
                curEntr.channelID = (Int32)pMForm_ChannelManager_TreeView.SelectedNode.Tag;
                curEntr.entranceID = bgsOpt.AddCurrentEntrance(curEntr);

                // updateChannel();

                TreeNode newCNode = new TreeNode();
                newCNode.Tag = curEntr.entranceID;
                newCNode.Text = curEntr.entranceName;
                pMForm_ChannelManager_TreeView.SelectedNode.Nodes.Add(newCNode);
                updateChannel();
                pMForm_ChannelManager_TreeView.SelectedNode = newCNode;
                loadPanel();
            }
            else
            {
                MessageBox.Show("只能在通道内添加设备,请先选择一个通道,或者添加通道！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void pMForm_ChannelManager_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (pMForm_ChannelManager_TreeView.SelectedNode != null)
            {
                if (pMForm_ChannelManager_TreeView.SelectedNode.Parent == null)
                {
                    curChan.channelID = 0;
                    curEntr.entranceID = 0;
                    curPark = bgsOpt.GetCurrentPark((int)pMForm_ChannelManager_TreeView.SelectedNode.Tag);
                    //选中的为停车场
                    this.loadPanel();
                    this.loadChargePanel();

                }
                else if (pMForm_ChannelManager_TreeView.SelectedNode.Parent.Parent == null)
                {
                    //选中的是通道
                    curPark = bgsOpt.GetCurrentPark((int)pMForm_ChannelManager_TreeView.SelectedNode.Parent.Tag);
                    curChan = bgsOpt.GetCurrentChannel((int)pMForm_ChannelManager_TreeView.SelectedNode.Tag);
                    curEntr.entranceID = 0;
                    this.loadPanel();
                }
                else if (pMForm_ChannelManager_TreeView.SelectedNode.Parent.Parent.Parent == null)
                {
                    //选中的是设备
                    curPark = bgsOpt.GetCurrentPark((int)pMForm_ChannelManager_TreeView.SelectedNode.Parent.Parent.Tag);
                    curChan = bgsOpt.GetCurrentChannel((int)pMForm_ChannelManager_TreeView.SelectedNode.Parent.Tag);
                    curEntr = bgsOpt.GetCurrentEntrance((int)pMForm_ChannelManager_TreeView.SelectedNode.Tag);
                   this. loadConfigPanel();
                    this.loadPanel();
                }

            }
        }


        private void pMForm_UpdateChannel_Button_Click(object sender, EventArgs e)
        {
            updateChannel();
        }

        private void pMForm_UpdateDevice_Button_Click(object sender, EventArgs e)
        {

            updateDevice();
        }

        private void pMForm_AddChannel_Button_Click(object sender, EventArgs e)
        {
            addChannel();
        }

        private void pMForm_AddDevice_Button_Click(object sender, EventArgs e)
        {
            addDevice();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bgsOpt.TotalSpace = Convert.ToInt32(pMForm_TotalSpace_Text.Text);
            bgsOpt.OccupiedSpace = Convert.ToInt32(pMForm_OccupiedSpace_Text.Text);
            bgsOpt.RemainSpace = Convert.ToInt32(pMForm_RamainSpace_Text.Text);



        }

        private void pMForm_TotalSpace_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("只能输入数字", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            int occ =  Convert.ToInt32(pMForm_TotalSpace_Text.Text) - Convert.ToInt32(pMForm_RamainSpace_Text.Text);
            pMForm_OccupiedSpace_Text.Text = occ.ToString();
        }


        private void pMForm_ChannelConfig_Button_Click(object sender, EventArgs e)
        {
            ParkTimerForm mForm = new ParkTimerForm(Command.TimerType.PARK,curPark.parkID);
          //  mForm.Owner = this;
            mForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParkTimerForm mForm = new ParkTimerForm(Command.TimerType.ENTRANCE, curEntr.entranceID);
            //  mForm.Owner = this;
            mForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (curEntr.entranceID != 0)
            {
                pMForm_DeviceStatus_Text.Text = Command.BGSstatus.测试中.ToString();
                MessageStc mes = new MessageStc();
                mes.park.selectedChannel.selectedEntrance = curEntr;
                mes.type = MessageTypeEnum.DEVICE_TEST;
                mes.ip = curEntr.tcpAddr;
                bgsOpt.DeployTest(mes);
            }
        }
        private void displayEntranceStatusMessage(object sender, MessageEventArgs e)
        {
            pMForm_DeviceStatus_Text.Text = Convert.ToString(e.Mes.info);
        }
        private void displayChannelStatusMessage(object sender, MessageEventArgs e)
        {
            pMForm_ChannelStatus_Text.Text = Convert.ToString(e.Mes.info);
        }
        private void pMForm_ChannelTest_Button_Click(object sender, EventArgs e)
        {
            if (curChan.channelID != 0)
            {
                pMForm_ChannelStatus_Text.Text = Command.BGSstatus.测试中.ToString();
                MessageStc mes = new MessageStc();
                mes.type = MessageTypeEnum.CHANNEL_TEST;
                mes.park.selectedChannel = curChan;
                mes.ip = curChan.stationAddr;
                bgsOpt.DeployTest(mes);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageStc mes = new MessageStc();
            mes.type = MessageTypeEnum.DEVICE_LEDL;
            mes.park.selectedChannel.selectedEntrance = curEntr;
            mes.ip = curEntr.tcpAddr;
            bgsOpt.DeployLED(mes);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pMForm_EntranceConfig_Text.Text))
                curEntr.entranceSetting.modeName = pMForm_EntranceConfig_Text.Text;

            curEntr.entranceSetting.enableBGS = pMForm_EnableBGS_Check.Checked;
            curEntr.entranceSetting.enableBGSRpeat = pMForm_EnableBGSR_Check.Checked;
            curEntr.entranceSetting.enableBGOn = pMForm_EnableBGSOn_Check.Checked;
            curEntr.entranceSetting.enableBGOnUp = Convert.ToInt32(pMForm_EnableBGSOnUp_Check.SelectedItem);
            curEntr.entranceSetting.enableBGOff = pMForm_EnableBGSOff_Check.Checked;
            curEntr.entranceSetting.enableBGOffDelay = Convert.ToInt32(pMForm_EnableBGSOffDelay_Check.SelectedItem);
            curEntr.entranceSetting.enableBGManual = pMForm_EnableBGManual_Check.Checked;
            curEntr.entranceSetting.enableCReader = pMForm_EnableCReader_Check.Checked;
            curEntr.entranceSetting.enableCReaderB = pMForm_EnableCReaderB_Check.Checked;
            curEntr.entranceSetting.enableCReaderI = pMForm_EnableCReaderI_Check.Checked;
            curEntr.entranceSetting.enableCSender = pMForm_EnableCSender_Check.Checked;
            curEntr.entranceSetting.enableCamera = pMForm_EnableCCam_Check.Checked;
            curEntr.entranceSetting.enableDG1 = pMForm_EnableCDG1_Check.Checked;
            curEntr.entranceSetting.enableDG1P = pMForm_EnableCDG1P_Check.Checked;
            curEntr.entranceSetting.enableDG2 = pMForm_EnableCDG2_Check.Checked;
            curEntr.entranceSetting.enableDG2P = pMForm_EnableCDG2P_Check.Checked;
            curEntr.entranceSetting.enableLED = pMForm_EnableLED_Check.Checked;
            curEntr.entranceSetting.enableVoice = pMForm_EnableVoice_Check.Checked;

            bgsOpt.SetCurrentEntranceSetting(curEntr.entranceSetting);
            bgsOpt.UpdateEntranceSetting(curEntr.entranceID, curEntr.entranceSettingID);
        }

        private void pMForm_saveChargeMode_Button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(manageForm_ChargeModeRename_Text.Text))
                curPark.parkChargeMode.modeName = manageForm_ChargeModeRename_Text.Text;

            curPark.parkChargeMode.enableCZCard = pMForm_enableCZCard_Radio.Checked;
            curPark.parkChargeMode.enableLSCard = pMForm_enableLSCard_Radio.Checked;
            curPark.parkChargeMode.enableRCard = pMForm_enableRCard_Radio.Checked;
            curPark.parkChargeMode.enableYCard = pMForm_enableYCard_Radio.Checked;
            curPark.parkChargeMode.enableYGCard = pMForm_enableYGCard_Radio.Checked;
            curPark.parkChargeMode.enableTQCard = pMForm_enableTQCard_Radio.Checked;
            curPark.parkChargeMode.enableSQCard = pMForm_enableSQCard_Radio.Checked;
            curPark.parkChargeMode.enableMFCard = pMForm_enableMFCard_Radio.Checked;
            curPark.parkChargeMode.modeSQCard = pMForm_SQCardModeS_Radio.Checked;
            bgsOpt.SetCurrentChargeMode(curPark.parkChargeMode);
            bgsOpt.UpdateParkChargeMode(curPark.parkID, curPark.parkChargeModeID);
            
        }


        private void manageForm_ChargeModeName_Combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            manageForm_ChargeModeRename_Text.Text = "";
            pMForm_unitCharge_Text.Text = "";
            pMForm_unitChargePay_Text.Text = "";
            pMForm_discount_Text.Text = "";
            pMForm_freeTime_Text.Text = "";
            pMForm_unitChargePayTime_Text.Text = "";
            pMForm_selectCZCard_Radio.Checked= false;
             pMForm_selectLSCard_Radio.Checked= false;
            pMForm_selectYGCard_Radio.Checked= false;
            pMForm_selectYCard_Radio.Checked= false;
            pMForm_selectRCard_Radio.Checked = false;
            curPark.parkChargeModeID = Convert.ToInt32(manageForm_ChargeModeName_Combo.SelectedValue);
            curPark.parkChargeMode = bgsOpt.GetCurrentChargeMode(curPark.parkChargeModeID);

            loadChargePanel();
        }

        private void pMForm_EntranceConfig_Combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pMForm_EntranceConfig_Text.Text = "";
            curEntr.entranceSettingID =  Convert.ToInt32(pMForm_EntranceConfig_Combo.SelectedValue);
            curEntr.entranceSetting = bgsOpt.GetCurrentEntranceSetting(curEntr.entranceSettingID);
            loadConfigPanel();
        }


        private void pMForm_selectYGCard_Radio_Click(object sender, EventArgs e)
        {
            if (pMForm_selectCZCard_Radio.Checked)
            {
                pMForm_unitCharge_Text.Text = curPark.parkChargeMode.unitCZCard.ToString();
                pMForm_unitChargePay_Text.Text = curPark.parkChargeMode.unitPayCZCard.ToString();
                pMForm_discount_Text.Text = curPark.parkChargeMode.discountCZCard.ToString();
                pMForm_freeTime_Text.Text = curPark.parkChargeMode.freeTimeCZCard.ToString();
            }
            else if (pMForm_selectLSCard_Radio.Checked)
            {
                pMForm_unitCharge_Text.Text = curPark.parkChargeMode.unitLSCard.ToString();
                pMForm_unitChargePay_Text.Text = curPark.parkChargeMode.unitPayLSCard.ToString();
                pMForm_discount_Text.Text = curPark.parkChargeMode.discountLSCard.ToString();
                pMForm_freeTime_Text.Text = curPark.parkChargeMode.freeTimeLSCard.ToString();
            }
            else if (pMForm_selectYGCard_Radio.Checked)
            {
                pMForm_unitCharge_Text.Text = curPark.parkChargeMode.unitYGCard.ToString();
                pMForm_unitChargePay_Text.Text = curPark.parkChargeMode.unitPayYGCard.ToString();
                pMForm_discount_Text.Text = curPark.parkChargeMode.discountYGCard.ToString();
                pMForm_freeTime_Text.Text = curPark.parkChargeMode.freeTimeYGCard.ToString();
            }
        }

        private void pMForm_selectRCard_Radio_Click(object sender, EventArgs e)
        {
            if (pMForm_selectYCard_Radio.Checked)
            {
                pMForm_unitChargePayTime_Text.Text = curPark.parkChargeMode.unitPayYCard.ToString();

            }
            else if (pMForm_selectRCard_Radio.Checked)
            {
                pMForm_unitChargePayTime_Text.Text = curPark.parkChargeMode.unitPayRCard.ToString();
            }
        }

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息

                return;

            base.WndProc(ref m);

        }

        private void pMForm_unitCharge_Text_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (pMForm_selectCZCard_Radio.Checked)
                {
                    curPark.parkChargeMode.unitCZCard = Convert.ToInt32(pMForm_unitCharge_Text.Text);
                    curPark.parkChargeMode.unitPayCZCard = Convert.ToInt32(pMForm_unitChargePay_Text.Text);
                    curPark.parkChargeMode.discountCZCard = Convert.ToInt32(pMForm_discount_Text.Text);
                    curPark.parkChargeMode.freeTimeCZCard = Convert.ToInt32(pMForm_freeTime_Text.Text);
                }
                else if (pMForm_selectLSCard_Radio.Checked)
                {
                    curPark.parkChargeMode.unitLSCard = Convert.ToInt32(pMForm_unitCharge_Text.Text);
                    curPark.parkChargeMode.unitPayLSCard = Convert.ToInt32(pMForm_unitChargePay_Text.Text);
                    curPark.parkChargeMode.discountLSCard = Convert.ToInt32(pMForm_discount_Text.Text);
                    curPark.parkChargeMode.freeTimeLSCard = Convert.ToInt32(pMForm_freeTime_Text.Text);
                }
                else if (pMForm_selectYGCard_Radio.Checked)
                {
                    curPark.parkChargeMode.unitYGCard = Convert.ToInt32(pMForm_unitCharge_Text.Text);
                    curPark.parkChargeMode.unitPayYGCard = Convert.ToInt32(pMForm_unitChargePay_Text.Text);
                    curPark.parkChargeMode.discountYGCard = Convert.ToInt32(pMForm_discount_Text.Text);
                    curPark.parkChargeMode.freeTimeYGCard = Convert.ToInt32(pMForm_freeTime_Text.Text);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("输入错误", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                // throw;
            }
        }

        private void pMForm_unitChargePayTime_Text_KeyUp(object sender, KeyEventArgs e)
        {

            if (String.IsNullOrEmpty(pMForm_unitChargePayTime_Text.Text)) return;

            if (pMForm_selectYCard_Radio.Checked)
            {
                curPark.parkChargeMode.unitPayYCard = Convert.ToInt32(pMForm_unitChargePayTime_Text.Text);

            }
            else if (pMForm_selectRCard_Radio.Checked)
            {
                curPark.parkChargeMode.unitPayRCard = Convert.ToInt32(pMForm_unitChargePayTime_Text.Text);
            }
        }



        private void pMForm_discount_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


    }
}
