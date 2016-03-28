using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTP抓取
{
    class Model
    {

        HtmlElement wb;
        string uri;
        string Clickid = "pigkoo-pager-box";

        public Model(HtmlElement w, string uri)
        {
            this.uri = uri;
            this.wb = w;
        }
        
     



        /// <summary>
        /// 写入字符串,不覆盖原文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="strings">字符串</param>
        static public void write_string(string path, string strings)
        {
            StreamWriter sw=null;
            try
            {
                sw = File.AppendText(path);
            }
            catch (Exception)
            {
                
            }
            if (strings==null || strings=="")
            {
                sw.WriteLine("null");
                return;
            }
            sw.WriteLine(strings);
            sw.Flush();
            sw.Close(); 
        }
        /// <summary>
        /// 触发指定属性的点击事件
        /// </summary>
        /// <param name="html">页面的属性</param>
        /// <param name="label">需要触发的属性的值</param>
        public void Next(HtmlElement html, string label)
        {

            HtmlElement temp = html.Document.GetElementById(Clickid);
            if (temp != null)
            {
                temp = temp.FirstChild;
            }
            HtmlElementCollection tempColl = temp.Children;
            foreach (HtmlElement item in tempColl)
            {
                if (item.InnerText == label)
                {
                    item.InvokeMember("Click");
                }
            }
        }



        /// <summary>
        /// 拆分字符串,根据传入的键的名称,返回对应Cookie的键值字符串
        /// </summary>
        /// <param name="key">键数组</param>
        /// <param name="Uri">资源地址</param>
        /// <returns></returns>
        public SortedDictionary<string, string> get_session(string[] key, string Uri)
        {
             string stringSession = GetWebBrowserCookie.GetCookieInternal(new Uri(Uri), true);
            SortedDictionary<string, string> sess = new SortedDictionary<string, string>();
            foreach (var item in key)
            {
                string temp = stringSession.Remove(0, stringSession.IndexOf(item) + item.Length + 1);
                string value = "";
                if (temp.IndexOf(";") > 0)
                {
                    value = temp.Remove(temp.IndexOf(";"));
                }
                else
                {
                    value = temp;
                }

                sess.Add(item, value);
            }


            return sess;
        }
        /// <summary>
        /// 获取鲜花卡盟数据
        /// </summary>
        /// <param name="uri">uri资源</param>
        /// <param name="dota">需要存放数据的引用数据类型</param>
        /// <returns></returns>
        public string get_Package(string uri,SortedDictionary<string,string> dota)
        {

            HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(uri);
            //设置封包头
            httpWeb.ContentType = "GET";
            httpWeb.Referer = "http://www.xianhuanet.cn/woaikalegou/Customer/CustomerListNew.aspx";
            httpWeb.Host = "www.xianhuanet.cn";


            //设置cookie
            CookieContainer tempCook = new CookieContainer();
            SortedDictionary<string, string> sd_tempCook = get_session(new string[] { "login", "CNZZDATA1254137492", "tencentSig", "CNZZDATA1384227", "ASP.NET_SessionId", "pgv_pvi" }, "http://www.xianhuanet.cn/woaikalegou/Customer/CustomerListNew.aspx");
            foreach (string item in sd_tempCook.Keys)
            {
                tempCook.Add(new Uri("http://www.xianhuanet.cn"), new Cookie(item, sd_tempCook[item]));
                
            }
            httpWeb.CookieContainer = tempCook;
            
            //获取返回数据
            HttpWebResponse httRe = (HttpWebResponse)httpWeb.GetResponse();
            Stream stream = httRe.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            //存放数据
            dota.Add("身份证号", get_html("IdentityCard", content));
            dota.Add("Email", get_html("Email", content));
            dota.Add("联系电话", get_html("Phone", content));
            dota.Add("手机号码", get_html("Mobile", content));
            dota.Add("联系人姓名", get_html("ContactName", content));
            dota.Add("QQ", get_html("QQ", content));
            httpWeb = null;
            content = null;
            stream = null;
            httRe = null;
            sr = null;

            return content;
        }



        /// <summary>
        /// 获取页面,指定属性的值
        /// </summary>
        /// <param name="id">属性id</param>
        /// <param name="string_http">html页面字符串</param>
        /// <returns></returns>
        private string get_html(string id, string string_http)
        {
            //input属性,值的获取方法
            if (string_http.IndexOf("input name=\"" + id+"\"") > 0)
            {
                int int_temp_1 = string_http.IndexOf("input name=\"" + id + "\"");
                int int_temp_2 = string_http.IndexOf("id=\"" + id + "\"",int_temp_1);
                int int_temp = string_http.IndexOf("value=\"", int_temp_1, int_temp_2 - int_temp_1);
                string string_temp=null;
                if (int_temp>0)
                {
                    string_temp = string_http.Remove(0, int_temp + 7);
                    string_temp = string_temp.Remove(string_temp.IndexOf("\""));
                    
                }
                return string_temp;
            }
            //非input属性
            if (string_http.IndexOf("id=\"" + id + "\"") > 0)
            {
                int int_temp_1 = string_http.IndexOf("id=\"" + id + "\"");
                int int_temp_2 = string_http.IndexOf("</", int_temp_1);
                int int_temp = string_http.IndexOf(">", int_temp_1, int_temp_2 - int_temp_1);
                string string_temp = null;
                if (int_temp > 0)
                {
                    string_temp = string_http.Remove(0, int_temp+1);
                    string_temp = string_temp.Remove(string_temp.IndexOf("</"));

                }
                return string_temp;
            }
            return null;
        }
    
    }
}
