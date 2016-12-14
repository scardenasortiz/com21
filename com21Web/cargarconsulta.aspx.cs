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


public partial class cargarconsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["texto"] != null)
            {
                lbltitulo.Text = Request.QueryString["texto"].ToString();
            }
            cargarproductosGrid("0","0");
            cargarserviciosGrid("0", "0");
            if ((hfprodt.Value == "0") && (hfserv.Value == "0"))
            {
                String _url = Request.Url.AbsoluteUri;
                productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;</div>";
            }
        }
    }
    #region "METODO PARA CARGAR LA INFORMACIÓN"
    private void cargarproductosGrid(String inicio, String fin)
    {
        String _inicio = "";
        String _fin = "";
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        hftipo.Value = "0";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        String texto = "";
        int i = 0;
        int j = 1;
        if (Request.QueryString["texto"] != null)
        {
                texto = Request.QueryString["texto"].ToString();
                //subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_productos_web_numero_busqueda(num, texto, 150);
                if ((lblitems1.Text == "0") && (lblitems.Text == "0"))
                {
                    lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count + int.Parse(lblitems1.Text));
                    lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count + int.Parse(lblitems.Text));
                }
                if (_prod.Tables[0].Rows.Count > 0)
                {
                    hfprodt.Value = "1";
                    lblproductonombre.Text = "Productos";
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

                        _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\">" +
                                              "<div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                              "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div></div><div class=\"label-product\"></div></li>";

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
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    hfprodt.Value = "0";
                    /*String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";*/
                }
        }
    }
    private void cargarproductosList(String inicio, String fin)
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        String _inicio = "";
        String _fin = "";
        hftipo.Value = "1";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        string texto = "";
        int subcat = 0;
        int i = 1;
        int j = 1;
        if (Request.QueryString["texto"] != null)
        {
            hfprodt.Value = "1";
                texto = Request.QueryString["texto"].ToString();
                //subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_productos_web_numero_busqueda(num, texto, 600);
                //lblitems1.Text = Convert.ToString(_prod.Tables[0].Rows.Count + int.Parse(lblitems1.Text));
                //lblitems.Text = Convert.ToString(_prod.Tables[0].Rows.Count + int.Parse(lblitems.Text));
                int total = _prod.Tables[0].Rows.Count;
                if (_prod.Tables[0].Rows.Count > 0)
                {
                    hfprodt.Value = "1";
                    lblproductonombre.Text = "Productos";
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div></div></li>";
                            //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div></div></div></li>";
                            //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box map-info\"><span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Nuevo Precio\" class=\"link-learn\">Nuevo Precio</a></div></div></li>";
                        }
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    hfprodt.Value = "0";
                    /*String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";*/
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
        String texto = "";
        int i = 0;
        int j = 1;
        if (Request.QueryString["texto"] != null)
        {
         
            texto = Request.QueryString["texto"].ToString();
            //subcat = int.Parse(Request.QueryString["Sub"].ToString());
            int num = int.Parse(ddlselect.SelectedItem.ToString());
            DataSet _prod = _consultar.Com21_consulta_productos_web_numero_busqueda(num, texto, 150);
            if ((lblitems1.Text == "0") && (lblitems.Text == "0"))
            {
                lblitems1.Text = Convert.ToString(_prod.Tables[2].Rows.Count + int.Parse(lblitems1.Text));
                lblitems.Text = Convert.ToString(_prod.Tables[2].Rows.Count + int.Parse(lblitems.Text));
            }
            if (_prod.Tables[2].Rows.Count > 0)
            {
                hfserv.Value = "1";
                lblserviciosnombres.Text = "Servicios";
                foreach (DataRow r in _prod.Tables[2].Rows)
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
                                              "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div></div><div class=\"label-product\"></div></li>";
                    
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
                hfserv.Value = "0";
                /*String _url = Request.Url.AbsoluteUri;
                servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";*/
            }
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
        string texto = "";
        int subcat = 0;
        int i = 1;
        int j = 1;
        if (Request.QueryString["texto"] != null)
        {
            //if (ddlprecio.SelectedValue == "0")
            //{
            texto = Request.QueryString["texto"].ToString();
            //subcat = int.Parse(Request.QueryString["Sub"].ToString());
            int num = int.Parse(ddlselect.SelectedItem.ToString());

            DataSet _prod = _consultar.Com21_consulta_productos_web_numero_busqueda(num, texto, 600);
            int total = _prod.Tables[2].Rows.Count;
            
             //   lblitems1.Text = Convert.ToString(_prod.Tables[2].Rows.Count + int.Parse(lblitems1.Text));
              //  lblitems.Text = Convert.ToString(_prod.Tables[2].Rows.Count + int.Parse(lblitems.Text));            
            
            if (_prod.Tables[2].Rows.Count > 0)
            {
                hfserv.Value = "1";
                lblproductonombre.Text = "Productos";
                _generar = "<ol class=\"products-list\" id=\"products-list\">";
                foreach (DataRow r in _prod.Tables[2].Rows)
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
                                              "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div></div></li>";
                        //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                    i = i + 1;
                    j = j + 1;

                }
                _generar = _generar + "</ol>";
                servicios_web.InnerHtml = _generar;
            }
            else
            {
                hfserv.Value = "1";
                /*String _url = Request.Url.AbsoluteUri;
                servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";*/
            }
        }


    }
    protected void ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosGrid("0", "0");
                cargarserviciosGrid("0", "0");
            }
            //else
            //{
            //    cargarproductosMarcaGrid("0", "0");
            //}
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosList("0", "0");
                cargarserviciosList("0", "0");
            }
            //else
            //{
            //    cargarproductosMarcaList("0", "0");
            //}
        }
    }
    protected void ddlselect1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosGrid("0", "0");
                cargarserviciosGrid("0", "0");
            }
            //else
            //{
            //    cargarproductosMarcaGrid("0", "0");
            //}
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosList("0", "0");
                cargarserviciosList("0", "0");
            }
            //else
            //{
            //    cargarproductosMarcaList("0", "0");
            //}
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
            cargarproductosGrid("0", "0");
            cargarserviciosGrid("0", "0");
        }
        //else
        //{
        //    cargarproductosMarcaGrid("0", "0");
        //}
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
            cargarproductosList("0", "0");
            cargarserviciosList("0", "0");
        }
        //else
        //{
        //    cargarproductosMarcaList("0", "0");
        //}
    }
    #endregion
}
