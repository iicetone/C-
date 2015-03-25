using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]

    public struct EntranceSettingStr
    {
        public int settingID;
        public string modeName;                             //配置模式名称
      
        public bool enableBGS;                         //是否允许开启BGS系统，开启后其他设置才可编辑
        public bool enableBGSRpeat;                         //是否允许开启BGS系统，开启后其他设置才可编辑

        public bool enableBGOn;                            //是否允许道闸开启，允许后才可接受开启道闸指令
        public int enableBGOnUp;

        public bool enableBGOff;                           //是否允许道闸关闭，允许后才可接受关闭道闸指令
        public int enableBGOffDelay;

        public bool enableBGManual;                        //是否允许手动开启道闸，允许后才可接受手动开启道闸指令

        public bool enableCReader;                          //是否允许开启读卡器
        public bool enableCReaderI;                          //是否允许开启读卡器
        public bool enableCReaderB;                          //是否允许开启读卡器

        public bool enableCSender;                          //是否允许开启发卡器
        public bool enableCamera;                              //是否允许开启摄像头

        public bool enableDG1;                              //是否允许开启摄像头
        public bool enableDG1P;                              //是否允许开启摄像头

        public bool enableDG2;                              //是否允许开启摄像头
        public bool enableDG2P;                              //是否允许开启摄像头

        public bool enableLED;                              //是否允许开启摄像头
        public string enableLEDStr;                              //是否允许开启摄像头

        public bool enableVoice;                              //是否允许开启摄像头

    }
}
