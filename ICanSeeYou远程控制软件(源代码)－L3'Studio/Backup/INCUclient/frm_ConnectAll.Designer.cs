namespace INCUclient
{
    partial class frm_ConnectAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ConnectAll));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.ipc_StartIP = new IPAddressControlLib.IPAddressControl();
            this.ipc_EndIP = new IPAddressControlLib.IPAddressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入起始IP以及结束IP:";
            // 
            // btn_Enter
            // 
            this.btn_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Enter.Location = new System.Drawing.Point(101, 101);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(87, 28);
            this.btn_Enter.TabIndex = 2;
            this.btn_Enter.Text = "确定";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // ipc_StartIP
            // 
            this.ipc_StartIP.BackColor = System.Drawing.SystemColors.Window;
            this.ipc_StartIP.Location = new System.Drawing.Point(12, 44);
            this.ipc_StartIP.MinimumSize = new System.Drawing.Size(116, 21);
            this.ipc_StartIP.Name = "ipc_StartIP";
            this.ipc_StartIP.ReadOnly = false;
            this.ipc_StartIP.Size = new System.Drawing.Size(116, 21);
            this.ipc_StartIP.TabIndex = 3;
            // 
            // ipc_EndIP
            // 
            this.ipc_EndIP.BackColor = System.Drawing.SystemColors.Window;
            this.ipc_EndIP.Location = new System.Drawing.Point(158, 44);
            this.ipc_EndIP.MinimumSize = new System.Drawing.Size(116, 21);
            this.ipc_EndIP.Name = "ipc_EndIP";
            this.ipc_EndIP.ReadOnly = false;
            this.ipc_EndIP.Size = new System.Drawing.Size(116, 21);
            this.ipc_EndIP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // frm_ConnectAll
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 155);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ipc_EndIP);
            this.Controls.Add(this.ipc_StartIP);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ConnectAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接所有安装服务端的主机";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Enter;
        private IPAddressControlLib.IPAddressControl ipc_StartIP;
        private IPAddressControlLib.IPAddressControl ipc_EndIP;
        private System.Windows.Forms.Label label3;
    }
}