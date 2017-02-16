namespace OptionFileCreator
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CreateServerPwd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ServerPassWord = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ClientPassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CreateClientPwd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码:";
            // 
            // btn_CreateServerPwd
            // 
            this.btn_CreateServerPwd.Location = new System.Drawing.Point(163, 63);
            this.btn_CreateServerPwd.Name = "btn_CreateServerPwd";
            this.btn_CreateServerPwd.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateServerPwd.TabIndex = 1;
            this.btn_CreateServerPwd.Text = "生成";
            this.btn_CreateServerPwd.UseVisualStyleBackColor = true;
            this.btn_CreateServerPwd.Click += new System.EventHandler(this.btn_CreateServerPwd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ServerPassWord);
            this.groupBox1.Controls.Add(this.btn_CreateServerPwd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端";
            // 
            // txt_ServerPassWord
            // 
            this.txt_ServerPassWord.Location = new System.Drawing.Point(88, 27);
            this.txt_ServerPassWord.Name = "txt_ServerPassWord";
            this.txt_ServerPassWord.Size = new System.Drawing.Size(150, 21);
            this.txt_ServerPassWord.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ClientPassWord);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_CreateClientPwd);
            this.groupBox2.Location = new System.Drawing.Point(10, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户端";
            // 
            // txt_ClientPassWord
            // 
            this.txt_ClientPassWord.Location = new System.Drawing.Point(88, 20);
            this.txt_ClientPassWord.Name = "txt_ClientPassWord";
            this.txt_ClientPassWord.Size = new System.Drawing.Size(150, 21);
            this.txt_ClientPassWord.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码:";
            // 
            // btn_CreateClientPwd
            // 
            this.btn_CreateClientPwd.Location = new System.Drawing.Point(163, 58);
            this.btn_CreateClientPwd.Name = "btn_CreateClientPwd";
            this.btn_CreateClientPwd.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateClientPwd.TabIndex = 1;
            this.btn_CreateClientPwd.Text = "生成";
            this.btn_CreateClientPwd.UseVisualStyleBackColor = true;
            this.btn_CreateClientPwd.Click += new System.EventHandler(this.btn_CreateClientPwd_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "说明:本程序(配置文件生成器)只用于INCU发布时初始化服务端和客户端的密码,或作为软件调试之用.不能被用作其它非正当用途.";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 282);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Main";
            this.Text = "配置文件生成器(INCU发布后不能附带此程序)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CreateServerPwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ServerPassWord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_CreateClientPwd;
        private System.Windows.Forms.TextBox txt_ClientPassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

