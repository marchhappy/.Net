using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HTTP抓取
{
    public partial class Form1 : Form
    {
        TextBox textHttp = new TextBox();
        

        public Form1()
        {
            InitializeComponent();
            establishText();
            textHttp.Hide();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void buttonGetHttp_Click(object sender, EventArgs e)
        {

            timer_.Enabled = true;
                 
            //等待页面加载完成
            

            
            //HtmlElement btn = new HtmlElement();
            
            
        }
        public void update_html()
        {
            
        }

        
        public void establishText()
        {
            this.textHttp.AcceptsReturn = true;
            this.textHttp.AcceptsTab = true;
            this.textHttp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textHttp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textHttp.Location = new System.Drawing.Point(0, 69);
            this.textHttp.Multiline = true;
            this.textHttp.Name = "textHttp";
            this.textHttp.Size = new System.Drawing.Size(479, 309);
            this.textHttp.TabIndex = 2;
            this.textHttp.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(textHttp);

        }
        

        private void buttonTye_Click(object sender, EventArgs e)
        {
            if (buttonTye.Text == "返回")
            {
                buttonTye.Text = "查看异常";
                webBrowser1.Show();
                textHttp.Hide();

            }
            else
            {
                buttonTye.Text = "返回";
                webBrowser1.Hide();
                textHttp.Show();
            }
            

        }
        /// <summary>
        /// 加载完成时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }


        private void Form1_Resize(object sender, EventArgs e)
        {    
            Size s = new Size(
                webBrowser1.Size.Width,
                this.Size.Height - 150);
            textHttp.Size = s;
            webBrowser1.Size = s;
            //webBrowser1.Size
        }


        private void buttonTest_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("http://www.xianhuanet.cn/woaikalegou/Customer/CustomerListNew.aspx");
        }

        private void timer_判断_Tick(object sender, EventArgs e)
        {
            HtmlElement temp = webBrowser1.Document.GetElementById("SunDataTable");
            if(temp != null && temp.Children[0].Children.Count > 5)
            {
                Control model = new Control(temp, webBrowser1.Url.ToString());
                ThreadStart ts = new ThreadStart(model.GetVales);
                Thread getDota = new Thread(ts);
                getDota.Start();
                timer_.Enabled = false;
            }
            //创建多线程执行
            
        }


    }
}
