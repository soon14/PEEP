using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace INCUclient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //先登陆成功才显示主窗体
            if (Login())
                Application.Run(new frm_Client());
            else
                Application.Exit();
        }
        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <returns>是否登陆成功</returns>
        private  static bool Login()
        {
            string md5TruePwd = "";
            string md5InputPwd = "";
            frm_Login login = new frm_Login();
            if (System.IO.File.Exists(ICanSeeYou.Common.Constant.OptionFilename))
            {

                ICanSeeYou.Configure.Option option = new ICanSeeYou.Configure.Option();
                ICanSeeYou.Configure.OptionFile optionFile = option.OptFile;
                md5TruePwd = optionFile.PassWord;
                if (md5TruePwd != "")
                {
                    DialogResult result = login.ShowDialog();
                    if (result == DialogResult.OK)
                        md5InputPwd = ICanSeeYou.Configure.PassWord.MD5Encrypt(login.Password);
                    else
                        return false;
                    while (md5TruePwd != md5InputPwd)
                    {
                        MessageBox.Show("密码错误!");
                        result = login.ShowDialog();
                        if (result == DialogResult.OK)
                            md5InputPwd =ICanSeeYou.Configure.PassWord.MD5Encrypt(login.Password);
                        else
                            return false;
                    }
                    if (md5InputPwd == md5TruePwd)
                        return true;
                }
                else
                    MessageBox.Show("配置文件的密码丢失,不能登陆!");
            }
            else
                MessageBox.Show("配置文件丢失,不能登陆!");
            return false;
        }
    }
}