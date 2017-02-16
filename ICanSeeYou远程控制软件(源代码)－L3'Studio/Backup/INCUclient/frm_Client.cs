using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using ICanSeeYou.Codes;

namespace INCUclient
{
    //INCU客户端
    public partial class frm_Client : Form
    {
        /// <summary>
        /// 总控制端
        /// </summary>
        private Clients.Controlers GeneralControler;
        /// <summary>
        /// 当前选择的树形结点
        /// </summary>
        private TreeNode CurrentNode;
        /// <summary>
        /// 哈希表(Key=文件后缀名,value=图片列表的Key)
        /// 例如:后缀名A=exe,则imageKey[A]="exe",而imageKey[A]则是对应的文件图标Key值.
        /// </summary>
        private Hashtable imageKey;

        /// <summary>
        /// 是否开始截取远程屏幕
        /// </summary>
        private bool ScreenOpen;

        //初始化
        public frm_Client()
        {
            InitializeComponent();
            Initial();
        }       
        
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            imageKey = new Hashtable();
            System.Collections.Specialized.StringCollection keyCol = iml_ExplorerImages.Images.Keys;
            for (int i = 0; i < keyCol.Count; i++)
                if (!imageKey.Contains(keyCol[i]))
                    imageKey.Add(keyCol[i], keyCol[i]);
            //总控制端初始化
            GeneralControler = new Clients.Controlers(imageKey);
            GeneralControler.pic_Screen = pic_Screen;
            GeneralControler.ltv_HostExplorer = ltv_hostexplorer;
            GeneralControler.ltv_Log = ltv_Log;
            GeneralControler.ltv_MyExplorer = ltv_myexplorer;
            GeneralControler.rtb_Content = rtb_Content;
            GeneralControler.trv_HostView = trv_HostView;
            GeneralControler.txb_HostExploer = txt_hostexplorer;
            GeneralControler.txb_MyExplorer = txt_myexplorer;
            GeneralControler.lbl_Message = lbl_Display;

            ICanSeeYou.Configure.Option option = new ICanSeeYou.Configure.Option();
            ICanSeeYou.Configure.OptionFile optionFile = option.OptFile;
            if (optionFile != null)
            {
                GeneralControler.UpdatedFile = optionFile.UpdatedFile;
                GeneralControler.ServerVersion = optionFile.UpdatedVersion;
            }

            //未开始截屏
            ScreenOpen = false;
            //默认截屏间隔时间(一秒),即截屏速度为中.
            ScreenTimer.Interval = 1000;
            中MToolStripMenuItem.Checked = true;
          //  this.ShowInTaskbar = false;
        }

        #region  建立连接

