using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
using Cheku.CamereManager;
using Cheku.DataManager;
using System.Data.OleDb;

namespace Cheku.BGSystem
{
    class CameraManager
    {
        BGSOperater bgsOpt;
     //   List<CameraStc> cameraList;
        private bool cam_bInitSDK = false;

        public CameraManager(BGSOperater bgs)
        {
            this.bgsOpt = bgs;

        }
        public void CameraInit()
        {
            cam_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (cam_bInitSDK == false)
            {
                //MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
            //cameraList = new List<CameraStc>();
        }
        //private void  loadCameraList()
        //{
        //    CameraStc camera;

        //    OleDbDataReader reader = DataOperater.CameraLoader_DO();
        //    while (reader.Read())
        //    {
        //        camera = new CameraStc();
        //        camera.cameraID = Convert.ToInt32(reader["ID"].ToString());
        //        camera.cameraName = reader["cameraName"].ToString();
        //        camera.tcpAddr = reader["tcpAddr"].ToString();
        //        camera.tcpPort = reader["tcpPort"].ToString();
        //        camera.cameraType = (CameraStc.CameraType)Enum.Parse(typeof(CameraStc.CameraType), reader["cameraType"].ToString());
        //        camera.cameraID = Convert.ToInt32(reader["channelID"].ToString());

        //        cameraList.Add(camera);
        //    }

        //}
        public string GetCameraPreView(CameraStc camera, ref System.Windows.Forms.PictureBox pic)
        {

            String str;
            if (camera.cam_lUserID < 0)
            {
               // MessageBox.Show("Please login the device firstly");
                return str = "Please login the device firstly";
            }

            if (camera.cam_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = pic.Handle;//预览窗口
               // lpPreviewInfo.lChannel = Int16.Parse(textBoxChannel.Text);//预te览的设备通道
                lpPreviewInfo.lChannel = 1;
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                IntPtr pUser = new IntPtr();//用户数据

                //打开预览 Start live view 
                camera.cam_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(camera.cam_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (camera.cam_lRealHandle < 0)
                {
                    camera.cam_iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + camera.cam_iLastErr; //预览失败，输出错误号
                    //MessageBox.Show(str);
                    return str;
                }
                else
                {
                    //预览成功
                   return str = "Stop";
                }
            }
            else
            {
                //停止预览 Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(camera.cam_lRealHandle))
                {
                    camera.cam_iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + camera.cam_iLastErr;
                   // MessageBox.Show(str);
                    return str;
                }
                camera.cam_lRealHandle = -1;
               // btnPreview.Text = "Live";
                str = "Live";
            }
            return str;
        }
        public string LoginCamera(ref CameraStc camera)
        {
            string str;
            if (camera.cam_lUserID < 0)
            {
                string DVRIPAddress = camera.tcpAddr; //设备IP地址或者域名
                Int16 DVRPortNumber = Int16.Parse(camera.tcpPort);//设备服务端口号
                camera.DVRUserName = "admin";
                camera.DVRPassword = "12345";
                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                camera.cam_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, camera.DVRUserName, camera.DVRPassword, ref DeviceInfo);
                if (camera.cam_lUserID < 0)
                {
                    camera.cam_iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    return str = "NET_DVR_Login_V30 failed, error code= " + camera.cam_iLastErr; //登录失败，输出错误号
                   // MessageBox.Show(str);
                }
                else
                {
                    //登录成功
                  //  MessageBox.Show("Login Success!");
                    return str = "Logout";
                }

            }
            else
            {
                //注销登录 Logout the device
                if (camera.cam_lRealHandle >= 0)
                {
                   // MessageBox.Show("Please stop live view firstly");
                    return str = "Please stop live view firstly";
                }

                if (!CHCNetSDK.NET_DVR_Logout(camera.cam_lUserID))
                {
                    camera.cam_iLastErr =CHCNetSDK.NET_DVR_GetLastError();
                   // str = "NET_DVR_Logout failed, error code= " + camera.cam_iLastErr;
                    //MessageBox.Show(str);
                    return str = "NET_DVR_Logout failed, error code= " + camera.cam_iLastErr;
                }
                camera.cam_lUserID = -1;
               return str = "Login";
            }
        }
        public string SaveJPEG(CameraStc camera)
        {
            string sJpegPicFileName,str;
            //图片保存路径和文件名 the path and file name to save
            sJpegPicFileName = camera.cameraName+"_"+camera.cameraID+"_"+DateTime.Now.ToString()+"_JPEG.jpg";

            int lChannel = Int16.Parse("1"); //通道号 Channel number

            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //图像质量 Image quality
            lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

            //JPEG抓图 Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(camera.cam_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                camera.cam_iLastErr = CHCNetSDK.NET_DVR_GetLastError();
               // MessageBox.Show(str);
                return str = "NET_DVR_CaptureJPEGPicture failed, error code= " + camera.cam_iLastErr;
            }
            else
            {
              return  str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
               // MessageBox.Show(str);
            }
        }
        public void RecordCamera(CameraStc camera)
        { 
        }
        public void CloseCamera(CameraStc camera)

        {
            //停止预览 Stop live view 
            if (camera.cam_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(camera.cam_lRealHandle);
                camera.cam_lRealHandle = -1;
            }

            //注销登录 Logout the device
            if (camera.cam_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(camera.cam_lUserID);
                camera.cam_lUserID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();
        }
        public bool GetCamera(ref CameraStc camera)
        {
           return bgsOpt.GetCurrentCameraStc( ref camera);
        }
        public List<ChannelUnit> GetChannelWithCamera()
        {
            List<ChannelUnit> chanList= bgsOpt.ChannelList;
            List<CameraStc> camList = bgsOpt.CameraList;

                      
            for (int i = 0; i < chanList.Count; i++)
            {
                if (chanList[i].cameraCount == 0) continue;

                ChannelUnit temp = chanList[i];
                temp.cameraList = new List<CameraStc>();
                foreach (CameraStc cam in camList)
                {
                    if (cam.channelID != temp.channelID) continue;
                    temp.cameraList.Add(cam);
                }
                chanList[i] = temp;
            }

            return chanList;
        }
        public void getChannel(ref ChannelUnit chan)
        { 
            chan = bgsOpt.GetCurrentChannel(chan.channelID);
        }
        public void updateCamera(ref ChannelUnit chan,ref CameraStc camera)
        {

             chan = bgsOpt.GetCurrentChannel(chan.channelID);

           if (camera.cameraID == 0)
            {
                addCamera(ref chan, ref camera);
            }
            else
            {
                saveCamera( camera);
            }

        }

        private void  saveCamera( CameraStc camera)
        {
            bgsOpt.SetCurrentCamera(camera);
         }
        private void addCamera(ref ChannelUnit chan ,   ref CameraStc camera)
        {
            bgsOpt.AddCurrentCamera(ref camera);
            chan.cameraCount = chan.cameraCount + 1;
            bgsOpt.SetCurrentChannel(chan);
        }

        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
    }

}
