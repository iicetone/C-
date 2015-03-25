using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Cheku.Types;
using Cheku.MessageManager;

namespace Cheku.BGSystem
{

    class MessageOperater
    {
        private static String DEBUG = "debugging：*************in MessageOperater.cs: "; //DEBUG注释

        public const string HEAD_ACK_TEMP = "F0";
        public const string HEAD_IN_ACK = "F1";
        public const string HEAD_OUT_ACK = "F2";
        public const string HEAD_NEW = "F3";
        public const string HEAD_CONF = "F4";
        public const string HEAD_CONT = "F5";
        public const string HEAD_INVALID = "F6";
        public const string HEAD_EXPIRED = "F7";
        public const string HEAD_WILLEXPIRE = "F8";
        public const string HEAD_BAN = "F9";
        public const string HEAD_LEDB = "E0"; 
                public const string HEAD_LEDV = "E1"; 

        public const string  HEAD_LEDL = "E2"; 	//绑定LED

        public const string HEAD_TEST = "FE";

        public const int SIZE_BUF = 10;
        public const int SIZE_BUF_ID = 3;
        public const int SIZE_BUF_ID10 = 8;        
        public const int SIZE_BUF_CONF = SIZE_BUF_ID+1;

        public const int BUF_LOCA_ADDR = 0;
        public const int BUF_LOCA_ID = BUF_LOCA_ADDR + 1;
        public const int BUF_LOCA_CONF = BUF_LOCA_ADDR + 1;
        public const int BUF_LOCA_FLAG = BUF_LOCA_ID + SIZE_BUF_ID;
        public const int BUF_LOCA_INFO = BUF_LOCA_FLAG + 1;
        public const int BUF_LOCA_INFO1 = BUF_LOCA_INFO + 1;

        public const int BUF_LOCA_INFO2 = BUF_LOCA_INFO1 + 1;
        public const int BUF_LOCA_HEAD = BUF_LOCA_INFO2 + 1;
        public const int BUF_LOCA_TAIL = BUF_LOCA_HEAD + 1;


        private CardOperater co;
        private BGSOperater bgs;
        private RS485Operater rs485Opt;
        private TcpOperater tcpOpt;
        public event EventHandler<MessageEventArgs> DeviceMessageArrived;            //控制器出入库确认信息
        public event EventHandler<MessageEventArgs> ChannelMessageArrived;            //通道信息传递
        public event EventHandler<MessageEventArgs> DeviceSettingMessageArrived;      //控制器设置信息
        public event EventHandler<MessageEventArgs> NewCardMessageArrived;            //新用户信息
        public event EventHandler<MessageEventArgs> DeviceCommandMessageArrived;             //控制器控制命令


        private static MessageOperater instance;
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  
        private long received_count = 0;//接收计数  
        private long send_count = 0;//发送计数  
        SerialPort com;
        byte[] buffer = new Byte[8];   //创建缓冲区
        int test = 0;
        public MessageOperater(BGSOperater bgso)
        {

            co = CardOperater.GetInstance();
            bgs = bgso;


            tcpOpt = new TcpOperater();
            tcpOpt.TcpMessageArrived += this.deviceMessageHandlerTCP;
            tcpOpt.TcpMessageArrived += this.channelMessageHandlerTCP;

            rs485Opt = new RS485Operater();
            rs485Opt.RS485MessageArrived += this.deviceMessageHandler485;


            //读取当前的配置信息
            Console.WriteLine("485 TEST " + builder.ToString());   //*******************DEBUGGING*****************

        }

        public void SetComPort(String port, int baudRate)
        {

            if (port != String.Empty)
            {
                rs485Opt.setComPort(port, baudRate);
            }
            else
            {
                Console.WriteLine(DEBUG + "SetComPort() Rs485Port == null");   //*******************DEBUGGING*****************
            }

        }


