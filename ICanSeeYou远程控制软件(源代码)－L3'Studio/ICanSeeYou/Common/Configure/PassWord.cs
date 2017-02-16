/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：PassWord.cs
        // 文件功能描述：密码操作类。
//----------------------------------------------------------------*/

using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICanSeeYou.Configure
{   
    /// <summary>
    /// 密码操作
    /// </summary>
    public class PassWord
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <returns></returns>
        public static string  MD5Encrypt(string buffer)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(buffer));
               return System.Text.Encoding.Unicode.GetString(result);
            }
            catch {
                return "";
            }
        }

        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="filename"></param>
        public static bool Save(string filename, string Md5PassWord)
        { 
            FileStream stream=null;
            try
            {
                if (Md5PassWord == "") return false;
                PassWordFile pwdFile = new PassWordFile();
                pwdFile.PassWord = Md5PassWord;
                if (File.Exists(filename)) File.Delete(filename);
                stream= new FileStream(filename, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, pwdFile);
                if (stream != null)
                    stream.Close();
                return true;
            }
            catch {
                if (stream != null)
                    stream.Close();
                return false;
            }
        }

        /// <summary>
        /// 读取密码
        /// </summary>
        /// <param name="filename"></param>
        public static string Read(string filename)
        {
            if (!File.Exists(filename)) return "";
            FileStream stream = null;
            try
            {
                stream= new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                PassWordFile pwdFile = (PassWordFile)formatter.Deserialize(stream);
                if (stream != null)
                    stream.Close();
                return pwdFile.PassWord;                
            }
            catch
            {
                if (stream != null)
                    stream.Close();
                return "";
            }
        }
    }
}
