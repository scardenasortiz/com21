﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class master_infoproductos : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUserAgent = Request.UserAgent.ToString().ToLower();
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
        {
            cargarTituloLocal();
        }
        else
        {
            cargarTituloWeb();
        }
        if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
        {
          
            #region "OBTENER TIPO NAVAGACIÓN"

            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true ||
                        strUserAgent.Contains("blackberry") || strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                        strUserAgent.Contains("palm") || strUserAgent.Contains("android") || strUserAgent.Contains("iPhone") || strUserAgent.Contains("iPad"))
                {
                   

                }
                else
                {
                    
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
                 
                }
                else
                {
                 
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
            case "http://localhost:2304/com21Web/cargarconsulta.aspx":
                titlepagina.Text = "Com21 S.A :: Busqueda";
                break;
            case "http://localhost:2304/com21Web/productos.aspx":
                titlepagina.Text = "Com21 S.A :: Productos";
                break;
            case "http://localhost:2304/com21Web/catproductos.aspx":
                titlepagina.Text = "Com21 S.A :: Catalogo de Productos";
                break;
            case "http://localhost:2304/com21Web/subimpresion.aspx":
                titlepagina.Text = "Com21 S.A :: Suministro de Impresión";
                break;
            case "http://localhost:2304/com21Web/servicio.aspx":
                titlepagina.Text = "Com21 S.A :: Servicios";
                break;
            case "http://localhost:2304/com21Web/noticias.aspx":
                titlepagina.Text = "Com21 S.A :: Noticias";
                break;
            case "http://localhost:2304/com21Web/ofertas.aspx":
                titlepagina.Text = "Com21 S.A :: Ofertas";
                titlepagina1.Content = "Com21 S.A :: Ofertas";
                break;
        }
    }
   
}