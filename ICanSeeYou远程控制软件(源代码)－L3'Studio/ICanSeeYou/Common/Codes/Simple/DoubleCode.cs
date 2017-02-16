/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：DoubleCode.cs
        // 文件功能描述：继承了BaseCode。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 双指令
    /// </summary>
    [Serializable]
    public class DoubleCode : BaseCode
    {
        private string body;
        /// <summary>
        /// 指令身体
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        public override string ToString()
        {
            return body;
        }
    }
}
