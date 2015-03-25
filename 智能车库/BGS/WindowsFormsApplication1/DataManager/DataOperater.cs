
/** 
* 文 件 名 : DataOperater
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* 文件编号：002 
* 创 建 人：Haden.W 
* 日    期：2014.8.20
* 修 改 人： 
* 日   期： 
* 描   述：  数据库操作逻辑类
* 版 本 号：0.1
*/
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Cheku.BGSystem;
using Cheku.Types;

namespace Cheku.DataManager
{
    class DataOperater
    {
        private static readonly String tbUser = "dbUser"; //管理用户表
        private static readonly String tbCard = "dbCard";//卡片信息表
        private static readonly String tbVehicle = "dbVehicle";//历史记录表
        private static readonly String tbConfigMode = "dbConfigMode";//配置记录表
        private static readonly String tbChargeMode = "dbChargeMode";//计费模式记录表
        private static readonly String tbChannelUnit = "dbChannelUnit";//通道记录表
        private static readonly String tbEntranceUnit = "dbEntranceUnit";//出入口记录表
        private static readonly String tbCamera = "dbCamera";//出入口记录表
        private static readonly String tbParkUnit = "dbParkUnit";//车场记录表
        private static readonly string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataBase\dbBGS.accdb";
        //OleDbConnection conn;
        public DataOperater() 
        {
            dbConnection();
        }

        private void dbConnection(){
            
            string strDPath = Application.StartupPath;
                //
                 
                
          //  conn = new OleDbConnection(strDataSource);
        }
        /**************************************************************************************************************

       Function:      VerifyUser_DO (String name, String pwd)
         
       Description:   登录时验证用户信息
         
       Input:         name 用户名，pwd 密码
           
       Return:         bool 成功标志

       **************************************************************************************************************/
        public static bool  VerifyUser_DO (String name, String pwd)
        {


            string strSql = "select * from " +tbUser+ " where userName=@name and userPwd=@pwd";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@name",OleDbType.Char),new OleDbParameter("@pwd",OleDbType.Char)
            };
            parms[0].Value = name;
            parms[1].Value = pwd;
            OleDbDataReader reader=AccessHelper.ExecuteReader(connStr, strSql, parms);
            return reader.HasRows;
        

        }



        /**************************************************************************************************************

       Function:       ParkUnitLoader_DO()
         
       Description:   载入所有通道
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader ParkUnitLoader_DO()
        {

            string strSql = "select * from " + tbParkUnit;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }


        public static OleDbDataReader SelectParkUnit_DO(int id)
        {

            string strSql = "select * from " + tbParkUnit + " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ID",OleDbType.Integer)
            };
            parms[0].Value = id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }
        public static OleDbDataReader SelectParkUnit_DO(string name)
        {

            string strSql = "select * from " + tbParkUnit + " where parkName=@parkName";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@parkName",OleDbType.Char)
            };
            parms[0].Value = name == null ? "" : name;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }

        public static bool SaveParkUnit_DO(ParkUnit parkUnit)
        {

            string strSql = "update " + tbParkUnit +

                " set  parkName=@parkName " +
                ", parkChargeModeID=@parkChargeModeID " +
                ", channelCount= @channelCount " +
                ", parkTotalSpace= @parkTotalSpace " +
                ", parkOccupiedSpace= @parkOccupiedSpace " +
                ", parkRemainSpace= @parkRemainSpace " +
                ", parkLevel= @parkLevel " +
                ", parkType= @parkType " +

                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@parkName",OleDbType.Char), 
                new OleDbParameter("@parkChargeModeID",OleDbType.Integer), 
                new OleDbParameter("@channelCount",OleDbType.Integer), 
                new OleDbParameter("@parkTotalSpace",OleDbType.Integer), 
                new OleDbParameter("@parkOccupiedSpace",OleDbType.Integer), 
                new OleDbParameter("@parkRemainSpace",OleDbType.Integer), 
                new OleDbParameter("@parkLevel",OleDbType.Integer), 
                new OleDbParameter("@parkType",OleDbType.Char), 

                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = parkUnit.parkName == null ? "" : parkUnit.parkName;
            //parms[1].Value = parkUnit.parkMode.ToString() == null ? "" : parkUnit.parkMode.ToString();
            parms[1].Value = parkUnit.parkChargeModeID;
            parms[2].Value = parkUnit.channelCount;
            parms[3].Value = parkUnit.parkTotalSpace;
            parms[4].Value = parkUnit.parkOccupiedSpace;
            parms[5].Value = parkUnit.parkRemainSpace;
            parms[6].Value = parkUnit.parkLevel;
            parms[7].Value = parkUnit.parkType.ToString() ;

            parms[8].Value = parkUnit.parkID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }


        public static int AddParkUnit_DO(ParkUnit parkUnit)
        {
            int id = 0;

            string strSql = "insert into " + tbParkUnit +
         "(parkName,parkMode,parkChargeModeID,channelCount,parkTotalSpace,parkOccupiedSpace,parkRemainSpace,parkLevel,parkType) " +
         " values(@parkName,@parkMode,@parkChargeModeID,@channelCount,@parkTotalSpace,@parkOccupiedSpace,@parkRemainSpace,@parkLevel,@parkType)";


            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@parkName",OleDbType.Char), 
                new OleDbParameter("@parkMode",OleDbType.Char),  
                new OleDbParameter("@parkChargeModeID",OleDbType.Integer), 
                new OleDbParameter("@channelCount",OleDbType.Integer), 
                new OleDbParameter("@parkTotalSpace",OleDbType.Integer), 
                new OleDbParameter("@parkOccupiedSpace",OleDbType.Integer), 
                new OleDbParameter("@parkRemainSpace",OleDbType.Integer), 
                new OleDbParameter("@parkLevel",OleDbType.Integer), 
                new OleDbParameter("@parkType",OleDbType.Char), 

             };

            parms[0].Value = parkUnit.parkName == null ? "" : parkUnit.parkName;
            //parms[1].Value = parkUnit.parkMode.ToString() == null ? "" : parkUnit.parkMode.ToString();
            parms[1].Value = parkUnit.parkChargeModeID;
            parms[2].Value = parkUnit.channelCount;
            parms[3].Value = parkUnit.parkTotalSpace;
            parms[4].Value = parkUnit.parkOccupiedSpace;
            parms[5].Value = parkUnit.parkRemainSpace;
            parms[6].Value = parkUnit.parkLevel;
            parms[7].Value = parkUnit.parkType.ToString();

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            OleDbDataReader reader = SelectParkUnit_DO(parkUnit.parkName);
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["ID"].ToString());

            }

            return id;
        }

        public static bool DeleteParkUnit_DO(int id)
        {


            string strSql = "delete from " + tbParkUnit + " where parkID=@parkID ";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@parkID",OleDbType.Integer)
            };
            parms[0].Value = id;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            return true;
        }


        /**********************************************************************************************

       Function:       ChannelUnitLoader_DO()
         
       Description:   载入所有通道
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       ***********************************************************************************************/
        public static OleDbDataReader ChannelUnitLoader_DO()
        {

            string strSql = "select * from " + tbChannelUnit;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }

