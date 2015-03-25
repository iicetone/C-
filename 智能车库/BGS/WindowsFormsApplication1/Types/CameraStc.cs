using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
        [Serializable]

    public class CameraStc
    {
        public int cameraID;
        public int channelID;
        public int parkID;

        public string cameraName;
        public string tcpAddr;
        public string tcpPort;
        public CameraType cameraType;

        public uint  cam_iLastErr = 0;
        public Int32  cam_lUserID = -1;
        public bool  cam_bInitSDK = false;
        public bool  cam_bRecord = false;
        public Int32  cam_lRealHandle = -1;
        
            public string DVRUserName = "admin";
            public string DVRPassword = "admin";
        public enum CameraType
        {
            通道摄像头,
            入口摄像头,
            出口摄像头,
            
        }
    }
}
