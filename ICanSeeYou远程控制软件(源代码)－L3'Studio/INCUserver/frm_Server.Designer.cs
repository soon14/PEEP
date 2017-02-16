namespace INCUserver
{
    partial class frm_Server
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Server));
            this.ltv_Log = new System.Windows.Forms.ListView();
            this.col_Datetime = new System.Windows.Forms.ColumnHeader();
            this.col_IP = new System.Windows.Forms.ColumnHeader();
            this.col_Event = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_Message = new System.Windows.Forms.ToolStripStatusLabel();
            this.grb_Log = new System.Windows.Forms.GroupBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cnm_notifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开OToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.cnm_notifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltv_Log
            // 
            this.ltv_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Datetime,
            this.col_IP,
            this.col_Event});
            this.ltv_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ltv_Log.Location = new System.Drawing.Point(0, 20);
            this.ltv_Log.Name = "ltv_Log";
            this.ltv_Log.Size = new System.Drawing.Size(589, 340);
            this.ltv_Log.TabIndex = 1;
            this.ltv_Log.UseCompatibleStateImageBehavior = false;
            this.ltv_Log.View = System.Windows.Forms.View.Details;
            // 
            // col_Datetime
            // 
            this.col_Datetime.Text = "时间";
            this.col_Datetime.Width = 125;
            // 
            // col_IP
            // 
            this.col_IP.Text = "IP";
            this.col_IP.Width = 168;
            // 
            // col_Event
            // 
            this.col_Event.Text = "操作";
            this.col_Event.Width = 291;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Message});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Message
            // 
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 17);
            // 
            // grb_Log
            // 
            this.grb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_Log.Location = new System.Drawing.Point(0, 0);
            this.grb_Log.Name = "grb_Log";
            this.grb_Log.Size = new System.Drawing.Size(589, 382);
            this.grb_Log.TabIndex = 3;
            this.grb_Log.TabStop = false;
            this.grb_Log.Text = "操作记录";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cnm_notifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ICanSeeYou服务端";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // cnm_notifyIcon
            // 
            this.cnm_notifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem3,
            this.关于AToolStripMenuItem1,
            this.退出EToolStripMenuItem1});
            this.cnm_notifyIcon.Name = "cnm_notifyIcon";
            this.cnm_notifyIcon.Size = new System.Drawing.Size(153, 92);
            // 
            // 打开OToolStripMenuItem3
            // 
            this.打开OToolStripMenuItem3.Image = global::INCUserver.Properties.Resources.Ice;
            this.打开OToolStripMenuItem3.Name = "打开OToolStripMenuItem3";
            this.打开OToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.打开OToolStripMenuItem3.Text = "打开(&O)";
            this.打开OToolStripMenuItem3.Click += new System.EventHandler(this.打开OToolStripMenuItem3_Click);
            // 
            // 关于AToolStripMenuItem1
            // 
            this.关于AToolStripMenuItem1.Image = global::INCUserver.Properties.Resources.info;
            this.关于AToolStripMenuItem1.Name = "关于AToolStripMenuItem1";
            this.关于AToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.关于AToolStripMenuItem1.Text = "关于(&A)";
            this.关于AToolStripMenuItem1.Click += new System.EventHandler(this.关于AToolStripMenuItem1_Click);
            // 
            // 退出EToolStripMenuItem1
            // 
            this.退出EToolStripMenuItem1.Image = global::INCUserver.Properties.Resources.Exit;
            this.退出EToolStripMenuItem1.Name = "退出EToolStripMenuItem1";
            this.退出EToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.退出EToolStripMenuItem1.Text = "退出(&E)";
            this.退出EToolStripMenuItem1.Click += new System.EventHandler(this.退出EToolStripMenuItem1_Click);
            // 
            // frm_Server
            // 
            this.ClientSize = new System.Drawing.Size(589, 382);
            this.Controls.Add(this.ltv_Log);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grb_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Server";
            this.ShowInTaskbar = false;
            this.Text = "ICanSeeYou服务端";
            this.Resize += new System.EventHandler(this.frm_server_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_server_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cnm_notifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ltv_Log;
        private System.Windows.Forms.ColumnHeader col_Datetime;
        private System.Windows.Forms.ColumnHeader col_IP;
        private System.Windows.Forms.ColumnHeader col_Event;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Message;
        private System.Windows.Forms.GroupBox grb_Log;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cnm_notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem1;
    }
}

