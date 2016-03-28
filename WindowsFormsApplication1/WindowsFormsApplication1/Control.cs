using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    class Control
    {
        public uiDota ui;
        /// <summary>
        /// 创建控制器实例,并且马上开始执行转换操作
        /// </summary>
        /// <param name="RichTest">需要转换文本</param>
        /// <param name="shouTest">间隔符</param>
        /// <param name="endTest">末位符号</param>
        public Control(uiDota ui)
        {
            this.ui = ui;
            convert();
        }
        /// <summary>
        /// 创建Control实例,自己设置属性后调用方法,开始转换操作
        /// </summary>
        public Control(){ }

        /// <summary>
        /// 执行转换
        /// </summary>
        /// <returns>返回是否成功</returns>
        public bool convert()
        {
            ui.contentString = ui.contentString.Replace("\t", ui.intervalString);
            ui.contentString = ui.contentString.Replace("\n", ui.endString+"\r\n" );
            try
            {
                File.WriteAllText(ui.pathString + @"\" + DateTime.Now.ToLongDateString() + ".txt", ui.contentString + "\n");
                return true;
            }
            catch (Exception )
            {
                File.WriteAllText(DateTime.Now.ToLongDateString() + ".txt", ui.contentString + "\n", Encoding.Default);
            }
            return false;
            
        }
        
        

    }
}
