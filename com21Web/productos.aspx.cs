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


public partial class productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarSubCat();
            cargarMarcas();
            cargarproductosRelacionados();
            /*Control ctrCurrentZdollor = LoadControl("productosrelacionados.ascx");
            productos_relacionados.Controls.Add(ctrCurrentZdollor);*/
            cargarproductosGrid("0","0");
        }
    }
    private void cargarproductosGrid(String inicio, String fin)
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
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            if (ddlprecio.SelectedValue == "0")
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_productos_web_numero(num, subcat, 150);
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box\">" +
                                                  "<span class=\"regular-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box map-info\">" +
                                                  "<span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span></span><a href=\"#\" id=\"msrp-click-" + _codident + "\">Nuevo precio</a>" +
                                /*"<script type=\"text/javascript\">"+
                                "var newLink = Catalog.Map.addHelpLink(" +
                                "$('msrp-click-" + r["Id_Producto"].ToString() + "" + _codident + "')," +
                                "" + r["Titulo"].ToString() + "\"," +
                                "'\n\n                \n    <div class=\"price-box\">\n                                \n                    <p class=\"old-price\">\n                <span class=\"price-label\">Precio Normal:</span>\n                <span class=\"price\" id=\"old-price-2\">\n                    $" + r["Precio"].ToString() + "               </span>\n            </p>\n\n                        <p class=\"special-price\">\n                <span class=\"price-label\">Precio Especial:</span>\n                <span class=\"price\" id=\"product-price-2\">\n                    $700.00                </span>\n            </p>\n                    \n    \n        </div>\n\n'," +
                                "'<span class=\"price\">$" + nuevo_precio + "</span>');" +*/
                                                  "</div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
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
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
            else
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                if (ddlprecio.SelectedValue == "1")
                {
                    _inicio = "0";
                    _fin = "500.00";
                }
                if (ddlprecio.SelectedValue == "2")
                {
                    _inicio = "500.01";
                    _fin = "800.00";
                }
                if (ddlprecio.SelectedValue == "3")
                {
                    _inicio = "800.01";
                    _fin = "1000.00";
                }
                if (ddlprecio.SelectedValue == "4")
                {
                    _inicio = "1000.01";
                    _fin = "1000.01";
                }

                DataSet _prod = _consultar.Com21_consulta_productos_web_precio(_inicio, _fin, num, subcat, 150, int.Parse(ddlprecio.SelectedValue.ToString()));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box\">" +
                                                  "<span class=\"regular-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box map-info\">" +
                                                  "<span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span></span><a href=\"#\" id=\"msrp-click-" + _codident + "\">Nuevo precio</a>" +
                                /*"<script type=\"text/javascript\">"+
                                "var newLink = Catalog.Map.addHelpLink(" +
                                "$('msrp-click-" + r["Id_Producto"].ToString() + "" + _codident + "')," +
                                "" + r["Titulo"].ToString() + "\"," +
                                "'\n\n                \n    <div class=\"price-box\">\n                                \n                    <p class=\"old-price\">\n                <span class=\"price-label\">Precio Normal:</span>\n                <span class=\"price\" id=\"old-price-2\">\n                    $" + r["Precio"].ToString() + "               </span>\n            </p>\n\n                        <p class=\"special-price\">\n                <span class=\"price-label\">Precio Especial:</span>\n                <span class=\"price\" id=\"product-price-2\">\n                    $700.00                </span>\n            </p>\n                    \n    \n        </div>\n\n'," +
                                "'<span class=\"price\">$" + nuevo_precio + "</span>');" +*/
                                                  "</div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
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
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
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
        int cat = 0;
        int subcat = 0;
        int i = 1;
        int j = 1;
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            if (ddlprecio.SelectedValue == "0")
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                
                DataSet _prod = _consultar.Com21_consulta_productos_web_numero(num, subcat, 600);
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box map-info\"><span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Nuevo Precio\" class=\"link-learn\">Nuevo Precio</a></div></div></li>";
                        }
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
            else
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                if (ddlprecio.SelectedValue == "1")
                {
                    _inicio = "0";
                    _fin = "500.00";
                }
                if (ddlprecio.SelectedValue == "2")
                {
                    _inicio = "500.01";
                    _fin = "800.00";
                }
                if (ddlprecio.SelectedValue == "3")
                {
                    _inicio = "800.01";
                    _fin = "1000.00";
                }
                if (ddlprecio.SelectedValue == "4")
                {
                    _inicio = "1000.01";
                    _fin = "1000.01";
                }

                DataSet _prod = _consultar.Com21_consulta_productos_web_precio(_inicio, _fin, num, subcat, 600, int.Parse(ddlprecio.SelectedValue.ToString()));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box map-info\"><span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Nuevo Precio\" class=\"link-learn\">Nuevo Precio</a></div></div></li>";
                        }
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
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
            }
            else
            {
                cargarproductosMarcaGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosList("0", "0");
            }
            else
            {
                cargarproductosMarcaList("0", "0");
            }
        }
    }
    protected void ddlselect1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosGrid("0", "0");
            }
            else
            {
                cargarproductosMarcaGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarproductosList("0", "0");
            }
            else
            {
                cargarproductosMarcaList("0", "0");
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
            cargarproductosGrid("0", "0");
        }
        else
        {
            cargarproductosMarcaGrid("0", "0");
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
            cargarproductosList("0", "0");
        }
        else
        {
            cargarproductosMarcaList("0", "0");
        }
    }
    private void cargarSubCat()
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        if (Request.QueryString["Sub"] != null)
        {
            string subcat = Request.QueryString["Sub"].ToString();
            DataSet _sub = _consultar.Com21_consulta_scategoria_id(int.Parse(subcat));
            if (_sub.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow r in _sub.Tables[2].Rows)
                {
                    lbltitulo.Text = r[1].ToString();
                }
            }
        }
    }
    private void cargarMarcas()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if (Request.QueryString["Sub"] != null)
        {
            string subcat = Request.QueryString["Sub"].ToString();
            DataSet _marcas = _consulta.Com21_consulta_productos_marca_sub(int.Parse(subcat));
            if(_marcas.Tables[0].Rows.Count > 0)
            {
                dtmarca.DataSource = _marcas.Tables[0];
                dtmarca.DataBind();
            }
        }
    }
    protected void dtmarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataListItem _dt = dtmarca.SelectedItem;

        HiddenField _marca = default(HiddenField);
        _marca = (HiddenField)_dt.FindControl("hfmarca");
        hfidmarca.Value = _marca.Value;

        if (hftipo.Value == "0")
        {
            cargarproductosMarcaGrid("0", "0");
        }
        else
        {
            cargarproductosMarcaList("0","0");
        }
    }
    private void cargarproductosMarcaGrid(String inicio, String fin)
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
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            if (ddlprecio.SelectedValue == "0")
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_productos_web_numero_marca_id(num, subcat, 150, int.Parse(hfidmarca.Value));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box\">" +
                                                  "<span class=\"regular-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box map-info\">" +
                                                  "<span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span></span><a href=\"#\" id=\"msrp-click-" + _codident + "\">Nuevo precio</a>" +
                                /*"<script type=\"text/javascript\">"+
                                "var newLink = Catalog.Map.addHelpLink(" +
                                "$('msrp-click-" + r["Id_Producto"].ToString() + "" + _codident + "')," +
                                "" + r["Titulo"].ToString() + "\"," +
                                "'\n\n                \n    <div class=\"price-box\">\n                                \n                    <p class=\"old-price\">\n                <span class=\"price-label\">Precio Normal:</span>\n                <span class=\"price\" id=\"old-price-2\">\n                    $" + r["Precio"].ToString() + "               </span>\n            </p>\n\n                        <p class=\"special-price\">\n                <span class=\"price-label\">Precio Especial:</span>\n                <span class=\"price\" id=\"product-price-2\">\n                    $700.00                </span>\n            </p>\n                    \n    \n        </div>\n\n'," +
                                "'<span class=\"price\">$" + nuevo_precio + "</span>');" +*/
                                                  "</div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
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
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
            else
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                if (ddlprecio.SelectedValue == "1")
                {
                    _inicio = "0";
                    _fin = "500.00";
                }
                if (ddlprecio.SelectedValue == "2")
                {
                    _inicio = "500.01";
                    _fin = "800.00";
                }
                if (ddlprecio.SelectedValue == "3")
                {
                    _inicio = "800.01";
                    _fin = "1000.00";
                }
                if (ddlprecio.SelectedValue == "4")
                {
                    _inicio = "1000.01";
                    _fin = "1000.01";
                }

                DataSet _prod = _consultar.Com21_consulta_productos_web_marcar(_inicio, _fin, num, subcat, 150, int.Parse(ddlprecio.SelectedValue.ToString()), int.Parse(hfidmarca.Value));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box\">" +
                                                  "<span class=\"regular-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"price-box map-info\">" +
                                                  "<span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span></span><a href=\"#\" id=\"msrp-click-" + _codident + "\">Nuevo precio</a>" +
                                /*"<script type=\"text/javascript\">"+
                                "var newLink = Catalog.Map.addHelpLink(" +
                                "$('msrp-click-" + r["Id_Producto"].ToString() + "" + _codident + "')," +
                                "" + r["Titulo"].ToString() + "\"," +
                                "'\n\n                \n    <div class=\"price-box\">\n                                \n                    <p class=\"old-price\">\n                <span class=\"price-label\">Precio Normal:</span>\n                <span class=\"price\" id=\"old-price-2\">\n                    $" + r["Precio"].ToString() + "               </span>\n            </p>\n\n                        <p class=\"special-price\">\n                <span class=\"price-label\">Precio Especial:</span>\n                <span class=\"price\" id=\"product-price-2\">\n                    $700.00                </span>\n            </p>\n                    \n    \n        </div>\n\n'," +
                                "'<span class=\"price\">$" + nuevo_precio + "</span>');" +*/
                                                  "</div><div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc grid-desc\">" + r["DescripcioCorta"].ToString() + "</div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
                        }
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
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
        }
    }
    private void cargarproductosMarcaList(String inicio, String fin)
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
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            if (ddlprecio.SelectedValue == "0")
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_productos_web_numero_marca_id(num, subcat, 600, int.Parse(hfidmarca.Value));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box map-info\"><span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Nuevo Precio\" class=\"link-learn\">Nuevo Precio</a></div></div></li>";
                        }
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
            else
            {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                subcat = int.Parse(Request.QueryString["Sub"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                if (ddlprecio.SelectedValue == "1")
                {
                    _inicio = "0";
                    _fin = "500.00";
                }
                if (ddlprecio.SelectedValue == "2")
                {
                    _inicio = "500.01";
                    _fin = "800.00";
                }
                if (ddlprecio.SelectedValue == "3")
                {
                    _inicio = "800.01";
                    _fin = "1000.00";
                }
                if (ddlprecio.SelectedValue == "4")
                {
                    _inicio = "1000.01";
                    _fin = "1000.01";
                }

                DataSet _prod = _consultar.Com21_consulta_productos_web_marcar(_inicio, _fin, num, subcat, 600, int.Parse(ddlprecio.SelectedValue.ToString()), int.Parse(hfidmarca.Value));
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
                        if (r["Descuento"].ToString() == "0")
                        {
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
                        }
                        else
                        {
                            String nuevo_precio = Convert.ToString((Convert.ToDouble(r["Precio"].ToString()) * Convert.ToDouble(r["Descuento"].ToString())) / 100);
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p></div><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box map-info\"><span class=\"old-price\" id=\"product-price-" + j + "\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"Nuevo Precio\" class=\"link-learn\">Nuevo Precio</a></div></div></li>";
                        }
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    productos_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    productos_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten productos actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            String _cat = Request.QueryString["Cat"];
            String _sub = Request.QueryString["Sub"];
            DataSet _prorel = _consulta.Com21_consulta_productos_web_categoria_nosub(int.Parse(_cat), int.Parse(_sub));
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
    private void cargarproductosRelacionados()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if ((Request.QueryString["Cat"] != null) && (Request.QueryString["Sub"] != null))
        {
            String _cat = Request.QueryString["Cat"];
            String _sub = Request.QueryString["Sub"];
            DataSet _prorel = _consulta.Com21_consulta_productos_web_categoria_nosub(int.Parse(_cat), int.Parse(_sub));
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
}
