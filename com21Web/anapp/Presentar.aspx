<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Presentar.aspx.cs" Inherits="Presentar"  %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--xmlns:fb="http://www.facebook.com/2008/fbml"--%>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:og="http://ogp.me/ns#" xmlns:fb="http://ogp.me/ns/fb#" lang="es-ES" prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb#" xmlns:fb="http://www.facebook.com/2008/fbml">
<head runat="server">
<meta charset="UTF-8" />
<meta id="imgMeta" runat="server" property="og:image" content="" />
<meta id="titleMeta" runat="server" property="og:title" content=""/>
<meta id="urlMeta" runat="server" property="og:url" content=""/>
<meta property="og:site_name" content="http://com21.com.ec/"/>
<meta id="descripcionMeta" runat="server" property="og:description" content=""/>
<meta property="og:image:type" content="image/jpg" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link id="linkUrl" runat="server" rel="canonical" href="" />
<meta property='og:locale' content='es_ES'/>
<title id="titlePage" runat="server"></title>
<%--<meta name="viewport" content="width=device-width; initial-scale=1.0" />--%>
<meta id="Desp" runat="server" name="description" content=""/>
<meta name="keywords" content="com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby"/>
<meta name="robots" content="INDEX,FOLLOW"/>
<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/>
<link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/>
<link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/>
<script async type="text/javascript" src="js/jspagina/jquery-1.7.min.js"></script>
<%--<script async type="text/javascript" src="js/jquery-1.9.1.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/jquery.prettyPhoto.js"></script>
<script async type="text/javascript" src="js/jspagina/superfish.js"></script>--%>
<script async type="text/javascript" src="js/jspagina/jquery.easing.1.3.js"></script>
<script async type="text/javascript" src="js/jspagina/jquery.mobile.customized.min.js"></script>
<%--<script async type="text/javascript" src="js/jspagina/scripts.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/easyTooltip.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/jquery.jcarousel.min.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/jquery.iosslider.min.js"></script>--%>
<!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]-->
<link rel="stylesheet" type="text/css" href="css/styles.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/responsive.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/superfish.css" media="all"/>
<%--<link rel="stylesheet" type="text/css" href="css/camera.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/widgets.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/cloud-zoom.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/print.css" media="print"/>
<script async type="text/javascript" src="js/jspagina/prototype.js"></script>--%>
<%--<script type="text/javascript" src="js/jspagina/ccard.js"></script>
<script type="text/javascript" src="js/jspagina/validation.js"></script>--%>

<%--<script async type="text/javascript" src="js/jspagina/builder.js"></script>
<script async type="text/javascript" src="js/jspagina/effects.js"></script>
<script async type="text/javascript" src="js/jspagina/dragdrop.js"></script>
<script async type="text/javascript" src="js/jspagina/controls.js"></script>
<script async type="text/javascript" src="js/jspagina/slider.js"></script>
<script async type="text/javascript" src="js/jspagina/js.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/form.js"></script>
<script async type="text/javascript" src="js/jspagina/translate.js"></script>
<script async type="text/javascript" src="js/jspagina/cookies.js"></script>--%>
<%--<script async type="text/javascript" src="js/jspagina/cloud-zoom.1.0.2.min.js"></script>--%>
<script async type="text/javascript" src="js/jspagina/bootstrap.js"></script>
<%--<script async type="text/javascript" src="js/jspagina/msrp.js"></script>--%>

<%--<script type="text/javascript">
//<![CDATA[ var Translator = new Translate([]); //]]>
</script>
<script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
<script type="text/javascript">
    stLight.options({ publisher: "6820c949-0f64-4774-aed9-9dee23904b79", doNotHash: false, doNotCopy: false, hashAddressBar: false });
