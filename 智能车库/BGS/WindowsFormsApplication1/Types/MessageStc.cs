using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

    public struct MessageStc
    {

           public ChannelUnit cu;
           public EntranceUnit eu;
           public ParkUnit park;
           public CardUnit card;
           public string ip;
           public MessageTypeEnum type;
           public string info;
    }
    public enum MessageHeadEnum
    {
        HEAD_ACK = 0XF1,
        HEAD_NEW = 0XF2,
        HEAD_CONF = 0XF3
    }
    [Serializable]
    public enum MessageTypeEnum
    {
        CHANNEL_APPLY,
        CHANNEL_GATECOMM,
        CHANNEL_GATESETTING,
        CHANNEL_UPDATE,
        CHANNEL_ADD,
        CHANNEL_TEST,

        DEVICE,
        NEWCARD,
        VACANCY,
        GATE_COMM,
        INCARD,
        OUTCARD,
        RECHARGE,
        STATUS,

        DEVICE_ADD, 
        DEVICE_UPDATE,
        DEVICE_SETTING,
        DEVICE_TEST,
        DEVICE_LEDL,

        PARK_ADD,
        PARK_UPDATE, 

    }

}
