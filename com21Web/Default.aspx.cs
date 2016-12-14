using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarpubli();
            cargarservicios();
            cargarslider();
            cargarproductos();

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
                        bannerhead.Visible = false;
                        logohead.Visible = true;
                        etiquetasTitulos.Attributes.CssStyle.Add("width", "100%");
                        etiquetasTitulos2.Attributes.CssStyle.Add("width", "100%");
                    }
                    else
                    {
                        lblusernomb.Text = Request.Cookies["UserCom21Web"].Value;
                        pInicio.Visible = false;
                        pInicioSesion.Visible = true;
                        pInicioRelogin.Visible = false;
                        pInicioRe.Visible = false;
                        bannerhead.Visible = true;
                        logohead.Visible = false;
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
                        bannerhead.Visible = false;
                        logohead.Visible = true;
                        etiquetasTitulos.Attributes.CssStyle.Add("width", "100%");
                        etiquetasTitulos2.Attributes.CssStyle.Add("width", "100%");
                    }
                    else
                    {
                        pInicio.Visible = true;
                        pInicioSesion.Visible = false;
                        pInicioRelogin.Visible = false;
                        pInicioRe.Visible = false;
                        bannerhead.Visible = true;
                        logohead.Visible = false;
                    }
                }
            }
        }
    }
    private void cargarInfoCarrito()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _det = _consulta.consulta_producto_prefacturado_id_user_cant_tot();
        if ((_det.Tables[1].Rows.Count > 0) && (_det.Tables[0].Rows.Count > 0))
        {
            foreach (DataRow r in _det.Tables[1].Rows)
            {
                if (!String.IsNullOrEmpty(r["Cantidad"].ToString()))
                {
                    lblitemscarrito.Text = r["Cantidad"].ToString() + " item(s)";
                }
                else
                {
                    lblitemscarrito.Text = "0 item(s)";
                }
            }
            foreach (DataRow r in _det.Tables[0].Rows)
            {
                if (!String.IsNullOrEmpty(r["Total"].ToString()))
                {
                    lbltotalcarrito.Text = "$" + r["Total"].ToString();
                }
                else
                {
                    lbltotalcarrito.Text = "$0.00";
                }
            }
        }
        else
        {
            lblitemscarrito.Text = "0 item(s)";
            lbltotalcarrito.Text = "$0.00";
        }
    }
    private void cargarpubli()
    {
        ServicioCom21.ServicioCom21 _user = new ServicioCom21.ServicioCom21();
        DataSet _promo = _user.Com21_consulta_promo_publi_mostrar();
        int total = _promo.Tables[0].Rows.Count;
        String _img = "";
        int i = 0;
        if (total > 0)
        {
            switch (total)
            {
                case 1:
                    foreach (DataRow r in _promo.Tables[0].Rows)
                    {
                        if ((r["Activar"].ToString() == "True") || (r["Activar"].ToString() == "true"))
                        {
                            if (r["ActPro"].ToString() == "1")
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" width=\"370\" height=\"136\" /></a>";
                            }
                            else
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" width=\"370\" height=\"136\" /></a>";
                            }

                            if (i == 0)
                            {
                                publi1.InnerHtml = _img;
                            }
                            i = i + 1;
                        }
                    }
                    publi2.InnerHtml = "<img src=\"images/promo_publi_sin.jpg\" alt=\"\"/>";
                    publi3.InnerHtml = "<img src=\"images/promo_publi_sin.jpg\" alt=\"\"/>";
                    break;
                case 2:
                    foreach (DataRow r in _promo.Tables[0].Rows)
                    {
                        if ((r["Activar"].ToString() == "True") || (r["Activar"].ToString() == "true"))
                        {
                            if (r["ActPro"].ToString() == "1")
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" width=\"370\" height=\"136\" /></a>";
                            }
                            else
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" width=\"370\" height=\"136\" /></a>";
                            }

                            if (i == 0)
                            {
                                publi1.InnerHtml = _img;
                            }
                            if (i == 1)
                            {
                                publi2.InnerHtml = _img;
                            }
                            i = i + 1;
                        }
                    }                    
                    publi3.InnerHtml = "<img src=\"images/promo_publi_sin.jpg\" alt=\"\"/>";
                    break;
                case 3:
                    foreach (DataRow r in _promo.Tables[0].Rows)
                    {
                        if ((r["Activar"].ToString() == "True") || (r["Activar"].ToString() == "true"))
                        {
                            if (r["ActPro"].ToString() == "1")
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" /></a>";
                            }
                            else
                            {
                                _img = "<a href=\"" + r["Link"].ToString() + "\" target='_blank'><img src=\"" + r["Ruta"].ToString().Substring(2) + "\" alt=\"\" /></a>";
                            }

                            if (i == 0)
                            {
                                publi1.InnerHtml = _img;
                            }
                            if (i == 1)
                            {
                                publi2.InnerHtml = _img;
                            }
                            if (i == 2)
                            {
                                publi3.InnerHtml = _img;
                            }
                            i = i + 1;
                        }
                    }
                    break;
            }
        }
    }
    private void cargarservicios()
    {
        ServicioCom21.ServicioCom21 _user = new ServicioCom21.ServicioCom21();
        DataSet _servi = _user.Com21_consulta_servicios_mostrar();
        if (_servi.Tables[0].Rows.Count > 0)
        {
            dtservi.DataSource = _servi.Tables[0];
            dtservi.DataBind();
        }
    }
    private void cargarslider()
    {
        String _sliders = "<div class=\"camera_wrap camera_orange_skin\" id=\"camera_wrap\">";
        ServicioCom21.ServicioCom21 _user = new ServicioCom21.ServicioCom21();
        DataSet _slider = _user.Com21_consulta_slide_mostrar();
        if (_slider.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _slider.Tables[0].Rows)
            {
                _sliders = _sliders + "<div data-link=\"#\" data-src=\"" + r["Rutas"].ToString() + "\"></div>";
            }
        }
        _sliders = _sliders + "</div>";
        sliders.InnerHtml = _sliders;
    }
    private void cargarproductos()
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        DataSet _prod = _consultar.Com21_consulta_productos_web_numero(4, 0, 0);
        if (_prod.Tables[1].Rows.Count > 0)
        {
            int i = 0;
            String _generar = "<ul class='products-grid row'>";
            foreach (DataRow r in _prod.Tables[1].Rows)
            {
                if (i == 0)
                {
                    _generar = _generar + "<li class='item first span3'>";
                }
                if ((i >= 1) && (i <= 2))
                {
                    _generar = _generar + "<li class='item span3'>";
                }
                if (i == 3)
                {
                    _generar = _generar + "<li class='item last span3'>";
                }
                if (r["Descuento"].ToString() == "0")
                {
                    _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a>" +
                                          "<div class=\"product-shop\"><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-" + r["Id_Producto"].ToString() + "-new\">";
                    //if()
                    _generar = _generar + "<span class=\"price\">$" + r["Precio"].ToString() + "</span></span></div>";
                    _generar = _generar + "<h3 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h3>" +
                                          "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Leer Más\" class=\"link-learn\"><img src='images/Leermas.gif' alt='Leer Más' height='22' width='22' /></a></div></li>";
                }
                else
                {
                    _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a>" +
                                          "<div class=\"product-shop\"><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-" + r["Id_Producto"].ToString() + "-new\"><span class=\"price\">$" + r["Precio"].ToString() + "</span></span></div>" +
                                          "<h3 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h3>" +
                                          "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Leer Más\" class=\"link-learn\"><img src='images/Leermas.gif' alt='Leer Más' height='22' width='22' /></a></div></li>";
                }
                i = i + 1;
            }
            _generar = _generar + "</ul>";
            productos_nuevos.InnerHtml = _generar;
        }
    }

    #region "BUSCAR"
    protected void btnbuscar1_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search1.Text);
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search.Text);
    }
    #endregion
}