/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：KeyBoardHook.cs
        // 文件功能描述：键盘控制（Hook键盘）。
//----------------------------------------------------------------*/

using System;
using System.Runtime.InteropServices;

using ICanSeeYou.API;

namespace ICanSeeYou.Hooks
{   
    /// <summary>
    /// 键盘控制
    /// </summary>
    public class KeyBoardHook
    {
        /// <summary>
        /// 按下按键的参数
        /// </summary>
        private const int KEYEVENTF_KEYDOWN = 0x0001;

        /// <summary>
        /// 释放按键的参数
        /// </summary>
        private const int KEYEVENTF_KEYUP = 0x0002;

        /// <summary>
        /// 模拟键盘事件-按下按键
        /// </summary>
        /// <param name="keyCode"></param>
        public static void KeyDown(System.Windows.Forms.Keys keyCode)
        {
            Api.keybd_event((byte)keyCode, 0, KEYEVENTF_KEYDOWN, 0);
        }

        /// <summary>
        /// 模拟键盘事件-释放按键
        /// </summary>
        /// <param name="keyCode"></param>
        public static void KeyUp(System.Windows.Forms.Keys keyCode)
        {
            Api.keybd_event((byte)keyCode, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
