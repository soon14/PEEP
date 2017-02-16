/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：DisksCode.cs
        // 文件功能描述：涉及到文件管理的指令－"所有磁盘"指令类。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// "所有磁盘"指令类(作为序列化指令在网络上传输)
    /// </summary>
    [Serializable]
    public class DisksCode : BaseCode
    {
        private DiskStruct[] disks;
        /// <summary>
        /// 磁盘数组
        /// </summary>
        public DiskStruct[] Disks
        {
            get { return disks; }
            set { disks = value; }
        }

        public DisksCode() { base.Head = CodeHead.SEND_DISKS; }
    }
}
