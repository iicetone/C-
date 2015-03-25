using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

   public struct ChannelUnit
    {
        public int channelID;     //通道ID
        public int parkID;     //通道ID

        public string channelName;        //通道名称
        public Command.ChannelMode channelMode;       //通道模式,工作站/直连

        public int entranceCount;      //通道内出入口数量
        public int cameraCount;
        public EntranceUnit selectedEntrance;        //通道内出入口LIST]

        public List<EntranceUnit> entranceList;        //通道内出入口LIST]
        public List<CameraStc> cameraList;

        public string stationAddr;     //通道工作站地址 TCP
        public Command.BGSstatus channelStatus;


    }
}

