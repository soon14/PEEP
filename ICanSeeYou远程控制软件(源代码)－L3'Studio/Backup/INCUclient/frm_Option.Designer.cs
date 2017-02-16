namespace INCUclient
{
    partial class frm_Option
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Option));
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_ServerPassWord = new System.Windows.Forms.TextBox();
            this.tbs_Server = new System.Windows.Forms.TabControl();
            this.tab_PassWord = new System.Windows.Forms.TabPage();
            this.lbl_ServerError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ServerPassWordSure = new System.Windows.Forms.TextBox();
            this.tab_Updat = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.mtb_Version = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_searchpath = new System.Windows.Forms.Button();
            this.txt_UpdatedFile = new System.Windows.Forms.TextBox();
            this.tbc_Option = new System.Windows.Forms.TabControl();
            this.tab_Client = new System.Windows.Forms.TabPage();
            this.lbl_ClientError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ClientPassWordSure = new System.Windows.Forms.TextBox();
            this.txt_ClientPassWord = new System.Windows.Forms.TextBox();
            this.tab_Server = new System.Windows.Forms.TabPage();
            this.tbs_Server.SuspendLayout();
            this.tab_PassWord.SuspendLayout();
            this.tab_Updat.SuspendLayout();
            this.tbc_Option.SuspendLayout();
            this.tab_Client.SuspendLayout();
            this.tab_Server.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Enter
            // 
            this.btn_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Enter.Location = new System.Drawing.Point(50, 232);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(75, 23);
            this.btn_Enter.TabIndex = 7;
            this.btn_Enter.Text = "确定";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(219, 232);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cansle_Click);
            // 
            // txt_ServerPassWord
            // 
            this.txt_ServerPassWord.Location = new System.Drawing.Point(83, 47);
            this.txt_ServerPassWord.Name = "txt_ServerPassWord";
            this.txt_ServerPassWord.PasswordChar = '*';
            this.txt_ServerPassWord.Size = new System.Drawing.Size(180, 21);
            this.txt_ServerPassWord.TabIndex = 3;
            this.txt_ServerPassWord.TextChanged += new System.EventHandler(this.txt_PassWord_TextChanged);
            // 
            // tbs_Server
            // 
            this.tbs_Server.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbs_Server.Controls.Add(this.tab_PassWord);
            this.tbs_Server.Controls.Add(this.tab_Updat);
            this.tbs_Server.HotTrack = true;
            this.tbs_Server.Location = new System.Drawing.Point(3, 16);
            this.tbs_Server.Name = "tbs_Server";
            this.tbs_Server.SelectedIndex = 0;
            this.tbs_Server.Size = new System.Drawing.Size(329, 165);
            this.tbs_Server.TabIndex = 2;
            // 
            // tab_PassWord
            // 
            this.tab_PassWord.Controls.Add(this.lbl_ServerError);
            this.tab_PassWord.Controls.Add(this.label6);
            this.tab_PassWord.Controls.Add(this.label5);
            this.tab_PassWord.Controls.Add(this.label2);
            this.tab_PassWord.Controls.Add(this.txt_ServerPassWordSure);
            this.tab_PassWord.Controls.Add(this.txt_ServerPassWord);
            this.tab_PassWord.Location = new System.Drawing.Point(4, 24);
            this.tab_PassWord.Name = "tab_PassWord";
            this.tab_PassWord.Padding = new System.Windows.Forms.Padding(3);
            this.tab_PassWord.Size = new System.Drawing.Size(321, 137);
            this.tab_PassWord.TabIndex = 0;
            this.tab_PassWord.Text = "退出密码";
            this.tab_PassWord.UseVisualStyleBackColor = true;
            // 
            // lbl_ServerError
            // 
            this.lbl_ServerError.AutoSize = true;
            this.lbl_ServerError.ForeColor = System.Drawing.Color.Red;
            this.lbl_ServerError.Location = new System.Drawing.Point(28, 112);
            this.lbl_ServerError.Name = "lbl_ServerError";
            this.lbl_ServerError.Size = new System.Drawing.Size(11, 12);
            this.lbl_ServerError.TabIndex = 5;
            this.lbl_ServerError.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "重新输入：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "    在下列框中填入密码,则服务端退出时需要输入密码\r\n才能退出";
            // 
            // txt_ServerPassWordSure
            // 
            this.txt_ServerPassWordSure.Location = new System.Drawing.Point(83, 74);
            this.txt_ServerPassWordSure.Name = "txt_ServerPassWordSure";
            this.txt_ServerPassWordSure.PasswordChar = '*';
            this.txt_ServerPassWordSure.Size = new System.Drawing.Size(180, 21);
            this.txt_ServerPassWordSure.TabIndex = 4;
            this.txt_ServerPassWordSure.TextChanged += new System.EventHandler(this.txt_PassWord_TextChanged);
            // 
            // tab_Updat
            // 
            this.tab_Updat.Controls.Add(this.label7);
            this.tab_Updat.Controls.Add(this.mtb_Version);
            this.tab_Updat.Controls.Add(this.label4);
            this.tab_Updat.Controls.Add(this.label3);
            this.tab_Updat.Controls.Add(this.btn_searchpath);
            this.tab_Updat.Controls.Add(this.txt_UpdatedFile);
            this.tab_Updat.Location = new System.Drawing.Point(4, 24);
            this.tab_Updat.Name = "tab_Updat";
            this.tab_Updat.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Updat.Size = new System.Drawing.Size(321, 137);
            this.tab_Updat.TabIndex = 1;
            this.tab_Updat.Text = "升级文件";
            this.tab_Updat.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "*升级的版本比以前高才有效";
            // 
            // mtb_Version
            // 
            this.mtb_Version.Location = new System.Drawing.Point(48, 65);
            this.mtb_Version.Name = "mtb_Version";
            this.mtb_Version.Size = new System.Drawing.Size(100, 21);
            this.mtb_Version.TabIndex = 6;
            this.mtb_Version.Text = "1.0.0.0";
            this.mtb_Version.TextChanged += new System.EventHandler(this.mtb_Version_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "路径:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "版本:";
            // 
            // btn_searchpath
            // 
            this.btn_searchpath.Location = new System.Drawing.Point(246, 27);
            this.btn_searchpath.Name = "btn_searchpath";
            this.btn_searchpath.Size = new System.Drawing.Size(69, 23);
            this.btn_searchpath.TabIndex = 1;
            this.btn_searchpath.Text = "浏览...";
            this.btn_searchpath.UseVisualStyleBackColor = true;
            this.btn_searchpath.Click += new System.EventHandler(this.btn_searchpath_Click);
            // 
            // txt_UpdatedFile
            // 
            this.txt_UpdatedFile.Location = new System.Drawing.Point(48, 27);
            this.txt_UpdatedFile.Name = "txt_UpdatedFile";
            this.txt_UpdatedFile.Size = new System.Drawing.Size(191, 21);
            this.txt_UpdatedFile.TabIndex = 5;
            // 
            // tbc_Option
            // 
            this.tbc_Option.Controls.Add(this.tab_Client);
            this.tbc_Option.Controls.Add(this.tab_Server);
            this.tbc_Option.Location = new System.Drawing.Point(12, 13);
            this.tbc_Option.Name = "tbc_Option";
            this.tbc_Option.SelectedIndex = 0;
            this.tbc_Option.Size = new System.Drawing.Size(346, 202);
            this.tbc_Option.TabIndex = 6;
            // 
            // tab_Client
            // 
            this.tab_Client.Controls.Add(this.lbl_ClientError);
            this.tab_Client.Controls.Add(this.label1);
            this.tab_Client.Controls.Add(this.label8);
            this.tab_Client.Controls.Add(this.label9);
            this.tab_Client.Controls.Add(this.txt_ClientPassWordSure);
            this.tab_Client.Controls.Add(this.txt_ClientPassWord);
            this.tab_Client.Location = new System.Drawing.Point(4, 21);
            this.tab_Client.Name = "tab_Client";
            this.tab_Client.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Client.Size = new System.Drawing.Size(338, 177);
            this.tab_Client.TabIndex = 0;
            this.tab_Client.Text = "客户端";
            this.tab_Client.UseVisualStyleBackColor = true;
            // 
            // lbl_ClientError
            // 
            this.lbl_ClientError.AutoSize = true;
            this.lbl_ClientError.ForeColor = System.Drawing.Color.Red;
            this.lbl_ClientError.Location = new System.Drawing.Point(43, 145);
            this.lbl_ClientError.Name = "lbl_ClientError";
            this.lbl_ClientError.Size = new System.Drawing.Size(11, 12);
            this.lbl_ClientError.TabIndex = 10;
            this.lbl_ClientError.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "重新输入：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "密码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(299, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "    在下列框中填入密码,则客户端登陆时需要输入密码\r\n才能使用";
            // 
            // txt_ClientPassWordSure
            // 
            this.txt_ClientPassWordSure.Location = new System.Drawing.Point(98, 106);
            this.txt_ClientPassWordSure.Name = "txt_ClientPassWordSure";
            this.txt_ClientPassWordSure.PasswordChar = '*';
            this.txt_ClientPassWordSure.Size = new System.Drawing.Size(180, 21);
            this.txt_ClientPassWordSure.TabIndex = 1;
            this.txt_ClientPassWordSure.TextChanged += new System.EventHandler(this.txt_ClientPassWordSure_TextChanged);
            // 
            // txt_ClientPassWord
            // 
            this.txt_ClientPassWord.Location = new System.Drawing.Point(98, 79);
            this.txt_ClientPassWord.Name = "txt_ClientPassWord";
            this.txt_ClientPassWord.PasswordChar = '*';
            this.txt_ClientPassWord.Size = new System.Drawing.Size(180, 21);
            this.txt_ClientPassWord.TabIndex = 0;
            // 
            // tab_Server
            // 
            this.tab_Server.Controls.Add(this.tbs_Server);
            this.tab_Server.Location = new System.Drawing.Point(4, 21);
            this.tab_Server.Name = "tab_Server";
            this.tab_Server.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Server.Size = new System.Drawing.Size(338, 177);
            this.tab_Server.TabIndex = 1;
            this.tab_Server.Text = "服务端";
            this.tab_Server.UseVisualStyleBackColor = true;
            // 
            // frm_Option
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(373, 272);
            this.Controls.Add(this.tbc_Option);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Enter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Option";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_Option_Load);
            this.tbs_Server.ResumeLayout(false);
            this.tab_PassWord.ResumeLayout(false);
            this.tab_PassWord.PerformLayout();
            this.tab_Updat.ResumeLayout(false);
            this.tab_Updat.PerformLayout();
            this.tbc_Option.ResumeLayout(false);
            this.tab_Client.ResumeLayout(false);
            this.tab_Client.PerformLayout();
            this.tab_Server.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_ServerPassWord;
        private System.Windows.Forms.TabControl tbs_Server;
        private System.Windows.Forms.TabPage tab_PassWord;
        private System.Windows.Forms.TabPage tab_Updat;
        private System.Windows.Forms.TextBox txt_UpdatedFile;
        private System.Windows.Forms.Button btn_searchpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mtb_Version;
        private System.Windows.Forms.TextBox txt_ServerPassWordSure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tbc_Option;
        private System.Windows.Forms.TabPage tab_Client;
        private System.Windows.Forms.TabPage tab_Server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_ClientPassWordSure;
        private System.Windows.Forms.TextBox txt_ClientPassWord;
        private System.Windows.Forms.Label lbl_ServerError;
        private System.Windows.Forms.Label lbl_ClientError;
    }
}