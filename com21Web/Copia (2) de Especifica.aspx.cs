using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using com21DLL;
using System.Net;
using System.Net.Mail;

public partial class Especifica : System.Web.UI.Page
{
    public String[] DataC;

    private void ConsultaDataCompra(int id)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_cliente_DatosCompra(id, 1);
        String data = "";
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            //idusuario+T+ActE+FormaP+CodUpdatePre
            data = r[1] + "" + "|" + r[2] + "" + "|" + r[3] + "" + "|" + r[4] + "" + "|" + r[5] + "";
        }
        ViewState["DataCompra"] = data;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                // cargarHead();
                 cargarproducto();
                //cargarTags();
                //                cargarProdRe();

                string strUserAgent = Request.UserAgent.ToString().ToLower();

                #region "presentar style"
                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true ||
                            strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                            strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                    {
                        //cargarStyle(1, hfIdentNSO.Value);
                        //idizq.Visible = false;
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('mobile 1:"+ hfIdentNSO.Value+"');", true);
                    }
                    else
                    {
                        //cargarStyle(0, hfIdentNSO.Value);
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('web 0:" + hfIdentNSO.Value + "');", true);
                    }
                }
                #endregion


                if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
                {
                    ConsultaDataCompra(int.Parse(Request.Cookies["IdCom21Web"].Value));
                    //cargarInfoCarrito();
                    #region "OBTENER TIPO NAVAGACIÓN"


                    #endregion
                    pbtncarrito.Visible = true;
                }
                else
                {




                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('" + ex.Message + "');", true);
            }
        }
    }
    private void cargarStyle(int modile, string tipo)
    {
        switch (tipo)
        {
            case "N":
                if (modile == 1)
                {
                    Divimg.Attributes.Add("class", "DImgMobil");
                    Image5.Attributes.Add("CssClass", "ImgMobil");
                }
                else
                    Divimg.Attributes.Add("class", "DImgWeb");
                break;
            case "O":
                if (modile == 1)
                {
                    Divimg.Attributes.Add("class", "DImgMobil");
                    Image5.Attributes.Add("CssClass", "ImgMobil");
                }
                else
                    Divimg.Attributes.Add("class", "DImgWeb");
                break;
            case "S":
                if (modile == 1)
                {
                    DivImgS.Attributes.Add("class", "DImgMobil");
                    img.Attributes.Add("CssClass", "ImgMobil");
                }
                else
                    DivImgS.Attributes.Add("class", "DImgWeb");
                break;
        }
    }
    //private void cargarHead()
    //{
    //    String url = HttpContext.Current.Request.Url.Host;
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    if (Request.QueryString["T"] != null)
    //    {
    //        string tipo = Request.QueryString["T"].ToString();
    //        switch (tipo)
    //        {
    //            case "P":
    //                if (Request.QueryString["ID"] != null)
    //                {
    //                    String _idprod = Request.QueryString["ID"].ToString();
    //                    DataSet _product = _consulta.Com21_consulta_productos_id_Web(int.Parse(_idprod));
    //                    if (_product.Tables[0].Rows.Count > 0)
    //                    {
    //                        foreach (DataRow r in _product.Tables[0].Rows)
    //                        {
    //                            imgMeta.Content = url + r["Imagen"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = url + r["UrlProducto"].ToString();
    //                            linkUrl.Href = url + r["UrlProducto"].ToString();
    //                            descripcionMeta.Content = HttpUtility.HtmlDecode(r["Descripcion"].ToString());
    //                            Desp.Content = HttpUtility.HtmlDecode(r["Descripcion"].ToString());
    //                        }
    //                    }
    //                }
    //                break;
    //            case "S":
    //                if (Request.QueryString["ID"] != null)
    //                {
    //                    String _idprod = Request.QueryString["ID"].ToString();
    //                    DataSet _product = _consulta.Com21_consulta_servicios_id(int.Parse(_idprod));
    //                    if (_product.Tables[1].Rows.Count > 0)
    //                    {
    //                        foreach (DataRow r in _product.Tables[1].Rows)
    //                        {
    //                            imgMeta.Content = url + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = url + r["Url"].ToString();
    //                            linkUrl.Href = url + r["Url"].ToString();
    //                            descripcionMeta.Content = r["DescripcioCorta"].ToString();//HttpUtility.HtmlEncode(r["Descripcion"].ToString());
    //                            Desp.Content = HttpUtility.HtmlEncode(r["DescripcioCorta"].ToString());
    //                        }
    //                    }
    //                }
    //                break;
    //            case "N":
    //                if (Request.QueryString["ID"] != null)
    //                {
    //                    String _idprod = Request.QueryString["ID"].ToString();
    //                    DataSet _product = _consulta.Com21_consulta_noticias_id(int.Parse(_idprod));
    //                    if (_product.Tables[1].Rows.Count > 0)
    //                    {
    //                        foreach (DataRow r in _product.Tables[1].Rows)
    //                        {
    //                            imgMeta.Content = url + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = url + r["Url"].ToString();
    //                            linkUrl.Href = url + r["Url"].ToString();
    //                            descripcionMeta.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                            Desp.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                        }
    //                    }
    //                }
    //                break;
    //            case "F":
    //                if (Request.QueryString["ID"] != null)
    //                {
    //                    String _idprod = Request.QueryString["ID"].ToString();
    //                    DataSet _product = _consulta.Com21_consulta_noticias_id(int.Parse(_idprod));
    //                    if (_product.Tables[3].Rows.Count > 0)
    //                    {
    //                        foreach (DataRow r in _product.Tables[3].Rows)
    //                        {
    //                            imgMeta.Content = url + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = url + r["Url"].ToString();
    //                            linkUrl.Href = url + r["Url"].ToString();
    //                            descripcionMeta.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                            Desp.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                        }
    //                    }
    //                }
    //                break;
    //        }
    //    }
    //}
    //private void cargarInfoCarrito()
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    DataSet _det = _consulta.consulta_producto_prefacturado_id_user_cant_tot();
    //    if (_det.Tables[1].Rows.Count > 0)
    //    {
    //        foreach (DataRow r in _det.Tables[1].Rows)
    //        {
    //            if (!String.IsNullOrEmpty(r["Cantidad"] + ""))
    //                lblitemscarrito.Text = r["Cantidad"].ToString() + " item(s)";
    //            else
    //                lblitemscarrito.Text = "0 item(s)";
    //        }
    //    }
    //    else
    //    {
    //        lblitemscarrito.Text = "0 item(s)";
    //    }
    //    if (_det.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow r in _det.Tables[0].Rows)
    //        {
    //            if (!String.IsNullOrEmpty(r["Total"] + ""))
    //                lbltotalcarrito.Text = "$" + r["Total"] + "";
    //            else
    //                lbltotalcarrito.Text = "$0.00";
    //        }
    //    }
    //    else
    //    {
    //        lbltotalcarrito.Text = "$0.00";
    //    }
    //}
    private void cargarproducto()
    {
        String url = HttpContext.Current.Request.Url.Host;
        if (Request.QueryString["T"] != null)
        {
            string tipo = Request.QueryString["T"].ToString();
            switch (tipo)
            {
                case "P":
                    if (Request.QueryString["ID"] != null)
                    {
                        pPro.Visible = true;
                        String imgprod = "";
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        String _idprod = Request.QueryString["ID"].ToString();
                        DataSet _product = _consulta.Com21_consulta_productos_id_Web(int.Parse(_idprod));
                        if (_product.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r in _product.Tables[0].Rows)
                            {
                                //String _head = "<meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Imagen"].ToString() + "\"/><meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:url\" content=\"" + r["UrlProducto"].ToString() + "\"/><meta property=\"og:site_name\" content=\"http://designsie.com/\"/><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcioCorta"].ToString()) + "\"/><meta property=\"og:image:type\" content=\"image/jpg\" />" +
                                //"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><script type=\"text/javascript\">    var NREUMQ = NREUMQ || []; NREUMQ.push([\"mark\", \"firstbyte\", new Date().getTime()]);</script><title>" + r["Titulo"].ToString() + "</title><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\"><meta name=\"description\" content=\"Default Description\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/><meta name=\"robots\" content=\"INDEX,FOLLOW\"/><link rel=\"icon\" href=\"http://designsie.com/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                                //"<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                                //"<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                                //"<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]-->" +
                                //"<script type=\"text/javascript\">//<![CDATA[    var Translator = new Translate([]);        //]]></script><script type=\"text/javascript\" src=\"http://w.sharethis.com/button/buttons.js\"></script><script type=\"text/javascript\">stLight.options({publisher: \"6820c949-0f64-4774-aed9-9dee23904b79\", doNotHash: false, doNotCopy: false, hashAddressBar: false});</script>";                                
                                //cabecera_esp.InnerHtml = _head;

                                hfCantidadBD.Value = r["Cantidad"].ToString();
                                titulo.InnerText = r["Titulo"].ToString();
                                descripcion_corta.InnerText = r["DescripcioCorta"].ToString();
                                if (r["Cantidad"].ToString() != "0")
                                {
                                    Existe.InnerText = "En existencia";
                                }
                                else
                                {
                                    Existe.InnerText = "No en existencia";
                                }
                                if (r["Descuento"].ToString() != "0")
                                {
                                    precio_actual.InnerText = "Precio Normal: $" + r["Precio"].ToString();
                                    precio_actual.Attributes.Add("class", "PrecioEspecial");

                                    hfDescuento.Value = r["Descuento"].ToString();
                                    int _desc = int.Parse(r["Descuento"].ToString());
                                    Double _calcular = double.Parse(r["Precio"].ToString());
                                    Double _multi = ((_calcular * _desc) / 100);
                                    String _precioesp = Convert.ToString(_calcular - _multi);

                                    precio_especial.InnerText = "Precio Descuento: $" + _precioesp;
                                    hfprecio.Value = r["Precio"].ToString();
                                }
                                else
                                {
                                    hfDescuento.Value = r["Descuento"].ToString();
                                    precio_actual.InnerText = "Precio Normal: $" + r["Precio"].ToString();
                                    precio_actual.Attributes.Add("class", "NPrecioEspecial");
                                    hfprecio.Value = r["Precio"].ToString();
                                }
                                detalle.InnerHtml = HttpUtility.HtmlDecode(r["Descripcion"].ToString());
                                //String _titulo_dinamico = "http://com21.com.ec/" + GenerateURLProducto(r["Titulo"].ToString(), r["Id_Producto"].ToString(), r["Id_Categoria"].ToString(), r["Id_SubCategoria"].ToString(), "5");
                                FaceP.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["UrlProducto"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceP.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceP.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span>";
                                /*Imagenes_Productos.InnerHtml = "<script>jQuery(document).ready(function () {count = 0; jQuery('.iosSlider .slider #item').each(function () { count++; }); if (count < 4) { jQuery('.next, .prev').css({ 'display': 'none' }); } if (count > 3) {jQuery('.iosSlider').iosSlider({snapToChildren: true, desktopClickDrag: true, keyboardControls: true, onSliderLoaded: sliderTest, onSlideStart: sliderTest, onSlideComplete: slideComplete, navNextSelector: jQuery('.next'), navPrevSelector: jQuery('.prev')}); jQuery('.next, .prev').css({ 'display': 'block' });}}); function sliderTest(args) {try {console.log(args); } catch (err) { } } function slideComplete(args) { jQuery('.next, .prev').removeClass('unselectable'); if (args.currentSlideNumber == 1) {jQuery('.prev').addClass('unselectable'); } else if (args.currentSliderOffset == args.data.sliderMax) {jQuery('.next').addClass('unselectable');}}</script>"+
                                "<p class=\"product-image\"><a href='" + http://com21.com.ec/ + r["Imagen"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + http://com21.com.ec/ + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec/" + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a></p>";*/
                                String _puerto = Request.Url.Authority;
                                if (_puerto == "localhost:2304")
                                {
                                    imgprod = "<a href='" + "http://localhost:2304/com21Web/" + r["Imagen"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + "http://localhost:2304/com21Web/" + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + "http://localhost:2304/com21Web/" + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                                    Imagenes_Productos.InnerHtml = imgprod;
                                }
                                else
                                {

                                    imgprod = "<a href='" + url + "/" + r["Imagen"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + url + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + url + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                                    Imagenes_Productos.InnerHtml = imgprod;
                                }
                            }
                            if (_product.Tables[1].Rows.Count > 0)
                            {
                                String _imgcarga = "";
                                //String _puerto = Request.Url.Authority;
                                //int i = 1;
                                //if (_puerto == "localhost:2304")
                                //{
                                //    foreach (DataRow r in _product.Tables[1].Rows)
                                //    {
                                //        if (r["Ruta"].ToString() != "images/imagenes/icons_variados_theme_negro/64_image.png")
                                //        {

                                //            _imgcarga = _imgcarga + "<a href=\"http://localhost:2304/com21Web/" + r["Ruta"].ToString() + "\" class='cloud-zoom-gallery' title='' rel=\"useZoom: 'zoom1', smallImage: 'http://localhost:2304/com21Web/'" + r["Ruta"].ToString() + "' \"><img src=\"http://localhost:2304/com21Web/" + r["Ruta"].ToString() + "\" alt=\"\"/></a>";
                                //            string style = ubicacionImg(i,_imgcarga);
                                //            i = i + 1;
                                //            _imgcarga = "";
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    foreach (DataRow r in _product.Tables[1].Rows)
                                //    {
                                //        if (r["Ruta"].ToString() != "images/imagenes/icons_variados_theme_negro/64_image.png")
                                //        {
                                //            _imgcarga = _imgcarga + "<a href=\http://com21.com.ec/ + r["Ruta"].ToString() + "\" class='cloud-zoom-gallery' title='' rel=\"useZoom: 'zoom1', smallImage: 'http://designsie.com/'" + r["Ruta"].ToString() + "' \"><img src=\http://com21.com.ec/ + r["Ruta"].ToString() + "\" alt=\"\"/></a>";
                                //            string style = ubicacionImg(i, _imgcarga);
                                //            i = i + 1;
                                //            _imgcarga = "";
                                //        }
                                //    }
                                //}

                                //imagenes.InnerHtml = _imgcarga;
                            }

                        }
                    }
                    break;
                case "S":
                    if (Request.QueryString["ID"] != null)
                    {
                        pServ.Visible = true;
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        DataSet _serv = _consulta.Com21_consulta_servicios_id(int.Parse(Request.QueryString["ID"].ToString()));
                        if (_serv.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow r in _serv.Tables[1].Rows)
                            {
                                //String _head = "<meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Img"].ToString() + "\"/><meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:type\" content=\"servicios\" /><meta property=\"og:url\" content=\"" + r["Url"].ToString() + "\"/><meta property=\"og:site_name\" content=\"Com21 S.A :.\"/><meta property=\"og:image:type\" content=\"image/jpg\" /><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcioCorta"].ToString()) + "\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/>" +
                                //"<meta name=\"summary\" content=\"Com21 S.A.\" /><meta name=\"Generator\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Author\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Origen\" content=\"Com21\" /><meta name=\"Revisit\" content=\"7 days\" /><meta name=\"Locality\" content=\"Guayaquil, Ecuador\" /><meta name=\"author\" content=\"Software Design Intranet and Extranet\" /><meta name=\"Language\" content=\"es\" /><meta name=\"robots\" content=\"INDEX, FOLLOW, NOODP\" /><meta http-equiv=\"Content-Type\" content=\"text/html;charset=iso-8859-15\" /><meta name=\"alexaVerifyID\" content=\"lePEQIViFY7NjZkOJ2x7ma53hKs\" />" +
                                //"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><link rel=\"icon\" href=\"http://com21.com.ec/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                                //"<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                                //"<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                                //"<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"js/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"js/ie6.js\"></script><![endif]-->" +
                                //"<title>" + r["Titulo"].ToString() + "</title><script type=\"text/javascript\" src=\"http://w.sharethis.com/button/buttons.js\"></script><script type=\"text/javascript\">stLight.options({publisher: \"6820c949-0f64-4774-aed9-9dee23904b79\", doNotHash: false, doNotCopy: false, hashAddressBar: false});</script>";
                                //cabecera_esp.InnerHtml = _head;

                                lbltitulo.Text = r["Titulo"].ToString();
                                servicios_web.InnerHtml = r["Descripcion"].ToString();
                                img.ImageUrl = r["Img"].ToString();
                                hfIdentNSO.Value = "S";
                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Servicio"].ToString(), "0", "0", "S");
                                String urlsge = url + _titulo_dinamico;
                                String imagen = url + r["Img"].ToString();
                                String titulo = url + r["Titulo"].ToString();
                                FaceS.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceS.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceP.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                            }
                        }
                    }
                    break;
                case "N":
                    if (Request.QueryString["ID"] != null)
                    {
                        pNoti.Visible = true;
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        DataSet _serv = _consulta.Com21_consulta_noticias_id(int.Parse(Request.QueryString["ID"].ToString()));
                        if (_serv.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow r in _serv.Tables[1].Rows)
                            {
                                //String _head = "<meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Img"].ToString() + "\"/><meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:type\" content=\"servicios\" /><meta property=\"og:url\" content=\"" + r["Url"].ToString() + "\"/><meta property=\"og:site_name\" content=\"Com21 S.A :.\"/><meta property=\"og:image:type\" content=\"image/jpg\" /><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString()) + "\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/>" +
                                //"<meta name=\"summary\" content=\"Com21 S.A.\" /><meta name=\"Generator\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Author\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Origen\" content=\"Com21\" /><meta name=\"Revisit\" content=\"7 days\" /><meta name=\"Locality\" content=\"Guayaquil, Ecuador\" /><meta name=\"author\" content=\"Software Design Intranet and Extranet\" /><meta name=\"Language\" content=\"es\" /><meta name=\"robots\" content=\"INDEX, FOLLOW, NOODP\" /><meta http-equiv=\"Content-Type\" content=\"text/html;charset=iso-8859-15\" /><meta name=\"alexaVerifyID\" content=\"lePEQIViFY7NjZkOJ2x7ma53hKs\" />" +
                                //"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><link rel=\"icon\" href=\"http://com21.com.ec/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                                //"<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                                //"<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                                //"<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"js/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"js/ie6.js\"></script><![endif]-->" +
                                //"<title>" + r["Titulo"].ToString() + "</title><script type=\"text/javascript\" src=\"http://w.sharethis.com/button/buttons.js\"></script><script type=\"text/javascript\">stLight.options({publisher: \"6820c949-0f64-4774-aed9-9dee23904b79\", doNotHash: false, doNotCopy: false, hashAddressBar: false});</script>";
                                //cabecera_esp.InnerHtml = _head;

                                lbltituloN.Text = r["Titulo"].ToString();
                                noticias_web.InnerHtml = r["Descripcion"].ToString();
                                Image5.ImageUrl = r["Img"].ToString();
                                hfIdentNSO.Value = "N";

                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "0", "0", "N");
                                FaceN.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceN.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceN.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                            }
                        }
                    }
                    break;
                case "F":
                    if (Request.QueryString["ID"] != null)
                    {
                        pNoti.Visible = true;
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        DataSet _serv = _consulta.Com21_consulta_noticias_id(int.Parse(Request.QueryString["ID"].ToString()));
                        if (_serv.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow r in _serv.Tables[3].Rows)
                            {
                                //String _head = "<meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Img"].ToString() + "\"/><meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:type\" content=\"servicios\" /><meta property=\"og:url\" content=\"" + r["Url"].ToString() + "\"/><meta property=\"og:site_name\" content=\"Com21 S.A :.\"/><meta property=\"og:image:type\" content=\"image/jpg\" /><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString()) + "\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/>" +
                                //"<meta name=\"summary\" content=\"Com21 S.A.\" /><meta name=\"Generator\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Author\" content=\"Software Design Intranet and Extranet.\" /><meta name=\"Origen\" content=\"Com21\" /><meta name=\"Revisit\" content=\"7 days\" /><meta name=\"Locality\" content=\"Guayaquil, Ecuador\" /><meta name=\"author\" content=\"Software Design Intranet and Extranet\" /><meta name=\"Language\" content=\"es\" /><meta name=\"robots\" content=\"INDEX, FOLLOW, NOODP\" /><meta http-equiv=\"Content-Type\" content=\"text/html;charset=iso-8859-15\" /><meta name=\"alexaVerifyID\" content=\"lePEQIViFY7NjZkOJ2x7ma53hKs\" />" +
                                //"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><link rel=\"icon\" href=\"http://com21.com.ec/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                                //"<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                                //"<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                                //"<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"js/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"js/ie6.js\"></script><![endif]-->" +
                                //"<title>" + r["Titulo"].ToString() + "</title><script type=\"text/javascript\" src=\"http://w.sharethis.com/button/buttons.js\"></script><script type=\"text/javascript\">stLight.options({publisher: \"6820c949-0f64-4774-aed9-9dee23904b79\", doNotHash: false, doNotCopy: false, hashAddressBar: false});</script>";
                                //cabecera_esp.InnerHtml = _head;

                                lbltituloN.Text = r["Titulo"].ToString();
                                noticias_web.InnerHtml = r["Descripcion"].ToString();
                                Image5.ImageUrl = r["Img"].ToString();
                                hfIdentNSO.Value = "O";

                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "0", "0", "N");
                                FaceN.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceN.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceN.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                            }
                        }
                    }
                    break;
            }
        }
    }
    private void cargarProdRe()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        int cat = int.Parse(Request.QueryString["Cat"].ToString());
        int subcat = int.Parse(Request.QueryString["Sub"].ToString());
        int id = int.Parse(Request.QueryString["ID"].ToString());
        DataSet _ds = _consulta.Com21_consulta_productos_relacionados(id, cat, subcat);
        int i = 0;
        String _product = "";
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[0].Rows)
            {
                if ((i >= 0) && (i < 2))
                {
                    _product = _product + "<li class=\"item\">";
                }
                else
                {
                    _product = _product + "<li class=\"item last\">";
                }
                _product = _product + "<div class=\"product-box\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" width=\"184\" height=\"184\" alt=\"" + r["Titulo"].ToString() + "\"/></a>" +
                    "<h3 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h3>" +
                    "<div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-26-upsell\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                i = i + 1;
            }
            produt_re.InnerHtml = _product;
        }
    }
    //private string ubicacionImg(int i, string html)
    //{
    //    String style = "";
    //    switch (i)
    //    {
    //        case 1:
    //            img1.InnerHtml = html;
    //            break;
    //        case 2:
    //            img2.InnerHtml = html;
    //            break;
    //        case 3:
    //            //img3.InnerHtml = html;
    //            a3.Attributes.Add("href","http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/f/i/file_29.jpg");
    //            a3.Attributes.Add("class","cloud-zoom-gallery");
    //            a3.Attributes.Add("title","");
    //            a3.Attributes.Add("rel","useZoom: 'zoom1', smallImage: 'http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/image/308x308/9df78eab33525d08d6e5fb8d27136e95/f/i/file_29.jpg'");
    //            break;
    //        case 4:
    //            //img4.InnerHtml = html;
    //            a4.Attributes.Add("href", "'http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/f/i/file_3_9.jpg' class='cloud-zoom-gallery' title='' rel='useZoom: 'zoom1', smallImage: 'http://livedemo00.template-help.com/magento_42968/media/catalog/product/cache/1/image/308x308/9df78eab33525d08d6e5fb8d27136e95/f/i/file_3_9.jpg''");
    //            break;
    //    }
    //    return style;
    //}
    public static string GenerateURLProducto(object Title, object strId, object strCat, object strSub, object strTipo)
    {

        string strTitle = Title.ToString();

        #region Generate SEO Friendly URL based on Title
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');

        strTitle = strTitle.ToLower();
        char[] chars = @"$%#@!*?;:´~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        strTitle = strTitle.Replace("c#", "C-Sharp");
        strTitle = strTitle.Replace("vb.net", "VB-Net");
        strTitle = strTitle.Replace("asp.net", "Asp-Net");
        strTitle = strTitle.Replace("á", "a");
        strTitle = strTitle.Replace("é", "e");
        strTitle = strTitle.Replace("í", "i");
        strTitle = strTitle.Replace("ó", "o");
        strTitle = strTitle.Replace("ú", "u");
        strTitle = strTitle.Replace("Á", "A");
        strTitle = strTitle.Replace("É", "E");
        strTitle = strTitle.Replace("Í", "I");
        strTitle = strTitle.Replace("Ó", "O");
        strTitle = strTitle.Replace("Ú", "U");
        strTitle = strTitle.Replace("ç", "c");
        strTitle = strTitle.Replace("Ç", "C");
        strTitle = strTitle.Replace("Ä", "A");
        strTitle = strTitle.Replace("Ë", "E");
        strTitle = strTitle.Replace("Ï", "I");
        strTitle = strTitle.Replace("Ö", "O");
        strTitle = strTitle.Replace("Ü", "U");
        strTitle = strTitle.Replace("ä", "a");
        strTitle = strTitle.Replace("ë", "e");
        strTitle = strTitle.Replace("ï", "i");
        strTitle = strTitle.Replace("ö", "o");
        strTitle = strTitle.Replace("ü", "u");

        //Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
                strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("-----", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');


        #endregion

        //Append ID at the end of SEO Friendly URL
        strTitle = "" + strTitle + "-" + strId + "-" + strCat + "-" + strSub + "-" + strTipo + ".aspx";

        return strTitle;
    }
    public static string RemoverSignosAcentos(object texto)
    {
        string texto2 = texto.ToString();
        var textoSinAcentos = string.Empty;

        foreach (var caracter in texto2)
        {
            var indexConAcento = ConSignos.IndexOf(caracter);
            if (indexConAcento > -1)
                textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
            else
                textoSinAcentos = textoSinAcentos + (caracter);
        }
        return textoSinAcentos;
    }
    private const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
    private const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
    private void cargarTags()
    {
        String ul = "<ul class=\"tags-list\">";
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _tags = _consulta.Com21_consulta_tags_marca_categorias_sub();
        int i = 1;
        if (_tags.Tables[0].Rows.Count > 0 || _tags.Tables[1].Rows.Count > 0)
        {
            //foreach(DataRow r in _tags.Tables[0].Rows)
            //{
            //    string _size = cargarTama(i);
            //    ul = ul + "<li><a href=\"servicio.aspx?IM=" + r["Id_Marca"].ToString() + "&IC=0&IS=0" + "\" style=\"font-size:" + _size + ";\">" + r["Marca"].ToString() + "</a></li>";
            //    //ul = ul + "<li><a href=\"cargarconsulta.aspx?IM=" + r["Id_Marca"].ToString() + "&IC=0&IS=0" + "\" style=\"font-size:" + _size + ";\">" + r["Marca"].ToString() + "</a></li>";
            //    i = i + 1;
            //}
            foreach (DataRow r in _tags.Tables[1].Rows)
            {
                string _size = cargarTama(i);
                ul = ul + "<li><a href=\"productos.aspx?Cat=" + r["Id_Categoria"].ToString() + "&Sub=" + r["Id_SubCategoria"].ToString() + "\" style=\"font-size:" + _size + ";\">" + r["Titulo"].ToString() + "</a></li>";
                //ul = ul + "<li><a href=\"cargarconsulta.aspx?IM=0" + "&IC=" + r["Id_Categoria"].ToString() + "&IS=" + r["Id_SubCategoria"].ToString() + "\" style=\"font-size:" + _size + ";\">" + r["Titulo"].ToString() + "</a></li>";
                i = i + 1;
            }
            tags_mezclados.InnerHtml = ul;
        }
    }
    private string cargarTama(int i)
    {
        String _tama = "";
        switch (i)
        {
            case 1:
                _tama = "121.66666666667%";
                break;
            case 2:
                _tama = "110%";
                break;
            case 3:
                _tama = "75%";
                break;
            case 4:
                _tama = "110%";
                break;
            case 5:
                _tama = "98.333333333333%";
                break;
            case 6:
                _tama = "133.33333333333%";
                break;
            case 7:
                _tama = "133.33333333333%";
                break;
            case 8:
                _tama = "110%";
                break;
            case 9:
                _tama = "121.66666666667%";
                break;
            case 10:
                _tama = "110%";
                break;
            case 11:
                _tama = "98.333333333333%";
                break;
            case 12:
                _tama = "98.333333333333%";
                break;
            case 13:
                _tama = "110%";
                break;
            case 14:
                _tama = "133.33333333333%";
                break;
            case 15:
                _tama = "121.66666666667%";
                break;
            case 16:
                _tama = "145%";
                break;
            case 17:
                _tama = "121.66666666667%";
                break;
        }
        return _tama;
    }
    protected void btnagregar_Click(object sender, EventArgs e)
    {
        if (txtcantidad.Text.Length > 0)
        {
            ingresarPrefactura();
        }
        else
        {
            lblnosi.Text = "Digite un cantidad mayor a 0";
        }
    }
    private void ingresarPrefactura()
    {
        consultaCantidadExistente();
        if (int.Parse(txtcantidad.Text) <= int.Parse(hfCantidadBD.Value))
        {
            DataSet _rep = consultaProductoExistente();
            if (_rep.Tables[0].Rows.Count == 0)
            {
                String _idprod = Request.QueryString["ID"].ToString();
                string _iduser = Request.Cookies["IdCom21Web"].Value;
                XmlDocument _xmlDatos = new XmlDocument();
                _xmlDatos.LoadXml("<Prefactura/>");
                _xmlDatos.DocumentElement.SetAttribute("IdProducto", _idprod);
                _xmlDatos.DocumentElement.SetAttribute("IdUsuario", _iduser);
                _xmlDatos.DocumentElement.SetAttribute("Cantidad", txtcantidad.Text);
                _xmlDatos.DocumentElement.SetAttribute("Precio", hfprecio.Value.Replace(",", "."));
                Double _total = int.Parse(txtcantidad.Text) * double.Parse(hfprecio.Value);
                _xmlDatos.DocumentElement.SetAttribute("Total", _total.ToString().Replace(",", "."));
                _xmlDatos.DocumentElement.SetAttribute("Facturado", "0");
                _xmlDatos.DocumentElement.SetAttribute("IdEstado", "1");
                if (hfDescuento.Value != "0")
                {
                    int _desc = int.Parse(hfDescuento.Value);
                    decimal _calcular = decimal.Parse(hfprecio.Value);
                    decimal _multi = ((_calcular * _desc) / 100);
                    String _precioesp = Convert.ToString(_multi * int.Parse(txtcantidad.Text));
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", _precioesp.Replace(",", "."));
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", "0");
                }
                _xmlDatos.DocumentElement.SetAttribute("TransAutori", "0");

                /*if (Request.Cookies["CodUpdatePre"] != null)
                {
                    _xmlDatos.DocumentElement.SetAttribute("CodUpdate", Request.Cookies["CodUpdatePre"].Value);
                }
                else
                {
                    classRandom _rand = new classRandom();
                    String _cod = _rand.NextString(11, true, true, true, false);
                    _xmlDatos.DocumentElement.SetAttribute("CodUpdate", _cod);
                }*/
                String data = ViewState["DataCompra"] + "";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {
                    _xmlDatos.DocumentElement.SetAttribute("CodUpdate", DataC[4] + "");
                }

                ServicioCom21.ServicioCom21 _enviar = new ServicioCom21.ServicioCom21();
                if (_enviar.proc_ingresa_prefactura(_xmlDatos.OuterXml))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    XmlDocument _xmlDatoscant = new XmlDocument();
                    _xmlDatoscant.LoadXml("<Ad_Productos/>");
                    string can = Convert.ToString(int.Parse(hfCantidadBD.Value) - int.Parse(txtcantidad.Text));
                    _xmlDatoscant.DocumentElement.SetAttribute("Cantidad", can);

                    if (_enviar.Com21_edita_productos_cantidad_restar(_xmlDatoscant.OuterXml, int.Parse(_idprod)))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        limpiar();
                        //cargarInfoCarrito();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto agregado con exito');", true);
                    }
                }
            }
            else
            {
                String _idprod = Request.QueryString["ID"].ToString();
                string _iduser = Request.Cookies["IdCom21Web"].Value;
                string cant = "";
                foreach (DataRow r in _rep.Tables[0].Rows)
                {
                    cant = r["Cantidad"].ToString();
                }

                XmlDocument _xmlDatos = new XmlDocument();
                _xmlDatos.LoadXml("<Prefactura/>");
                int cants = int.Parse(cant) + int.Parse(txtcantidad.Text);
                _xmlDatos.DocumentElement.SetAttribute("Cantidad", Convert.ToString(cants));
                _xmlDatos.DocumentElement.SetAttribute("Precio", hfprecio.Value.Replace(",", "."));
                Double _total = cants * double.Parse(hfprecio.Value);
                _xmlDatos.DocumentElement.SetAttribute("Total", _total.ToString().Replace(",", "."));
                if (hfDescuento.Value != "0")
                {
                    int _desc = int.Parse(hfDescuento.Value);
                    decimal _calcular = decimal.Parse(hfprecio.Value);
                    decimal _multi = ((_calcular * _desc) / 100);
                    String _precioesp = Convert.ToString(_multi * cants);
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", _precioesp.Replace(",", "."));
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", "0");
                }

                ServicioCom21.ServicioCom21 _enviar = new ServicioCom21.ServicioCom21();
                if (_enviar.proc_actualiza_producto_repetido(_xmlDatos.OuterXml, int.Parse(_iduser), int.Parse(_idprod), ""))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    XmlDocument _xmlDatoscant = new XmlDocument();
                    _xmlDatoscant.LoadXml("<Ad_Productos/>");
                    string can = Convert.ToString(int.Parse(hfCantidadBD.Value) - int.Parse(txtcantidad.Text));
                    _xmlDatoscant.DocumentElement.SetAttribute("Cantidad", can);

                    if (_enviar.Com21_edita_productos_cantidad_restar(_xmlDatoscant.OuterXml, int.Parse(_idprod)))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        limpiar();
                        // cargarInfoCarrito();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto agregado con exito');", true);
                    }
                }
            }
        }
        else
        {
            lblnosi.Text = "Cantidad máxima para comprar es: " + hfCantidadBD.Value;
            enviarcorreo();
        }
    }
    private void consultaCantidadExistente()
    {
        String _idprod = Request.QueryString["ID"].ToString();
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _cant = _consulta.Com21_consulta_productos_cantidad_id(int.Parse(_idprod));
        if (_cant.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _cant.Tables[0].Rows)
            {
                hfCantidadBD.Value = r["Cantidad"].ToString();
            }
        }
        else
        {
            lblnosi.Text = "Stock no disponible";
            btnagregar.Visible = false;
            txtcantidad.Visible = false;
        }
    }
    private DataSet consultaProductoExistente()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String _idprod = Request.QueryString["ID"].ToString();
        string _iduser = Request.Cookies["IdCom21Web"].Value;
        DataSet _rep = _consulta.consulta_producto_repetido(int.Parse(_iduser), int.Parse(_idprod));
        return _rep;
    }
    private void limpiar()
    {
        txtcantidad.Text = "";
    }
    #region "BUSCAR"
    /*protected void btnbuscar1_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search1.Text);
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search.Text);
    }*/
    #endregion
    private void enviarcorreo()
    {
        try
        {
            MailMessage objMail = new MailMessage();
            objMail.IsBodyHtml = false;
            objMail.From = new MailAddress("info@com21.com.ec");
            objMail.To.Add("so_cardenas@hotmail.com");
            //objMail.To.Add("rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec");
            objMail.Subject = "Información de Compra";
            String user = Request.Cookies["IdCom21Web"].Value;
            objMail.Body = "Han intentado comprar más del stock disponible del producto: " + titulo.InnerText;

            //con puerto
            //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
            //objSMTPClient.EnableSsl = true;
            //objSMTPClient.UseDefaultCredentials = false;
            //objSMTPClient.Credentials = new NetworkCredential("steven.cardenas@bonsai.com.ec", "Steven!2012");
            //fin con puertos

            //sin puertos
            SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //fin de sin puertos

            objSMTPClient.Send(objMail);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Su solicitud no fue enviada.');", true);
        }
    }
}