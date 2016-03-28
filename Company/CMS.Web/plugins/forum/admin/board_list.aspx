<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="board_list.aspx.cs" Inherits="CMS.Web.Plugin.Forum.admin.board_list" %>
<%@ Import namespace="CMS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>论坛版块管理</title>
<link href="../images/forum.css" rel="stylesheet" type="text/css" />
<link href="../../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<style type="text/css">
    .forum-board-ico { background:}
</style>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>论坛管理</span>
  <i class="arrow"></i>
  <span>版块管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="board_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="lbtnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('lbtnDelete');" onclick="lbtnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="lbtnSearch_Click">查询</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="table-container">
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" colspan="2">版块</th>
    <th align="left" width="12%">访问权限</th>
    <th align="center" width="80">排序</th>
    <th width="8%">状态</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td width="64">
      <a href="board_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">
        <%#Eval("img_url").ToString() != "" ? "<img width=\"64\" height=\"64\" src=\"" + Eval("img_url") + "\" />" : "<b class=\"forum-board-ico\"></b>"%>
      </a>
    </td>
    <td>
      <div class="user-box">
        <h4><b><%#Eval("boardname")%></b></h4>
        <i>版主列表：<%#Eval("moderator_list")%></i>
      </div>
    </td>
    <td align="left"><%# GetAllowUserGroupName(Eval("allow_usergroupid_list").ToString())%></td>
    <td align="center"><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' Width="20" CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center"><%# Convert.ToInt32(Eval("is_lock")) == 1 ? "隐藏" : "正常"%></td>
    <td align="center"><a href="board_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
</div>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
