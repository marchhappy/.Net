<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.index" ValidateRequest="false" %>
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
	templateBuilder.Append("\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <!-- CSS Files -->\r\n    <link rel=\"stylesheet\" href=\"");
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
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n\r\n    ");

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


	templateBuilder.Append("\r\n    <script>SysNavnalSet(1);</");
	templateBuilder.Append("script>\r\n\r\n    <div id=\"main-slide\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        ");
	DataTable adBar1 = GetAdvertBaner(1);

	templateBuilder.Append("\r\n        <ol class=\"carousel-indicators\">\r\n            ");
	int ad0__loop__id=0;
	foreach(DataRow ad0 in adBar1.Rows)
	{
		ad0__loop__id++;


	templateBuilder.Append("\r\n            <li data-target=\"#main-slide\" data-slide-to=\"");
	templateBuilder.Append(Utils.ObjectToStr(ad0__loop__id-1));
	templateBuilder.Append("\" class=\"");
	templateBuilder.Append(TrueFalseEval(ad0__loop__id==1," active","").ToString());

	templateBuilder.Append("\"></li>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n        </ol>\r\n        <div class=\"carousel-inner\">\r\n            ");
	int ad1__loop__id=0;
	foreach(DataRow ad1 in adBar1.Rows)
	{
		ad1__loop__id++;


	templateBuilder.Append("\r\n\r\n            <div class=\"item ");
	templateBuilder.Append(TrueFalseEval(ad1__loop__id==1," active","").ToString());

	templateBuilder.Append("\r\n                \">\r\n                <img class=\"img-responsive\" src=\"" + Utils.ObjectToStr(ad1["file_path"]) + "\" alt=\"slider\">\r\n                <div class=\"slider-content\">\r\n                    <div class=\"col-md-12 text-center\">\r\n                        <h2>" + Utils.ObjectToStr(ad1["title"]) + "</h2>\r\n                        <div></div>\r\n                        ");
	if (!string.IsNullOrEmpty(Utils.ObjectToStr(ad1["link_url"])))
	{

	templateBuilder.Append("\r\n                        <p><a href=\"" + Utils.ObjectToStr(ad1["link_url"]) + "\" class=\"slider btn\">阅读更多</a> </p>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n        <a class=\"left carousel-control\" href=\"#main-slide\" data-slide=\"prev\"> <span><i class=\"fa fa-angle-left\"></i></span> </a>\r\n        <a class=\"right carousel-control\" href=\"#main-slide\" data-slide=\"next\"> <span><i class=\"fa fa-angle-right\"></i></span> </a>\r\n    </div>\r\n\r\n    <section class=\"poweredby\">\r\n        <figure class=\"container\">\r\n            <div class=\"row text-center client-logos\">\r\n                <div class=\"col-md-3\">\r\n                    <a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/01.gif\" alt=\"\" />\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/01.gif\" class=\"color\" alt=\"\" />\r\n                    </a>\r\n                    <h4>网页版平台系统</h4>\r\n                </div>\r\n                <div class=\"col-md-3\">\r\n                    <a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/04.gif\" alt=\"\" />\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/04.gif\" class=\"color\" alt=\"\" />\r\n                    </a>\r\n                    <h4>一卡通兑换系统</h4>\r\n                </div>\r\n                <div class=\"col-md-3\">\r\n                    <a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/05.gif\" alt=\"\" />\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/05.gif\" class=\"color\" alt=\"\" />\r\n                    </a>\r\n                    <h4>手机版卡盟</h4>\r\n                </div>\r\n                <div class=\"col-md-3\">\r\n                    <a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/06.gif\" alt=\"\" />\r\n                        <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/06.gif\" class=\"color\" alt=\"\" />\r\n                    </a>\r\n                    <h4>全新产品，敬请期待！</h4>\r\n                </div>\r\n            </div>\r\n        </figure>\r\n    </section>\r\n\r\n    <div class=\"container content content-light home-1\">\r\n        <section class=\"row animation-scroll\">\r\n            <figure class=\"col-md-6 animated\" data-animation=\"bounceInLeft\"><img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/home1_img1.png\" alt=\"\" /></figure>\r\n            <article class=\"col-md-6 animated\" data-animation=\"bounceInRight\">\r\n                <h3><a href=\"#\"><strong>我要进货</strong></a><small class=\"text-green margin-left-8\">货源多</small></h3>\r\n                <p>卡密、充值商品全市最低价，货源丰富，淘宝、拍拍对接管理，API开放接口灵活配置。</p>\r\n                <a href=\"categories.htm\" class=\"link-more\">了解进货详情<i class=\"fa fa-arrow-right \"></i></a>\r\n            </article>\r\n        </section>\r\n        <section class=\"row animation-scroll\">\r\n            <article class=\"col-md-6 animated\" data-animation=\"bounceInLeft\">\r\n                <h3><a href=\"#\"><strong>我要供货</strong></a><small class=\"text-green margin-left-8\">销路广</small></h3>\r\n                <p>卡乐购上千家平台，每月数亿的交易量，坐享为数百万用户供货的便捷，迅速拓展您的商品销路。</p>\r\n                <a href=\"#\" class=\"link-more\">了解供货详情<i class=\"fa fa-arrow-right \"></i></a>\r\n            </article>\r\n            <figure class=\"col-md-6 animated\" data-animation=\"bounceInRight\"><img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/home1_img2.png\" alt=\"\" /></figure>\r\n        </section>\r\n        <section class=\"row animation-scroll\">\r\n            <figure class=\"col-md-6 animated\" data-animation=\"bounceInLeft\"><img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/home1_img3.png\" alt=\"\" /></figure>\r\n            <article class=\"col-md-6 animated\" data-animation=\"bounceInRight\">\r\n                <h3><strong>个性化服务</strong></h3>\r\n                <p>拒绝千篇一律，展现自我品牌形象。我们为有个性化需求的用户定制独一无二的界面及功能。个性化定制包括：网站前台风格，平台内页风格和软件风格，功能定制包括充值模版等一些自动化的功能。</p>\r\n                <a href=\"#\" class=\"link-more\">了解详情<i class=\"fa fa-arrow-right \"></i></a>\r\n            </article>\r\n        </section>\r\n    </div>\r\n\r\n    <section class=\"content content-dark bg-dark-img\">\r\n        <div class=\"container\">\r\n            <p class=\"header text-center text-white\">想要加入我们吗？</p>\r\n            <p class=\"header header-tiny text-center text-white\">我们为有个性化需求的用户定制独一无二的界面及功能。</p>\r\n            <p class=\"buttons text-center\"><a href=\"about-us.htm\" class=\"btn btn-theme btn-orange\">产品服务</a> <a href=\"plans.htm\" class=\"btn btn-theme btn-green\">套餐购买</a></p>\r\n        </div>\r\n    </section>\r\n\r\n\r\n    <section class=\"content content-light\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n                    <h3>\r\n                        <strong>新闻公告</strong>\r\n                        <a href=\"#\" class=\"color-text-1\" style=\"float: right; margin-right: 2%; font-size: 80%;\"><i class=\"fa fa-arrow-right\"></i></a>\r\n                    </h3>\r\n                    <ul class=\"fa-ul list-special\">\r\n                        ");
	DataTable nlist = get_article_list("news", 5, "status=0 and Category_id=54");

	foreach(DataRow dr in nlist.Rows)
	{

	templateBuilder.Append("\r\n                        <li><i class=\"fa-li fa fa-2x fa-dribbble text-green\"></i><a href=\"");
	templateBuilder.Append("<%linkurl(\" news_show\"," + Utils.ObjectToStr(dr["id"]) + ")%>");
	templateBuilder.Append("\" class=\"color-text\">" + Utils.ObjectToStr(dr["title"]) + "</a></li>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                    </ul>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n                    <h3>\r\n                        <strong>热门帮助</strong>\r\n                        <a href=\"#\" class=\"color-text-1\" style=\"float: right; margin-right: 2%; font-size: 80%;\"><i class=\"fa fa-arrow-right\"></i></a>\r\n                    </h3>\r\n                    <ul class=\"fa-ul list-special\">\r\n                        ");
	DataTable hlist = get_article_list("news", 5, "status=0 and Category_id=57");

	foreach(DataRow dr in hlist.Rows)
	{

	templateBuilder.Append("\r\n                        <li><i class=\"fa-li fa fa-2x fa-check text-green\"></i><a href=\"");
	templateBuilder.Append("<%linkurl(\" helpamount\"," + Utils.ObjectToStr(dr["id"]) + ")%>");
	templateBuilder.Append("\" class=\"color-text\">" + Utils.ObjectToStr(dr["title"]) + "</a></li>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n    ");

	templateBuilder.Append("<hr class=\"invisible\" />\r\n\r\n<footer class=\"main bg-dark-img\">\r\n    <section class=\"widgets\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3\">\r\n                    <h4>关于我们</h4>\r\n                    <p>江苏佳婵网络科技有限公司，注册资金人民币1000万元，是国内较早的数字产品在线销售平台提供商，目前在国内数字产品在线销售平台市场占有率最高。</p>\r\n                </div>\r\n                <div class=\"col-md-3 footer-qlink\">\r\n                    <h4>快速链接</h4>\r\n                    <nav>\r\n                        <ul>\r\n                            <li><a href=\"about-us.htm\">产品服务</a></li>\r\n                            <li><a href=\"plans.htm\">套餐购买</a></li>\r\n                            <li><a href=\"videos-list.htm\">新闻公告</a></li>\r\n                            <li><a href=\"features.htm\">帮助信息</a></li>\r\n                        </ul>\r\n                    </nav>\r\n                </div>\r\n                <div class=\"col-md-3 footer-blog\">\r\n                    <h4>联系我们</h4>\r\n                    <ul class=\"media-list\">\r\n                        <li class=\"media\">\r\n                            <img class=\"pull-left media-object img-rounded\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/rexian.png\" alt=\"author\" />\r\n                            <div class=\"media-body\">\r\n                                <h5 class=\"media-heading\" style=\"margin-top: 4px;\">服务热线</h5>\r\n                                <p>0512-52196996</p>\r\n                            </div>\r\n                        </li>\r\n                        <li class=\"media\">\r\n                            <img class=\"pull-left media-object img-rounded\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/weixin.png\" alt=\"author\" />\r\n                            <div class=\"media-body\">\r\n                                <h5 class=\"media-heading\" style=\"margin-top: 4px;\">微信</h5>\r\n                                <p>kalegou</p>\r\n                            </div>\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n                <div class=\"col-md-3 footer-social\">\r\n                    <h4>关注卡乐购微信</h4>\r\n                    <img src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/img/wei_b.png\" class=\"index_wei\" />\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <section class=\"copyright\">\r\n        <div class=\"container\"> 苏ICP备08015923号-12 营业执照 320581000092299 增值电信业务经营许可证：苏B2-20130082 软件著作权证：0142069号 </div>\r\n    </section>\r\n</footer>");


	templateBuilder.Append("\r\n\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
