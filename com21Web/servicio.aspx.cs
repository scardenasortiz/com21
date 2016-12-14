using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using com21DLL;
using System.Web.Security;
using System.Xml.Linq;


public partial class servicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*Control ctrCurrentZdollor = LoadControl("productosrelacionados.ascx");
            productos_relacionados.Controls.Add(ctrCurrentZdollor);*/
            cargarproductosRelacionados();
            cargarCategorias();
            cargarserviciosGrid("0","0");
            //lbltitulo.Text = "Servicios";
            string strUserAgent = Request.UserAgent.ToString().ToLower();

            
                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true ||
                            strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                            strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                    {
                       
                    }
                 }
        }
    }
    private void cargarserviciosGrid(String inicio, String fin)
    {
        String _inicio = "";
        String _fin = "";
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        hftipo.Value = "0";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int i = 0;
        int j = 1;

        lbltitulo.InnerHtml = "<h1>Servicios</h1>";
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_servicios_numero(num, 150);
                lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                if (_prod.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in _prod.Tables[0].Rows)
                    {
                        String _codident = _ident.NextString(21, true, true, true, false);
                        if (i == 0)
                        {
                            _generar = _generar + "<ul class='products-grid row'><li class='item first span3'>";

                        }
                        if ((i > 0) && (i <= 2))
                        {
                            _generar = _generar + "<li class='item span3'>";

                        }
                        _generar = _generar + "<a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\">" +
                                                  "<div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        if (i == 2)
                        {
                            _generar = _generar + "</ul>";
                            i = 0;
                        }
                        else
                        {
                            i = i + 1;
                        }
                        j = j + 1;

                    }
                    servicios_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten servicios actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    private void cargarserviciosList(String inicio, String fin)
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        String _inicio = "";
        String _fin = "";
        hftipo.Value = "1";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int i = 1;
        int j = 1;
        lbltitulo.InnerHtml = "<h1>Servicios</h1>";
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_servicios_numero(num, 600);
                lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                int total = _prod.Tables[0].Rows.Count;
                if (_prod.Tables[0].Rows.Count > 0)
                {
                    _generar = "<ol class=\"products-list\" id=\"products-list\">";
                    foreach (DataRow r in _prod.Tables[0].Rows)
                    {
                        String _codident = _ident.NextString(21, true, true, true, false);
                        if (i == total)
                        {
                            _generar = _generar + "<li class='item last'>";

                        }
                        else
                        {
                            _generar = _generar + "<li class='item'>";

                        }
                            _generar = _generar + "<a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div></div></li>";
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    servicios_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten servicios actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    protected void ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarserviciosGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarserviciosList("0", "0");
            }

        }
    }
    protected void ddlselect1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarserviciosGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarserviciosList("0", "0");
            }
        }
    }
    protected void ibgrid_Click(object sender, ImageClickEventArgs e)
    {
        //List
        ImageButton2.ImageUrl = "~/images/listN.gif";
        iblist.ImageUrl = "~/images/listN.gif";
        //Grid
        ibgrid.ImageUrl = "~/images/gridV.gif";
        ImageButton1.ImageUrl = "~/images/gridV.gif";

        if (hfidmarca.Value == "0")
        {
            cargarserviciosGrid("0", "0");
        }
        else
        {
            cargarserviciosCategoriasGrid("0", "0");
        }
    }
    protected void iblist_Click(object sender, ImageClickEventArgs e)
    {
        //List
        ImageButton2.ImageUrl = "~/images/listV.gif";
        iblist.ImageUrl = "~/images/listV.gif";
        //Grid
        ibgrid.ImageUrl = "~/images/gridN.gif";
        ImageButton1.ImageUrl = "~/images/gridN.gif";

        if (hfidmarca.Value == "0")
        {
            cargarserviciosList("0", "0");
        }
        else
        {
            cargarserviciosCategoriasList("0","0");
        }
    }
    protected void dtcategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataListItem _dt = dtcategoria.SelectedItem;

        HiddenField _marca = default(HiddenField);
        _marca = (HiddenField)_dt.FindControl("hfmarca");
        HiddenField _tit = default(HiddenField);
        _tit = (HiddenField)_dt.FindControl("hftitulo");
        hfidmarca.Value = _marca.Value;
        lbltitulo.InnerHtml = "<h1 style=\"font-weight: normal;\"><a href=\"servicio.aspx\">Servicios</a> > " + _tit.Value + "</h1>";
        if (hftipo.Value == "0")
        {
            cargarserviciosCategoriasGrid("0", "0");
        }
        else
        {
            cargarserviciosCategoriasList("0", "0");
        }
    }
    private void cargarserviciosCategoriasGrid(String inicio, String fin)
    {
        String _inicio = "";
        String _fin = "";
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        hftipo.Value = "0";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int cat = 0;
        int subcat = 0;
        int i = 0;
        int j = 1;
        
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_servicios_web_numero_categoria_id(num, subcat, 150, int.Parse(hfidmarca.Value));
                lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                if (_prod.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in _prod.Tables[0].Rows)
                    {
                        String _codident = _ident.NextString(21, true, true, true, false);
                        if (i == 0)
                        {
                            _generar = _generar + "<ul class='products-grid row'><li class='item first span3'>";

                        }
                        if ((i > 0) && (i <= 2))
                        {
                            _generar = _generar + "<li class='item span3'>";

                        }
                        _generar = _generar + "<a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\">" +
                                                  "<div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        if (i == 2)
                        {
                            _generar = _generar + "</ul>";
                            i = 0;
                        }
                        else
                        {
                            i = i + 1;
                        }
                        j = j + 1;

                    }
                    servicios_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten servicios actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    private void cargarserviciosCategoriasList(String inicio, String fin)
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        String _inicio = "";
        String _fin = "";
        hftipo.Value = "1";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int cat = 0;
        int subcat = 0;
        int i = 1;
        int j = 1;
        
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_servicios_web_numero_categoria_id(num, subcat, 600, int.Parse(hfidmarca.Value));
                lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count);
                int total = _prod.Tables[0].Rows.Count;
                        if (_prod.Tables[0].Rows.Count > 0)
                {
                    _generar = "<ol class=\"products-list\" id=\"products-list\">";
                    foreach (DataRow r in _prod.Tables[0].Rows)
                    {
                        String _codident = _ident.NextString(21, true, true, true, false);
                        if (i == total)
                        {
                            _generar = _generar + "<li class='item last'>";

                        }
                        else
                        {
                            _generar = _generar + "<li class='item'>";

                        }
                            _generar = _generar + "<a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div></div></li>";
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    servicios_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten servicios actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    private void cargarCategorias()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        
            DataSet _marcas = _consulta.Com21_consulta_servicios_cat();
            if (_marcas.Tables[0].Rows.Count > 0)
            {
                dtcategoria.DataSource = _marcas.Tables[0];
                dtcategoria.DataBind();
            }
    }
    private void cargarproductosRelacionados()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _prorel = _consulta.Com21_consulta_servicios_web_Top5();
            if (_prorel.Tables[0].Rows.Count > 0)
            {
                String _generar = "<ol class=\"mini-products-list\" id=\"block-related\">";
                foreach (DataRow r in _prorel.Tables[0].Rows)
                {
                    _generar = _generar + "<li class=\"item\"><div class=\"product\">" +
                    "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a>" +
                    "<p class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\">" + r["Titulo"].ToString() + "</a></p><div class=\"product-details\"><div class=\"price-box\">";
                    if (r["Descuento"].ToString() == "0")
                    {
                        _generar = _generar + "<span class=\"regular-price\" id=\"product-price-9-related\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div>";
                    }
                    else
                    {
                        String _precio = Convert.ToString((decimal.Parse(r["Precio"].ToString()) * int.Parse(r["Descuento"].ToString())) / 100);
                        String _nue_pre = Convert.ToString(decimal.Parse(r["Precio"].ToString()) - decimal.Parse(_precio));
                        _generar = _generar + "<span class=\"old-price\" id=\"product-price-9-related\"><span class=\"price\">$" + r["Precio"].ToString() + "</span>&nbsp;<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + _nue_pre + "\"></a></span></div>";
                    }
                    _generar = _generar + "</div></div></li>";
                }
                _generar = _generar + "</ol>";
                productos_relacionados.InnerHtml = _generar;
            }
    }
}
