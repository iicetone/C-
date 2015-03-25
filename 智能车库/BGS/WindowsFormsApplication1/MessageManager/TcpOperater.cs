

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cheku.Types;
using Cheku.BGSystem;


namespace Cheku.MessageManager
{
    public partial class TcpOperater
    {
        public Thread MylistenThread1;
        public TcpListener MyTcplistener1;
        public Thread MylistenThread2;
        public TcpListener MyTcplistener2;
        private int port;
        public bool isFileHaveName = false;
        public event EventHandler<MessageEventArgs> TcpMessageArrived;            //收到状态委托任务


        private static String DEBUG = "debugging：*************in TCPOperater.cs: "; //DEBUG注释

        public TcpOperater()
        {
            Initialize();
            port = 20777;
            //监听开始
            this.MylistenThread1 = new Thread(new ThreadStart(StartListen));
            this.MylistenThread1.Start();
        }

        private void Initialize()
        {

            //    throw new NotImplementedException();
        }

        //开始监听  

        private void StartListen()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                MyTcplistener1 = new TcpListener(getMyIP(), port);
                MyTcplistener1.Start();
                while (true)
                {
                    TcpClient MyTcpClient = MyTcplistener1.AcceptTcpClient();
                    NetworkStream networkStream = MyTcpClient.GetStream();
                    BinaryReader br = new BinaryReader(networkStream);

                    MemoryStream memstrm = new MemoryStream();
                    int size = Convert.ToInt32(br.ReadString());
                    byte[] data2 = br.ReadBytes(size);
                    memstrm.Write(data2, 0, size);
                    BinaryFormatter binaryF = new BinaryFormatter();
                    memstrm.Position = 0;
                    MessageStc m = (MessageStc)binaryF.Deserialize(memstrm);
                    memstrm.Close();
                    if (TcpMessageArrived != null)
                    {
                        TcpMessageArrived(this, new MessageEventArgs(m));
                    }
                    else
                    {
                        Console.WriteLine(DEBUG + "TCPMessageArrived == null");   //*******************DEBUGGING*****************
                    }
                //    textBox2.Text = m.ip + " Type: " + m.type.ToString();
                    Console.WriteLine(DEBUG + "TCP TEST IP: " + m.ip);   //*******************DEBUGGING*****************

                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(DEBUG + "StartListen: " + ee.ToString());   //*******************DEBUGGING*****************

                //MessageBox.Show(ee.ToString());
            }

        }


        private void ConnectCallback(IAsyncResult ar)
        {
            Console.WriteLine(DEBUG + "TCP TEST ConnectCallback");   //*******************DEBUGGING*****************

        }

        public void sendTCPMessage(MessageStc msg)
        {
            msg.ip = getMyIP().ToString(); //*******************DEBUGGING*****************
            TcpClient MyTcpClient = new TcpClient();
            if (msg.ip != null)
            {
                MyTcpClient.BeginConnect(msg.ip, port, new AsyncCallback(ConnectCallback), MyTcpClient); //WARRING:注意替换IP为远程主机
                System.Threading.Thread.Sleep(20);

                Console.WriteLine(DEBUG + "TCP TEST sendTCPMessage :ip " + msg.ip);   //*******************DEBUGGING*****************

                if (!MyTcpClient.Connected)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (!MyTcpClient.Connected) { }

                }
                    MemoryStream ms = new MemoryStream();
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, msg);
                    byte[] bytes = ms.ToArray();

                    NetworkStream networkStream = MyTcpClient.GetStream();

                    BinaryWriter bw = new BinaryWriter(networkStream);
                    bw.Write(bytes.Length.ToString());//发送大小
                    bw.Flush();
                    bw.Write(bytes, 0, bytes.Length);//发送对象
                    bw.Flush();
            }
            else     Console.WriteLine(DEBUG + "TCP TEST sendTCPMessage :ip ==null");   //*******************DEBUGGING*****************

        }

        //获取本地IP
        public IPAddress getMyIP()
        {
            IPAddress[] addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily.ToString() == "InterNetwork")
                    return addr[i];
            }
            return addr[0];

        }



        //发送IP
        public void sendIp()
        {

            TcpClient MyTcpClient = new TcpClient("127.0.0.1", 9977);
            NetworkStream MyTcpStream = MyTcpClient.GetStream();
            StreamWriter MyStream = new StreamWriter(MyTcpStream);

            //  MyStream.Write(textBox1.ToString());

            MyStream.Close();


        }

        public void tcpClosing()
        {
            try
            {
                if (this.MyTcplistener1 != null)
                {
                    this.MyTcplistener1.Stop();
                }
                if (this.MylistenThread1 != null)
                {
                    if (this.MylistenThread1.ThreadState == ThreadState.Running)
                    {
                        this.MylistenThread1.Abort();

                    }

                }
                if (this.MyTcplistener2 != null)
                {
                    this.MyTcplistener2.Stop();
                }

                if (this.MylistenThread2 != null)
                {
                    if (this.MylistenThread2.ThreadState == ThreadState.Running)
                    {
                        this.MylistenThread2.Abort();
                    }
                }
            }
            catch (Exception Err)
            { MessageBox.Show(Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public Stream serializeStream_sameProject(object param)
        {
            BinaryFormatter formmatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();

            formmatter.Serialize(stream, param);

            return stream;
        }

        public object deserializeStream_sameProject(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            stream.Seek(0, SeekOrigin.Begin);

            object obj = formatter.Deserialize(stream);

            return obj;
        }
    }
}

