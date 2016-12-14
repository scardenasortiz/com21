<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Especifica.aspx.cs" Inherits="Especifica"  %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="http://ogp.me/ns/fb#">
<head id="Head1" runat="server">

</head>
<body class=" cms-index-index cms-home">
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <div class="wrapper en-lang-class">
<noscript>
<div class="global-site-notice noscript">
<div class="notice-inner">
<p>
<strong>JavaScript seems to be disabled in your browser.</strong><br/>
You must have JavaScript enabled in your browser to utilize the functionality of this website. </p>
</div>
</div>
</noscript>
<div class="page">
<div class="header-container">
<div class="container">
<div class="row">
<div class="span12">
<div class="header">
<asp:Panel ID="pInicioRe" runat="server">
<div class="header-buttons1">
<div class="row-1">
<div class="header-button menu-list">
<a href="#"></a>
<ul class="links" style="right: 0; left: auto;">
<li class="first"><a href="iniciar.aspx" title="Iniciar sesión">Iniciar sesión</a></li>
<li class=" last"><a href="registrate.aspx" title="Registrate" class="top-link-checkout">Registrate</a></li>
</ul>
</div>
</div>
</div> 
</asp:Panel>
<asp:Panel ID="pInicioRelogin" runat="server" Visible="false">
<div class="header-buttons1">
<div class="row-1">
<div class="header-button menu-list">
<a href="#"></a>
<ul class="links" style="right: 0; left: auto;">
<li class="first"><a href="cuentaUsuario.aspx" title="Mi cuenta">Mi cuenta</a></li>
<li><a href="carrito.aspx" title="Realizar Pedido" class="top-link-checkout">Realizar pedido</a></li>
<li><a href="ordenes.aspx" title="Checkout" class="top-link-checkout">Mis ordenes</a></li>
<li class=" last"><a href="cerrarsession.aspx" title="Checkout" class="top-link-checkout">Cerrar sesión</a></li>
</ul>
</div>
</div>
</div> 
</asp:Panel>
<div id="search_mini_form" style="padding-top: 20px;">
<div class="form-search">
<label for="search">Buscar:</label>
<asp:TextBox ID="search1" runat="server" class="input-text" MaxLength="128"></asp:TextBox>
<asp:Button ID="btnbuscar1" runat="server" Text="Buscar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="27px" 
        Width="55px" onclick="btnbuscar1_Click" />
</div>
</div>
<asp:Panel ID="logohead" runat="server">
<h1 class="logo"><strong>Com21 S.A</strong><a 
        href="default.aspx" title="Com21 S.A" class="logo"><img 
        src="images/logocom21icon.png" alt="Com21 S.A" width="130" height="45" /></a></h1>
</asp:Panel>
<asp:Panel ID="bannerhead" runat="server">
<div style="margin-left:auto; margin-right:auto; text-align:left;">
<h1 class="logo" style="text-align: left;"><a 
        href="default.aspx" title="Com21 S.A" class="logo"><img 
        src="images/slogan.png" alt="Com21 S.A" width="900" height="110" /></a></h1>
</div>
</asp:Panel>
<asp:Panel ID="pInicio" runat="server">
<div class="row-2">
<div class="quick-access">
<div class="header-links">
<ul class="links" style="right: 0; left: auto;">
<li class="first"><a href="iniciar.aspx" title="Iniciar sesión">Iniciar sesión</a></li>
<li><a href="registrate.aspx" title="Registrate" class="top-link-checkout">Registrate</a></li>
</ul>
</div>
</div>
<div class="clear"></div>
</div>
</asp:Panel>
<asp:Panel ID="pInicioSesion" runat="server" Visible="false">
<div class="row-2">
<div class="block-cart-header">
<h3>Usuario:&nbsp;<asp:Label ID="lblusernomb" runat="server" ForeColor="White"></asp:Label></h3>
<h3>Mi Carro:</h3>
<div class="block-content">
<div class="empty">
<asp:UpdatePanel ID="upCantidad" runat="server">
<ContentTemplate>
<asp:Label ID="lblitemscarrito" runat="server" Text="0 item(s)"></asp:Label> <span class="price">
    <asp:Label ID="lbltotalcarrito" runat="server" Text="$0.00"></asp:Label></span>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnagregar" />
