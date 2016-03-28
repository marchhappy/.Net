<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="CMS.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by CMS Template Engine at 2016/1/11 12:09:26.
		本页面代码由模板引擎生成于 2016/1/11 12:09:26. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<center><h1>页面等待更新</h1></center>");
	Response.Write(templateBuilder.ToString());
}
</script>
