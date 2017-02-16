/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ShowMessageForm.cs
        // 文件功能描述：动态效果显示文本信息（起提醒作用）
//----------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShowMessage
{
    /// <summary>
    /// 信息框
    /// </summary>
    public partial class ShowMessageForm : Form
    {
        /// <summary>
        /// 当前的时间
        /// </summary>
        private int times;

        /// <summary>
        /// 总时间(上升时间+显示时间)
        /// </summary>
        private int allTimes;

        /// <summary>
        /// 开始上升前的高度
        /// </summary>
        private int startTop;

        /// <summary>
        /// 单位时间内信息框上升的高度
        /// </summary>
        private int step;

        public ShowMessageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化各个参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessageForm_Load(object sender, EventArgs e)
        {
            times = 0;
            allTimes = 25+ (int)(txt_Message.Text.Length * 10 / 2.5);
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            startTop=screenSize.Height -42;
            step=this.Height/25;
            this.Opacity = 0.00;
            this.Left = screenSize.Width - this.Width;
            this.Top = startTop;
            this.TopMost = true;
            txt_Message.ReadOnly = true;
            txt_Message.Cursor = Cursors.Hand;
            txt_Message.Enabled = false;
            FormControlTimer.Enabled = true;
        }

        /// <summary>
        /// 时钟控制信息框上升
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormControlTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.00)
            {
                this.Opacity += 0.04;
                this.Top -= step;
            }
            if (++times > allTimes) this.Close();
        }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message
        {
            set
            {
                txt_Message.Text = value;
            }
        }
    }
}