        //连接所有安装服务端的主机
        private void 所有主机AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            frm_ConnectAll Connection = new frm_ConnectAll();
            DialogResult result = Connection.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!GeneralControler.ConnectAll(Connection.StartIP, Connection.EndIP))
                    MessageBox.Show("不能建立连接!");
            }
        }

        //与指定主机连接连接
        private void 指定主机SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            frm_Connection Connection = new frm_Connection();
            DialogResult result = Connection.ShowDialog();
            if (result == DialogResult.OK)
            { 
                System.Net.IPAddress serverIP;
                try
                {
                   serverIP = ICanSeeYou.Common.Network.ToIPAddress(Connection.ServerIP);
                }
                catch
                {
                    MessageBox.Show("IP地址错误!", "IP地址错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                GeneralControler.BuiltControler(serverIP);
            }
        }

        //重新连接
        private void 重新连接RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            TreeNode tn = trv_HostView.SelectedNode;
            if (tn != null)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(GeneralControler.ReBuilt));
                thread.Start(tn);
            }
            else
                MessageBox.Show("请选择树形视图的主机IP地址重试,或者移除它,然后再建立连接.");
        }

        #endregion

        #region 文件管理

        //打开本地电脑上的路径
        private void btn_myexplorer_Click(object sender, EventArgs e)
        {
            ICanSeeYou.Common.IO.OpenDirectory(txt_myexplorer.Text, ltv_myexplorer, imageKey);
        }

        //打开本地电脑上的路径
        private void ltv_myexplorer_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectItem = null;
            BaseFile basefile = null;
            try
            {
                selectItem = ltv_myexplorer.FocusedItem;
                if (selectItem != null)
                {
                    basefile = selectItem.Tag as BaseFile;
                    if (basefile != null)
                        if (basefile.Flag != FileFlag.File)
                        {
                            string path = (basefile.Flag == FileFlag.Directory ? basefile.Name : basefile.Name + @"\");
                            lbl_Display.Text = path;
                            ICanSeeYou.Common.IO.OpenDirectory(path, ltv_myexplorer, imageKey);
                            txt_myexplorer.Text = path;
                        }
                }
                else
                {
                    MessageBox.Show(" 请选择一个文件夹！");
                }
            }
            catch
            {
            }
        }

        //获取本地电脑上文件的信息
        private void ltv_myexplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltv_myexplorer.FocusedItem != null)
            {
                BaseFile basefile = ltv_myexplorer.FocusedItem.Tag as BaseFile;
                if (basefile != null)
                    if (basefile.Flag == FileFlag.Directory)
                        lbl_Display.Text = basefile.Name;
                    else if (basefile.Flag == FileFlag.File)
                        lbl_Display.Text = ICanSeeYou.Common.IO.GetFileDetial(basefile.Name);
            }
        }

        //打开本地电脑上的路径
        private void txt_myexplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ICanSeeYou.Common.IO.OpenDirectory(txt_myexplorer.Text, ltv_myexplorer, imageKey);
        }

        //打开本地电脑上的路径
        private void 打开OToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ltv_myexplorer_DoubleClick(sender, e);
        }

        //刷新本地电脑
        private void 刷新RtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_myexplorer_Click(sender, e);
        }

        //打开远程电脑上的路径
        private void 打开OToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvs_hostexplorer_DoubleClick(sender, e);
        }

        //打开远程电脑上的路径
        private void btn_hostexplorer_Click(object sender, EventArgs e)
        {
            string path = txt_hostexplorer.Text;
            if (path != "")
                GeneralControler.GetDirectoryDetial(path);
            else
                GeneralControler.GetDiskDetial();
        }

        //打开远程电脑上的路径
        private void lvs_hostexplorer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ltv_hostexplorer.FocusedItem != null)
                {
                    BaseFile basefile = ltv_hostexplorer.FocusedItem.Tag as BaseFile;
                    if (basefile != null)
                        if (basefile.Flag != FileFlag.File)
                        {
                            string path = (basefile.Flag == FileFlag.Directory ? basefile.Name : basefile.Name + @"\");
                            if (path != "")
                            {
                                lbl_Display.Text = path;
                                GeneralControler.GetDirectoryDetial(path);
                                txt_hostexplorer.Text = path;
                            }
                            else
                            {
                                GeneralControler.GetDiskDetial();
                                lbl_Display.Text = "远程电脑的根目录";
                            }
                        }
                }
                else
                {
                    MessageBox.Show(" 请选择一个文件夹！");
                }
            }
            catch { }
        }

        //打开远程电脑上的路径
        private void txt_hostexplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_hostexplorer_Click(sender, e);
        }

        private void 刷新RToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_hostexplorer_Click(sender, e);
        }

        //获取远程电脑上文件的信息
        private void lvs_hostexplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BaseFile basefile = ltv_hostexplorer.FocusedItem.Tag as BaseFile;
                if (basefile != null)
                    if (basefile.Flag == FileFlag.File)
                        GeneralControler.GetFileDetial(basefile.Name);
                    else if (basefile.Flag == FileFlag.Directory)
                        lbl_Display.Text = basefile.Name;
            }
            catch { }

        }

        //远程文件下载
        private void 下载DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ltv_hostexplorer.FocusedItem != null)
                {
                    BaseFile basefile = ltv_hostexplorer.FocusedItem.Tag as BaseFile;
                    if (basefile != null)
                        if (basefile.Flag == FileFlag.File)
                        {
                            string savePath = ltv_myexplorer.Tag as string;
                            if (savePath != null)
                            {
                                string fileName = ICanSeeYou.Common.IO.GetName(basefile.Name);
                                savePath += (savePath.EndsWith(@"\") ? fileName : @"\" + fileName);
                                if (savePath != "")
                                {
                                    if (System.IO.File.Exists(savePath))
                                    {
                                        DialogResult result = MessageBox.Show("\t文件\'" + fileName + "\'已经存在!\n\t是否选择另外一个目录保存?", "选择另外一个目录保存", MessageBoxButtons.YesNo);
                                        if (result == DialogResult.Yes)
                                        {
                                            SaveFileDialog filechooser = new SaveFileDialog();
                                            filechooser.FileName = savePath;
                                            filechooser.Filter = "(" + ICanSeeYou.Common.IO.GetFileType(fileName) + ")|*." + ICanSeeYou.Common.IO.GetFileType(fileName);
                                            DialogResult saveResult = filechooser.ShowDialog();
                                            if (saveResult == DialogResult.OK)
                                            {
                                                savePath = filechooser.FileName;
                                            }
                                        }
                                    }
                                    if (savePath != null && savePath != "")
                                        GeneralControler.DownOrUpload(basefile.Name, savePath, true);
                                }
                                else
                                    MessageBox.Show("当前保存路径" + savePath + "无效!");
                            }
                        }
                        else
                            MessageBox.Show("只能下载文件");
                }
                else
                {
                    MessageBox.Show(" 请选择一个文件下载！");
                }
            }
            catch { }
        }

        //上传本地文件到服务端
        private void 上传UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ltv_myexplorer.FocusedItem != null)
                {
                    BaseFile basefile = ltv_myexplorer.FocusedItem.Tag as BaseFile;
                    if (basefile != null)
                        if (basefile.Flag == FileFlag.File)
                        {
                            string savePath = ltv_hostexplorer.Tag as string;
                            if (savePath != null)
                                if (savePath != "")
                                {
                                    string fileName = ICanSeeYou.Common.IO.GetName(basefile.Name);
                                    savePath += (savePath.EndsWith(@"\") ? fileName : @"\" + fileName);
                                    GeneralControler.DownOrUpload(basefile.Name, savePath, false);
                                }
                                else
                                    MessageBox.Show("当前保存路径" + savePath + "无效!");
                        }
                        else
                            MessageBox.Show("只能上传文件");
                }
                else
                {
                    MessageBox.Show(" 请选择一个文件上传！");
                }
            }
            catch { }
        }

        #endregion

        #region  远程主机的鼠标控制

        private void pic_Screen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ScreenOpen)
                GeneralControler.MouseDoubleClick(sender, e);
        }

        private void pic_Screen_MouseDown(object sender, MouseEventArgs e)
        {
            if (ScreenOpen)
                GeneralControler.MouseDown(sender, e);
        }

        private void pic_Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (ScreenOpen)
                GeneralControler.MouseMove(sender, e);
        }

        private void pic_Screen_MouseUp(object sender, MouseEventArgs e)
        {
            if (ScreenOpen)
                GeneralControler.MouseUp(sender, e);
        }
        #endregion

        #region 远程主机的屏幕截取

        //截取远程屏幕
        private void ScreenTimer_Tick(object sender, EventArgs e)
        {
            if (!GeneralControler.GetScreen())
            {
                ScreenTimer.Enabled = false;
                MessageBox.Show("远程屏幕截取失败!", "远程屏幕截取失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //打开远程屏幕(主菜单和工具栏)
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            if (!ScreenOpen)
            {
                if (GeneralControler.CurrentControler != null)
                {
                    tabs.SelectedTab = tab_Desktop;
                    GeneralControler.OpenScreen();
                    //暂停片刻,让屏幕控制端和服务端在这时间建立连接
                    Thread.Sleep(300);
                    ScreenOpen = true;
                    ScreenTimer.Enabled = true;
                }
            }
            else
                MessageBox.Show("已经打开远程截屏功能了");
        }

        //打开远程屏幕(树形视图的右键菜单)
        private void 屏幕控制PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = trv_HostView.SelectedNode;
            if (tn != null)
            {
                ScreenTimer.Enabled = false;
                tabs.SelectedTab = tab_Desktop;
                if (tn != CurrentNode)
                {
                    CurrentNode = tn;
                    GeneralControler.OpenScreen(tn.Tag);
                    //暂停片刻,让屏幕控制端和服务端在这时间建立连接
                    Thread.Sleep(300);
                    ScreenOpen = true;
                }
                ScreenTimer.Enabled = true;
            }
        }
        //暂停截取远程屏幕
        private void 暂停PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            ScreenOpen = false;
        }

        //关闭截取远程屏幕
        private void 关闭CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Enabled = false;
            ScreenOpen = false;
            GeneralControler.CloseScreenControler();
        }

        #endregion

       
        //与服务端对话
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (rtb_Speak.Text == "")
                MessageBox.Show("不能发送空信息!", "阻止框", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (GeneralControler.Speak(rtb_Speak.Text))
                {
                    rtb_Content.Text += ("管理员" + ":\n\t" + rtb_Speak.Text + "\n");
                    rtb_Speak.Text = "";
                }
            }
        }

        //与服务端对话
        private void rtb_Speak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                btn_Send_Click(sender, e);
        }

        //在关闭程序前关闭所有的连接
        private void frm_client_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();            
        }

        private void 关机SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = trv_HostView.SelectedNode;
            if (tn != null && tn.Tag != null)
            {
                DialogResult result = MessageBox.Show("确定关闭远程主机" + tn.Tag.ToString() + "吗?", "关闭确认", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    GeneralControler.CloseWindows(tn.Tag);
            }
            else
            {
                MessageBox.Show("当前主机已经断开了连接,请移除它,然后再连接");
            }
        }

        private void 移除MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = trv_HostView.SelectedNode;
            if (tn != null)
            {
                GeneralControler.RemoveControler(tn.Tag);
                tn.Remove();
            }
        }

        private void trv_HostView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trv_HostView.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Left && e.Node != null && e.Node != trv_HostView.Nodes[0])
                if (e.Node.Tag != null)
                {
                     GeneralControler.ChangeControler(e.Node.Tag);
                }
                else
                    lbl_Display.Text = "当前主机已经断开了连接,请移除它,然后再连接";
           
        }

        private void trv_HostView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            重新连接RToolStripMenuItem_Click(sender, e);
        }

        private void 增加主机NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            指定主机SToolStripMenuItem_Click(sender, e);
        }

        private void 移除所有RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trv_HostView.Nodes[0].Nodes != null)
                trv_HostView.Nodes[0].Nodes.Clear();
            if (GeneralControler != null)
                GeneralControler.CloseAll();
        }

        private void 关闭连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            移除所有RToolStripMenuItem_Click(sender, e);
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralControler != null)
                GeneralControler.CloseAll();
            System.Environment.Exit(System.Environment.ExitCode);
            Application.Exit();
        }

        private void frm_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 退出EToolStripMenuItem_Click(sender, e);
        }

        #region 键盘事件
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //if(ScreenOpen && tabs.SelectedTab == tab_Desktop)
                GeneralControler.KeyDown(e.KeyCode);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (ScreenOpen && tabs.SelectedTab == tab_Desktop)
                GeneralControler.KeyUp(e.KeyCode);
           // base.OnKeyUp(e);
        }

        #endregion

        //显示主窗体
        private void 打开OToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Show();
        }

        private void 关闭连接CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关闭连接ToolStripMenuItem_Click(sender, e);
        }

        private void 关于AToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frm_AboutINCU().Show();
        }

        private void 退出EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            退出EToolStripMenuItem_Click(sender, e);
        }

        //帮助内容
        private void 内容CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(ICanSeeYou.Common.Constant.HelpFilename))
                    System.Diagnostics.Process.Start(ICanSeeYou.Common.Constant.HelpFilename);
                else
                    MessageBox.Show("帮助文件丢失！");
            }
            catch
            {
                MessageBox.Show("帮助文件无法读取！可能已经损坏。");
            }
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于AToolStripMenuItem1_Click(sender, e);
        }


        private void 快QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Interval = 500;
            中MToolStripMenuItem.Checked = false;
            快QToolStripMenuItem.Checked = true;
            慢SToolStripMenuItem.Checked = false;

        }

        private void 中MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Interval = 1000;
            中MToolStripMenuItem.Checked = true;
            快QToolStripMenuItem.Checked = false;
            慢SToolStripMenuItem.Checked = false;

        }

        private void 慢SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTimer.Interval = 1500;
            中MToolStripMenuItem.Checked = false;
            快QToolStripMenuItem.Checked = false;
            慢SToolStripMenuItem.Checked = true;

        }

        //高级设置
        private void 高级HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Option option = new frm_Option();
            DialogResult result= option.ShowDialog();
            if (result == DialogResult.OK)
            {
                while (result == DialogResult.OK && option.ServerPassWordChanged == PwdChangType.UNSUCCESED)
                {
                    MessageBox.Show("服务端密码修改不成功");
                    if (option != null)
                        result = option.ShowDialog();
                }
                if (option.ServerPassWordChanged == PwdChangType.CHANGED)
                {
                    GeneralControler.ChangeServerPassWord(option.ServerPassWord);
                }
                if (option.UpdatedFileChanged)
                {
                    ICanSeeYou.Configure.OptionManager.ChangeUpdatedFile(option.UpdatedFile, option.Version);
                    GeneralControler.UpdatedFile = option.UpdatedFile;
                    GeneralControler.ServerVersion = option.Version;
                }
                while (result == DialogResult.OK && option.ClientPassWordChanged == PwdChangType.UNSUCCESED)
                {
                    MessageBox.Show("客户端密码修改不成功");
                    if(option !=null)
                        result = option.ShowDialog();
                }
                if (option.ClientPassWordChanged==PwdChangType.CHANGED)
                {
                    string Md5Pwd = ICanSeeYou.Configure.PassWord.MD5Encrypt(option.ClientPassWord);
                    if (Md5Pwd != "")
                        ICanSeeYou.Configure.OptionManager.ChangePassWord(Md5Pwd);
                    else
                        MessageBox.Show("客户端的密码不能被加密!请重新修改!");
                }
                
            }
        }

        //升级服务端
        private void 升级服务端UtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICanSeeYou.Configure.Option option = new ICanSeeYou.Configure.Option(ICanSeeYou.Common.Constant.OptionFilename);
            if(!option.Read()) MessageBox.Show("配置文件丢失,请重新设置.");
            if (option.OptFile == null)MessageBox.Show("配置文件发生错误,请重新设置.");
            else{
                string UpdatedFile = option.OptFile.UpdatedFile;
                if (UpdatedFile != null && System.IO.File.Exists(UpdatedFile))
                    GeneralControler.UpdateServer();
                else
                    MessageBox.Show("配置文件发生错误或升级文件丢失.");
            }
        }

        //双击托盘显示或隐藏主窗口
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                打开OToolStripMenuItem3_Click(sender, e);
            }
            else
                this.WindowState = FormWindowState.Minimized;
        }

       
    }
}