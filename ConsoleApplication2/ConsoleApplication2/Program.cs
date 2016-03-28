using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication2
{
    class Program
    {
        static List<users> list = new List<users>();
        static void Main(string[] args)
        {
            
            read("c://test.txt");
            serialize(list, "c://test.dat");
            
            Console.Read();
            
        }

        /// <summary>
        /// 序列化账号
        /// </summary>
        /// <param name="us"></param>
        static void serialize(object us,string pash)
        {
            Stream fStream = new FileStream(pash, FileMode.Create, FileAccess.Write);
            BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
            
            binFormat.Serialize(fStream, list);
            fStream.Close();
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="pash"></param>
        static object noSerialize(string pash)
        {
            Stream fStream = new FileStream(pash, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器

            return binFormat.Deserialize(fStream);
        }
        /// <summary>
        /// 读取账号信息,并且保存到list属性中
        /// </summary>
        /// <param name="pash"></param>
        /// <returns></returns>
        static List<users> read(string pash)
        {
            string[] namestring = File.ReadAllLines(pash);
            users name;
            foreach (string item in namestring)
            {
                name = new users();
                string tempstring=item.Replace(" ","");
                tempstring = item.Replace("----", "|");
                tempstring = tempstring.Remove(tempstring.Length - 4, 4);
                string[] stringshuzu = tempstring.Split("|".ToCharArray(), 17);
                name.email = stringshuzu[0];
                name.qq = stringshuzu[1];
                name.user_name = stringshuzu[4];
                name.group = stringshuzu[5];
                name.telphone = stringshuzu[6];
                name.nick_name = stringshuzu[7];
                name.Real_id = stringshuzu[9];
                name.mobile = stringshuzu[10];
                name.area = stringshuzu[11];
                try
                {
                    name.Subordinate = int.Parse(stringshuzu[12].Remove(stringshuzu[12].Length - 1, 1));
                    name.superior = int.Parse(stringshuzu[8]);
                    name.id = int.Parse(stringshuzu[2]);
                }
                catch (Exception)
                {
                    continue;
                }
                list.Add(name);
            }
            
            return list;
        }
    }
}
