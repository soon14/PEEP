/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：DiskStruct.cs
        // 文件功能描述：涉及到文件管理的指令－磁盘结构类。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 磁盘结构(作为序列化指令在网络上传输)
    /// </summary>
    [Serializable]
    public class DiskStruct : FileStruct
    {
        /// <summary>
        /// 磁盘标志
        /// </summary>
        public override FileFlag Flag
        {
            get { return FileFlag.Disk; }
        }
        public DiskStruct(string name) : base(name) { }
    }
}
