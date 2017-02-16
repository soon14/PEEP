/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：Controlers.cs
        // 文件功能描述：总的控制类（客户端），包括基本通信，远程文件管理，远程屏幕控制等类的实例。
//----------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

using Client;
using ICanSeeYou.Bases;
using ICanSeeYou.Codes;
using ICanSeeYou.Common;

namespace Clients
{
    /// <summary>
    /// 主控端
    /// </summary>
    public class Controlers
    {

        #region 客户端窗体各种被主控端调用的控件

        /// <summary>
        /// 客户端电脑浏览文件的地址栏
        /// </summary>
        public TextBox txb_MyExplorer;
        /// <summary>
        /// 服务端电脑浏览文件的地址栏
        /// </summary>
        public TextBox txb_HostExploer;
        /// <summary>
        /// 回馈各种信息的标签
        /// </summary>
        public ToolStripStatusLabel lbl_Message;
        /// <summary>
        /// 显示屏幕的图片框
        /// </summary>
        public PictureBox pic_Screen;
        /// <summary>
        /// 服务端电脑的文件列表
        /// </summary>
        public ListView ltv_MyExplorer;
        /// <summary>
        /// 客户端电脑的文件列表
        /// </summary>
        public ListView ltv_HostExplorer;
        /// <summary>
        /// 日志列表
        /// </summary>
        public ListView ltv_Log;
        /// <summary>
        /// 显示对话的文本框
        /// </summary>
        public RichTextBox rtb_Content;
        /// <summary>
        /// 显示已经建立连接的主机集合
        /// </summary>
        public TreeView trv_HostView;
        /// <summary>
        /// trv_HostView控件子结点上的快捷菜单
        /// </summary>
        public ContextMenuStrip cnm_HostView;

        #endregion

        #region Private 字段

        /// <summary>
        /// 哈希表(Key=文件后缀名,value=图片列表的Key)
        /// 例如:后缀名A=exe,则imageKey[A]="exe",而imageKey[A]则是对应的文件图标Key值.
        /// </summary>
        private Hashtable imageKey;

        /// <summary>
        /// 当前控制端
        /// </summary>
        private BaseControler currentControler;
        /// <summary>
        /// 屏幕接收端
        /// </summary>
        private ScreenControler screenControler;
        /// <summary>
        /// 文件管理端
        /// </summary>
        private FileControler fileControler;
        /// <summary>
        /// 更新控制端
        /// </summary>
        private FileControler serverupdateControler;

        /// <summary>
        /// 主线程
        /// </summary>
        private Thread mainControlerThread;

        /// <summary>
        /// 当前被控制端的IP
        /// </summary>
        private System.Net.IPAddress curServerIP ;

        /// <summary>
        /// 远程屏幕大小
        /// </summary>
        private Size screenSize;

        /// <summary>
        /// 保存鼠标移动前的位置（屏幕控制时使用）
        /// </summary>
        private Point oldPoint;

        /// <summary>
        /// 服务端升级文件的版本
        /// </summary>
        private string serverVersion;

        /// <summary>
        /// 更新文件的路径
        /// </summary>
        private string updatedFile;

        #endregion

        #region  Public 属性

