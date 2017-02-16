/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：BaseServer.cs
        // 文件功能描述：基本服务类（即服务端），具有建立连接，断开连接和基本通讯功能
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using ICanSeeYou.Bases;

namespace Server
{
    /// <summary>
    /// 基本服务类
    /// </summary>
    public class BaseServer:BaseCommunication
    {
        /// <summary>
        /// 连接
        /// </summary>
        private Socket connection;
        /// <summary>
        /// 服务端侦听连接
        /// </summary>
        private TcpListener listener;

        #region 作为以后扩展功能用
        //private int startPort;

        /// <summary>
        /// 线程是否被挂起
        /// </summary>
        //private bool threadSuspended = true;

        #endregion

        /// <summary>
        /// 服务端构造函数
        /// </summary>
        /// <param name="con"></param>
        /// <param name="poct"></param>
        public BaseServer(int port)
            : base()
        {
            base.port = port ;
        }

        /// <summary>
        /// 运行
        /// </summary>
        public void Run()
        {
            CloseConnections();
            listener = new TcpListener(System.Net.IPAddress.Any, base.port);
            listener.Start();//等待连接...
            do
            {
                base.Disconnected = false;
                try
                {
                    connection = listener.AcceptSocket();
                    base.stream = new NetworkStream(connection);
                    base.SayHello();
                }
                catch //(Exception exp)
                {
                    //  MessageBox.Show(exp.ToString());
                }
                //开始建立通讯
                base.communication();
                if (base.Disconnected)
                    CloseConnections();
            } while (!base.Exit);

        }

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        /// <returns></returns>
        public  void CloseConnections()
        {
            base.CloseStream();
            try
            {
                if (connection != null)
                    connection.Close();
            }
            catch
            {
            }
        }


    }
}
