using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CMS.Web
{
    /// <summary>
    /// 全局数据处理
    /// 1.在线人数计数
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        //系统启动时
        protected void Application_Start(object sender, EventArgs e)
        {
            //重置在线人数
            Application["user_online"] = 0; 
        }

        //系统结束时
        protected void Application_End(object sender, EventArgs e)
        {

        }

        //用户会话开始
        protected void Session_Start(object sender, EventArgs e)
        {
            //增加在线人数计数
            Application.Lock();
            Application["user_online"] = (int)Application["user_online"] + 1;
            Application.UnLock(); 
        }

        //用户会话结束
        protected void Session_End(object sender, EventArgs e)
        {
            //减少在线人数计数
            Application.Lock();
            Application["user_online"] = (int)Application["user_online"] - 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

    }
}