        /// <summary>
        /// 服务端升级文件的版本
        /// </summary>
        public string ServerVersion
        {
            get { return serverVersion; }
            set { serverVersion = value; }
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        public string UpdatedFile
        {
            get { return updatedFile; }
            set { updatedFile = value; }
        }

        /// <summary>
        /// 当前控制端
        /// </summary>
        public BaseControler CurrentControler
        {
            get
            {
                return currentControler;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 返回一个主控端实例
        /// </summary>
        /// <param name="imageKey"></param>
        public Controlers(System.Collections.Hashtable imageKey)            
        {
            this.imageKey = imageKey;
            oldPoint = new Point(0, 0);
        }

        #endregion

        #region  各种 Delegate

        /// <summary>
        /// 树形控件添加结点(委托)
        /// </summary>
        /// <param name="node">连接成功的服务端IP</param>
        private delegate void TreeViewAddEvent(object node);
        /// <summary>
        /// 列表控件添加结点(委托)
        /// </summary>
        /// <param name="Item"></param>
        private delegate void ListViewAddEvent(object Item);
        /// <summary>
        /// 清除事件(委托)
        /// </summary>
        private delegate void ClearEvent();

        #endregion

        #region 添加,移除连接,重新连接,连接所有上线服务端等等

        /// <summary>
        /// 添加一个控制端
        /// </summary>
        /// <param name="serverAddress">服务端地址</param>
        /// <param name="insertIntoTreeNode">是否添加到树形列表中</param>
        /// <returns>树形控件的结点数 与 已经连接的服务端数 是否匹配</returns>
        private bool InsertControler(System.Net.IPAddress serverAddress,bool insertIntoTreeNode)
        {
            DisplayMessage("正在连接" + serverAddress + "...");
            //最大重试次数10
            BaseControler mainControler = new BaseControler(serverAddress, Constant.Port_Main, 10);
            mainControler.Execute = new ExecuteCodeEvent(mainExecuteCode);
           // mainControler.MaxTimes = Constant.MaxTimes;
            mainControler.Connecting();
            if (mainControler.HaveConnected)
            {
                DisplayMessage("连接" + serverAddress + "成功!");
                currentControler = mainControler;
                curServerIP = mainControler.ServerAddress;
                //是否添加到树形列表中
                if (insertIntoTreeNode)
                {
                    try
                    {
                        trv_HostView.Invoke(new TreeViewAddEvent(TreeViewAddNode), new object[] { serverAddress });
                    }
                    catch 
                    {
                        return false;
                    }
                }
            }
            else
                DisplayMessage("连接" + serverAddress + "不成功!");
            return true;
        }

        /// <summary>
        /// 树形控件添加结点(连接成功的服务端IP)
        /// </summary>
        /// <param name="node">连接成功的服务端IP</param>
        private void TreeViewAddNode(object node)
        {
            trv_HostView.Nodes[0].Nodes.Add(node.ToString());
            int count = trv_HostView.Nodes[0].Nodes.Count;
            trv_HostView.Nodes[0].Nodes[count - 1].Tag = node;
            trv_HostView.Nodes[0].Nodes[count - 1].ImageKey = "Host";
            trv_HostView.Nodes[0].Nodes[count - 1].ContextMenuStrip = cnm_HostView;
            trv_HostView.Nodes[0].Expand();
        }

        /// <summary>
        /// 重新建立连接
        /// </summary>
        /// <param name="treeNode">选择的TreeNode</param>
        public void ReBuilt(object selecterTreeNode)
        {
            TreeNode treeNode = selecterTreeNode as TreeNode;
            System.Net.IPAddress restartIP = null;
            if (treeNode == null)
                MessageBox.Show("请选择树形视图的主机IP地址重试,或者移除它,然后再建立连接.");
            else if (treeNode.Tag == null)
                MessageBox.Show("抱歉!当前服务端信息已经丢失,请在树形视图中移除它,然后再建立连接.");
            else
            {
                restartIP = treeNode.Tag as System.Net.IPAddress;
                if (restartIP != null)
                {
                    CloseAll();
                    mainControlerThread = new Thread(new ParameterizedThreadStart(rebuilt));
                    mainControlerThread.Start(restartIP);
                }
            }
        }
        /// <summary>
        /// 重新建立连接(辅助方法)
        /// </summary>
        /// <param name="serverAddress"></param>
        private void rebuilt(object serverAddress)
        {
            InsertControler((System.Net.IPAddress)serverAddress, false);
            if (currentControler != null)
                currentControler.Run();
        }

        /// <summary>
        /// 建立一个控制端
        /// </summary>
        /// <param name="serverAddress">服务端IP</param>
        public void BuiltControler(object serverAddress)
        {
            CloseAll();
            mainControlerThread = new Thread(new ParameterizedThreadStart(built));
            mainControlerThread.Start(serverAddress);
        }

        /// <summary>
        /// 建立一个控制端(辅助方法)
        /// </summary>
        /// <param name="serverAddress"></param>
        private void built(object serverAddress)
        {
            InsertControler((System.Net.IPAddress)serverAddress, true);
            if (currentControler != null)
                currentControler.Run();
        }

        /// <summary>
        /// 移除一个控制端
        /// </summary>
        /// <param name="controler">被移除的控制端</param>
        public void RemoveControler(object serverIP)
        {
            if (curServerIP != null && curServerIP == (System.Net.IPAddress)serverIP)
                    CloseAll();
        }

        /// <summary>
        /// 更改控制端
        /// </summary>
        /// <param name="serverAddress"></param>
        public void ChangeControler(object serverAddress)
        {
            if (curServerIP != null && curServerIP == (System.Net.IPAddress)serverAddress)
                return;
            CloseAll();
            mainControlerThread = new Thread(new ParameterizedThreadStart(change));
            mainControlerThread.Start(serverAddress);
        }

        /// <summary>
        /// 更改控制端(辅助方法)
        /// </summary>
        /// <param name="serverAddress"></param>
        private void change(object serverAddress)
        {
            if (curServerIP == null)
                curServerIP = (System.Net.IPAddress)serverAddress;
            InsertControler((System.Net.IPAddress)serverAddress, false);
            if (currentControler != null)
                currentControler.Run();
        }

        /// <summary>
        ///  连接所有安装服务端的主机
        /// </summary>
        /// <param name="startIP">起始IP</param>
        /// <param name="endIP">终止IP</param>
        /// <returns>连接过程是否发生异常</returns>
        public bool ConnectAll(string startIP, string endIP)
        {
            //清除之前的所有连接(避免连接相同的服务端)
            CloseAll();
            //移除树形视图里的服务端信息
            trv_HostView.Invoke(new ClearEvent(TreeViewClear));

            byte[] Start = Network.SplitIP(startIP);
            byte[] End = Network.SplitIP(endIP);
            if (Start == null || End == null)
                return false;
            for (byte i = Start[0]; i <= End[0]; i++)
                for (byte j = Start[1]; j <= End[1]; j++)
                    for (byte k = Start[2]; k <= End[2]; k++)
                        for (byte l = Start[3]; l <= End[3]; l++)
                        {
                            try
                            {
                                System.Net.IPAddress ip = Network.ToIPAddress(new byte[4] { i, j, k, l });
                                Thread thread = new Thread(new ParameterizedThreadStart(NewControler));
                                thread.Start(ip);
                            }
                            catch
                            {
                                return false;
                            }
                        }
            return true;
        }

        /// <summary>
        /// 此方法主要被多线程调用(搜索网段内的上线服务端时被调用);
        /// </summary>
        /// <param name="IP"></param>
        private void NewControler(object IP)
        {
            if (!InsertControler((System.Net.IPAddress)IP, true))
                MessageBox.Show("异常:树形控件的结点数 与 已经连接的服务端数 不匹配!");
        }

        /// <summary>
        /// 移除树形视图里的服务端信息
        /// </summary>
        private void TreeViewClear()
        {
            if (trv_HostView.Nodes[0].Nodes != null)
                trv_HostView.Nodes[0].Nodes.Clear();
        }

        #endregion

        #region 关闭连接

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public void CloseAll()
        {
            CloseFileControler();
            CloseScreenControler();
            CloseUpdateControler();
            CloseCurrentControler();
        }

        /// <summary>
        /// 关闭当前控制端
        /// </summary>
        public void CloseCurrentControler()
        {
            if (currentControler != null)
                currentControler.CloseConnections();
            if (mainControlerThread != null && mainControlerThread.IsAlive)
                mainControlerThread.Abort();
            currentControler = null;
        }
        /// <summary>
        /// 关闭屏幕控制
        /// </summary>
        public void CloseScreenControler()
        {
            if (screenControler != null)
            {
                pic_Screen.Image = null;
                screenControler.CloseConnections();
            }
        }
        /// <summary>
        /// 关闭文件控制
        /// </summary>
        public void CloseFileControler()
        {
            if (fileControler != null)
                fileControler.CloseConnections();            
        }
        /// <summary>
        /// 关闭更新
        /// </summary>
        public void CloseUpdateControler()
        {
            if (serverupdateControler != null)
                serverupdateControler.CloseConnections();
        }

        #endregion

        #region  执行各种指令

        /// <summary>
        /// 执行各种指令
        /// </summary>
        /// <param name="msg">指令</param>
        private void mainExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead .CONNECT_OK:
                    GetServerMessage(sender);
                    DisplayMessage("连接"+((BaseControler)sender).ServerAddress+"成功!");
                    break;
                case CodeHead .HOST_MESSAGE:
                    //显示主机信息
                    displayHostMessage(code);
                    break;
                case CodeHead.SEND_FILE_READY:
                    //打开文件接收端
                    builtFileControler(sender, code);
                    break;
                    //建立文件发送端
                case CodeHead.GET_FILE_READY:
                    builtFileControler(sender, code);
                    break;
                case CodeHead.SCREEN_READY:
                    //建立屏幕接收端
                    builtScreenControler(sender, code);
                    break;
                case CodeHead .UPDATE_READY:
                    //建立更新控制端
                    builtUpdateControler(sender, code);
                    break;
                case CodeHead .VERSION:
                    //确认服务端版本,如果版本低则更新
                    Updating(sender, code);
                    break;
                case CodeHead .UPDATE_FAIL:
                    MessageBox.Show("更新失败!");
                    break;
                case CodeHead.CHANGE_PASSWORD_OK:
                    MessageBox.Show("密码修改成功!");
                    break;
                case CodeHead.SEND_DISKS:
                    //显示远程磁盘
                    ShowDisks((DisksCode)code);
                    break;
                case CodeHead.SEND_FILE_DETIAL:
                    //显示文件的信息
                    DisplayMessage(code.ToString());
                    break;    
                case CodeHead.SEND_DIRECTORY_DETIAL:
                    //显示文件夹的信息
                    ShowHostDirectory((ExplorerCode)code);
                    break;
                case CodeHead.SPEAK:
                    //对话
                    displayContent(code);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 文件控制端

        /// <summary>
        /// 建立文件控制端
        /// </summary>
        /// <param name="code"></param>
        private void builtFileControler(BaseCommunication sender, Code code)
        {
            BaseControler controler = sender as BaseControler;
            if (controler != null)
            {
                PortCode readyCode = code as PortCode;
                if (readyCode != null)
                {
                    if (fileControler != null) fileControler.CloseConnections();
                    fileControler = new FileControler(controler.ServerAddress, readyCode.Port);
                    fileControler.Refrush = new RefrushEvent(UpdateExplorerView);
                }
            }
        }

        /// <summary>
        /// 下载或上传文件
        /// </summary>
        /// <param name="sourceFile">原文件</param>
        /// <param name="destinationFile">目标文件</param>
        /// <param name="destinationFile">是否下载命令（true表示下载，false表示上传）</param>
        public void DownOrUpload(string sourceFile, string destinationFile, bool IsDownloaded)
        {
            if (fileControler != null)
            {
                fileControler.CloseConnections();
                fileControler.SourceFile = sourceFile;
                fileControler.DestinationFile = destinationFile;
                fileControler.IsDownload = IsDownloaded;
                fileControler.Open();
            }
        }

        #endregion

        #region 屏幕接收端

        /// <summary>
        /// 建立屏幕接收端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="code"></param>
        private void builtScreenControler(BaseCommunication sender, Code code)
        {
            BaseControler controler = sender as BaseControler;
            if (controler != null)
            {
                PortCode readyCode = code as PortCode;
                if (readyCode != null)
                {
                    if (screenControler != null) screenControler.CloseConnections();
                    screenControler = new ScreenControler(controler.ServerAddress, readyCode.Port);
                    screenControler.pic_Screen = pic_Screen;
                    screenControler.lbl_Message = lbl_Message;
                }
            }
        }
        /// <summary>
        /// 向远程主机发出截屏连接
        /// </summary>
        public void OpenScreen()
        {
            if (screenControler != null)
            {
                screenControler.CloseConnections();
                screenControler.Open();
                screenControler.GetScreen();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        public void OpenScreen(object serverIP)
        {
            ChangeControler(serverIP);
            OpenScreen();
        }

        /// <summary>
        /// 向远程主机发出截屏请求(由时钟触发)
        /// </summary>
        /// <returns></returns>
        public bool GetScreen()
        {
            if (screenControler != null )
                return screenControler.GetScreen();
            return false;
        }

        #endregion

        #region  用来更新的控制端

        /// <summary>
        /// 建立更新控制端
        /// </summary>
        /// <param name="code"></param>
        private void builtUpdateControler(BaseCommunication sender, Code code)
        {
            BaseControler controler = sender as BaseControler;
            if (controler != null)
            {
                PortCode readyCode = code as PortCode;
                if (readyCode != null)
                {
                    if(serverupdateControler==null)
                        serverupdateControler = new FileControler(controler.ServerAddress, readyCode.Port);
                    if (serverupdateControler != null)
                    {
                        serverupdateControler.CloseConnections();
                        Thread.Sleep(500);
                        serverupdateControler = new FileControler(controler.ServerAddress, readyCode.Port);
                        serverupdateControler.SourceFile = updatedFile;
                        serverupdateControler.DestinationFile = ICanSeeYou.Common.IO.GetName(updatedFile);
                        serverupdateControler.IsDownload = false;//上传更新文件
                        serverupdateControler.Open();
                    }
                }
            }
        }
        /// <summary>
        /// 开始更新服务端
        /// </summary>
        public void UpdateServer()
        {
            BaseCode code = new BaseCode();
            code.Head = CodeHead.VERSION;
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                currentControler.SendCode(code);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="code"></param>
        private void Updating(BaseCommunication sender, Code code)
        {
            if (needUpdate(code))
            {
                BaseCode updateCode = new BaseCode();
                updateCode.Head = CodeHead.UPDATE;
                sender.SendCode(updateCode);
                DisplayMessage("服务端正在更新...");
            }
            else
            {
                DisplayMessage("不需要更新");
            }
        }

        /// <summary>
        /// 是否需要更新
        /// </summary>
        /// <param name="code"></param>
        private bool needUpdate(Code code)
        {
            DoubleCode versionCode = code as DoubleCode;
            if (versionCode != null)
            {
                int[] oldver = versionToInt(versionCode.Body);
                int[] newver = versionToInt(serverVersion);
                if (newver[0] > oldver[0]) return true;
                if (newver[1] > oldver[1]) return true;
                if (newver[2] > oldver[2]) return true;
                if (newver[3] > oldver[3]) return true;
            }
            return false;
        }

        /// <summary>
        /// 版本号转化为整数数组
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private int[] versionToInt(string version)
        {
            //无效版本
            int[] vail = new int[4] { 0, 0, 0, 0 };
            string[] ver = version.Split(new char[] { '.' });
            if (ver==null||ver.Length != 4) return vail;
            try
            {
                return new int[4] { int.Parse(ver[0]), int.Parse(ver[1]), int.Parse(ver[2]), int.Parse(ver[3]) };
            }
            catch { return  vail; }
        }
      
        #endregion

        #region 主控端的一般方法

        /// <summary>
        /// 向对方发送信息
        /// </summary>
        /// <param name="content">对话内容</param>
        public bool Speak(string content)
        {
            if (currentControler == null)
            {
                MessageBox.Show("你还没连接任何主机或连接中断!");
                return false;
            }
            else
            {
                DoubleCode code = new DoubleCode();
                code.Head = CodeHead.SPEAK;
                code.Body = content;
                currentControler.SendCode(code);
                return true;
            }
        }

        /// <summary>
        /// 发送关机指令
        /// </summary>
        /// <param name="controler"></param>
        public void CloseWindows(object serverIP)
        {
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                if (curServerIP != (System.Net.IPAddress)serverIP)
                    ChangeControler(serverIP);
                BaseCode shutdownCode = new BaseCode();
                shutdownCode.Head = CodeHead.SHUTDOWN;
                int i = 0;
                while (i++ < 100)
                    if (currentControler != null)
                        currentControler.SendCode(shutdownCode);
            }
        }

        /// <summary>
        /// 修改服务端密码
        /// </summary>
        /// <param name="pwd">密码</param>
        public void ChangeServerPassWord(string pwd)
        {
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                DoubleCode code = new DoubleCode();
                code.Head = CodeHead.PASSWORD;
                code.Body = ICanSeeYou.Configure.PassWord.MD5Encrypt(pwd);
                currentControler.SendCode(code);
            }
        }

        /// <summary>
        /// 显示有对方发来的信息
        /// </summary>
        /// <param name="code"></param>
        private void displayContent(Code code)
        {
            DoubleCode contentCode = code as DoubleCode;
            if(contentCode!=null)
                rtb_Content.Text+=(currentControler.ServerAddress+":\n\t"+contentCode.Body+"\n");
        }

        /// <summary>
        /// 显示对方信息(IP和主机名)
        /// </summary>
        private void displayHostMessage(Code code)
        {
            HostCode hostcode = code as HostCode;
            if (hostcode != null)
            {
                DisplayMessage("远程主机信息:\t"+hostcode.IP + "(" + hostcode.Name + ")");
            }
        }

        /// <summary>
        /// 显示接收的信息
        /// </summary>
        /// <param name="msg"></param>
        public void DisplayMessage(string msg)
        {
            lbl_Message.Text = msg;
        }

        #endregion

        #region 获取各种信息的方法

        /// <summary>
        /// 获取对方信息(IP和主机名)
        /// </summary>
        /// <param name="sender"></param>
        private void GetServerMessage(BaseCommunication sender)
        {
            BaseControler controler = sender as BaseControler;
            if (controler != null)
            {
                BaseCode code = new BaseCode();
                code.Head = CodeHead.HOST_MESSAGE;
                controler.SendCode(code);
            }
        }
        /// <summary>
        /// 获取文件夹信息(里面的文件夹和文件)
        /// </summary>
        /// <param name="fullName"></param>
        public void GetDirectoryDetial(string fullName)
        {
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                DoubleCode code = new DoubleCode();
                code.Head = CodeHead.GET_DIRECTORY_DETIAL;
                code.Body = fullName;
                currentControler.SendCode(code);
            }
        }
        /// <summary>
        /// 获取文件信息(大小,修改日期)
        /// </summary>
        /// <param name="fullName"></param>
        public void GetFileDetial(string fullName)
        {
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                DoubleCode code = new DoubleCode();
                code.Head = CodeHead.GET_FILE_DETIAL;
                code.Body = fullName;
                currentControler.SendCode(code);
            }
        }

        /// <summary>
        /// 获取磁盘的信息(里面的文件夹和文件)
        /// </summary>
        /// <param name="diskName"></param>
        public void GetDiskDetial()
        {
            if (currentControler == null)
                MessageBox.Show("你还没连接任何主机或连接中断!");
            else
            {
                BaseCode code = new BaseCode();
                code.Head = CodeHead.GET_DISKS;
                currentControler.SendCode(code);
            }
        }

        #endregion
   
        #region 鼠标控制

        /// <summary>
        /// 控制远程鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseClick(object sender, MouseEventArgs e)
        {
            sendMouseEvent(sender, e, MouseEventType.MouseClick);
        }
        /// <summary>
        /// 控制远程鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sendMouseEvent(sender, e, MouseEventType.MouseDoubleClick);
        }

        /// <summary>
        /// 控制远程鼠标按键被按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                sendMouseEvent(sender, e, MouseEventType.MouseLeftDown);
            else
                sendMouseEvent(sender, e, MouseEventType.MouseRightDown);
        }

