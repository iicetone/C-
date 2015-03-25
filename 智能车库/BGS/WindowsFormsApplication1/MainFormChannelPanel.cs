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
    public partial class MainFormChannelTabPage : TabPage


    {
        BGSOperater bgsOpt = BGSOperater.GetInstance();
        CameraManager camMan;

       public int curParkID { get; set; }

      //  public int channelID { get; set; }
        public int entranceCount { get; set; }

       // public int[] entrances { get; set; }
        public EntranceUnit[] EntrancesInChannel { get; set; }

        public MainFormChannelTabPage()
        {
            InitializeComponent();
         //   entrances = new int[2];         //只支持双控制器
            EntrancesInChannel = new EntranceUnit[2]; //只支持双控制器
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbChargeMode”中。您可以根据需要移动或删除它。
          this.dbChargeModeTableAdapter.Fill(this.dbBGSDataSet.dbChargeMode);
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbConfigMode”中。您可以根据需要移动或删除它。
            this.dbConfigModeTableAdapter.Fill(this.dbBGSDataSet.dbConfigMode);
            camMan = bgsOpt.CamManager;
        }

        private void ruKu_Daozha_IButton_Click(object sender, EventArgs e)
        {
            if (!EntrancesInChannel[0].entranceSetting.enableBGS) return;
            if (EntrancesInChannel[0].entranceSettingID != 2)
            {
                bgsOpt.UpdateEntranceSetting(EntrancesInChannel[0].entranceID, 2);
                ruKu_Daozha_IButton.Image = Properties.Resources.close;
            }
            else
            {
                bgsOpt.UpdateEntranceSetting(EntrancesInChannel[0].entranceID, 1);
                ruKu_Daozha_IButton.Image = Properties.Resources.open;
            }
            MessageStc mes = new MessageStc();
            mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID);
            mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID).tcpAddr;
            mes.type = MessageTypeEnum.GATE_COMM;
            bgsOpt.BGSControl(mes);
        }

        private void chuKu_Daozha_IButton_Click(object sender, EventArgs e)
        {

            if (!EntrancesInChannel[1].entranceSetting.enableBGS) return;
            if (EntrancesInChannel[1].entranceSettingID != 2)
            {
                bgsOpt.UpdateEntranceSetting(EntrancesInChannel[1].entranceID, 2);
                chuKu_Daozha_IButton.Image = Properties.Resources.close;
            }
            else
            {
                bgsOpt.UpdateEntranceSetting(EntrancesInChannel[1].entranceID, 1);
                chuKu_Daozha_IButton.Image = Properties.Resources.open;
            }
            MessageStc mes = new MessageStc();
            mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID);
            mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID).tcpAddr;
            mes.type = MessageTypeEnum.GATE_COMM;
            bgsOpt.BGSControl(mes);
        }


        private void topMenu_Shoufei_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgsOpt.UpdateParkChargeMode(curParkID, Convert.ToInt32(topMenu_Shoufei_Box.SelectedValue.ToString()));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgsOpt.UpdateEntranceSetting( EntrancesInChannel[0].entranceID, Convert.ToInt32(topMenu_Guanli1_Box.SelectedValue.ToString()));
        }

        private void topMenu_Guanli_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgsOpt.UpdateEntranceSetting( EntrancesInChannel[1].entranceID, Convert.ToInt32(topMenu_Guanli2_Box.SelectedValue.ToString()));
        }

        private void ruKu_Faka_IButton_Click(object sender, EventArgs e)
        {
            CameraStc cam = new CameraStc();
            cam.cameraType = CameraStc.CameraType.入口摄像头;
            int id =(int)this.Tag;

            camMan.GetCamera(ref cam);
            camMan.GetCameraPreView(cam, ref pictureBox6);
        }

        private void chuKu_Faka_IButton_Click(object sender, EventArgs e)
        {
            CameraStc cam = new CameraStc();
            cam.cameraType = CameraStc.CameraType.出口摄像头;

            int id = (int)this.Tag;

            camMan.GetCamera(ref cam);
            camMan.GetCameraPreView(cam, ref pictureBox6);
        }

        private void Channel_OFF_Button_Click(object sender, EventArgs e)
        {
            //MessageStc mes = new MessageStc();
            //mes.type = MessageTypeEnum.GATE_COMM;
            //if (isNormallyOpenE0)
            //{
            //    bgsOpt.UpdateEntranceSetting((int)this.Tag, EntrancesInChannel[0].entranceID, 1);
            //    chuKu_Daozha_IButton.Image = Properties.Resources.open;
            //    if (isOpenE0)
            //    {
            //        mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID);
            //        mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID).tcpAddr;
            //        bgsOpt.BGSControl(mes);
            //        isOpenE0 = false;
            //    }
            //    isNormallyOpenE0 = false;
            //}
            //if (isNormallyOpenE1)
            //{
            //    bgsOpt.UpdateEntranceSetting((int)this.Tag, EntrancesInChannel[1].entranceID, 1);
            //    chuKu_Daozha_IButton.Image = Properties.Resources.open;
            //    if (isOpenE1)
            //    {
            //        mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID);
            //        mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID).tcpAddr;
            //        bgsOpt.BGSControl(mes);
            //        isOpenE1 = false;
            //    }
            //    isNormallyOpenE1 = false;
            //}

        }
        private void Channel_ON_Button_Click(object sender, EventArgs e)
        {
            //bgsOpt.UpdateEntranceSetting((int)this.Tag, EntrancesInChannel[0].entranceID, 1);

            //bgsOpt.UpdateEntranceSetting((int)this.Tag, EntrancesInChannel[1].entranceID, 1);
            //MessageStc mes = new MessageStc();

            //bgsOpt.BGSControl(mes);
            //if (!isOpenE0)
            //{
            //    mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID);
            //    mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[0].entranceID).tcpAddr;
            //}
            //if (!isOpenE1)
            //{
            //    mes.park.selectedChannel.selectedEntrance = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID);
            //    mes.ip = bgsOpt.GetCurrentEntrance(EntrancesInChannel[1].entranceID).tcpAddr;
            //}
            //mes.type = MessageTypeEnum.GATE_COMM;
            //bgsOpt.BGSControl(mes);

            //isNormallyOpenE1 = true;
            //isNormallyOpenE0 = true;
        }
        private void ruKu_Tongdao_IButton_Click(object sender, EventArgs e)
        {
            if (!EntrancesInChannel[0].entranceSetting.enableBGS) return;

            MessageStc mes = new MessageStc();
            mes.park.selectedChannel.selectedEntrance = EntrancesInChannel[0];
            mes.ip = EntrancesInChannel[0].tcpAddr;
            mes.type = MessageTypeEnum.GATE_COMM;
            bgsOpt.BGSControl(mes);
        }


        private void chuKu_Tongdao_IButton_Click(object sender, EventArgs e)
        {
            if (!EntrancesInChannel[1].entranceSetting.enableBGS) return;
            MessageStc mes = new MessageStc();
            mes.park.selectedChannel.selectedEntrance = EntrancesInChannel[1];
            mes.ip = EntrancesInChannel[1].tcpAddr;
            mes.type = MessageTypeEnum.GATE_COMM;
            bgsOpt.BGSControl(mes);
        }



    }
}
