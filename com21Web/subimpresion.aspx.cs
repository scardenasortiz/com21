using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com21DLL;
using System.Data;

public partial class subimpresion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarCat();
            /*Control ctrCurrentZdollor = LoadControl("productosrelacionados.ascx");
            productos_relacionados.Controls.Add(ctrCurrentZdollor);*/
            cargarsuministrosGrid("0", "0");
        }
    }
    private void cargarsuministrosGrid(String inicio, String fin)
    {
        String _inicio = "";
        String _fin = "";
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        hftipo.Value = "0";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int cat = 0;
        int i = 0;
        int j = 1;
        if (Request.QueryString["Cat"] != null)
        {

                cat = int.Parse(Request.QueryString["Cat"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_categoria_numero_web(num, cat);
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
                        _generar = _generar + "<a href=\"productos.aspx?Cat=" + r["Id_Categoria"].ToString() + "&Sub=" + r["Id_SubCategoria"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\">" +
                                                  "<div class=\"clear\"></div><h2 class=\"product-name\"><a href=\"productos.aspx?Cat=" + r["Id_Categoria"].ToString() + "&Sub=" + r["Id_SubCategoria"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"label-product\"></div></li>";
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
    private void cargarsuministrosList(String inicio, String fin)
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
        if (Request.QueryString["Cat"] != null)
        {
                cat = int.Parse(Request.QueryString["Cat"].ToString());
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_categoria_numero_web(num, cat);
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
                            _generar = _generar + "<a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image\"><img src=\"" + r["RutaImg"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"/></a><div class=\"product-shop\"><div class=\"f-fix\">" +
                                                  "<h2 class=\"product-name\"><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\">" + r["Titulo"].ToString() + "</a></h2>" +
                                                  "<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p><a href=\"" + r["UrlProducto"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"price-box\"><span class=\"regular-price\" id=\"product-price-1\"><span class=\"price\">$" + r["Precio"].ToString() + "</span> </span></div></div></li>";
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
    protected void ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarsuministrosGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarsuministrosList("0", "0");
            }            
        }
    }
    protected void ddlselect1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarsuministrosGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarsuministrosList("0", "0");
            }
        }
    }
    protected void ibgrid_Click(object sender, ImageClickEventArgs e)
    {
        ////List
        //ImageButton2.ImageUrl = "~/images/listN.gif";
        //iblist.ImageUrl = "~/images/listN.gif";
        ////Grid
        //ibgrid.ImageUrl = "~/images/gridV.gif";
        //ImageButton1.ImageUrl = "~/images/gridV.gif";

        //if (hfidmarca.Value == "0")
        //{
        //    cargarsuministrosGrid("0", "0");
        //}
    }
    protected void iblist_Click(object sender, ImageClickEventArgs e)
    {
        ////List
        //ImageButton2.ImageUrl = "~/images/listV.gif";
        //iblist.ImageUrl = "~/images/listV.gif";
        ////Grid
        //ibgrid.ImageUrl = "~/images/gridN.gif";
        //ImageButton1.ImageUrl = "~/images/gridN.gif";

        //if (hfidmarca.Value == "0")
        //{
        //    cargarsuministrosList("0", "0");
        //}
        
    }
    private void cargarCat()
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        if (Request.QueryString["Cat"] != null)
        {
            string subcat = Request.QueryString["Cat"].ToString();
            DataSet _sub = _consultar.Com21_consulta_categoria_id(int.Parse(subcat));
            if (_sub.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow r in _sub.Tables[1].Rows)
                {
                    lbltitulo.Text = r["Categoria"].ToString();
                }
            }
        }
    }
}