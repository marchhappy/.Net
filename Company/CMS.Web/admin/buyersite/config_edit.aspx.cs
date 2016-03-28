using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Common;

namespace CMS.Web.admin.buyersite
{
    public partial class config_edit : Web.UI.ManagePage
    {        
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0; //编辑的信息ID
        private int bid = 0; // dt_buyersite 表ID
        

        protected void Page_Load(object sender, EventArgs e)
        {
            bid = DTRequest.GetQueryInt("bid", 0);        

            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.buyersite_config().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("buyersiteconfigs", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (bid > 0)
                {
                    txtUserName.Text = new BLL.buyersite().GetUserName(bid);
                }

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {            

            if (_id < 1) return;

            BLL.buyersite_config bll = new BLL.buyersite_config();
            var ds = bll.GetList(" id=" + _id.ToString());

            if (ds.Tables[0].Rows.Count == 0) return;

            DataRow dr = ds.Tables[0].Rows[0];

            cbIsLock.Checked = dr["stat"].ToString() == "1" ? true : false;

            txtSiteName.Text = dr["site_name"].ToString();
            txtSiteDomain.Text = dr["site_domain"].ToString();
            txtSiteConfig.Text = dr["site_config"].ToString();
            var bu = new BLL.users().GetModel(Convert.ToInt32(dr["user_id"].ToString()));
            txtUserName.Text = bu == null ? "" : bu.user_name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd(int user_id)
        {
            
            Model.buyersite_config model = new Model.buyersite_config();
            BLL.buyersite_config bll = new BLL.buyersite_config();

            model.user_id = user_id;
            model.site_type = 1;
            model.site_name = txtSiteName.Text.Trim();
            model.site_domain = txtSiteDomain.Text.Trim();
            model.site_config = txtSiteConfig.Text.Trim();
            model.add_time = DateTime.Now;
            model.update_time = DateTime.Now;
            model.stat = cbIsLock.Checked == true ? 1 : 4;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加站点:" + model.site_name); //记录日志
                if (bid > 0)
                {
                    new BLL.buyersite().AppliedCrement(bid, true);
                }
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.buyersite_config bll = new BLL.buyersite_config();
            Model.buyersite_config model = new Model.buyersite_config()
            {
                id = _id,
                site_name = txtSiteName.Text.Trim(),
                site_domain = txtSiteDomain.Text.Trim(),
                site_config = txtSiteConfig.Text.Trim(),
                update_time = DateTime.Now,
                stat = cbIsLock.Checked == true ? 1 : 4
            };

            if (bll.Update(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改站点:" + model.site_name); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("buyersiteconfigs", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                string msbox = "CallSyncPost(\"" + this.id + "\")";
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            }
            else //添加
            {
                ChkAdminLevel("buyersiteconfigs", DTEnums.ActionEnum.Add.ToString()); //检查权限

                if (string.IsNullOrWhiteSpace(txtSiteName.Text))
                {
                    JscriptMsg("站点名称必填！", "");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSiteDomain.Text))
                {
                    JscriptMsg("访问域名必填！", "");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    JscriptMsg("站点所属用户名必填！", "");
                    return;
                }

                string userName = txtUserName.Text;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    JscriptMsg("站点所属用户名必填！", "");
                    return;
                }
                var user = new BLL.users().GetModel(userName);
                if (user == null)
                {
                    JscriptMsg("站点所属用户名未找到！", "");
                    return;
                }

                if (!DoAdd(user.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加站点信息成功！", "configlist.aspx");
            }
        }
    }
}