/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ScreenControler.cs
        // 文件功能描述：远程屏幕控制类，具有屏幕鼠标控制，观看远程屏幕功能。
//----------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using System.Text;
using System.Threading;

using ICanSeeYou.Bases;
using ICanSeeYou.Codes;

namespace Client
{
    /// <summary>
    /// 屏幕接收端
    /// </summary>
    public class ScreenControler:BaseControler
    {
        /// <summary>
        /// 屏幕接收端线程
        /// </summary>
        private Thread screenThread;

        /// <summary>
        /// 显示屏幕的图片框
        /// </summary>
        private PictureBox pic_screen;

        /// <summary>
        /// 显示信息的标签
        /// </summary>
        private ToolStripStatusLabel lbl_message;

        /// <summary>
        /// 显示信息的标签
        /// </summary>
        public PictureBox pic_Screen
        {
            get { return pic_screen; }
            set { pic_screen = value; }
        }

        /// <summary>
        /// 显示信息的标签
        /// </summary>
        public ToolStripStatusLabel lbl_Message
        {
            get { return lbl_message; }
            set { lbl_message = value; }
        }

        /// <summary>
        /// 返回一个屏幕接收端的实例
        /// </summary>
        /// <param name="serverAddress"></param>
        /// <param name="port"></param>
        public ScreenControler(System.Net.IPAddress serverAddress,int port):base(serverAddress,port)
        {
            base.Execute = new ExecuteCodeEvent(screenExecuteCode);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="code"></param>
        private void screenExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead.CONNECT_OK:
                    DisplayMessage("屏幕连接成功!");
                    break;
                //case CodeHead.SCREEN_READY:
                //    DisplayMessage("屏幕截取准备完毕!");
                //    break;
                case CodeHead.SCREEN_SUCCESS:
                    //接受屏幕成功
                    screenShow((SendScreenCode)code);
                    break;
                case CodeHead.SCREEN_FAIL:
                    //服务端截屏发生错误
                    MessageBox.Show("无法截取屏幕!");
                    CloseConnections();
                    break;
                case CodeHead.CONNECT_CLOSE:
                    //关闭连接
                    CloseConnections();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 显示屏幕
        /// </summary>
        /// <param name="code"></param>
        private void screenShow(SendScreenCode code)
        {
            pic_screen.Image = code.ScreenImage;
        }

        /// <summary>
        ///  打开屏幕接收端
        /// </summary>
        public void Open()
        {
            if (screenThread != null && screenThread.IsAlive)
            {
                DialogResult result = MessageBox.Show("当前文件线程没关闭!是否关闭?", "关闭线程", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
            CloseConnections();
            ThreadStart threadStart = new ThreadStart(base.Connecting);
            threadStart += new ThreadStart(base.Run);
            screenThread = new Thread(threadStart);
            screenThread.Start();
        }


        /// <summary>
        /// 向截屏服务端发送截屏请求
        /// </summary>
        public bool GetScreen()
        {
            if (!base.Disconnected)
            {
                BaseCode code = new BaseCode();
                code.Head = CodeHead.SCREEN_GET;
                base.SendCode(code);
                return true;
            }
            else
                return false;
        }       

        /// <summary>
        /// 关闭连接
        /// </summary>
        public override void CloseConnections()
        {
            base.CloseConnections();
            if (screenThread != null && screenThread.IsAlive)
                screenThread.Abort();
        }

        /// <summary>
        /// 显示接收的信息
        /// </summary>
        /// <param name="msg"></param>
        public void DisplayMessage(string msg)
        {
            lbl_message.Text = msg;
        }
    }
}
