<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="catproductos.aspx.cs" Inherits="catproductos" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet" href="style/MenuCatalogo.css">
<%--    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
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
<div class="toolbar-bottom">
<div class="toolbar">
<div class="pager">
<p class="amount">
<strong><asp:Label ID="lblitems" runat="server" Text="0" ForeColor="#383737"></asp:Label> Item(s)</strong>
</p>
</div>
<div class="sorter">
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/gridV.gif" 
        onclick="ibgrid_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
        ID="ImageButton2" runat="server" ImageUrl="~/images/listN.gif" 
        onclick="iblist_Click" />
</div>
</div>
</div>
</div>
<div id="map-popup" class="map-popup" style="display:none;">
<a href="#" class="map-popup-close" id="map-popup-close">x</a>
<div class="map-popup-arrow"></div>
<div class="map-popup-heading"><h2 id="map-popup-heading"></h2></div>
<div class="map-popup-content" id="map-popup-content">
<div class="map-popup-msrp" id="map-popup-msrp-box"><strong>Price:</strong> <span style="text-decoration:line-through;" id="map-popup-msrp"></span></div>
<div class="map-popup-price" id="map-popup-price-box"><strong>Actual Price:</strong> <span id="map-popup-price"></span></div>
<div class="map-popup-checkout">
<form action="#" method="POST" id="product_addtocart_form_from_popup">
<input type="hidden" name="product" class="product_id" value="" id="map-popup-product-id"/>
<div class="additional-addtocart-box">
</div>
<button type="button" title="Add to Cart" class="button btn-cart" id="map-popup-button"><span><span>Add to Cart</span></span></button>
</form>
</div>
<script type="text/javascript">
        //<![CDATA[
    document.observe("dom:loaded", Catalog.Map.bindProductForm);
        //]]>
        </script>
</div>
<div class="map-popup-text" id="map-popup-text">Our price is lower than the manufacturer's &quot;minimum advertised price.&quot; As a result, we cannot show you the price in catalog or the product page. <br/><br/> You have no obligation to purchase the product once you know the price. You can simply remove the item from your cart.</div>
<div class="map-popup-text" id="map-popup-text-what-this">Our price is lower than the manufacturer's &quot;minimum advertised price.&quot; As a result, we cannot show you the price in catalog or the product page. <br/><br/> You have no obligation to purchase the product once you know the price. You can simply remove the item from your cart.</div>
</div>
</div>
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlprecio" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlselect" 
            EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ibgrid" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="iblist" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<div class="col-right sidebar span3">
<div class="block block-layered-nav" style="margin-bottom: 5px;">
<div class="block-title">
<strong><span>Catálogo de productos</span></strong>
</div>
<div class="block-content">
<div id="menu_catalogo_web" runat="server">
<%--<ul class="sidenav">
<li>
<a href="#">Item 1<span>Duis diam ligula, luctus nec varius eu, interdum eget turpis. Ut convallis tempor tellus, sed tincidunt velit feugiat quis. Vivamus placerat ligula eu metus molestie tincidunt. Sed tempus porttitor eros vitae vehicula.</span></a>
</li>
<li>
<a href="#">Item 2<span>Suspendisse tristique mauris vel odio pulvinar sit amet consectetur est bibendum? Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non sapien at tellus euismod feugiat.</span></a>
</li>
<li>
<a href="#">Item 3<span>Morbi porttitor tristique lacus a malesuada. Morbi vel porta metus. Nunc laoreet libero eget erat blandit faucibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In hac habitasse platea dictumst. Integer quis nulla nec elit dignissim molestie sit amet vel quam?</span></a>
</li>
<li>
<a href="#">Item 4<span>Tation utrum utrum abigo demoveo immitto aliquam sino aliquip.</span></a>
</li>
<li>
<a href="#">Item 5<span><img width=220" src="../../../2.bp.blogspot.com/_hljKDuw-cxQ/TDTwvkrBe7I/AAAAAAAAP-I/93pkLlddkoI/s00/324.png"/></span></a>
</li>
<li>
<a href="#">Item 6<span>Morbi pretium tincidunt bibendum. Nam ac viverra ipsum. Aenean rutrum lorem sit amet metus.</span></a>
</li>
<li>
<a href="#">Item 7<span>Blandit turpis patria euismod at iaceo appellatio, demoveo esse.</span></a>
</li>
</ul>--%>
<%--<ul class="sidenav">
<li>
<div>Item 1<span><a href="#">hola</a><br /><a href="#">hola</a><br /><a href="#">hola</a><br /></span></div>
</li>
<li>
<div>Item 2<span>Suspendisse tristique mauris vel odio pulvinar sit amet consectetur est bibendum? Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non sapien at tellus euismod feugiat.</span></div>
</li>
<li>
<div>Item 3<span>Morbi porttitor tristique lacus a malesuada. Morbi vel porta metus. Nunc laoreet libero eget erat blandit faucibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In hac habitasse platea dictumst. Integer quis nulla nec elit dignissim molestie sit amet vel quam?</span></div>
</li>
<li>
<div>Item 4<span>Tation utrum utrum abigo demoveo immitto aliquam sino aliquip.</span></div>
</li>
<li>
<div>Item 5<span><img width=220" src="../../../2.bp.blogspot.com/_hljKDuw-cxQ/TDTwvkrBe7I/AAAAAAAAP-I/93pkLlddkoI/s00/324.png"/></span></div>
</li>
<li>
<div>Item 6<span>Morbi pretium tincidunt bibendum. Nam ac viverra ipsum. Aenean rutrum lorem sit amet metus.</span></div>
</li>
<li>
<div>Item 7<span>Blandit turpis patria euismod at iaceo appellatio, demoveo esse.</span></div>
</li>
</ul>--%>
</div>
</div>
</div>
<div>
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
