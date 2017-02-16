using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace INCUclient
{
    /// <summary>
    /// 连接所有安装服务端的IP输入框
    /// </summary>
    public partial class frm_ConnectAll : Form
    {
        /// <summary>
        /// 获取起始IP
        /// </summary>
        public string StartIP
        {
            get { return ipc_StartIP.Text; }
        }

        /// <summary>
        /// 获取结束IP
        /// </summary>
        public string EndIP
        {
            get { return ipc_EndIP.Text; }
        }

        public frm_ConnectAll()
        {
            InitializeComponent();
            ipc_StartIP.Focus();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}