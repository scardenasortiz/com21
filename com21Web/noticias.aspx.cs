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


public partial class noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*Control ctrCurrentZdollor = LoadControl("productosrelacionados.ascx");
            productos_relacionados.Controls.Add(ctrCurrentZdollor);*/
            cargarnoticiasGrid("0","0");
            lbltitulo.Text = "Noticias";
        }
    }
    private void cargarnoticiasGrid(String inicio, String fin)
    {
        String _inicio = "";
        String _fin = "";
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        hftipo.Value = "0";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int i = 0;
        int j = 1;
        
                
                int num = int.Parse(ddlselect.SelectedItem.ToString());
                DataSet _prod = _consultar.Com21_consulta_noticias_numero(num, 150);
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
                                                  "<div class=\"desc grid-desc\">" + r["DescripcionCorta"].ToString() + "</div><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div><div class=\"label-product\"></div></li>";
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
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten noticias actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    private void cargarnoticiasList(String inicio, String fin)
    {
        ServicioCom21.ServicioCom21 _consultar = new ServicioCom21.ServicioCom21();
        String _inicio = "";
        String _fin = "";
        hftipo.Value = "1";
        classCom21Random _ident = new classCom21Random();
        String _generar = "";
        int i = 1;
        int j = 1;
                int num = int.Parse(ddlselect.SelectedItem.ToString());

                DataSet _prod = _consultar.Com21_consulta_noticias_numero(num, 600);
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
                                                  "<div class=\"desc std\"><p>" + r["DescripcionCorta"].ToString() + "</p><a href=\"" + r["Url"].ToString() + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"link-learn\">Más información</a></div></div></li>";
                        i = i + 1;
                        j = j + 1;

                    }
                    _generar = _generar + "</ol>";
                    servicios_web.InnerHtml = _generar;
                }
                else
                {
                    String _url = Request.Url.AbsoluteUri;
                    servicios_web.InnerHtml = "<div style=\"font-size:18px;\">No exiten noticias actualmente.&nbsp;<a href=\"" + _url + "\"><img alt=\"\" src=\"images/imagenes/icons_variados_theme_negro/_refresh.png\" width=\"24\" height=\"24\" title=\"Cargar Productos\" /></a></div>";
                }
    }
    protected void ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarnoticiasGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarnoticiasList("0", "0");
            }

        }
    }
    protected void ddlselect1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (hftipo.Value == "0")
        {
            if (hfidmarca.Value == "0")
            {
                cargarnoticiasGrid("0", "0");
            }
        }
        else
        {
            if (hfidmarca.Value == "0")
            {
                cargarnoticiasList("0", "0");
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
            cargarnoticiasGrid("0", "0");
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
            cargarnoticiasList("0", "0");
        }
    }
}
