using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheku.Types
{
    [Serializable]
    public struct BGSTimerStr
    {
        public int Num;

        public int EntranceID;
        public int ParkID;  
             
        public int StartTimeHour;
        public int StartTimeMinute;
        public int EndTimeHour;
        public int EndTimeMinute; 

        public int EntranceSettingID;
        public int ChargeModeID;

        public int AfterEntranceSettingID;
        public int AfterChargeModeID;


    }
}
