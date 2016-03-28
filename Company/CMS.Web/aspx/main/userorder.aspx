<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.userorder" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>我的订单 - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/pagination.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
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
	if (action=="list")
	{

	templateBuilder.Append("\r\n      <!--交易订单-->\r\n      <div class=\"u-tab-head\">\r\n        <p>\r\n          <a class=\"selected\" href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\">交易订单</a>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userorder","close"));

	templateBuilder.Append("\">已关闭订单</a>\r\n        </p>\r\n      </div>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>交易订单</strong>\r\n        </div>\r\n        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ftable\">\r\n          <tr>\r\n            <th width=\"16%\" align=\"left\">订单号</th>\r\n            <th align=\"left\">订单商品</th>\r\n            <th width=\"10%\">姓名</th>\r\n            <th width=\"12%\">订单金额</th>\r\n            <th width=\"11%\">下单时间</th>\r\n            <th width=\"10%\">状态</th>\r\n            <th width=\"12%\">操作</th>\r\n          </tr>\r\n          ");
	DataTable list = get_order_list(10, page, "user_id="+userModel.id+" and status<=3", out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(10, page, totalcount, "userorder", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <tr>\r\n            <td>" + Utils.ObjectToStr(dr["order_no"]) + "</td>\r\n            <td>\r\n              ");
	List<CMS.Model.article> ls = get_order_goods_list(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0));

	if (ls!=null)
	{

	foreach(CMS.Model.article modelt in ls)
	{

	templateBuilder.Append("\r\n              <a target=\"_blank\" title=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("\" href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.id));

	templateBuilder.Append("\">\r\n                <img width=\"60\" height=\"60\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" class=\"img\">\r\n              </a>\r\n              ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n            </td>\r\n            <td align=\"center\">" + Utils.ObjectToStr(dr["accept_name"]) + "</td>\r\n            <td align=\"center\"><strong>￥" + Utils.ObjectToStr(dr["order_amount"]) + "</strong><br />");
	templateBuilder.Append(get_payment_title(Utils.StrToInt(Utils.ObjectToStr(dr["payment_id"]), 0)).ToString());

	templateBuilder.Append("</td>\r\n            <td align=\"center\">" + Utils.ObjectToStr(dr["add_time"]) + "</td>\r\n            <td align=\"center\">\r\n              ");
	templateBuilder.Append(get_order_status(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0)).ToString());

	templateBuilder.Append("\r\n            </td>\r\n            <td align=\"center\">\r\n              <a href=\"");
	templateBuilder.Append(linkurl("userorder_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">查看订单</a><br />\r\n              ");
	if (get_order_payment_status(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0)))
	{

	templateBuilder.Append("\r\n              <a href=\"");
	templateBuilder.Append(linkurl("payment","?action=confirm&order_no="+Utils.ObjectToStr(dr["order_no"])));

	templateBuilder.Append("\">去付款</a> |\r\n              ");
	}	//end for if

	if (Utils.StrToInt(Utils.ObjectToStr(dr["status"]), 0)<2)
	{

	templateBuilder.Append("\r\n              <a href=\"javascript:;\" onclick=\"clickSubmit('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=order_cancel&order_no=" + Utils.ObjectToStr(dr["order_no"]) + "');\">取消</a>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </td>\r\n          </tr>\r\n          ");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n          <tr>\r\n            <td colspan=\"8\" align=\"center\">暂无记录</td>\r\n          </tr>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </table>\r\n        <div class=\"page-foot\">\r\n          <div class=\"flickr right\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div><!--放置页码列表-->\r\n        </div>\r\n      </div>\r\n      <!--/交易订单-->\r\n      \r\n      ");
	}
	else if (action=="close")
	{

	templateBuilder.Append("\r\n      <!--已关闭订单-->\r\n      <div class=\"u-tab-head\">\r\n        <p>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\">交易订单</a>\r\n          <a class=\"selected\" href=\"");
	templateBuilder.Append(linkurl("userorder","close"));

	templateBuilder.Append("\">已关闭订单</a>\r\n        </p>\r\n      </div>\r\n      <div class=\"u-tab-content\">\r\n        <div class=\"title-div\">\r\n          <strong>交易订单</strong>\r\n        </div>\r\n        \r\n        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ftable\">\r\n          <tr>\r\n            <th width=\"16%\" align=\"left\">订单号</th>\r\n            <th align=\"left\">订单商品</th>\r\n            <th width=\"10%\">姓名</th>\r\n            <th width=\"12%\">订单金额</th>\r\n            <th width=\"11%\">下单时间</th>\r\n            <th width=\"10%\">状态</th>\r\n            <th width=\"12%\">操作</th>\r\n          </tr>\r\n          ");
	DataTable list = get_order_list(10, page, "user_id="+userModel.id+" and status>3", out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(10, page, totalcount, "userorder", action, "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n          <tr>\r\n            <td>" + Utils.ObjectToStr(dr["order_no"]) + "</td>\r\n            <td>\r\n              ");
	List<CMS.Model.article> ls = get_order_goods_list(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0));

	if (ls!=null)
	{

	foreach(CMS.Model.article modelt in ls)
	{

	templateBuilder.Append("\r\n              <a target=\"_blank\" title=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("\" href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.id));

	templateBuilder.Append("\"><img width=\"60\" height=\"60\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\"></a>\r\n              ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n            </td>\r\n            <td align=\"center\">" + Utils.ObjectToStr(dr["accept_name"]) + "</td>\r\n            <td align=\"center\"><strong>￥" + Utils.ObjectToStr(dr["order_amount"]) + "</strong><br />");
	templateBuilder.Append(get_payment_title(Utils.StrToInt(Utils.ObjectToStr(dr["payment_id"]), 0)).ToString());

	templateBuilder.Append("</td>\r\n            <td align=\"center\">" + Utils.ObjectToStr(dr["add_time"]) + "</td>\r\n            <td align=\"center\">");
	templateBuilder.Append(get_order_status(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0)).ToString());

	templateBuilder.Append("</td>\r\n            <td align=\"center\"><a href=\"");
	templateBuilder.Append(linkurl("userorder_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">查看订单</a></td>\r\n          </tr>\r\n          ");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n          <tr><td colspan=\"8\" align=\"center\">暂无记录</td></tr>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </table>\r\n    \r\n        <div class=\"page-foot\">\r\n          <div class=\"flickr right\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div><!--放置页码列表-->\r\n        </div>\r\n      </div>\r\n      <!--/已关闭订单-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n    </div>\r\n    <!--/右侧内容-->\r\n  </div>\r\n</div>\r\n\r\n<!--Footer-->\r\n");

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
