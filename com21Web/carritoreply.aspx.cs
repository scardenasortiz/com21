using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using com21DLL;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Collections.Specialized;

public partial class carritoreply : System.Web.UI.Page
{
    public String[] DataC;
    private void ConsultaDataCompra(int id)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_cliente_DatosCompra(id,1);
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
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                ConsultaDataCompra(int.Parse(Request.Cookies["IdCom21Web"].Value));
                String data = ViewState["DataCompra"] + "";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {
                    if (DataC[2] + "" != "-1")
                    {
                        Refrescar.Visible = false;
                        RefrescarN.Visible = true;
                        int i = int.Parse(DataC[3] + "");
                        if (i == 0)
                        {
                            pSinCosto.Visible = true;
                            pConCosto.Visible = false;
                            //cambiarCodUpdate();
                        }
                        else
                        {
                            if (i == 1)
                            {
                                if (DataC[2] + "" == "1")
                                {
                                    pSinCosto.Visible = false;
                                    pConCosto.Visible = true;
                                    pEnvioAct.Visible = true;
                                }
                                if (DataC[2] + "" == "0")
                                {
                                    pSinCosto.Visible = true;
                                    pConCosto.Visible = false;
                                    pEnvioAct.Visible = false;
                                }
                            }
                            else
                            {
                                if (DataC[2] + "" == "1")
                                {
                                    pSinCosto.Visible = false;
                                    pConCosto.Visible = true;
                                    pEnvioAct.Visible = true;
                                }
                                if (DataC[2] + "" == "0")
                                {
                                    pSinCosto.Visible = true;
                                    pConCosto.Visible = false;
                                    pEnvioAct.Visible = false;
                                }
                            }
                        }
                        recibeDatos();
                    }
                    else
                    {
                        cancelarCarrito();
                        Refrescar.Visible = true;
                        RefrescarN.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                Response.Redirect("default.aspx");   
            }
        }
    }
    private DataSet cargarCarrito()
    {
        /*int carga = 0;
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {
            if (DataC[3] + "" == "0")
                carga = 0;
            else
                carga = 1;
        }*/
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado_IdCod(int.Parse(Request.Cookies["IdCom21Web"].Value), DataC[4]+"");
        if (_ds.Tables[0].Rows.Count > 0)
        {
            pProductSi.Visible = true;
            pProductNo.Visible = false;
            GvCarrito.DataSource = _ds.Tables[0];
            GvCarrito.DataBind();
            sumarTD(_ds, 0);
            
        }
        else
        {
            pProductSi.Visible = false;
            pProductNo.Visible = true;
            productosN.InnerHtml = "No existen productos agregados a su carrito";
        }
        return _ds;
    }
    private void cambiarCodUpdate()
    {
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        String codupdate = "";
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {
            codupdate = DataC[4] + "";    
        }
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if (_consulta.proc_edita_codupdate_prefactura(0, id, codupdate))
        {
        }
        else
        {
        }
    }
    private void sumarTD(DataSet ds, int carga)
    {
        Decimal _tot = 0;
        Decimal _desc = 0;
        Decimal _totF = 0;
        Decimal _iva = 0;
        foreach (DataRow r in ds.Tables[carga].Rows)
        {
            _tot = _tot + decimal.Parse(r["Total"].ToString());
            _desc = _desc + decimal.Parse(r["Descuento"].ToString());

        }

        if (DataC[2] + "" == "1")
        {
            Decimal _costo = costoenvio();
            sCostoEnv.InnerHtml = Convert.ToString(_costo.ToString("0.00"));

            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc + _costo;
        }
        else
        {
            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc;
        }

        iva.InnerHtml = Convert.ToString(_iva);
        sIvaCosto.InnerHtml = Convert.ToString(_iva);

        descuentos.InnerHtml = Convert.ToString(_desc);
        sDescCosto.InnerHtml = Convert.ToString(_desc);

        subtotal.InnerHtml = Convert.ToString(_tot);
        sSubCosto.InnerHtml = Convert.ToString(_tot);

        total.InnerHtml = Convert.ToString(_totF);
        sTotCosto.InnerHtml = Convert.ToString(_totF);
    }
    private decimal costoenvio()
    {
        Decimal a = 0;
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_costo_IdUsuario_IdCiudad(id,0);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[0].Rows)
            {
                a = decimal.Parse(r["Costo"].ToString().Replace(".", ","));
            }
        }
        else
        {

        }
        return a;
    }
    private void recibeDatos()
    {
        try
        {
            NameValueCollection coll = new NameValueCollection();
            coll = Request.Params;
            if (coll.Get("payment_status").Equals("Completed"))
            {
                String data = ViewState["DataCompra"] + "";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {            //idusuario+T+ActE+FormaP+CodUpdatePre
                    if (DataC[3] + "" == "1")
                    {
                        lblformaP.Text = "Transferencia";
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        XmlDocument _xmlDatos = new XmlDocument();

                        string idt = DataC[1] + "";
                        _xmlDatos.LoadXml("<Transaccion/>");
                        _xmlDatos.DocumentElement.SetAttribute("Lote", "");
                        _xmlDatos.DocumentElement.SetAttribute("Referencia", "");
                        _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Realizada");
                        if (_consulta.proc_Actualiza_Transaccion(_xmlDatos.OuterXml, idt))
                        {
                        }
                        else
                        {
                            lblorden.Text = idt;
                            cargarDatos();
                            IngresarOrden();
                            if (DataC[2] + "" != "0")
                            {
                                cargarDireccionEnvio();
                            }
                            DataSet ds = cargarCarrito();
                            ingresarinventario(ds);
                            enviarcorreo(ds);

                            /*int carga;
                            if (DataC[3] + "" == "0")
                                carga = 0;
                            else
                                carga = 1;*/
                            int i = ds.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                ActualizarDataCompra("0", "0", DataC[4] + "", "0");
                                /*Response.Cookies["FormaP"].Value = "0";
                                Response.Cookies["ActE"].Value = "0";
                                Response.Cookies["T"].Value = "0";*/
                            }
                        }
                    }
                    else
                    {
                        lblformaP.Text = "PAYPAL";
                        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                        XmlDocument _xmlDatos = new XmlDocument();

                        string idt = DataC[1] + "";
                        _xmlDatos.LoadXml("<Transaccion/>");
                        _xmlDatos.DocumentElement.SetAttribute("Lote", "");
                        _xmlDatos.DocumentElement.SetAttribute("Referencia", "");
                        _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Realizada");
                        if (_consulta.proc_Actualiza_Transaccion(_xmlDatos.OuterXml, idt))
                        {
                        }
                        else
                        {
                            lblorden.Text = idt;
                            cargarDatos();
                            IngresarOrden();
                            if (DataC[2] + "" == "1")
                            {
                                cargarDireccionEnvio();
                            }
                            DataSet ds = cargarCarrito();
                            ingresarinventario(ds);
                            enviarcorreo(ds);

                            /*int carga;
                            if (DataC[3] + "" == "0")
                                carga = 0;
                            else
                                carga = 1;*/
                            int i = ds.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                ActualizarDataCompra("0", "0", DataC[4] + "", "0");
                                /*Response.Cookies["FormaP"].Value = "0";
                                Response.Cookies["ActE"].Value = "0";
                                Response.Cookies["T"].Value = "0";*/
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Refrescar.Visible = true;
            RefrescarN.Visible = false;
        }
    }
    private void ActualizarDataCompra(string T, string FormaP, string CodUpdatePre, string ActE)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", Request.Cookies["IdCom21Web"].Value);
        _xmlDatos.DocumentElement.SetAttribute("T", T);
        _xmlDatos.DocumentElement.SetAttribute("FormaP", FormaP);
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", CodUpdatePre);
        _xmlDatos.DocumentElement.SetAttribute("ActE", ActE);
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, int.Parse(Request.Cookies["IdCom21Web"].Value)))
        { }
        else
        { }
    }
    private void enviarcorreo(DataSet _ds)
    {
        int carga = 0;
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {            //idusuario+T+ActE+FormaP+CodUpdatePre

            MailMessage objMail = new MailMessage();
            objMail.IsBodyHtml = true;
            objMail.From = new MailAddress("info@com21.com.ec");
            objMail.Priority = MailPriority.High;
            objMail.To.Add(Request.Cookies["EmailCom21Web"].Value);
            objMail.Subject = "Orden de Compra";
            String formt = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\">";
            //head
            formt = formt + "<title>Com21 S.A :: Orden de Compra</title><meta id=\"ctl00_titlepagina1\" property=\"og:title\" /><meta property=\"og:type\" content=\"company\" /><meta property=\"og:url\" content=\"http://com21.com.ec/\" /><meta property=\"og:image\" /><meta property=\"og:site_name\" content=\"Com21 S.A\" /><meta property=\"og:image:type\" content=\"image/jpg\" /><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0\" /><meta name=\"description\" content=\"Default Description\" /><meta name=\"keywords\" content=\"com21sa, com21, misión y visión de com21, misión, visión, nosotros, contactenos, quienes somos, telefonía, computo, servicios, catalogo de productos, catalogo de productos, suministros de impresión, registrate, inicio sesión, suministros de impresión guayaquil, suministros de impresión guayaquil ecuador,  ventas, venta online, electrico, pc, computadoras, cableado de red, cableado electrico, láptop, portátil, software, hardware, mouse, teclado, memorias, memoria, discos duros, disco duro, parlantes, línea blanca, refrigeradoras, neveras, tv, televisores, lcd, led, cocinas, aires acondicionados, cpu, programas, monitor, monitores, celulares, notebooks, table, cable de red, ups, tarjetas de red, tarjetas de video, mantenimiento, toner, cableado estructurado, suministros de oficina, suministros de computación, accesorios de computo, camaras de vigilancia, camaras digitales, camaras web, pen drive, flash memory, suministros xerox, hp, dell, toshiba, LG, samsung, acer, mabe, indurama, modem, coby\" /><meta name=\"summary\" content=\"Compromiso y buen servicios para todos sus clientes\" /><meta name=\"Generator\" content=\"Designsie\" /><meta name=\"Author\" content=\"Designsie.\" /><meta name=\"Origen\" content=\"Com21 S.A\" /><meta name=\"Locality\" content=\"Guayaquil, Ecuador\" /><meta name=\"author\" content=\"http://designsie.com/\" /><meta name=\"Language\" content=\"es\" /><meta name=\"robots\" content=\"INDEX,FOLLOW\" /><meta name=\"alexaVerifyID\" content=\"lePEQIViFY7NjZkOJ2x7ma53hKs\" /><script type=\"text/javascript\"> var _gaq = _gaq || [];" +
                "_gaq.push(['_setAccount', 'UA-42436643-1']);_gaq.push(['_setDomainName', 'com21.com.ec']);_gaq.push(['_trackPageview']); (function () { var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true; ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s); })();</script><link rel=\"icon\" href=\"http://com21.com.ec/images/logocom21icon.png\" type=\"image/x-icon\" /><link href=\"http://com21.com.ec/css/css056a.css?family=Playfair+Display\" rel=\"stylesheet\" type=\"text/css\" /><link href=\"http://com21.com.ec/css/css4fe8.css?family=Open+Sans+Condensed:300\" rel=\"stylesheet\" type=\"text/css\" /><link href=\"http://com21.com.ec/css/cssaa4a.css?family=Open+Sans:400,700\" rel=\"stylesheet\" type=\"text/css\" /><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery-1.7.min.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery.prettyPhoto.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/superfish.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery.easing.1.3.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery.mobile.customized.min.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/scripts.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/easyTooltip.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery.jcarousel.min.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/jquery.iosslider.min.js\"></script><!--[if lt IE 9]><style>	body {	min-width: 960px !important;}</style><![endif]--><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/styles.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/responsive.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/superfish.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/camera.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/widgets.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/cloud-zoom.css\" media=\"all\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"http://com21.com.ec/css/print.css\" media=\"print\" />" +
                "<script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/prototype.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/ccard.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/validation.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/builder.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/effects.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/dragdrop.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/controls.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/slider.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/js.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/form.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/translate.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/cookies.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/cloud-zoom.1.0.2.min.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/bootstrap.js\"></script><script type=\"text/javascript\" src=\"http://com21.com.ec/js/jspagina/msrp.js\"></script><!--[if lt IE 8]><link rel=\"stylesheet\" type=\"text/css\" href=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/default/theme451/css/styles-ie.css\" media=\"all\" /><![endif]--><!--[if lt IE 7]><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/js/lib/ds-sleight.js\"></script><script type=\"text/javascript\" src=\"http://livedemo00.template-help.com/magento_42968/skin/frontend/base/default/js/ie6.js\"></script><![endif]--><script type=\"text/javascript\">//<![CDATA[var Translator = new Translate([]);//]]></script>";
            //fin de head
            //cuerpo
            formt = formt + "</head><body><div style=\"width: 500px;margin-right: auto; margin-left: auto;\">" +
                "<table style=\"border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;\"><tr><td style=\"background-position: center top; padding: 5px; text-align: left; background-image: url('http://designsie.com/images/carrito_correo.png'); background-repeat: no-repeat; font-weight: bold;\"><table style=\"width: 100%;\"><tr><td width=\"50%\"><a href=\"http://designsie.com/\" target=\"_blank\"><img alt=\"\" src=\"http://com21.com.ec/images/logocom21icon.png\" width=\"120\" /></a></td><td width=\"50%\" style=\"text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;\">ORDEN DE COMPRA</td></tr></table></td></tr>" +
                "<tr><td style=\"padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">&nbsp;</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">Estimado(a)</td></tr><tr><td style=\"padding: 5px 5px 15px 5px\">";
            //datos
            String nom_ape = cargarNombreApe();
            formt = formt + nom_ape;
            formt = formt + "</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">";
            formt = formt + "<div style=\"color: #ABCD43; font-size: 18px; font-family: Arial, Helvetica, sans-serif;\">Su pedido ha sido recibido.</div><br />Gracias por comprar en com21.com.ec, su # de orden es:&nbsp;<h2 class=\"product-name\" style=\"margin-bottom: 5px; font-weight:bold; font-size:13px;\">" + DataC[1]+"" + "</h2><br /> En breve recibirá un correo electrónico con respecto al estado de su pedido.</td></tr>";
            formt = formt + "<tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">";
            //aqui va productos
            //String _generar = "<ol class=\"products-list\" id=\"products-list\">";
            String _generar = "<table style=\"width: 100%; padding-top: 10px; padding-bottom: 7px; margin-bottom: 5px;\" class=\"item\">";
            /*if (DataC[3] + "" == "1")
                carga = 0;
            else
                carga = 1;*/
            int total = _ds.Tables[0].Rows.Count;
         
            foreach (DataRow r in _ds.Tables[0].Rows)
            {
                _generar = _generar + "<tr><td style=\"width: 95px;\">";
                String img = string.Empty;
                String _dominio = Request.Url.Authority;
                if (_dominio == "localhost:2304")
                {
                    img = "http://localhost:2304/com21Web/" + r["Ruta"]+"";
                }
                else
                {
                    img = "http://designsie.com/" + r["Ruta"] + "";
                }
                
                _generar = _generar + "<div class=\"product-image-carrito\"><img src='" + img + "' alt='" + r["Titulo"].ToString() + "' width=\"90\" height=\"90\"></div></td>";
                _generar = _generar + "<td style=\"width: 203px;\"><div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\" style=\"margin-bottom: 5px; color:#ABCD43; font-weight:bold; font-size:14px;\">" + r["Titulo"].ToString() + "</h2>";
                _generar = _generar + "<div class=\"desc std\"><div style=\"color:#000000; font-size:12px; font-weight:bold;\">Cantidad:&nbsp;&nbsp;&nbsp;" + r["Cantidad"].ToString() + "</div>" +
                    "<div style=\"color:#000000; font-size:12px; font-weight:bold;\">Precio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$" + r["Precio"].ToString() + "</div>";
                _generar = _generar + "<div style=\"color:#000000; font-size:12px; font-weight:bold;\">Descuento:&nbsp;$" + r["Descuento"].ToString() + "</div></div></div></div></td>";

                _generar = _generar + "<td style=\"width: 202px;\"><div style=\"padding-top:4px\"><div style=\"text-align: center; padding: 5px; float:left;\"></div><div style=\"color:#000000; font-size:13px; font-weight:bold; float:right; background-color:#ABCD43; padding: 5px\">TOTAL:&nbsp;$" + r["Total"].ToString() + "</div></div></td></tr>";

            }
            _generar = _generar + "</table>";
            //_generar = _generar + "</ol>";
            //fin de productos

            formt = formt + _generar;
            formt = formt + "</td></tr>" +
                "<tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Si usted desea imprimir sus compras, por favor visite el área de <a href=\"http://designsie.com/ordenes.aspx\" target=\"_blank\">Mis Ordenes</a> de nuestro sitio web.<br /><br />Gracias de nuevo por hacer compras en com21.com.ec Saludos cordiales," +
                "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif; text-align: center;\"><a href=http://designsie.com/ target=\"_blank\">www.com21.com.ec</a></td></tr><tr style=\"background-color: #E2E2E2;\">" +
                "<td style=\"padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;\">Contacto:&nbsp;&nbsp;&nbsp;<span style=\"font-size: 14px; color: #000000\">Tel:(+593) 42-300539</span></td></tr></table></div></body></html>";

            objMail.Body = formt;
            //fin puerto

            //envio de correos al administrador
            classCom21Correo clCorreo = new classCom21Correo();
            String _dominios = Request.Url.Authority;
            if (_dominios == "localhost:2304")
            {
                clCorreo.EnvioLN(1, objMail);
            }
            else
            {
                clCorreo.EnvioLN(2, objMail);
            }
            //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
            //objSMTPClient.EnableSsl = true;
            //objSMTPClient.UseDefaultCredentials = false;
            //objSMTPClient.Credentials = new NetworkCredential("com21pagos@gmail.com", "C21PC#1988");
            //fin con puertos

            //sin puertos
            //SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
            //objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //fin de sin puertos

            //objSMTPClient.Send(objMail);
        }
    }
    private String cargarNombreApe()
    {
        String nom_ape = "";
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_cliente_id(id);
        if (_user.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _user.Tables[0].Rows)
            {
                nom_ape = r["Nombres"].ToString() + " " + r["Apellidos"].ToString();
            }
        }
        return nom_ape;
    }
    private void cargarDatos()
    {
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_cliente_id(id);
        if (_user.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _user.Tables[0].Rows)
            {
                lblnombres.Text = r["Nombres"].ToString();
                lblapellidos.Text = r["Apellidos"].ToString();
            }
        }
    }
    private void cargarDireccionEnvio()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
        if (_direccion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _direccion.Tables[0].Rows)
            {
                direccion.Text = "Dirección: " + r["Direccion"].ToString() + ", Lugar de envio: " + r["Pais"].ToString() + "/" + r["Provincia"].ToString() + "/" + r["Ciudad"].ToString();
                lbltelefonoenvio.Text = r["Telefono"].ToString();
                lblnombreenvio.Text = r["ContactoNombre"].ToString();
            }
        }        
    }
    #region "FUNCIONES INVENTARIO"
    //private void ingresarinventario(int Id_Producto, int Cantidad, string Pvp, string PrecioCompra, string Ident, string IdentCV)
    private void ingresarinventario(DataSet _ds)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Productos/>");

        foreach (DataRow r in _ds.Tables[0].Rows)
        {
            _xmlDatos.DocumentElement.SetAttribute("Id_Producto", r["Id_Producto"].ToString());
            _xmlDatos.DocumentElement.SetAttribute("Cantidad", r["Cantidad"].ToString());
            _xmlDatos.DocumentElement.SetAttribute("Precio", r["Precio"].ToString().Replace(',','.'));
            _xmlDatos.DocumentElement.SetAttribute("PrecioCompra", r["PrecioCompra"].ToString().Replace(',','.'));
            _xmlDatos.DocumentElement.SetAttribute("Identificador", "N");
            _xmlDatos.DocumentElement.SetAttribute("IdentificadorCV", "Venta");

            if (_consulta.Com21_ingresa_inventario_productos(_xmlDatos.OuterXml))
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Inventario');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
            }
        }
    }
    #endregion
    private void IngresarOrden()
    {
        String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            if (DataC.Length > 0)
            {
                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                if (_consulta.proc_ingresa_ordenes(DataC[4] + "", int.Parse(Request.Cookies["IdCom21Web"].Value), DataC[1] + ""))
                {
                }
                else
                {
                }
            }
    }

    #region "CANCELAR CARRITO"
    private void cancelarCarrito()
    {
        classRandom _rand = new classRandom();
        String _cod = _rand.NextString(11, true, true, true, false);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {
            if (DataC[2].ToString().Equals("-1"))
            {
                XmlDocument _xmlDatos = new XmlDocument();

                string idt = DataC[1] + "";
                _xmlDatos.LoadXml("<Transaccion/>");
                _xmlDatos.DocumentElement.SetAttribute("Lote", "");
                _xmlDatos.DocumentElement.SetAttribute("Referencia", "");
                _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Cancelada");
                if (_consulta.proc_Actualiza_Transaccion(_xmlDatos.OuterXml, idt))
                {
                }
                else
                {
                }
                cancelar(_cod, 2);
            }
            else
            {
                cancelar(_cod, 0);
            }
        }
    }
    private void cancelar(String _cod, int tabla)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(Request.Cookies["IdCom21Web"].Value));
        if (_ds.Tables[tabla].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[tabla].Rows)
            {
                if (_consulta.proc_actualiza_cantidad_producto_id(int.Parse(r["Cantidad"] + ""), int.Parse(r["Id_Producto"] + "")))
                {
                }
                else
                {
                    //cargarCarrito();
                }
            }

            string _codUP = DataC[4] + "";
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Prefactura/>");
            _xmlDatos.DocumentElement.SetAttribute("IdEstado", "2");

            if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP))
            {
            }
            else
            {
                cargarCarrito();
            }

            EditarDatosCompra(_cod, int.Parse(Request.Cookies["IdCom21Web"].Value));
            // EditarDatosCompra(DataC[4] + "", int.Parse(Request.Cookies["IdCom21Web"].Value));
        }
    }
    private void EditarDatosCompra(String _cod, int idusuario)
    {
        classRandom _rand = new classRandom();
        String _cod2 = _rand.NextString(11, true, true, true, false);
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod2);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, idusuario))
        { }
        else
        { }
    }
    #endregion
}