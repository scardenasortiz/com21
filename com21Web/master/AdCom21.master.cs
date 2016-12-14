using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class master_AdCom21 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null || Session["admin"] != "admin")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                perfil();
                consutarinbox();
                consultarTrans();
                lbluser.Text = Session["admin-user"].ToString();
            }
        }
    }
    private void perfil()
    {
        String menu = "<div id='accordion-js' class='accordion'>";
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        string id = Session["admin-id"].ToString();
        DataSet _perfil = _consulta.Com21_consulta_perfil_opc(int.Parse(id));
        if (_perfil.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _perfil.Tables[1].Rows)
            {
                if (Convert.ToBoolean(r[6].ToString()) == true)
                {
                    menu = menu + cargarmenu(int.Parse(r[2].ToString()), r[3].ToString());
                }
            }
        }
        menu = menu + "</div>";
        opciones.InnerHtml = menu;
    }
    private string cargarmenu(int Perfil, string opc)
    {
        string sub = "";
        switch (Perfil)
        {
            case 1:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='pais.aspx' style='font-size: 12px'>Pais</a><a href='provincia.aspx' style='font-size: 12px'>Provincias</a><a href='ciudad.aspx' style='font-size: 12px'>Ciudades</a><a href='costoenvio.aspx' style='font-size: 12px'>Costo de Envio</a></p>";
                break;
            case 2:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='nosotro.aspx' style='font-size: 12px'>Nosotros</a><a href='misionvision.aspx' style='font-size: 12px;'>Misión y Visión</a><a href='noticias.aspx' style='font-size: 12px;'>Noticias</a><a href='ofertas.aspx' style='font-size: 12px'>Ofertas</a><a href='empresa.aspx' style='font-size: 12px'>Sucursales</a></p>";
                //sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='nosotro.aspx' style='font-size: 12px'>Nosotros</a><a href='misionvision.aspx' style='font-size: 12px;'>Misión y Visión</a><a href='noticias.aspx' style='font-size: 12px;'>Noticias</a><a href='ofertas.aspx' style='font-size: 12px'>Ofertas</a></p>";
                break;
            case 3:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='categoria.aspx' style='font-size: 12px'>Categoria</a><a href='subcategoria.aspx' style='font-size: 12px'>Sub-Categoria</a><a href='marca.aspx' style='font-size: 12px'>Marca</a><a href='items.aspx' style='font-size: 12px'>Ingreso de producto</a><a href='asignarproducto.aspx' style='font-size: 12px'>Productos sin marca</a><a href='asignarproductosub.aspx' style='font-size: 12px'>Productos sin sub-categoria</a></p>";//<a href='imagenes.aspx' style='font-size: 12px'>Imagenes de producto</a>
                break;
            case 4:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='usuadministrador.aspx' style='font-size: 12px'>Nuevo Usuario</a><a href='perfil.aspx' style='font-size: 12px'>Asignar Perfil</a>";//<a href='claves.aspx' style='font-size: 12px'>Cambiar Claves</a></p>";
                break;
            case 5:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='usucliente.aspx' style='font-size: 12px'>Consultas Usuario</a></p>";
                break;
            case 6:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='galeriafoto.aspx' style='font-size: 12px'>Imagenes</a></p>";
                break;
            case 7:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='rproductos.aspx' style='font-size: 12px'>Productos</a><a href='rtransacciones.aspx' style='font-size: 12px'>Transacciones</a><a href='inventario.aspx' style='font-size: 12px'>Inventario</a></p>";
                break;
            case 9:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='promociones.aspx' style='font-size: 12px'>Promociones/Publicidad</a><a href='promocionesi.aspx' style='font-size: 12px'>Publicidad Internas</a></p>";
                break;
            case 10:
                sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='servicios.aspx' style='font-size: 12px'>Servicios</a><a href='categoria_serv.aspx' style='font-size: 12px'>Categorias Servicios</a></p>";
                break;
        }
        return sub;
    }
    //private string cargarmenu(int Perfil, string opc)
    //{
    //    string sub = "";
    //    switch (Perfil)
    //    {
    //        case 1:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='pais.aspx' style='font-size: 12px'>Pais</a><a href='provincia.aspx' style='font-size: 12px'>Provincias</a><a href='ciudad.aspx' style='font-size: 12px'>Ciudades</a><a href='costoenvio.aspx' style='font-size: 12px'>Costo de Envio</a></p>";
    //            break;
    //        case 2:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='nosotro.aspx' style='font-size: 12px'>Nosotros</a><a href='misionvision.aspx' style='font-size: 12px;'>Misión y Visión</a><a href='noticias.aspx' style='font-size: 12px;'>Noticias</a><a href='ofertas.aspx' style='font-size: 12px'>Ofertas</a><a href='empresa.aspx' style='font-size: 12px'>Sucursales</a></p>";
    //            //sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='nosotro.aspx' style='font-size: 12px'>Nosotros</a><a href='misionvision.aspx' style='font-size: 12px;'>Misión y Visión</a><a href='noticias.aspx' style='font-size: 12px;'>Noticias</a><a href='ofertas.aspx' style='font-size: 12px'>Ofertas</a><a href='empresa.aspx' style='font-size: 12px'>Sucursales</a></p>";
    //            break;
    //        case 3:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='categoria.aspx' style='font-size: 12px'>Categoria</a><a href='subcategoria.aspx' style='font-size: 12px'>Sub-Categoria</a><a href='marca.aspx' style='font-size: 12px'>Marca</a><a href='items.aspx' style='font-size: 12px'>Ingreso de producto</a><a href='asignarproducto.aspx' style='font-size: 12px'>Productos sin marca</a><a href='asignarproductosub.aspx' style='font-size: 12px'>Productos sin sub-categoria</a></p>";//<a href='imagenes.aspx' style='font-size: 12px'>Imagenes de producto</a>
    //            break;
    //        case 4:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='usuadministrador.aspx' style='font-size: 12px'>Nuevo Usuario</a><a href='perfil.aspx' style='font-size: 12px'>Asignar Perfil</a>";//<a href='claves.aspx' style='font-size: 12px'>Cambiar Claves</a></p>";
    //            break;
    //        case 5:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='usucliente.aspx' style='font-size: 12px'>Consultas Usuario</a></p>";
    //            break;
    //        case 6:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='galeriafoto.aspx' style='font-size: 12px'>Imagenes</a></p>";
    //            break;
    //        case 7:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='rproductos.aspx' style='font-size: 12px'>Productos</a><a href='rtransacciones.aspx' style='font-size: 12px'>Transacciones</a><a href='inventario.aspx' style='font-size: 12px'>Inventario</a></p>";
    //            break;
    //        case 9:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='promociones.aspx' style='font-size: 12px'>Promociones/Publicidad</a></p>";
    //            break;
    //        case 10:
    //            sub = "<h2 style='font-family: Tahoma; color: #0066CC; font-weight: normal; font-size: 15px;'>" + opc + "</h2><p><a href='servicios.aspx' style='font-size: 12px'>Servicios</a><a href='categoria_serv.aspx' style='font-size: 12px'>Categorias Servicios</a></p>";
    //            break;
    //    }
    //    return sub;
    //}
    private void consutarinbox()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_inbox_outbox();
        if (_ds.Tables[2].Rows.Count > 0)
        {
            imgEmailNL.ImageUrl = "~/images/mail_1_3.png";
        }
        else
        {
            imgEmailNL.ImageUrl = "~/images/mail_1.png";
        }
    }
    private void consultarTrans()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_ResportesInicialTrans();
        if (_ds.Tables[1].Rows.Count > 0)
        {
            imgVentas.ImageUrl = "~/images/cart_admin1.png";
        }
        else
        {
            imgVentas.ImageUrl = "~/images/cart_admin.png";
        }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("correos.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("rtransacciones.aspx");
    }
}
