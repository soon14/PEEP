/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ServerUpdater.cs
        // 文件功能描述：服务端更新类，接收客户端的更新命令并调用更新模块来自动更新
//----------------------------------------------------------------*/

using System;
using System.IO;
using System.Diagnostics;

using ICanSeeYou.Codes;
using ICanSeeYou.Bases;

namespace  Server
{
    /// <summary>
    /// 关闭事件委托
    /// </summary>
    public delegate void CloseMeEvent();

    /// <summary>
    /// 服务端更新类
    /// </summary>
    public class ServerUpdater : BaseServer
    {
        /// <summary>
        /// 临时文件
        /// </summary>
        private string tempFile;

        /// <summary>
        /// 服务端程序名
        /// </summary>
        private string appName;

        /// <summary>
        /// 关闭程序的委托
        /// </summary>
        private CloseMeEvent close;

        /// <summary>
        /// 关闭程序的委托
        /// </summary>
        public CloseMeEvent Close
        {
            get { return close; }
            set { close = value; }
        }

        /// <summary>
        /// 程序名
        /// </summary>
        public string AppName
        {
            get { return appName; }
            set { appName = value; }
        }

        /// <summary>
        /// 返回一个文件服务端实例
        /// </summary>
        /// <param name="port">文件传输端口</param>
        public ServerUpdater(int port)
            : base(port)
        {
            base.Execute = new ExecuteCodeEvent(updaterExecuteCode);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="msg">指令</param>
        private void updaterExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead.SEND_FILE:
                    //更新服务端
                    UpdateApp(sender, code);
                    break;
                case CodeHead .FILE_TRAN_END:
                    CloseMe(sender);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 获取系统临时文件夹
        /// </summary>
        /// <returns></returns>
        private string GetSystemTempDir()
        {
            return "";// "%temp%\\";
        }

        /// <summary>
        ///升级程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="code"></param>
        private void UpdateApp(BaseCommunication sender, Code code)
        {
            FileCode fileCode = code as FileCode;
            if (fileCode != null)
            {
                string fileName=fileCode.SavePath;
                tempFile=GetSystemTempDir() +fileName + ".tmp";
                System.Console.WriteLine("下载更新包:" + tempFile);
                fileCode.SavePath = tempFile;
                ICanSeeYou.Common.IO.SaveFile(sender, fileCode);
                int index = appName.IndexOf(".");
                //获取服务端线程名
                string process=appName.Substring(0, index );
                System.Console.WriteLine("关闭当前服务端线程:" +process );
                bool cankill = false;
                cankill = CloseApplication(process);
                System.Console.WriteLine("正在关闭服务端线程...");
                System.Threading.Thread.Sleep(500);
                if (cankill)
                {
                    string savedFile = Directory.GetCurrentDirectory() + "\\" + fileName;
                    System.Console.WriteLine("更新文件:" + savedFile);
                    Updatefile(tempFile, savedFile);
                    System.Console.WriteLine("重新启动服务端程序:" + Directory.GetCurrentDirectory() + "\\" + appName);
                    restart(Directory.GetCurrentDirectory() + "\\" + appName);
                }
                else
                    System.Console.WriteLine("无法关闭低版本的服务端程序!");
                System.Console.WriteLine("关闭升级程序!");
                CloseMe(sender);
            }
        }

        /// <summary>
        /// 关闭自身程序
        /// </summary>
        /// <param name="sender"></param>
        private void CloseMe(BaseCommunication sender)
        {
            BaseCode code = new BaseCode();
            code.Head = CodeHead.FILE_TRAN_END;
            sender.SendCode(code);
        }

        /// <summary>
        /// 关闭指定程序
        /// </summary>
        /// <param name="fileName">程序的名称</param>
        /// <returns></returns>
        public static bool CloseApplication(string process)
        {
            try
            {
                Process[] localByName = Process.GetProcessesByName(process);
                //用循环的方式关进程
                foreach (Process proc in localByName)
                {
                    proc.WaitForExit(100);
                    proc.Kill();
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 更新程序,输入的参数为升级程序的路径和原来程序的路径
        /// </summary>
        private void Updatefile(string tempfile, string Tofile)
        {
            if (File.Exists(Tofile))
                File.Delete(Tofile);
            File.Copy(tempfile, Tofile);
            if (File.Exists(tempfile))
                File.Delete(tempfile);
        }
        /// <summary>
        /// 重新启动主程序,传入的参数为程序的名称
        /// </summary>
        private void restart(string excuteName)
        {
            try
            {
                System.Diagnostics.Process.Start(excuteName);
            }
            catch
            {
            }
        }
    }
}