</Triggers>
</asp:UpdatePanel>
</div>
</div>
</div>
<div class="quick-access">
<div class="header-links">
<ul class="links">
<li class="first"><a href="cuentaUsuario.aspx" title="Mi cuenta">Mi cuenta</a></li>
<li><a href="carrito.aspx" title="Realizar Pedido" class="top-link-checkout">Realizar pedido</a></li>
<li><a href="ordenes.aspx" title="Checkout" class="top-link-checkout">Mis ordenes</a></li>
<li><a href="cerrarsession.aspx" title="Checkout" class="top-link-checkout">Cerrar sesión</a></li>
</ul>
</div>
</div>
<div class="clear"></div>
</div>
</asp:Panel>
<div class="clear"></div>
<div class="search-cont" style="padding-top: 20px;">
<div class="form-search">
<label for="search">Buscar:</label>
    <asp:TextBox ID="search" runat="server" class="input-text" MaxLength="128"></asp:TextBox>
    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="45px" 
        Width="20%" Font-Size="16px" onclick="btnbuscar_Click" />
</div>
</div>
</div>
</div>
</div>
<div class="clear"></div>
</div>
</div>
<div class="nav-container">
<div class="container">
<div class="row">
<div class="span12">
<div id="menu-icon">Menú</div>
<ul id="nav" class="sf-menu">
<li class="level0 nav-1 first level-top"><a href="Default.aspx" class="level-top"><span>Inicio</span></a></li>
<li class="level0 nav-2 level-top parent"><a href="#" class="level-top"><span>Quiénes Somos</span></a>
   <ul class="level0">
     <li class="level1 nav-2-1 first"><a href="nosotros.aspx"><span>Nosotros</span></a></li>
     <li class="level1 nav-2-2"><a href="info.aspx"><span>Misión/Visión</span></a></li>
     </ul>
</li>
<li class="level0 nav-3 level-top"><a href="catproductos.aspx?Cat=0&Sub=0" class="level-top"><span>Productos</span></a></li>
<li class="level0 nav-4 level-top"><a href="servicio.aspx" class="level-top"><span>Servicios</span></a></li>
<li class="level0 nav-5 level-top"><a href="noticias.aspx" class="level-top"><span>Noticias</span></a></li>
<li class="level0 nav-6 level-top"><a href="ofertas.aspx" class="level-top"><span>Ofertas</span></a></li>
<li class="level0 nav-7 last level-top"><a href="contactenos.aspx" class="level-top"><span>Contactos</span></a></li>
</ul>
</div>
</div>
<div class="clear"></div>
</div>
</div>
<!--aqui va-->
<div class="main-container col2-right-layout">
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<asp:HiddenField ID="hfIdentNSO" runat="server" />
<asp:Panel ID="pPro" runat="server" Visible="false">
<div class="padding-s">
<div id="messages_product_view"></div>
<div class="product-view">
<div class="product-essential">
<div id="product_addtocart_form">
<div class="no-display">
<input type="hidden" name="product" value="27"/>
<input type="hidden" name="related_product" id="related-products-field" value=""/>
</div>
<div class="product-img-box">
<script type="text/javascript" language="javascript">
    jQuery(document).ready(function () {
        count = 0;
        jQuery('.iosSlider .slider #item').each(function () { count++; });
        if (count < 4) { jQuery('.next, .prev').css({ 'display': 'none' }); }
        if (count > 3) {
            jQuery('.iosSlider').iosSlider({
                snapToChildren: true,
                desktopClickDrag: true,
                keyboardControls: true,
                onSliderLoaded: sliderTest,
                onSlideStart: sliderTest,
                onSlideComplete: slideComplete,
                navNextSelector: jQuery('.next'),
                navPrevSelector: jQuery('.prev')
            });
            jQuery('.next, .prev').css({ 'display': 'block' });
        }
    });

    function sliderTest(args) {
        try {
            console.log(args);
        } catch (err) { }
    }

    function slideComplete(args) {
        jQuery('.next, .prev').removeClass('unselectable');
        if (args.currentSlideNumber == 1) {
            jQuery('.prev').addClass('unselectable');
        } else if (args.currentSliderOffset == args.data.sliderMax) {
            jQuery('.next').addClass('unselectable');
        }
    }
