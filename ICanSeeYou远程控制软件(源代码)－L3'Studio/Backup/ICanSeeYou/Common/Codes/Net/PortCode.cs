/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：PortCode.cs
        // 文件功能描述：用来获取服务端和客户端文件/屏幕的通讯端口。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 用来获取服务端和客户端文件/屏幕的通讯端口
    /// </summary>
    [Serializable]
    public class PortCode : BaseCode
    {
        private int port;
        /// <summary>
        /// 通讯端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }
    }
}
