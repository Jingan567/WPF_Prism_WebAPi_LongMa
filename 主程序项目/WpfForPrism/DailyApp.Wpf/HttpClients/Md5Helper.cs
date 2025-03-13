using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.Wpf.HttpClients
{
    /// <summary>
    /// MD5工具类
    /// </summary>
    public class Md5Helper
    {
        /// <summary>
        /// MD5 UTF-8编码 32位
        /// </summary>
        /// <param name="content">明文</param>
        /// <returns>MD5结果</returns>
        public static string GetMd5(string content)
        {
            return string.Join("", MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(content))
                .Select(x => x.ToString("X2")));
            //Select 投影操作，将每个元素转换成16进制的字符串
            //Join用""将枚举连接成字符串
        }
    }
}
