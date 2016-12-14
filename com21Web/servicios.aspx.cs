using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class servicios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarhead();
            cargarproducto();
            string strUserAgent = Request.UserAgent.ToString().ToLower();

            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                cargarInfoCarrito();
                #region "OBTENER TIPO NAVAGACIÓN"

                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true ||
                            strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                            strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                    {
                        lblusernomb.Text = Request.Cookies["UserCom21Web"].Value;
                        pInicio.Visible = false;
                        pInicioSesion.Visible = false;
                        pInicioRelogin.Visible = true;
                        pInicioRe.Visible = false;
                    }
                    else
                    {
                        lblusernomb.Text = Request.Cookies["UserCom21Web"].Value;
                        pInicio.Visible = false;
                        pInicioSesion.Visible = true;
                        pInicioRelogin.Visible = false;
                        pInicioRe.Visible = false;
                    }

                }
                #endregion
            }
            else
            {


                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true ||
                            strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                            strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                    {
                        pInicio.Visible = false;
                        pInicioSesion.Visible = false;
                        pInicioRelogin.Visible = false;
                        pInicioRe.Visible = true;
                    }
                    else
                    {
                        pInicio.Visible = true;
                        pInicioSesion.Visible = false;
                        pInicioRelogin.Visible = false;
                        pInicioRe.Visible = false;
                    }
                }
            }
        }
    }
    //private void cargarhead()
    //{
    //    String _head = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><script type=\"text/javascript\">    var NREUMQ = NREUMQ || []; NREUMQ.push([\"mark\", \"firstbyte\", new Date().getTime()]);</script><title>Com21</title><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\"><meta name=\"description\" content=\"Default Description\"/><meta name=\"keywords\" content=\"Magento, Varien, E-commerce\"/><meta name=\"robots\" content=\"INDEX,FOLLOW\"/><link rel=\"icon\" href=\"images/logocom21icon.png\" type=\"image/x-icon\"/>" +
    //    "<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
    //    "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
    //    "<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]-->" +
    //    "<script type=\"text/javascript\">//<![CDATA[    var Translator = new Translate([]);        //]]></script>";
    //    cabecera_esp.InnerHtml = _head;
    //}
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
        if (Request.QueryString["NS"] != null)
        {
            string notser = Request.QueryString["NS"].ToString();
            if (notser == "S")
            {
                if (Request.QueryString["IDS"] != null)
                {
                    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                    DataSet _serv = _consulta.Com21_consulta_servicios_id(int.Parse(Request.QueryString["IDS"].ToString()));
                    if (_serv.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow r in _serv.Tables[1].Rows)
                        {
                            String _head = "<meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:url\" content=\"" + r["Url"].ToString() + "\"/><meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Img"].ToString() + "\"/><meta property=\"og:site_name\" content=\"http://designsie.com/\"/><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcioCorta"].ToString()) + "\"/><meta property=\"og:image:type\" content=\"image/jpg\" />" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><script type=\"text/javascript\">    var NREUMQ = NREUMQ || []; NREUMQ.push([\"mark\", \"firstbyte\", new Date().getTime()]);</script><title>" + r["Titulo"].ToString() + "</title><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\"><meta name=\"description\" content=\"Default Description\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/><meta name=\"robots\" content=\"INDEX,FOLLOW\"/><link rel=\"icon\" href=\"http://designsie.com/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                            "<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                            "<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]-->" +
                            "<script type=\"text/javascript\">//<![CDATA[    var Translator = new Translate([]);        //]]></script>";
                            cabecera_esp.InnerHtml = _head;

                            lbltitulo.Text = r["Titulo"].ToString();
                            productos_web.InnerHtml = r["Descripcion"].ToString();
                            img.ImageUrl = r["Img"].ToString();

                            String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Servicio"].ToString(), "S");
                            Face.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fdesignsie.com%2F" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                        }
                    }
                }
            }
            else
            {
                if (Request.QueryString["IDS"] != null)
                {
                    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                    DataSet _serv = _consulta.Com21_consulta_noticias_id(int.Parse(Request.QueryString["IDS"].ToString()));
                    if (_serv.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow r in _serv.Tables[1].Rows)
                        {
                            String _head = "<meta property=\"og:title\" content=\"" + r["Titulo"].ToString() + "\"/><meta property=\"og:url\" content=\"" + r["Url"].ToString() + "\"/><meta property=\"og:image\" content=\"" + "http://com21.com.ec/" + r["Img"].ToString() + "\"/><meta property=\"og:site_name\" content=\"http://designsie.com/\"/><meta property=\"og:description\" content=\"" + HttpUtility.HtmlEncode(r["DescripcionCorta"].ToString()) + "\"/><meta property=\"og:image:type\" content=\"image/jpg\" />" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><script type=\"text/javascript\">    var NREUMQ = NREUMQ || []; NREUMQ.push([\"mark\", \"firstbyte\", new Date().getTime()]);</script><title>" + r["Titulo"].ToString() + "</title><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\"><meta name=\"description\" content=\"Default Description\"/><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\"/><meta name=\"robots\" content=\"INDEX,FOLLOW\"/><link rel=\"icon\" href=\"http://designsie.com/images/logocom21icon.png\" type=\"image/x-icon\"/>" +
                            "<link href='css/css056a.css?family=Playfair+Display' rel='stylesheet' type='text/css'/><link href='css/css4fe8.css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'/><link href='css/cssaa4a.css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/><script type=\"text/javascript\" src=\"js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {min-width: 960px !important;}	</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"css/styles.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/responsive.css\" media=\"all\"/>" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/superfish.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/camera.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/widgets.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/cloud-zoom.css\" media=\"all\"/><link rel=\"stylesheet\" type=\"text/css\" href=\"css/print.css\" media=\"print\"/><script type=\"text/javascript\" src=\"js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/effects.js\"></script>" +
                            "<script type=\"text/javascript\" src=\"js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]-->" +
                            "<script type=\"text/javascript\">//<![CDATA[    var Translator = new Translate([]);        //]]></script>";
                            cabecera_esp.InnerHtml = _head;

                            lbltitulo.Text = r["Titulo"].ToString();
                            productos_web.InnerHtml = r["Descripcion"].ToString();
                            img.ImageUrl = r["Img"].ToString();

                            String _titulo_dinamico = GenerateURLProducto(r["Titulo"].ToString(), r["Id_Noticia"].ToString(), "N");
                            Face.InnerHtml = "<iframe src='//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fdesignsie.com%2F" + _titulo_dinamico + "&amp;send=false&amp;layout=button_count&amp;width=150&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21' scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:150px; height:21px;\" allowTransparency=\"true\"></iframe>";
                        }
                    }
                }
            }
        }
    }
    public static string GenerateURLProducto(object Title, object strId, object strTipo)
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
        strTitle = "" + strTitle + "-" + strId + "-" + strTipo + ".aspx";

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
}