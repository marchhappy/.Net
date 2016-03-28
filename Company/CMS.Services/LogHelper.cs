using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMS.Services
{
    class LogHelper
    {
        string logFile = "";
        /// <summary>
        /// 不带参数的构造函数
        /// </summary>
        public LogHelper()
        {
        }
        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="logFile"></param>
        public LogHelper(string logFile)
        {
            this.logFile = logFile;
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一条信息，带参数
        /// </summary>
        /// <param name="fomarttext"></param>
        /// <param name="_params"></param>
        public void Write(string fomarttext, params object[] _params)
        {
            string text = fomarttext;
            if (_params.Length > 0)
            {
                text = string.Format(fomarttext, _params);
            }
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>
        public void Write(string logFile, string text)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一行信息
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一行信息带参数
        /// </summary>
        /// <param name="fomarttext"></param>
        /// <param name="_params"></param>
        public void WriteLine(string fomarttext, params object[] _params)
        {
            string text = fomarttext;
            if (_params.Length > 0)
            {
                text = string.Format(fomarttext, _params);
            }
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
    }
}