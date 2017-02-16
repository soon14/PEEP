/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：CodeHead.cs
        // 文件功能描述：指令头，当在网络通讯，对方收到指令的时候，先读取它的指令头，通过指令头来识别它的作用。
//----------------------------------------------------------------*/

namespace ICanSeeYou.Codes
{
    /// <summary>
    /// 指令的头部
    /// </summary>
    public enum CodeHead
    {

        #region 主通讯端

        /// <summary>
        /// 获取或发送主机信息(主机名和IP)
        /// </summary>
        HOST_MESSAGE,
        /// <summary>
        /// 关机
        /// </summary>
        SHUTDOWN,
        /// <summary>
        /// 重启
        /// </summary>
        REBOOT,

        /// <summary>
        /// 离开
        /// </summary>
        EXIT,
        /// <summary>
        /// 连接成功
        /// </summary>
        CONNECT_OK,
        /// <summary>
        /// 关闭连接
        /// </summary>
        CONNECT_CLOSE,
        /// <summary>
        /// 重新建立连接
        /// </summary>
        CONNECT_RESTART,

        /// <summary>
        /// 关闭程序
        /// </summary>
        CLOSE_APPLICATION,

        /// <summary>
        /// 接收失败
        /// </summary>
        FAIL,
        /// <summary>
        /// 密码设置
        /// </summary>
        PASSWORD,
        /// <summary>
        /// 密码修改成功
        /// </summary>
        CHANGE_PASSWORD_OK,
        /// <summary>
        /// 进行对话
        /// </summary>
        SPEAK,

        /// <summary>
        /// 屏幕控制的准备工作已经完成
        /// </summary>
        SCREEN_READY,
        /// <summary>
        /// 打开屏幕截取
        /// </summary>
        SCREEN_OPEN,
        /// <summary>
        /// 关闭屏幕截取
        /// </summary>
        SCREEN_CLOSE,
        /// <summary>
        /// 屏幕发送失败
        /// </summary>
        SCREEN_FAIL,
        /// <summary>
        /// 屏幕发送成功
        /// </summary>
        SCREEN_SUCCESS,
        /// <summary>
        /// 请求获取屏幕
        /// </summary>
        SCREEN_GET,

        /// <summary>
        /// 更新服务端
        /// </summary>
        UPDATE,
        /// <summary>
        /// 更新已经准备好
        /// </summary>
        UPDATE_READY,
        /// <summary>
        /// 更新失败
        /// </summary>
        UPDATE_FAIL,
        /// <summary>
        /// 服务端的版本
        /// </summary>
        VERSION,

        #endregion

        #region 控制鼠标或键盘
        /// <summary>
        /// 控制鼠标
        /// </summary>
        CONTROL_MOUSE,
        /// <summary>
        /// 控制键盘
        /// </summary>
        CONTROL_KEYBOARD,

        #endregion

        #region 文件传输

        /// <summary>
        /// 获取磁盘信息
        /// </summary>
        GET_DISKS,
        /// <summary>
        /// 发送磁盘信息
        /// </summary>
        SEND_DISKS,
        /// <summary>
        /// 请求进入(文件夹路径)
        /// </summary>
        GET_DIRECTORY_DETIAL,
        /// <summary>
        /// 发送文件夹内的信息
        /// </summary>
        SEND_DIRECTORY_DETIAL,
        /// <summary>
        /// 获取文件详细信息
        /// </summary>
        GET_FILE_DETIAL,
        /// <summary>
        /// 发送文件详细信息
        /// </summary>        
        SEND_FILE_DETIAL,

        /// <summary>
        /// 发出获取文件的请求
        /// </summary>
        GET_FILE,
        /// <summary>
        /// 发出发送文件的请求
        /// </summary>
        SEND_FILE,
        /// <summary>
        /// 获取文件的服务端已经准备好
        /// </summary>
        GET_FILE_READY,
        /// <summary>
        /// 发送文件的服务端已经准备好
        /// </summary>
        SEND_FILE_READY,
        /// <summary>
        /// 文件传输完毕
        /// </summary>
        FILE_TRAN_END,

        #endregion

    }
}