</script>--%>
<style type="text/css">
    .CajaCantidad
    {
        width: 60px !important;
    }
    .Header-A-P
    {
        height: 44px;
        /* vertical-align: middle; */
        border: 1px solid #ABCD43;
        background: #ABCD43;
        color: #fff;
        font-weight: bold;
       /* text-shadow: 0 -1px 1px #000;*/
        background-image: -webkit-gradient(linear,left top,left bottom,from(#C6DD80),to(#ABCD43));
        background-image: -webkit-linear-gradient(#C6DD80,#ABCD43);
        background-image: -moz-linear-gradient(#C6DD80,#ABCD43);
        background-image: -ms-linear-gradient(#C6DD80,#ABCD43);
        background-image: -o-linear-gradient(#C6DD80,#ABCD43);
        background-image: linear-gradient(#C6DD80,#ABCD43);
    }
    .h1Header-P
    {
        min-height: 1.1em;
        text-align: center;
        font-size: 14px;
        display: block;
        margin: .9em 1% .8em;
        padding: 0;
        text-overflow: ellipsis;
        overflow: hidden;
        white-space: nowrap;
        outline: 0!important;
        font-weight: bold;
    }
    /*mensajes de alerta*/
       .info, .exito, .alerta, .error {
    font-family:Arial, Helvetica, sans-serif; 
    font-size:13px;
    border: 1px solid;
    /*margin: 10px 0px;*/
    padding:15px 10px 15px 50px;
    background-repeat: no-repeat;
    background-position: 10px center;
}
.info {
    color: #00529B;
    background-color: #BDE5F8;
    background-image: url('cssJqueryMobile/img/info.png');
}
.exito {
    color: #4F8A10;
    background-color: #DFF2BF;
    background-image: url('cssJqueryMobile/img/exito.png');
}
.alerta {
    color: #9F6000;
    background-color: #FEEFB3;
    background-image: url('cssJqueryMobile/img/alerta.png');
}
.error {
    color: #D8000C;
    background-color: #FFBABA;
    background-image: url('cssJqueryMobile/img/error.png');
}
.QuitarBox
{
/* box-shadow: 0px 0px 0px rgba(0,0,0,0.18) !important; */
-moz-box-shadow: 0px 0px 0px rgba (0,0,0,0.18) !important;
-webkit-box-shadow: 0px 0px 0px rgba (0,0,0,0.18) !important;
}
.BotonesA
{
    display: inline-block !important;
    padding: .8em 30px !important;
    min-width: .75em;
    font-size: 13px !important;
    display: block;
    text-overflow: ellipsis;
    overflow: hidden;
    white-space: nowrap;
    position: relative;
    zoom: 1;
    display: block;
    text-align: center;
    cursor: pointer;
    position: relative;
    margin: .5em 5px;
    padding: 0;
    border: 1px solid #111;
    background: #333;
    font-weight: bold;
    color: #fff !important;
    text-shadow: 0 1px 1px #111;
    background-image: -webkit-gradient(linear,left top,left bottom,from(#444),to(#2d2d2d));
    background-image: -webkit-linear-gradient(#444,#2d2d2d);
    background-image: -moz-linear-gradient(#444,#2d2d2d);
    background-image: -ms-linear-gradient(#444,#2d2d2d);
    background-image: -o-linear-gradient(#444,#2d2d2d);
    background-image: linear-gradient(#444,#2d2d2d);
}
.BotonesAE
{
    display: inline-block !important;
    padding: .8em 30px !important;
    min-width: .75em;
    font-size: 13px !important;
    display: block;
    text-overflow: ellipsis;
    overflow: hidden;
    white-space: nowrap;
    position: relative;
    zoom: 1;
    /*display: block;*/
    text-align: center;
    cursor: pointer;
    position: relative;
    margin: .5em 5px;
    padding: 0;
    border: 1px solid #bbb;
    background: #dfdfdf;
    font-weight: bold;
    color: #222 !important;
    text-shadow: 0 1px 0 #fff;
    background-image: -webkit-gradient(linear,left top,left bottom,from(#f6f6f6),to(#e0e0e0));
    background-image: -webkit-linear-gradient(#f9f9f9,#e0e0e0);
    background-image: -moz-linear-gradient(#f6f6f6,#e0e0e0);
    background-image: -ms-linear-gradient(#f6f6f6,#e0e0e0);
    background-image: -o-linear-gradient(#f6f6f6,#e0e0e0);
    background-image: linear-gradient(#f6f6f6,#e0e0e0);
}
html { overflow-y:hidden; }
        body { overflow-y:hidden; }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $.mobile.pageLoadErrorMessage = false;
        $.mobile.fixedToolbars.show(true);
//        $(".EnviarC").click(function () {
//            var hUrl = '#<%=hfURL.ClientID %>';
//            var url = "envioCorreo.aspx?UrlRe=" + encodeURIComponent($(hUrl).val());
//            $(hUrl).val(url);
//            var btn = "#" + "<%=BtRefresh.ClientID %>";
//            $(btn).click();
//        });
//        $(".CancelarC").click(function () {
//            var btn = '#<%=BtRefresh.ClientID %>';
//        });
    });
</script>
<script type="text/javascript" language="javascript">
    var isCloseBrowser = false;

    document.onkeydown = function () {
        if (window.event.altKey == true && window.event.keyCode == 115)
            isCloseBrowser = true;
    };
    window.onmousemove = function () {
        if (window.event.clientY <= 1 || window.event.clientX <= 1)
            isCloseBrowser = true;
    };
    window.onbeforeunload = function (evt) {
        var valor;
        if (isCloseBrowser) {
            valor = '1';
            document.cookie = 'IsCloseBrowser = ' + valor + '';
        }
        else {
            valor = '0';
            document.cookie = 'IsCloseBrowser = ' + valor + '';
        }
    };

    if (window.history) {
        function noBack() { window.history.forward() }
        noBack();
        window.onload = noBack;
        window.onpageshow = function (evt) { if (evt.persisted) noBack() }
        window.onunload = function () { void (0) }
    }
</script>
</head>
<body class=" catalog-category-view categorypath-servers-html category-servers" style="background-color: #FFFFFF">
    <form id="form1" runat="server">
    <%--<div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/es_LA/all.js#xfbml=1&appId=448140018617323";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>--%>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:HiddenField ID="hfURL" runat="server" />
    <asp:HiddenField ID="hValorMensaje" runat="server" />
    <div style="display:none">
        
    </div>
        <div data-role="header" class="Header-A-P" role="banner" data-position="fixed"><h1 id="titulo" runat="server" class="h1Header-P" role="heading" aria-level="1"></h1></div>
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
<div class="QuitarBox main-container col2-right-layout">
<asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server" class="exito">Mensaje de éxito de la operación realizada</div>
</asp:Panel>
<%--<div class="error">Mensaje que informa al usuario sobre el error que se ha producido</div>--%>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<asp:Panel ID="pPro" runat="server" Visible="false">
<div class="padding-s">
<div id="messages_product_view"></div>
<div class="product-view" style="margin-bottom:0px">
<div class="product-essential" style=" padding-bottom:0px">
<div id="product_addtocart_form">
<div class="no-display">
<input type="hidden" name="product" value="27"/>
<input type="hidden" name="related_product" id="related-products-field" value=""/>
</div>
<div class="product-shop">
<%--<div class="product-name category-title">
<h1 id="titulo" runat="server" style="font-size: 20px;"></h1>
</div>--%>
<div class="product-img-box" style="text-align: center; width: 270px;">
<p id="Imagenes_Productos" runat="server" class="product-image" style=" height:270px">
</p>
</div>
<div class="short-description">
<div id="descripcion_corta" runat="server" class="std" style="text-align: justify"></div>
</div>
<p class="availability in-stock">Disponibilidad: <span id="Existe" runat="server">En existencia</span></p>
<div class="price-box">
<span class="regular-price" id="product-price-27">
<span id="precio_actual" runat="server" class="price" style="font-weight: bold; font-size:16px"></span> </span><br />
<span class="regular-price" id="product-price-28">
<span id="precio_especial" runat="server" class="price" style="color: #8e8e90; font-size:18px"></span> </span>
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
<div class="qty-block" style="line-height: 100px;">
<label for="qty" style="font-size: 20px; font-weight: bold; vertical-align: middle;">AGREGAR:</label>
    <asp:TextBox ID="txtcantidad" runat="server" class="input-text CajaCantidad" 
        MaxLength="5" ForeColor="Black" Width="80px" Height="40px" Font-Size="16px"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblnosi" runat="server" ForeColor="Red"></asp:Label>
    <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txtcantidad"
           FilterType="Numbers" />
</div>
<span style="float: right;">
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/anapp/images/cartAPP.png" Height="100px" onclick="btnagregar_Click" 
        Width="100px" />
<%--<asp:Button ID="btnagregar" runat="server" Text="Agregar al Carrito" ToolTip="Agregar" 
        CssClass="button bordebotones" Height="30" Width="150" BackColor="#ABCD43" 
        ForeColor="White" Font-Bold="True" Font-Size="14px" 
        onclick="btnagregar_Click" />--%>
</span>
</asp:Panel>

</div>
<asp:Panel ID="pErrorListo" runat="server" Visible="false">
            <table style="text-align: left; width:100%; color: #CC0000; background-color: #FF6F6F; padding-left: 5px; vertical-align: middle; padding-bottom: 2px; padding-top: 2px;">
                <tr>
                    <td style="padding: 5px" width="35px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/anapp/images/error.png" 
                    Height="30px" Width="30px" />
                    </td>
                    <td style="padding: 5px; vertical-align:middle">
                        <asp:Label ID="LblErrorListo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </asp:Panel>
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
<%--<div id="FaceP" runat="server" class="addthis_toolbox addthis_default_style">
</div>--%>
</div>
</div>
</div>
</div>
</div>
</asp:Panel>
<asp:Panel ID="pServicios" runat="server" Visible="false">
<div class="padding-s">
<div id="messages_product_view"></div>
<div class="product-view">
<div class="product-essential">
<div id="product_addtocart_form">
<div class="no-display">
<input type="hidden" name="product" value="27"/>
<input type="hidden" name="related_product" id="Hidden2" value=""/>
</div>
<%--auiq va imagenes --%>
<div class="product-shop">
<%--<div class="product-name category-title">
<h1 id="tituloServicios" runat="server"></h1>
</div>--%>
<div class="product-img-box">
<p id="Imagenes_servicios" runat="server" class="product-image">
</p>
</div>
<div class="short-description">
<div id="descripcion_servicios" runat="server" class="std" style="text-align: justify"></div>
</div>
<div class="clear"></div>
<div class="add-to-box">
<%--<span class="or">OR</span>--%>
<asp:Button ID="BtRefresh" runat="server" Text="Contáctenos" 
            onclick="BtRefresh_Click" CssClass="BotonesAE" data-inline="true" data-ajax="false" />
            <asp:Button ID="btnatras" CssClass="BotonesA" runat="server" Text="Atrás" 
            onclick="btnatras_Click" data-inline="true" data-ajax="false" data-theme="a" />
<%--<a href="#" class="EnviarC BotonesAE" data-role="button" data-inline="true">Contáctenos</a>
<a href="#" class="CancelarC BotonesA" data-role="button" data-inline="true" data-theme="a">Atrás</a>--%>
</div>
<%--<div id="FaceP" runat="server" class="addthis_toolbox addthis_default_style">
</div>--%>
</div>
</div>
</div>
</div>
</div>
</asp:Panel>
<asp:Panel ID="pOfertas" runat="server" Visible="false">
<div class="padding-s">
<div id="messages_product_view"></div>
<div class="product-view">
<div class="product-essential">
<div id="product_addtocart_form">
<div class="no-display">
<input type="hidden" name="product" value="27"/>
<input type="hidden" name="related_product" id="Hidden1" value=""/>
</div>
<%--auiq va imagenes --%>
<div class="product-shop">
<%--<div class="product-name category-title">
<h1 id="tituloOferta" runat="server"></h1>
</div>--%>
<div class="product-img-box">
<p id="Imagenes_ofertas" runat="server" class="product-image">
</p>
</div>
<div class="short-description">
<div id="descripcion_oferta" runat="server" class="std" style="text-align: justify"></div>
</div>
<div class="clear"></div>
<div class="add-to-box">
<span class="or">OR</span>
</div>
<%--<div id="FaceP" runat="server" class="addthis_toolbox addthis_default_style">
</div>--%>
</div>
</div>
</div>
</div>
</div>
</asp:Panel>
</div>
</div>
</div>
</div>
</div>
</div>
<!--aqui va la especifica de los productos-->
<div id="tema" runat="server"></div>
</div>
<%--<div class="footer-container-2">
	<div class="container">
		<div class="row">
			<div class="span12">
					<div class="footer footer2">
						<address>&copy; <script type="text/javascript">						                    var mdate = new Date(); document.write(mdate.getFullYear());</script> Com21 S.A. Todos los Derechos Reservados.</address>
												<!--{%FOOTER_LINK}-->						<div class="clear"></div>
					</div>
			</div>
		</div>
	</div>
</div>--%>
            </div>
</div>

<!--LIVEDEMO_00 -->
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-42436643-1']);
    _gaq.push(['_setDomainName', 'com21.com.ec']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>

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
