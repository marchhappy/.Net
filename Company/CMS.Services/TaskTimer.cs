using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CMS.Services
{
    /// <summary>
    /// 任务定时执行
    /// </summary>
    public sealed class TaskTimer : IDisposable
    {
        /// <summary>
        /// 定时器
        /// </summary>
        Timer _watchWorker;
        /// <summary>
        /// 日志记录
        /// </summary>
        LogHelper logRun = new LogHelper(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy_MM_dd") + ".log");
        /// <summary>
        /// 延迟启动时间
        /// </summary>
        double WatchTimerMillisecond = 1000;
        string TaskMessage = "";
        /// <summary>
        /// 服务运行状态
        /// </summary>
        public string serverType = ServiceStatusType.Stoped.ToString();

        /// <summary>
        /// 监视轮询工作
        /// 发现有可执行的任务时，启动该任务所在的驱动以使其执行。
        /// </summary>
        public void Working(object sender, ElapsedEventArgs args)
        {
            //Note:线程锁定
            lock (this)
            {
                _watchWorker.Stop();
                logRun.WriteLine("---- Timer Begin ----");
                serverType = ServiceStatusType.Runing.ToString();
                //实际工作
                if (!string.IsNullOrEmpty(TaskMessage))
                {
                    logRun.WriteLine("请求:{0}", TaskMessage);
                    System.Net.HttpWebRequest webrequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(TaskMessage);
                    System.Net.HttpWebResponse webresponse = (System.Net.HttpWebResponse)webrequest.GetResponse();//请求连接,并反回数据
                    Stream stream = webresponse.GetResponseStream();//把返回数据转换成流文件
                    byte[] rsByte = new Byte[webresponse.ContentLength];  //把流文件转换为字节数组
                    try
                    {
                        stream.Read(rsByte, 0, (int)webresponse.ContentLength);
                        string HTML = System.Text.Encoding.Default.GetString(rsByte, 0, rsByte.Length).ToString();
                        logRun.WriteLine("结果:{0}", HTML);
                    }
                    catch (Exception exp)
                    {
                        logRun.WriteLine("异常:{0}", exp.ToString());
                    }
                }
                logRun.WriteLine("---- Timer End ----");
                _watchWorker.Start();
            }
        }

        /// <summary>
        /// 服务任务
        /// </summary>
        public void Start()
        {
            //Note:线程锁定
            lock (this)
            {
                logRun.WriteLine("----- 服务启动开始 -----");
                //Note:初始化计时器
                _watchWorker = new Timer(WatchTimerMillisecond);
                _watchWorker.Elapsed += Working;
                _watchWorker.Start();
                serverType = ServiceStatusType.Started.ToString();
                logRun.WriteLine("----- 服务启动完成 -----");
            }
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        public void Stop()
        {
            //Note:线程锁定
            lock (this)
            {
                if (_watchWorker == null) return;
                logRun.WriteLine("----- 服务停止开始 -----");
                _watchWorker.Stop();
                //所有任务停止后释放计时器
                _watchWorker.Dispose();
                _watchWorker = null;
                serverType = ServiceStatusType.Stoped.ToString();
                logRun.WriteLine("----- 服务停止完成 -----");
            }
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            logRun.WriteLine("----- 服务资源释放开始 -----");
            logRun.WriteLine("----- 服务资源释放结束 -----");
        }
    }

    /// <summary>
    /// 任务服务状态
    /// </summary>
    public enum ServiceStatusType
    {
        /// <summary>
        /// 已启动
        /// </summary>
        Started = 0,

        /// <summary>
        /// 已停止
        /// </summary>
        Stoped = 1,

        /// <summary>
        /// 运行中
        /// </summary>
        Runing = 2,
    }
}
