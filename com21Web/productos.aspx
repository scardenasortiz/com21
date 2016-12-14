<%@ Page Language="C#" MasterPageFile="~/master/infoproductos.master" AutoEventWireup="true" CodeFile="productos.aspx.cs" Inherits="productos" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%--  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
<div class="limiter">
<label>Precio</label>
<asp:DropDownList ID="ddlprecio" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlselect_SelectedIndexChanged">
<asp:ListItem Text="Todos" Value="0"></asp:ListItem>
<asp:ListItem Text="$0.00 - $500.00" Value="1"></asp:ListItem>
<asp:ListItem Text="$500.01 - $800.00" Value="2"></asp:ListItem>
<asp:ListItem Text="$800.01 - $1000.00" Value="3"></asp:ListItem>
<asp:ListItem Text="$1000.01 - y por encima" Value="4"></asp:ListItem>
</asp:DropDownList>&nbsp;&nbsp;
</div>
</div>
<div class="sorter">
<asp:ImageButton ID="ibgrid" runat="server" ImageUrl="~/images/gridV.gif" 
        onclick="ibgrid_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
        ID="iblist" runat="server" ImageUrl="~/images/listN.gif" 
        onclick="iblist_Click" />
</div>
</div>
<div id="productos_web" runat="server">

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
<asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 200px; background-color: #E2E2E2; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/loadinfo.net1.gif" />
                       </td> 
                    </tr>
                    <tr>
                    <td style="white-space: nowrap; text-align: center; font-family: verdana; font-size: 10px;">
                            <span class="Datos" 
                                style="font-size: 10px; font-family: Talo; font-weight:bold; color: #000000;"> POR FAVOR ESPERE, PROCESANDO...</span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:Panel>
    <ajaxtoolkit:modalpopupextender ID="mpeProgress" runat="server" BackgroundCssClass="modalBackground"
        DropShadow="true" PopupControlID="pnlProgress" 
        TargetControlID="pnlProgress">
    </ajaxtoolkit:modalpopupextender>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlprecio" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlselect" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="dtmarca" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ibgrid" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="iblist" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-title">
<strong><span>Seleccione POR</span></strong>
</div>
<div class="block-content">
<p class="block-subtitle">Opciones de selección</p>
<dl id="narrow-by-list">
<dt>Marcas</dt>
<dd>
<ol>
<asp:DataList ID="dtmarca" runat="server" 
        onselectedindexchanged="dtmarca_SelectedIndexChanged">
<ItemTemplate>
<li>
<asp:HiddenField ID="hfmarca" runat="server" Value='<%# Eval("Id_Marca") %>' />
<asp:LinkButton ID="lbmarca" runat="server" ForeColor="#8A8989" CommandName="Select"><%# Eval("Marca") %></asp:LinkButton>&nbsp;(<asp:Label ID="lblcantidadmarca" runat="server"
    Text='<%# Eval("Cantidad") %>'></asp:Label>)
