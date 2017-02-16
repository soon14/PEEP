using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace INCUclient
{
    /// <summary>
    /// 客户端密码修改情况
    /// </summary>
    public enum PwdChangType
    {
        /// <summary>
        /// 已经修改
        /// </summary>
        CHANGED,
        /// <summary>
        /// 没有修改
        /// </summary>
        CANCEL,
        /// <summary>
        /// 密码修改不成功
        /// </summary>
        UNSUCCESED,
    }
    /// <summary>
    /// 配置窗口
    /// </summary>
    public partial class frm_Option : Form
    {
        /// <summary>
        /// 升级文件的路径是否改变
        /// </summary>
        private  bool updatedFileChanged;

        /// <summary>
        /// 服务端的密码修改情况
        /// </summary>
        private PwdChangType serverPassWordChanged;

        /// <summary>
        /// 客户端密码修改情况
        /// </summary>
        private PwdChangType clientPassWordChanged;
       
        public frm_Option()
        {
            InitializeComponent();
            serverPassWordChanged = PwdChangType.CANCEL;
            clientPassWordChanged = PwdChangType.CANCEL;
            ReadOptionFile();
        }

        //读取配置文件
        private void ReadOptionFile()
        {
            ICanSeeYou.Configure.Option option= new ICanSeeYou.Configure.Option();
            ICanSeeYou.Configure.OptionFile optionFile = option.OptFile;
            txt_UpdatedFile.Text = optionFile.UpdatedFile;
            mtb_Version.Text = optionFile.UpdatedVersion;
        }

        /// <summary>
        /// 服务端的退出密码修改情况
        /// </summary>
        public PwdChangType ServerPassWordChanged
        {
            get { return serverPassWordChanged; }
            set { serverPassWordChanged = value; }
        }
        
        /// <summary>
        /// 服务端的更新文件是否修改
        /// </summary>
        public bool UpdatedFileChanged
        {
            get{return updatedFileChanged;}
        }

        /// <summary>
        /// 客户端密码修改情况
        /// </summary>
        public PwdChangType ClientPassWordChanged
        {
            get { return clientPassWordChanged; }
            set { clientPassWordChanged = value; }
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        public string UpdatedFile
        {
            get { return txt_UpdatedFile.Text; }
        }

        /// <summary>
        /// 服务端的退出密码
        /// </summary>
        public string ServerPassWord
        {
            get { return txt_ServerPassWord.Text; }
        }

        /// <summary>
        /// 更新文件的版本
        /// </summary>
        public string Version
        {
            get { return mtb_Version.Text; }
        }

        /// <summary>
        /// 客户端的登陆密码
        /// </summary>
        public string ClientPassWord
        {
            get { return txt_ClientPassWord.Text; }
        }

        //选择服务端的升级文件
        private void btn_searchpath_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.Title = "选择服务端的升级文件";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (txt_UpdatedFile.Text != fileDialog.FileName)
                    updatedFileChanged = true;
                txt_UpdatedFile.Text = fileDialog.FileName;
            }
        }

        private void txt_PassWord_TextChanged(object sender, EventArgs e)
        {
            serverPassWordChanged = PwdChangType.CHANGED;
            lbl_ServerError.Text = "";
        }

        private void mtb_Version_TextChanged(object sender, EventArgs e)
        {
            updatedFileChanged=true;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (txt_ServerPassWord.Text != txt_ServerPassWordSure.Text)
            {
                lbl_ServerError.Text = "两次输入的服务端密码不一致!";
                serverPassWordChanged = PwdChangType.UNSUCCESED;
            }
            //else if (txt_ServerPassWord.Text == ""&& clientPassWordChanged== PwdChangType.CHANGED)
            //{
            //    lbl_ServerError.Text = "输入的服务端密码不能为空!";
            //    serverPassWordChanged = PwdChangType.UNSUCCESED;
            //}
            else if (txt_ClientPassWord.Text != txt_ClientPassWordSure.Text)
            {
                lbl_ClientError.Text = "两次输入的客户端密码不一致!";
                clientPassWordChanged = PwdChangType.UNSUCCESED;
            }
            //else if(txt_ClientPassWord.Text=="")
            //{
            //    lbl_ClientError.Text = "输入的客户端密码不能为空!";
            //    clientPassWordChanged = PwdChangType.UNSUCCESED;
            //}
            else
                this.Close();
        }

        private void btn_Cansle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_ClientPassWordSure_TextChanged(object sender, EventArgs e)
        {
            clientPassWordChanged = PwdChangType.CHANGED;
            lbl_ClientError.Text = "";
        }

        private void frm_Option_Load(object sender, EventArgs e)
        {
            serverPassWordChanged = PwdChangType.CANCEL;
            clientPassWordChanged = PwdChangType.CANCEL;
        }
    }
}