using System;
namespace CMS.Model
{
    /// <summary>
    /// 上传文件
    /// </summary>
    [Serializable]
    public partial class files
    {
        public files()
        { }
        #region Model
        private Int64 _id;
        private string _file_name;
        private string _file_path;
        private string _file_md5;
        private string _file_server;
        private DateTime _file_uptime;
        private int _file_upuser;
        private Int64 _file_usetimes;
        private int _file_state;
        private int _file_type;
        private string _file_endwith;
        private string _file_fullpath;
        /// <summary>
        /// 自增ID
        /// </summary>
        public Int64 id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string file_name
        {
            set { _file_name = value; }
            get { return _file_name; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_path
        {
            set { _file_path = value; }
            get { return _file_path; }
        }
        /// <summary>
        /// 文件HASH值
        /// </summary>
        public string file_md5
        {
            set { _file_md5 = value; }
            get { return _file_md5; }
        }
        /// <summary>
        /// 文件存储服务器
        /// </summary>
        public string file_server
        {
            set { _file_server = value; }
            get { return _file_server; }
        }
        /// <summary>
        /// 文件上传时间
        /// </summary>
        public DateTime file_uptime
        {
            set { _file_uptime = value; }
            get { return _file_uptime; }
        }
        /// <summary>
        /// 文件上传用户ID
        /// </summary>
        public int file_upuser
        {
            set { _file_upuser = value; }
            get { return _file_upuser; }
        }
        /// <summary>
        /// 文件被使用次数
        /// </summary>
        public Int64 file_usetimes
        {
            set { _file_usetimes = value; }
            get { return _file_usetimes; }
        }
        /// <summary>
        /// 文件状态0:未同步1:已同步-1:已删除
        /// </summary>
        public int file_state
        {
            set { _file_state = value; }
            get { return _file_state; }
        }
        /// <summary>
        /// 文件类型0:图片1:压缩包2:WORD等文档3:其它文件
        /// </summary>
        public int file_type
        {
            set { _file_type = value; }
            get { return _file_type; }
        }
        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string file_endwith
        {
            set { _file_endwith = value; }
            get { return _file_endwith; }
        }
        /// <summary>
        /// 文件上传后的物理路径
        /// </summary>
        public string file_fullpath
        {
            set { _file_fullpath = value; }
            get { return _file_fullpath; }
        }
        #endregion Model

    }
}