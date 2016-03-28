using System;
namespace CMS.Model
{
    /// <summary>
    /// 会员主表
    /// </summary>
    [Serializable]
    public partial class users
    {
        public users()
        { }
        #region Model
        private int _id;
        private int _group_id = 0;
        private string _user_name;
        private string _salt;
        private string _password;
        private string _mobile = string.Empty;
        private string _email = string.Empty;
        private string _avatar = string.Empty;
        private string _nick_name = string.Empty;
        private string _sex = string.Empty;
        private DateTime? _birthday;
        private string _telphone;
        private string _area = string.Empty;
        private string _address = string.Empty;
        private string _qq = string.Empty;
        private string _msn = string.Empty;
        private decimal _amount = 0M;
        private int _point = 0;
        private int _exp = 0;
        private int _status = 0;
        private DateTime _reg_time = DateTime.Now;
        private string _reg_ip;
        private Model.users_login _model_login;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户组ID
        /// </summary>
        public int group_id
        {
            set { _group_id = value; }
            get { return _group_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 6位随机字符串,加密用到
        /// </summary>
        public string salt
        {
            set { _salt = value; }
            get { return _salt; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar
        {
            set { _avatar = value; }
            get { return _avatar; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string nick_name
        {
            set { _nick_name = value; }
            get { return _nick_name; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// MSN账号
        /// </summary>
        public string msn
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 经验值
        /// </summary>
        public int exp
        {
            set { _exp = value; }
            get { return _exp; }
        }
        /// <summary>
        /// 账户状态,0正常,1待验证,2待审核,3锁定
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_time
        {
            set { _reg_time = value; }
            get { return _reg_time; }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string reg_ip
        {
            set { _reg_ip = value; }
            get { return _reg_ip; }
        }
        #endregion

        #region 附加一个登录信息
        /// <summary>
        /// 附加登录信息
        /// </summary>
        public Model.users_login model_login
        {
            set { _model_login = value; }
            get { return _model_login; }
        }
        #endregion

    }

    /// <summary>
    /// 会员登录信息表
    /// </summary>
    [Serializable]
    public partial class users_login
    {
        public users_login()
        { }
        #region Model
        private DateTime _login_time = DateTime.Now;
        private string _login_ip;
        private int _login_wrong_time = 0;

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime login_time
        {
            set { _login_time = value; }
            get { return _login_time; }
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string login_ip
        {
            set { _login_ip = value; }
            get { return _login_ip; }
        }
        /// <summary>
        /// 错误登录尝试次数
        /// </summary>
        public int login_wrong_time
        {
            set { _login_wrong_time = value; }
            get { return _login_wrong_time; }
        }
        #endregion

    }
}