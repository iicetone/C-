
/** 
* 文 件 名 : MessageEventArgs
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：002 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：  委托事件，出入库，充值，警告信息
* 版 本 号：0.1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
namespace Cheku.BGSystem

{
    public class MessageEventArgs:EventArgs
    {
        private MessageStc message;
        private BGSTimerStr timer;
        private bool isStart;
        private MessageTypeEnum msgType;



        public MessageStc Mes
        {
            get
            {
                return message;
            }
        }

        public BGSTimerStr BGSTimer
        {
            get
            {
                return timer;
            }
        }
        public bool IsStart
        {
            get
            {
                return isStart;
            }
        }

        public MessageEventArgs(MessageStc mes)
        {
            message = mes;
        }

        public MessageEventArgs(BGSTimerStr timer , bool isStart)
        {
            this.timer = timer;
            this.isStart = isStart;

        }

    }
}