        public static OleDbDataReader SelectChannelUnit_DO(int id)
        {

            string strSql = "select * from " + tbChannelUnit + " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ID",OleDbType.Integer)
            };
            parms[0].Value = id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }
        public static OleDbDataReader SelectChannelUnit_DO(string name)
        {

            string strSql = "select * from " + tbChannelUnit + " where channelName=@channelName";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@channelName",OleDbType.Char)
            };
            parms[0].Value = name == null ? "" : name;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }

        public static bool SaveChannelUnit_DO(ChannelUnit channelUnit)
        {

            string strSql = "update " + tbChannelUnit +

                " set  channelName=@channelName " +
                ", parkID= @parkID " +
                ", channelMode=@channelMode  " +
                ", entranceCount= @entranceCount " +
                ", stationAddr = @stationAddr " +
                ", cameraCount= @cameraCount " +
                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@channelName",OleDbType.Char),
                new OleDbParameter("@parkID",OleDbType.Integer), 
                new OleDbParameter("@channelMode",OleDbType.Char),  
                new OleDbParameter("@entranceCount",OleDbType.Integer), 
                new OleDbParameter("@stationAddr",OleDbType.Char), 
                new OleDbParameter("@cameraCount",OleDbType.Integer), 
                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = channelUnit.channelName == null ? "" : channelUnit.channelName;
            parms[1].Value = channelUnit.parkID ;
            parms[2].Value = channelUnit.channelMode.ToString() == null ? "" : channelUnit.channelMode.ToString();
            parms[3].Value = channelUnit.entranceCount;
            parms[4].Value = channelUnit.stationAddr == null ? "" : channelUnit.stationAddr;
            parms[5].Value = channelUnit.cameraCount;
            parms[6].Value = channelUnit.channelID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }


        public static int AddChannelUnit_DO(ChannelUnit channelUnit)
        {
            int id = 0;

            string strSql = "insert into " + tbChannelUnit +
         "(channelName,parkID,channelMode,entranceCount,stationAddr,cameraCount) " +
         " values(@channelName,@parkID,@channelMode,@entranceCount,@stationAddr,@cameraCount)";


            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@channelName",OleDbType.Char), 
                new OleDbParameter("@parkID",OleDbType.Integer),  
                new OleDbParameter("@channelMode",OleDbType.Char),  
                new OleDbParameter("@entranceCount",OleDbType.Integer), 
                new OleDbParameter("@stationAddr",OleDbType.Char), 
                new OleDbParameter("@cameraCount",OleDbType.Integer), 
            };
            parms[0].Value = channelUnit.channelName == null ? "" : channelUnit.channelName;
            parms[1].Value = channelUnit.parkID;
            parms[2].Value = channelUnit.channelMode.ToString() == null ? "" : channelUnit.channelMode.ToString();
            parms[3].Value = channelUnit.entranceCount;
            parms[4].Value = channelUnit.stationAddr == null ? "" : channelUnit.stationAddr;
            parms[5].Value = channelUnit.cameraCount;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            OleDbDataReader reader = SelectChannelUnit_DO(channelUnit.channelName);
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["ID"].ToString());

            }

            return id;
        }

        public static bool DeleteChannelUnit_DO(int id)
        {


            string strSql = "delete from " + tbChannelUnit + " where channelID=@channelID ";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@channelID",OleDbType.Integer)
            };
            parms[0].Value = id;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            return true;
        }



        /**************************************************************************************************************

       Function:       EntranceUnitLoader_DO()
         
       Description:   载入所有出入口
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader EntranceUnitLoader_DO()
        {

            string strSql = "select * from " + tbEntranceUnit;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }


        public static OleDbDataReader SelectEntranceUnit_DO(int id)
        {

            string strSql = "select * from " + tbEntranceUnit + " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ID",OleDbType.Integer)
            };
            parms[0].Value = id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }
        public static OleDbDataReader SelectEntranceUnit_DO(string name)
        {

            string strSql = "select * from " + tbEntranceUnit + " where entranceName=@entranceName";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@entranceName",OleDbType.Char)
            };
            parms[0].Value = name == null ? "" : name;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }

        public static bool SaveEntranceUnit_DO(EntranceUnit entranceUnit)
        {

            string strSql = "update " + tbEntranceUnit +

                " set  entranceName=@entranceName " +
                ", entranceMode=@entranceMode  " +
                ", entranceType=@entranceType " +
                ", entranceSettingID= @entranceSettingID " +
                ", rs485Addr= @rs485Addr " +
                ", tcpAddr = @tcpAddr " +
                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@entranceName",OleDbType.Char), 
                new OleDbParameter("@entranceMode",OleDbType.Char),  
                new OleDbParameter("@entranceType",OleDbType.Char), 
                new OleDbParameter("@entranceSettingID",OleDbType.Char), 
                new OleDbParameter("@rs485Addr",OleDbType.Char), 
                new OleDbParameter("@tcpAddr",OleDbType.Char), 
                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = entranceUnit.entranceName == null ? "" : entranceUnit.entranceName;
            parms[1].Value = entranceUnit.entranceMode.ToString() == null ? "" : entranceUnit.entranceMode.ToString();
            parms[2].Value = entranceUnit.entranceType.ToString() == null ? "" : entranceUnit.entranceType.ToString();
            parms[3].Value = entranceUnit.entranceSettingID.ToString() == null ? "" : entranceUnit.entranceSettingID.ToString();
            parms[4].Value = entranceUnit.rs485Addr == null ? "" : entranceUnit.rs485Addr;
            parms[5].Value = entranceUnit.tcpAddr == null ? "" : entranceUnit.tcpAddr;
            parms[6].Value = entranceUnit.entranceID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }



        public static int AddEntranceUnit_DO(EntranceUnit entranceUnit)
        {
            int id = 0;

            string strSql = "insert into " + tbEntranceUnit +
         "(entranceName,entranceMode,entranceType,entranceSettingID,rs485Addr,tcpAddr,channelID,parkID) " +
         " values(@entranceName,@entranceMode,@entranceType,@entranceSettingID,@rs485Addr,@tcpAddr,@channelID,@parkID)";


            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@entranceName",OleDbType.Char), 
                new OleDbParameter("@entranceMode",OleDbType.Char),  
                new OleDbParameter("@entranceType",OleDbType.Char), 
                new OleDbParameter("@entranceSettingID",OleDbType.Char), 
                new OleDbParameter("@rs485Addr",OleDbType.Char), 
                new OleDbParameter("@tcpAddr",OleDbType.Char), 
               new OleDbParameter("@channelID",OleDbType.Integer), 
               new OleDbParameter("@parkID",OleDbType.Integer), 
            };

            parms[0].Value = entranceUnit.entranceName == null ? "" : entranceUnit.entranceName;
            parms[1].Value = entranceUnit.entranceMode.ToString() == null ? "" : entranceUnit.entranceMode.ToString();
            parms[2].Value = entranceUnit.entranceType.ToString() == null ? "" : entranceUnit.entranceType.ToString();
            parms[3].Value = entranceUnit.entranceSettingID.ToString() == null ? "" : entranceUnit.entranceSettingID.ToString();
            parms[4].Value = entranceUnit.rs485Addr == null ? "" : entranceUnit.rs485Addr;
            parms[5].Value = entranceUnit.tcpAddr == null ? "" : entranceUnit.tcpAddr;
            parms[6].Value = entranceUnit.channelID;
            parms[7].Value = entranceUnit.parkID;


            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            OleDbDataReader reader = SelectEntranceUnit_DO(entranceUnit.entranceName);
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["ID"].ToString());

            }

            return id;
        }

        public static bool DeleteEntranceUnit_DO(int id)
        {


            string strSql = "delete from " + tbEntranceUnit + " where entranceID=@entranceID ";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@entranceID",OleDbType.Integer)
            };
            parms[0].Value = id;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            return true;
        }

        /**************************************************************************************************************

       Function:       CameraLoader_DO()
         
       Description:   载入所有出入口
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader CameraLoader_DO()
        {

            string strSql = "select * from " + tbCamera;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }

        public static bool AddCamera_DO(ref CameraStc camera)
        {

            string strSql = "insert into " + tbCamera +
         "(cameraName,tcpAddr,tcpPort,cameraType,channelID,parkID) " +
         " values(@cameraName,@tcpAddr,@tcpPort,@cameraType,@channelID,@parkID)";


            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cameraName",OleDbType.Char), 
                new OleDbParameter("@tcpAddr",OleDbType.Char),
                new OleDbParameter("@tcpPort",OleDbType.Char),  
                new OleDbParameter("@cameraType",OleDbType.Char), 
                new OleDbParameter("@channelID",OleDbType.Integer), 
                new OleDbParameter("@parkID",OleDbType.Integer), 

            };
            parms[0].Value = camera.cameraName == null ? "" : camera.cameraName;
            parms[1].Value = camera.tcpAddr == null ? "" : camera.tcpAddr;
            parms[2].Value = camera.tcpPort == null ? "" : camera.tcpPort;
            parms[3].Value = camera.cameraType.ToString() == null ? "" : camera.cameraType.ToString();
            parms[4].Value = camera.channelID;
            parms[5].Value = camera.parkID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            OleDbDataReader reader = SelectCamera_DO(camera.cameraName);
            while (reader.Read())
            {
                camera.cameraID = Convert.ToInt32(reader["ID"].ToString());

            }
            return true;
        }
        public static bool SaveCameraUnit_DO(CameraStc camera)
        {

            string strSql = "update " + tbCamera +

                " set  cameraName=@cameraName " +
                ", tcpAddr=@tcpAddr  " +
                ", tcpPort=@tcpPort " +
                ", cameraType= @cameraType " +
                ", channelID= @channelID " +
                ", parkID= @parkID " +

                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cameraName",OleDbType.Char), 
                new OleDbParameter("@tcpAddr",OleDbType.Char),
                new OleDbParameter("@tcpPort",OleDbType.Char),  
                new OleDbParameter("@cameraType",OleDbType.Char), 
                new OleDbParameter("@channelID",OleDbType.Integer), 
                new OleDbParameter("@parkID",OleDbType.Integer), 

                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = camera.cameraName == null ? "" : camera.cameraName;
            parms[1].Value = camera.tcpAddr == null ? "" : camera.tcpAddr;
            parms[2].Value = camera.tcpPort == null ? "" : camera.tcpPort;
            parms[3].Value = camera.cameraType.ToString() == null ? "" : camera.cameraType.ToString();
            parms[4].Value = camera.channelID;
            parms[5].Value = camera.parkID;
            parms[6].Value = camera.cameraID;


            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }
        public static OleDbDataReader SelectCamera_DO(string name)
        {

            string strSql = "select * from " + tbCamera + " where cameraName=@cameraName";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cameraName",OleDbType.Char)
            };
            parms[0].Value = name == null ? "" : name;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }

        public static bool DeleteCamera_DO(int id)
        {


            string strSql = "delete from " + tbCamera + " where cameraID=@cameraID ";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cameraID",OleDbType.Integer)
            };
            parms[0].Value = id;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);


            return true;
        }

        /*************************************************
        /**************************************************************************************************************

       Function:       ShowHistory_DO()
         
       Description:   显示历史记录信息
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader HistoryLoader_DO()
        {

            string strSql = "select * from " + tbVehicle;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }
        public static OleDbDataReader HistoryClear_DO()
        {

            string strSql = "delete from " + tbVehicle;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }
        public static bool RecordHistory_DO(MessageStc mes)
        {
            CardUnit card = mes.card;
            string carTime = System.DateTime.Now.ToString("G"); 

            string strSql = "insert into " + tbVehicle +
         "(carTime,cardID,cardType,carType,carLic,cardName,cardTel,entryFlag,parkName,channelName) " +
         " values(@carTime,@cardID,@cardType,@carType,@carLic,@cardName,@cardTel,@entryFlag,@parkName,@channelName)";
    

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@carTime",OleDbType.Char), 
                new OleDbParameter("@cardID",OleDbType.Char),
                new OleDbParameter("@cardType",OleDbType.Char),  
                new OleDbParameter("@carType",OleDbType.Char),   
                new OleDbParameter("@carLic",OleDbType.Char), 
                new OleDbParameter("@cardName",OleDbType.Char),   
                new OleDbParameter("@cardTel",OleDbType.Char), 
                new OleDbParameter("@entryFlag",OleDbType.Char),
                new OleDbParameter("@parkName",OleDbType.Char), 
                new OleDbParameter("@channelName",OleDbType.Char)

            };
            parms[0].Value = carTime == null ? "" : carTime;
            parms[1].Value = card.CardID == null ? "": card.CardID ;
            parms[2].Value = card.CardType.ToString() == null ? "" :card.CardType.ToString();
            parms[3].Value = card.CarType.ToString() == null ? "" : card.CarType.ToString();
            parms[4].Value = card.CarLic == null ? "" : card.CarLic ;
            parms[5].Value = card.CardName == null ? "": card.CardName ;
            parms[6].Value = card.CardTel == null ? "" : card.CardTel;
            parms[7].Value = card.TimerFlag;
            parms[8].Value = mes.park.parkName == null ? "" : mes.park.parkName;
            parms[9].Value = mes.park.selectedChannel.channelName == null ? "" : mes.park.selectedChannel.channelName;


            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;
        }



        /**************************************************************************************************************

       Function:      ShowCardInfo_DO()
         
       Description:   显示卡片信息列表
         
       Input:          
           
       Return:         OleDbDataReader 返回片信息列表的reader

       **************************************************************************************************************/
        public static OleDbDataReader ShowCardInfo_DO()
        {

            string strSql = "select * from " + tbCard;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }
        public static OleDbDataReader CardClear_DO()
        {

            string strSql = "delete from " + tbCard;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }

        public static OleDbDataReader SelectCard_DO(string id)
        {

            string strSql = "select * from " + tbCard + " where cardID=@id";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@id",OleDbType.Char)
            };
            parms[0].Value = id == null ? "" : id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }


        public static bool RecordCard_DO(CardUnit card)

    {
        string strSql = "update " + tbCard + 
            " set  timerFlag=@timerFlag " + 
            ", validFlag=@validFlag "+
            ", totalTime=@totalTime "+
            ", lastIn= @lastIn "+
            ", lastOut= @lastOut "+
            ", cardValue = @cardValue " +

            " where cardID=@cid";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@timerFlag",OleDbType.Boolean), 
                new OleDbParameter("@validFlag",OleDbType.Char),
                new OleDbParameter("@totalTime",OleDbType.Char),  
                new OleDbParameter("@lastIn",OleDbType.Char), 
                new OleDbParameter("@lastOut",OleDbType.Char),   
                new OleDbParameter("@cardValue",OleDbType.Char),

                new OleDbParameter("@cid",OleDbType.Char)
            };
            parms[0].Value = card.TimerFlag ? 1 : 0;
            parms[1].Value = card.ValidFlag.ToString() == null ? "" : card.ValidFlag.ToString();
            parms[2].Value = card.TotalTime == null ? "" : card.TotalTime.ToString();
            parms[3].Value = card.LastIn == null ? "" : card.LastIn ;
            parms[4].Value = card.LastOut == null ? "" : card.LastOut;
            parms[5].Value = card.CardValue == null ? "" : card.CardValue;

            parms[6].Value = card.CardID == null ? "" : card.CardID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;



    }

        public static bool RechargeCard_DO(CardUnit card)
        {
            string strSql = "update " + tbCard +
                " set  cardValue=@value " +
                ", cardType=@cardType "+
                ", lastRecharge= @lastRecharge " +
                " where cardID=@id";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@value",OleDbType.Char)
                ,new OleDbParameter("@cardType",OleDbType.Char)
                ,new OleDbParameter("@lastRecharge",OleDbType.Char)
                ,new OleDbParameter("@id",OleDbType.Char)
            };
            parms[0].Value = card.CardValue == null ? "" :card.CardValue  ;
            parms[1].Value = card.CardType.ToString() == null ? "" :card.CardType.ToString() ;
            parms[2].Value = card.LastRecharge == null ? "" :  card.LastRecharge;
            parms[3].Value = card.CardID == null ? "" : card.CardID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);
            return true;
        }

        public static bool EditCard_DO(CardUnit card)
        {
            string strSql = "update " + tbCard +
                " set  cardName=@cardName " +
                ", timerFlag=@timerFlag " + 
            ", validFlag=@validFlag "+
                ", carType=@carType " +
                ", carLic=@carLic " +
                ", cardTel= @cardTel " +
                ", cardLevel = @cardLevel " +

                " where cardID=@id";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cardName",OleDbType.Char)
               , new OleDbParameter("@timerFlag",OleDbType.Boolean)
                ,new OleDbParameter("@validFlag",OleDbType.Char)
                ,new OleDbParameter("@carType",OleDbType.Char)
                ,new OleDbParameter("@carLic",OleDbType.Char)
                ,new OleDbParameter("@cardTel",OleDbType.Char)
               , new OleDbParameter("@cardLevel",OleDbType.Integer)

                ,new OleDbParameter("@id",OleDbType.Char)
            };
            parms[0].Value = card.CardName == null ? "" : card.CardName;
            parms[1].Value = card.TimerFlag ? 1 : 0;
            parms[2].Value = card.ValidFlag.ToString() == null ? "" : card.ValidFlag.ToString();
            parms[3].Value =card.CarType.ToString();
            parms[4].Value = card.CarLic == null ? "" : card.CarLic;
            parms[5].Value = card.CardTel == null ? "" : card.CardTel;
            parms[6].Value = card.CardLevel;

            parms[7].Value = card.CardID == null ? "" : card.CardID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);
            return true;
        }


        public static bool RefreshCard_DO(CardUnit card)
        {
            string strSql = "update " + tbCard +
            " set  timerFlag=@timerFlag " + 
            ", validFlag=@validFlag "+
                " where cardID=@id";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@timerFlag",OleDbType.Boolean), 
                new OleDbParameter("@validFlag",OleDbType.Char),
                new OleDbParameter("@id",OleDbType.Char),
            };
            parms[0].Value = card.TimerFlag ? 1 : 0;
            parms[1].Value = card.ValidFlag.ToString() == null ? "" : card.ValidFlag.ToString();
            parms[2].Value = card.CardID == null ? "" : card.CardID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);
            return true;
        }


        public static bool AddCard_DO(CardUnit card)

        {


            string strSql = "insert into " + tbCard +
         "(cardID,cardType,validFlag,initTime,cardName,carType,carLic,cardTel,cardValue,cardLevel,lastRecharge) " +
         " values(@cardID,@cardType,@validFlag,@initTime,@cardName,@carType,@carLic,@cardTel,@cardValue,@cardLevel,@lastRecharge)";


            OleDbParameter[] parms = new OleDbParameter[]
            {
               
                new OleDbParameter("@cardID",OleDbType.Char),
                new OleDbParameter("@cardType",OleDbType.Char),  
                new OleDbParameter("@validFlag",OleDbType.Char),
                 new OleDbParameter("@initTime",OleDbType.Char), 
                new OleDbParameter("@cardName",OleDbType.Char),   
                new OleDbParameter("@carType",OleDbType.Char), 
                new OleDbParameter("@carLic",OleDbType.Char), 
                new OleDbParameter("@cardTel",OleDbType.Char), 
                new OleDbParameter("@cardValue",OleDbType.Char), 
                new OleDbParameter("@cardLevel",OleDbType.Integer),

                new OleDbParameter("@lastRecharge",OleDbType.Char), 

            };
            parms[0].Value = card.CardID== null ? "" : card. CardID;
            parms[1].Value = card.CardType.ToString()== null ? "" : card.CardType.ToString();
            parms[2].Value = card.ValidFlag.ToString()== null ? "" : card.ValidFlag.ToString();
            parms[3].Value = card.InitTime== null ? "" : card.InitTime ;
            parms[4].Value = card.CardName== null ? "" : card. CardName;
            parms[5].Value = card.CarType.ToString() ;
            parms[6].Value = card.CarLic== null ? "" : card. CarLic;
            parms[7].Value = card.CardTel== null ? "" : card.CardTel ;
            parms[8].Value = card.CardValue== null ? "" : card.CardValue ;
                        parms[9].Value = card.CardLevel;

            parms[10].Value = card.LastRecharge == null ? "" : card.LastRecharge;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;
        }


        public static bool DeleteCard_DO(int id)
        {
            
            
            string strSql = "delete from " + tbCard + " where cardID=@cardID ";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@cardID",OleDbType.Integer)
            };
            parms[0].Value = id;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);
            
            
            return true;
        }


        /**************************************************************************************************************

       Function:       ConfigModeLoader_DO()
         
       Description:   载入所有配置模式
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader ConfigModeLoader_DO()
        {

            string strSql = "select * from " + tbConfigMode;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }

        public static OleDbDataReader SelectSetting_DO(int id)
        {

            string strSql = "select * from " + tbConfigMode + " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ID",OleDbType.Integer)
            };
            parms[0].Value = id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }



        public static bool SaveSetting_DO(EntranceSettingStr setting )
        {

            string strSql = "update " + tbConfigMode +

                " set  modeName=@modeName " +
                ", enableBGS=@enableBGS  " +
                ", enableBGSRpeat=@enableBGSRpeat  " +

                ", enableBGOn=@enableBGOn " +
                ", enableBGOnUp=@enableBGOnUp " +

                ", enableBGOff= @enableBGOff " +
                ", enableBGOffDelay= @enableBGOffDelay " +

                ", enableBGManual = @enableBGManual " +

                ", enableCSender = @enableCSender " +

                ", enableCReader = @enableCReader " +
                ", enableCReaderI = @enableCReaderI " +
                ", enableCReaderB = @enableCReaderB " +

                ", enableDG1 = @enableDG1 " +
                ", enableDG1P = @enableDG1P " +
                ", enableDG2 = @enableDG2 " +
                ", enableDG2P = @enableDG2P " +

                ", enableLED = @enableLED " +
                ", enableLEDStr = @enableLEDStr " +

                ", enableCamera = @enableCamera " +
                ", enableVoice = @enableVoice " +

                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@modeName",OleDbType.Char),  
                new OleDbParameter("@enableBGS",OleDbType.Boolean), 
                new OleDbParameter("@enableBGSRpeat",OleDbType.Boolean), 

                new OleDbParameter("@enableBGOn",OleDbType.Boolean), 
                new OleDbParameter("@enableBGOnUp",OleDbType.Integer), 

                new OleDbParameter("@enableBGOff",OleDbType.Boolean), 
                new OleDbParameter("@enableBGOffDelay",OleDbType.Integer), 

                new OleDbParameter("@enableBGManual",OleDbType.Boolean), 

                new OleDbParameter("@enableCSender",OleDbType.Boolean), 

                new OleDbParameter("@enableCReader",OleDbType.Boolean), 
                new OleDbParameter("@enableCReaderI",OleDbType.Boolean), 
                new OleDbParameter("@enableCReaderB",OleDbType.Boolean), 

                new OleDbParameter("@enableDG1",OleDbType.Boolean), 
                new OleDbParameter("@enableDG1P",OleDbType.Boolean), 
                new OleDbParameter("@enableDG2",OleDbType.Boolean), 
                new OleDbParameter("@enableDG2P",OleDbType.Boolean), 

                new OleDbParameter("@enableLED",OleDbType.Boolean), 
                new OleDbParameter("@enableLEDStr",OleDbType.Char), 

                new OleDbParameter("@enableCamera",OleDbType.Boolean), 
                new OleDbParameter("@enableVoice",OleDbType.Boolean), 

                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = setting.modeName == null ? "" : setting.modeName;
            parms[1].Value = setting.enableBGS ? 1 : 0;
            parms[2].Value = setting.enableBGSRpeat ? 1 : 0;

            parms[3].Value = setting.enableBGOn ? 1 : 0;
            parms[4].Value = setting.enableBGOnUp ;

            parms[5].Value = setting.enableBGOff ? 1 : 0;
            parms[6].Value = setting.enableBGOffDelay;

            parms[7].Value = setting.enableBGManual ? 1 : 0;

            parms[8].Value = setting.enableCSender ? 1 : 0;

            parms[9].Value = setting.enableCReader ? 1 : 0;
            parms[10].Value = setting.enableCReaderI ? 1 : 0;
            parms[11].Value = setting.enableCReaderB ? 1 : 0;

            parms[12].Value = setting.enableDG1 ? 1 : 0;
            parms[13].Value = setting.enableDG1P ? 1 : 0;
            parms[14].Value = setting.enableDG2 ? 1 : 0;
            parms[15].Value = setting.enableDG2P ? 1 : 0;

            parms[16].Value = setting.enableLED ? 1 : 0;
            parms[17].Value = setting.enableLEDStr == null ? "" : setting.enableLEDStr;

            parms[18].Value = setting.enableCReader ? 1 : 0;
            parms[19].Value = setting.enableVoice ? 1 : 0;
            parms[20].Value = setting.settingID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }


        /**************************************************************************************************************

       Function:       ChargeModeLoader_DO()
         
       Description:   载入所有计费模式
         
       Input:          
           
       Return:         OleDbDataReader 返回历史记录的reader

       **************************************************************************************************************/
        public static OleDbDataReader ChargeModeLoader_DO()
        {

            string strSql = "select * from " + tbChargeMode;


            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, null);

            return ds;

        }

        public static OleDbDataReader SelectChargeMode_DO(int id)
        {

            string strSql = "select * from " + tbChargeMode + " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ID",OleDbType.Integer)
            };
            parms[0].Value = id;

            OleDbDataReader ds = AccessHelper.ExecuteReader(connStr, strSql, parms);

            return ds;

        }

        public static bool SaveChargeMode_DO(ChargeModeStr chargeMode)
        {

            string strSql = "update " + tbChargeMode +

                " set  modeName=@modeName " +
                ", enableYCard=@enableYCard  " +
                ", enableMFCard=@enableMFCard " +
                ", enableCZCard= @enableCZCard " +
                ", enableLSCard= @enableLSCard " +
                ", enableYGCard= @enableYGCard " +
                ", enableSQCard= @enableSQCard " +
                ", enableTQCard= @enableTQCard " +
                ", enableRCard= @enableRCard " +

                ", unitCZCard = @unitCZCard " +
                ", unitPayCZCard = @unitPayCZCard " +
                ", discountCZCard = @discountCZCard " +
                ", freeTimeCZCard = @freeTimeCZCard " +

                ", unitLSCard = @unitLSCard " +
                ", unitPayLSCard = @unitPayLSCard " +
                ", discountLSCard = @discountLSCard " +
                ", freeTimeLSCard = @freeTimeLSCard " +

                ", unitYGCard = @unitYGCard " +
                ", unitPayYGCard = @unitPayYGCard " +
                ", discountYGCard = @discountYGCard " +
                ", freeTimeYGCard = @freeTimeYGCard " +

                ", unitPayYCard = @unitPayYCard " +
                ", unitPayRCard = @unitPayRCard " +
                ", modeSQCard = @modeSQCard " +

                " where ID=@ID";

            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@modeName",OleDbType.Char), 
                new OleDbParameter("@enableYCard",OleDbType.Boolean),  
                new OleDbParameter("@enableMFCard",OleDbType.Boolean), 
                new OleDbParameter("@enableCZCard",OleDbType.Boolean), 
                new OleDbParameter("@enableLSCard",OleDbType.Boolean), 
                new OleDbParameter("@enableYGCard",OleDbType.Boolean), 
                new OleDbParameter("@enableSQCard",OleDbType.Boolean), 
                new OleDbParameter("@enableTQCard",OleDbType.Boolean), 
                new OleDbParameter("@enableRCard",OleDbType.Boolean), 

                new OleDbParameter("@unitCZCard",OleDbType.Integer), 
                new OleDbParameter("@unitPayCZCard",OleDbType.Integer), 
                new OleDbParameter("@discountCZCard",OleDbType.Integer), 
                new OleDbParameter("@freeTimeCZCard",OleDbType.Integer), 


                new OleDbParameter("@unitLSCard",OleDbType.Integer), 
                new OleDbParameter("@unitPayLSCard",OleDbType.Integer), 
                new OleDbParameter("@discountLSCard",OleDbType.Integer), 
                new OleDbParameter("@freeTimeLSCard",OleDbType.Integer), 

                new OleDbParameter("@unitYGCard",OleDbType.Integer), 
                new OleDbParameter("@unitPayYGCard",OleDbType.Integer), 
                new OleDbParameter("@discountYGCard",OleDbType.Integer), 
                new OleDbParameter("@freeTimeYGCard",OleDbType.Integer), 

                new OleDbParameter("@unitPayYCard",OleDbType.Integer), 
                new OleDbParameter("@unitPayRCard",OleDbType.Integer), 
                new OleDbParameter("@modeSQCard",OleDbType.Boolean), 

                new OleDbParameter("@ID",OleDbType.Integer), 
            };

            parms[0].Value = chargeMode.modeName == null ? "" : chargeMode.modeName;
            parms[1].Value = chargeMode.enableYCard ? 1 : 0;
            parms[2].Value = chargeMode.enableMFCard ? 1 : 0;
            parms[3].Value = chargeMode.enableCZCard ? 1 : 0;
            parms[4].Value = chargeMode.enableLSCard ? 1 : 0;
            parms[5].Value = chargeMode.enableYGCard ? 1 : 0;
            parms[6].Value = chargeMode.enableSQCard ? 1 : 0;
            parms[7].Value = chargeMode.enableTQCard ? 1 : 0;
            parms[8].Value = chargeMode.enableRCard ? 1 : 0;

            parms[9].Value = chargeMode.unitCZCard ;
            parms[10].Value = chargeMode.unitPayCZCard;
            parms[11].Value = chargeMode.discountCZCard;
            parms[12].Value = chargeMode.freeTimeCZCard;

            parms[13].Value = chargeMode.unitLSCard;
            parms[14].Value = chargeMode.unitPayLSCard;
            parms[15].Value = chargeMode.discountLSCard;
            parms[16].Value = chargeMode.freeTimeLSCard;

            parms[17].Value = chargeMode.unitYGCard;
            parms[18].Value = chargeMode.unitPayYGCard;
            parms[19].Value = chargeMode.discountYGCard;
            parms[20].Value = chargeMode.freeTimeYGCard;

            parms[21].Value = chargeMode.unitPayYCard;
            parms[22].Value = chargeMode.unitPayRCard;
            parms[23].Value = chargeMode.modeSQCard ? 1 : 0;

            parms[24].Value = chargeMode.modeID;

            AccessHelper.ExecuteNonQuery(connStr, strSql, parms);

            return true;

        }





    }
}
