using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class master_infocarrito : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String _dominio = Request.Url.Authority;
            if (_dominio == "localhost:2304")
            {
                cargarTituloLocal();
            }
            else
            {
                cargarTituloWeb();
            }
            //if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            //{
            //    pInicio.Visible = false;
            //    pInicioSesion.Visible = true;
            //}
            //else
            //{
            //    pInicio.Visible = true;
            //    pInicioSesion.Visible = false;
            //}
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
               // cargarInfoCarrito();
                #region "OBTENER TIPO NAVAGACIÓN"

                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true ||
                            strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                            strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                    {
                       /* lblusernomb.Text = Request.Cookies["UserCom21Web"].Value;
                        pInicio.Visible = false;
                        pInicioSesion.Visible = false;*/
                       // pInicioRelogin.Visible = true;
                        //pInicioRe.Visible = false;
                        logohead.Visible = true;
                        bannerhead.Visible = false;
                    }
                    else
                    {
                        /*lblusernomb.Text = Request.Cookies["UserCom21Web"].Value;
                        pInicio.Visible = false;
                        pInicioSesion.Visible = true;*/
                        //pInicioRelogin.Visible = false;
                        //pInicioRe.Visible = false;
                        logohead.Visible = false;
                        bannerhead.Visible = true;
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
                        /*pInicio.Visible = false;
                        pInicioSesion.Visible = false;*/
                        //pInicioRelogin.Visible = false;
                        //pInicioRe.Visible = true;
                        logohead.Visible = true;
                        bannerhead.Visible = false;
                    }
                    else
                    {
                        /*pInicio.Visible = true;
                        pInicioSesion.Visible = false;*/
                        //pInicioRelogin.Visible = false;
                        //pInicioRe.Visible = false;
                        logohead.Visible = false;
                        bannerhead.Visible = true;
                    }
                }
            }
        }
    }
    private void cargarTituloWeb()
    {
        String _dominio = Request.Url.AbsoluteUri;
        int _don = int.Parse(_dominio.LastIndexOf(".aspx").ToString()) + 5;
        String _newdon = _dominio.Substring(0, _don);
        switch (_newdon)
        {
            case "http://com21.com.ec/recuperar.aspx":
                titlepagina.Text = "Com21 S.A :: Recuperar Clave";
                titlepagina1.Content = "Com21 S.A :: Recuperar Clave";
                descp.Content = "Recuperar Clave, Recuperar Contraseña";
                descmeta.Content = "Recuperar Clave, Recuperar Contraseña";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/iniciar.aspx":
                titlepagina.Text = "Com21 S.A :: Iniciar Sesión";
                titlepagina1.Content = "Com21 S.A :: Iniciar Sesión";
                descp.Content = "Iniciar Sesión";
                descmeta.Content = "Iniciar Sesión";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/registrate.aspx":
                titlepagina.Text = "Com21 S.A :: Registrate";
                titlepagina1.Content = "Com21 S.A :: Registrate";
                descp.Content = "Registrate";
                descmeta.Content = "Registrate";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/nosotros.aspx":
                titlepagina.Text = "Com21 S.A :: Nosotros";
                titlepagina1.Content = "Com21 S.A :: Nosotros";
                descp.Content = "Nosotros";
                descmeta.Content = "Nosotros";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/info.aspx":
                titlepagina.Text = "Com21 S.A :: Misión - Visión";
                titlepagina1.Content = "Com21 S.A :: Misión - Visión";
                descp.Content = "Misión, Visión";
                descmeta.Content = "Misión, Visión";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/contactenos.aspx":
                titlepagina.Text = "Com21 S.A :: Contactenos";
                titlepagina1.Content = "Com21 S.A :: Contactenos";
                descp.Content = "Contactenos para mayor información";
                descmeta.Content = "Contactenos para mayor información";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/carrito.aspx":
                titlepagina.Text = "Com21 S.A :: Carrito de Compras";
                titlepagina1.Content = "Com21 S.A :: Carrito de Compras";
                descp.Content = "Carrito de compras";
                descmeta.Content = "Carrito de compras";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/cuentaUsuario.aspx":
                titlepagina.Text = "Com21 S.A :: Cuenta del Usuario";
                titlepagina1.Content = "Com21 S.A :: Cuenta del Usuario";
                descp.Content = "Accede a tu cuenta de usuario";
                descmeta.Content = "Accede a tu cuenta de usuario";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/editainfo.aspx":
                titlepagina.Text = "Com21 S.A :: Infomación para la Compra";
                titlepagina1.Content = "Com21 S.A :: Infomación para la Compra";
                descp.Content = "información para la compra";
                descmeta.Content = "información para la compra";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/cargarconsulta.aspx":
                titlepagina.Text = "Com21 S.A :: Busqueda";
                titlepagina1.Content = "Com21 S.A :: Busqueda";
                descp.Content = "Busca tu productos aqui";
                descmeta.Content = "Busca tu productos aqui";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/productos.aspx":
                titlepagina.Text = "Com21 S.A :: Productos";
                titlepagina1.Content = "Com21 S.A :: Productos";
                descp.Content = "Elige un producto";
                descmeta.Content = "Elige un producto";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/catproductos.aspx":
                titlepagina.Text = "Com21 S.A :: Catalogo de Productos";
                titlepagina1.Content = "Com21 S.A :: Catalogo de Productos";
                descp.Content = "Elige un producto en nuestro catalogo";
                descmeta.Content = "Elige un producto en nuestro catalogo";
                url.Content = _newdon + "?Cat=0&Sub=0";
                break;
            case "http://com21.com.ec/subimpresion.aspx":
                titlepagina.Text = "Com21 S.A :: Suministrod de Impresión";
                titlepagina1.Content = "Com21 S.A :: Suministrod de Impresión";
                descp.Content = "Mire nuestrso suministros de impresión";
                descmeta.Content = "Mire nuestrso suministros de impresión";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/servicio.aspx":
                titlepagina.Text = "Com21 S.A :: Servicios";
                titlepagina1.Content = "Com21 S.A :: Servicios";
                descp.Content = "Ofrecemos servicios en diversas areas";
                descmeta.Content = "Ofrecemos servicios en diversas areas";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/noticias.aspx":
                titlepagina.Text = "Com21 S.A :: Noticias";
                titlepagina1.Content = "Com21 S.A :: Noticias";
                descp.Content = "Lee nuestras noticias sobre tecnología y nuetras notas curiosas";
                descmeta.Content = "Lee nuestras noticias sobre tecnología y nuetras notas curiosas";
                url.Content = _newdon;
                break;
            case "http://com21.com.ec/ofertas.aspx":
                titlepagina.Text = "Com21 S.A :: Ofertas";
                titlepagina1.Content = "Com21 S.A :: Ofertas";
                descp.Content = "Verifica nuestras ofertas";
                descmeta.Content = "Verifica nuestras ofertas";
                url.Content = _newdon;
                break;
        }
    }
    private void cargarTituloLocal()
    {
        String _dominio = Request.Url.AbsoluteUri;
        int _don = int.Parse(_dominio.LastIndexOf(".aspx").ToString()) + 5;
        String _newdon = _dominio.Substring(0, _don);
        switch (_newdon)
        {
            case "http://localhost:2304/com21Web/recuperar.aspx":
                titlepagina.Text = "Com21 S.A :: Recuperar Clave";
                break;
            case "http://localhost:2304/com21Web/iniciar.aspx":
                titlepagina.Text = "Com21 S.A :: Iniciar Sesión";
                break;
            case "http://localhost:2304/com21Web/registrate.aspx":
                titlepagina.Text = "Com21 S.A :: Registrate";
                break;
            case "http://localhost:2304/com21Web/nosotros.aspx":
                titlepagina.Text = "Com21 S.A :: Nosotros";
                break;
            case "http://localhost:2304/com21Web/info.aspx":
                titlepagina.Text = "Com21 S.A :: Misión - Visión";
                break;
            case "http://localhost:2304/com21Web/contactenos.aspx":
                titlepagina.Text = "Com21 S.A :: Contactenos";
                break;
            case "http://localhost:2304/com21Web/carrito.aspx":
                titlepagina.Text = "Com21 S.A :: Carrito de Compras";
                break;
            case "http://localhost:2304/com21Web/cuentaUsuario.aspx":
                titlepagina.Text = "Com21 S.A :: Cuenta del Usuario";
                break;
            case "http://localhost:2304/com21Web/editainfo.aspx":
                titlepagina.Text = "Com21 S.A :: Infomación para la Compra";
                break;
        }
    }
    //private void cargarInfoCarrito()
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    DataSet _det = _consulta.consulta_producto_prefacturado_id_user_cant_tot();
    //    if ((_det.Tables[1].Rows.Count > 0) && (_det.Tables[0].Rows.Count > 0))
    //    {
    //        foreach (DataRow r in _det.Tables[1].Rows)
    //        {
    //            if (!String.IsNullOrEmpty(r["Cantidad"].ToString()))
    //            {
    //                lblitemscarrito.Text = r["Cantidad"].ToString() + " item(s)";
    //            }
    //            else
    //            {
    //                lblitemscarrito.Text = "0 item(s)";
    //            }
    //        }
    //        foreach (DataRow r in _det.Tables[0].Rows)
    //        {
    //            if (!String.IsNullOrEmpty(r["Total"].ToString()))
    //            {
    //                lbltotalcarrito.Text = "$" + r["Total"].ToString();
    //            }
    //            else
    //            {
    //                lbltotalcarrito.Text = "$0.00";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblitemscarrito.Text = "0 item(s)";
    //        lbltotalcarrito.Text = "$0.00";
    //    }
    //}
    #region "BUSQUEDA"
    protected void btnbuscar1_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search1.Text);
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargarconsulta.aspx?texto=" + search.Text);
    }
    #endregion
    protected void timerValor_Tick(object sender, EventArgs e)
    {
       // cargarInfoCarrito();
    }
}
