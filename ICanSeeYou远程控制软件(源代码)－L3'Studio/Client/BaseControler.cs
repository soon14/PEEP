/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：BaseControler.cs
        // 文件功能描述：基本控制类（即客户端），具有建立连接，断开连接和基本通讯功能
//----------------------------------------------------------------*/

using System;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

using ICanSeeYou.Bases;
using ICanSeeYou.Common;

namespace Client
{
    /// <summary>
    /// 基本控制类
    /// </summary>
    public class BaseControler : BaseCommunication
    {
        /// <summary>
        /// Tcp客户端
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// 服务端IP
        /// </summary>
        private IPAddress serverAddress;
        /// <summary>
        /// 服务端IP
        /// </summary>
        public IPAddress ServerAddress
        {
            get { return serverAddress; }
            set { serverAddress = value; }
        }

        private bool haveConnected;
        /// <summary>
        /// 是否已经建立连接
        /// </summary>
        public bool HaveConnected
        {
            get
            {
                return haveConnected;
            }

        }

        //startPort作为以后扩展功能用
        // private int startPort;

        private int maxTimes;
        /// <summary>
        /// 最大重试次数
        /// </summary>
        public int MaxTimes
        {
            get { return maxTimes; }
            set { maxTimes = value; }
        }
        /// <summary>
        ///等待重试时间
        /// </summary>
        protected override int sleepTime
        {
            get
            {
                return base.sleepTime;
            }
        }

        /// <summary>
        /// 控制端的构造函数(默认重试次数为常量:Constant.MaxTimes)
        /// </summary>
        /// <param name="serverAddress">服务端IP地址</param>
        /// <param name="port">通讯端口</param>
        public BaseControler(IPAddress serverAddress, int port)
            : this(serverAddress, port, Constant.MaxTimes)
        {
        }
        /// <summary>
        /// 控制端的构造函数
        /// </summary>
        /// <param name="serverAddress">服务端IP地址</param>
        /// <param name="port">通讯端口</param>
        ///<param name="maxTimes">重试次数</param>
        public BaseControler(IPAddress serverAddress, int port, int maxTimes)
            : base()
        {
            this.serverAddress = serverAddress;
            base.port = port;
          //  this.startPort = port;
            this.maxTimes = maxTimes;
            haveConnected = false;
        }

        /// <summary>
        /// 正在连接服务端 
        /// </summary>
        /// <returns>能否连接</returns>
        public void Connecting()
        {
            haveConnected = false;
            base.Disconnected = true;
            //base.port = startPort;
            int timeNum = 0;
            while (!connectSucceed())
            {
                Thread.Sleep(sleepTime);
                if (++timeNum > maxTimes)
                {
                    //if (++base.port > IPEndPoint.MaxPort)
                    //{
                    MessageBox.Show("无法连接" + serverAddress + "!");
                    CloseConnections();
                    return;
                    //}
                }
            }
            try
            {
                stream = client.GetStream();
                haveConnected = true;
            }
            catch
            {
                MessageBox.Show("无法获取网络流!");
                haveConnected = false;
            }
        }

        /// <summary>
        /// 运行
        /// </summary>
        public void Run()
        {
            try
            {
                Disconnected = false;
                if (haveConnected)
                    base.communication();

            }
            catch //(Exception exp)
            {
                CloseConnections();
               // MessageBox.Show( exp.ToString());
            }
            Disconnected = true;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public virtual  void CloseConnections()
        {
            try
            {
                base.CloseStream();
                haveConnected = false;
                if (client != null)
                    client.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        ///连接是否成功(当重试次数超过规定最大次数就表示连接失败)
        /// </summary>
        /// <returns></returns>
        private bool connectSucceed()
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverAddress,base.port);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
