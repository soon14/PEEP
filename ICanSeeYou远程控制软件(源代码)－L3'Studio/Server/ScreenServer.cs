/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ScreenServer.cs
        // 文件功能描述：屏幕发送类，例如向客户端发送自己的屏幕
//----------------------------------------------------------------*/

using System;
using System.Drawing;

using ICanSeeYou.Bases;
using ICanSeeYou.Codes;
using ICanSeeYou.Windows;

namespace Server
{
    /// <summary>
    /// 屏幕发送端
    /// </summary>
    public class ScreenServer:BaseServer
    {      
        /// <summary>
        /// 返回屏幕发送端实例
        /// </summary>
        /// <param name="port">屏幕发送所使用的端口</param>
        public ScreenServer(int port) : base(port)
        {
            base.Execute = new ExecuteCodeEvent(screenExecuteCode);
        }

        /// <summary>
        /// 执行屏幕指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="code"></param>
        private void screenExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead.CONNECT_OK:
                case CodeHead.SCREEN_GET:
                    //发送屏幕到主控端
                    SendScreen();
                    break;
                case CodeHead.SCREEN_CLOSE:
                    base.CloseConnections();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 截取屏幕并发送
        /// </summary>
        private void SendScreen()
        {
            SendScreenCode code = new SendScreenCode();
            code.ScreenImage = ScreenCapture.Capture();
            if(code.ScreenImage==null)
            {//不能发送屏幕
                BaseCode failcode = new BaseCode();
                failcode.Head = CodeHead.FAIL;
                base.SendCode(failcode);
            }
            else
                base.SendCode(code);
        }
    }
}
