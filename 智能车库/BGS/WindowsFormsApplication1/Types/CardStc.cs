/** 
* 文 件 名 : Command
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：定义卡片实体的结构体
* 版 本 号：0.1
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cheku.Types
{
    [Serializable]
    public struct CardUnit
    {
        public string CardID;                        //卡号
         public string InitTime;                    //卡片创建时间
         public string CardName;                    //卡主姓名
         public string CardTel;                    //卡主电话
         public string TotalTime;                  //总入库时长
         public string LastIn;                    //最后一次入库时间
         public string LastOut;                    //最后一次出库时间
         public string CardValue;                    //卡内余额
         public CAType CarType;                     //卡主车型
         public string CarLic;                     //卡主车牌号
         public CType CardType;                     //卡片类型
         public VFlag ValidFlag;                    //卡片有效性标志
         public bool TimerFlag;                    // 卡片入库标志，true 入库开始计时 false 出库结束计时
         public string LastRecharge;                //最后充值时间
         public int CardLevel;

        
        public  int Cost;                            //此次入库费用  ，数据库无关

         public  enum CType:int 
         {
             免费卡 = 0,
             临时卡 = 1,
             充值卡 = 2,
             月卡 = 3,
             日卡 =4,
             特权卡 = 5,
            授权卡 = 6,
            员工卡 = 7

         }
         public enum VFlag
         {
             无效 = 0,
             有效 = 1,
            // 即将过期 = 2,
             耗尽 = 3,
             禁止,
             临时
         }
         public enum CAType
         {
             小型车 = 0,
             中型车 = 1,
             大型车 = 3,
         }
    }
}
