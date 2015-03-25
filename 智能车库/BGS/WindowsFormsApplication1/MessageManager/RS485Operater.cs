using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Cheku.Types;
using Cheku.BGSystem;

namespace Cheku.MessageManager
{
    class RS485Operater
    {
 
        private static String DEBUG = "debugging：*************in RS485Operater.cs: "; //DEBUG注释

        private SerialPort com;
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  
        public event EventHandler<MessageEventArgs> RS485MessageArrived;            //收到状态委托任务

        int TEST = 0;
        public RS485Operater()
        {

            //读取当前的配置信息
            Console.WriteLine("485 TEST " + builder.ToString());   //*******************DEBUGGING*****************

        }
        public void setComPort(String port, int baudRate)
        {
            com = new SerialPort();
            com.BaudRate = baudRate;
            com.PortName = port;
            com.DataBits = 8;
            com.ReceivedBytesThreshold = 10;
            this.com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnDataReceived);
            try
            {
                com.Open();//打开串口();    捕获端口不存在的异常

            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("setComPort  Port == null");   //*******************DEBUGGING*****************

                // throw;
            }
        }


        public void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Console.WriteLine("OnDataRece");   //*******************DEBUGGING*****************
            int n = com.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据  
            com.Read(buf, 0, n);//读取缓冲数据  
            MessageStc mes = new MessageStc();

            if (buf[n - 1] != 0xFF || buf[0] >63) Console.WriteLine("OnDataReceived == ERRO DATA");   //*******************DEBUGGING*****************

            for (int i = 0; i < n; i++)
            {
                mes.info += buf[i].ToString("X2");
             //   Console.WriteLine("OnDataReceived == " + buf[i].ToString() + "   Length:" + buf.Length.ToString());   //*******************DEBUGGING*****************
            }
            Console.WriteLine("OnDataReceived == " + mes.info + "   Length:" + mes.info.Length.ToString());   //*******************DEBUGGING*****************
            if (RS485MessageArrived != null)
            {
                RS485MessageArrived(this, new MessageEventArgs(mes));
            }
            else
            {
                Console.WriteLine(DEBUG + "RS485MessageArrived == null");   //*******************DEBUGGING*****************
            }
        }
        public void sendData(Byte[] data)
        {
            try
            {
                com.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(DEBUG + "RS485sendData  com " +e.ToString());   //*******************DEBUGGING*****************

            }

        }
    }
}