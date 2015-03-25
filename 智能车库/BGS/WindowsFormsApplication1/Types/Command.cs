/** 
* 文 件 名 : Command
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：定义控制指令的结构体
* 版 本 号：0.1
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku;


namespace Cheku.Types
{
    [Serializable]

    public struct Command
    {
        public   enum BGSType
        {
            入口=1,
            出口=2,
            出入口=3
        }
        public  enum ControlComm
        {
            通道,
            开闸,
            摄像头,
            读卡器,
            发卡器,
            允许通道,
            允许开道闸,
            允许关道闸,
            允许读卡器,
            允许发卡器,
            允许手动开闸
        }

        public  enum CardInfoComm
        {
            卡号,
            类型,
            有效标志,
            计时标志,
            办卡时间,
            姓名,
            电话,
            总时间,
            最后一进库时间,
            最后一次出库时间,
            剩余值

        }
        public enum CardStatusComm
        {
            INCARD,
            OUTCARD,
            RECHARGE,
            STATUS,
            NEWCARD
        }
        public enum enableOpt
        {
            开启=1,
            关闭=2
        }
        public enum BGSstatus
        {
            未测试,
            已开启,
            开启中,
            已关闭,
            关闭中,
            停止中,
            测试通过,
            测试中

        }
        public enum ChannelMode
        {
            工作站式,
            直连
        }
        public enum EntranceMode
        {
            TCP,
            RS485
        }
        public enum DeviceType
        {

        }
        public enum SoftMode
        {
            主机,
            从机,
            单主机
        }
        public enum TimerType
        {
            PARK,
            ENTRANCE 
        } 
    }

}
