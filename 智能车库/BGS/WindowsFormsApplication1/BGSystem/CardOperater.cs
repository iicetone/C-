/** 
* 文 件 名 : CardOperater
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：002 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述： 负责接受到控制器信息后，对卡片信息的操作和认证
 *          系统对卡片设置，包括充值，注册，调用，删除等
 *          负责管理系统对卡片的配置信息
* 版 本 号：0.1
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
using System.Data.OleDb;
using Cheku.DataManager;
namespace Cheku.BGSystem
{

    class CardOperater
    {
      private static String DEBUG = "debugging：*************in CardOperater.cs: "; //DEBUG注释
      
      private Queue<EntranceUnit> entranceCard;

      private ChargeOperater chargeOper;                                            //充值管理类实例化



      public event EventHandler<MessageEventArgs> historyMessageArrived;            //入库委托任务
      public event EventHandler<MessageEventArgs> RechargeCardMessageArrived;       //充值委托任务
      public event EventHandler<MessageEventArgs> CautionMessageArrived;            //警告信息委托任务

      private static CardOperater instance;                                        //CardOperager实例化



        private CardOperater()
        {

            entranceCard = new Queue<EntranceUnit>();
          //  rechargeCardQ = new Queue<CardUnit>();

            //读取当前的配置信息
            //readCurrentChargeModeSetting();
        }
        /*************************************************

         Function:     GetInstance()
         
         Description:    用于外部获取实例
         
         Input:          
           
         Return:          CardOperater实例

       *************************************************/
        public static  CardOperater GetInstance()
        {
            if (instance == null)
                instance = new CardOperater();
            return instance;
        }


        /*************************************************

         Function:     SetCurrentCard(int cID,MessageTypeEnum comm)
         
         Description:    由外部调取，获取当前事件的卡片ID，并由此补充卡片信息，并根据comm开启不同的事件
         
         Input:          cID 卡片ID，comm 事件标志（充值，出库，入库）
           
         Return:         bool，成功标志

       *************************************************/
        public void SetCurrentCard(ref MessageStc mes)
        {
            //获取卡片实体
            mes.card = fillInfoCard(mes.card.CardID);
            if (String.IsNullOrEmpty(mes.card.CardID))
            {
                Console.WriteLine(DEBUG + "SetCurrentCard  No card match this id :" + mes.card.CardID);   //*******************DEBUGGING*****************
                return;

            }
            switch (mes.type)
            {
                case MessageTypeEnum.RECHARGE:
                    rechargeCardHandler(mes);
                break;
                case MessageTypeEnum.OUTCARD:
                    outCardHandler(ref mes); 
                break;
                case MessageTypeEnum.INCARD:
                    inCardHandler(ref mes);
                break;
             }                


        }
        /*************************************************

         Function:     fillInfoCard(int cid)
         
         Description:    由SetCurrentCard调取，根据ID补充卡片信息成一个CardStc实体
         
         Input:          cID 卡片ID
           
         Return:         CardStc，卡片实例化实体

       *************************************************/
        private CardUnit fillInfoCard(string cid)
        {

            CardUnit cur = new CardUnit();
            cur.CardID = cid;

            //marking:检测数据库信息
            OleDbDataReader reader = DataOperater.SelectCard_DO(cid);

            while (reader.Read())
            {

                cur.CardID = reader["cardID"].ToString();
                cur.CardType = (CardUnit.CType)Enum.Parse(typeof(CardUnit.CType), reader["cardType"].ToString());
                cur.ValidFlag = (CardUnit.VFlag)Enum.Parse(typeof(CardUnit.VFlag), reader["validFlag"].ToString());
                cur.TimerFlag = (Boolean)reader["timerFlag"];
                cur.InitTime = reader["initTime"].ToString();
                cur.CardName = reader["cardName"].ToString();
                cur.CardTel = reader["cardTel"].ToString();
                cur.TotalTime = reader["totalTime"].ToString();
                cur.LastIn = reader["lastIn"].ToString();
                cur.LastOut = reader["lastOut"].ToString();
                cur.CardValue = reader["cardValue"].ToString();
                cur.CarType = (CardUnit.CAType)Enum.Parse(typeof(CardUnit.CAType), reader["carType"].ToString());
                cur.CarLic = reader["carLic"].ToString();
                cur.LastRecharge = reader["lastRecharge"].ToString();
                return cur;

            }
            cur.CardID = null;
            return cur;
        }



        /*************************************************

         Function:     verifyCard(CardStc cur)， verifyCardType(CardStc.CType type)
         
         Description:   验证卡片信息，验证有效性标志位ValidFlag及当前系统是否允许相应卡片类型进入
         
         Input:          cur 卡片实体
           
         Return:         bool，成功标志

       *************************************************/

        private bool verifyCardType(MessageStc mes)
        {
            CardUnit.CType type = mes.card.CardType;
            ChargeModeStr curCM = mes.park.parkChargeMode;

            switch (type)
                {
                case CardUnit.CType.充值卡:
                        //marking : do something

                    return curCM.enableCZCard;
                case CardUnit.CType.临时卡:
                    //marking : do something

                    return curCM.enableLSCard;
                case CardUnit.CType.免费卡:
                    //marking : do something

                    return curCM.enableMFCard;
                case CardUnit.CType.月卡:
                    //marking : do something

                    return curCM.enableYCard;
                case CardUnit.CType.日卡:
                    return curCM.enableRCard;
                case CardUnit.CType.特权卡:
                    return curCM.enableTQCard;
                case CardUnit.CType.授权卡:
                    return curCM.enableSQCard;
                case CardUnit.CType.员工卡:
                    return curCM.enableYGCard;
                default:
                    return false;
                 }

        }

        /*************************************************

         Function:     inCardHandler， outCardHandler()，rechargeCardHandler()
         
         Description:   入库，出库，充值时的处理函数，并注册委托
         
         Input:          
           
         Return:       

       *************************************************/

        private void inCardHandler(ref MessageStc mes) 
        {
           // CardUnit inCard = entr.cardUnit;
            if (!verifyCardType(mes))
            {
                mes.card.ValidFlag = CardUnit.VFlag.禁止;
                return;
            }
            if (mes.park.selectedChannel.selectedEntrance.entranceSetting.enableBGSRpeat)
            {
                if (mes.card.TimerFlag )
                {
                mes.card.ValidFlag = CardUnit.VFlag.禁止;
                return;    
                }
            }
            if (mes.card.ValidFlag == CardUnit.VFlag.有效 || mes.card.ValidFlag == CardUnit.VFlag.临时)
            {

                //入库标志位，最后一次入库时间设置

                mes.card.TimerFlag = true;
                mes.card.LastIn = System.DateTime.Now.ToString("G");

                //更新时间标志位和进入时间
                DataOperater.RecordCard_DO(mes.card);
                //写入历史记录
                DataOperater.RecordHistory_DO(mes);

                //事件处理，入库事件，交由MainForm,BGSOperater
                if (historyMessageArrived != null)          
                {
                    historyMessageArrived(this, new MessageEventArgs(mes));
                }
                else
                {
                    Console.WriteLine(DEBUG + "InCardMessageArrived == null");   //*******************DEBUGGING*****************
                }
            //do something
                return ;

            }
                //事件处理，警告事件，标志位信息处理
            else if (CautionMessageArrived != null)
            {

                if (Convert.ToInt32(mes.card.CardValue) <= 0)
                {
                    mes.card.ValidFlag = CardUnit.VFlag.耗尽;
                    CautionMessageArrived(this, new MessageEventArgs(mes));
                }
                else
                {
                    mes.card.ValidFlag = CardUnit.VFlag.无效;
                    CautionMessageArrived(this, new MessageEventArgs(mes));
                }
            }
            else
            {
                Console.WriteLine(DEBUG + "CautionMessageArrived == null");   //*******************DEBUGGING*****************

            }
          

        }
        private void outCardHandler(ref MessageStc mes) 
        {
          //  CardUnit outCard = entr.cardUnit;
            if (!verifyCardType(mes))
            {
                mes.card.ValidFlag = CardUnit.VFlag.禁止;
                return ;
            }

            if (mes.park.selectedChannel.selectedEntrance.entranceSetting.enableBGSRpeat)
            {
                if (!mes.card.TimerFlag)
                {
                    mes.card.ValidFlag = CardUnit.VFlag.禁止;
                    return;
                }
            }
            if (mes.card.ValidFlag != CardUnit.VFlag.无效 )
            {
                //实例化充值类
                chargeOper = new ChargeOperater(mes.park.parkChargeMode);

                //出库标志位，最后一次出库时间设置
                mes.card.TimerFlag = false;
                mes.card.LastOut = System.DateTime.Now.ToString("G");

                //费用计算
                mes.card = chargeOper.getCost(mes.card);
                //事件处理，警告事件，根据卡片计费后的情况进行通知
                CautionMessageArrived(this, new MessageEventArgs(mes));

                //更新时间标志位和出库时间
                DataOperater.RecordCard_DO(mes.card);
                //写入历史记录
                DataOperater.RecordHistory_DO(mes);



                //事件处理，出库事件，MainForm,BGSystem
                if (historyMessageArrived != null)
                    historyMessageArrived(this, new MessageEventArgs(mes));
                else
                    Console.WriteLine(DEBUG + "historyMessageArrived == null");   //*******************DEBUGGING*****************
                //do something
            }

             //事件处理，警告事件，标志位信息处理
            else if(CautionMessageArrived !=null)
            {

                if (Convert.ToInt32(mes.card.CardValue) <= 0)
                {
                    mes.card.ValidFlag = CardUnit.VFlag.耗尽;
                    CautionMessageArrived(this, new MessageEventArgs(mes));
                }
                else
                {
                    mes.card.ValidFlag = CardUnit.VFlag.无效;
                    CautionMessageArrived(this, new MessageEventArgs(mes));
                }
            }
            else 
            {
                Console.WriteLine(DEBUG + "CautionMessageArrived == null");   //*******************DEBUGGING*****************

            }

            //do something

        }
        private void rechargeCardHandler( MessageStc mes)
        {
         //   CardUnit rechargeCard = entr.cardUnit;
            if (RechargeCardMessageArrived != null)
            {
                RechargeCardMessageArrived(this, new MessageEventArgs(mes));

            }
            else
            {
                Console.WriteLine(DEBUG + "RechargeCardMessageArrived == null");   //*******************DEBUGGING*****************
            }


        }



        /*************************************************

         Function:    RechargeCard(int value)，RechargeCard(int value, CardStc.CType type)
         
         Description:   外部调取，充值方法 ，带类型参数时即改变卡片类型，以前的充值将清零
         
         Input:          value 充值数额 ，type
           
         Return:         bool，成功标志

       *************************************************/
        public bool RechargeCard(int value, CardUnit rechargeCard)
        {
            //充值的如果是月卡，充值为天数
            if (rechargeCard.CardType == CardUnit.CType.月卡)
            {
                value = value * 30;
            }

            //将充值数额和先前卡片数额累加
            int totalValue = value + Convert.ToInt32(rechargeCard.CardValue);
            rechargeCard.CardValue = Convert.ToString(totalValue);
            //写入最后一次充值事件
            rechargeCard.LastRecharge = System.DateTime.Now.ToString("G");
            //数据库写入充值金额
            DataOperater.RechargeCard_DO(rechargeCard);
            return true;
        }
        public bool RechargeCard(int value, CardUnit.CType type, CardUnit rechargeCard)
        {
            //改变卡片类型
            rechargeCard.CardType = type;
            //充值金额不累加
            rechargeCard.CardValue = Convert.ToString(value);
            rechargeCard.LastRecharge = System.DateTime.Now.ToString("G");
            DataOperater.RechargeCard_DO(rechargeCard);
            return true;
        }

        /*************************************************

         Function:    AddCard(CardStc card)
         
         Description:   外部调取，充值方法 ，带类型参数时即改变卡片类型，以前的充值将清零
         
         Input:          card，卡片实体
           
         Return:         bool，成功标志

       *************************************************/
        public bool AddCard(CardUnit card)
        {
            //更新创建时间
            card.InitTime = System.DateTime.Now.ToString("G");
            //更新创建时间
            card.LastRecharge = System.DateTime.Now.ToString("G");
            //设置有效标志位为有效
            card.ValidFlag = CardUnit.VFlag.有效;
            //数据库添加卡片
            DataOperater.AddCard_DO(card);
            
            return true;
        }

        /*************************************************

         Function:    EditCard_DO(CardStc card)
         
         Description:  
         
         Input:          card，卡片实体
           
         Return:         bool，成功标志

       *************************************************/
        public bool EditCard(CardUnit card)
        {
            DataOperater.EditCard_DO(card);
            return true;
        }

        /*************************************************

         Function:    DeleteCard(int id)
         
         Description:   删除数据库中的卡片信息
         
         Input:          card，卡片实体
           
         Return:         bool，成功标志

        *************************************************/
        public bool DeleteCard(int id)
        {
          DataOperater.DeleteCard_DO(id);
            return true;
        }


        public OleDbDataReader ShowCardInfo()
        {
            return DataOperater.ShowCardInfo_DO();
        }
        public OleDbDataReader CardClear()
        {
            return DataOperater.CardClear_DO();
        }
        public OleDbDataReader  HistoryLoader()
        {
            return  DataOperater.HistoryLoader_DO();
        }
        public OleDbDataReader  HistoryClear()
        {
            return DataOperater.HistoryClear_DO();
        }
        
    }

}
