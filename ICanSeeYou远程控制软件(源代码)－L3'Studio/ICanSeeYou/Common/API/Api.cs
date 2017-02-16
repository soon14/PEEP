/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：API.cs
        // 文件功能描述：API函数库。
//----------------------------------------------------------------*/

using System;
using System.Runtime.InteropServices;

namespace ICanSeeYou.API
{
    /// <summary>
    /// API类
    /// </summary>
    public class Api
    {
        /// <summary>
        /// 模拟鼠标事件的函数模型
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dwData"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void mouse_event(int flags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// 设置光标到指定位置的函数模型
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// 模拟键盘事件的函数模型
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,
            byte bScan,
            int dwFlags,
            int dwExtraInfo
        );
    }
}
