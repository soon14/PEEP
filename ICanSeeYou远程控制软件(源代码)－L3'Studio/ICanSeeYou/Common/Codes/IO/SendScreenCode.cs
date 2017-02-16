/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：SendScreenCode.cs
        // 文件功能描述：涉及到屏幕管理的指令－发送屏幕指令。
//----------------------------------------------------------------*/

using System;
namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 发送屏幕指令
    /// </summary>
    [Serializable]
    public class SendScreenCode : BaseCode
    {
        private System.Drawing.Image screenImage;
        /// <summary>
        /// 屏幕截图
        /// </summary>
        public System.Drawing.Image ScreenImage
        {
            get { return screenImage; }
            set { screenImage = value; }
        }
        public SendScreenCode()
        {
            base.Head = CodeHead.SCREEN_SUCCESS;
        }
    }
}
