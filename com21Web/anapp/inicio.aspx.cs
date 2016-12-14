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

public partial class anapp_inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarDatos();
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_portada();
        ViewState["ds"] = _ds;
    }
    private void cargarDatos()
    {
        DataSet _ds = (DataSet)ViewState["ds"];
        Session["dtportada"] = _ds;
        //ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        //XmlDocument _servicios = new XmlDocument();
        //String _dominio = "http://" + Request.Url.Authority;
        //DataSet _ds = _consulta.Com21_consulta_portada();
        String PresentarP = "<ol class=\"products-list\" id=\"products-list\">";
        String PresentarO = "<ol class=\"products-list\" id=\"products-list\">";
        String PresentarS = "<ol class=\"products-list\" id=\"products-list\">";

        //String PresentarTO = "<div class=\"page-title category-title\"><h1>Ofertas</h1></div>";
        //String PresentarTP = "<div class=\"page-title category-title\"><h1>Productos</h1></div>";
        //String PresentarTS = "<div class=\"page-title category-title\"><h1>Servicios</h1></div>";

        String PresentarNTP = "<ul class=\"list-iconsdivi row\" style=\"width: 100%; margin-top: 0px;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 1px; height: 40px; width: 100%;\"> &nbsp; &nbsp;Productos &nbsp;</li></ul>";
        String PresentarNTO = "<ul class=\"list-iconsdivi row\" style=\"width: 100%; margin-top: 0px;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 1px; height: 40px; width: 100%;\"> &nbsp; &nbsp;Ofertas &nbsp;</li></ul>";
        String PresentarNTS = "<ul class=\"list-iconsdivi row\" style=\"width: 100%; margin-top: 0px;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 1px; height: 40px; width: 100%;\"> &nbsp; &nbsp;Servicios &nbsp;</li></ul>";
        PresentarP = PresentarP + PresentarNTP;
        PresentarO = PresentarO + PresentarNTO;
        PresentarS = PresentarS + PresentarNTS;
        //productos
        String url = "";
        String urlp = "";
        //string path = Server.MapPath("http://designsie.com/anapp/productos.xml");        
            foreach (DataRow rp in _ds.Tables[0].Rows)
            {
                urlp = "Presentar.aspx?ID=" + rp["Id_Producto"].ToString() + "&T=IP";
                PresentarP = PresentarP + "<li class=\"item\">" +
                "<a href=\"" + urlp + "\" title=\"" + rp["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
                "<img src=\".." + rp["Ruta"].ToString() + "\" alt=\"" + rp["Titulo"].ToString() + "\"></a>" +
                "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
                "<a href=\"" + urlp + "\" title=\"" + rp["Titulo"].ToString() + "\">" +
                "" + rp["Titulo"].ToString() + "</a></h2>" +
                    //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
                    //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
                "</div></div></li>";
            }
            PresentarP = PresentarP + "</ol>";
            //ofertas
            String urlo = "";
            foreach (DataRow ro in _ds.Tables[2].Rows)
            {
                urlo = "Presentar.aspx?ID=" + ro["Id_Noticia"].ToString() + "&T=IO";
                PresentarO = PresentarO + "<li class=\"item\">" +
                "<a href=\"" + urlo + "\" title=\"" + ro["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
                "<img src=\".." + ro["Ruta"].ToString() + "\" alt=\"" + ro["Titulo"].ToString() + "\"></a>" +
                "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
                "<a href=\"" + urlo + "\" title=\"" + ro["Titulo"].ToString() + "\">" +
                "" + ro["Titulo"].ToString() + "</a></h2>" +
                    //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
                    //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
                "</div></div></li>";
            }
            PresentarO = PresentarO + "</ol>";

            //servicios
            String urls = "";
            foreach (DataRow rs in _ds.Tables[1].Rows)
            {
                urls = "Presentar.aspx?ID=" + rs["Id_Servicio"].ToString() + "&T=IS";
                PresentarS = PresentarS + "<li class=\"item\">" +
                "<a href=\"" + urls + "\" title=\"" + rs["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
                "<img src=\".." + rs["Ruta"].ToString() + "\" alt=\"" + rs["Titulo"].ToString() + "\"></a>" +
                "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
                "<a href=\"" + urls + "\" title=\"" + rs["Titulo"].ToString() + "\">" +
                "" + rs["Titulo"].ToString() + "</a></h2>" +
                    //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
                    //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
                "</div></div></li>";
            }
        PresentarS = PresentarS + "</ol>";

        mostrar.InnerHtml = PresentarP + PresentarO + PresentarS;
    }

    //private void cargarDatos()
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    XmlDocument _servicios = new XmlDocument();
    //    String _dominio = "http://" + Request.Url.Authority;
    //    DataSet _ds = _consulta.Com21_consulta_portada();
    //    String PresentarP = "<ol class=\"products-list\" id=\"products-list\">";
    //    String PresentarO = "<ol class=\"products-list\" id=\"products-list\">";
    //    String PresentarS = "<ol class=\"products-list\" id=\"products-list\">";

    //    //String PresentarTO = "<div class=\"page-title category-title\"><h1>Ofertas</h1></div>";
    //    //String PresentarTP = "<div class=\"page-title category-title\"><h1>Productos</h1></div>";
    //    //String PresentarTS = "<div class=\"page-title category-title\"><h1>Servicios</h1></div>";

    //    String PresentarNTP = "<ul class=\"list-iconsdivi row\" style=\"width: 98%;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 2px; height: 40px;\"> &nbsp; &nbsp;Productos &nbsp;</li></ul>";
    //    String PresentarNTO = "<ul class=\"list-iconsdivi row\" style=\"width: 98%;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 2px; height: 40px;\"> &nbsp; &nbsp;Ofertas &nbsp;</li></ul>";
    //    String PresentarNTS = "<ul class=\"list-iconsdivi row\" style=\"width: 98%;\"><li style=\"background: url('images/list-icon-bg3.png'); border-radius: 2px; height: 40px;\"> &nbsp; &nbsp;Servicios &nbsp;</li></ul>";
    //    PresentarP = PresentarP + PresentarNTP;
    //    PresentarO = PresentarO + PresentarNTO;
    //    PresentarS = PresentarS + PresentarNTS;
    //    //productos
    //    String url = "";
    //    String urlp = "";
    //    //string path = Server.MapPath("http://designsie.com/anapp/productos.xml");
    //    String _dominios = Request.Url.Authority;
    //    if (_dominios == "localhost:2304")
    //        _dominios = "http://" + _dominios + "/com21Web";
    //    else
    //        _dominio = "http://" + _dominio;
    //    String path = HttpContext.Current.Server.MapPath("inicial.xml");
    //    using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.GetEncoding("utf-8")))
    //    {
    //        writer.Formatting = Formatting.Indented;
    //        writer.WriteStartDocument();
    //        writer.WriteStartElement("Rows");
    //        foreach (DataRow rp in _ds.Tables[0].Rows)
    //        {
    //            urlp = "Presentar.aspx?ID=" + rp["Id_Producto"].ToString() + "&T=IP";
    //            PresentarP = PresentarP + "<li class=\"item\">" +
    //            "<a href=\"" + urlp + "\" title=\"" + rp["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
    //            "<img src=\".." + rp["Ruta"].ToString() + "\" alt=\"" + rp["Titulo"].ToString() + "\"></a>" +
    //            "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
    //            "<a href=\"" + urlp + "\" title=\"" + rp["Titulo"].ToString() + "\">" +
    //            "" + rp["Titulo"].ToString() + "</a></h2>" +
    //                //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
    //                //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
    //            "</div></div></li>";

    //            writer.WriteStartElement("Row");
    //            writer.WriteStartElement("Id");
    //            writer.WriteString(rp["Id_Producto"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Descripcion");
    //            writer.WriteString(rp["DescripcioCorta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Url");
    //            writer.WriteString(_dominios + "/" + rp["Url"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ruta");
    //            writer.WriteString(_dominios + rp["Ruta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Titulo");
    //            writer.WriteString(rp["Titulo"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Fecha");
    //            writer.WriteString(rp["FechaIngreso"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Descuento");
    //            writer.WriteString(rp["Descuento"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Cantidad");
    //            writer.WriteString(rp["Cantidad"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Precio");
    //            writer.WriteString(rp["Precio"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ident");
    //            writer.WriteString("IP");
    //            writer.WriteEndElement();
    //            writer.WriteEndElement();
    //        }
    //        PresentarP = PresentarP + "</ol>";
    //        //ofertas
    //        String urlo = "";
    //        foreach (DataRow ro in _ds.Tables[2].Rows)
    //        {
    //            urlo = "Presentar.aspx?ID=" + ro["Id_Noticia"].ToString() + "&T=IO";
    //            PresentarO = PresentarO + "<li class=\"item\">" +
    //            "<a href=\"" + urlo + "\" title=\"" + ro["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
    //            "<img src=\".." + ro["Ruta"].ToString() + "\" alt=\"" + ro["Titulo"].ToString() + "\"></a>" +
    //            "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
    //            "<a href=\"" + urlo + "\" title=\"" + ro["Titulo"].ToString() + "\">" +
    //            "" + ro["Titulo"].ToString() + "</a></h2>" +
    //                //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
    //                //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
    //            "</div></div></li>";

    //            writer.WriteStartElement("Row");
    //            writer.WriteStartElement("Id");
    //            writer.WriteString(ro["Id_Noticia"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Titulo");
    //            writer.WriteString(ro["Titulo"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ruta");
    //            writer.WriteString(_dominios + ro["Ruta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Url");
    //            writer.WriteString(_dominios + "/" + ro["Url"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("DescripcionCorta");
    //            writer.WriteString(ro["DescripcionCorta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ident");
    //            writer.WriteString("IO");
    //            writer.WriteEndElement();
    //            writer.WriteEndElement();
    //        }
    //        PresentarO = PresentarO + "</ol>";

    //        //servicios
    //        String urls = "";
    //        foreach (DataRow rs in _ds.Tables[1].Rows)
    //        {
    //            urls = "Presentar.aspx?ID=" + rs["Id_Servicio"].ToString() + "&T=IS";
    //            PresentarS = PresentarS + "<li class=\"item\">" +
    //            "<a href=\"" + urls + "\" title=\"" + rs["Titulo"].ToString() + "\" class=\"product-image Fondoimage\">" +
    //            "<img src=\".." + rs["Ruta"].ToString() + "\" alt=\"" + rs["Titulo"].ToString() + "\"></a>" +
    //            "<div class=\"product-shop\"><div class=\"f-fix\"><h2 class=\"product-name\">" +
    //            "<a href=\"" + urls + "\" title=\"" + rs["Titulo"].ToString() + "\">" +
    //            "" + rs["Titulo"].ToString() + "</a></h2>" +
    //                //"<div class=\"desc std\"><p>" + r["DescripcioCorta"].ToString() + "</p>" +
    //                //"</div>" +//<a href=\"http://localhost:2304/com21Web/mvixbox-wdn-2000-ultra-performance-2-bay-sata-nas-server-13-2-5.aspx\" title=\"" + titulo + "\" class=\"link-learn\">Más información</a>
    //            "</div></div></li>";

    //            writer.WriteStartElement("Row");
    //            writer.WriteStartElement("Id");
    //            writer.WriteString(rs["Id_Servicio"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Titulo");
    //            writer.WriteString(rs["Titulo"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ruta");
    //            writer.WriteString(_dominios + rs["Ruta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Url");
    //            writer.WriteString(_dominios + "/" + rs["Url"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("DescripcionCorta");
    //            writer.WriteString(rs["DescripcioCorta"].ToString());
    //            writer.WriteEndElement();
    //            writer.WriteStartElement("Ident");
    //            writer.WriteString("IS");
    //            writer.WriteEndElement();
    //            writer.WriteEndElement();
    //        }

    //        writer.WriteEndElement();
    //        writer.WriteEndDocument();
    //        writer.Flush();
    //        writer.Close();
    //    }
    //    PresentarS = PresentarS + "</ol>";

    //    mostrar.InnerHtml = PresentarP + PresentarO + PresentarS;
    //}
}