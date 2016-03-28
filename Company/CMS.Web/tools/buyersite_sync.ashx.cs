using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using CMS.Web.UI;
using CMS.Common;
using System.Web.Script.Serialization;

namespace CMS.Web.tools
{
    /// <summary>
    /// buyersite_sync 的摘要说明
    /// </summary>
    public class buyersite_sync : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable { get { return false; } }

        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置信息
        HttpResponse Response { get; set; }
        string CallBackFun { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            this.Response = context.Response;

            context.Response.ContentType = "text/plain";
            this.CallBackFun = DTRequest.GetQueryString("callback");

            if (!new ManagePage().IsAdminLogin())
            {
                EchoErr("尚未登录或已超时，请登录后操作！");
                return;
            }


            string action = DTRequest.GetQueryString("action");

            var bsc = new BLL.buyersite_config().GetList(" id=1");

            if (bsc == null) return;
            if (bsc.Tables.Count == 0) return;
            if (bsc.Tables[0].Rows.Count == 0) return;

            List<string> jXml = new List<string>();
            for (int i = 0; i < bsc.Tables[0].Columns.Count; i++)
            {
                jXml.Add("\"" + bsc.Tables[0].Columns[i].ColumnName + "\":\"" + bsc.Tables[0].Rows[0][i].ToString() + "\"");
            }

            EchoOk(new { site = 1, xml = "{" + string.Join(",", jXml) + "}" });
        }


        void EchoOk(object msg)
        {
            var jsArg = new JavaScriptSerializer().Serialize(new { status = 1, msg = msg });
            if (string.IsNullOrWhiteSpace(this.CallBackFun))
            {
                Response.Write(jsArg);
            }
            else
            {
                Response.Write(this.CallBackFun.Trim() + "(" + jsArg + ");");
            }
        }

        void EchoErr(string msg)
        {
            if (string.IsNullOrWhiteSpace(this.CallBackFun))
                Response.Write("{\"status\": 0, \"msg\": \"" + msg + "\"}");
            else
                Response.Write(this.CallBackFun.Trim() + "({\"status\": 0, \"msg\": \"" + msg + "\"});");
        }

        
    }
}