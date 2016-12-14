<%@ Page Language="C#" MasterPageFile="~/master/infoespecifica.master" AutoEventWireup="true" CodeFile="Copia (2) de Especifica.aspx.cs" Inherits="Especifica"  %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:HiddenField ID="hfIdentNSO" runat="server" />
<%--    <div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/es_LA/all.js#xfbml=1&appId=448140018617323";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>--%>
 <%--   <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
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
<div class="main-container col2-right-layout" style="box-shadow: 0px 0px 0px rgba(0,0,0,0.18); -moz-box-shadow: 0px 0px 0px rgba (0,0,0,0.18); -webkit-box-shadow: 0px 0px 0px rgba (0,0,0,0.18);">
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
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
<div class="product-shop">
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
<div class="page-title category-title">
<h1><asp:Label ID="lbltitulo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="FaceS" runat="server" style="margin-top: 10px;">
</div></h1>
</div> 
<div class="category-products">
<div id="DivImgS" runat="server">
    <asp:Image ID="img" runat="server" BorderColor="#ABCD43" BorderStyle="Solid" CssClass="BorderShadow" 
        BorderWidth="1.5px" />
</div>
<div id="servicios_web" runat="server">
</div>
</div>
</div>
</asp:Panel>
<asp:Panel ID="pNoti" runat="server" Visible="false">
<div class="padding-s">
<div class="page-title category-title">
<h1><asp:Label ID="lbltituloN" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="FaceN" runat="server" style="margin-top: 10px;">
</div></h1>
</div> 
<div class="category-products">
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
<strong><span>Twitter</span><span class="toggle"></span></strong>
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

<%--<script type="text/javascript">

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

    </script>--%>
</asp:Content>