</li>    
</ItemTemplate>
</asp:DataList>
<%--<li>
<a href="http://livedemo00.template-help.com/magento_42968/servers.html?manufacturer=21">HP</a>
(2)
</li>
<li>
<a href="http://livedemo00.template-help.com/magento_42968/servers.html?manufacturer=20">MvixBOX</a>
(1)
</li>
<li>
<a href="http://livedemo00.template-help.com/magento_42968/servers.html?manufacturer=19">Seagate</a>
(1)
</li>--%>
</ol>
</dd>
</dl>
<%--<script type="text/javascript">    decorateDataList('narrow-by-list')</script>--%>
</div>
</div>
<div class="block block-layered-nav">
<div class="block-title">
<strong><span>Top Productos</span></strong>
</div>
<div class="block-content">
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="600000">
</asp:Timer>
<div id="productos_relacionados" runat="server">
</div>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>
<%--<ol class="mini-products-list" id="block-related">
<li class="item">
<div class="product">
<a href="http://livedemo00.template-help.com/magento_42968/tivo-ag0100-wireless-g-usb-network-adapter.html" title="TiVo AG0100 Wireless G USB Network Adapter" class="product-image"><img src="http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/thumbnail/90x/9df78eab33525d08d6e5fb8d27136e95/f/i/file_10.jpg" alt="TiVo AG0100 Wireless G USB Network Adapter"/></a>
<p class="product-name"><a href="http://livedemo00.template-help.com/magento_42968/tivo-ag0100-wireless-g-usb-network-adapter.html">TiVo AG0100 Wireless G USB Network Adapter</a></p>
<div class="product-details">
<div class="price-box">old-price
<span class="regular-price" id="product-price-9-related">
<span class="price">$50.00</span> </span>
</div>
<a href="http://livedemo00.template-help.com/magento_42968/wishlist/index/add/product/9/" class="link-wishlist">Add to Wishlist</a>
</div>
</div>
</li>
<li class="item">
<div class="product">
<a href="http://livedemo00.template-help.com/magento_42968/d-link-medialounge-high-definition-media-player.html" title="D-Link MediaLounge High-Definition Media Player" class="product-image"><img src="http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/thumbnail/90x/9df78eab33525d08d6e5fb8d27136e95/f/i/file_1_9.jpg" alt="D-Link MediaLounge High-Definition Media Player"/></a>
<p class="product-name"><a href="http://livedemo00.template-help.com/magento_42968/d-link-medialounge-high-definition-media-player.html">D-Link MediaLounge High-Definition Media Player</a></p>
<div class="product-details">
<div class="price-box">
<span class="regular-price" id="product-price-10-related">
<span class="price">$50.99</span> </span>
</div>
<a href="http://livedemo00.template-help.com/magento_42968/wishlist/index/add/product/10/" class="link-wishlist">Add to Wishlist</a>
</div>
</div>
</li>
<li class="item">
<div class="product">
<a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html" title="RangeMax WNDR3300 Dual Band Wireless-N Router " class="product-image"><img src="http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/thumbnail/90x/9df78eab33525d08d6e5fb8d27136e95/f/i/file_28.jpg" alt="RangeMax WNDR3300 Dual Band Wireless-N Router "/></a>
<p class="product-name"><a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html">RangeMax WNDR3300 Dual Band Wireless-N Router </a></p>
<div class="product-details">
<div class="price-box">
<span class="regular-price" id="product-price-25-related">
<span class="price">$149.99</span> </span>
</div><br />
<a href="http://livedemo00.template-help.com/magento_42968/wishlist/index/add/product/25/" class="link-wishlist">Add to Wishlist</a>
</div>
</div>
</li>
<li class="item">
<div class="product">
<a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html" title="RangeMax WNDR3300 Dual Band Wireless-N Router " class="product-image"><img src="http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/thumbnail/90x/9df78eab33525d08d6e5fb8d27136e95/f/i/file_28.jpg" alt="RangeMax WNDR3300 Dual Band Wireless-N Router "/></a>
<p class="product-name"><a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html">RangeMax WNDR3300 Dual Band Wireless-N Router </a></p>
<div class="product-details">
<div class="price-box">
<span class="regular-price" id="Span1">
<span class="price">$149.99</span> </span>
</div><br />
<a href="http://livedemo00.template-help.com/magento_42968/wishlist/index/add/product/25/" class="link-wishlist">Add to Wishlist</a>
</div>
</div>
</li>
<li class="item">
<div class="product">
<a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html" title="RangeMax WNDR3300 Dual Band Wireless-N Router " class="product-image"><img src="http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/thumbnail/90x/9df78eab33525d08d6e5fb8d27136e95/f/i/file_28.jpg" alt="RangeMax WNDR3300 Dual Band Wireless-N Router "/></a>
<p class="product-name"><a href="http://livedemo00.template-help.com/magento_42968/rangemax-wndr3300-dual-band-wireless-n-router.html">RangeMax WNDR3300 Dual Band Wireless-N Router </a></p>
<div class="product-details">
<div class="price-box">
<span class="regular-price" id="Span2">
<span class="price">$149.99</span> </span>
</div><br />
<a href="http://livedemo00.template-help.com/magento_42968/wishlist/index/add/product/25/" class="link-wishlist">Add to Wishlist</a>
</div>
</div>
</li>
</ol>--%>
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
<script type="text/javascript">

    Sys.Net.WebRequestManager.add_invokingRequest(onInvoke);
    Sys.Net.WebRequestManager.add_completedRequest(onComplete);

    function onInvoke(sender, args) {
        $find('<%= mpeProgress.ClientID %>').show();
    }

    function onComplete(sender, args) {
        $find('<%= mpeProgress.ClientID %>').hide();
    }

    function pageUnload() {
        Sys.Net.WebRequestManager.remove_invokingRequest(onInvoke);
        Sys.Net.WebRequestManager.remove_completedRequest(onComplete);
    }

    </script>
</asp:Content>
