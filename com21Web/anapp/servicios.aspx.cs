using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;

public partial class anapp_servicios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CargarProductos_POST();
            cargarDatos();
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataTable _dtO = _consulta.Com21_consulta_servicios_app().Tables[0];
        ViewState["ds"] = _dtO;
    }
    #region "carga servicios anteriores"
    //private void cargarDatos()
    //{
    //    String PresentarO = "<ol class=\"products-list\" id=\"products-list\">";
    //    String PresentarTO = "<div class=\"page-title category-title\"><h1>Servicios</h1></div>";
    //    String PresentarNTO = "<ul class=\"list-iconsdivi row\" style=\"width: 98%;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 2px; height: 40px;\"> &nbsp; &nbsp;Servicios &nbsp;</li></ul>";
        
    //    //ofertas
    //    String url = "";
    //    DataTable _dtO = (DataTable)ViewState["ds"];
    //    foreach (DataRow r in _dtO.Rows)
    //    {
    //        url = "Presentar.aspx?ID=" + r["Id_Servicio"].ToString() + "&T=S";
    //        PresentarO = PresentarO + "<li class=\"item\">" +
    //        "<a href=\"" + url + "\" title=\"" + r["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
    //        "<img src=\".." + r["Ruta"].ToString() + "\" alt=\"" + r["Titulo"].ToString() + "\"></a>" +
    //        "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
    //        "<a href=\"" + url + "\" title=\"" + r["Titulo"].ToString() + "\">" +
    //        "" + r["Titulo"].ToString() + "</a></h2>" +
    //            //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
    //            //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
    //        "</div></div></li>";
    //    }
    //    PresentarO = PresentarO + "</ol>";

    //    mostrar.InnerHtml = PresentarO;
    //}
    #endregion

    private void cargarDatos()
    {
        String PresentarO = "<div data-role=\"page\" class=\"type-home\"><div data-role=\"header\" data-position=\"fixed\"><h1>Servicios</h1></div>" +
            "<div data-role=\"content\" style=\"overflow-y:auto;\"><ul data-role=\"listview\" data-inset=\"true\" data-theme=\"c\" data-dividertheme=\"a\">";

        String url = "";
        DataTable _dtO = (DataTable)ViewState["ds"];
        foreach (DataRow r in _dtO.Rows)
        {
            url = "Presentar.aspx?ID=" + r["Id_Servicio"].ToString() + "&T=S";
            PresentarO = PresentarO + "<li><a href=\"" + url + "\" data-ajax=\"false\"> <img src=\".." + r["Ruta"].ToString() + "\"><h1> " + r["Titulo"].ToString() + " </h1><p>" + r["DescripcioCorta"].ToString() + "</p></a></li>";
        }
        PresentarO = PresentarO + "</ul></div></div>";

        mostrar.InnerHtml = PresentarO;
    }
}