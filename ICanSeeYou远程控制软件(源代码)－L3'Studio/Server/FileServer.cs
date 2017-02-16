/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：FileServer.cs
        // 文件功能描述：文件服务类，响应客户端的需求，上传文件或接受文件
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;

using ICanSeeYou.Bases;
using ICanSeeYou.Codes;

namespace Server
{
    /// <summary>
    /// 文件服务端
    /// </summary>
    public class FileServer:BaseServer
    {
        /// <summary>
        /// 返回一个文件服务端实例
        /// </summary>
        /// <param name="port">文件传输端口</param>
        public FileServer(int port)
            : base(port)
        {
            base.Execute = new ExecuteCodeEvent(fileExecuteCode);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="msg">指令</param>
        private void fileExecuteCode(BaseCommunication sender, Code code)
        {
            switch (code.Head)
            {
                case CodeHead.CONNECT_OK:
                    //displayMessage("准备发送文件...");
                    // ICanSeeYou.Common.IO.UploadFile(sender,uploadFile);                    
                    break;
                case CodeHead.SEND_FILE:
                   // displayMessage("保存文件.");
                    ICanSeeYou.Common.IO.SaveFile(sender, (FileCode)code);
                    ICanSeeYou.Common.IO.EndTranFile(sender);
                    break;
                case CodeHead.GET_FILE:
                   // displayMessage("上传文件...");
                    ICanSeeYou.Common.IO.UploadFile(sender, (FileCode)code);
                    break;
                case CodeHead.FILE_TRAN_END:
                    ICanSeeYou.Common.IO.EndTranFile(sender);
                   // displayMessage("接收文件完毕.");
                    break;
                default:
                    break;
            }
        }
    }
}
