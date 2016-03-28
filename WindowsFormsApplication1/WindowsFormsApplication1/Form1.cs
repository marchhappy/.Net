using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void sevebutt_Click(object sender, EventArgs e)
        {
            openfolderBrowserDialog.ShowNewFolderButton = true;
            openfolderBrowserDialog.ShowDialog();   //打开选取文件对话框
            label.Text = openfolderBrowserDialog.SelectedPath;
            
        }

        private void buttonCon_Click(object sender, EventArgs e)
        {
            uiDota u = new uiDota();
            u.contentString = richTextBox.Text;
            u.endString = endtext.Text;
            u.intervalString = textBox1.Text;
            u.pathString = label.Text;
            Control c = new Control(u);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string file = @"test.dat";
            Stream f = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);

            
        }
    }
}
