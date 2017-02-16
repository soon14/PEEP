/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：OptionManager.cs
        // 文件功能描述：配置文件管理类。
//----------------------------------------------------------------*/

using ICanSeeYou.Common;

namespace ICanSeeYou.Configure
{
    /// <summary>
    /// 配置文件管理类
    /// </summary>
    public class OptionManager
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static bool ChangePassWord(string pwd)
        {
            Option option = new Option(Constant.OptionFilename, pwd);
            return option.Write();
        }
        /// <summary>
        /// 修改更新文件的路径
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        public static bool ChangeUpdatedFile(string fileName, string version)
        {
            Option option = new Option(Constant.OptionFilename, fileName, version);
            return option.Write();
        }
        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="fileName">文件</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        public static bool Change(string pwd, string fileName, string version)
        {
            Option option = new Option(Constant.OptionFilename, pwd, fileName, version);
            return option.Write();
        }
    }
}
