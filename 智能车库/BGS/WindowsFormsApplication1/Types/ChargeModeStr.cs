/** 
* 文 件 名 : ChargeModeStr
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：定义系统卡片配置的结构体
* 版 本 号：0.1
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

    public  struct ChargeModeStr
    {
        public int modeID;
      public   string modeName;                          //配置模式名称
      public bool enableYCard;                          //是否允许月卡
      public bool enableCZCard;                          //是否允许充值卡
      public bool enableMFCard;                          //是否允许免费卡
      public bool enableLSCard;                          //是否允许临时卡
      public bool enableYGCard;                          //是否允许员工卡
      public bool enableSQCard;                          //是否允许授权卡
      public bool enableTQCard;                          //是否允许特权卡
      public bool enableRCard;                          //是否允许免费卡

      public int unitPayCZCard;                          //充值卡单位时间的收费
      public int unitCZCard;                             //充值卡单位时间
      public int discountCZCard;                             //充值卡单位时间
      public int freeTimeCZCard;                             //充值卡单位时间

      public int unitPayLSCard;                          //临时卡单位时间的收费
      public int unitLSCard;                             //临时卡单位时间
      public int discountLSCard;                             //充值卡单位时间
      public int freeTimeLSCard;                             //充值卡单位时间

      public int unitPayYGCard;                          //临时卡单位时间的收费
      public int unitYGCard;                             //临时卡单位时间
      public int discountYGCard;                             //充值卡单位时间
      public int freeTimeYGCard;                             //充值卡单位时间

      public int unitPayYCard;                          //临时卡单位时间的收费
      public int unitPayRCard;                          //临时卡单位时间的收费
      public bool modeSQCard;


    }

      
}
