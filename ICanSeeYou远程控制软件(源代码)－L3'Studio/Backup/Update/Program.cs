/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：Program.cs
        // 文件功能描述：INCU服务端用作更新的程序
//----------------------------------------------------------------*/

using System.Windows.Forms;

namespace Update
{
    /// <summary>
    /// 更新程序
    /// </summary>
    class Program
    {

        Server.ServerUpdater update;

        System.Threading.Thread updateThread;
        /// <summary>
        /// 程序主入口
        /// </summary>
        /// <param name="args">接收一个参数.其中arg[0]是服务端的程序名</param>
        static void Main(string[] args)
        {
            Program program = new Program();
            program.update = new Server.ServerUpdater(ICanSeeYou.Common.Constant.Port_Update);
            program.update.AppName = args[0];
            System.Console.WriteLine("程序名:" + args[0]);
            program.update.Close = new Server.CloseMeEvent(program.Close);
            program.updateThread = new System.Threading.Thread(new System.Threading.ThreadStart(program.update.Run));
            try
            {
                program.updateThread.Start();
            }
            catch
            {
                program.Close();
            }
        }

        /// <summary>
        /// 关闭升级程序
        /// </summary>
        public void Close()
        {
            try
            {
                if (update != null) update.CloseConnections();
                if (updateThread != null && updateThread.IsAlive) updateThread.Abort();
            }
            catch { }
            Application.ExitThread();
            Application.Exit();
        }
    }
}
