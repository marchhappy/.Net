using System;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace CMS.Services
{
    /// <summary>
    /// 系统服务
    /// </summary>
    public class TaskService : ServiceBase
    {
        /// <summary>
        /// 日志记录
        /// </summary>
        static LogHelper logRun = new LogHelper(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy_MM_dd") + ".log");

        #region 应用程序入口
        /// <summary>
        /// 应用程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var newMutexCreated = false;
                var mutexName = System.Guid.NewGuid().ToString(); //唯一的名称
                try
                {
                    var obj = new Mutex(false, mutexName, out newMutexCreated);
                }
                catch (Exception ex)
                {
                    logRun.WriteLine(string.Format("创建互斥体[mutexName = {0}]异常{1}，程序退出", mutexName, ex));
                    Environment.Exit(1);
                }
                if (newMutexCreated)
                {
                    logRun.WriteLine("创建互斥体[mutexName = {0}]成功，开始创建服务", mutexName);
                    //无参数时直接运行服务
                    if ((!Environment.UserInteractive))
                    {
                        logRun.WriteLine("开始启动服务");
                        RunAsService();
                        return;
                    }
                    if (args != null && args.Length > 0)
                    {
                        if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                        {
                            logRun.WriteLine("安装系统服务...");
                            SelfInstaller.InstallMe();
                            return;
                        }
                        if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                        {
                            logRun.WriteLine("卸载系统服务...");
                            SelfInstaller.UninstallMe();
                            return;
                        }
                        if (args[0].Equals("-t", StringComparison.OrdinalIgnoreCase) ||
                            args[0].Equals("-c", StringComparison.OrdinalIgnoreCase))
                        {
                            logRun.WriteLine("在控制台下运行...[{0}]", Assembly.GetExecutingAssembly().Location);
                            RunAsConsole(args);
                            return;
                        }
                        const string tip =
                            "Invalid argument! note:\r\n -i is install the service.;\r\n -u is uninstall the service.;\r\n -t or -c is run the service on console.";
                        Console.WriteLine(tip);
                        Console.ReadLine();
                    }
                }
                else
                {
                    logRun.WriteLine("有一个实例正在运行，如要调试，请先停止其它正在运行的实例，程序退出。");
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                logRun.WriteLine("启动服务异常:[{0}]", ex);
            }
        }
        #endregion

        #region 运行方式配置
        /// <summary>
        /// 控制台下运行服务
        /// </summary>
        /// <param name="args"></param>
        private static void RunAsConsole(string[] args)
        {
            var service = new TaskService();
            service.OnStart(null);
            Console.ReadLine();
        }

        /// <summary>
        /// 以服务的方式运行服务
        /// </summary>
        private static void RunAsService()
        {
            var service = new TaskService();
            Run(service);
        }
        #endregion

        #region 服务初始化
        /// <summary>
        /// 服务显示名称
        /// </summary>
        private readonly string _displayName;

        /// <summary>
        /// 默认构造，相关初始化
        /// </summary>
        public TaskService()
        {
            _displayName = ConfigurationManager.AppSettings["ServiceDisplayName"].Trim();//服务显示名称
            CanPauseAndContinue = true;//服务运行时的暂停响应支持
            ServiceName = ConfigurationManager.AppSettings["ServiceName"].Trim();//服务名称
            logRun.WriteLine("服务类初始化完成");
        }
        #endregion

        #region 启动/停止/暂停/继续的相关支持
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                //if (_taskService == null)
                //    _taskService = new Task4WinService();
                //log.InfoFormat("try run the {0}.", _displayName);
                //_taskService.Start();
                //log.InfoFormat("{0} is runing.", _displayName);
            }
            catch (Exception ex)
            {
                logRun.WriteLine("启动服务时发生异常:[{0}]", ex);
                throw;
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        protected override void OnStop()
        {
            //log.InfoFormat("try stop the {0}.", _displayName);
            //_taskService.Stop();
            //log.InfoFormat("{0} is stoped.", _displayName);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        protected override void OnPause()
        {
            //log.InfoFormat("try pause the {0}", _displayName);
            //_taskService.Pause();
            //log.InfoFormat("{0} is pauseed\n", _displayName);
        }

        /// <summary>
        /// 继续
        /// </summary>
        protected override void OnContinue()
        {
            //log.InfoFormat("try continue the {0}", _displayName);
            //_taskService.Resume();
            //log.InfoFormat("{0} is continued\n", _displayName);
        }
        #endregion
    }

    #region 服务安装卸载
    /// <summary>
    /// 服务自安装
    /// </summary>
    public class SelfInstaller
    {
        private static readonly string exePath = Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// Install service
        /// </summary>
        /// <returns></returns>
        public static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Uninstall service
        /// </summary>
        /// <returns></returns>
        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { "/u", exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
    #endregion

    #region 服务安装配置
    /// <summary>
    /// 服务安装，安装后立即启动
    /// </summary>
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private static readonly string codeBase = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
        protected string ConfigServiceName = codeBase;
        protected string ConfigDescription = null;
        protected string DisplayName = codeBase;

        /// <summary>
        /// 安装
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent(); //在安装中取得配置中的名字必须。
            Committed += ServiceInstallerCommitted;

            var serviceName = ConfigurationManager.AppSettings["ServiceName"].Trim();
            var displayName = ConfigurationManager.AppSettings["ServiceDisplayName"].Trim();
            var desc = ConfigurationManager.AppSettings["ServiceDescription"].Trim();
            if (!string.IsNullOrEmpty(serviceName)) ConfigServiceName = serviceName;
            if (!string.IsNullOrEmpty(displayName)) DisplayName = displayName;
            if (!string.IsNullOrEmpty(desc)) ConfigDescription = desc;

            var processInstaller = new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem };
            var serviceInstaller = new ServiceInstaller
            {
                //自动启动服务，手动的话，每次开机都要手动启动。
                StartType = ServiceStartMode.Automatic,
                DisplayName = DisplayName,
                ServiceName = ConfigServiceName,
                Description = ConfigDescription
            };

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

        }

        /// <summary>
        /// 服务安装完成后自动启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceInstallerCommitted(object sender, InstallEventArgs e)
        {
            var controller = new ServiceController(ConfigServiceName);
            controller.Start();
        }

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

        }
    }
    #endregion
}
