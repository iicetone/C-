/** 
* 文 件 名 : BGSOperater
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：001 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：负责控制器，读卡器，发卡器，摄像头的控制及配置。
* 版 本 号：0.1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
using Cheku.BGSystem;
using System.Data.OleDb;
using Cheku.DataManager;

namespace Cheku.BGSystem
{
    class BGSOperater
    {
        private static String DEBUG = "debugging：*************in BGSOperater.cs: "; //DEBUG注释

        

        public Command.SoftMode SMode;
        public string ServerAddr;
        public string Rs485Port;
        private static BGSOperater instance;  //实例化
        private CardOperater cOpt;
        private MessageOperater msgOpt;
        private CameraManager camOpt;
        BGSTimerOperater timerOpt;

        private List<ParkUnit> parkList;      //维护的通道列表 
        private List<ChannelUnit> channelList;      //维护的通道列表
        private List<EntranceUnit> entranceList;      //维护的出入口列表
        private List<ChargeModeStr> chargeModeList;      //维护计费模式列表
        private List<EntranceSettingStr> entrSettingList;      //维护出入口篇配置列表
        private List<CameraStc> cameraList;


        private BGSystemSetting bgss = new BGSystemSetting();//系统配置setting文件的实例化

        public event EventHandler<MessageEventArgs> entranceStatusMessageArrived;            //收到状态委托任务
        public event EventHandler<MessageEventArgs> channelStatusMessageArrived;             //收到状态委托任务
        public event EventHandler<MessageEventArgs> parkStatusMessageArrived;            //收到状态委托任务

        public event EventHandler<MessageEventArgs> addChannelMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> addDeviceMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> updateChannelMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> updateDeviceMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> addParkMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> updateParkMessageArrived;            //入库委托任务
        public event EventHandler<MessageEventArgs> cardPassMessageArrived;            //入库委托任务

        public int TotalSpace { get; set; }
        public int OccupiedSpace { get; set; }
        public int RemainSpace { get; set; }

        private BGSOperater()
        {

            cOpt = CardOperater.GetInstance(); //获取CardOperater的实例化
            msgOpt = new MessageOperater(this);       //实例化MESSAGE管理
            msgOpt.SetComPort("COM8", 9600);

            //msgOpt.SetComPort(Rs485Port, 9600); 

            timerOpt = new BGSTimerOperater();
            timerOpt.TimerStart();
            // this.readDefaultSetting();

            camOpt = new CameraManager(this);
            camOpt.CameraInit();

            readDefaultSetting();//读出默认的配置信息
            loadBGSInfo();      //载入配置信息,计费策略,通道及包含的出入口


            //   cOpt.cardPassMessageArrived += BGSTurnOn;  //入库委托
            //   cOpt.OutCardMessageArrived += BGSTurnOn;  //出库委托
            msgOpt.DeviceMessageArrived += deviceMessageHandler;
            msgOpt.ChannelMessageArrived += channelMessageHandler;
            msgOpt.DeviceSettingMessageArrived += deviceSettingMessageHandler;
            msgOpt.NewCardMessageArrived += newCardMessageHandler;
            msgOpt.DeviceCommandMessageArrived += deviceCommandMessageHandler;

            timerOpt.BGSTimerMessageArrived += timerMessageHandler;

        }


        /*************************************************

          Function:       GetInstance()
          
         * Description:     获取BGSOperater的实例化的调用方法。

        *************************************************/
        public static BGSOperater GetInstance()
        {
            if (instance == null)
                instance = new BGSOperater();
            return instance;
        }

        public CameraManager CamManager
        {
            get
            {
                return camOpt;
            }
        }
        public List<ParkUnit> ParkList
        {
            get
            {
                return parkList;
            }
        }

        public List<ChannelUnit> ChannelList
        {
            get
            {
                return channelList;
            }
        }
        public List<EntranceUnit> EntranceList
        {
            get
            {
                return entranceList;
            }
        }
        public List<CameraStc> CameraList
        {
            get
            {
                return cameraList;
            }
        }
        public List<ChargeModeStr> ChargeModeList
        {
            get
            {
                return chargeModeList;
            }
        }
        public List<EntranceSettingStr> EntranceSettingList
        {
            get
            {
                return entrSettingList;
            }
        }
        public void ChannelApply()
        {
            if (ServerAddr != null)
            {
                msgOpt.ChannelApply(ServerAddr);
            }
            else Console.WriteLine(DEBUG + "ChannelApply() ServerAddr == null");   //*******************DEBUGGING*****************

        }
        /*************************************************

          Function:        BGSControl(Command.ControlComm comm)
        
         Description:     BGS的控制操作入口，由各界面中命令调用
          Input:          comm  控制命令，enable 控制的具体内容，开启还是关闭
          Return:         返回文字说明

        *************************************************/

        public String BGSControl(MessageStc mes)
        {
            if (SMode == Command.SoftMode.单主机)
            {
                switch (mes.type)
                {
                    case MessageTypeEnum.GATE_COMM:
                        turnONBarrier(mes);
                        return null;
                    default:
                        return null;
                }
            }
            else if (SMode == Command.SoftMode.主机)
            {
                msgOpt.sendDataTCP(mes);
            }
            //else if (SMode == Command.SoftMode.从机)
            //{
            //    mes.ip = ServerAddr;
            //    msgOpt.sendDataTCP(mes);
            //}
            return null;
        } 

        /*************************************************

         Function:        turnONBarrier(bool enable)，turnOFFBarrier(bool enable)
        
        Description:     由BGSControl调用，打开或关闭道闸的具体方法

         Return:         返回bool 反馈成功信息

       *************************************************/

        private bool turnONBarrier(MessageStc mes)
        {
            EntranceUnit entr = mes.park.selectedChannel.selectedEntrance;
            //检测 是否允许开启道闸，BGS系统是否允许运行，是否处于常开状态三个标志位
            if (entr.entranceSetting.enableBGOn && entr.entranceSetting.enableBGS)
            {
                msgOpt.sendContData485(mes);//目前只接受开启任务
            }
            else
            {
                Console.WriteLine(DEBUG + "turnONBarrier() can't open");   //*******************DEBUGGING*****************
                return false;
            }
            return true;
        }
        private bool turnOFFBarrier(EntranceUnit entrance, bool enable)
        {

            if (entrance.entranceSetting.enableBGOff && entrance.entranceSetting.enableBGS && entrance.entranceStatus.statusBGS == Command.BGSstatus.关闭中)
            {
                //marking turnon 
            }
            return true;

        }

        /*************************************************

         Function:     readSetting()，， saveCurrentSetting()
         
         Description:    读取或写入BGSystemSetting.settings里的配置信息
         
         Input:          
           
         Return:          

       *************************************************/
        public void readDefaultSetting()
        {

            this.SMode = (Command.SoftMode)Enum.Parse(typeof(Command.SoftMode), bgss.SystemMode);
            this.ServerAddr = bgss.ServerAddr;
            this.Rs485Port = bgss.Rs485Port;
            this.TotalSpace = Convert.ToInt32(bgss.TotalSpace);
            this.OccupiedSpace = Convert.ToInt32(bgss.OccupiedSpace);
            this.RemainSpace = Convert.ToInt32(bgss.RemainSpace);

        }

        public void saveDefaultSetting()
        {
            bgss.SystemMode = this.SMode.ToString();
            bgss.ServerAddr = this.ServerAddr;
            bgss.Rs485Port = this.Rs485Port;
            bgss.TotalSpace = this.TotalSpace.ToString();
            bgss.OccupiedSpace = this.OccupiedSpace.ToString();
            bgss.RemainSpace = this.RemainSpace.ToString();
        }


        /*************************************************

        Function:     loadDBSetting(string name)
         
        Description:  从数据库中载入所有设置信息并放入LIST中
     
        Function:     saveDBSetting(EntranceSettingStr newSet)
         
        Description:  将新的配置信息保存到entranceSettingList及数据库中    Input:          
           
        Return:          

        *************************************************/

        private void loadBGSInfo()
        {
            entranceList = new List<EntranceUnit>();
            channelList = new List<ChannelUnit>();
            chargeModeList = new List<ChargeModeStr>();
            entrSettingList = new List<EntranceSettingStr>();
            cameraList = new List<CameraStc>();
            parkList = new List<ParkUnit>();
            if (SMode != Command.SoftMode.从机)
            {
                loadDBSetting();
                loadDBChargeMode();
                loadDBEntrance();
                loadDBCamera();
                loadDBChannel();
                loadDBPark();

            }
            else
            {
                //ChannelApply();

            }
        }


        private void loadDBSetting()
        {
            EntranceSettingStr entrSetting;

            OleDbDataReader reader = DataOperater.ConfigModeLoader_DO();
            while (reader.Read())
            {
                entrSetting = new EntranceSettingStr();

                entrSetting.settingID = Convert.ToInt32(reader["ID"].ToString());

                entrSetting.modeName = reader["modeName"].ToString();
                entrSetting.enableBGS = (Boolean)reader["enableBGS"];
                entrSetting.enableBGSRpeat = (Boolean)reader["enableBGSRpeat"];

                entrSetting.enableBGOn = (Boolean)reader["enableBGOn"];
                entrSetting.enableBGOnUp = (Int32)reader["enableBGOnUp"];

                entrSetting.enableBGOff = (Boolean)reader["enableBGOff"];
                entrSetting.enableBGOffDelay = (Int32)reader["enableBGOffDelay"];

                entrSetting.enableBGManual = (Boolean)reader["enableBGManual"];

                entrSetting.enableCSender = (Boolean)reader["enableCSender"];

                entrSetting.enableCReader = (Boolean)reader["enableCReader"];
                entrSetting.enableCReaderI = (Boolean)reader["enableCReaderI"];
                entrSetting.enableCReaderB = (Boolean)reader["enableCReaderB"];

                entrSetting.enableDG1 = (Boolean)reader["enableDG1"];
                entrSetting.enableDG1P = (Boolean)reader["enableDG1P"];
                entrSetting.enableDG2 = (Boolean)reader["enableDG2"];
                entrSetting.enableDG2P = (Boolean)reader["enableDG2P"];

                entrSetting.enableLED = (Boolean)reader["enableLED"];
                entrSetting.enableLEDStr = (String)reader["enableLEDStr"];

                entrSetting.enableCamera = (Boolean)reader["enableCamera"];
                entrSetting.enableVoice = (Boolean)reader["enableVoice"];

                entrSettingList.Add(entrSetting);
            }

        }
        private void loadDBChargeMode()
        {
            ChargeModeStr chargeMode;

            OleDbDataReader reader = DataOperater.ChargeModeLoader_DO();
            while (reader.Read())
            {
                chargeMode = new ChargeModeStr();

                chargeMode.modeID = Convert.ToInt32(reader["ID"].ToString());
                chargeMode.modeName = reader["modeName"].ToString();
                chargeMode.enableMFCard = (Boolean)reader["enableMFCard"];
                chargeMode.enableYCard = (Boolean)reader["enableYCard"];
                chargeMode.enableCZCard = (Boolean)reader["enableCZCard"];
                chargeMode.enableLSCard = (Boolean)reader["enableLSCard"];
                chargeMode.enableYGCard = (Boolean)reader["enableYGCard"];
                chargeMode.enableSQCard = (Boolean)reader["enableSQCard"];
                chargeMode.enableTQCard = (Boolean)reader["enableTQCard"];
                chargeMode.enableRCard = (Boolean)reader["enableRCard"];

                chargeMode.unitCZCard = Convert.ToInt32(reader["unitCZCard"].ToString());
                chargeMode.unitPayCZCard = Convert.ToInt32(reader["unitPayCZCard"].ToString());
                chargeMode.discountCZCard = Convert.ToInt32(reader["discountCZCard"].ToString());
                chargeMode.freeTimeCZCard = Convert.ToInt32(reader["freeTimeCZCard"].ToString());

                chargeMode.unitLSCard = Convert.ToInt32(reader["unitLSCard"].ToString());
                chargeMode.unitPayLSCard = Convert.ToInt32(reader["unitPayLSCard"].ToString());
                chargeMode.discountLSCard = Convert.ToInt32(reader["discountLSCard"].ToString());
                chargeMode.freeTimeLSCard = Convert.ToInt32(reader["freeTimeLSCard"].ToString());

                chargeMode.unitYGCard = Convert.ToInt32(reader["unitYGCard"].ToString());
                chargeMode.unitPayYGCard = Convert.ToInt32(reader["unitPayYGCard"].ToString());
                chargeMode.discountYGCard = Convert.ToInt32(reader["discountYGCard"].ToString());
                chargeMode.freeTimeYGCard = Convert.ToInt32(reader["freeTimeYGCard"].ToString());

                chargeMode.unitPayYCard = Convert.ToInt32(reader["unitPayYCard"].ToString());
                chargeMode.unitPayRCard = Convert.ToInt32(reader["unitPayRCard"].ToString());
                chargeMode.modeSQCard = (Boolean)reader["modeSQCard"];

                chargeModeList.Add(chargeMode);
            }

        }
        private void loadDBCamera()
        {
            CameraStc camera;

            OleDbDataReader reader = DataOperater.CameraLoader_DO();
            while (reader.Read())
            {
                camera = new CameraStc();
                camera.cameraID = Convert.ToInt32(reader["ID"].ToString());
                camera.cameraName = reader["cameraName"].ToString();
                camera.tcpAddr = reader["tcpAddr"].ToString();
                camera.tcpPort = reader["tcpPort"].ToString();
                camera.cameraType = (CameraStc.CameraType)Enum.Parse(typeof(CameraStc.CameraType), reader["cameraType"].ToString());
                camera.channelID = Convert.ToInt32(reader["channelID"].ToString());
                camera.parkID = Convert.ToInt32(reader["parkID"].ToString());
                

                cameraList.Add(camera);
            }
        }

        private void loadDBChannel()
        {
            ChannelUnit channel;

            OleDbDataReader reader = DataOperater.ChannelUnitLoader_DO();
            while (reader.Read())
            {
                channel = new ChannelUnit();

                channel.channelID = Convert.ToInt32(reader["ID"].ToString());

                channel.channelName = reader["channelName"].ToString();
                channel.parkID = Convert.ToInt32(reader["parkID"].ToString());

                channel.channelMode = (Command.ChannelMode)Enum.Parse(typeof(Command.ChannelMode), reader["channelMode"].ToString());
                channel.entranceCount = Convert.ToInt32(reader["entranceCount"].ToString());
                channel.entranceList = new  List<EntranceUnit>();

                channel.stationAddr = reader["stationAddr"].ToString();
                channel.cameraCount = Convert.ToInt32(reader["cameraCount"].ToString());
                channel.cameraList = new List<CameraStc>();
                foreach (CameraStc cam in cameraList)
                {
                    if (cam.channelID == channel.channelID)
                    {
                        channel.cameraList.Add(cam);
                    }
                }
                channelList.Add(channel);
            }

        }
        private void loadDBPark()
        {
            ParkUnit park ;
            OleDbDataReader reader = DataOperater.ParkUnitLoader_DO();
            while (reader.Read())
            {
                park = new ParkUnit();

                park.parkID = Convert.ToInt32(reader["ID"].ToString());

                park.parkName = reader["parkName"].ToString();
                park.parkChargeModeID = Convert.ToInt32(reader["parkChargeModeID"].ToString());
                park.parkChargeMode = mapChargeMode(park.parkChargeModeID);
                park.channelCount = Convert.ToInt32(reader["channelCount"].ToString());
                park.channelList = new List<ChannelUnit>();
                park.TimerList = new List<BGSTimerStr>();
                park.parkTotalSpace = Convert.ToInt32(reader["parkTotalSpace"].ToString());
                park.parkOccupiedSpace = Convert.ToInt32(reader["parkOccupiedSpace"].ToString());
                park.parkRemainSpace = Convert.ToInt32(reader["parkRemainSpace"].ToString());
                park.parkLevel = Convert.ToInt32(reader["parkLevel"].ToString());
                park.parkType = (ParkTypeEnum)Enum.Parse(typeof(ParkTypeEnum), reader["parkType"].ToString()); 


                parkList.Add(park);
            }
        }

        private void loadDBEntrance()
        {
            EntranceUnit entrance;

            OleDbDataReader reader = DataOperater.EntranceUnitLoader_DO();
            while (reader.Read())
            {
                entrance = new EntranceUnit();

                entrance.entranceID = Convert.ToInt32(reader["ID"].ToString());
                entrance.channelID = Convert.ToInt32(reader["channelID"].ToString());
                entrance.parkID = Convert.ToInt32(reader["parkID"].ToString());

                entrance.entranceName = reader["entranceName"].ToString();
                entrance.entranceMode = (EntranceModeEnum)Enum.Parse(typeof(EntranceModeEnum), reader["entranceMode"].ToString());
                entrance.entranceType = (EntranceTypeEnum)Enum.Parse(typeof(EntranceTypeEnum), reader["entranceType"].ToString());
                entrance.entranceSettingID = Convert.ToInt32(reader["entranceSettingID"].ToString());
                entrance.entranceSetting = mapSetting(entrance.entranceSettingID);

                entrance.rs485Addr = reader["rs485Addr"].ToString();
                entrance.tcpAddr = reader["tcpAddr"].ToString();

                entranceList.Add(entrance);
            }

        }
        private bool saveDBSetting(EntranceSettingStr newSet)
        {

            return DataOperater.SaveSetting_DO(newSet);
        }
        private bool saveDBChargeMode(ChargeModeStr newMode)
        {
                return DataOperater.SaveChargeMode_DO(newMode);
        }
        private bool saveDBChannelUnit(ChannelUnit nCh)
        {
            return DataOperater.SaveChannelUnit_DO(nCh);
        }
        private int addDBChannelUnit(ChannelUnit nCh)
        {
            return DataOperater.AddChannelUnit_DO(nCh);
        }
        private bool saveDBEntranceUnit(EntranceUnit nEn)
        {
            return DataOperater.SaveEntranceUnit_DO(nEn);
        }
        private int addDBEntranceUnit(EntranceUnit nEn)
        {
            return DataOperater.AddEntranceUnit_DO(nEn);
        }
        private int addDBParkUnit(ParkUnit nPa)
        {
            return DataOperater.AddParkUnit_DO(nPa);
        }
        private bool saveDBParkUnit(ParkUnit nPa)
        {
            return DataOperater.SaveParkUnit_DO(nPa);
        }
        /*************************************************

          Function:      mapChannel(int cID)
          
         * Description:     根据id在CHANNELLIST中查询相符的channel。
         * 
         * 
           Function:     mapEntrance(int eID,ChannelUnit cunit)
          
         * Description:     根据id和channel 查询相应的entrance
         * 
         * 
          Function:      mapSetting(int sID)
          
         * Description:     根据id在CHANNELLIST中查询相符的channel。
         * 
         * 
          Function:      mapChargeMode(int sID)
          
         * Description:     根据id在mapChargeModeList中查询相符的mapChargeMode。

        *************************************************/
        private ParkUnit mapPark(int cID)
        {

            foreach (ParkUnit cu in parkList)
                if (cu.parkID == cID) return cu;
            //warring:警告 不存在当前park
            return new ParkUnit();
        }
        private ChannelUnit mapChannel(int cID)
        {

            foreach (ChannelUnit cu in channelList)
                if (cu.channelID == cID) return cu;
            //warring:警告 不存在当前channel
            return new ChannelUnit();
        }

        private EntranceUnit mapEntrance(int eID)
        {

            foreach (EntranceUnit eunit in entranceList)
                if (eunit.entranceID == eID)
                    return eunit;
            //warring:警告 不存在当前entrance
            return new EntranceUnit();
        }
        private EntranceUnit mapEntrance(int cID,EntranceTypeEnum type)
        {

            foreach (EntranceUnit eunit in entranceList)
                if (eunit.channelID == cID && eunit .entranceType == type)
                    return eunit;
            //warring:警告 不存在当前entrance
            return new EntranceUnit();
        }
        private EntranceSettingStr mapSetting(int sID)
        {

            foreach (EntranceSettingStr setting in entrSettingList)
                if (setting.settingID == sID)
                    return setting;
            //warring:警告 不存在当前setting
            return new EntranceSettingStr();
        }

        private ChargeModeStr mapChargeMode(int cID)
        {
            foreach (ChargeModeStr mode in chargeModeList)
                if (mode.modeID == cID)
                    return mode;
            //warring:警告 不存在当前setting
            return new ChargeModeStr();
        }

        private CameraStc mapCameraStc(int camID)
        {
            foreach (CameraStc cam in cameraList)
            {
                if (cam.cameraID != camID) continue;
                return cam;
            }
            //warring:警告 不存在当前setting
            return new CameraStc();
        }
        private CameraStc mapCameraStc(int chanID,CameraStc.CameraType camType)
        {
            foreach (CameraStc cam in cameraList)
                if (cam.channelID == chanID && cam.cameraType == camType)
                {
                    return cam;
                }
            //warring:警告 不存在当前setting
            return new CameraStc();
        }
        /*************************************************

        Function:     GetCurrentBGSystemSetting（），， UpdateCurrentBGSystemSetting(BGSystemStr bgs)
         
        Description:    由外部调用，获取当前的BGS配置信息 或者将外部的配置信息写入到当前的配置信息
         
        Input:          
           
        Return:          

        *************************************************/
        public EntranceUnit GetCurrentEntrance(int entranceID)
        {
            return mapEntrance(entranceID);
        }
        public EntranceUnit GetCurrentEntrance(int channelID, EntranceTypeEnum type)
        {
            return mapEntrance(channelID,type);
        }
        public ChannelUnit GetCurrentChannel(int channelID)
        {
            return mapChannel(channelID);
        }
        public ParkUnit GetCurrentPark(int parkID)
        {
            return mapPark(parkID);
        }
        public EntranceSettingStr GetCurrentEntranceSetting(int settingID)
        {

            return mapSetting(settingID);
        }
        public ChargeModeStr GetCurrentChargeMode(int modeID)
        {
            return mapChargeMode(modeID);
        }
        public bool GetCurrentCameraStc(ref CameraStc cam)
        {
            if (cam.cameraID != 0)
                cam = mapCameraStc(cam.cameraID);
            else if (cam.channelID != 0)
                cam = mapCameraStc(cam.channelID, cam.cameraType);
            else return false;
            if (cam.cameraID == 0) return false;
            return true;
        }
        public int SetCurrentEntrance(EntranceUnit nEn)
        {
            if (nEn.entranceID == 0) return 0;

            for (int i = 0; i < entranceList.Count; i++)
            {
                if (entranceList[i].entranceID != nEn.entranceID) continue;
                
                    entranceList[i] = nEn;
                    saveDBEntranceUnit(nEn);
                    MessageStc mes = new MessageStc();
                    mes.type = MessageTypeEnum.DEVICE_UPDATE;
                    mes.park.selectedChannel.selectedEntrance = nEn;
                    if (updateDeviceMessageArrived != null)
                    {
                        updateDeviceMessageArrived(this, new MessageEventArgs(mes));
                    }
                    else
                    {
                        Console.WriteLine(DEBUG + "updateDeviceMessageArrived == null");   //*******************DEBUGGING*****************
                    }
                    return nEn.entranceID;
            }
            return 0;
            //  return saveDBEntranceUnit(entrance);

        }
        public int AddCurrentEntrance(EntranceUnit nEn)
        {
            foreach (EntranceUnit entr in entranceList)
            {
                if (entr.entranceID == 0) continue;

                if (nEn.entranceID == entr.entranceID) return 0;
            }
            nEn.entranceID = addDBEntranceUnit(nEn);
            entranceList.Add(nEn);
            MessageStc mes = new MessageStc();
            mes.type = MessageTypeEnum.DEVICE_ADD;
            mes.park.selectedChannel.selectedEntrance = nEn;
            if (addDeviceMessageArrived != null)
            {
                addDeviceMessageArrived(this, new MessageEventArgs(mes));
            }
            else
            {
                Console.WriteLine(DEBUG + "addDeviceMessageArrived == null");   //*******************DEBUGGING*****************
            }
            return nEn.entranceID;

        }

        public int SetCurrentCamera(CameraStc cam)
        {
            if (cam.cameraID == 0) return 0;

            for (int i = 0; i < cameraList.Count; i++)
            {
                if (cameraList[i].cameraID != cam.cameraID) continue;
                cameraList[i] = cam;
               DataOperater. SaveCameraUnit_DO(cam);
                return cam.cameraID;
            }
            return 0;
            //  return saveDBCameraUnit(camera);

        }
        public int AddCurrentCamera(ref CameraStc cam)
        {
            foreach (CameraStc camera in cameraList)
            {
                if (camera.cameraID == 0) continue;

                if (camera.cameraID == cam.cameraID) return 0;
            }
            DataOperater.AddCamera_DO(ref cam);
            cameraList.Add(cam);

            return cam.cameraID;

        }
        public int SetCurrentChannel(ChannelUnit nCh)
        {
            if (nCh.channelID == 0) return 0;

            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i].channelID != nCh.channelID) continue;
                    channelList[i] = nCh;
                    saveDBChannelUnit(nCh);
                    MessageStc mes = new MessageStc();
                    mes.type =MessageTypeEnum.CHANNEL_UPDATE;
                    mes.park.selectedChannel = nCh;
                    if (updateChannelMessageArrived != null)
                    {
                        updateChannelMessageArrived(this, new MessageEventArgs(mes));
                    }
                    return nCh.channelID;
            }
            return 0;

        }
        public int AddCurrentChannel(ChannelUnit nCh)
        {
            foreach (ChannelUnit chan in channelList)
            {
                if (chan.channelID == 0) continue;
                if (nCh.channelID == chan.channelID ) return 0;
            }
            nCh.channelID = addDBChannelUnit(nCh);
            channelList.Add(nCh);
            MessageStc mes = new MessageStc();
            mes.type = MessageTypeEnum.CHANNEL_ADD;
            mes.park.selectedChannel = nCh;
            if (addChannelMessageArrived != null)
            {
                addChannelMessageArrived(this, new MessageEventArgs(mes));
            }
            return nCh.channelID;
        }
        public int SetCurrentPark(ParkUnit nPa)
        {
            if (nPa.parkID == 0) return 0;

            for (int i = 0; i < parkList.Count; i++)
            {
                if (parkList[i].parkID != nPa.parkID) continue;
                parkList[i] = nPa;
                saveDBParkUnit(nPa);
                MessageStc mes = new MessageStc();
                mes.type = MessageTypeEnum.PARK_UPDATE;
                mes.park = nPa;
                if (updateParkMessageArrived != null)
                {
                    updateParkMessageArrived(this, new MessageEventArgs(mes));
                }
                return nPa.parkID;
            }
            return 0;
        }

        public int AddCurrentPark(ParkUnit nPa)
        {
            foreach (ParkUnit park in parkList)
            {
                if (park.parkID == 0) continue;

                if (nPa.parkID == park.parkID ) return 0;
            }
            nPa.parkID = addDBParkUnit(nPa);
            parkList.Add(nPa);
            MessageStc mes = new MessageStc();
            mes.type = MessageTypeEnum.PARK_ADD;
            mes.park = nPa;
            if (addParkMessageArrived != null)
            {
                addParkMessageArrived(this, new MessageEventArgs(mes));
            }
            return nPa.parkID;
        }
        public bool SetCurrentEntranceSetting(EntranceSettingStr setting)
        {
            for (int i = 0; i < entrSettingList.Count; i++)
            {
                if (entrSettingList[i].settingID != setting.settingID) continue;
                entrSettingList[i] = setting;
                return saveDBSetting(setting);
            }
            return false;
        }
        public bool SetCurrentChargeMode(ChargeModeStr mode)
        {
            for (int i = 0; i < chargeModeList.Count; i++)
            {
                if (chargeModeList[i].modeID != mode.modeID) continue;
                chargeModeList[i] = mode;
                return saveDBChargeMode(mode);
            }
            return false;
        }

        /*************************************************

         Function:     deploySetting()
         
         Description:    调用485向控制器部署控制信息
         
         Input:          
           
         Return:          

       *************************************************/
        private void deploySetting(MessageStc  mes)   
        {

            ParkUnit park = mes.park;
            EntranceUnit entr = park.selectedChannel.selectedEntrance;
            String str = "";
            if (SMode == Command.SoftMode.单主机)
            {

                if (park.parkChargeMode.enableMFCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableLSCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableCZCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableYCard)
                {
                    str += "1";
                }
                else str += "0";

                if (park.parkChargeMode.enableRCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableTQCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableSQCard)
                {
                    str += "1";
                }
                else str += "0";
                if (park.parkChargeMode.enableYGCard)
                {
                    str += "1";
                }
                else str += "0";


                if (entr.entranceSetting.enableBGS)
                {
                    str += "1";
                    if (entr.entranceSetting.enableBGSRpeat)
                    {
                        str += "1";
                    }
                    else str += "0";
                }
                else str += "00";


                if (entr.entranceSetting.enableBGOn)
                {
                    str += "1";
                }
                else str += "0";
               
                if (entr.entranceSetting.enableBGOnUp < 4)      //2-7
	            {
                    str += "0";
                    str += Convert.ToString(entr.entranceSetting.enableBGOnUp,2);
	            }
                else str += Convert.ToString(entr.entranceSetting.enableBGOnUp, 2);
             
                if (entr.entranceSetting.enableBGOff)
                {
                    str += "1";
                }
                else str += "0";

                if (entr.entranceSetting.enableBGOffDelay < 4) // 5-10
                {
                    str += "0";
                    str += Convert.ToString(entr.entranceSetting.enableBGOffDelay, 2);
                }
                else str += Convert.ToString(entr.entranceSetting.enableBGOffDelay, 2);

                if (entr.entranceSetting.enableBGManual)
                {
                    str += "1";
                }
                else str += "0";
                if (entr.entranceSetting.enableCReader)
                {
                    str += "1";
                    if (entr.entranceSetting.enableCReaderB)
                    {
                        str += "1";
                    }
                    str += "0";
                    if (entr.entranceSetting.enableCReaderI)
                    {
                        str += "1";
                    }
                    str += "0";
                }
                else str += "000";

                if (entr.entranceSetting.enableCSender)
                {
                    str += "10";
                }
                else str += "00";
                if (entr.entranceSetting.enableDG1)
                {
                    str += "1";
                    if (entr.entranceSetting.enableDG1P)
                    {
                        str += "1";
                    }
                    else str += "0";

                }
                else str += "00";
                if (entr.entranceSetting.enableDG2)
                {
                    str += "1";
                    if (entr.entranceSetting.enableDG2P)
                    {
                        str += "1";
                    }
                    else str += "0";

                }
                else str += "00";
                if (entr.entranceSetting.enableLED)
                {
                    str += "10";
                }
                else str += "00";
                if (entr.entranceSetting.enableVoice)
                {
                    str += "10";
                }
                else str += "00";
                mes.info = str;
                msgOpt.sendConfData485(mes);
                System.Threading.Thread.Sleep(200);
            }
            else if (SMode == Command.SoftMode.主机)
            {
                msgOpt.sendDataTCP(mes);
            }

            //  msgOpt.sendConfData485(curEUnit, str);
        }

        public void DeployNewCard(MessageStc mes) 
        {

            if (SMode == Command.SoftMode.单主机 )
            {
                foreach (EntranceUnit eu in entranceList)
                {
                    if (eu.parkID == mes.park.parkID)
                    {
                        mes.park.selectedChannel.selectedEntrance = eu;
                        msgOpt.sendNewCardData485(mes);
                        System.Threading.Thread.Sleep(200);
                    }
                }
            }
            else if (SMode == Command.SoftMode.主机)
            {
                foreach (EntranceUnit eu in entranceList)
                {
                    if (eu.parkID == mes.park.parkID)
                    {
                        mes.park.selectedChannel.selectedEntrance = eu;
                        mes.ip = eu.tcpAddr;
                        msgOpt.sendDataTCP(mes);
                    }
                }
            }
        }
        public void DeployVacancy(MessageStc mes)
        {
            mes.info = mes.park.parkRemainSpace.ToString();
            mes.type = MessageTypeEnum.VACANCY;
            if (SMode == Command.SoftMode.单主机)
            {
                foreach (EntranceUnit eu in entranceList)
                {
                    if (eu.parkID == mes.park.parkID)
                    {
                        mes.park.selectedChannel.selectedEntrance = eu;
                        System.Threading.Thread.Sleep(500);

                        msgOpt.sendVacancy(mes);
                    }
                }
            }
            else if (SMode == Command.SoftMode.主机)
            {
                foreach (EntranceUnit eu in entranceList)
                {
                    if (eu.parkID == mes.park.parkID)
                    {
                        mes.park.selectedChannel.selectedEntrance = eu;
                        mes.ip = eu.tcpAddr;
                        msgOpt.sendDataTCP(mes);
                    }
                }
                foreach (ChannelUnit chan in channelList)
                {
                    if (chan.parkID == mes.park.parkID)
                    {
                        mes.park.selectedChannel = chan;
                        mes.ip = chan.stationAddr;
                        msgOpt.sendDataTCP(mes);

                    }
                }
            }

        }
        public void DeployTest(MessageStc mes)
        {
            if (SMode == Command.SoftMode.单主机 )
            {
                msgOpt.sendTestData485(mes);
                System.Threading.Thread.Sleep(200);
            }
            else if (SMode == Command.SoftMode.主机)
            {
                msgOpt.sendDataTCP(mes);
            }
            else if (SMode == Command.SoftMode.从机)
            {
                mes.ip = ServerAddr;
                msgOpt.sendDataTCP(mes);
            }
        }

        public void DeployLED( MessageStc mes)
        {
           
            msgOpt.sendReSetLED(mes);

        }
        /*************************************************

         Function:     deploySetting()
         
         Description:    调用485向控制器部署控制信息
         
         Input:          
           
         Return:          

       *************************************************/
        public void ShowEntranceStasus(MessageStc mes)
        {
            if (entranceStatusMessageArrived != null)
            {
                mes.info = mes.park.selectedChannel.selectedEntrance.entranceStatus.statusBGS.ToString();
                entranceStatusMessageArrived(this, new MessageEventArgs(mes));
            }
            else
            {
                Console.WriteLine(DEBUG + "entranceStatusMessageArrived == null");   //*******************DEBUGGING*****************
            }
        }
        public void ShowChannelStasus(MessageStc mes)
        {
            if (channelStatusMessageArrived != null)
            {
                mes.info = mes.park.selectedChannel.channelStatus.ToString();
                channelStatusMessageArrived(this, new MessageEventArgs(mes));
            }
            else
            {
                Console.WriteLine(DEBUG + "channelStatusMessageArrived == null");   //*******************DEBUGGING*****************
            }
        }
        /*************************************************

         Function:     UpdateEntranceSetting(int channelID, int entranceID, int settingID)
         
         Description:   由界面管理类调用,将settingID的相关具体setting参数赋给指定的entrance
         
         Input:       channelID 通道ID   entranceID 出入口ID  settingID赋给entrance的settingID
           
         Return:    bool 是否成功    
         * 
         * 
         Function:     UpdateChannelChargeMode(int channelID, int modeID)
         
         Description:   由界面管理类调用,将modeID的相关具体chargeMode参数赋给指定的channel
         
         Input:       channelID 通道ID   modeID赋给channel的chargeModeID
           
         Return:    bool 是否成功  

       *************************************************/
        public bool UpdateEntranceSetting(int entrID , int settingID)
        {
            EntranceUnit curEUnit = GetCurrentEntrance(entrID);
            curEUnit.entranceSettingID = settingID;
            curEUnit.entranceSetting = mapSetting(settingID);       //根据settingID在settingList中匹配setting并赋予当前操作的Entrance
            SetCurrentEntrance(curEUnit);           //更新数据库中的当前entrance信息.

            MessageStc mes = new MessageStc();
            mes.park = GetCurrentPark(curEUnit.parkID);
            mes.park.parkChargeMode = GetCurrentChargeMode(mes.park.parkChargeModeID);
            mes.park.selectedChannel.selectedEntrance = curEUnit;
            mes.type = MessageTypeEnum.DEVICE_SETTING;
            mes.ip = curEUnit.tcpAddr;
            deploySetting(mes);

            return true;
        }

        public bool UpdateParkChargeMode(int parkID, int modeID)
        {
            ParkUnit park = GetCurrentPark(parkID);
            park.parkChargeModeID = modeID;
            park.parkChargeMode = GetCurrentChargeMode(modeID);
            MessageStc mes = new MessageStc();
            mes.park = park;

            foreach (ChannelUnit chan in channelList)
            {
                if (chan.parkID != park.parkID) continue;
                mes.type = MessageTypeEnum.CHANNEL_UPDATE;
                mes.park.selectedChannel = chan;
                mes.ip = chan.stationAddr;
                msgOpt.sendDataTCP(mes);
            }

            foreach (EntranceUnit entr in entranceList )
            {
                if (entr.parkID != park.parkID) continue;
                mes.type = MessageTypeEnum.DEVICE_SETTING;
                mes.park.selectedChannel.selectedEntrance = entr;
                mes.ip = entr.tcpAddr;
                deploySetting(mes);
            }

            SetCurrentPark(park);         
            return true;
                
        }

        /*************************************************

         Function:     DeviceMessageHandler(object sender, MessageEventArgs e)
         
         Description:   tcp,rs485在收到数据后的委托任务处理方法.
         
     

       *************************************************/

        public void bgsTimerAdd(Command.TimerType type, int id, BGSTimerStr timer)
        {
            if (type == Command.TimerType.PARK)
            {
                ParkUnit park = GetCurrentPark(id);
                if (park.TimerList == null)
                {
                    park.TimerList = new List<BGSTimerStr>();
                }
                park.TimerList.Add(timerOpt.TimerAdd(timer));
                SetCurrentPark(park);
            }
            else
            {
                EntranceUnit entr = GetCurrentEntrance(id);
                if (entr.TimerList == null)
                {
                    entr.TimerList = new List<BGSTimerStr>();
                }
                entr.TimerList.Add(timerOpt.TimerAdd(timer));
                SetCurrentEntrance(entr);
            }
        }

        public void bgsTimerDelete(Command.TimerType type, int id, int timerNum)
        {
            if (type == Command.TimerType.PARK)
            {
                ParkUnit park = GetCurrentPark(id);
                if (park.TimerList != null)
                {
                    timerOpt.TimerDelete(timerNum);
                    park.TimerList.RemoveAt(timerNum);
                    SetCurrentPark(park);
                }
            }
            else
            {
                EntranceUnit entr = GetCurrentEntrance(id);
                if (entr.TimerList != null)
                {
                    timerOpt.TimerDelete(timerNum);
                    entr.TimerList.RemoveAt(timerNum);
                    SetCurrentEntrance(entr);
                }

            }
        }
        public void bgsTimerClear(Command.TimerType type, int id)
        {
            if (type == Command.TimerType.PARK)
            {
                ParkUnit park = GetCurrentPark(id);
                if (park.TimerList != null)
                {
                    timerOpt.ParkTimerClear(id);
                    park.TimerList.Clear();
                    SetCurrentPark(park);
                }
            }
            else
            {
                EntranceUnit entr = GetCurrentEntrance(id);
                if (entr.TimerList != null)
                {
                    timerOpt.EntranceTimerClear(id);
                    entr.TimerList.Clear();
                    SetCurrentEntrance(entr);
                }

            }
        }


        /*************************************************

         Function:     DeviceMessageHandler(object sender, MessageEventArgs e)
         
         Description:   tcp,rs485在收到数据后的委托任务处理方法.
         
     

       *************************************************/
        public void Rs485PortSetter(string port)
        {
            Rs485Port = port;
            if (Rs485Port != String.Empty)
            {
                msgOpt.SetComPort(port, 9600);
            }
            else
            {
                Console.WriteLine(DEBUG + "Rs485PortSetter()  port  == null");   //*******************DEBUGGING*****************

            }
        }
        private void timerMessageHandler(object sender, MessageEventArgs e)
        {
            BGSTimerStr timer = e.BGSTimer;

            if (timer.ParkID != 0)
            {
                int chargeModeID = e.IsStart ? timer.ChargeModeID : timer.AfterChargeModeID;
                UpdateParkChargeMode(timer.ParkID, chargeModeID);
            }
            else if (timer.EntranceID != 0)
            {
                int settingID = e.IsStart ? timer.EntranceSettingID : timer.AfterEntranceSettingID;
                UpdateEntranceSetting( timer.EntranceID, settingID);
            }

        }
        private void parkVacancyUpdater(ref ParkUnit park , MessageTypeEnum type)
        {
            if (type == MessageTypeEnum.INCARD)
            {
                park.parkRemainSpace--;
                if (park.parkRemainSpace < 0) park.parkRemainSpace = 0;
                park.parkOccupiedSpace++;
                if (park.parkOccupiedSpace > park.parkTotalSpace) park.parkOccupiedSpace = park.parkTotalSpace;
            }
            else if (type == MessageTypeEnum.OUTCARD)
            {
                park.parkOccupiedSpace--;
                if (park.parkOccupiedSpace < 0) park.parkOccupiedSpace = 0;
                park.parkRemainSpace++;
                if (park.parkRemainSpace > park.parkTotalSpace) park.parkRemainSpace = park.parkTotalSpace;
            }
            SetCurrentPark(park);
            //临时
            this.TotalSpace = park.parkTotalSpace;
            this.OccupiedSpace = park.parkOccupiedSpace;
            this.RemainSpace = park.parkRemainSpace;
        }
        private void deviceCommandMessageHandler(object sender, MessageEventArgs e)
        {
            BGSControl(e.Mes);
        }
        private void deviceSettingMessageHandler(object sender, MessageEventArgs e)
        {
            deploySetting(e.Mes);
        }
        private void newCardMessageHandler(object sender, MessageEventArgs e)
        {
            DeployNewCard(e.Mes);
        }
        private void vacancyMessageHandler(object sender, MessageEventArgs e)
        {
            DeployVacancy(e.Mes);
        }
        private void channelMessageHandler(object sender, MessageEventArgs e)
        {
            ChannelUnit chan = e.Mes.park.selectedChannel;
            MessageStc mes = e.Mes;
            if (SMode != Command.SoftMode.主机) return;
            
                switch (mes.type)
                {
                    case MessageTypeEnum.CHANNEL_APPLY:
                        for (int i = 0; i < channelList.Count; i++)
                        {
                            if (channelList[i].stationAddr != chan.stationAddr || String.IsNullOrEmpty(chan.stationAddr)) continue;
                                chan = channelList[i];
                                chan.channelStatus = Command.BGSstatus.测试通过;
                                channelList[i] = chan;
                                foreach (EntranceUnit  entr in entranceList)
                                {
                                    if (entr.parkID == chan.parkID && entr.channelID == chan.channelID)
                                    {
                                        chan.entranceList.Add(entr);
                                    }
                                }
                                foreach (CameraStc cam in cameraList)
                                {
                                    if (cam.parkID == chan.parkID && cam.channelID == chan.channelID)
                                    {
                                        chan.cameraList.Add(cam);
                                    }
                                }
                                mes.park = GetCurrentPark(chan.parkID);
                                mes.park.selectedChannel = chan;
                                mes.ip = chan.stationAddr;
                                msgOpt.sendDataTCP(mes);
                                break;
                        }
                        break;

                    case MessageTypeEnum.CHANNEL_TEST:
                        for (int i = 0; i < channelList.Count; i++)
                        {
                            if (channelList[i].stationAddr != chan.stationAddr || String.IsNullOrEmpty(chan.stationAddr)) continue;
                            chan = channelList[i];
                            chan.channelStatus = Command.BGSstatus.测试通过;
                            channelList[i] = chan;
                            mes.park.selectedChannel = chan;
                            ShowChannelStasus(mes);
                            break;
                        }
                        break;
                    case MessageTypeEnum.CHANNEL_GATECOMM:
                        mes.ip = mes.park.selectedChannel.selectedEntrance.tcpAddr;
                        BGSControl(mes);
                        break;
                    case MessageTypeEnum.CHANNEL_GATESETTING:
                        mes.ip = mes.park.selectedChannel.selectedEntrance.tcpAddr;
                        UpdateEntranceSetting(mes.park.selectedChannel.selectedEntrance.entranceID,
                            mes.park.selectedChannel.selectedEntrance.entranceSettingID);
                        break;
                    default:
                        break;
                }

        }



        private void deviceMessageHandler(object sender, MessageEventArgs e)
        {
            MessageStc mes = e.Mes;
            EntranceUnit curEntr = mes.park.selectedChannel.selectedEntrance ;
            EntranceUnit entrTemp = new EntranceUnit();

            if (curEntr.entranceMode == EntranceModeEnum.RS485)
            {
                foreach (EntranceUnit entr in entranceList)
                {
                    if (curEntr.rs485Addr != entr.rs485Addr) continue;
                    entrTemp = entr;
                    break;
                }
            }
            else if (curEntr.entranceMode == EntranceModeEnum.TCP)
            {
                foreach (EntranceUnit entr in entranceList)
                {
                    if (curEntr.tcpAddr != entr.tcpAddr) continue;
                    entrTemp = entr;
                    break;

                }
            }
            if (entrTemp.entranceID == 0) return;
            if (mes.type == MessageTypeEnum.INCARD)
            {
                if (entrTemp.entranceType == EntranceTypeEnum.入库控制器)
                    mes.type = MessageTypeEnum.INCARD;
                else if (entrTemp.entranceType == EntranceTypeEnum.出库控制器)
                    mes.type = MessageTypeEnum.OUTCARD;
            }

            mes.park = GetCurrentPark(entrTemp.parkID);
            mes.park.selectedChannel = GetCurrentChannel(entrTemp.channelID);

                switch (mes.type)
                {
                    case MessageTypeEnum.INCARD:
                            
                            mes.park.selectedChannel.selectedEntrance = entrTemp;
                            mes.park.parkChargeMode = GetCurrentChargeMode(mes.park.parkChargeModeID);
                            cOpt.SetCurrentCard(ref mes);
                            if (String.IsNullOrEmpty(mes.card.CardID)) return;
                           // SetCurrentEntrance(curEntr);
                            if (SMode == Command.SoftMode.单主机)
                             msgOpt.SendACKData485(mes);
                            else if (SMode == Command.SoftMode.主机)
                            {
                                mes.ip = entrTemp.tcpAddr;
                                msgOpt.sendDataTCP(mes);
                            }
                            parkVacancyUpdater(ref mes.park,mes.type);
                            if (cardPassMessageArrived != null)
                                cardPassMessageArrived(this, new MessageEventArgs(mes));
                            else
                                Console.WriteLine(DEBUG + "cardPassMessageArrived == null");   //*******************DEBUGGING*****************
                            DeployVacancy(mes);

                            Console.WriteLine(DEBUG + "deviceMessageHandler() this card " + mes.card.ValidFlag.ToString());   //*******************DEBUGGING*****************                                    }
                        return;
                    case MessageTypeEnum.OUTCARD :

                        mes.park.selectedChannel.selectedEntrance = entrTemp;
                        mes.park.parkChargeMode = GetCurrentChargeMode(mes.park.parkChargeModeID);
                        cOpt.SetCurrentCard(ref mes);
                        if (String.IsNullOrEmpty(mes.card.CardID)) return;
                        // SetCurrentEntrance(curEntr);
                        if (SMode == Command.SoftMode.单主机)
                            msgOpt.SendACKData485(mes);
                        else if (SMode == Command.SoftMode.主机)
                        {
                            mes.ip = entrTemp.tcpAddr;
                            msgOpt.sendDataTCP(mes);
                        }
                            parkVacancyUpdater(ref mes.park,mes.type);
                            if (cardPassMessageArrived != null)
                                cardPassMessageArrived(this, new MessageEventArgs(mes));
                            else
                                Console.WriteLine(DEBUG + "cardPassMessageArrived == null");   //*******************DEBUGGING*****************
                            DeployVacancy(mes);

                        Console.WriteLine(DEBUG + "deviceMessageHandler() this card " + mes.card.ValidFlag.ToString());   //*******************DEBUGGING*****************                                    }
                        return;

                    case MessageTypeEnum.STATUS:
                        entrTemp.entranceStatus = curEntr.entranceStatus;
                        SetCurrentEntrance(entrTemp);
                        mes.park.selectedChannel.selectedEntrance = entrTemp;
                        ShowEntranceStasus(mes);
                            Console.WriteLine(DEBUG + "deviceMessageHandler() this entr " +  curEntr.entranceStatus.ToString());   //*******************DEBUGGING*****************                                    }

                        return;
                    case MessageTypeEnum.DEVICE_TEST:
                        entrTemp.entranceStatus.statusBGS = Command.BGSstatus.测试通过;
                        SetCurrentEntrance(entrTemp);
                        mes.park.selectedChannel.selectedEntrance = entrTemp;
                        ShowEntranceStasus(mes);
                        Console.WriteLine(DEBUG + "deviceMessageHandler() this entr " + curEntr.entranceStatus.ToString());   //*******************DEBUGGING*****************                                    }

                        return;
                    case MessageTypeEnum.NEWCARD:


                            cOpt.AddCard(curEntr.selectedCard);
                        
                        return;
                    default:
                        return;
                }

        }

        public OleDbDataReader HistoryLoader()
        {
            return DataOperater.HistoryLoader_DO();
        }
        public void LinkClosing()
        {
            msgOpt.LinkClosing();

        }
        //TEST
        public void test(EntranceUnit entr)
        {
          //  msgOpt.forwardMessage(entr);
        }


    }
}