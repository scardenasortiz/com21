using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class anapp_envioCorreo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String E = Request.QueryString["E"];
            String URL = Request.QueryString["UrlRe"];
            if (E != null)
            {
                PresentarMensaje(E);
            }
            if (URL != null)
            {
                HfURLRe.Value = URL;
            }
        }
    }
    private void PresentarMensaje(string E)
    {
        switch (E)
        {
            case "1":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "exito");
                DMensaje.InnerText = "Correo enviado con exito";
                break;
            case "2":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Correo ingresado invalido";
                break;
            case "3":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Correo no envido, por favor intente luego";
                break;
            case "4":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Por favor ingrese todo los campos";
                break;
        }
    }
    private void limpiar()
    {
        txtnombre.Text = "";
        txtcorreo.Text = "";
        txtmensaje.Text = "";
        txttelefono.Text = "";
    }
    private int Validar()
    {
        int i = 0;
        if (txttelefono.Text.Length > 0)
        {
            i = 1;
        }
        if (txtnombre.Text.Length > 0)
        {
            i = 1;
        }
        if (txtcorreo.Text.Length > 0)
        {
            i = 1;
        }
        if (txtmensaje.Text.Length > 0)
        {
            i = 1;
        }
        return i;
    }
    #region "Envio de Correo"
    private void enviarcorreo()
    {
        try
        {
            MailMessage objMail = new MailMessage();
            objMail.IsBodyHtml = false;
            objMail.From = new MailAddress("info@com21.com.ec");
            objMail.To.Add("so_cardenas@hotmail.com");
            //objMail.To.Add("rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec");
            objMail.Subject = "Información Contactenos";
            objMail.Body = "Los datos del contacto son:\nNombres: " + txtnombre.Text + "\nEmail: " + txtcorreo.Text + "\nTeléfono: " + txttelefono.Text + "\nMensaje: " + txtmensaje.Text + "";

            //con puerto
            //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
            //objSMTPClient.EnableSsl = true;
            //objSMTPClient.UseDefaultCredentials = false;
            //objSMTPClient.Credentials = new NetworkCredential("steven.cardenas@bonsai.com.ec", "Steven!2012");
            //fin con puertos

            //sin puertos
            SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //fin de sin puertos

            objSMTPClient.Send(objMail);
            limpiar();
            Redireccionar("1");

        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Su solicitud no fue enviada.');", true);
            Redireccionar("3");
        }
    }
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
    #endregion
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        int i = Validar();
        if (i > 0)
        {
            if (email_bien_escrito(txtcorreo.Text))
            {
                enviarcorreo();
            }
            else
            {
                Redireccionar("2");
            }
        }
        else
        {
            Redireccionar("4");
        }
    }
    private void Redireccionar(String E)
    {
        string url = string.Empty;
        String parametro1 = Request.QueryString["E"];
        if (parametro1 != null)
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            //String parametro2 = Request.QueryString["UrlRe"];
            url = array[0] + "?E=" + E + "&UrlRe=" + HttpUtility.UrlEncode(HfURLRe.Value);
        }
        else
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            //String parametro2 = Request.QueryString["UrlRe"];
            url = array[0] + "?E=" + E + "&UrlRe=" + HttpUtility.UrlEncode(HfURLRe.Value);
        }
        
        Response.Redirect(url,false);
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        string url = Request.QueryString["UrlRe"];
        if (url != null)
        {
            Response.Redirect(url, false);
        }
    }
    protected void btnValidar_Click(object sender, EventArgs e)
    {
        int i = Validar();
        if (i > 0)
        {
            if (email_bien_escrito(txtcorreo.Text))
            {
                enviarcorreo();
            }
            else
            {
                Redireccionar("2");
            }
        }
        else
        {
            Redireccionar("4");
        }
    }
}