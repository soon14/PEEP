/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：PassWordFile.cs
        // 文件功能描述：密码文件结构(保存已经经过加密后的密码)。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Configure
{
    /// <summary>
    /// 密码文件结构(保存已经经过加密后的密码)
    /// </summary>
    [Serializable]
    public class PassWordFile
    {
        private string passWord;
        /// <summary>
        /// 经过加密后的密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
    }
}
