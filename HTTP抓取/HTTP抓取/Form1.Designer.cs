namespace HTTP抓取
{
    partial class Form1
    {
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonGetHttp = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.buttonTye = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.timer_ = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonGetHttp
            // 
            this.buttonGetHttp.Location = new System.Drawing.Point(13, 32);
            this.buttonGetHttp.Name = "buttonGetHttp";
            this.buttonGetHttp.Size = new System.Drawing.Size(75, 23);
            this.buttonGetHttp.TabIndex = 0;
            this.buttonGetHttp.Text = "抓取HTTP";
            this.buttonGetHttp.UseVisualStyleBackColor = true;
            this.buttonGetHttp.Click += new System.EventHandler(this.buttonGetHttp_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 96);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(479, 282);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("http://www.xianhuanet.cn/woaikalegou/", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // buttonTye
            // 
            this.buttonTye.Location = new System.Drawing.Point(252, 33);
            this.buttonTye.Name = "buttonTye";
            this.buttonTye.Size = new System.Drawing.Size(75, 23);
            this.buttonTye.TabIndex = 3;
            this.buttonTye.Text = "查看异常";
            this.buttonTye.UseVisualStyleBackColor = true;
            this.buttonTye.Click += new System.EventHandler(this.buttonTye_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(13, 67);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 4;
            this.buttonTest.Text = "跳转页面";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // timer_
            // 
            this.timer_.Interval = 1000;
            this.timer_.Tick += new System.EventHandler(this.timer_判断_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 378);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonTye);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.buttonGetHttp);
            this.Name = "Form1";
            this.Text = "抓取HTTP";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetHttp;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonTye;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Timer timer_;
    }
}