</script>
<p id="Imagenes_Productos" runat="server" class="product-image">
</p>
</div>
<div id="prodshop" runat="server" class="product-shop">
<div class="product-name">
<h1 id="titulo" runat="server"></h1>
</div>
<div class="short-description">
<div id="descripcion_corta" runat="server" class="std"></div>
</div>
<p class="availability in-stock">Disponibilidad: <span id="Existe" runat="server">En existencia</span></p>
<div class="price-box">
<span class="regular-price" id="product-price-27">
<span id="precio_actual" runat="server" class="price"></span> </span><br />
<span class="regular-price" id="product-price-28">
<span id="precio_especial" runat="server" class="price" style="color: #8e8e90; font-size:14px"></span><br />
<p class="availability in-stock" style="font-weight: normal;font-size: 9px;">Nota: La cantidad agregada a su carrito se calculara en base al precio normal, el descuento se tomará en cuenta en el proceso de compra.</p> 
</span>
</div>
<div class="clear"></div>
<div class="add-to-box">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:HiddenField ID="hfCantidadBD" runat="server" />
    <asp:HiddenField ID="hfprecio" runat="server" />
    <asp:HiddenField ID="hfDescuento" runat="server" />
    <asp:HiddenField ID="hfCat" runat="server" /><asp:HiddenField ID="hfSubCat" runat="server" />
        <div class="add-to-cart">
        <asp:Panel ID="pbtncarrito" runat="server" Visible="false">
<div class="qty-block">
<label for="qty">Cantidad:</label>
    <asp:TextBox ID="txtcantidad" runat="server" class="input-text qty" MaxLength="5" ForeColor="Black"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblnosi" runat="server" ForeColor="Red"></asp:Label>
    <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txtcantidad"
           FilterType="Numbers" />
</div>
<span style="float: right;">
<asp:Button ID="btnagregar" runat="server" Text="Agregar al Carrito" ToolTip="Agregar" 
        CssClass="button bordebotones" Height="30" Width="150" BackColor="#ABCD43" 
        ForeColor="White" Font-Bold="True" Font-Size="14px" 
        onclick="btnagregar_Click" />
</span>
</asp:Panel>
</div>
<asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 200px; background-color: #E2E2E2; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image4" runat="server" ImageUrl="~/images/loadinfo.net1.gif" />
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
</asp:UpdatePanel>
<span class="or">OR</span>
</div>
<div id="FaceP" runat="server" class="addthis_toolbox addthis_default_style">
</div>
</div>
</div>
</div>
<div class="product-collateral">
<div class="box-collateral box-description">
<h2>Detalle</h2>
<div class="box-collateral-content">
<div id="detalle" runat="server" class="std">
</div>
</div>
</div>
<div class="box-collateral box-description">
<h2>Tags</h2>
<div class="box-collateral-content">
<div id="tags_mezclados" runat="server" class="std">
</div>
</div>
</div>
<div class="box-collateral" style="margin-bottom:10px">
<h2>Productos Relacionados</h2>
<div class="box-collateral box-up-sell related-carousel-none">
<ul id="produt_re" runat="server" class="products-ups">

</ul>
<script type="text/javascript">    decorateTable('upsell-product-table')</script>
<script type="text/javascript">
    document.observe('dom:loaded', function () {
        var home_blocks = $$('.box-up-sell');
        home_blocks.each(function (p) {
            var grids = p.select('.products-ups');
            grids.each(function (n) {
                var columns = n.select('li.item');
                var max_height = 0;
                columns.each(function (m) {
                    if (m.getHeight() > max_height) {
                        max_height = m.getHeight();
                    }
                });
                var boxes = n.select('li .product-name');
                boxes.each(function (b) {
                    var this_column = b.up('li.item');
                    var box_indent = this_column.getHeight() - b.getHeight();
                    b.setStyle({
                        height: max_height - box_indent + 'px'
                    });
                });
            });
        });
    })
    jQuery(window).bind('load resize', function () {

        sw = jQuery('.container').width();
        if (sw < 765) { jQuery('li .product-name').removeAttr('style'); };
    });
	</script>
</div>
</div>
</div>
</div>

<script type="text/javascript">
    var lifetime = 3600;
    var expireAt = Mage.Cookies.expires;
    if (lifetime > 0) {
        expireAt = new Date();
        expireAt.setTime(expireAt.getTime() + lifetime * 1000);
    }
    Mage.Cookies.set('external_no_cache', 1, expireAt);
</script>
</div>
</asp:Panel>
<asp:Panel ID="pServ" runat="server" Visible="false">
<div class="padding-s">
<div id="tituloServi" runat="server" class="page-title category-title">
<h1><asp:Label ID="lbltitulo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="FaceS" runat="server" style="margin-top: 10px;">
</div></h1>
</div> 
<div id="desServi" runat="server" class="category-products">
<div id="DivImgS" runat="server">
    <asp:Image ID="img" runat="server" BorderColor="#ABCD43" BorderStyle="Solid" BorderWidth="1.5px" />
