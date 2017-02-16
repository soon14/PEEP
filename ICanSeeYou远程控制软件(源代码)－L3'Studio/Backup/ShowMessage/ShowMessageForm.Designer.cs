namespace ShowMessage
{
    partial class ShowMessageForm
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
            this.FormControlTimer = new System.Windows.Forms.Timer(this.components);
            this.txt_Message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // FormControlTimer
            // 
            this.FormControlTimer.Tick += new System.EventHandler(this.FormControlTimer_Tick);
            // 
            // txt_Message
            // 
            this.txt_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_Message.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Message.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Message.ForeColor = System.Drawing.Color.Blue;
            this.txt_Message.Location = new System.Drawing.Point(0, 0);
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.ReadOnly = true;
            this.txt_Message.Size = new System.Drawing.Size(246, 187);
            this.txt_Message.TabIndex = 1;
            this.txt_Message.Text = "";
            // 
            // ShowMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(246, 187);
            this.ControlBox = false;
            this.Controls.Add(this.txt_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowMessageForm";
            this.Text = "管理员信息";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShowMessageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FormControlTimer;
        private System.Windows.Forms.RichTextBox txt_Message;

    }
}

