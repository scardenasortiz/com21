<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servicios.aspx.cs" Inherits="servicios" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="http://ogp.me/ns/fb#">
<head id="cabecera_esp" runat="server">
</head>
<body class=" catalog-category-view categorypath-servers-html category-servers">
    <form id="form1" runat="server">
    
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
<div class="header-buttons1">
<div class="row-1">
<%--<div class="header-button top-login">
<ul class="links">
<li class="first last"><a href="iniciar.aspx" title="Login" class="Login_link">Login</a></li>
</ul>
</div>--%>
<div class="header-button menu-list">
<a href="#"></a>
<asp:Panel ID="pInicioRe" runat="server">
<ul class="links">
<li class="first"><a href="iniciar.aspx" title="Iniciar sesión">Iniciar sesión</a></li>
<li class=" last"><a href="registrate.aspx" title="Registrate" class="top-link-checkout">Registrate</a></li>
</ul>
</asp:Panel>
<asp:Panel ID="pInicioRelogin" runat="server" Visible="false">
<ul class="links">
<li class="first"><a href="#" title="Mi cuenta">Mi cuenta</a></li>
<%--<li><a href="#" title="Checkout" class="top-link-checkout">Realizar pedido</a></li>
<li><a href="#" title="Checkout" class="top-link-checkout">Mis ordenes</a></li>--%>
<li class=" last"><a href="cerrarsession.aspx" title="Checkout" class="top-link-checkout">Cerar sesión</a></li>
</ul>
</asp:Panel>
</div>
</div>
</div>
<div id="search_mini_form">
<div class="form-search">
<label for="search">Buscar:</label>
<asp:TextBox ID="search1" runat="server" class="input-text" MaxLength="128"></asp:TextBox>
<asp:Button ID="btnbuscar1" runat="server" Text="Buscar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="27px" 
        Width="55px" />
</div>
</div>

<h1 class="logo"><strong>Com21 S.A</strong><a 
        href="default.aspx" title="Com21 S.A" class="logo"><img 
        src="images/logocom21icon.png" alt="Com21 S.A" width="200" height="45" /></a></h1>
<asp:Panel ID="pInicio" runat="server">
<div class="row-2">
<div class="quick-access">
<div class="header-links">
<ul class="links">
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
<h3>Usuario:&nbsp;<asp:Label ID="lblusernomb" runat="server" ForeColor="White"></asp:Label><%--&nbsp;-&nbsp;--%></h3>
<%--<h3>Mi Carro:</h3>
<div class="block-content">
<div class="empty">
<asp:Label ID="lblitemscarrito" runat="server" Text="0 item(s)"></asp:Label> <span class="price">
    <asp:Label ID="lbltotalcarrito" runat="server" Text="$0.00"></asp:Label></span> <div class="cart-content">
No tiene artículos en su carrito de compras. </div>
</div>
</div>--%>
</div>
<div class="quick-access">
<div class="header-links">
<ul class="links">
<li class="first"><a href="#" title="Mi cuenta">Mi cuenta</a></li>
<%--<li><a href="#" title="Checkout" class="top-link-checkout">Realizar pedido</a></li>
<li><a href="#" title="Checkout" class="top-link-checkout">Mis ordenes</a></li>--%>
<li><a href="cerrarsession.aspx" title="Checkout" class="top-link-checkout">Cerar sesión</a></li>
</ul>
<%--<ul class="links">
<li class="first last"><a href="http://livedemo00.template-help.com/magento_42968/customer/account/login/" title="Entrar" class="Login_link">Iniciar sesión</a></li>
</ul>--%>
</div>
</div>
<div class="clear"></div>
</div>
</asp:Panel>
<div class="clear"></div>
<div class="search-cont">
<div class="form-search">
<label for="search">Buscar:</label>
    <asp:TextBox ID="search" runat="server" class="input-text" MaxLength="128"></asp:TextBox>
    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="45px" 
        Width="20%" Font-Size="16px" />
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
<%--<li class="level0 nav-4 level-top"><a href="subimpresion.aspx?Cat=3" class="level-top"><span>Suministros de Impresión</span></a></li>--%>
<%--<li class="level0 nav-5 level-top parent"><a href="#" class="level-top"><span>Telefonía</span></a>
   <ul class="level0">
     <li class="level1 nav-5-1 first"><a href="productos.aspx?Cat=2&Sub=5"><span>Celulares</span></a></li>
     <li class="level1 nav-5-2"><a href="productos.aspx?Cat=2&Sub=5"><span>Telefonos Inalámbricos</span></a></li>
     </ul>