        private void deviceMessageHandler485(object sender, MessageEventArgs e)
        {
            // SIZE_BUF: ADDR    ID    FLAG  HEAD TAIL
            //     BYTE:   0   1 2 3 4  5     6    7   

            // SIZE_BUF: ADDR    STA(CON)  TAIL TAIL2 HEAD  
            //     BYTE:   0       1 2 3 4   5    6     7     

            EntranceUnit curEUnit = new EntranceUnit();
            CardUnit card = new CardUnit();
            MessageStc mes = e.Mes;
            MessageTypeEnum statusComm = new MessageTypeEnum();

            UInt16 temp;
            string[] buff = new string[SIZE_BUF];
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = mes.info.Substring(i * 2, 2);
            }
            string data = buff[BUF_LOCA_HEAD];

            //  UInt16[] status= new UInt16[2];
            switch (data)
            {
                case HEAD_IN_ACK:
                    statusComm = MessageTypeEnum.INCARD;
                    data = Convert.ToInt32(buff[BUF_LOCA_ID], 16).ToString("000")
                        + Convert.ToInt32(buff[BUF_LOCA_ID + 1] + buff[BUF_LOCA_ID + 2], 16).ToString("00000");//3字节卡号版
                    temp = Convert.ToUInt16(buff[BUF_LOCA_FLAG], 16);
                     entranceCardSetter(ref card, Convert.ToString(data), Convert.ToString(temp, 2));        //填充EntranceUnit
                    break;

                case HEAD_NEW:
                    statusComm = MessageTypeEnum.NEWCARD;
                    data = Convert.ToInt32(buff[BUF_LOCA_ID], 16).ToString("000")
                        + Convert.ToInt32(buff[BUF_LOCA_ID + 1] + buff[BUF_LOCA_ID + 2], 16).ToString("00000");//3字节卡号版
                    temp = Convert.ToUInt16(buff[BUF_LOCA_FLAG], 16);
                    entranceCardSetter(ref card,Convert.ToString(data), Convert.ToString(temp, 2));        //填充EntranceUnit
                   card.CardType = CardUnit.CType.免费卡;
                   card.ValidFlag = CardUnit.VFlag.有效;                
                    break;
                case HEAD_CONF:
                    statusComm = MessageTypeEnum.STATUS;
                    data = String.Empty;

                        temp = Convert.ToUInt16(buff[BUF_LOCA_CONF], 16);
                        data += Convert.ToString(temp, 2);
                        temp = Convert.ToUInt16(buff[BUF_LOCA_CONF+1], 16);
                        data += Convert.ToString(temp, 2);

                    Console.WriteLine("485 TEST STA DATA  " + data);   //*******************DEBUGGING*****************
                    entranceStatusSetter(ref curEUnit,data);        //填充EntranceUnit
                    break;
                case HEAD_TEST:
                    statusComm = MessageTypeEnum.DEVICE_TEST;
                    curEUnit.entranceStatus.statusBGS = Command.BGSstatus.测试通过;
                    break;
            }

            curEUnit.rs485Addr = buff[BUF_LOCA_ADDR];        //地址载入
            curEUnit.entranceMode = EntranceModeEnum.RS485;
            mes.park.selectedChannel.selectedEntrance = curEUnit;
            mes.type = statusComm;
            mes.card = card;
            if (bgs.SMode == Command.SoftMode.从机)
            {
                //forwardMessage(curEUnit);
            }
            else
            {
                if (DeviceMessageArrived != null)
                {
                    DeviceMessageArrived(this, new MessageEventArgs(mes));
                }
                else
                {
                    Console.WriteLine(DEBUG + "RS485MessageArrived == null");   //*******************DEBUGGING*****************
                }
            }

        }

