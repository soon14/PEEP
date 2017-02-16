namespace INCUclient
{
    partial class frm_Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Connection));
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rdb_IsIP = new System.Windows.Forms.RadioButton();
            this.rdb_Hostname = new System.Windows.Forms.RadioButton();
            this.txt_Hostname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipc_ServerIP = new IPAddressControlLib.IPAddressControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Enter
            // 
            this.btn_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Enter.Location = new System.Drawing.Point(25, 119);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(87, 28);
            this.btn_Enter.TabIndex = 2;
            this.btn_Enter.Text = "确定";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(163, 119);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(86, 28);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rdb_IsIP
            // 
            this.rdb_IsIP.AutoSize = true;
            this.rdb_IsIP.Checked = true;
            this.rdb_IsIP.Location = new System.Drawing.Point(41, 44);
            this.rdb_IsIP.Name = "rdb_IsIP";
            this.rdb_IsIP.Size = new System.Drawing.Size(65, 16);
            this.rdb_IsIP.TabIndex = 3;
            this.rdb_IsIP.TabStop = true;
            this.rdb_IsIP.Text = "IP地址:";
            this.rdb_IsIP.UseVisualStyleBackColor = true;
            this.rdb_IsIP.CheckedChanged += new System.EventHandler(this.rdb_IsIP_CheckedChanged);
            // 
            // rdb_Hostname
            // 
            this.rdb_Hostname.AutoSize = true;
            this.rdb_Hostname.Location = new System.Drawing.Point(41, 72);
            this.rdb_Hostname.Name = "rdb_Hostname";
            this.rdb_Hostname.Size = new System.Drawing.Size(65, 16);
            this.rdb_Hostname.TabIndex = 5;
            this.rdb_Hostname.Text = "主机名:";
            this.rdb_Hostname.UseVisualStyleBackColor = true;
            this.rdb_Hostname.CheckedChanged += new System.EventHandler(this.rdb_Hostname_CheckedChanged);
            // 
            // txt_Hostname
            // 
            this.txt_Hostname.Location = new System.Drawing.Point(112, 71);
            this.txt_Hostname.Name = "txt_Hostname";
            this.txt_Hostname.Size = new System.Drawing.Size(116, 21);
            this.txt_Hostname.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipc_ServerIP);
            this.groupBox1.Location = new System.Drawing.Point(25, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入要控制的主机IP或主机名:";
            // 
            // ipc_ServerIP
            // 
            this.ipc_ServerIP.BackColor = System.Drawing.SystemColors.Window;
            this.ipc_ServerIP.Location = new System.Drawing.Point(87, 31);
            this.ipc_ServerIP.MinimumSize = new System.Drawing.Size(116, 21);
            this.ipc_ServerIP.Name = "ipc_ServerIP";
            this.ipc_ServerIP.ReadOnly = false;
            this.ipc_ServerIP.Size = new System.Drawing.Size(116, 21);
            this.ipc_ServerIP.TabIndex = 0;
            // 
            // frm_Connection
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(284, 159);
            this.Controls.Add(this.rdb_Hostname);
            this.Controls.Add(this.txt_Hostname);
            this.Controls.Add(this.rdb_IsIP);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "建立连接";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RadioButton rdb_IsIP;
        private System.Windows.Forms.RadioButton rdb_Hostname;
        private System.Windows.Forms.TextBox txt_Hostname;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPAddressControlLib.IPAddressControl ipc_ServerIP;
    }
}