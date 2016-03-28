using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using PacketDotNet;
using System.Diagnostics;

namespace HTTP抓取
{
    class MySharpPcap 
    {
        public int ProcessID { get; set; }//进程ID
        public string ProcessName { get; set; }//进程名
        public long NetSendBytes { get; set; }//网络发送数据字节数
        public long NetRecvBytes { get; set; }//网络接收数据字节数
        public long NetTotalBytes { get; set; }//网络数据总字节数

        public MySharpPcap(string ProcessName)
        {
            foreach (Process item in Process.GetProcessesByName(ProcessName))
            {
               ProcessID = item.Id;
               ProcessName = item.ProcessName;
            }
        }

    }
}
