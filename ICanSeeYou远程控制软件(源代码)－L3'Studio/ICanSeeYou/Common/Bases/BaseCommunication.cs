/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：BaseCommunication.cs
        // 文件功能描述：基本通讯类，本身不能直接当作网络通讯使用，被BaseServer和BaseControler继承。
//----------------------------------------------------------------*/

using System;
using System.Text;

using System.Net.Sockets;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

using ICanSeeYou.Common;
using ICanSeeYou.Codes;

namespace ICanSeeYou.Bases
{
    /// <summary>
    /// 执行指令的委托
    /// </summary>
    /// <param name="code">指令</param>
    public delegate void ExecuteCodeEvent(BaseCommunication sender, Code code);

    /// <summary>
    /// 基本通讯类
    /// </summary>
    public class BaseCommunication
    {
        /// <summary>
        /// 序列化网络流读者
        /// </summary>
        private BinaryFormatter formatterReader;
        /// <summary>
        /// 序列化网络流写者
        /// </summary>
        private BinaryFormatter formatterWriter;

        /// <summary>
        /// 网络流
        /// </summary>
        protected NetworkStream stream;
        /// <summary>
        /// 端口
        /// </summary>
        protected int port;

        /// <summary>
        ///获取等待重试时间
        /// </summary>
        protected virtual int sleepTime
        {
            get { return Constant.SleepTime; }//默认值
        }

        /// <summary>
        ///是否断开连接
        /// </summary>
        public bool Disconnected;
        /// <summary>
        /// 是否退出(不再连接)
        /// </summary>
        public bool Exit;
        /// <summary>
        /// 委托(执行指令)
        /// </summary>
        public ExecuteCodeEvent Execute;

        /// <summary>
        /// 客户端基类构造函数
        /// </summary>
        public BaseCommunication()
        {
            Disconnected =true;
            Exit = false;
            formatterReader = new BinaryFormatter();
            formatterWriter = new BinaryFormatter();
        }

        /// <summary>
        /// 传输信息
        /// </summary>
        protected void communication()
        {
            try
            {
                Disconnected = false;
                do
                {
                    //读取网络流
                    Code code = (Code)formatterReader.Deserialize(stream);
                    if (code != null)
                    {
                        if (code.Head == CodeHead.CONNECT_CLOSE)
                            Disconnected = true;
                        else if (code.Head == CodeHead.EXIT)
                        {
                            Disconnected = true;
                            Exit = true;
                        }
                        else
                            Execute(this, code);
                    }

                } while (!Disconnected);
            }
            catch// (Exception e)
            {
               // MessageBox.Show(e.ToString());
            }
            Disconnected = true;
        }       

        /// <summary>
        /// 告诉对方连接成功
        /// </summary>
        protected void SayHello()
        {
            try
            {
                Disconnected = false;
                BaseCode ConnectOK = new BaseCode();
                ConnectOK.Head = CodeHead.CONNECT_OK;
                SendCode(ConnectOK);
            }
            catch
            {
                Disconnected = true;
            }
        }

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        /// <returns></returns>
        public  void CloseStream()
        {
            try
            {
                Disconnected = true;
                if (stream != null)
                    stream.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="code">指令</param>
        public void SendCode(Code code)
        {
            try
            {
                formatterWriter.Serialize(stream, code);
            }
            catch// (Exception exp)
            {
               // MessageBox.Show("Error:" + exp.ToString());
            }
        }
    }
}
