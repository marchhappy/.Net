<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="config_edit.aspx.cs" Inherits="CMS.Web.admin.buyersite.config_edit" %>
<%@ Import namespace="CMS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑站点</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });

    var alerted = false;
    function AlertSuccess() {
        // 修改信息成功
        if (alerted == true) return;
        alerted = true;

        parent.jsprint("修改站点信息成功！", "configlist.aspx");
    }

    function CallSyncPost(config_id) {
        //通知站点配置文件修改了
        alerted = false;

        AlertSuccess();
        return;

        var sTimer = setTimeout(function () {
            AlertSuccess();
        }, 1500);

        var domainstr = $('#txtSiteDomain').val();
        var syncUrl = 'http://localhost:35708/tools/buyersite_sync.ashx';

        $.ajax({
            type: "get",            
            url: syncUrl,
            dataType: "jsonp",
            jsonp: "callback",//传递给请求处理程序或页面的，用以获得jsonp回调函数名的参数名(一般默认为:callback)             
            success: function (json) {
                var code = json['status'];
                var msg = json['msg'];
                clearTimeout(sTimer);
                AlertSuccess();
            },
            error: function () {
                alert('发送数据同步信号失败');
            }
        });                
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="configlist.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>  
  <i class="arrow"></i>
  <span>编辑站点</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">用户站点信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>站点名称</dt>
    <dd><asp:TextBox ID="txtSiteName" runat="server" CssClass="input normal" datatype="*"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>访问域名</dt>
    <dd><asp:TextBox ID="txtSiteDomain" runat="server" CssClass="input normal" datatype="*"></asp:TextBox><span class="Validform_checktip">如：http://www.abc.com/ </span></dd>
  </dl>
  <dl>
    <dt>用户名</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="*"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>是否启用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
      </div>
      <span class="Validform_checktip">*不启用则站点无法使用</span>
    </dd>
  </dl>
  <dl>
    <dt>配置数据</dt>
    <dd><asp:TextBox ID="txtSiteConfig" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox></dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>