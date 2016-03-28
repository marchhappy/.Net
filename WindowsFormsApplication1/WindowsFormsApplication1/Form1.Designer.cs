namespace WindowsFormsApplication1
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.sevebutt = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.first = new System.Windows.Forms.Label();
            this.endLabeli = new System.Windows.Forms.Label();
            this.endtext = new System.Windows.Forms.TextBox();
            this.buttonCon = new System.Windows.Forms.Button();
            this.openfolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(407, 134);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // sevebutt
            // 
            this.sevebutt.Location = new System.Drawing.Point(13, 141);
            this.sevebutt.Name = "sevebutt";
            this.sevebutt.Size = new System.Drawing.Size(75, 23);
            this.sevebutt.TabIndex = 1;
            this.sevebutt.Text = "保存位置";
            this.sevebutt.UseVisualStyleBackColor = true;
            this.sevebutt.Click += new System.EventHandler(this.sevebutt_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(94, 146);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(293, 12);
            this.label.TabIndex = 2;
            this.label.Text = "如果不选择保存位置,默认保存文件当前位置.账号.txt";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // first
            // 
            this.first.AutoSize = true;
            this.first.Location = new System.Drawing.Point(13, 173);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(53, 12);
            this.first.TabIndex = 4;
            this.first.Text = "间隔字符";
            // 
            // endLabeli
            // 
            this.endLabeli.AutoSize = true;
            this.endLabeli.Location = new System.Drawing.Point(192, 173);
            this.endLabeli.Name = "endLabeli";
            this.endLabeli.Size = new System.Drawing.Size(53, 12);
            this.endLabeli.TabIndex = 5;
            this.endLabeli.Text = "末尾字符";
            // 
            // endtext
            // 
            this.endtext.Location = new System.Drawing.Point(252, 170);
            this.endtext.Name = "endtext";
            this.endtext.Size = new System.Drawing.Size(100, 21);
            this.endtext.TabIndex = 6;
            // 
            // buttonCon
            // 
            this.buttonCon.Location = new System.Drawing.Point(15, 197);
            this.buttonCon.Name = "buttonCon";
            this.buttonCon.Size = new System.Drawing.Size(75, 23);
            this.buttonCon.TabIndex = 7;
            this.buttonCon.Text = "开始转换";
            this.buttonCon.UseVisualStyleBackColor = true;
            this.buttonCon.Click += new System.EventHandler(this.buttonCon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 290);
            this.Controls.Add(this.buttonCon);
            this.Controls.Add(this.endtext);
            this.Controls.Add(this.endLabeli);
            this.Controls.Add(this.first);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.sevebutt);
            this.Controls.Add(this.richTextBox);
            this.Name = "Form1";
            this.Text = "文件转换";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button sevebutt;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label first;
        private System.Windows.Forms.Label endLabeli;
        public System.Windows.Forms.TextBox endtext;
        private System.Windows.Forms.Button buttonCon;
        private System.Windows.Forms.FolderBrowserDialog openfolderBrowserDialog;
    }
}

