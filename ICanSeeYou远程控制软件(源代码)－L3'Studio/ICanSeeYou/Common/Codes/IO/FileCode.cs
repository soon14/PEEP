/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：FileCode.cs
        // 文件功能描述：涉及到文件管理的指令－文件指令类。
//----------------------------------------------------------------*/

using System;
using System.IO;

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 文件指令类
    /// </summary>
    [Serializable]
    public class FileCode : BaseCode
    {
        private string fileName;
        private string savePath;
        private byte[] mbyte;
        /// <summary>
        /// 文件字节数
        /// </summary>
        private long fileLength;
        /// <summary>
        /// 文件流字节块
        /// </summary>
        public byte[] Mbyte
        {
            get { return mbyte; }
            set { mbyte = value; }
        }
        /// <summary>
        /// 保存路径
        /// </summary>
        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }
        /// <summary>
        /// 文件指令类的构造函数
        /// </summary>
        /// <param name="fileName"></param>
        public FileCode(string fileName)
        {
            this.fileName = fileName;
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        public void readFile()
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            fileLength = fileStream.Length;
            mbyte = new byte[fileLength];
            int m = 0;
            int startmbyte = 0;
            int allmybyte = (int)fileLength;
            do
            {
                m = fileStream.Read(mbyte, startmbyte, allmybyte);
                startmbyte += m;
                allmybyte -= m;

            } while (m > 0);
            fileStream.Close();
        }
        /// <summary>
        ///  保存文件
        /// </summary>
        public void SaveFile()
        {
            try
            {
                FileStream output = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write);
                output.Write(mbyte, 0, (int)fileLength);
                output.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.ToString());
            }
        }
    }
}
