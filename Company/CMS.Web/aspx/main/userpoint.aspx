<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.userpoint" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>我的积分 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" />\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/common.js\"></");
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


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n<div class=\"section clearfix\">\r\n  <div class=\"line30\"></div>\r\n\r\n  <div class=\"info-wrap\">\r\n    <!--左侧导航-->\r\n    ");

	templateBuilder.Append("    <div class=\"info-box\">\r\n      <div class=\"avatar-box\">\r\n        <a href=\"");
	templateBuilder.Append(linkurl("usercenter","avatar"));

	templateBuilder.Append("\" class=\"img-box\">\r\n          ");
	if (userModel.avatar!="")
	{

	templateBuilder.Append("\r\n            <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\" />\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n            <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/images/user-avatar.png\" />\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </a>\r\n        <h3>\r\n        ");
	if (userModel.nick_name!="")
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
	templateBuilder.Append("\r\n        ");
	}
	else
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n        </h3>\r\n        <p>余额：");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append(" 元</p>\r\n        <p>积分：");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append(" 分</p>					\r\n      </div>\r\n      <ul class=\"side-nav\">\r\n        <li>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("buyersite","list"));

	templateBuilder.Append("\">我的站点</a>          \r\n        </li>\r\n		<li>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\">订单管理</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("useraddress"));

	templateBuilder.Append("\">收货地址</a>\r\n        </li>\r\n        <li>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("useramount","recharge"));

	templateBuilder.Append("\">账户余额</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\">我的积分</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\">站内消息</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","invite"));

	templateBuilder.Append("\">邀请好友</a>\r\n        </li>\r\n        <li>\r\n          \r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","proinfo"));

	templateBuilder.Append("\">个人资料</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","avatar"));

	templateBuilder.Append("\">头像设置</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","password"));

	templateBuilder.Append("\">修改密码</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出登录</a>\r\n        </li>\r\n      </ul>\r\n    </div>");


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n    \r\n    <!--右侧内容-->\r\n    <div class=\"home-box\">\r\n      ");
	if (action=="convert")
	{

	templateBuilder.Append("\r\n      <!--积分兑换-->\r\n      <div class=\"u-tab-head\">\r\n        <p>\r\n          <a class=\"selected\" href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\">积分兑换</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\">积分明细</a>\r\n        </p>\r\n      </div>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>积分兑换</strong>\r\n        </div>\r\n        \r\n        ");
	if (uconfig.pointcashrate==0)
	{

	templateBuilder.Append("\r\n          <p style=\"text-align:center;\">目前的积分兑换功能已被关闭！</p>\r\n        ");
	}
	else if (userModel.amount<1)
	{

	templateBuilder.Append("\r\n          <p style=\"text-align:center;\">目前您的余额不足，不能使用积分兑换功能！</p>\r\n        ");
	}
	else
	{

	templateBuilder.Append("\r\n          <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n          <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n          <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n          <script type=\"text/javascript\">\r\n			$(function(){\r\n			  //初始化表单\r\n			  AjaxInitForm('#pointForm', '#btnSubmit', 1, '#turl');\r\n			});\r\n		  </");
	templateBuilder.Append("script>\r\n          <input id=\"hideAmount\" name=\"hideAmount\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append("\" />\r\n          <input id=\"hideCashrate\" name=\"hideCashrate\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.pointcashrate));
	templateBuilder.Append("\" />\r\n          <form id=\"pointForm\" name=\"pointform\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_convert\">\r\n          <div class=\"form-box\">\r\n            <dl>\r\n              <dt>账户余额：</dt>\r\n              <dd>目前账户积分:<b class=\"red\">");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append("</b>分，可用金额：<b class=\"red\">");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append("</b>元</dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>兑换说明：</dt>\r\n              <dd>积分兑换最少金额为1元，兑换比例为：1元等于");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.pointcashrate));
	templateBuilder.Append("个积分</dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>积分兑换：</dt>\r\n              <dd>\r\n                <input name=\"txtAmount\" id=\"txtAmount\" type=\"text\" class=\"input small\" onkeydown=\"return checkNumber(event);\" onchange=\"numConvert(this);\" datatype=\"n\"  nullmsg=\"请输入金额\" sucmsg=\" \" />\r\n              金额转换成 <strong class=\"red\" id=\"convertPoint\">0</strong> 积分\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt>验证用户密码：</dt>\r\n              <dd>\r\n                <input name=\"txtPassword\" id=\"txtPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\" nullmsg=\"请输入密码\" sucmsg=\" \" />\r\n              </dd>\r\n            </dl>\r\n            <dl>\r\n              <dt></dt>\r\n              <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn btn-success\" value=\"确认兑换\" /></dd>\r\n            </dl>\r\n          </div>\r\n          </form>\r\n          <input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\" />\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </div>\r\n      <!--/积分兑换-->\r\n      \r\n      ");
	}
	else if (action=="list")
	{

	templateBuilder.Append("\r\n      <!--积分明细-->\r\n      <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/pagination.css\" />\r\n      <script type=\"text/javascript\">\r\n	    function ExecPostBack(checkValue) {\r\n			if (arguments.length == 1) {\r\n				ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_delete', checkValue, '#turl');\r\n			}else{\r\n				var valueArr = '';\r\n				$(\"input[name='checkId']:checked\").each(function(i){\r\n					valueArr += $(this).val();\r\n					if(i < $(\"input[name='checkId']:checked\").length - 1){\r\n						valueArr += \",\"\r\n					}\r\n				});\r\n				ExecDelete('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_point_delete', valueArr, '#turl');\r\n			}\r\n		}\r\n	  </");
	templateBuilder.Append("script>\r\n      <div class=\"u-tab-head\">\r\n        <p>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userpoint","convert"));

	templateBuilder.Append("\">积分兑换</a>\r\n          <a class=\"selected\" href=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\">积分明细</a>\r\n        </p>\r\n      </div>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>积分明细</strong>\r\n        </div>\r\n        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"mtable\">\r\n          ");
	DataTable pointList = get_user_point_list(20, page, "user_id="+userModel.id, out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(20, page, totalcount, "userpoint", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in pointList.Rows)
	{

	templateBuilder.Append("\r\n            <tr>\r\n              <td width=\"20\" align=\"center\"><input name=\"checkId\" class=\"checkall\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" ></td>\r\n              <td width=\"150\">" + Utils.ObjectToStr(dr["add_time"]) + "</td>\r\n              <td>" + Utils.ObjectToStr(dr["remark"]) + "</td>\r\n              <td width=\"50\">\r\n                ");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["value"]), 0)>0)
	{

	templateBuilder.Append("\r\n                +" + Utils.ObjectToStr(dr["value"]) + "\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                " + Utils.ObjectToStr(dr["value"]) + "\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n              </td>\r\n              <td width=\"35\"><a onclick=\"ExecPostBack('" + Utils.ObjectToStr(dr["id"]) + "');\" href=\"javascript:;\">删除</a></td>\r\n            </tr>\r\n          ");
	}	//end for if

	if (pointList.Rows.Count==0)
	{

	templateBuilder.Append("\r\n            <tr><td colspan=\"5\" align=\"center\">暂无记录...</td></tr>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </table>\r\n        <div class=\"page-foot\">\r\n          <div class=\"flickr right\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div><!--放置页码列表-->\r\n          <div class=\"page-btns\">\r\n            <a onclick=\"checkAll(this);\" href=\"javascript:;\">全选</a>\r\n            <span class=\"pipe\">|</span>\r\n            <a onclick=\"ExecPostBack();\" href=\"javascript:;\">删除</a>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("userpoint","list"));

	templateBuilder.Append("\" /><!--存在跳转的URL值-->\r\n      <!--/积分明细-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n    </div>\r\n    <!--/右侧内容-->\r\n  </div>\r\n</div>\r\n\r\n<!--Footer-->\r\n");

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
