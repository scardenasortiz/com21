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
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class anapp_recuperar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String Estado = Request.QueryString["Estado"];
            if (Estado != null)
            {
                PresentarMensaje(Estado);
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
                DMensaje.InnerText = "Usuario o correo ingresado inválido";
                break;
            case "3":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Por favor ingrese todo los campos";
                break;
            case "4":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Su solicitud no fue enviada.";
                break;
        }
    }
    private void limpiar()
    {
        txtcorreo.Text = "";
    }
    private int Validar()
    {
        int i = 0;
        if (txtcorreo.Text.Length > 0)
        {
            i = 1;
        }
        return i;
    }
    #region "Envio de Correo"
    private DataSet RecuperarUsuario(String ident)
    {
        ServicioCom21.ServicioCom21 _app = new ServicioCom21.ServicioCom21();
        DataSet ds = _app.Com21_consulta_recuperar_clave_cliente(txtcorreo.Text, ident);
        return ds;
    }
    private void enviarcorreo(DataSet ds)
    {
        try
        {
            MailMessage objMail = new MailMessage();
            objMail.IsBodyHtml = true;
            objMail.From = new MailAddress("info@com21.com.ec");
            
            //objMail.To.Add("rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec");
            objMail.Subject = "Envio de Clave";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                objMail.To.Add(row["Correo"]+"");
                objMail.Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title></head><body>" +
                "<div style=\"width: 500px;margin-right: auto; margin-left: auto;\"><table style=\"border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;\"><tr><td style=\"background-position: center top; padding: 5px; text-align: left; background-image: url('http://designsie.com/images/imagen_registro1.png'); background-repeat: no-repeat; font-weight: bold;\">" +
                "<table style=\"width: 100%;\"><tr><td width=\"50%\"><a href=\"http://designsie.com/\" target=\"_blank\"><img alt=\"\" src=\"http://designsie.com/images/logocom21icon.png\" width=\"120\" /></a></td><td width=\"50%\" style=\"text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;\">ENVIO DE CLAVE</td>" +
                "</tr></table></td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">&nbsp;</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">Estimado(a)</td></tr><tr><td style=\"padding: 5px 5px 15px 5px\">" + row["Usuario"]+"" + "</td></tr><tr>" +
                "<td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Registramos su solicitud de recuperación de contraseña para su ingreso.</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Clave: " + row["CopiaClave"] + "" + "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Para iniciar sesión de click en el link:&nbsp;&nbsp;<a href=\"http://designsie.com/iniciar.aspx\" target=\"_blank\">Iniciar Sesión</a>" +
                "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif; text-align: center;\"><a href=\"http://designsie.com/\" target=\"_blank\">www.com21.com.ec</a></td></tr><tr style=\"background-color: #E2E2E2;\"><td style=\"padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;\">Contacto:&nbsp;&nbsp;&nbsp;<span style=\"font-size: 14px; color: #000000\">Tel:(+593) 42-300539</span></td>" +
                "</tr></table></div></body></html>";
            }
            //con puerto
            //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
            //objSMTPClient.EnableSsl = true;
            //objSMTPClient.UseDefaultCredentials = false;
            //objSMTPClient.Credentials = new NetworkCredential("infopagocom21sa@gmail.com", "Com21sa2015");
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
            Redireccionar("4");
        }
    }
    private void Redireccionar(String E)
    {
        string url = string.Empty;
        String Estado = Request.QueryString["Estado"];
        if (Estado != null)
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            url = array[0] + "?Estado=" + E;
        }
        else
        {
            url = Request.Url.AbsoluteUri;
            url = url + "?Estado=" + E;
        }
        
        Response.Redirect(url,false);
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
                DataSet ds = RecuperarUsuario("2");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    enviarcorreo(ds);
                }
                else
                {
                    Redireccionar("2");
                }
            }
            else
            {
                
                DataSet ds = RecuperarUsuario("1");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    enviarcorreo(ds);
                }
                else
                {
                    Redireccionar("2");
                }
            }
        }
        else
        {
            Redireccionar("3");
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx",false);
    }
 
}