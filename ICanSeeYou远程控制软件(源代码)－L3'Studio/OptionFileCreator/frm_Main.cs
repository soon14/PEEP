using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptionFileCreator
{
    /// <summary>
    /// 说明:本程序(配置文件生成器)只用于INCU发布时初始化服务端和客户端的密码,或作为软件调试之用.
    /// 注意:INCU发布后不能附带此程序.
    /// </summary>
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_CreateServerPwd_Click(object sender, EventArgs e)
        {
            ICanSeeYou.Configure.PassWord.Save(ICanSeeYou.Common.Constant.PassWordFilename, ICanSeeYou.Configure.PassWord.MD5Encrypt(txt_ServerPassWord.Text));
        }

        private void btn_CreateClientPwd_Click(object sender, EventArgs e)
        {
            ICanSeeYou.Configure.OptionManager.ChangePassWord(ICanSeeYou.Configure.PassWord.MD5Encrypt(txt_ClientPassWord.Text));
        }
    }
}