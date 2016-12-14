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
using System.Text.RegularExpressions;
using com21DLL;
using System.Net.Mail;

public partial class anapp_registroSi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarDatos();
            String estado = Request.QueryString["Estado"];
            //String clave = Request.QueryString["Usu"];
            //String usu = Request.QueryString["Cl"];
            if (estado != null)
            {
                PresentarMensaje(estado);
                //if((usu != null) || (clave != null))
                //{
                //    txtclave.Text = clave;
                //    txtusuario.Text = usu;
                //}
            }
        }
    }
    protected void btnValidar_Click(object sender, EventArgs e)
    {
    }
    private void PresentarMensaje(string E)
    {
        switch (E)
        {
            case "4":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Por favor ingrese todo los campos";
                break;
            case "3":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Usuario ingresado ya existe para una cuenta";
                break;
        }
    }
    private void limpiar()
    {
        txtclave.Text = "";
        txtusuario.Text = "";
    }
    private int Validar()
    {
        int i = 1;
        if (txtclave.Text.Length == 0)
        {
            i = 0;
        }
        if (txtusuario.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void Redireccionar(String E)
    {
        string url = string.Empty;
        String estado = Request.QueryString["Estado"];
        String nom = Request.QueryString["Nom"];
        String ape = Request.QueryString["Ape"];
        String ds = Request.QueryString["Ds"];
        String co = Request.QueryString["Co"];
        if (estado != null)
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            if (E != "1")
            {
                url = array[0] + "?Estado=" + E + "&Nom=" + nom + "&Ape=" + ape + "&Co=" + co + "&Ds=" + ds;
            }
            else
            {
                ingresarCliente();
            }
        }
        else
        {
            url = Request.Url.AbsoluteUri;
            if (E != "1")
            {
                url = url + "?Estado=" + E + "&Nom=" + nom + "&Ape=" + ape + "&Co=" + co + "&Ds=" + ds;
            }
            else
            {
                ingresarCliente();
            }
        }
        Response.Redirect(url,false);
    }
    private void ingresarCliente()
    {
        String nom = Request.QueryString["Nom"];
        String ape = Request.QueryString["Ape"];
        String ds = Request.QueryString["Ds"];
        String co = Request.QueryString["Co"];
        //,,,,,,,Direccion,Telefono,Celular,CopiaClave)
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        _xmlDatos.DocumentElement.SetAttribute("Nombres", nom);
        _xmlDatos.DocumentElement.SetAttribute("Apellidos", ape);
        _xmlDatos.DocumentElement.SetAttribute("Usuario", txtusuario.Text);
        String _clave = classMD5.encriptaClave(txtclave.Text);
        _xmlDatos.DocumentElement.SetAttribute("Clave", _clave);
        _xmlDatos.DocumentElement.SetAttribute("CopiaClave", txtclave.Text);
        _xmlDatos.DocumentElement.SetAttribute("Correo", co);
        _xmlDatos.DocumentElement.SetAttribute("Id_Sexo", ds);
        if(ds == "0")
            _xmlDatos.DocumentElement.SetAttribute("Sexo", "Masculino");
        else
            _xmlDatos.DocumentElement.SetAttribute("Sexo", "Femenino");

        _xmlDatos.DocumentElement.SetAttribute("Direccion", "0");
        _xmlDatos.DocumentElement.SetAttribute("Telefono", "0");
        _xmlDatos.DocumentElement.SetAttribute("Celular", "0");
        _xmlDatos.DocumentElement.SetAttribute("Id_Pais", "1");
        _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", "0");
        _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", "0");
        _xmlDatos.DocumentElement.SetAttribute("Cedula", "0");
        _xmlDatos.DocumentElement.SetAttribute("Notificaciones", "0");

        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_ingresa_cliente(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
            enviarcorreo();
            cookiesSesion(_clave);
            limpiar();
        }
    }
    private void enviarcorreo()
    {
        String nom = Request.QueryString["Nom"];
        String ape = Request.QueryString["Ape"];
        String ds = Request.QueryString["Ds"];
        String co = Request.QueryString["Co"];
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(co);
        objMail.Subject = "Registro de Usuario";
        objMail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head runat='server'><title>Com21 S.A ::. Registro de Usuario</title></head><body><div style='width: 500px;margin-right: auto; margin-left: auto;'>" +
                       "<table style='border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;'><tr><td style='background-position: center top; padding: 5px; text-align: left; background-image: url(http://designsie.com/images/imagen_registro1.png); background-repeat: no-repeat; font-weight: bold;'>" +
                       "<table style='width: 100%;'><tr><td width='50%'><a href='http://designsie.com/' target='_blank'><img alt='' src='http://designsie.com/images/logocom21icon.png' width='120' /></a></td><td width='50%' style='text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;'>NUEVO CLIENTE</td>" +
                       "</tr></table></td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>&nbsp;</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>Estimado(a)</td></tr><tr><td style='padding: 5px 5px 15px 5px'>" + nom + " " + ape + "</td>" +
                       "</tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>¡Bienvenido(a) a Com21!</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>Los datos ingresados son:</td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>" +
                       "<table style='width:100%;'><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Usuario:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtusuario.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Correo:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + co + "</td>" +
                       "</tr></table></td></tr><tr style='background-color: #E2E2E2;'><td style='padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;'>Contacto:&nbsp;&nbsp;&nbsp;<span style='font-size: 14px; color: #000000'>Tel:(+593) 42-300539</span></td></tr></table></div></body></html>";
        //envio de correos al administrador
        classCom21Correo clCorreo = new classCom21Correo();
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
        {
            clCorreo.EnvioLN(1, objMail);
        }
        else
        {
            clCorreo.EnvioLN(2, objMail);
        }
    }
    private void cookiesSesion(String clave)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_valida_cliente(txtusuario.Text, clave);
        HttpCookie aCookieIdCom21 = new HttpCookie("IdCom21App");
        HttpCookie aCookieUserCom21 = new HttpCookie("UserCom21App");
        HttpCookie aCookiePassCom21 = new HttpCookie("PassCom21App");
        HttpCookie aCookieEmailCom21 = new HttpCookie("EmailCom21App");
        String co = Request.QueryString["Co"];
        if (_user.Tables[0].Rows.Count > 0)
        {
            classRandom _rand = new classRandom();
            String _cod = _rand.NextString(11, true, true, true, false);

            foreach (DataRow r in _user.Tables[0].Rows)
            {
                aCookieIdCom21.Value = r["Id_Clientes"].ToString();
                Response.Cookies.Add(aCookieIdCom21);

                aCookieUserCom21.Value = txtusuario.Text;
                Response.Cookies.Add(aCookieUserCom21);


                aCookiePassCom21.Value = txtclave.Text;
                Response.Cookies.Add(aCookiePassCom21);

                aCookieEmailCom21.Value =  co;
                Response.Cookies.Add(aCookieEmailCom21);

                int dcompras = ConsultaDatosCompra(int.Parse(r["Id_Clientes"] + ""));
                if (dcompras == 1)
                { EditarDatosCompra(_cod, int.Parse(r["Id_Clientes"] + "")); }
                else
                { IngresoDatosCompra(_cod, int.Parse(r["Id_Clientes"] + "")); }
            }
            Response.Redirect("Default.aspx");
        }
    }
    #region "Datos para realizar compras"
    private int ConsultaDatosCompra(int idusuario)
    {
        int dcompras = 0;
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet ds = _administrador.Com21_consulta_cliente_DatosCompra(idusuario, 2);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dcompras = 1;
        }
        return dcompras;
    }
    private void IngresoDatosCompra(String _cod, int idusuario)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "2");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_ingresa_cliente_DatosCompra(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
        }
    }
    private void EditarDatosCompra(String _cod, int idusuario)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "2");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, idusuario))
        { }
        else
        { }
    }
    #endregion
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _app = new ServicioCom21.ServicioCom21();
        int i = Validar();
        if (i > 0)
        {
            if (txtclave.Text.Length >= 6 && txtclave.Text.Length <= 12)
            {
                DataSet ds = _app.Com21_consulta_recuperar_clave_cliente(txtusuario.Text, "1");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Redireccionar("3");
                }
                else
                {
                    Redireccionar("1");
                }
            }
        }
        else
        {
            Redireccionar("4");
        }
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    protected void btnAtras_Click1(object sender, EventArgs e)
    {
        Response.Redirect("registro.aspx", false);
    }
}