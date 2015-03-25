using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

   public struct EntranceUnit
    {
      public int entranceID;     //出入口id
      public string entranceName;        //出入口名称
      public EntranceModeEnum entranceMode;      //出入口模式 TCP/485
      public EntranceTypeEnum entranceType;       //出入口类型  出口/入口

      public int entranceSettingID;      //出入口配置ID
      public EntranceSettingStr entranceSetting;     //出入口配置信息
      public EntranceStatusStr entranceStatus;       //出入口状态信息 
      public CardUnit selectedCard;      //每个出入口的card单元
      public int channelID;
      public int parkID;


      public string rs485Addr;      //485地址
      public string tcpAddr;     //tcp地址

      public List<BGSTimerStr> TimerList;
    }
    [Serializable]

    public enum EntranceTypeEnum
    {
        入库控制器,
        出库控制器,
    }
    [Serializable]

    public enum EntranceModeEnum
    {
        TCP,
        RS485
    }
}
