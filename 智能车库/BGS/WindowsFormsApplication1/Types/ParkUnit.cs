using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

   public struct ParkUnit
    {
        public int parkID;     //车场ID
        public string parkName;        //车场名称

        public ChargeModeStr parkChargeMode;        //车场付费策略
        public int parkChargeModeID;        //车场付费策略ID

        public ChannelUnit selectedChannel;
        public int channelCount;      //车场内通道数量

        public int parkTotalSpace;
        public int parkOccupiedSpace;
        public int parkRemainSpace;

        public int parkLevel; 
        public ParkTypeEnum parkType;

        public List<ChannelUnit> channelList;
        public List<BGSTimerStr> TimerList;

    }
        [Serializable]

    public enum ParkTypeEnum : int
    {
        普通 = 0,
        场中场 = 1, 
    }
}

