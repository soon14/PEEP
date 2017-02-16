/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：Constant.cs
        // 文件功能描述： 常量类(包含各种默认值)。
//----------------------------------------------------------------*/

using System;
using System.Text;

namespace ICanSeeYou.Common
{
    /// <summary>
    /// 常量类(包含各种默认值)
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// 等待重试时间
        /// </summary>
        public const int SleepTime = 1000;
        /// <summary>
        /// 最大重试次数
        /// </summary>
        public const int MaxTimes = 100;
        /// <summary>
        /// 默认主要通讯端口
        /// </summary>
        public const int Port_Main = 5566;
        /// <summary>
        /// 默认文件发送端口
        /// </summary>
        public const int Port_File = 6566;
        /// <summary>
        /// 默认屏幕发送端口
        /// </summary>
        public const int Port_Screen = 7566;
        /// <summary>
        /// 升级程序的端口
        /// </summary>
        public const int Port_Update = 8566;
        /// <summary>
        /// 默认屏幕大小
        /// </summary>
        public static System.Drawing.Size ScreenSize = new System.Drawing.Size(1024, 768);
        /// <summary>
        /// 上一层
        /// </summary>
        public const string ParentPath = "上一层";
        /// <summary>
        /// 不可能的文件扩展名
        /// </summary>
        public const string UnknowFileType = "/";
        /// <summary>
        /// 服务端的密码文件名
        /// </summary>
        public static string PassWordFilename = System.IO.Directory.GetCurrentDirectory()+"\\INCUpwd.lll";
        /// <summary>
        /// 客户端的配置文件名
        /// </summary>
        public static string OptionFilename = System.IO.Directory.GetCurrentDirectory() + "\\INCUopt.lll";
        /// <summary>
        /// 客户端的帮助文件名
        /// </summary>
        public static string HelpFilename = System.IO.Directory.GetCurrentDirectory() + "\\INCU.chm";
    }
}
