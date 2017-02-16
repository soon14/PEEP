/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：Network.cs
        // 文件功能描述： 获取网络某些信息的类。
//----------------------------------------------------------------*/

using System;

using System.Net;
using System.Net.Sockets;

namespace ICanSeeYou.Common
{
    /// <summary>
    /// 获取网络某些信息的类
    /// </summary>
    public class Network
    {
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <param name="hostname">主机名</param>
        /// <returns></returns>
        public static string GetIpAdrress(string hostname)
        {
            string ip;
            try
            {
                IPHostEntry iphe = Dns.GetHostEntry(hostname);
                foreach (IPAddress address in iphe.AddressList)
                {
                    ip = address.ToString();
                    if (ip != "") return ip;
                }
            }
            catch
            {
            }
            return "";
        }

        /// <summary>
        /// 获取本地计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// 字符形式的IP地址转换为IPAddress实例
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static IPAddress ToIPAddress(string IP)
        {
            return  IPAddress.Parse(IP);
        }

        /// <summary>
        /// byte数组形式的IP地址转换为IPAddress实例
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static IPAddress ToIPAddress(byte[] IP)
        {
            return new IPAddress(IP);
        }

        /// <summary>
        /// 分开IP地址为byte数组形式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static byte[] SplitIP(string ip)
        {
            byte[] IP=new byte[4];
            string []splitIp=ip.Split(new char[]{'.'});
            if(splitIp.Length!=4)return null;
            try
            {
                for (int i = 0; i < 4; i++)
                    IP[i] =byte.Parse(splitIp[i]);
            }
            catch
            {
                return null;
            }
            return IP;
        }
    }
}
