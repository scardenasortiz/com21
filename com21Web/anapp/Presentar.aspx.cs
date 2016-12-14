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

public partial class Presentar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarXML();
            //cargarHead();
            //cargarproducto();
            //string strUserAgent = Request.UserAgent.ToString().ToLower();

            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                //cargarInfoCarrito();

                pbtncarrito.Visible = true;
            }
            //else
            //{
            //}
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if (Request.QueryString["T"] != null)
        {
            string tipo = Request.QueryString["T"].ToString();
            switch (tipo)
            {
                case "O":
                    if (Request.QueryString["ID"] != null)
                    {
                        String Ofer = Request.QueryString["ID"] + "";
                        DataSet _dsO = _consulta.Com21_consulta_noticias_id(int.Parse(Ofer));
                        if (_dsO.Tables[3].Rows.Count > 0)
                        {
                            ViewState["ds"] = _dsO.Tables[3];
                            ofertas();
                        }
                    }
                    break;
                case "S":
                    if (Request.QueryString["ID"] != null)
                    {
                        String Ser = Request.QueryString["ID"] + "";
                        DataSet _dsS = _consulta.Com21_consulta_servicios_id(int.Parse(Ser));
                        if (_dsS.Tables[1].Rows.Count > 0)
                        {
                            ViewState["ds"] = _dsS.Tables[1];
                            servicios();
                        }
                    }
                    break;
                case "P":
                    if (Request.QueryString["ID"] != null)
                    {
                        String pro = Request.QueryString["ID"] + "";
                        DataSet _dsP = _consulta.Com21_consulta_productos_id_Web(int.Parse(pro));
                        if (_dsP.Tables[0].Rows.Count > 0)
                        {
                            ViewState["ds"] = _dsP.Tables[0];
                            productos();
                        }
                    }
                    break;
                case "IP":
                    if (Request.QueryString["ID"] != null)
                    {
                        String pro = Request.QueryString["ID"] + "";
                        DataSet _dsIP = (DataSet)Session["dtportada"];
                        try
                        {
                            DataTable _dtIP = _dsIP.Tables[0].Select("Id_Producto = " + int.Parse(pro)).CopyToDataTable();
                            //DataSet _dsIP = _consulta.Com21_consulta_productos_id_Web(int.Parse(pro));
                            //if (_dsIP.Tables[0].Rows.Count > 0)
                            //{
                            //    ViewState["ds"] = _dsIP.Tables[0];
                            //    inicialP();
                            //}
                            if (_dtIP.Rows.Count > 0)
                            {
                                //ViewState["ds"] = _dsIP.Tables[0];
                                inicialP(_dtIP);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    break;
                case "IS":
                    if (Request.QueryString["ID"] != null)
                    {
                        String Ser = Request.QueryString["ID"] + "";
                        DataSet _dsIS = _consulta.Com21_consulta_servicios_id(int.Parse(Ser));
                        if (_dsIS.Tables[1].Rows.Count > 0)
                        {
                            ViewState["ds"] = _dsIS.Tables[1];
                            inicialS();
                        }
                    }
                    break;
                case "IO":
                    if (Request.QueryString["ID"] != null)
                    {
                        String IOfer = Request.QueryString["ID"] + "";
                        DataSet _dsIO = _consulta.Com21_consulta_noticias_id(int.Parse(IOfer));
                        if (_dsIO.Tables[3].Rows.Count > 0)
                        {
                            ViewState["ds"] = _dsIO.Tables[3];
                            inicialO();
                        }
                    }
                    break;
            }
        }
    }
    private void cargarXML()
    {
        if (Request.QueryString["T"] != null)
        {
            string tipo = Request.QueryString["T"].ToString();
            switch (tipo)
            {
                case "O":
                    ofertas();
                    break;
                case "S":
                    servicios();
                    break;
                case "P":
                    productos();
                    break;
                case "IP":
                    //inicialP();
                    break;
                case "IS":
                    inicialS();
                    break;
                case "IO":
                    inicialO();
                    break;
            }
        }
    }
    #region "cabecera comentada"
    //private void cargarHead()
    //{
        
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    if (Request.QueryString["T"] != null)
    //    {
    //        string tipo = Request.QueryString["T"].ToString();
    //        switch (tipo)
    //        {
    //            case "P":
    //                if (Request.QueryString["ID"] != null)
    //                {
    //                    pPro.Visible = true;
    //                    String _archivo = Server.MapPath("productos.xml");
    //                    XmlDocument _datas = new XmlDocument();
    //                    _datas.Load(_archivo);

    //                    XmlNodeList ListProducto = _datas.GetElementsByTagName("Producto");
    //                    foreach (XmlNode nodeproducto in ListProducto)
    //                    {
    //                        XmlElement Xmlproducto = (XmlElement)nodeproducto;
    //                        if (Xmlproducto.SelectSingleNode("Id").InnerText == Request.QueryString["ID"].ToString())
    //                        {
    //                            imgMeta.Content = "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText;
    //                            titleMeta.Content = Xmlproducto.SelectSingleNode("Titulo").InnerText;
    //                            titlePage.Text = Xmlproducto.SelectSingleNode("Titulo").InnerText;
    //                            urlMeta.Content = "http://com21.com.ec/" + Xmlproducto.SelectSingleNode("Url").InnerText;
    //                            linkUrl.Href = "http://com21.com.ec/" + Xmlproducto.SelectSingleNode("Url").InnerText;
    //                            descripcionMeta.Content = HttpUtility.HtmlEncode(Xmlproducto.SelectSingleNode("Descripcion").InnerText);
    //                            Desp.Content = HttpUtility.HtmlEncode(Xmlproducto.SelectSingleNode("Descripcion").InnerText);

    //                            hfCantidadBD.Value = Xmlproducto.SelectSingleNode("Cantidad").InnerText;
    //                            titulo.InnerText = Xmlproducto.SelectSingleNode("Titulo").InnerText;
    //                            descripcion_corta.InnerText = Xmlproducto.SelectSingleNode("Descripcion").InnerText;
    //                            if (Xmlproducto.SelectSingleNode("Cantidad").InnerText != "0")
    //                            {
    //                                Existe.InnerText = "En existencia";
    //                            }
    //                            else
    //                            {
    //                                Existe.InnerText = "No en existencia";
    //                            }
    //                            if (Xmlproducto.SelectSingleNode("Descuento").InnerText != "0")
    //                            {
    //                                precio_actual.InnerText = "Precio Normal: $" + Xmlproducto.SelectSingleNode("Precio").InnerText;
    //                                precio_actual.Attributes.Add("class", "PrecioEspecial");

    //                                hfDescuento.Value = Xmlproducto.SelectSingleNode("Descuento").InnerText;
    //                                int _desc = int.Parse(Xmlproducto.SelectSingleNode("Descuento").InnerText);
    //                                Double _calcular = double.Parse(Xmlproducto.SelectSingleNode("Precio").InnerText);
    //                                Double _multi = ((_calcular * _desc) / 100);
    //                                String _precioesp = Convert.ToString(_calcular - _multi);

    //                                precio_especial.InnerText = "Precio Descuento: $" + _precioesp;
    //                                hfprecio.Value = Xmlproducto.SelectSingleNode("Precio").InnerText;
    //                            }
    //                            else
    //                            {
    //                                hfDescuento.Value = Xmlproducto.SelectSingleNode("Descuento").InnerText;
    //                                precio_actual.InnerText = "Precio Normal: $" + Xmlproducto.SelectSingleNode("Precio").InnerText;
    //                                precio_actual.Attributes.Add("class", "NPrecioEspecial");
    //                                hfprecio.Value = Xmlproducto.SelectSingleNode("Precio").InnerText;
    //                            }
    //                            //FaceP.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + Xmlproducto.SelectSingleNode("Url").InnerText + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
    //                            String _puerto = Request.Url.Authority;
    //                            String imgprod = "";
    //                            if (_puerto == "localhost:2304")
    //                            {
    //                                imgprod = "<a href='" + "http://localhost:2304/com21Web" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlproducto.SelectSingleNode("Titulo").InnerText + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlproducto.SelectSingleNode("Titulo").InnerText + "\" style=\"width: 307px; height: 308px;\"/></a>";
    //                                Imagenes_Productos.InnerHtml = imgprod;
    //                            }
    //                            else
    //                            {
    //                                imgprod = "<a href='" + "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlproducto.SelectSingleNode("Titulo").InnerText + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec" + Xmlproducto.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlproducto.SelectSingleNode("Titulo").InnerText + "\" style=\"width: 307px; height: 308px;\"/></a>";
    //                                Imagenes_Productos.InnerHtml = imgprod;
    //                            }
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
    //                            imgMeta.Content = "http://com21.com.ec/" + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = "http://com21.com.ec/" + r["Url"].ToString();
    //                            linkUrl.Href = "http://com21.com.ec/" + r["Url"].ToString();
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
    //                            imgMeta.Content = "http://com21.com.ec/" + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = "http://com21.com.ec/" + r["Url"].ToString();
    //                            linkUrl.Href = "http://com21.com.ec/" + r["Url"].ToString();
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
    //                            imgMeta.Content = "http://com21.com.ec/" + r["Img"].ToString();
    //                            titleMeta.Content = r["Titulo"].ToString();
    //                            titlePage.Text = r["Titulo"].ToString();
    //                            urlMeta.Content = "http://com21.com.ec/" + r["Url"].ToString();
    //                            linkUrl.Href = "http://com21.com.ec/" + r["Url"].ToString();
    //                            descripcionMeta.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                            Desp.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                        }
    //                    }
    //                }
    //                break;
    //        }
    //    }
    //}
    #endregion
    private void cargarInfoCarrito()
    {
        //ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        //DataSet _det = _consulta.consulta_producto_prefacturado_id_user_cant_tot();
        //if ((_det.Tables[1].Rows.Count > 0) && (_det.Tables[0].Rows.Count > 0))
        //{
        //    foreach (DataRow r in _det.Tables[1].Rows)
        //    {
        //        lblitemscarrito.Text = r["Cantidad"].ToString() + " item(s)";
        //    }
        //    foreach (DataRow r in _det.Tables[0].Rows)
        //    {
        //        lbltotalcarrito.Text = "$" + r["Total"].ToString();
        //    }
        //}
        //else
        //{
        //    lblitemscarrito.Text = "0 item(s)";
        //    lbltotalcarrito.Text = "$0.00";
        //}
    }
    private void cargarproducto()
    {
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
                        if ((Request.QueryString["Ruta"] != null) && (Request.QueryString["Titulo"] != null) && (Request.QueryString["Descripcion"] != null) && (Request.QueryString["Descuento"] != null) && (Request.QueryString["Precio"] != null) && (Request.QueryString["Cantidad"] != null) && (Request.QueryString["Fecha"] != null))
                        {
                            //String _head = "<meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Imagen"].ToString() + "\"/><meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:url\" content=\"" + r["UrlProducto"].ToString() + "\"/><meta property=\"og:site_name\" content=\"http://designsie.com/\"/><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcioCorta"].ToString()) + "\"/><meta property=\"og:image:type\" content=\"image/jpg\" />" +
                            //"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><script type=\"text/javascript\">    var NREUMQ = NREUMQ || []; NREUMQ.push([\"mark\", \"firstbyte\", new Date().getTime()]);</script><title>" + r["Titulo"].ToString() + "</title><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\"><meta name=\"description\" content=\"Default Description\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/><meta name=\"robots\" content=\"INDEX,FOLLOW\"/><link rel=\"icon\" href=\"http://designsie.com/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                            //"<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                            //"<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                            //"<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]-->" +
                            //"<script type=\"text/javascript\">//<![CDATA[    var Translator = new Translate([]);        //]]></script><script type=\"text/javascript\" src=\"http://w.sharethis.com/button/buttons.js\"></script><script type=\"text/javascript\">stLight.options({publisher: \"6820c949-0f64-4774-aed9-9dee23904b79\", doNotHash: false, doNotCopy: false, hashAddressBar: false});</script>";                                
                            //cabecera_esp.InnerHtml = _head;

                            hfCantidadBD.Value = Request.QueryString["Cantidad"].ToString();
                            titulo.InnerText = Request.QueryString["Titulo"].ToString();
                            descripcion_corta.InnerText = Request.QueryString["DescripcioCorta"].ToString();
                            if (Request.QueryString["Cantidad"].ToString() != "0")
                            {
                                Existe.InnerText = "En existencia";
                            }
                            else
                            {
                                Existe.InnerText = "No en existencia";
                            }
                            if (Request.QueryString["Descuento"].ToString() != "0")
                            {
                                precio_actual.InnerText = "Precio Normal: $" + Request.QueryString["Precio"].ToString();
                                precio_actual.Attributes.Add("class", "PrecioEspecial");

                                hfDescuento.Value = Request.QueryString["Descuento"].ToString();
                                int _desc = int.Parse(Request.QueryString["Descuento"].ToString());
                                Double _calcular = double.Parse(Request.QueryString["Precio"].ToString());
                                Double _multi = ((_calcular * _desc) / 100);
                                String _precioesp = Convert.ToString(_calcular - _multi);

                                precio_especial.InnerText = "Precio Descuento: $" + _precioesp;
                                hfprecio.Value = Request.QueryString["Precio"].ToString();
                            }
                            else
                            {
                                hfDescuento.Value = Request.QueryString["Descuento"].ToString();
                                precio_actual.InnerText = "Precio Normal: $" + Request.QueryString["Precio"].ToString();
                                precio_actual.Attributes.Add("class", "NPrecioEspecial");
                                hfprecio.Value = Request.QueryString["Precio"].ToString();
                            }
                            //detalle.InnerHtml = HttpUtility.HtmlDecode(r["Descripcion"].ToString());
                            //String _titulo_dinamico = "http://com21.com.ec/" + GenerateURLProducto(r["Titulo"].ToString(), r["Id_Producto"].ToString(), r["Id_Categoria"].ToString(), r["Id_SubCategoria"].ToString(), "5");
                            //FaceP.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + Request.QueryString["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                            //FaceP.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                            //FaceP.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span>";
                            /*Imagenes_Productos.InnerHtml = "<script>jQuery(document).ready(function () {count = 0; jQuery('.iosSlider .slider #item').each(function () { count++; }); if (count < 4) { jQuery('.next, .prev').css({ 'display': 'none' }); } if (count > 3) {jQuery('.iosSlider').iosSlider({snapToChildren: true, desktopClickDrag: true, keyboardControls: true, onSliderLoaded: sliderTest, onSlideStart: sliderTest, onSlideComplete: slideComplete, navNextSelector: jQuery('.next'), navPrevSelector: jQuery('.prev')}); jQuery('.next, .prev').css({ 'display': 'block' });}}); function sliderTest(args) {try {console.log(args); } catch (err) { } } function slideComplete(args) { jQuery('.next, .prev').removeClass('unselectable'); if (args.currentSlideNumber == 1) {jQuery('.prev').addClass('unselectable'); } else if (args.currentSliderOffset == args.data.sliderMax) {jQuery('.next').addClass('unselectable');}}</script>"+
                            "<p class=\"product-image\"><a href='" + http://com21.com.ec/ + r["Imagen"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + http://com21.com.ec/ + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec/" + r["Imagen"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a></p>";*/
                            String _puerto = Request.Url.Authority;
                            if (_puerto == "localhost:2304")
                            {
                                imgprod = "<a href='" + "http://localhost:2304/com21Web/" + Request.QueryString["Ruta"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + "http://com21.com.ec/" + Request.QueryString["Ruta"].ToString() + "\" alt='' title=\"" + Request.QueryString["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec/" + Request.QueryString["Ruta"].ToString() + "\" alt='' title=\"" + Request.QueryString["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                                Imagenes_Productos.InnerHtml = imgprod;
                            }
                            else
                            {
                                imgprod = "<a href='" + "http://com21.com.ec/" + Request.QueryString["Ruta"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + "http://com21.com.ec/" + Request.QueryString["Ruta"].ToString() + "\" alt='' title=\"" + Request.QueryString["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + "http://com21.com.ec/" + Request.QueryString["Imagen"].ToString() + "\" alt='' title=\"" + Request.QueryString["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                                Imagenes_Productos.InnerHtml = imgprod;
                            }
                        }
                    }
                    break;
                case "S":
                    if (Request.QueryString["ID"] != null)
                    {
                        //pServ.Visible = true;
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

                                //lbltitulo.Text = r["Titulo"].ToString();
                                //servicios_web.InnerHtml = r["DescripcioCorta"].ToString();
                                //img.ImageUrl = r["Img"].ToString();

                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Servicio"].ToString(), "0", "0", "S");
                                String urlsge = "http://com21.com.ec/" + _titulo_dinamico;
                                String imagen = "http://com21.com.ec/" + r["Img"].ToString();
                                String titulo = "http://com21.com.ec/" + r["Titulo"].ToString();
                                //FaceS.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceS.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceP.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                                //imgServ.InnerHtml = "<a href='" + r["Img"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + r["Img"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + r["Img"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                            }
                        }
                    }
                    break;
                case "N":
                    if (Request.QueryString["ID"] != null)
                    {
                        //pNoti.Visible = true;
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

                                //lbltituloN.Text = r["Titulo"].ToString();
                                //noticias_web.InnerHtml = r["DescripcionCorta"].ToString();
                                //Image5.ImageUrl = r["Img"].ToString();

                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "0", "0", "N");
                                //FaceN.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceN.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceN.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                            }
                        }
                    }
                    break;
                case "F":
                    if (Request.QueryString["ID"] != null)
                    {
                        //pNoti.Visible = true;
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

                                //lbltituloN.Text = r["Titulo"].ToString();
                                //noticias_web.InnerHtml = r["DescripcionCorta"].ToString();
                                //Image5.ImageUrl = r["Img"].ToString();
                                //imgOfer.InnerHtml = "<a href='" + r["Img"].ToString() + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + r["Img"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\"/><img class=\"big\" src=\"" + r["Img"].ToString() + "\" alt='' title=\"" + r["Titulo"].ToString() + "\" style=\"width: 307px; height: 308px;\"/></a>";
                                String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "0", "0", "N");
                                //FaceN.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fcom21.com.ec%2F" + r["Url"].ToString() + "&amp;width=450&amp;height=35&amp;colorscheme=light&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;send=true&amp;extended_social_context=false&amp;appId=448140018617323\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:115px; height:35px;\"></iframe>";
                                //FaceN.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http://com21.com.ec/" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                                //FaceN.InnerHtml = "<span class='st_fblike_hcount' displayText='Facebook Like'></span><span class='st_twitter_hcount' displayText='Tweet' st_via='com21_sa'></span>";//<span class='st_instagram_hcount' displayText='Instagram Badge' st_username='omarsoco' st_image='" + imagen + "' st_title='" + titulo + "'></span>";//<span class='st_plusone_hcount' displayText='Google +1' st_url='" + urlsge + "' st_image='" + imagen + "' st_title='" + titulo + "'></span>";
                            }
                        }
                    }
                    break;
            }
        }
    }
    //private void cargarProdRe()
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    int cat = int.Parse(Request.QueryString["Cat"].ToString());
    //    int subcat = int.Parse(Request.QueryString["Sub"].ToString());
    //    int id = int.Parse(Request.QueryString["ID"].ToString());
    //    DataSet _ds = _consulta.Com21_consulta_productos_relacionados(id, cat, subcat);
    //    int i = 0;
    //    String _product = "";
    //    if (_ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow r in _ds.Tables[0].Rows)
    //        {
    //            if ((i >= 0) && (i < 2))
    //            {
    //                _product = _product + "<li class=\"item\">";
    //            }
    //            else
    //            {
    //                _product = _product + "<li class=\"item last\">";
    //            }
    //            _product = _product + "<div class=\"product-box\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" width=\"184\" height=\"184\" alt=\"" + r["Titulo"].ToString() + "\"/></a>" +
    //                "<h3 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h3>"+
    //                "<div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-26-upsell\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
    //            i = i + 1;
    //        }
    //        produt_re.InnerHtml = _product;
    //    }
    //}
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
    //private void cargarTags()
    //{
    //    String ul = "<ul class=\"tags-list\">";
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    DataSet _tags = _consulta.Com21_consulta_tags_marca_categorias_sub();
    //    int i = 1;
    //    if (_tags.Tables[0].Rows.Count > 0 || _tags.Tables[1].Rows.Count > 0)
    //    {
    //        //foreach(DataRow r in _tags.Tables[0].Rows)
    //        //{
    //        //    string _size = cargarTama(i);
    //        //    ul = ul + "<li><a href=\"servicio.aspx?IM=" + r["Id_Marca"].ToString() + "&IC=0&IS=0" + "\" style=\"font-size:" + _size + ";\">" + r["Marca"].ToString() + "</a></li>";
    //        //    //ul = ul + "<li><a href=\"cargarconsulta.aspx?IM=" + r["Id_Marca"].ToString() + "&IC=0&IS=0" + "\" style=\"font-size:" + _size + ";\">" + r["Marca"].ToString() + "</a></li>";
    //        //    i = i + 1;
    //        //}
    //        foreach (DataRow r in _tags.Tables[1].Rows)
    //        {
    //            string _size = cargarTama(i);
    //            ul = ul + "<li><a href=\"productos.aspx?Cat=" + r["Id_Categoria"].ToString() + "&Sub=" + r["Id_SubCategoria"].ToString() + "\" style=\"font-size:" + _size + ";\">" + r["Titulo"].ToString() + "</a></li>";
    //            //ul = ul + "<li><a href=\"cargarconsulta.aspx?IM=0" + "&IC=" + r["Id_Categoria"].ToString() + "&IS=" + r["Id_SubCategoria"].ToString() + "\" style=\"font-size:" + _size + ";\">" + r["Titulo"].ToString() + "</a></li>";
    //            i = i + 1;
    //        }
    //        tags_mezclados.InnerHtml = ul;
    //    }
    //}
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
            pErrorListo.Visible = false;
            ingresarPrefactura();
        }
        else
        {
            pErrorListo.Visible = true;
            LblErrorListo.Text = "Digite una cantidad mayor a 0";
            //lblnosi.Text = "Digite un cantidad mayor a 0";
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

                if (Request.Cookies["CodUpdatePre"] != null)
                {
                    _xmlDatos.DocumentElement.SetAttribute("CodUpdate", Request.Cookies["CodUpdatePre"].Value);
                }
                else
                {
                    classRandom _rand = new classRandom();
                    String _cod = _rand.NextString(11, true, true, true, false);
                    _xmlDatos.DocumentElement.SetAttribute("CodUpdate", _cod);
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
                        cargarInfoCarrito();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto agregado con exito');", true);
                    }
                }
            }
            else
            {
                String _idprod = Request.QueryString["ID"].ToString();
                string _iduser = Request.Cookies["IdCom21Web"].Value;
                string cant ="";
                foreach(DataRow r in _rep.Tables[0].Rows)
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
                if (_enviar.proc_actualiza_producto_repetido(_xmlDatos.OuterXml,int.Parse(_iduser),int.Parse(_idprod),""))
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
                        cargarInfoCarrito();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto agregado con exito');", true);
                    }
                }
            }
        }
        else
        {
            pErrorListo.Visible = true;
            LblErrorListo.Text = "Cantidad máxima para comprar es: " + hfCantidadBD.Value;
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
            pErrorListo.Visible = true;
            LblErrorListo.Text = "No existe cantidad suficiente para realizar la compra";
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

    #region "INICIAL"
    private void inicialP(DataTable dp)
    {
        //DataTable dp = (DataTable)ViewState["ds"];
        //DataTable dp = (DataTable)ViewState["ds"];
        pPro.Visible = true;
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web/";
        else
            _dominio = "http://" + _dominio + "/";
        foreach (DataRow rp in dp.Rows)
        {
            //imgMeta.Content = rp["Ruta"] + "";
            //titleMeta.Content = rp["Titulo"] + "";
            //titlePage.Text = rp["Titulo"] + "";
            //urlMeta.Content = rp["UrlProducto"] + "";
            //linkUrl.Href = rp["UrlProducto"] + "";
            //descripcionMeta.Content = HttpUtility.HtmlEncode(rp["DescripcioCorta"] + "");
            //Desp.Content = HttpUtility.HtmlEncode(rp["DescripcioCorta"] + "");
            titulo.InnerText = rp["Titulo"] + "";
            descripcion_corta.InnerText = HttpUtility.HtmlDecode(rp["DescripcioCorta"] + "");
            //Imagenes_Productos.InnerHtml = "<a href='" + rp["Ruta"] + "" + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + rp["Ruta"] + "" + "\" alt='' title=\"" + rp["Titulo"] + "" + "\"/><img class=\"big\" src=\"" + rp["Ruta"] + "" + "\" alt='' title=\"" + rp["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/></a>";
            Imagenes_Productos.InnerHtml = "<img class=\"big\" src=\"" + _dominio + rp["Ruta"].ToString().Remove(0, 1) + "\" alt='' title=\"" + rp["Titulo"] + "" + "\" style=\"width: 267px; height: 268px;\"/>";
            if (rp["Cantidad"] + "" != "0")
            {
                Existe.InnerText = "En existencia";
            }
            else
            {
                Existe.InnerText = "No en existencia";
            }
            if (rp["Descuento"] + "" != "0")
            {
                precio_actual.InnerText = "Precio Normal: $" + rp["Precio"] + "";
                precio_actual.Attributes.Add("class", "PrecioEspecial");

                hfDescuento.Value = rp["Descuento"] + "";
                int _desc = int.Parse(rp["Descuento"] + "");
                Double _calcular = double.Parse(rp["Precio"] + "");
                Double _multi = ((_calcular * _desc) / 100);
                String _precioesp = Convert.ToString(_calcular - _multi);

                precio_especial.InnerText = "Precio Descuento: $" + _precioesp;
                hfprecio.Value = rp["Precio"] + "";
            }
            else
            {
                hfDescuento.Value = rp["Descuento"] + "";
                precio_actual.InnerText = "Precio Normal: $" + rp["Precio"] + "";
                precio_actual.Attributes.Add("class", "NPrecioEspecial");
                hfprecio.Value = rp["Precio"] + "";
            }
        }
    }
    private void inicialO()
    {
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web";
        else
            _dominio = "http://" + _dominio;
        DataTable dt = (DataTable)ViewState["ds"];
        pOfertas.Visible = true;
        foreach (DataRow ro in dt.Rows)
        {
            imgMeta.Content = ro["Ruta"] + "";
            titleMeta.Content = ro["Titulo"] + "";
            titlePage.Text = ro["Titulo"] + "";
            urlMeta.Content = ro["Url"] + "";
            linkUrl.Href = ro["Url"] + "";
            descripcionMeta.Content = HttpUtility.HtmlEncode(ro["DescripcionCorta"] + "");
            Desp.Content = HttpUtility.HtmlEncode(ro["DescripcionCorta"] + "");
            titulo.InnerText = ro["Titulo"] + "";
            descripcion_oferta.InnerText = ro["DescripcionCorta"] + "";
            Imagenes_ofertas.InnerHtml = "<img class=\"big\" src=\"" + _dominio + ro["Ruta"].ToString().Remove(0,1) + "\" alt='' title=\"" + ro["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/>";
        }
    }
    private void inicialS()
    {
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web";
        else
            _dominio = "http://" + _dominio;
        DataTable dt = (DataTable)ViewState["ds"];
        pServicios.Visible = true;
        foreach (DataRow rs in dt.Rows)
        {
            imgMeta.Content = rs["Ruta"] + "";
            titleMeta.Content = rs["Titulo"] + "";
            titlePage.Text = rs["Titulo"] + "";
            urlMeta.Content = rs["Url"] + "";
            linkUrl.Href = rs["Url"] + "";
            descripcionMeta.Content = HttpUtility.HtmlEncode(rs["DescripcioCorta"] + "");
            Desp.Content = HttpUtility.HtmlEncode(rs["DescripcioCorta"] + "");
            titulo.InnerText = rs["Titulo"] + "";
            descripcion_servicios.InnerText = rs["DescripcioCorta"] + "";
            Imagenes_servicios.InnerHtml = "<img class=\"big\" src=\"" + _dominio + rs["Ruta"].ToString().Remove(0,1) + "\" alt='' title=\"" + rs["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/>";
        }
    }
    #endregion
    #region "OFERTAS"
    private void ofertas()
    {
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web";
        else
            _dominio = "http://" + _dominio;
        DataTable dt = (DataTable)ViewState["ds"];
        pOfertas.Visible = true;
        foreach (DataRow ro in dt.Rows)
        {
                imgMeta.Content = ro["Ruta"]+"";
                titleMeta.Content = ro["Titulo"]+"";
                titlePage.Text = ro["Titulo"]+"";
                urlMeta.Content = ro["Url"]+"";
                linkUrl.Href = ro["Url"]+"";
                descripcionMeta.Content = HttpUtility.HtmlEncode(ro["DescripcionCorta"]+"");
                Desp.Content = HttpUtility.HtmlEncode(ro["DescripcionCorta"]+"");
                titulo.InnerText = ro["Titulo"]+"";
                descripcion_oferta.InnerText = ro["DescripcionCorta"]+"";
                Imagenes_ofertas.InnerHtml = "<img class=\"big\" src=\"" + _dominio + ro["Ruta"].ToString().Remove(0,1) + "\" alt='' title=\"" + ro["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/>";
        }
    }
    //private void ofertas()
    //{
    //    if (Request.QueryString["ID"] != null)
    //    {
    //        String path = HttpContext.Current.Server.MapPath("ofertas.xml");
    //        String _idprod = Request.QueryString["ID"].ToString();
    //        XmlDocument _doc = new XmlDocument();
    //        _doc.Load(path);
    //        XmlNodeList ListItem = _doc.GetElementsByTagName("Oferta");
    //        pOfertas.Visible = true;
    //        foreach (XmlNode nodeitem in ListItem)
    //        {
    //            XmlElement Xmlitem = (XmlElement)nodeitem;
    //            if (Xmlitem.SelectSingleNode("Id").InnerText == _idprod)
    //            {
    //                imgMeta.Content = Xmlitem.SelectSingleNode("Ruta").InnerText;
    //                titleMeta.Content = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                titlePage.Text = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                urlMeta.Content = Xmlitem.SelectSingleNode("Url").InnerText;
    //                linkUrl.Href = Xmlitem.SelectSingleNode("Url").InnerText;
    //                descripcionMeta.Content = HttpUtility.HtmlEncode(Xmlitem.SelectSingleNode("DescripcionCorta").InnerText);
    //                Desp.Content = HttpUtility.HtmlEncode(Xmlitem.SelectSingleNode("DescripcionCorta").InnerText);
    //                tituloOferta.InnerText = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                descripcion_oferta.InnerText = Xmlitem.SelectSingleNode("DescripcionCorta").InnerText;
    //                Imagenes_ofertas.InnerHtml = "<a href='" + Xmlitem.SelectSingleNode("Ruta").InnerText + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + Xmlitem.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlitem.SelectSingleNode("Titulo").InnerText + "\"/><img class=\"big\" src=\"" + Xmlitem.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlitem.SelectSingleNode("Titulo").InnerText + "\" style=\"width: 307px; height: 308px;\"/></a>";
    //                //String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "0", "0", "N");
    //                //imgMeta.Content = "http://com21.com.ec/" + r["Img"].ToString();
    //                //titleMeta.Content = r["Titulo"].ToString();
    //                //titlePage.Text = r["Titulo"].ToString();
    //                //urlMeta.Content = "http://com21.com.ec/" + r["Url"].ToString();
    //                //linkUrl.Href = "http://com21.com.ec/" + r["Url"].ToString();
    //                //descripcionMeta.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //                //Desp.Content = HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString());
    //            }
    //        }
    //    }
    //}
    #endregion
    #region "SERVICIO"
    private void servicios()
    {
        String E = Request.QueryString["E"];
        hfURL.Value = HttpContext.Current.Request.Url.AbsoluteUri;
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web";
        else
            _dominio = "http://" + _dominio;
        DataTable dt = (DataTable)ViewState["ds"];
        pServicios.Visible = true;
        foreach (DataRow rs in dt.Rows)
        {
            imgMeta.Content = rs["Ruta"] + "";
            titleMeta.Content = rs["Titulo"] + "";
            titlePage.Text = rs["Titulo"] + "";
            urlMeta.Content = rs["Url"] + "";
            linkUrl.Href = rs["Url"] + "";
            descripcionMeta.Content = HttpUtility.HtmlEncode(rs["DescripcioCorta"] + "");
            Desp.Content = HttpUtility.HtmlEncode(rs["DescripcioCorta"] + "");
            titulo.InnerText = rs["Titulo"] + "";
            descripcion_servicios.InnerText = rs["DescripcioCorta"] + "";
            Imagenes_servicios.InnerHtml = "<img class=\"big\" src=\"" + _dominio + rs["Ruta"].ToString().Remove(0,1) + "\" alt='' title=\"" + rs["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/>";
        }
        if (E != null)
        {
            if (E == "1")
            {
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.CssStyle.Add("exito", "");
                DMensaje.InnerText = "Correo enviado con exito";
            }
        }
    }
    //private void servicios()
    //{
    //    if (Request.QueryString["ID"] != null)
    //    {
    //        String path = HttpContext.Current.Server.MapPath("servicios.xml");
    //        String _idprod = Request.QueryString["ID"].ToString();
    //        XmlDocument _doc = new XmlDocument();
    //        _doc.Load(path);
    //        XmlNodeList ListItem = _doc.GetElementsByTagName("Servicio");
    //        pServicios.Visible = true;
    //        foreach (XmlNode nodeitem in ListItem)
    //        {
    //            XmlElement Xmlitem = (XmlElement)nodeitem;
    //            if (Xmlitem.SelectSingleNode("Id").InnerText == _idprod)
    //            {
    //                imgMeta.Content = Xmlitem.SelectSingleNode("Ruta").InnerText;
    //                titleMeta.Content = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                titlePage.Text = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                urlMeta.Content = Xmlitem.SelectSingleNode("Url").InnerText;
    //                linkUrl.Href = Xmlitem.SelectSingleNode("Url").InnerText;
    //                descripcionMeta.Content = HttpUtility.HtmlEncode(Xmlitem.SelectSingleNode("DescripcionCorta").InnerText);
    //                Desp.Content = HttpUtility.HtmlEncode(Xmlitem.SelectSingleNode("DescripcionCorta").InnerText);
    //                tituloServicios.InnerText = Xmlitem.SelectSingleNode("Titulo").InnerText;
    //                descripcion_servicios.InnerText = Xmlitem.SelectSingleNode("DescripcionCorta").InnerText;
    //                Imagenes_servicios.InnerHtml = "<a href='" + Xmlitem.SelectSingleNode("Ruta").InnerText + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + Xmlitem.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlitem.SelectSingleNode("Titulo").InnerText + "\"/><img class=\"big\" src=\"" + Xmlitem.SelectSingleNode("Ruta").InnerText + "\" alt='' title=\"" + Xmlitem.SelectSingleNode("Titulo").InnerText + "\" style=\"width: 307px; height: 308px;\"/></a>";
    //            }
    //        }
    //    }
    //}
    #endregion
    #region "PRODUCTOS"
    private void productos()
    {
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
            _dominio = "http://" + _dominio + "/com21Web";
        else
            _dominio = "http://" + _dominio;
        DataTable dp = (DataTable)ViewState["ds"];
        pPro.Visible = true;
        foreach (DataRow rp in dp.Rows)
        {
            //imgMeta.Content = rp["Ruta"]+"";
            //titleMeta.Content = rp["Titulo"]+"";
            //titlePage.Text = rp["Titulo"]+"";
            //urlMeta.Content = rp["UrlProducto"] + "";
            //linkUrl.Href = rp["UrlProducto"] + "";
            //descripcionMeta.Content = HttpUtility.HtmlEncode(rp["Descripcion"]+"");
            //Desp.Content = HttpUtility.HtmlEncode(rp["Descripcion"]+"");
            titulo.InnerText = rp["Titulo"]+"";
            descripcion_corta.InnerText = HttpUtility.HtmlDecode(rp["DescripcioCorta"]+"");
            //Imagenes_Productos.InnerHtml = "<a href='" + rp["Ruta"] + "" + "' class='cloud-zoom' id='zoom1' rel=\"position:'right',showTitle:1,titleOpacity:0.5,lensOpacity:0.5,adjustX: 10,adjustY:-4\"><img class=\"small\" src=\"" + rp["Ruta"] + "" + "\" alt='' title=\"" + rp["Titulo"] + "" + "\"/><img class=\"big\" src=\"" + rp["Ruta"] + "" + "\" alt='' title=\"" + rp["Titulo"] + "" + "\" style=\"width: 307px; height: 308px;\"/></a>";
            Imagenes_Productos.InnerHtml = "<img class=\"big\" src=\"" + _dominio + rp["Ruta"].ToString().Remove(0, 1) + "\" alt='' title=\"" + rp["Titulo"] + "" + "\" style=\"width: 267px; height: 268px;\"/>";
            if (rp["Cantidad"]+"" != "0")
            {
                Existe.InnerText = "En existencia";
            }
            else
            {
                Existe.InnerText = "No en existencia";
            }
            if (rp["Descuento"]+"" != "0")
            {
                precio_actual.InnerText = "Precio Normal: $" + rp["Precio"]+"";
                precio_actual.Attributes.Add("class", "PrecioEspecial");

                hfDescuento.Value = rp["Descuento"]+"";
                int _desc = int.Parse(rp["Descuento"]+"");
                Double _calcular = double.Parse(rp["Precio"]+"");
                Double _multi = ((_calcular * _desc) / 100);
                String _precioesp = Convert.ToString(_calcular - _multi);

                precio_especial.InnerText = "Precio Descuento: $" + _precioesp;
                hfprecio.Value = rp["Precio"]+"";
            }
            else
            {
                hfDescuento.Value = rp["Descuento"]+"";
                precio_actual.InnerText = "Precio Normal: $" + rp["Precio"]+"";
                precio_actual.Attributes.Add("class", "NPrecioEspecial");
                hfprecio.Value = rp["Precio"]+"";
            }
        }
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtcantidad.Text.Length > 0)
        {
            pErrorListo.Visible = false;
            ingresarPrefactura();
        }
        else
        {
            pErrorListo.Visible = true;
            LblErrorListo.Text = "Digite una cantidad mayor a 0";
            //lblnosi.Text = "Digite un cantidad mayor a 0";
        }
    }

    protected void BtRefresh_Click(object sender, EventArgs e)
    {
        if (hfURL.Value != "")
        {
            Response.Redirect("envioCorreo.aspx?UrlRe=" + HttpUtility.UrlEncode(hfURL.Value));
        }
    }
    protected void btnatras_Click(object sender, EventArgs e)
    {

        Response.Redirect("servicios.aspx");
        
    }
}