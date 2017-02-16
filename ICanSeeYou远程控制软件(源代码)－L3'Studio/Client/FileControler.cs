/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：FileControler.cs
        // 文件功能描述：原程文件管理类，具有文件上传下载功能。
//----------------------------------------------------------------*/

using System;
using System.Threading;
using System.Windows.Forms;

using ICanSeeYou.Bases;
using ICanSeeYou.Codes;
using ICanSeeYou.Common;

namespace Client
{
    /// <summary>
    /// 更新文件视图的委托
    /// </summary>
    /// <param name="IsServer">是否服务端的文件视图</param>
   public delegate void RefrushEvent(bool IsServer);

    /// <summary>
    /// 文件控制类
    /// </summary>
    public class FileControler : BaseControler
    {
        /// <summary>
        /// 文件控制端线程
        /// </summary>
        private Thread fileThread;

        private string sourceFile;
        private string destinationFile;        
        private bool isDownload;

        /// <summary>
        /// 更新文件视图事件
        /// </summary>
        private RefrushEvent refrush;


        /// <summary>
        /// 值为true时表示下载,false表示上传
        /// </summary>
        public bool IsDownload
        {
            get { return isDownload; }
            set { isDownload = value; }
        }

        /// <summary>
        /// 原文件
        /// </summary>
        public string SourceFile
        {
            get { return sourceFile; }
            set { sourceFile = value; }
        }

        /// <summary>
        /// 目标文件
        /// </summary>
        public string DestinationFile
        {
            get { return destinationFile; }
            set { destinationFile = value; }
        }

        /// <summary>
        /// 更新文件视图事件
        /// </summary>
        public RefrushEvent Refrush
        {
            get { return refrush; }
            set { refrush = value; }
        }

        /// <summary>
        /// 返回一个文件控制端的实例
        /// </summary>
        /// <param name="serverAddress">文件服务端IP</param>
        /// <param name="port">端口</param>
        public FileControler(System.Net.IPAddress serverAddress, int port)
            : base(serverAddress, port)
        {
            base.Execute = new ExecuteCodeEvent(fileExecuteCode);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="msg">指令</param>
        private void fileExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead.CONNECT_OK:
                    if (isDownload)
                        IO.DownloadFile(sender, sourceFile, destinationFile);
                    else
                        IO.ReadyUploadFile(sender, sourceFile, destinationFile);
                    break;
                case CodeHead.SEND_FILE:
                    IO.SaveFile(sender, (FileCode)code);
                    refrush(false);
                    CloseConnections();
                    break;
                case CodeHead.GET_FILE:
                  //  FileManager.UploadFile(sender, (FileStructCode)code);
                    break;
                case CodeHead.FILE_TRAN_END:
                    refrush(true);
                    CloseConnections();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///  打开文件控制端
        /// </summary>
        public void Open()
        {
            if (fileThread != null && fileThread.IsAlive)
            {
               DialogResult result= MessageBox.Show("当前文件线程没关闭!是否关闭?","关闭线程",MessageBoxButtons.YesNo);
               if (result == DialogResult.No) 
                   return;
            }
            CloseConnections();
            ThreadStart threadStart = new ThreadStart(base.Connecting);
            threadStart += new ThreadStart(base.Run);
            fileThread = new Thread(threadStart);
            fileThread.Start();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public override void CloseConnections()
        {
            base.CloseConnections();
            if (fileThread != null && fileThread.IsAlive)
                fileThread.Abort();
        }
    }
}

