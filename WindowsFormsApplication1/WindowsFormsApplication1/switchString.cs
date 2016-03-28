using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    /// <summary>
    /// 执行字符串转换
    /// </summary>
    class switchString
    {
        

        public uiDota ui;
        public switchString(uiDota dota)
        {
            ui = dota;
        }

        public List<string> switchz()
        {

            return null;
        }
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <returns>返回是否保存成功</returns>
        public bool save()
        {

            return false;
        }

    }
    /// <summary>
    /// ui 保存数据
    /// </summary>
    struct uiDota
    {
        public string pathString { get; set; }
        public string intervalString { get; set; }
        public string endString { get; set; }
        public string contentString { get; set; }
    }
    
}