        private void deviceMessageHandlerTCP(object sender, MessageEventArgs e)
        {
            MessageStc megs = e.Mes;
            // if (bgs.sMode == Command.SoftMode.分机) 
            if (megs.type == MessageTypeEnum.DEVICE )
            {
                if (DeviceMessageArrived != null)
                {
                    DeviceMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "DeviceMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else  if (megs.type == MessageTypeEnum.DEVICE_SETTING)
            {
                if (DeviceSettingMessageArrived != null)
                {
                    DeviceSettingMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "DeviceSettingMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else if (megs.type == MessageTypeEnum.NEWCARD)
            {
              //  EntranceUnit entr = megs.eu;
                if (NewCardMessageArrived != null)
                {
                    NewCardMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "NewCardMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else if (megs.type == MessageTypeEnum.GATE_COMM)
            {
                if (DeviceCommandMessageArrived != null)
                {
                    DeviceCommandMessageArrived(this, new MessageEventArgs( megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "DeviceCommandMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }

            else if (megs.type == MessageTypeEnum.DEVICE_TEST)
            {
                if (DeviceMessageArrived != null)
                {
                    DeviceMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "DeviceMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
        }

        private void channelMessageHandlerTCP(object sender, MessageEventArgs e)
        {
            MessageStc megs = e.Mes;

            if (megs.type == MessageTypeEnum.CHANNEL_APPLY)
            {
                if (ChannelMessageArrived != null)
                {
                    ChannelMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "ChannelMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else if (megs.type == MessageTypeEnum.CHANNEL_TEST)
            {
                if (ChannelMessageArrived != null)
                {
                    ChannelMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "ChannelMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else if (megs.type == MessageTypeEnum.CHANNEL_GATECOMM)
            {
                if (ChannelMessageArrived != null)
                {
                    ChannelMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "ChannelMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            else if (megs.type == MessageTypeEnum.CHANNEL_GATESETTING)
            {
                if (ChannelMessageArrived != null)
                {
                    ChannelMessageArrived(this, new MessageEventArgs(megs));
                }
                else
                {
                    Console.WriteLine(DEBUG + "ChannelMessageArrived == null");   //*******************DEBUGGING*****************
                }
            }
            /// <summary>
            ///从机使用
            /// </summary>
            /// <param name="entr"></param>
            //else if (megs.type == MessageTypeEnum.VACANCY)
            //{
            //    if (ChannelMessageArrived != null)
            //    {
            //        ChannelMessageArrived(this, new MessageEventArgs(megs));
            //    }
            //    else
            //    {
            //        Console.WriteLine(DEBUG + "VacancyMessageArrived == null");   //*******************DEBUGGING*****************
            //    }
            //}
        }
        /// <summary>
        ///从机使用
        /// </summary>
        /// <param name="entr"></param>
        //public void forwardMessage(EntranceUnit entr)
        //{
        //    MessageStc msgs = new MessageStc();
        //    msgs.type = MessageTypeEnum.DEVICE;
        //    msgs.eu = entr;
        //    msgs.ip = bgs.ServerAddr;
        //    if (tcpOpt != null)
        //    {
        //        tcpOpt.sendTCPMessage(msgs);
        //    }
        //    else
        //    {
        //        //TCP未实例化
        //    }
        //}

        public void SendACKData485(MessageStc mes)
        {
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
            Byte[] data = new Byte[SIZE_BUF];
            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);
            String idtemp = mes.card.CardID == null ? "" : mes.card.CardID;

            if (idtemp.Length == SIZE_BUF_ID10)
            {
                string hid = idtemp.Substring(0, 3);
                string pid = idtemp.Substring(3, 5);
                pid = Convert.ToString(Convert.ToInt32(pid), 16);
                data[BUF_LOCA_ID] = Convert.ToByte(hid);
                data[BUF_LOCA_ID + 1] = Convert.ToByte(pid.Substring(0, 2), 16);
                data[BUF_LOCA_ID + 2] = Convert.ToByte(pid.Substring(2, 2), 16);

            }
            //String cardFlagTemp = "111"; //未处理的 7,8位   由控制器处理的 6位
            //if (entr.selectedCard.CardType == CardUnit.CType.临时卡)
            //{
            //    cardFlagTemp += "001";
            //}
            //else if (entr.selectedCard.CardType == CardUnit.CType.充值卡)
            //{
            //    cardFlagTemp += "010";
            //}
            //else if (entr.selectedCard.CardType == CardUnit.CType.月卡)
            //{
            //    cardFlagTemp += "011";
            //}
            //else if (entr.selectedCard.CardType == CardUnit.CType.免费卡)
            //{
            //    cardFlagTemp += "100";
            //}
            //cardFlagTemp += entr.selectedCard.TimerFlag ? "1" : "0";
            //cardFlagTemp += entr.selectedCard.ValidFlag != CardUnit.VFlag.无效 && entr.selectedCard.ValidFlag != CardUnit.VFlag.耗尽 ? "1" : "0";

           // data[BUF_LOCA_FLAG] = Convert.ToByte(cardFlagTemp, 2); ;    //FLAG暂未处理
             data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 16); ;    //FLAG暂未处理

            String valuestr = "";
            if (mes.card.CardValue.ToString().Length < 6)
            {
                for (int i = 0; i < 6 - mes.card.CardValue.ToString().Length; i++)
                {
                    valuestr += "0";
                }
                valuestr += mes.card.CardValue.ToString();

            }

            data[BUF_LOCA_INFO] = Convert.ToByte(valuestr.Substring(0, 2), 10);
            data[BUF_LOCA_INFO1] = Convert.ToByte(valuestr.Substring(2, 2), 10);
            data[BUF_LOCA_INFO2] = Convert.ToByte(valuestr.Substring(4, 2), 10);

            switch (mes.card.ValidFlag)
            {
                case CardUnit.VFlag.无效:
                    data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_INVALID, 16);
                    break;
                case CardUnit.VFlag.有效:
                    if (mes.type == MessageTypeEnum.OUTCARD)
                        data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_OUT_ACK, 16);
                    else if (mes.type == MessageTypeEnum.INCARD)
                        data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_IN_ACK, 16);
                    break;
                //case CardUnit.VFlag.即将过期:
                //    data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_WILLEXPIRE, 16);
                //    break;
                case CardUnit.VFlag.耗尽:
                    data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_EXPIRED, 16);
                    break;
                case CardUnit.VFlag.禁止:
                    data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_BAN, 16);
                    break;
                case CardUnit.VFlag.临时:
                    data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_ACK_TEMP, 16);
                    break;

                default:
                    break;
            }

            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);
            rs485Opt.sendData(data);

        }
        public void sendConfData485(MessageStc mes)
        {
            Byte[] data = new Byte[SIZE_BUF];
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
           String  conf = mes.info;

            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);
            data[BUF_LOCA_CONF] = Convert.ToByte(conf.Substring(0, 8), 2);
            data[BUF_LOCA_CONF + 1] = Convert.ToByte(conf.Substring(8, 8), 2);
            data[BUF_LOCA_CONF + 2] = Convert.ToByte(conf.Substring(16, 8), 2);
            data[BUF_LOCA_CONF + 3] = Convert.ToByte(conf.Substring(24, 8), 2);
            data[BUF_LOCA_INFO] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO2] = Convert.ToByte("FF", 16); 
            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_CONF, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);
            rs485Opt.sendData(data);

        }
        public void sendContData485(MessageStc mes)
        
        {
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;

            Byte[] data = new Byte[SIZE_BUF];
           data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);

           data[BUF_LOCA_CONF] = Convert.ToByte("FF", 16);
         data[BUF_LOCA_CONF + 1] = Convert.ToByte("FF", 16);
          data[BUF_LOCA_CONF + 2] = Convert.ToByte("FF", 16);
          data[BUF_LOCA_CONF + 3] = Convert.ToByte("FF", 16);

          data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO2] = Convert.ToByte("FF", 16);

            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_CONT, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);

            rs485Opt.sendData(data);

        }
        public void sendNewCardData485(MessageStc mes)
        {
            Byte[] data = new Byte[SIZE_BUF];
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
            CardUnit card = mes.card;
            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);
            if (card.CardID.Length == SIZE_BUF_ID10)
            {
                string hid = card.CardID.Substring(0, 3);
                string pid = card.CardID.Substring(3, 5);
                pid = Convert.ToString(Convert.ToInt32(pid), 16);
                data[BUF_LOCA_ID] = Convert.ToByte(hid);
                data[BUF_LOCA_ID + 1] = Convert.ToByte(pid.Substring(0, 2), 16);
                data[BUF_LOCA_ID + 2] = Convert.ToByte(pid.Substring(2, 2), 16);
            }
            //String cardFlagTemp = "111"; //未处理的 7,8位   由控制器处理的 6位
            //if (card.CardType == CardUnit.CType.临时卡)
            //{
            //    cardFlagTemp += "001";
            //}
            //else if (card.CardType == CardUnit.CType.充值卡)
            //{
            //    cardFlagTemp += "010";
            //}
            //else if (card.CardType == CardUnit.CType.月卡)
            //{
            //    cardFlagTemp += "011";
            //}
            //else if (card.CardType == CardUnit.CType.免费卡)
            //{
            //    cardFlagTemp += "100";
            //}
            //cardFlagTemp += card.TimerFlag ? "1" : "0";
            //cardFlagTemp += card.ValidFlag != 0 ? "1" : "0";

            //data[BUF_LOCA_FLAG] = Convert.ToByte(cardFlagTemp, 2); ;    //FLAG暂未处理
            data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 2); ;    //FLAG暂未处理

            data[BUF_LOCA_INFO] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO2] = Convert.ToByte("FF", 16); 
            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_NEW, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);
            rs485Opt.sendData(data);

        }
        public void sendTestData485(MessageStc mes)
        {
            Byte[] data = new Byte[SIZE_BUF];
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);

            data[BUF_LOCA_ID] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_ID+1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_ID+2] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO2] = Convert.ToByte("FF", 16); 
            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_TEST, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);
            rs485Opt.sendData(data);

        }
        public void sendVacancy(MessageStc m)
        {
            MessageStc mes = m;
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
            String vacstr = "" ;
            if (mes.info.Length < 6)
            {
                for (int i = 0; i < 6 - mes.info.Length; i++)
                {
                    vacstr += "0";
                }
                vacstr += mes.info;

            }
            Byte[] data = new Byte[SIZE_BUF];
            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);

            data[BUF_LOCA_CONF] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_CONF + 1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_CONF + 2] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO] = Convert.ToByte(vacstr.Substring(0, 2), 10);
            data[BUF_LOCA_INFO1] = Convert.ToByte(vacstr.Substring(2, 2), 10);
            data[BUF_LOCA_INFO2] = Convert.ToByte(vacstr.Substring(4, 2), 10);

            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_LEDV, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);

            rs485Opt.sendData(data);

        }
        public void sendReSetLED(MessageStc mes)
        {
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;

            Byte[] data = new Byte[SIZE_BUF];

            data[BUF_LOCA_ADDR] = Convert.ToByte(entr.rs485Addr, 16);

            data[BUF_LOCA_ID] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_ID + 1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_ID + 2] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_FLAG] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO1] = Convert.ToByte("FF", 16);
            data[BUF_LOCA_INFO2] = Convert.ToByte("FF", 16); 
            data[BUF_LOCA_HEAD] = Convert.ToByte(HEAD_LEDL, 16);
            data[BUF_LOCA_TAIL] = Convert.ToByte("FF", 16);
            rs485Opt.sendData(data);

        }

        public void sendDataTCP(MessageStc mes)
        {
            tcpOpt.sendTCPMessage(mes);
        }


        public void ChannelApply(string serverIP)
        {
            MessageStc msgs = new MessageStc();
            msgs.park.selectedChannel.stationAddr = tcpOpt.getMyIP().ToString();
            msgs.ip = serverIP;
            msgs.type = MessageTypeEnum.CHANNEL_APPLY;

            tcpOpt.sendTCPMessage(msgs);
        }
        private void entranceStatusSetter(ref EntranceUnit curEUnit,string status)
        {

            char[] arr = new char[16];
            char[] temparr = status.ToCharArray();

            int i = temparr.Length - 1;
             for (int j = arr.Length-1; j>= 0; j--)
                {
                    arr[j] = temparr[i];
                    if (i == 0) break;
                    i--;
                }		
          int  length = arr.Length;
           if (arr[length - 9] == '1') //停止
               curEUnit.entranceStatus.statusBGS = Command.BGSstatus.停止中; //停止
           else if (arr[length - 8] == '1')//关闭
               curEUnit.entranceStatus.statusBGS = Command.BGSstatus.关闭中;   //关闭中    
            else if (arr[length - 7] == '1') //开启
                curEUnit.entranceStatus.statusBGS = Command.BGSstatus.开启中;      //开启中

        }
        private void entranceCardSetter(ref CardUnit card,  string id, string flag)
        {
            card.CardID = id;
        }

        public void LinkClosing()
        {
            tcpOpt.tcpClosing();
        }



    }


}
