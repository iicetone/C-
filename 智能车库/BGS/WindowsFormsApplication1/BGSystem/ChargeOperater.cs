
/** 
* 文 件 名 : ChargeOperater
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：002 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：  在出库时计算费用并赋值新的余额
* 版 本 号：0.1
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
namespace Cheku.BGSystem
{
    class ChargeOperater
    {
       
        ChargeModeStr curCM;
      
        
        public ChargeOperater(ChargeModeStr cur)
        {

            curCM = cur;

        }

        /*************************************************

         Function:    getCost(CardStc card)
         
         Description:   计算费用，由CardOperater在出库时调用
         Input:          cur 卡片实体
           
         Return:         CardStc，计算费用后的卡片实体

       *************************************************/
        public CardUnit getCost(CardUnit card)
        {
            //此次花费
                 int cost = 0; 
            //余额
                 int value = 0;
                 int totalTime = 0;
             TimeSpan interval,intervalM;
             DateTime inT, outT,lastDate;
            //计算此次入库总时间（分钟）
                 if (card.LastIn == string.Empty )
                 {
                     return card;
                 }
                 inT = Convert.ToDateTime(card.LastIn);
                 outT = Convert.ToDateTime(card.LastOut);
                 interval = outT - inT; 
                  int minutes = (int)(interval != null ? interval.TotalMinutes : 0);

            //根据卡片类型计算费用
                switch (card.CardType)
                {
                    //计算方法：直接返回
                    case CardUnit.CType.免费卡:
                        return card;
                    case CardUnit.CType.特权卡:
                        return card;

                    //计算方法：由出库时的日期-最后一次充值时的日期，得到出库时以距离最后充值时间过去的天数
                    //再与卡内余额（天数)对比
                    case CardUnit.CType.月卡:
                        //计算充值后可使用时间（天数）
                          totalTime= Convert.ToInt32(card.CardValue);
                        //得到最后一次充值时间
                         lastDate = Convert.ToDateTime(card.LastRecharge);
                        //获取距离最后充值时间过去的时间间隔
                         intervalM = outT - lastDate;
                        //得到最新余额
                        value=totalTime-intervalM.Days ;
                       if (value<=0)
                        {
                            card.ValidFlag = CardUnit.VFlag.耗尽;
                            card.CardValue ="0";
                            return card;
                        }
                        card.CardValue = Convert.ToString(value);
                        return card;
                    case CardUnit.CType.日卡:
                        //计算充值后可使用时间（天数）
                         totalTime = Convert.ToInt32(card.CardValue);
                        //得到最后一次充值时间
                         lastDate = Convert.ToDateTime(card.LastRecharge);
                        //获取距离最后充值时间过去的时间间隔
                         intervalM = outT - lastDate;
                        //得到最新余额
                        value = totalTime - intervalM.Days;
                        if (value <= 0)
                        {
                            card.ValidFlag = CardUnit.VFlag.耗尽;
                            card.CardValue = "0";
                            return card;
                        }
                        card.CardValue = Convert.ToString(value);
                        return card;
                    //计算方法：由入库总时间除以系统的收费单位，再乘以单位时间收费
                    case CardUnit.CType.临时卡:
                        minutes = minutes - curCM.freeTimeLSCard;

                        cost = (minutes / curCM.unitLSCard) * curCM.unitPayLSCard;
                        cost = cost * curCM.discountLSCard / 10;
                        value = 0;
                        card.CardValue = Convert.ToString(value);
                        card.Cost = cost;
                        card.ValidFlag = CardUnit.VFlag.临时;

                        //if (value <= 0)
                        //{
                        //    card.ValidFlag = CardUnit.VFlag.耗尽;
                        //    return card;
                        //}
                        return card;
                    //计算方法：由入库总时间除以系统的收费单位，再乘以单位时间收费

                    case CardUnit.CType.充值卡:
                        minutes = minutes - curCM.freeTimeCZCard;
                        cost = (minutes / curCM.unitCZCard) * curCM.unitPayCZCard;
                        cost = cost * curCM.discountCZCard / 10;
                        value = Convert.ToInt32(card.CardValue) - cost;
                        card.Cost = cost;
                        if (value <= 0)
                        {
                            card.ValidFlag = CardUnit.VFlag.耗尽;
                            value = 0;
                        }
                        card.CardValue = Convert.ToString(value);

                        return card;
                    case CardUnit.CType.员工卡:
                        minutes = minutes - curCM.freeTimeYGCard;
                        cost = (minutes / curCM.unitYGCard) * curCM.unitPayYGCard;
                        cost = cost * curCM.discountYGCard / 10;
                        value = Convert.ToInt32(card.CardValue) - cost;
                        card.Cost = cost;
                        if (value <= 0)
                        {
                            card.ValidFlag = CardUnit.VFlag.耗尽;
                            value = 0;
                        }
                        card.CardValue = Convert.ToString(value);

                        return card;
                    case CardUnit.CType.授权卡:
                        if (Convert.ToInt32(card.CardValue)  <= 0)
                        {
                            card.CardValue = "0";
                            card.ValidFlag = CardUnit.VFlag.耗尽;

                            return card;
                        }
                        value = Convert.ToInt32(card.CardValue) - 1;

                        card.CardValue = Convert.ToString(value);
                        

                        return card;
                }
            

            return card;
        }


    }
}
