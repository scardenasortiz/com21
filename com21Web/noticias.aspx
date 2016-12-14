<%@ Page Language="C#" MasterPageFile="~/master/infoproductos.master" AutoEventWireup="true" CodeFile="noticias.aspx.cs" Inherits="noticias" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
        ChildrenAsTriggers="False">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<asp:HiddenField ID="hfidmarca" runat="server" Value="0" />
<div class="col-main span9">
<div class="padding-s">
<div class="page-title category-title">
<h1><asp:Label ID="lbltitulo" runat="server" ></asp:Label></h1>
</div>
 
<div class="category-products">
<div class="toolbar">
<div class="pager">
<p class="amount">
<strong><asp:Label ID="lblitems1" runat="server" Text="0" ForeColor="#383737"></asp:Label> Item(s)</strong>
</p>
<div class="limiter">
<label>Número</label>
<asp:DropDownList ID="ddlselect" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlselect_SelectedIndexChanged">
<asp:ListItem Text="9" Value="0"></asp:ListItem>
<asp:ListItem Text="15" Value="1"></asp:ListItem>
<asp:ListItem Text="30" Value="2"></asp:ListItem>
<asp:ListItem Text="50" Value="3"></asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="sorter">
<asp:ImageButton ID="ibgrid" runat="server" ImageUrl="~/images/gridV.gif" 
        onclick="ibgrid_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
        ID="iblist" runat="server" ImageUrl="~/images/listN.gif" 
        onclick="iblist_Click" />
</div>
</div>
<div id="servicios_web" runat="server">

</div>
<div>
</div>
<script type="text/javascript">    decorateGeneric($$('ul.products-grid'), ['odd', 'even', 'first', 'last'])</script>
<div class="toolbar-bottom">
<div class="toolbar">
<div class="pager">
<p class="amount">
<strong><asp:Label ID="lblitems" runat="server" Text="0" ForeColor="#383737"></asp:Label> Item(s)</strong>
</p>
<%--<div class="limiter">
<label>Número</label>
<asp:DropDownList ID="ddlselect1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlselect1_SelectedIndexChanged">
<asp:ListItem Text="9" Value="0"></asp:ListItem>
<asp:ListItem Text="15" Value="1"></asp:ListItem>
<asp:ListItem Text="30" Value="2"></asp:ListItem>
<asp:ListItem Text="50" Value="3"></asp:ListItem>
</asp:DropDownList>
</div>--%>
</div>
<div class="sorter">
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/gridV.gif" 
        onclick="ibgrid_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
        ID="ImageButton2" runat="server" ImageUrl="~/images/listN.gif" 
        onclick="iblist_Click" />
</div>
<%--<div class="sorter">
<p class="view-mode">
<label>View as:</label>
<strong title="Grid" class="grid"></strong>&nbsp;
<a href="http://livedemo00.template-help.com/magento_42968/servers.html?mode=list" title="List" class="list">List</a>&nbsp;
</p>
</div>--%>
</div>
</div>
</div>
</div>
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlselect" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ibgrid" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="iblist" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-content">
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/publi.jpg" Width="100%" />
</div>
</div>
<div class="block block-layered-nav">
<div class="block-title">
<strong><span>Facebook</span></strong>
</div>
<div class="block-content">
<iframe src="//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FCOM-21-SA%2F166410506765758&amp;width=250&amp;height=365&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;border_color&amp;header=false&amp;appId=330721080316666" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:100%; height:395px;" allowTransparency="true"></iframe>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
