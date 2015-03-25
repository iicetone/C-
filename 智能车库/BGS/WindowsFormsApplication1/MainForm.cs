/** 
* 文 件 名 : MainForm
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.18
* 修 改 人： 
* 日   期： 
* 描   述：主界面，主要功能如下
*          ①负责出入口摄像头监控画面，道闸控制器状态的读取
 *         ②道闸起降的手动控制及出入口的常开常闭状态
 *         ③读取出入口卡片信息
 *         ④显示出库车辆的停车时间及费用
 *         ⑤车库状态的显示
 *         ⑥切换收费模式及管理模式
 *         ⑦显示登录人员的姓名及登录时间
 *         ⑧功能导航-历史记录，车库管理，系统设置，充值管理
* 版 本 号：0.1
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.BGSystem;
using Cheku.DataManager;
using System.Data.OleDb;
using Cheku.Types;
using Cheku.MessageManager;


namespace Cheku

{
    public partial class MainForm : Form
    {
      private  CardOperater cardOpt;
      private BGSOperater bgsOpt;
      private CardPanel cardPanel;
      private RechargePanel recPanel; 
      private ParkManagerPanel parkPanel;
      private CameraPanel cameraPanel;
        private EntranceSettingStr curEntranceSet;
        private EntranceStatusStr curEntranceSta; 

        private EntranceUnit curEntrance;
        private ChannelUnit curChannel;

        private int curChannelID;
        private int curEntranceID;

        private List<MainFormChannelTabPage> channelPages;
        private List<int> channelIDs;

        private Control curPanel;
        public MainForm()
        {
             InitializeComponent();


             cardOpt =  CardOperater.GetInstance();
             bgsOpt = BGSOperater.GetInstance();

             curEntranceSet = bgsOpt.GetCurrentEntranceSetting(curEntranceID);

             bgsOpt.cardPassMessageArrived += displayInCardMessage;
            cardOpt.CautionMessageArrived += displayChargeMessage;
            bgsOpt.addChannelMessageArrived += addChannelPageMessage;
            bgsOpt.updateChannelMessageArrived += updateChannelPageMessage;
            bgsOpt.updateDeviceMessageArrived += updateDeviceMessage;
            bgsOpt.addDeviceMessageArrived += updateDeviceMessage;
            bgsOpt.updateParkMessageArrived += updateParkPageMessage;
            //*******************DEBUGGING*****************
      //      co.SetCurrentCard(10000, MessageTypeEnum.入库);

     //     co.SetCurrentCard(11111,MessageTypeEnum.出库);

            //*******************DEBUGGING*****************

            curChannelID = 1;
            curEntranceID = 1;


            cardPanel = new CardPanel();
            BottomPanel1.Controls.Add(cardPanel);
            cardPanel.Hide();
            parkPanel = new ParkManagerPanel();
            BottomPanel1.Controls.Add(parkPanel);
            parkPanel.Hide();
            cameraPanel = new CameraPanel();
            BottomPanel1.Controls.Add(cameraPanel);
            cameraPanel.Hide();
            recPanel = new RechargePanel();
            BottomPanel1.Controls.Add(recPanel);
            recPanel.Hide();

            loadChannelPage();

            topMenu_TotalSpace_Label.Text = bgsOpt.TotalSpace.ToString();
            topMenu_OcuSpace_Label.Text = bgsOpt.OccupiedSpace.ToString();
            topMenu_RemSpace_Label.Text = bgsOpt.RemainSpace.ToString();

            curPanel = TabPanel;

        }

        private void loadChannelPage()
        {
            channelPages = new List<MainFormChannelTabPage>();

            foreach (ChannelUnit cu in bgsOpt.ChannelList)
            {
                addChannelPage(cu);
            }
        }

        private void addChannelPage(ChannelUnit cu)
        {
           MainFormChannelTabPage mfcPanel = new MainFormChannelTabPage();
      //     mfcPanel.channelID = cu.channelID;
           mfcPanel.Tag = cu.channelID;
           mfcPanel.Text = cu.channelName;
           mfcPanel.curParkID = cu.parkID;
           if (cu.entranceCount >= 2)
           {
               EntranceUnit entr = bgsOpt.GetCurrentEntrance(cu.channelID, EntranceTypeEnum.入库控制器);
               if (entr.entranceID != 0)
                   mfcPanel.EntrancesInChannel[0] = entr;
               entr = bgsOpt.GetCurrentEntrance(cu.channelID, EntranceTypeEnum.出库控制器);
               if (entr.entranceID != 0)
                   mfcPanel.EntrancesInChannel[1] = entr;
           }

           channelPages.Add(mfcPanel);
           this.TabPanel.Controls.Add(mfcPanel);
           
        }
        private void addChannelPageMessage(object sender, MessageEventArgs e)
        {
            if (e.Mes.park.selectedChannel.channelID != 0)
                addChannelPage(e.Mes.park.selectedChannel);
               
        }
        private void addDeviceMessage(object sender, MessageEventArgs e)
        {
            //if (e.EntranceID != 0)
            //    addChannelPage(bgsOpt.GetCurrentChannel(e.EntranceID));

        }
        private void updateDeviceMessage(object sender, MessageEventArgs e)
        {
            EntranceUnit entr = e.Mes.park.selectedChannel.selectedEntrance;
            if (entr.entranceID != 0)

            foreach (MainFormChannelTabPage tab in TabPanel.TabPages)
            {
                if (entr.channelID != (int)tab.Tag) continue;

                if (entr.entranceID == tab.EntrancesInChannel[0].entranceID)
                {
                    tab.EntrancesInChannel[0] = entr;
                    tab.groupBox1.Text = entr.entranceName;
                    tab.topMenu_Guanli1_Box.SelectedValue = entr.entranceSettingID;

                    tab.ruKu_StatusValue_Label.Text = Convert.ToString(entr.entranceStatus.statusBGS.ToString()) + " ...";
                    if (entr.entranceStatus.statusBGS == Command.BGSstatus.开启中)
                    {
                        tab.ruKu_Tongdao_IButton.Image = Properties.Resources.no;
                    }
                    else if (entr.entranceStatus.statusBGS == Command.BGSstatus.关闭中)
                    {
                        tab.ruKu_Tongdao_IButton.Image = Properties.Resources.ok;
                    }
                    break;

                }
                else if (entr.entranceID == tab.EntrancesInChannel[1].entranceID)
                {
                    tab.EntrancesInChannel[1] = entr;
                    tab.groupBox2.Text = entr.entranceName;
                    tab.topMenu_Guanli2_Box.SelectedValue = entr.entranceSettingID;

                    tab.chuKu_StatusValue_Label.Text = Convert.ToString(entr.entranceStatus.statusBGS.ToString()) + " ...";
                    if (entr.entranceStatus.statusBGS == Command.BGSstatus.开启中)
                    {
                        tab.chuKu_Tongdao_IButton.Image = Properties.Resources.no;
                    }
                    else if (entr.entranceStatus.statusBGS == Command.BGSstatus.关闭中)
                    {
                        tab.chuKu_Tongdao_IButton.Image = Properties.Resources.ok;
                    }
                    break;
                }
            }
        }
        private void updateChannelPageMessage(object sender, MessageEventArgs e)
        {
            ChannelUnit channel = e.Mes.park.selectedChannel;
            if (channel.channelID == 0) return;
            foreach (MainFormChannelTabPage tab in TabPanel.TabPages)
            {
                if (channel.channelID != (int)tab.Tag) continue;

                tab.Text = channel.channelName;
                //if (channel.entranceCount >= 2)
                //    {
                //           EntranceUnit entr = bgsOpt.GetCurrentEntrance(channel.channelID,EntranceTypeEnum.入库控制器);
                //           if (entr.entranceID != 0 )
                //               tab.entrances[0] = entr.entranceID;
                //           entr = bgsOpt.GetCurrentEntrance(channel.channelID, EntranceTypeEnum.出库控制器);
                //           if (entr.entranceID != 0)
                //               tab.entrances[1] = entr.entranceID;
                //    }

                    break;
            }
        }
        private void updateParkPageMessage(object sender, MessageEventArgs e)
        {
            ParkUnit park = e.Mes.park;
            if (park.parkID == 0) return;

            topMenu_TotalSpace_Label.Text = park.parkTotalSpace.ToString();
            topMenu_OcuSpace_Label.Text = park.parkOccupiedSpace.ToString();
            topMenu_RemSpace_Label.Text = park.parkRemainSpace.ToString();

            foreach (MainFormChannelTabPage tab in TabPanel.TabPages)
            {

                tab.topMenu_Shoufei_Box.SelectedValue = park.parkChargeModeID;
            }
        }
        private void displayInCardMessage(object sender, MessageEventArgs e)
        {
            CardUnit card = e.Mes.card;

            if (card.CardID != String.Empty)
            {
                foreach (MainFormChannelTabPage tpage in channelPages)
                {
                    if (e.Mes.park.selectedChannel.channelID != (int)tpage.Tag) continue;

                    if (tpage.EntrancesInChannel[0].entranceID == e.Mes.park.selectedChannel.selectedEntrance.entranceID)
                     {
                             tpage.ruKu_KahaoValue_Label.Text = Convert.ToString(card.CardID);
                             tpage.ruKu_EduValue_Label.Text = Convert.ToString(card.CardValue);
                             tpage.ruKu_LeixingValue_Label.Text = Convert.ToString(card.CardType);
                             tpage.ruKu_YouxiaoValue_Label.Text = Convert.ToString(card.ValidFlag);
                             tpage.ruKu_XingmingValue_Label.Text = Convert.ToString(card.CardName);
                             tpage.ruKu_ChepaiValue_Label.Text = Convert.ToString(card.CarLic);
                             tpage.ruKu_DianhuaValue_Label.Text = DateTime.Now.ToLongTimeString();
                             break;

                      }
                    else if (tpage.EntrancesInChannel[1].entranceID == e.Mes.park.selectedChannel.selectedEntrance.entranceID)
                     {
                        tpage.chuKu_KahaoValue_Label.Text = Convert.ToString(card.CardID);
                        tpage.chuKu_EduValue_Label.Text = Convert.ToString(card.CardValue);
                        tpage.chuKu_LeixingValue_Label.Text = Convert.ToString(card.CardType);
                        tpage.chuKu_YouxiaoValue_Label.Text = Convert.ToString(card.ValidFlag);
                        tpage.chuKu_XingmingValue_Label.Text = Convert.ToString(card.CardName);
                        tpage.chuKu_ChepaiValue_Label.Text = Convert.ToString(card.CarLic);
                        tpage.chuKu_DianhuaValue_Label.Text = DateTime.Now.ToLongTimeString();
                        break;

                     }

                 }

                topMenu_TotalSpace_Label.Text = bgsOpt.TotalSpace.ToString();
                topMenu_OcuSpace_Label.Text = bgsOpt.OccupiedSpace.ToString();
                topMenu_RemSpace_Label.Text = bgsOpt.RemainSpace.ToString();
            }
           

        }



        private void displayChargeMessage(object sender, MessageEventArgs e)
        {
            string valueType;
            CardUnit card = e.Mes.card;
            if (String.IsNullOrEmpty(card.CardID)) return;
            
                foreach (MainFormChannelTabPage tpage in channelPages)
                {
                    if (e.Mes.park.selectedChannel.channelID != (int)tpage.Tag) continue;
                    if (tpage.EntrancesInChannel[0].entranceID == e.Mes.park.selectedChannel.selectedEntrance.entranceID
                        || tpage.EntrancesInChannel[1].entranceID == e.Mes.park.selectedChannel.selectedEntrance.entranceID)
                    {
                        valueType = card.CardType == CardUnit.CType.月卡 ? " 天" : " 元";
                        if (card.LastIn != string.Empty && card.LastOut != string.Empty)
                        {
                        DateTime inT = Convert.ToDateTime(card.LastIn);
                        DateTime outT = Convert.ToDateTime(card.LastOut);
                        TimeSpan interval = outT - inT;
                        int seconds = (int)interval.TotalSeconds;
                        int hours = seconds / 60 / 60;
                        int minutes = seconds / 60 % 60;                    
                        tpage.charge_CostValue_Label.Text = Convert.ToString(card.Cost) + valueType;
                        tpage.charge_CardValue_Label.Text = card.CardValue + valueType;
                        tpage.charge_LastInValue_Label.Text = Convert.ToString(card.LastIn);
                        tpage.charge_LastOutValue_Label.Text = Convert.ToString(card.LastOut);
                        tpage.charge_TotalTimeValue_Label.Text = Convert.ToString(hours) + " 小时 " + Convert.ToString(minutes) + " 分钟";
                        tpage.charge_TypeValue_Label.Text = Convert.ToString(card.CardType);

                        }


                    }


                }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbChargeMode”中。您可以根据需要移动或删除它。
            this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbConfigMode”中。您可以根据需要移动或删除它。
            this.dbConfigModeTableAdapter.Fill(this.dbBGSDataSet.dbConfigMode);

        }


        private void topMenu_Recharge_IButton_Click(object sender, EventArgs e)
        {
            topMenu_ChongZhi_IButton.Image = Properties.Resources.充值管理2;

            curPanel.Hide();
            BottomPanel1.Controls.Add(recPanel);
            BottomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            recPanel.Show();
            curPanel = recPanel;
        }

        private void topMenu_Manage_IButton_Click(object sender, EventArgs e)
        {
            topMenu_Cheku_IButton.Image = Properties.Resources.车库管理2;

            curPanel.Hide();
            BottomPanel1.Controls.Add(parkPanel);
            BottomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            parkPanel.Show();
            curPanel = parkPanel;
        }

        private void topMenu_History_IButton_Click(object sender, EventArgs e)
        {
            topMenu_Lishi_IButton.Image = Properties.Resources.历史纪录2;
            HistoryForm hForm = new HistoryForm();
            hForm.Owner = this;
            hForm.ShowDialog();
        }

        private void topMenu_System_IButton_Click(object sender, EventArgs e)
        {
            topMenu_Xitong_IButton.Image = Properties.Resources.系统设置2;
            SystemManageForm mForm = new SystemManageForm();
            mForm.Owner = this;
            mForm.ShowDialog();
        }

        private void topMenu_CardManager_IButton_Click(object sender, EventArgs e)
        {

            topMenu_CardManager_IButton.Image = Properties.Resources.用户管理2;
            curPanel.Hide();
            BottomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            cardPanel.Show();
            curPanel = cardPanel;
        }

        private void ruKu_Tongdao_Button_Click(object sender, EventArgs e)
        {



            //ruKu_Tongdao_IButton.Image = Properties.Resources.no1;

         //   bgsOpt.BGSControl(Command.ControlComm.通道, !curEntranceSta.statusBGS);


           
        }
        private void ruKu_Daozha_Button_Click(object sender, EventArgs e)
        {
         //   this.TabPanel.TabPages[]ruKu_Daozha_IButton.Image = Properties.Resources.close1;
        //    bgsOpt.BGSConfig(Command.ControlComm.道闸, curEntranceSet.);

        }

        private void rukuOFFButton_Click(object sender, EventArgs e)
        {
      //      bgsOpt.BGSConfig(Command.ControlComm.允许发卡器,);


        }



        private void topMenu_ChongZhi_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_ChongZhi_IButton.Image = Properties.Resources.充值管理1;

        }

        private void topMenu_ChongZhi_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_ChongZhi_IButton.Image = Properties.Resources.充值管理;

        }

        private void topMenu_CardManager_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_CardManager_IButton.Image = Properties.Resources.用户管理1;

        }

        private void topMenu_CardManager_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_CardManager_IButton.Image = Properties.Resources.用户管理;

        }

        private void topMenu_Cheku_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_Cheku_IButton.Image = Properties.Resources.车库管理;

        }

        private void topMenu_Cheku_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_Cheku_IButton.Image = Properties.Resources.车库管理1;

        }

        private void topMenu_Lishi_IButton_MouseLeave(object sender, EventArgs e)
        {
                        topMenu_Lishi_IButton.Image = Properties.Resources.历史记录;
        }

        private void topMenu_Lishi_IButton_MouseEnter(object sender, EventArgs e)
        {
                        topMenu_Lishi_IButton.Image = Properties.Resources.历史记录1;
        }

        private void topMenu_Xitong_IButton_MouseLeave(object sender, EventArgs e)
        {
                        topMenu_Xitong_IButton.Image = Properties.Resources.系统设置;

        }

        private void topMenu_Xitong_IButton_MouseEnter(object sender, EventArgs e)
        {
                        topMenu_Xitong_IButton.Image = Properties.Resources.系统设置1;

        }



        private void topMenu_Print_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_Print_IButton.Image = Properties.Resources.打印1;

        }


        private void topMenu_Print_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_Print_IButton.Image = Properties.Resources.打印;

        }


        private void topMenu_Camera_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_Camera_IButton.Image = Properties.Resources.监控管理1;

        }

        private void topMenu_Camera_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_Camera_IButton.Image = Properties.Resources.监控管理;

        }

        private void topMenu_ChannelManager_IButton_MouseEnter(object sender, EventArgs e)
        {
            topMenu_ChannelManager_IButton.Image = Properties.Resources.通道管理1;

        }

        private void topMenu_ChannelManager_IButton_MouseLeave(object sender, EventArgs e)
        {
            topMenu_ChannelManager_IButton.Image = Properties.Resources.通道管理;

        }

        private void topMenu_ChannelManager_IButton_Click(object sender, EventArgs e)
        {
            curPanel.Hide();
            BottomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TabPanel.Show();
            curPanel = TabPanel;
        }

        private void topMenu_Guanli_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void topMenu_Shoufei_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TabPanel_Selected(object sender, TabControlEventArgs e)
        {
            //if (e.TabPage != null)
            //{
            //    curChannelID = (int)e.TabPage.Tag;
            //    curEntranceID = bgsOpt.GetCurrentChannel(curChannelID).entranceList[0].entranceID;
            //    this.topMenu_Shoufei_Box.SelectedIndexChanged -= topMenu_Shoufei_Box_SelectedIndexChanged;
            //    this.topMenu_Guanli_Box.SelectedIndexChanged -= topMenu_Guanli_Box_SelectedIndexChanged;

            //    topMenu_Guanli_Box.SelectedValue = bgsOpt.GetCurrentEntrance(curChannelID, curEntranceID).entranceSettingID; 
            //    topMenu_Shoufei_Box.SelectedValue =bgsOpt.GetCurrentChannel(curChannelID).channelChargeModeID;
            
            //    this.topMenu_Guanli_Box.SelectedIndexChanged += topMenu_Guanli_Box_SelectedIndexChanged;
            //    this.topMenu_Shoufei_Box.SelectedIndexChanged += topMenu_Shoufei_Box_SelectedIndexChanged;

            //}
        }

        private void topMenu_Camera_IButton_Click(object sender, EventArgs e)
        {
            curPanel.Hide();
            BottomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            cameraPanel.Show();
            curPanel = cameraPanel;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bgsOpt.LinkClosing();
        }

        private void topMenu_RemSpace_Label_Click(object sender, EventArgs e)
        {

        }



    }
}

