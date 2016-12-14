using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Xml;
using System.Net;
using com21DLL;
using System.Text.RegularExpressions;

public partial class contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnenviar_Click(object sender, EventArgs e)
    {
        int i = validar();
        if (i == 1)
        {
            enviarcorreo();
        }
        else
        {
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("class", "error");
            DMensaje.InnerText = "Por favor llenar todos los campos";
        }
    }
    private int validar()
    {
        int i = 1;
        if (txtnombres.Text.Length == 0)
        {
            i = 0;
        }
        if (txtapellidos.Text.Length == 0)
        {
            i = 0;
        }
        if (txttelefono.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        if (txtmensaje.Text.Length == 0)
        {
            i = 0;
        }
        if (txtasunto.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*([,;]\\s*\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)*";

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
    private void enviarcorreo()
    {
        try
        {
            if (email_bien_escrito(txtcorreo.Text.Trim()))
            {
                MailMessage objMail = new MailMessage();
                objMail.IsBodyHtml = false;
                objMail.From = new MailAddress("info@com21.com.ec");
                objMail.To.Add("so_cardenas@hotmail.com");
                //objMail.To.Add("rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec");
                objMail.Subject = "Información Contáctenos";
                objMail.Body = "Los datos del contacto son:\nNombres: " + txtnombres.Text + "\nApellidos: " + txtapellidos.Text + "\nEmail: " + txtcorreo.Text + "\nTeléfono: " + txttelefono.Text + "\nAsunto: " + txtasunto.Text + "\nMensaje: " + txtmensaje.Text + "";

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

                ingresarinbox();
                limpiar();

                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "exito");
                DMensaje.InnerText = "Se ha enviado con exito su información.";
            }
            else
            {
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Por favor digite un correo válido";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Su solicitud no fue enviada.');", true);
        }
    }
    private void limpiar()
    {
        txtapellidos.Text = "";
        txtcorreo.Text = "";
        txtmensaje.Text = "";
        txtnombres.Text = "";
        txttelefono.Text = "";
        txtasunto.Text = "";
        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Su solicitud fue enviada.');", true);
    }
    private void ingresarinbox()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Inbox/>");
        _xmlDatos.DocumentElement.SetAttribute("Titulo", txtasunto.Text);
        _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtnombres.Text + " - " + txtapellidos.Text + " - " + txttelefono.Text + ".<br />" + txtmensaje.Text);
        _xmlDatos.DocumentElement.SetAttribute("Para", "Com21 S.A.");
        _xmlDatos.DocumentElement.SetAttribute("De", txtcorreo.Text);
        _xmlDatos.DocumentElement.SetAttribute("Tipo", "1");
        _xmlDatos.DocumentElement.SetAttribute("Nombres", txtnombres.Text + " " + txtapellidos.Text);
        
        if (_consulta.Com21_ingresa_inbox_outbox(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
        }
    }
}