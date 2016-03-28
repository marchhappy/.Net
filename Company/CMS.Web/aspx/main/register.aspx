<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.register" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html lang=\"cn\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title>");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_title));
	templateBuilder.Append("</title>\r\n    <meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n    <meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />    \r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <!-- CSS Files -->\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/bootstrap/css/bootstrap.min.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/font-awesome/css/font-awesome.min.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/pretty-photo/css/prettyPhoto.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/styleui.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/animate.min.css\" />\r\n    <!-- / CSS Files -->\r\n    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->\r\n    <!--[if lt IE 9]>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/html5shiv.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/respond.min.js\"></");
	templateBuilder.Append("script>\r\n    <![endif]-->\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/bootstrap/js/bootstrap.min.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/script/animate.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/plugin/jquery.cuteTime.min.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/script/script.js\"></");
	templateBuilder.Append("script>\r\n	\r\n	<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n	<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<header class=\"main bg-dark-img home-1\">\r\n    <div class=\"container\">\r\n        <nav class=\"navbar\" role=\"navigation\">\r\n            <div class=\"navbar-header\">\r\n                <a class=\"navbar-brand\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\"><img id=\"logo\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/logo.png\" alt=\"eLearn\" /></a>\r\n            </div>\r\n            <div class=\"collapse navbar-collapse\">\r\n                <div class=\"navbar-right menu-main\">\r\n                    <ul class=\"nav navbar-nav\">\r\n                        <li id=\"snav1\" class=\"dropdown\">\r\n                            <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\"><span>首页</span></a>\r\n                        </li>\r\n                        <li id=\"snav2\"><a href=\"");
	templateBuilder.Append(linkurl("signproduct"));

	templateBuilder.Append("\"><span>产品服务</span></a></li>\r\n                        <li id=\"snav3\" class=\"dropdown\">\r\n                            <a href=\"");
	templateBuilder.Append(linkurl("homeplan"));

	templateBuilder.Append("\"><span>套餐购买</span></a>\r\n                            <!--- <ul class=\"dropdown-menu\">\r\n                                 <li><a href=\"blog-list.htm\">Blog list</a></li>\r\n                                 <li><a href=\"blog-post.htm\">Blog post detail</a></li>\r\n                             </ul> -->\r\n                        </li>\r\n                        <li id=\"snav4\" class=\"dropdown\">\r\n                            <a href=\"");
	templateBuilder.Append(linkurl("news_list",54));

	templateBuilder.Append("\"><span>新闻公告</span></a>\r\n                            <!--- <ul class=\"dropdown-menu\">\r\n                                <li><a href=\"categories.htm\">Categories of video</a></li>\r\n                                <li><a href=\"videos-list.htm\">Video list</a></li>\r\n                                <li><a href=\"videos-grid.htm\">Video list (grid)</a></li>\r\n                                <li><a href=\"video.htm\">Video film detail</a></li>\r\n                            </ul>-->\r\n                        </li>\r\n                        <li id=\"snav5\"><a href=\"");
	templateBuilder.Append(linkurl("helpamount"));

	templateBuilder.Append("\"><span>帮助信息</span></a></li>\r\n                        <li id=\"snav6\"><a href=\"");
	templateBuilder.Append(linkurl("signabout"));

	templateBuilder.Append("\"><span>关于我们</span></a></li>\r\n                        <li id=\"snav7\"><a href=\"");
	templateBuilder.Append(linkurl("signcontact"));

	templateBuilder.Append("\"><span>联系我们</span></a></li>\r\n                    </ul>\r\n                    <a class=\"btn btn-theme navbar-btn btn-default sign-in\" id=\"userCenterDoorBtn1\" href=\"javascript:;\">登陆</a>\r\n                    <a class=\"btn btn-theme navbar-btn btn-orange  sign-up\" id=\"userCenterDoorBtn2\" href=\"javascript:;\">注册</a>\r\n\r\n                    <script type=\"text/javascript\">\r\n					function SysNavnalSet(key){\r\n						// 设置当前导航高亮\r\n						setTimeout(function(){$('#snav'+key).addClass('active');},5);						\r\n					}\r\n                    $.ajax({\r\n                        type: \"POST\",\r\n                        url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n                        dataType: \"json\",\r\n                        timeout: 20000,\r\n                        success: function (data, textStatus) {\r\n                            if (data.status == 1) {\r\n								var strOut='");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("'; //退出\r\n								var strCnt='");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("'; //会员中心\r\n                                $('#userCenterDoorBtn1').attr('href',strOut).html('退出');\r\n								$('#userCenterDoorBtn2').attr('href',strCnt).html('会员中心');\r\n                            } else {\r\n                                var strReg='");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("'; //注册\r\n								var strSig='");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("'; //登陆\r\n                                $('#userCenterDoorBtn1').attr('href',strReg).html('注册');\r\n								$('#userCenterDoorBtn2').attr('href',strSig).html('登陆');\r\n                            }\r\n                        }\r\n                    });\r\n                    </");
	templateBuilder.Append("script>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n\r\n    </div>\r\n</header>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n	<div class=\"page-header\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-7\">\r\n                    <h1>注册帐户</h1>\r\n                </div>\r\n                <div class=\"col-md-5\">\r\n                    <ol class=\"breadcrumb pull-right\">\r\n                        <li><a href=\"index.htm\">主页</a></li>\r\n                        <li class=\"active\">账户注册</li>\r\n                    </ol>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    \r\n    <section class=\"content content-light\">\r\n        <div class=\"container\">            \r\n		\r\n		");
	if (action=="")
	{

	templateBuilder.Append("\r\n		<!--用户注册-->\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n		<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n		<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n		<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/register-validate.js\"></");
	templateBuilder.Append("script>\r\n			\r\n            <form id=\"regform\" name=\"regform\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_register&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("\">\r\n                <h2 class=\"title-form\">个人信息</h2>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-4\">\r\n                        \r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputUsername\">用户名</label>                            \r\n							<input id=\"txtUserName\" name=\"txtUserName\" type=\"text\" class=\"form-control input-lg\" placeholder=\"输入登录用户名\" datatype=\"s3-50\" nullmsg=\"请输入登录的用户名\" sucmsg=\" \" ajaxurl=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=validate_username\" />\r\n							<span class=\"Validform_checktip\">请输入登录的用户名</span>\r\n							\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputPassword1\">密码</label>                            \r\n							<input id=\"txtPassword\" name=\"txtPassword\" type=\"password\" class=\"form-control input-lg\" placeholder=\"输入登录密码\" datatype=\"*6-20\" nullmsg=\"请输入登录密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" />\r\n							<span class=\"Validform_checktip\">请输入6-20位的登录密码</span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-4\">\r\n                        \r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputEmail1\">手机号码</label>                            \r\n							<input id=\"txtMobile\" name=\"txtMobile\" type=\"text\" class=\"form-control input-lg\" placeholder=\"输入手机号码\" datatype=\"m\" nullmsg=\"请输入手机号码\" sucmsg=\" \" />\r\n							<span class=\"Validform_checktip\">请输入手机号码</span>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputPassword2\">确认密码</label>                            \r\n							<input id=\"txtPassword1\" name=\"txtPassword1\" type=\"password\" class=\"form-control input-lg\" placeholder=\"请再次输入密码\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"请再输入一次密码\" errormsg=\"两次输入的密码不一致\" sucmsg=\" \" />\r\n							<span class=\"Validform_checktip\">请再次输入登录密码</span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-4\">\r\n                        \r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputEmail2\">邮箱</label>                            \r\n							<input id=\"txtEmail\" name=\"txtEmail\" type=\"text\" class=\"form-control input-lg\" placeholder=\"输入邮箱账号\" datatype=\"e\" nullmsg=\"请输入电子邮箱账号\" sucmsg=\" \" />\r\n							<span class=\"Validform_checktip\">请输入电子邮箱账号</span>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label for=\"fieldInputPostalcode\">验证码</label>                            \r\n							<input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"form-control input code\" placeholder=\"输入验证码\" datatype=\"s4-20\" nullmsg=\"请输入右边显示的验证码\" sucmsg=\" \" />\r\n							<a class=\"send\" title=\"点击切换验证码\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\">\r\n							  <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" />\r\n							</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                \r\n                \r\n				\r\n				");
	if (uconfig.regstatus==1||uconfig.regstatus==2)
	{

	templateBuilder.Append("\r\n				<!--开放注册及手机注册-->        \r\n				");
	}	//end for if

	if (uconfig.regstatus==2)
	{

	templateBuilder.Append("\r\n				<!--开启手机注册-->\r\n				<hr class=\"invisible\" />\r\n				<p>\r\n					<input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"input code\" placeholder=\"输入手机收到的确认码\"  datatype=\"s4-20\" nullmsg=\"请输入手机收到的确认码\" sucmsg=\" \" />\r\n					<a class=\"send\" href=\"javascript:;\" onclick=\"sendSMS(this,'#txtMobile','");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_verify_smscode&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("');\">发送确认码</a>\r\n					<span class=\"Validform_checktip\">请手机短信收到的验证码</span>         \r\n				</p>\r\n				<!--开启手机注册-->\r\n				");
	}	//end for if

	if (uconfig.regstatus==1||uconfig.regstatus==3||uconfig.regstatus==4)
	{

	templateBuilder.Append("\r\n				<!--开放注册及邮箱邀请注册-->        \r\n				");
	}	//end for if

	if (uconfig.regstatus==4)
	{

	templateBuilder.Append("\r\n				<!--开启邀请注册-->\r\n				<hr class=\"invisible\" />\r\n				<p>\r\n					<input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"input txt\" placeholder=\"输入好友提供的邀请码\" datatype=\"s2-20\" nullmsg=\"请输入注册邀请码\" sucmsg=\" \" />\r\n					<span class=\"Validform_checktip\">输入好友提供的邀请码</span>          \r\n				</p>\r\n				<!--/开启邀请注册-->\r\n				");
	}	//end for if

	if (uconfig.regstatus==1)
	{

	templateBuilder.Append("\r\n				<!--开放注册验证码-->				\r\n				");
	}	//end for if

	if (uconfig.regrules==1)
	{

	templateBuilder.Append("\r\n				<!--开启注册协议-->\r\n				<hr class=\"invisible\" />\r\n				<p>\r\n					  <input id=\"chkAgree\" name=\"chkAgree\" type=\"checkbox\" value=\"1\">\r\n					  <label for=\"chkAgree\">我已仔细阅读并接受 <a href=\"javascript:;\" onclick=\"showWindow('#regrules');\">注册许可协议</a></label>\r\n					  <div id=\"regrules\" title=\"注册许可协议\" style=\"display:none;\">");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.regrulestxt));
	templateBuilder.Append("</div>           \r\n				</p>\r\n				<!--开启注册协议-->\r\n				");
	}	//end for if

	templateBuilder.Append("\r\n				\r\n				\r\n                <hr class=\"invisible\" />\r\n                \r\n                <p>\r\n					<input type=\"submit\" class=\"btn btn-theme btn-orange\" id=\"btnSubmit\" value=\"确认注册\" disabled=\"disabled\" /> \r\n					<a class=\"btn btn-theme btn-green\" href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">已有账号,登录</a>\r\n				</p>\r\n            </form>\r\n			\r\n			\r\n\r\n        \r\n		\r\n		\r\n       \r\n	   \r\n    <!--用户注册-->\r\n  ");
	}	//end for if

	if (action=="close")
	{

	templateBuilder.Append("\r\n    <!--关闭会员注册-->\r\n    <div class=\"main-tit\">\r\n      <h2>温馨提示</h2>\r\n    </div>\r\n    <div class=\"inner-box\">\r\n      <div class=\"msg-tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>非常抱歉，系统暂停注册会员服务！</strong>\r\n          <p>由于某些原因，系统暂停注册会员，如对您造成不便之处，我们深感遗憾！</p>\r\n          <p>如需了解开放时间，请联系本站客服或管理员。</p>\r\n          <p>您可以点击这里<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">返回网站首页</a></p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <!--关闭会员注册-->\r\n  ");
	}	//end for if

	if (action=="sendmail")
	{

	templateBuilder.Append("\r\n    <!--发送邮箱验证-->\r\n    <div class=\"main-tit\">\r\n      <h2>温馨提示</h2>\r\n    </div>\r\n    <div class=\"inner-box\">\r\n      <div class=\"msg-tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>注册成功，您的账户目前处于未验证状态！</strong>\r\n          <p>欢迎您成为本站会员，您的账户目前处于未验证状态，请尽快登录您的注册邮箱激活该会员账户。</p>\r\n          <p>系统已经自动为您发送了一封验证邮件，如果您长时间未收到邮件，请点击这里<a href=\"javascript:;\" onclick=\"sendEmail('");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("', '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_verify_email&site=");
	templateBuilder.Append(Utils.ObjectToStr(site.build_path));
	templateBuilder.Append("');\">重新发送邮件</a>！</p>\r\n          <i>温馨提示：邮件验证有效期为\r\n          ");
	if (uconfig.regemailexpired>0)
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.regemailexpired));
	templateBuilder.Append("天\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          无限制\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          </i>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <!--发送邮箱验证-->\r\n  ");
	}	//end for if

	if (action=="checkmail")
	{

	templateBuilder.Append("\r\n    <!--邮箱验证成功-->\r\n    <div class=\"main-tit\">\r\n      <h2>温馨提示</h2>\r\n    </div>\r\n    <div class=\"inner-box\">\r\n      <div class=\"msg-tips\">\r\n        <div class=\"ico\"></div>\r\n        <div class=\"msg\">\r\n          <strong>恭喜您");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("，已通过邮件激活会员账户</strong>\r\n          <p>您的会员账户已经激活啦，从现在起，你可以享受更多的会员服务，还等什么呢？</p>\r\n          <p>赶快点击这里返回<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a>，点击这里<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">进入会员中心</a>吧！</p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <!--邮箱验证成功-->\r\n  ");
	}	//end for if

	if (action=="checkerror")
	{

	templateBuilder.Append("\r\n    <!--注册验证失败-->\r\n    <div class=\"main-tit\">\r\n      <h2>温馨提示</h2>\r\n    </div>\r\n    <div class=\"inner-box\">\r\n      <div class=\"msg-tips\">\r\n        <div class=\"ico error\"></div>\r\n        <div class=\"msg\">\r\n          <strong>出错啦，该用户不存在或验证已过期！</strong>\r\n          <p>无法验证你的账户，不知神马原因，可能是你的用户名不存在或者验证码已经过期啦！</p>\r\n          <p>不过别担心，如果您还记得你的会员名称的话，点击这里<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">进入会员中心</a>吧。</p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <!--注册验证失败-->\r\n  ");
	}	//end for if

	if (action=="verify")
	{

	templateBuilder.Append("\r\n    <!--人工审核-->\r\n    <div class=\"main-tit\">\r\n      <h2>温馨提示</h2>\r\n    </div>\r\n    <div class=\"inner-box\">\r\n      <div class=\"msg-tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>账户处于未审核状态，请等待人工审核通过！</strong>\r\n          <p>很抱歉亲爱的，您的会员账户还没有审核通过呢，再等等吧，实在等不及的话请联系本站客服人员！</p>\r\n          <p>由于种种原因，本站不得以暂时开启人工审核，如对您造成不便敬请原谅哦。</p>\r\n          <p>您可以点击这里<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">返回网站首页</a></p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <!--人工审核-->\r\n  ");
	}	//end for if

	templateBuilder.Append("\r\n			\r\n			\r\n	</div>        \r\n</section>\r\n\r\n\r\n	\r\n\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<hr class=\"invisible\" />\r\n\r\n<footer class=\"main bg-dark-img\">\r\n    <section class=\"widgets\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3\">\r\n                    <h4>关于我们</h4>\r\n                    <p>江苏佳婵网络科技有限公司，注册资金人民币1000万元，是国内较早的数字产品在线销售平台提供商，目前在国内数字产品在线销售平台市场占有率最高。</p>\r\n                </div>\r\n                <div class=\"col-md-3 footer-qlink\">\r\n                    <h4>快速链接</h4>\r\n                    <nav>\r\n                        <ul>\r\n                            <li><a href=\"about-us.htm\">产品服务</a></li>\r\n                            <li><a href=\"plans.htm\">套餐购买</a></li>\r\n                            <li><a href=\"videos-list.htm\">新闻公告</a></li>\r\n                            <li><a href=\"features.htm\">帮助信息</a></li>\r\n                        </ul>\r\n                    </nav>\r\n                </div>\r\n                <div class=\"col-md-3 footer-blog\">\r\n                    <h4>联系我们</h4>\r\n                    <ul class=\"media-list\">\r\n                        <li class=\"media\">\r\n                            <img class=\"pull-left media-object img-rounded\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/rexian.png\" alt=\"author\" />\r\n                            <div class=\"media-body\">\r\n                                <h5 class=\"media-heading\" style=\"margin-top: 4px;\">服务热线</h5>\r\n                                <p>0512-52196996</p>\r\n                            </div>\r\n                        </li>\r\n                        <li class=\"media\">\r\n                            <img class=\"pull-left media-object img-rounded\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/weixin.png\" alt=\"author\" />\r\n                            <div class=\"media-body\">\r\n                                <h5 class=\"media-heading\" style=\"margin-top: 4px;\">微信</h5>\r\n                                <p>kalegou</p>\r\n                            </div>\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n                <div class=\"col-md-3 footer-social\">\r\n                    <h4>关注卡乐购微信</h4>\r\n                    <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/wei_b.png\" class=\"index_wei\" />\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <section class=\"copyright\">\r\n        <div class=\"container\"> 苏ICP备08015923号-12 营业执照 320581000092299 增值电信业务经营许可证：苏B2-20130082 软件著作权证：0142069号 </div>\r\n    </section>\r\n</footer>");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
