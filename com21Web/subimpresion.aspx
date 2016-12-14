<%@ Page Language="C#" MasterPageFile="~/master/infoproductos.master" AutoEventWireup="true" CodeFile="subimpresion.aspx.cs" Inherits="subimpresion" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
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
<%--<div class="limiter">
<label>Precio</label>
<asp:DropDownList ID="ddlprecio" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlselect_SelectedIndexChanged">
<asp:ListItem Text="Todos" Value="0"></asp:ListItem>
<asp:ListItem Text="$0.00 - $500.00" Value="1"></asp:ListItem>
<asp:ListItem Text="$500.01 - $800.00" Value="2"></asp:ListItem>
<asp:ListItem Text="$800.01 - $1000.00" Value="3"></asp:ListItem>
<asp:ListItem Text="$1000.01 - y por encima" Value="4"></asp:ListItem>
</asp:DropDownList>&nbsp;&nbsp;
</div>--%>
</div>
<%--<div class="sorter">
    &nbsp;&nbsp;&nbsp;&nbsp;</div>--%>
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
<%--<div class="sorter">
    &nbsp;&nbsp;&nbsp;&nbsp;</div>--%>
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
        <asp:AsyncPostBackTrigger ControlID="ddlselect" 
            EventName="SelectedIndexChanged" />
        <%--<asp:AsyncPostBackTrigger ControlID="ibgrid" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="iblist" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />--%>
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