</div>
<div class="short-description">
<div id="servicios_web" runat="server" class="std">
</div>
</div>
</div>
</div>
</asp:Panel>
<asp:Panel ID="pNoti" runat="server" Visible="false">
<div class="padding-s">
<div id="tituloNoti" runat="server" class="page-title category-title">
<h1><asp:Label ID="lbltituloN" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="FaceN" runat="server" style="margin-top: 10px;">
</div></h1>
</div> 
<div id="desNoti" runat="server" class="category-products">
<div id="Divimg" runat="server">
    <asp:Image ID="Image5" runat="server" BorderColor="#ABCD43" BorderStyle="Solid" CssClass="BorderShadow" 
        BorderWidth="1.5px" />
</div>
<div id="noticias_web" runat="server">
</div>
</div>
</div>
</asp:Panel>
</div>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-content">
<asp:Image ID="Image3" runat="server" ImageUrl="~/images/publi.jpg" Width="100%" />
</div>
</div>
<div class="block block-list block-compare">
<div class="block-title">
<strong><span>Facebook </span></strong>
</div>
<div class="block-content">
<iframe src="//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FCOM-21-SA%2F166410506765758&amp;width=250&amp;height=260&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;border_color&amp;header=false&amp;appId=330721080316666" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:100%; height:290px;" allowTransparency="true"></iframe>
</div>
</div>
<div class="block block-list block-compare">
<div class="block-title">
<strong><span>Twitter</span></strong>
</div>
<div class="block-content">
<a class="twitter-timeline" data-dnt="true" href="https://twitter.com/com21_sa" data-widget-id="358332484888428545">Tweets por @com21_sa</a>
<script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<!--aqui va la especifica de los productos-->
<div id="tema" runat="server"></div>
</div>
<!--mirar aqui-->
<div class="footer-container">
<div class="container">
<div class="row">
<div class="span12">
<div class="footer">
<p id="back-top"><a href="#top"><span></span></a> </p>
<div class="footer-cols-wrapper">
<div class="footer-col">
<h4>Información</h4>
<div class="footer-col-content">
<ul>
<li><a href="Default.aspx">Inicio</a></li>
<li><a href="info.aspx">Misión/Visión</a></li>
<li><a href="nosotros.aspx">Nosotros</a></li>
<li class="last privacy"><a href="contactenos.aspx">Contáctenos</a></li>
</ul>
</div>
</div>
<div class="footer-col">
<h4>Redes Sociales</h4>
<div class="footer-col-content">
    <table style="width: 100%;">
        <tr>
            <td>
                Síguenos en:<br /><a href="https://www.facebook.com/pages/COM-21-SA/166410506765758?fref=ts" target="_blank">
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/images/imagenes/Redes_sociales/facebook.png" Height="34px" 
                    Width="34px" /></a>&nbsp;&nbsp;&nbsp;<a href="https://twitter.com/com21_sa"><asp:Image 
                    ID="Image2" runat="server" 
                    ImageUrl="~/images/imagenes/Redes_sociales/twitter.png" Height="34px" 
                    Width="34px" /></a>
            </td>
        </tr>
    </table>
</div>
</div>
<div class="footer-col contacts"">
	<h4>Contactos</h4>
	<div class="footer-col-content">
        <ul>
<li>Guayaquil</li>
</ul>
		Victor Manuel Rendón 920, Lorenzo de Garaicoa
		<span class="tel">Tel:(+593) 42-300539</span>
	</div>
</div>					  </div>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="footer-container-2">
	<div class="container">
		<div class="row">
			<div class="span12">
					<div class="footer footer2">
						<address>&copy; <script type="text/javascript">						                    var mdate = new Date(); document.write(mdate.getFullYear());</script> Designsie Todos los Derechos Reservados.</address>
												<!--{%FOOTER_LINK}-->						<div class="clear"></div>
                                               <span id="siteseal"><img style=" height:35px; cursor:pointer;cursor:hand" src="https://seal.godaddy.com/images/3/es/siteseal_gd_3_h_l_m.gif" onclick="verifySeal();"></span>
						<div class="paypal-logo">
    <a href="#" title="Additional Options"><img src="images/bnr_nowAccepting_150x60.gif" alt="Additional Options" title="Additional Options" style="height:35px; width:95px"/></a>
</div>
					</div>
			</div>
		</div>
	</div>
</div>
            </div>
</div>
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
    </form>
</body>
</html>
