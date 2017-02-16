/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：BaseServer.cs
        // 文件功能描述：指令类（即服务端和客户端之间事先约好的一个规定），譬如客户端发送的通讯内容包含指令SHUTDOWN，
        // 那么服务端收到这样的内容后就做出关机的响应。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{  
    /// <summary>
    /// 指令
    /// </summary>
    [Serializable]
    public abstract class Code
    {
        /// <summary>
        /// 指令头部
        /// </summary>
        public abstract CodeHead Head
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// 单指令
    /// </summary>
    [Serializable]
    public class BaseCode:Code
    {
        private CodeHead head;
        /// <summary>
        /// 指令头部
        /// </summary>
        public override CodeHead Head
        {
            get { return head; }
            set { head = value; }
        }
        /// <summary>
        /// 调试用
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Head=" + head;
        }
    }

}
