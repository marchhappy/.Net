<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.oauth_login" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="CMS.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by CMS Template Engine at 2016-03-19 12:27:41.
		本页面代码由模板引擎生成于 2016-03-19 12:27:41. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>合作网站登录 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n$(function(){\r\n	tabs('#oauthTabs','click');\r\n	//初始化表单1\r\n	AjaxInitForm('#bindForm', '#btnSubmit1', 0, '#turl');\r\n	//初始化表单2\r\n	AjaxInitForm('#oauthForm', '#btnSubmit2', 0, '#turl');\r\n});\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<div class=\"header\">\r\n    <div class=\"width-th\">\r\n        <a href=\"index.html\" class=\"fl logo\"><img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/logo.png\" /></a>\r\n        <div class=\"fr\">\r\n            <a href=\"javascript:;\" class=\"btn sign-in\" id=\"userCenterDoorBtn1\">登录</a>\r\n            <a href=\"javascript:;\" class=\"btn sign-up\" id=\"userCenterDoorBtn2\">注册</a>\r\n        </div>\r\n        <div class=\"nav fr\">\r\n            <ul>\r\n                <li><a id=\"snav1\" href=\"");
	templateBuilder.Append("<%linkurl(\" index\")%>");
	templateBuilder.Append("\" class=\"active\"><span>首页</span></a></li>\r\n                <li><a id=\"snav2\" href=\"");
	templateBuilder.Append("<%linkurl(\" signproduct\")%>");
	templateBuilder.Append("\">产品服务</a></li>\r\n                <li><a id=\"snav3\" href=\"");
	templateBuilder.Append("<%linkurl(\" homeplan\")%>");
	templateBuilder.Append("\">套餐购买</a></li>\r\n                <li><a id=\"snav4\" href=\"");
	templateBuilder.Append("<%linkurl(\" news_list\",54)%>");
	templateBuilder.Append("\">新闻公告</a></li>\r\n                <li><a id=\"snav5\" href=\"");
	templateBuilder.Append("<%linkurl(\" helpamount\")%>");
	templateBuilder.Append("\">帮助信息</a></li>\r\n                <li><a id=\"snav6\" href=\"");
	templateBuilder.Append("<%linkurl(\" signabout\")%>");
	templateBuilder.Append("\">关于我们</a></li>\r\n                <li><a id=\"snav7\" href=\"");
	templateBuilder.Append("<%linkurl(\" signcontact\")%>");
	templateBuilder.Append("\">联系我们</a></li>\r\n            </ul>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<script type=\"text/javascript\">\r\n    function SysNavnalSet(key) {\r\n        // 设置当前导航高亮\r\n        setTimeout(function () { $('#snav' + key).addClass('active'); }, 5);\r\n    }\r\n    $.ajax({\r\n        type: \"POST\",\r\n        url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n        dataType: \"json\",\r\n        timeout: 20000,\r\n        success: function (data, textStatus) {\r\n            if (data.status == 1) {\r\n                var strOut = '");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("'; //退出\r\n                var strCnt = '");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("'; //会员中心\r\n                $('#userCenterDoorBtn1').attr('href', strOut).html('退出');\r\n                $('#userCenterDoorBtn2').attr('href', strCnt).html('会员中心');\r\n            } else {\r\n                var strReg = '");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("'; //注册\r\n                var strSig = '");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("'; //登陆\r\n                $('#userCenterDoorBtn1').attr('href', strReg).html('注册');\r\n                $('#userCenterDoorBtn2').attr('href', strSig).html('登陆');\r\n            }\r\n        }\r\n    });\r\n</");
	templateBuilder.Append("script>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n<div class=\"main-box\">\r\n  <div class=\"section clearfix\">\r\n    <div class=\"main-tit\">\r\n      <h2>合作网站登录</h2>\r\n    </div>\r\n    <div id=\"oauthTabs\" class=\"inner-box\">\r\n      <!--选项卡-->\r\n      <div id=\"tabHead\" class=\"tab-head\">\r\n        <ul>\r\n          <li>\r\n            <a class=\"selected\" href=\"javascript:;\">绑定已有的账号</a>\r\n          </li>\r\n          <li>\r\n            <a href=\"javascript:;\">创建新的账号</a>\r\n          </li>\r\n        </ul>\r\n      </div>\r\n      <!--/选项卡-->\r\n      \r\n      <!--选项内容-->\r\n      <form name=\"bindForm\" id=\"bindForm\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_oauth_bind\">\r\n      <div class=\"dl-list tab-content\" style=\"display:block;\">\r\n        <dl>\r\n          <dt>用户名：</dt>\r\n          <dd><input name=\"txtUserName\" type=\"text\" class=\"input txt\" datatype=\"*\"  nullmsg=\"请输入用户名\" sucmsg=\" \" /></dd>\r\n        </dl>\r\n        <dl>\r\n          <dt>密　码：</dt>\r\n          <dd><input name=\"txtPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\"  nullmsg=\"请输入密码\" sucmsg=\" \" /></dd>\r\n        </dl>\r\n        <dl>\r\n          <dt></dt>\r\n          <dd><input id=\"btnSubmit1\" name=\"btnSubmit1\" type=\"submit\" class=\"btn\" value=\"立即绑定\" /></dd>\r\n        </dl>\r\n      </div>\r\n      </form>\r\n      \r\n      <form name=\"oauthForm\" id=\"oauthForm\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_oauth_register\">\r\n      <div class=\"dl-list tab-content\">\r\n        <dl>\r\n          <dt>电子邮箱：</dt>\r\n          <dd><input name=\"txtEmail\" type=\"text\" class=\"input txt\" datatype=\"e\"  nullmsg=\"请输入邮箱地址\" sucmsg=\" \" /></dd>\r\n        </dl>\r\n        <dl>\r\n          <dt>手机号码：</dt>\r\n          <dd><input name=\"txtMobile\" type=\"text\" class=\"input txt\" datatype=\"m\"  nullmsg=\"请输入手机号码\" sucmsg=\" \" /></dd>\r\n        </dl>\r\n        <dl>\r\n          <dt>登录密码：</dt>\r\n          <dd><input name=\"txtPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\"  nullmsg=\"请设置密码\" sucmsg=\" \" /></dd>\r\n        </dl>\r\n        <dl>\r\n          <dt></dt>\r\n          <dd><input id=\"btnSubmit2\" name=\"btnSubmit1\" type=\"submit\" class=\"btn\" value=\"创建新账户\" /></dd>\r\n        </dl>\r\n      </div>\r\n      </form>\r\n      <!--/选项内容-->\r\n      <input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n    </div>\r\n    \r\n  </div>\r\n</div>\r\n\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div class=\"footer\">\r\n    <div class=\"width-th footer-1\">\r\n        <div class=\"x3\">\r\n            <div class=\"x3-2\">\r\n                <h3>关于我们</h3>\r\n                <p>重庆亿奇达网络科技有限公司致力于开发一套游戏货源电子交易平台，公司创办人为一名90后在校大学生，三年创业，成功带领了公司10多名员工一起奋斗至今！公司主营业务为游戏点卡，是公司程序设计和安全运营十分看重，因此公司长期招聘优秀程序员，让我们团结在一起一起努力吧！</p>\r\n            </div>\r\n        </div>\r\n        <div class=\"x3 footer-link\">\r\n            <div class=\"x3-2\">\r\n                <h3>快速链接</h3>\r\n                <ul>\r\n                    <li><a href=\"");
	templateBuilder.Append("<%linkurl(\" signproduct\")%>");
	templateBuilder.Append("\"\">产品服务</a></li>\r\n                    <li><a href=\"");
	templateBuilder.Append("<%linkurl(\" homeplan\")%>");
	templateBuilder.Append("\">套餐购买</a></li>\r\n                    <li><a href=\"");
	templateBuilder.Append("<%linkurl(\" news_list\",54)%>");
	templateBuilder.Append("\">新闻公告</a></li>\r\n                    <li><a href=\"");
	templateBuilder.Append("<%linkurl(\" helpamount\")%>");
	templateBuilder.Append("\">帮助信息</a></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"x3 footer-contact\">\r\n            <div class=\"x3-2\">\r\n                <h3>联系我们</h3>\r\n                <ul>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/rexian.png\" class=\"fl\" />\r\n                        <div class=\"fl\">\r\n                            <h5>服务热线</h5>\r\n                            <p>");
	templateBuilder.Append(Utils.ObjectToStr(site.tel));
	templateBuilder.Append("</p>\r\n                        </div>\r\n                    </li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/weixin.png\" class=\"fl\" />\r\n                        <div class=\"fl\">\r\n                            <h5>电子邮件</h5>\r\n                            <p>");
	templateBuilder.Append(Utils.ObjectToStr(site.email));
	templateBuilder.Append("</p>\r\n                        </div>\r\n                    </li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"x3\">\r\n            <div class=\"x3-2\">\r\n                <h3>关注亿奇达</h3>\r\n                <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/wei_b.png\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"copy\">\r\n        <div class=\"width-th\">");
	templateBuilder.Append(Utils.ObjectToStr(site.copyright));
	templateBuilder.Append("</div>\r\n    </div>\r\n</div>		");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
