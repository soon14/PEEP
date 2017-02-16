/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：DirectoryStruct.cs
        // 文件功能描述：涉及到文件管理的指令－文件夹结构类。
//----------------------------------------------------------------*/
using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 文件夹结构(作为序列化指令在网络上传输)
    /// </summary>
    [Serializable]
    public class DirectoryStruct : FileStruct
    {
        /// <summary>
        /// 文件夹标志
        /// </summary>
        public override FileFlag Flag
        {
            get { return FileFlag.Directory; }
        }
        public DirectoryStruct(string name) : base(name) { }
    }
}