</li>--%>
<%--<li class="level0 nav-6 level-top parent"><a href="#" class="level-top"><span>Computo</span></a>
   <ul class="level0">
     <li class="level1 nav-6-1 first"><a href="productos.aspx?Cat=2&Sub=5"><span>Equipos Computación</span></a></li>
     <li class="level1 nav-6-2"><a href="productos.aspx?Cat=2&Sub=5"><span>Laptops</span></a></li>
     </ul>
</li>--%>
<li class="level0 nav-4 level-top"><a href="servicio.aspx" class="level-top"><span>Servicios</span></a></li>
<li class="level0 nav-5 level-top"><a href="noticias.aspx" class="level-top"><span>Noticias</span></a></li>
<li class="level0 nav-6 last level-top"><a href="contactenos.aspx" class="level-top"><span>Contactos</span></a></li>
</ul>
</div>
</div>
<div class="clear"></div>
</div>
</div>
<div class="main-container col2-right-layout">
<ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
        </ajaxtoolkit:toolkitscriptmanager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<div class="padding-s">
<div class="page-title category-title">
<h1><asp:Label ID="lbltitulo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="Face" runat="server">
</div></h1>
</div> 
<div class="category-products">
<div style="width:700px; margin-left:auto; margin-right:auto; text-align:center; margin-bottom:15px;">
    <asp:Image ID="img" runat="server" BorderColor="#ABCD43" BorderStyle="Solid" CssClass="BorderShadow" 
        BorderWidth="1.5px" />
</div>
<div id="productos_web" runat="server">
</div>
</div>
</div>
</div>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-content">
<asp:Image ID="Image3" runat="server" ImageUrl="~/images/publi.jpg" Width="100%" />
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
</ContentTemplate>
</asp:UpdatePanel>
<!--aqui va la especifica de los productos-->
<%--<div id="tema" runat="server"></div>--%>
</div>
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
</ul> <%--<ul class="links">
<li class="first"><a href="http://livedemo00.template-help.com/magento_42968/catalog/seo_sitemap/category/" title="Site Map">Mapa del sitio</a></li>
<li><a href="http://livedemo00.template-help.com/magento_42968/catalogsearch/term/popular/" title="Search Terms">Search Terms</a></li>
<li><a href="http://livedemo00.template-help.com/magento_42968/catalogsearch/advanced/" title="Advanced Search">Busqueda </a></li>
<li><a href="http://livedemo00.template-help.com/magento_42968/sales/guest/form/" title="Orders and Returns">Orders and Returns</a></li>
<li class=" last"><a href="http://livedemo00.template-help.com/magento_42968/contacts/" title="Contact Us">Contact Us</a></li>
</ul>--%>
</div>
</div>
<%--<div class="footer-col">
<h4>Why buy from us</h4>
<div class="footer-col-content">
<ul>
<li><a href="#">Shipping & Returns</a></li>
<li><a href="#">Secure Shopping</a></li>
<li><a href="#">International Shipping</a></li>
<li><a href="#">Affiliates</a></li>
<li><a href="#">Group Sales</a></li>
</ul>
</div>
</div>--%>
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
						<address>&copy; <script type="text/javascript">						                    var mdate = new Date(); document.write(mdate.getFullYear());</script> Com21 S.A. Todos los Derechos Reservados.</address>
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

<!--LIVEDEMO_00 -->

<%--<script type="text/javascript">
    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-7078796-5']);
    _gaq.push(['_trackPageview']);
    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();</script>--%>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41913935-1', 'designsie.com');
        ga('send', 'pageview');

</script>
<%--<script type="text/javascript">    if (!NREUMQ.f) { NREUMQ.f = function () { NREUMQ.push(["load", new Date().getTime()]); var e = document.createElement("script"); e.type = "text/javascript"; e.src = (("http:" === document.location.protocol) ? "http:" : "https:") + "//" + "d1ros97qkrwjf5.cloudfront.net/42/eum/rum.js"; document.body.appendChild(e); if (NREUMQ.a) NREUMQ.a(); }; NREUMQ.a = window.onload; window.onload = NREUMQ.f; }; NREUMQ.push(["nrfj", "beacon-1.newrelic.com", "72d7dcce33", "1388850", "ZV1TZ0FTVkFVWkwKXlwXcFBHW1dcG1pZF1BeV1YcUFNMV1NWShoeRFFURA==", 0, 1543, new Date().getTime(), "", "", "", "", ""]);</script>--%>

    </form>
</body>
</html>

