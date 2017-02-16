/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ExplorerCode.cs
        // 文件功能描述：涉及到文件管理的指令－"我的电脑"指令类。
//----------------------------------------------------------------*/

using System;

namespace ICanSeeYou.Codes
{   
    /// <summary>
    /// "我的电脑"指令类(作为序列化指令在网络上传输)
    /// </summary>
    [Serializable]
    public class ExplorerCode:BaseCode
    {
        private string path;
        private bool available;
        private DirectoryStruct[] directorys;
        private FileStruct[] files;

        /// <summary>
        /// 当前路径有效
        /// </summary>
        public bool Available
        {
            get { return available; }
        }

        /// <summary>
        /// 文件夹数组
        /// </summary>
        public DirectoryStruct[] Directorys
        {
            get { return directorys; }
        }

        /// <summary>
        /// 文件数组
        /// </summary>
        public FileStruct[] Files
        {
            get { return files; }
        }

        /// <summary>
        /// 当前路径
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        /// <summary>
        /// 创建"我的电脑"指令类的实例
        /// </summary>
        /// <param name="curPath"></param>
        public ExplorerCode()
        {
            base.Head = CodeHead.SEND_DIRECTORY_DETIAL;
        }
        /// <summary>
        /// 进入指定文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public void Enter(string curPath)
        {
            path = curPath;
            try
            {
                if (!System.IO.Directory.Exists(curPath))
                { //当前路径无效
                    available = false;
                    return;
                }
                //获取当前路径的所有文件夹
                string[] directoryArray = System.IO.Directory.GetDirectories(curPath);
                directorys = new DirectoryStruct[directoryArray.Length]; 
                for(int i=0;i<directoryArray.Length;i++)
                    directorys[i] = new DirectoryStruct(directoryArray[i]);
                //获取当前路径的所有文件
                string[] fileArray = System.IO.Directory.GetFiles(curPath);
                files = new FileStruct[fileArray.Length];
                for (int i = 0; i < files.Length; i++)
                    files[i] = new FileStruct(fileArray[i]);
                available = true;
            }
            catch 
            {
                available = false;
            }
        }        
    }
}
