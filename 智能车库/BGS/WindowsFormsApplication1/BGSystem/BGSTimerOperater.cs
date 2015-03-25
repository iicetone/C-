using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cheku.Types;
using System.Timers;

namespace Cheku.BGSystem
{
    class BGSTimerOperater
    {
        private List<BGSTimerStr> timerList;
        private Timer myTimer;
        public event EventHandler<MessageEventArgs> BGSTimerMessageArrived;             //入库委托任务
        private static String DEBUG = "debugging：*************in BGSTimerOperater.cs: "; //DEBUG注释

        public BGSTimerOperater()
        {
            timerList = new List<BGSTimerStr>();
             myTimer = new Timer(55000);    //一分钟
            myTimer.Elapsed += myTimer_Elapsed;//到2秒了做的事件
            myTimer.AutoReset = true; //是否不断重复定时器操作
        }
        public void TimerStart()
        {
            myTimer.Start();
        }
        public void TimerClose()
        {
            myTimer.Close();
            myTimer.Dispose();
        }
        public BGSTimerStr TimerAdd(BGSTimerStr timer)
        {
            bool flag = false;
                for (int i = 0; i < timerList.Count; i++)
                {
                    if (timer.StartTimeHour < timerList[i].StartTimeHour)
                    {
                       timerList.Insert(i,timer);
                       timer.Num = i+1;
                       flag = true;
                       break;
                    }
                    else if (timer.StartTimeHour == timerList[i].StartTimeHour)
                    {
                        if (timer.StartTimeMinute < timerList[i].StartTimeMinute)
                        {
                           timerList.Insert(i,timer);
                           timer.Num = i+1;
                           flag = true;
                           break;
                        } 
                        else if (timer.StartTimeMinute >= timerList[i].StartTimeMinute)
                        {
                            timerList.Insert(i+1, timer);
                            timer.Num = i+2;
                            flag = true;
                            break;
                        } 
                    }
                }
                if (!flag)
                {
                    timer.Num = timerList.Count+1 ;
                    timerList.Add(timer);
                }
                return timer;
        }


        public void TimerDelete(int timerNum)
        {
                timerList.RemoveAt(timerNum - 1);
                BGSTimerStr t = new BGSTimerStr();
                for (int i = 0; i < timerList.Count; i++)
                {
                    t = timerList[i];
                    t.Num = i + 1;
                    timerList[i] = t;
                }
        }

        public void EntranceTimerClear(int entranceID)
        {
            for (int i = 0; i < timerList.Count; i++)
            {
                if (timerList[i].EntranceID == entranceID)
                {
                    timerList.Remove(timerList[i]);
                }
            }
            BGSTimerStr t = new BGSTimerStr();
            for (int i = 0; i < timerList.Count; i++)
            {
                t = timerList[i];
                t.Num = i + 1;
                timerList[i] = t;
            }

        }
        public void ParkTimerClear(int parkID)
        {
            for (int i = 0; i < timerList.Count; i++)
            {
                if (timerList[i].ParkID == parkID)
                {
                    timerList.Remove(timerList[i]);
                }
            }
            BGSTimerStr t = new BGSTimerStr();
            for (int i = 0; i < timerList.Count; i++)
            {
                t = timerList[i];
                t.Num = i + 1;
                timerList[i] = t;
            }
        }
        public void AllTimerClear( )
        {
            if (timerList != null) 
            {
                timerList.Clear();
            }
        }
      private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int hh = DateTime.Now.Hour;//获取计时器的时数
            int mm = DateTime.Now.Minute;//获取计时器的分数
            foreach (BGSTimerStr t in timerList)
            {
                if (t.StartTimeHour == hh && t.StartTimeMinute == mm)
                {
                    if (BGSTimerMessageArrived != null)
                    {
                        BGSTimerMessageArrived(this, new MessageEventArgs(t,true));
                    }
                    else
                    {
                        Console.WriteLine(DEBUG + "BGSTimerMessageArrived == null");   //*******************DEBUGGING*****************
                    }
                }
                else if (t.EndTimeHour == hh && t.EndTimeMinute == mm)
                {
                    if (BGSTimerMessageArrived != null)
                    {
                        BGSTimerMessageArrived(this, new MessageEventArgs(t,false));
                    }
                    else
                    {
                        Console.WriteLine(DEBUG + "BGSTimerMessageArrived == null");   //*******************DEBUGGING*****************
                    }
                }
            }
        }
    }
}
