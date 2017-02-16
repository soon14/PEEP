/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：MouseHook.cs
        // 文件功能描述：鼠标控制（Hook鼠标）。
//----------------------------------------------------------------*/

using System;
using System.Text;
using System.Runtime.InteropServices;

using ICanSeeYou.API;
using ICanSeeYou.Codes;

namespace ICanSeeYou.Hooks
{  
    /// <summary>
    /// 鼠标Hook类
    /// </summary>
    public class MouseHook
    {   
        /// <summary>
        /// 鼠标事件枚举
        /// </summary>
        public enum MouseEventFlag
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        /// <summary>
        /// 委托-鼠标按键触发
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dwData"></param>
        /// <param name="dwExtraInfo"></param>
        public delegate void DoMouseButtons(int flags, int dx, int dy, int dwData, int dwExtraInfo);
        /// <summary>
        /// 委托-鼠标移动触发
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public delegate bool DoMouseMove(int X, int Y);
        /// <summary>
        /// 模拟鼠标按钮按下的事件
        /// </summary>
        private event DoMouseButtons MouseButton;
        /// <summary>
        /// 模拟鼠标移动的事件
        /// </summary>
        private event DoMouseMove MouseMove;

        /// <summary>
        /// 创建鼠标钩子的实例
        /// </summary>
        public MouseHook()
        {
            MouseButton += new DoMouseButtons(Api.mouse_event);
            MouseMove += new DoMouseMove(Api.SetCursorPos);
        }

        /// <summary>
        /// 控制鼠标执行相应操作
        /// </summary>
        /// <param name="MEvent">指定的鼠标事件</param>
        public void MouseWork(MouseEvent MEvent)
        {

            switch (MEvent.Type)
            {
                case MouseEventType.MouseMove:
                    MouseMove(MEvent.X, MEvent.Y);
                    break;
                case MouseEventType.MouseLeftDown:
                    MouseMove(MEvent.X, MEvent.Y);
                    MouseButton((int)MouseEventFlag.LeftDown, MEvent.X, MEvent.Y, 0, 0);
                    break;
                case MouseEventType.MouseLeftUp:
                    MouseMove(MEvent.X, MEvent.Y);
                    MouseButton((int)MouseEventFlag.LeftUp, MEvent.X, MEvent.Y, 0, 0);
                    break;
                case MouseEventType.MouseRightDown:
                    MouseButton((int)MouseEventFlag.RightDown, MEvent.X, MEvent.Y, 0, 0);
                    break;
                case MouseEventType.MouseRightUp:
                    MouseButton((int)MouseEventFlag.RightUp, MEvent.X, MEvent.Y, 0, 0);
                    break;
                case MouseEventType.MouseClick:
                    MouseMove(MEvent.X, MEvent.Y);
                    MouseButton((int)MouseEventFlag.LeftDown, MEvent.X, MEvent.Y, 0, 0);
                    MouseButton((int)MouseEventFlag.LeftUp, MEvent.X, MEvent.Y, 0, 0);
                    break;
                case MouseEventType.MouseDoubleClick:
                    MouseMove(MEvent.X, MEvent.Y);
                    MouseButton((int)MouseEventFlag.LeftDown, MEvent.X, MEvent.Y, 0, 0);
                    MouseButton((int)MouseEventFlag.LeftDown, MEvent.X, MEvent.Y, 0, 0);
                    MouseButton((int)MouseEventFlag.LeftUp, MEvent.X, MEvent.Y, 0, 0);
                    MouseButton((int)MouseEventFlag.LeftUp, MEvent.X, MEvent.Y, 0, 0);
                    break;
            }
        }
    }
}