        /// <summary>
        /// 控制远程鼠标按键被释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            sendMouseEvent(sender, e, MouseEventType.MouseLeftUp);
            else
            sendMouseEvent(sender, e, MouseEventType.MouseRightUp);
        }

        /// <summary>
        /// 控制远程鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (Math.Pow(e.X - oldPoint.X, 2) + Math.Pow(e.Y - oldPoint.Y, 2) >= 4)
            {
                sendMouseEvent(sender, e, MouseEventType.MouseMove);
                oldPoint = new Point(e.X, e.Y);
            }
        }

        /// <summary>
        /// 发送鼠标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="flag"></param>
        private void sendMouseEvent(object sender, MouseEventArgs e,MouseEventType flag)
        {
            if (currentControler == null)
                lbl_Message.Text=("你还没连接任何主机或连接中断!");
            else
            {
                PictureBox screenPict = (PictureBox)sender;
                Point epoint = ToScreenPoint(screenPict, e.Location);
                MouseEvent code = new MouseEvent(flag, epoint.X, epoint.Y);
                code.Head = CodeHead.CONTROL_MOUSE;
                if (epoint.X != -1)
                    currentControler.SendCode(code);
            }
        }

        /// <summary>
        /// 把虚拟桌面的鼠标坐标转换为远程桌面的鼠标坐标
        /// </summary>
        /// <param name="screenPict">虚拟桌面(图片框)</param>
        /// <param name="realPoint">虚拟桌面的鼠标坐标</param>
        /// <returns></returns>
        private Point ToScreenPoint(PictureBox screenPict, Point realPoint)
        {
            //无效坐标
                Point screenPoint=new Point(-1,-1);
            if (screenPict.Image != null)
            {
                screenSize =new Size ( screenPict.Image.Size.Width*4/3,screenPict.Image.Size.Height*4/3);

                //screenSize = new Size(800, 600);
                Size boxSize = screenPict.Size;
                double virPointX ,virPointY;
                double hr = screenSize.Height / (double)boxSize.Height;
                double wr = screenSize.Width / (double)boxSize.Width;
                if (hr > wr)
                {
                    virPointY = realPoint.Y;
                    virPointX = realPoint.X - (boxSize.Width - screenSize.Width / hr) / 2;
                    screenPoint.X =Convert.ToInt32( virPointX * hr);
                    screenPoint.Y =Convert.ToInt32( virPointY * hr);
                }
                else
                {
                    virPointX = realPoint.X;
                    virPointY = realPoint.Y - (boxSize.Height - screenSize.Height / wr) / 2;
                    screenPoint.X = Convert.ToInt32(virPointX * wr);
                    screenPoint.Y = Convert.ToInt32(virPointY * wr);
                }
                if (screenPoint.X < 0) screenPoint.X = 0;
                if (screenPoint.Y < 0) screenPoint.Y = 0;
                if (screenPoint.X > screenSize.Width) screenPoint.X = screenSize.Width;
                if (screenPoint.Y > screenSize.Height) screenPoint.Y = screenSize.Height;
            }
            return screenPoint;
        }
        #endregion

        #region 键盘控制

        /// <summary>
        /// 控制键盘的按键按下
        /// </summary>
        /// <param name="keyCode"></param>
        public void KeyDown(Keys keyCode)
        {
            KeyBoardEvent code = new KeyBoardEvent(KeyBoardType.Key_Down, keyCode);
            code.Head = CodeHead.CONTROL_KEYBOARD;
            currentControler.SendCode(code);
        }

        /// <summary>
        /// 控制键盘的按键释放
        /// </summary>
        /// <param name="keyCode"></param>
        public void KeyUp(Keys keyCode)
        {
            KeyBoardEvent code = new KeyBoardEvent(KeyBoardType.Key_Up, keyCode);
            code.Head = CodeHead.CONTROL_KEYBOARD;
            currentControler.SendCode(code);
        }

        #endregion
      
        #region  文件控制

        /// <summary>
        /// 更新ExplorerView
        /// </summary>
        /// <param name="IsServer"></param>
        public void UpdateExplorerView(bool IsServer)
        {
            if (IsServer)
            {
                string path = ltv_HostExplorer.Tag as string;
                if (path == null || path == "")
                    GetDiskDetial();
                else
                    GetDirectoryDetial(path);
            }
            else
            {
                string path = ltv_MyExplorer.Tag as string;
                if (path == null || path == "")
                    ICanSeeYou.Common.IO.OpenRoot(ltv_MyExplorer, imageKey);
                else
                    ICanSeeYou.Common.IO.OpenDirectory(path, ltv_MyExplorer, imageKey);
            }
        }

        /// <summary>
        /// 显示主机的磁盘
        /// </summary>
        /// <param name="diskcode">磁盘指令</param>
        public void ShowDisks(DisksCode diskcode)
        {
            DiskStruct[] disk = diskcode.Disks;
            if (disk != null && disk.Length != 0)
            {
                ltv_HostExplorer.Items.Clear();
                ListViewItem[] dItems = new ListViewItem[disk.Length];
                ltv_HostExplorer.Tag = "";

                string name;
                for (int i = 0; i < disk.Length; i++)
                {
                    name = ICanSeeYou.Common.IO.DiskToString(disk[i].Name, true);
                    dItems[i] = new ListViewItem(name);
                    //文件夹图标
                    dItems[i].ImageKey = (string)imageKey["Disk"];
                    dItems[i].Tag = disk[i];
                    UpdateListView(dItems[i]);
                }
            }
        }

        private void ListViewAddItem(object Item)
        {
            ltv_HostExplorer.Items.Add((ListViewItem)Item);
        }

        private void UpdateListView(ListViewItem Item)
        {
            ltv_HostExplorer.Invoke(new ListViewAddEvent(ListViewAddItem), new object[] { Item });
        }

        private void ListViewClear()
        {
            ltv_HostExplorer.Items.Clear();
        }

        /// <summary>
        /// 显示主机上的文件
        /// </summary>
        /// <param name="explorer">主机指令</param>
        public  void ShowHostDirectory(ExplorerCode explorer)
        {
            DirectoryStruct[] directorys;
            FileStruct[] files;
            if (!explorer.Available)
            {
                MessageBox.Show("当前路径无法访问!");
                return;
            }
            ltv_HostExplorer.Invoke(new ClearEvent(ListViewClear));
            directorys = explorer.Directorys;
            files = explorer.Files;

            //记录当前目录(用于下载或上传文件)
            ltv_HostExplorer.Tag = explorer.Path;
            //添加回退功能
            string parentPath = ICanSeeYou.Common.IO.GetParentPath(explorer.Path);

            DirectoryStruct lastDirectory = new DirectoryStruct(parentPath);
            ListViewItem lastItem = new ListViewItem(Constant.ParentPath);
            lastItem.ImageKey = (string)imageKey["LastPath"];
            lastItem.Tag = lastDirectory;

            UpdateListView(lastItem);

            ListViewItem[] dItems = new ListViewItem[directorys.Length];
            string name;
            for (int i = 0; i < directorys.Length; i++)
            {
                name = ICanSeeYou.Common.IO.GetName(directorys[i].Name);
                if (name != "")
                {
                    dItems[i] = new ListViewItem(name);
                    //文件夹图标
                    dItems[i].ImageKey = (string)imageKey["Directory"];
                    dItems[i].Tag = directorys[i];
                    UpdateListView(dItems[i]);
                }
            }

            ListViewItem[] fItems = new ListViewItem[files.Length];
            string type;
            for (int i = 0; i < files.Length; i++)
            {
                name = ICanSeeYou.Common.IO.GetName(files[i].Name);
                if (name != "")
                {
                    fItems[i] = new ListViewItem(name);
                    //文件图标
                    type = ICanSeeYou.Common.IO.GetFileType(files[i].Name).ToLower();
                    if (imageKey.Contains(type))
                        fItems[i].ImageKey = (string)imageKey[type];
                    else
                        fItems[i].ImageKey = (string)imageKey["Unknown"];
                    fItems[i].Tag = files[i];
                    UpdateListView(fItems[i]);
                }
            }
        }

        #endregion 
    }
}
