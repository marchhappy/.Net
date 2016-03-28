<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.article" ValidateRequest="false" %>
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
	const string channel = "news";

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


	templateBuilder.Append("\r\n<!--/Header-->\r\n<script>SysNavnalSet(4);</");
	templateBuilder.Append("script>\r\n\r\n\r\n<ul class=\"rank-list\">\r\n        ");
	DataTable hotList = get_article_list(channel, 54, 10, "status=0", "click desc,id desc");

	int dr2__loop__id=0;
	foreach(DataRow dr2 in hotList.Rows)
	{
		dr2__loop__id++;


	if (dr2__loop__id==1)
	{

	templateBuilder.Append("\r\n            <li class=\"active\">\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n            <li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          <span>");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(dr2["add_time"])).ToString("MM-dd"));

	templateBuilder.Append("</span>\r\n          <i class=\"num\">");
	templateBuilder.Append(Utils.ObjectToStr(dr2__loop__id));
	templateBuilder.Append("</i>\r\n          <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(dr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr2["title"]) + "</a>\r\n        </li>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </ul>\r\n\r\n\r\n<!--Footer-->\r\n");

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
