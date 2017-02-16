/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：KeyBoardEvent.cs
        // 文件功能描述：涉及到屏幕管理的指令－键盘控制指令。
//----------------------------------------------------------------*/

using System;
using System.Text;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 键盘事件类型
    /// </summary>
    [Serializable]
    public enum KeyBoardType
    {
        /// <summary>
        /// 按下按键
        /// </summary>
        Key_Down,
        /// <summary>
        /// 释放按键
        /// </summary>
        Key_Up,
        /// <summary>
        /// 按下并释放按键
        /// </summary>
        Key_Press,
    }

    /// <summary>
    /// 键盘事件结构
    /// </summary>
    [Serializable]
    public class KeyBoardEvent : BaseCode
    {
        /// <summary>
        /// 键盘事件类型
        /// </summary>
        private KeyBoardType type;

        /// <summary>
        /// 键代码
        /// </summary>
        private System.Windows.Forms.Keys keyCode;

        /// <summary>
        /// 键盘事件类型
        /// </summary>
        public KeyBoardType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 键代码
        /// </summary>
        public System.Windows.Forms.Keys KeyCode
        {
            get { return keyCode; }
            set { keyCode = value; }
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        public KeyBoardEvent()
        {
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keyCode"></param>
        public KeyBoardEvent(KeyBoardType type, System.Windows.Forms.Keys keyCode)
        {
            this.type = type;
            this.keyCode = keyCode;
        }
    } 
}
