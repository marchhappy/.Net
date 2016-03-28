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
    class Control
    {

        HtmlElement wb;
        string uri;
        Model model;
        string[] property = new string[13] { "编号", "用户名", "公司名称", "客户级别", "所属地区", "余额", "已消费", "状态", "财务", "上级", "下级", "QQ", "电话" };
        Queue<SortedDictionary<string, string>> clientDota = new Queue<SortedDictionary<string, string>>();

        public Control(HtmlElement w, string uri)
        {
            this.uri = uri;
            this.wb = w;
            model=new Model(w,uri);
        }
        /// <summary>
        /// 获取客户数据,放入数据集合的控制器
        /// </summary>
        /// <returns></returns>
        public void GetVales()
        {

            while (wb != null)//等于空时,NewGetVales读取完毕,在此函数内部设置的 
            {
                while (!NewGetVales())
                {
                    Thread.Sleep(3000);
                }
                model.Next(wb, "前一页");
            }
        }
        /// <summary>
        /// 写入
        /// </summary>
        private void writeQueue()
        {
            SortedDictionary<string, string> tempSD;
            string temp = "";
            for (int i = 0; i < clientDota.Count; i++)
            {
                tempSD = clientDota.Dequeue();
                foreach (string item in tempSD.Keys)
                {
                    if (tempSD[item] == "" || tempSD[item] == null)
                    {
                        temp = temp + "null----";
                    }
                    else
                    {
                        temp = temp + tempSD[item] + "----";
                    }
                }
                Model.write_string("C:/test.txt", temp);
                temp = "";
            }
            tempSD = null;
            temp = null;
        }

        /// <summary>
        /// 获取客户数据,返回是否成功
        /// </summary>
        /// <returns></returns>
        private bool NewGetVales()
        {
            HtmlElement temp = wb;
            //判断获取元素是否成功
            if (temp == null)
            {
                return false;
            }

            temp = temp.FirstChild;//获取到表单的下一级元素
            if (temp == null)
            {
                return false;
            }

            SortedDictionary<string, string> tempIDictionary;


            HtmlElementCollection html_table = temp.Children; //获得下一级所有元素集合

            if (html_table.Count < 5)//页面标签小于5尚未加载完成
            {
                return false;
            }
            foreach (HtmlElement item in html_table)//获得每一行
            {
                tempIDictionary = new SortedDictionary<string, string>();//创建每一行的容器
                for (int i = 0; i < item.Children.Count; i++)
                {
                    if (i > 0 && i < item.Children.Count - 1)
                    {
                        tempIDictionary.Add(property[i - 1], item.Children[i].InnerText);
                    }
                }
                //get_Package("http://www.xianhuanet.cn/woaikalegou/Customer/CustomerEdit.aspx?PID="+tempIDictionary["编号"]+"&PageIndex=1&SearchType=PID&SearchValue=&RegionID=&CustomerLevelID=&Status=&RightType=&OrderBy=&BalanceStart=&BalanceEnd=&ConsumedStart=&ConsumedEnd=&UnLoginDay=0&PageSize=20&y=0", tempIDictionary);
                clientDota.Enqueue(tempIDictionary);
            }
            foreach (SortedDictionary<string, string> item in clientDota)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(get_Package_thread));
                thread.Start(item);
            }
            //多线程读取网页个人信息
            int int_i = 0;
            while (clientDota.Count - 2 > int_i)
            {
                int_i = 0;
                foreach (SortedDictionary<string, string> item in clientDota)
                {
                    if (item.Count > 15)
                    {
                        int_i++;
                    }
                }
                Thread.Sleep(500);
            }
            //写入,垃圾回收,页面判断
            writeQueue();//写入
            clientDota = new Queue<SortedDictionary<string, string>>();
            if (html_table.Count < 50)//小于100时,证明是最后一页了
            {
                wb = null;
            }
            GC.Collect();
            return true;

        }

        /// <summary>
        /// 获取网页信息
        /// </summary>
        private void get_Package_thread(object id)
        {
            SortedDictionary<string, string> sd = (SortedDictionary<string, string>)id;
            model.get_Package("http://www.xianhuanet.cn/woaikalegou/Customer/CustomerEdit.aspx?PID=" + sd["编号"] + "&PageIndex=1&SearchType=PID&SearchValue=&RegionID=&CustomerLevelID=&Status=&RightType=&OrderBy=&BalanceStart=&BalanceEnd=&ConsumedStart=&ConsumedEnd=&UnLoginDay=0&PageSize=20&y=0", sd);


        }
    }
}
