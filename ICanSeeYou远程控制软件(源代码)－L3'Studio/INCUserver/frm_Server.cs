using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using ICanSeeYou.Common;
using ICanSeeYou.Configure;

namespace INCUserver
{
    /// <summary>
    /// INCU服务端
    /// </summary>
    public partial class frm_Server : Form
    {
        //服务端
        private Servers.Servers server;

        public frm_Server()
        {
            InitializeComponent();
            Run();
        }

        /// <summary>
        /// 程序标题
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                // 获取此程序集上的所有 Title 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // 如果至少有一个 Title 属性
                if (attributes.Length > 0)
                {
                    // 请选择第一个属性
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // 如果该属性为非空字符串，则将其返回
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // 如果没有 Title 属性，或者 Title 属性为一个空字符串，则返回 .exe 的名称
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        /// <summary>
        /// 程序版本
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// 程序产品名
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                // 获取此程序集上的所有 Product 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // 如果 Product 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Product 属性，则返回该属性的值
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// 运行
        /// </summary>
        private void Run()
        {
            this.WindowState=FormWindowState.Minimized;
            server = new Servers.Servers(Constant.Port_Main, Constant.Port_File,  Constant.Port_Screen);
            server.ltv_Log = ltv_Log;
            server.lbl_Message = lbl_Message;
            server.Version = AssemblyVersion;
            server.ProductName = AssemblyProduct;
            try
            {
                server.Run();
            }
            catch
            {
                CloseServer();
            }
        }
        /// <summary>
        /// 关闭程序
        /// </summary>
        private void CloseServer()
        {
            try
            {
                if (server != null)
                    server.Close();
                System.Environment.Exit(System.Environment.ExitCode);
                Application.ExitThread();
                Application.Exit();
            }
            catch { }
        }

        private void frm_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            退出EToolStripMenuItem1_Click(sender, e);
        }

        private void 关于AToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frm_AboutINCU().Show();
        }

        private void 退出EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (server.ExitPassWord == "") CloseServer();
            else
            {
                frm_PassWord passwordForm = new frm_PassWord();
                DialogResult result = passwordForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (server.ExitPassWord == PassWord.MD5Encrypt(passwordForm.Password))
                    {
                        if (!System.IO.File.Exists(Constant.PassWordFilename))
                            PassWord.Save(Constant.PassWordFilename, server.ExitPassWord);
                        CloseServer();
                    }
                    else
                        MessageBox.Show("密码错误!", "密码错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void 打开OToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
                this.WindowState = FormWindowState.Normal;
        }

        private void frm_server_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Visible = false;
        }

        private void frm_Server_Load(object sender, EventArgs e)
        {

        }
    }
}