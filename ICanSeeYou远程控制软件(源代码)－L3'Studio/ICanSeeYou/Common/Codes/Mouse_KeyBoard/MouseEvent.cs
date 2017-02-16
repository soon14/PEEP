/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：MoseEvent.cs
        // 文件功能描述：涉及到屏幕管理的指令－鼠标控制指令。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 鼠标事件类型
    /// </summary>
    [Serializable]
    public enum MouseEventType
    {
        MouseMove,
        MouseLeftDown,
        MouseLeftUp,
        MouseRightDown,
        MouseRightUp,
        MouseClick,
        MouseDoubleClick
    }

    /// <summary>
    /// 鼠标事件结构
    /// </summary>
    [Serializable]
    public class MouseEvent : BaseCode
    {
        private Byte[] type;
        private Byte[] x;
        private Byte[] y;

        /// <summary>
        /// 创建鼠标事件的实例
        /// </summary>
        /// <param name="Type">类型</param>
        /// <param name="X">鼠标指针的X坐标</param>
        /// <param name="Y">鼠标指针的Y坐标</param>
        public MouseEvent(MouseEventType Type, int X, int Y)
        {
            this.type = BitConverter.GetBytes((int)Type);
            this.x = BitConverter.GetBytes(X);
            this.y = BitConverter.GetBytes(Y);
        }

        public MouseEvent(Byte[] Type, Byte[] X, Byte[] Y)
        {
            this.type = Type;
            this.x = X;
            this.y = Y;
        }

        public MouseEvent(Byte[] Content)
        {
            type = new byte[4];
            x = new byte[4];
            y = new byte[4];
            for (int i = 0; i < Content.Length; i++)
            {
                if (i >= 0 && i < 4)
                    type[i] = Content[i];
                if (i >= 4 && i < 8)
                    x[i - 4] = Content[i];
                if (i >= 8 && i < 12)
                    y[i - 8] = Content[i];
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public MouseEventType Type
        {
            get { return (MouseEventType)BitConverter.ToInt32(type, 0); }
        }
        /// <summary>
        /// 鼠标指针的X坐标
        /// </summary>
        public int X
        {
            get { return BitConverter.ToInt32(x, 0); }
        }
        /// <summary>
        /// 鼠标指针的Y坐标
        /// </summary>
        public int Y
        {
            get { return BitConverter.ToInt32(y, 0); }
        }

        public Byte[] ToBytes()
        {
            Byte[] Bytes = new Byte[12];
            type.CopyTo(Bytes, 0);
            x.CopyTo(Bytes, 4);
            y.CopyTo(Bytes, 8);
            return Bytes;
        }
    }
}