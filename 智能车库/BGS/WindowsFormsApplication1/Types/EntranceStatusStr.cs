using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

    public struct EntranceStatusStr
    {
        int id;

        public Command.BGSstatus statusBGS;                               //目前道闸状态，开启，闭合,停止,开启中,关闭中 1 2 3 4 5
        public bool statusBGManual;                        //手动开启道闸，允许后才可接受手动开启道闸指令状态
        public bool statusCSender;                          //开启发卡器状态
        public bool statusCReader;                          //开启读卡器状态
        public bool statusCamera;                            //开启摄像头状态
        public int statusIDACK;                           //ID的验证状态

    }
}
