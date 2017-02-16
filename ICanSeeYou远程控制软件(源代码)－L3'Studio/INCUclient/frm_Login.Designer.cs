namespace INCUclient
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Check = new System.Windows.Forms.Label();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.pic_backgroud = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_backgroud)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(121, 102);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(168, 21);
            this.txt_password.TabIndex = 0;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(37, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理员密码:";
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Login.Location = new System.Drawing.Point(78, 165);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 24);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "登陆(&E)";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(197, 166);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "取消(&C)";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Check
            // 
            this.lbl_Check.AutoSize = true;
            this.lbl_Check.BackColor = System.Drawing.Color.AliceBlue;
            this.lbl_Check.Location = new System.Drawing.Point(119, 137);
            this.lbl_Check.Name = "lbl_Check";
            this.lbl_Check.Size = new System.Drawing.Size(0, 12);
            this.lbl_Check.TabIndex = 6;
            // 
            // pic_logo
            // 
            this.pic_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_logo.Image = global::INCUclient.Properties.Resources.logo;
            this.pic_logo.Location = new System.Drawing.Point(0, 0);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(356, 70);
            this.pic_logo.TabIndex = 3;
            this.pic_logo.TabStop = false;
            // 
            // pic_backgroud
            // 
            this.pic_backgroud.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic_backgroud.Image = global::INCUclient.Properties.Resources.backgroud2;
            this.pic_backgroud.Location = new System.Drawing.Point(0, 69);
            this.pic_backgroud.Name = "pic_backgroud";
            this.pic_backgroud.Size = new System.Drawing.Size(356, 172);
            this.pic_backgroud.TabIndex = 8;
            this.pic_backgroud.TabStop = false;
            // 
            // frm_Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(356, 241);
            this.Controls.Add(this.lbl_Check);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.pic_backgroud);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员登陆框";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_backgroud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Check;
        private System.Windows.Forms.PictureBox pic_backgroud;
    }
}