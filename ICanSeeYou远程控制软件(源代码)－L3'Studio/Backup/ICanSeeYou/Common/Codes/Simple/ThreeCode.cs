/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ThreeCode.cs
        // 文件功能描述：继承了DoubleCode。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 三指令(例如向服务端请求文件下载上传的指令)
    /// </summary>
    [Serializable]
    public class ThreeCode : DoubleCode
    {
        private string foot;
        /// <summary>
        /// 指令尾部
        /// </summary>
        public string Foot
        {
            get { return foot; }
            set { foot = value; }
        }

        public override string ToString()
        {
            return base.ToString() + ",Foot=" + foot;
        }
    }
}
