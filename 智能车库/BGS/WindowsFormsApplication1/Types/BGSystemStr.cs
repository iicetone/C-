/** 
* 文 件 名 : Command
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：定义系统配置的结构体
* 版 本 号：0.1
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;

namespace Cheku.Types
{

    [Serializable]

    public struct BGSystemStr
    {
            public Command.BGSType type;                                      //进1 出2 可进可出3
            public string modeName;                             //配置模式名称
            public bool enableBGSystem;                         //是否允许开启BGS系统，开启后其他设置才可编辑
            public bool enableBGOn;                            //是否允许道闸开启，允许后才可接受开启道闸指令
            public bool enableBGOff;                           //是否允许道闸关闭，允许后才可接受关闭道闸指令
            public bool enableBGStop;                           //是否允许道闸停止
            public bool enableBGManual;                        //是否允许手动开启道闸，允许后才可接受手动开启道闸指令
            public bool enableCSender;                          //是否允许开启发卡器
            public bool enableCReader;                          //是否允许开启读卡器
            public bool enableCamera;                              //是否允许开启摄像头

            public Command.BGSstatus statusBG;                               //目前道闸状态，开启，闭合,停止,开启中,关闭中 1 2 3 4 5
            public bool statusBGS;                              //目前BGS系统状态，开启，闭合
            public bool statusBGManual;                        //手动开启道闸，允许后才可接受手动开启道闸指令状态
            public bool statusCSender;                          //开启发卡器状态
            public bool statusCReader;                          //开启读卡器状态
            public bool statusCamera;                            //开启摄像头状态
            public int  statusIDACK;                           //ID的验证状态

        }
}
