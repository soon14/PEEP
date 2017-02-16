using System;
using System.Runtime.InteropServices;

namespace ICanSeeYou.Windows
{
    /// <summary>
    /// Windows管理类(主要有关机重启等功能,API函数实现)
    /// </summary>
    public class WindowsManager
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
            ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        /// <summary>
        /// 注销
        /// </summary>
        internal const int EWX_LOGOFF = 0x00000000;
        /// <summary>
        /// 关机
        /// </summary>
        internal const int EWX_SHUTDOWN = 0x00000001;
        /// <summary>
        /// 重启
        /// </summary>
        internal const int EWX_REBOOT = 0x00000002;

        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;
        internal const int EWX_FORCEIFHUNG = 0x00000010;

        private static void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }
        /// <summary>
        /// 关机
        /// </summary>
        public static void ShutDown()
        {
            // 修改 EWX_SHUTDOWN 或者 EWX_LOGOFF, EWX_REBOOT等实现不同得功能。
            // 在XP下可以看到帮助信息，以得到不同得参数
            // SHUTDOWN /?
            DoExitWin(EWX_SHUTDOWN);
        }
        /// <summary>
        /// 重启
        /// </summary>
        public static void Reboot()
        {
            DoExitWin(EWX_REBOOT);
        }
    }
}
