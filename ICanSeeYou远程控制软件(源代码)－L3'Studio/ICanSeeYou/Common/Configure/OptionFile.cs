/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：Option.cs
        // 文件功能描述：配置类。
//----------------------------------------------------------------*/
/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：OptionFile.cs
        // 文件功能描述：客户端的配置文件类。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Configure
{
    /// <summary>
    /// 客户端的配置文件
    /// </summary>
    [Serializable]
    public class OptionFile : PassWordFile
    {
        private string updatedFile;
        /// <summary>
        /// 服务端更新文件
        /// </summary>
        public string UpdatedFile
        {
            get { return updatedFile; }
            set { updatedFile = value; }
        }
        private string updatedVersion;
        /// <summary>
        /// 服务端更新文件的版本
        /// </summary>
        public string UpdatedVersion
        {
            get { return updatedVersion; }
            set { updatedVersion = value; }
        }
    }
}
