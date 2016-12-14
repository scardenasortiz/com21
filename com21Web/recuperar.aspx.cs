using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using com21DLL;
using System.Net.Mail;
using System.Net;

public partial class recuperar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                Response.Redirect("default.aspx");
            }
            else
            {

            }
        }
    }
    protected void btncrearcuenta_Click(object sender, EventArgs e)
    {
        int i = validaDato();
        if (i == 1)
        {
            if (email_bien_escrito(txtemail.Text) == true)
            {
                DataSet _dtinfo = consultaCorreo();
                if (_dtinfo.Tables[0].Rows.Count > 0)
                {
                    enviarClave(_dtinfo);
                    limpiar();
                }
                else
                {
                    lblinfo.Text = "No existe correo registrado";
                }
            }
            else
            {
                lblinfo.Text = "Correo digitado de forma incorrecta";
            }
        }
    }
    private int validaDato()
    {
        int i = 1;
        if (txtemail.Text.Length == 0)
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
    private void limpiar()
    {
        txtemail.Text = "";
        lblinfo.Text = "";
        //lblcorrecto.Text = "";
    }
    private void enviarClave(DataSet _dtinfo)
    {
        String nombre = ""; String apellido = "";
        String user = ""; String clave = "";
        foreach (DataRow r in _dtinfo.Tables[0].Rows)
        {
            nombre = r["Nombres"].ToString();
            apellido = r["Apellidos"].ToString();
            user = r["Usuario"].ToString();
            clave = r["CopiaClave"].ToString();
        }
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(txtemail.Text);
        objMail.Subject = "Envio de Clave";
        objMail.Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title></head><body>" +
        "<div style=\"width: 500px;margin-right: auto; margin-left: auto;\"><table style=\"border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;\"><tr><td style=\"background-position: center top; padding: 5px; text-align: left; background-image: url('http://designsie.com/images/imagen_registro1.png'); background-repeat: no-repeat; font-weight: bold;\">" +
        "<table style=\"width: 100%;\"><tr><td width=\"50%\"><a href=\"http://designsie.com/\" target=\"_blank\"><img alt=\"\" src=\"http://designsie.com/images/logocom21icon.png\" width=\"120\" /></a></td><td width=\"50%\" style=\"text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;\">ENVIO DE CLAVE</td>" +
        "</tr></table></td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">&nbsp;</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">Estimado(a)</td></tr><tr><td style=\"padding: 5px 5px 15px 5px\">" + nombre + " " + apellido + "</td></tr><tr>" +
        "<td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">La infomacción solicitada para ingresar a su cuenta son:</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Usuario: " + user + "<br />Clave: " + clave + "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Para iniciar sesión de click en el link:&nbsp;&nbsp;<a href=\"http://designsie.com/iniciar.aspx\" target=\"_blank\">Iniciar Sesión</a>" +
        "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif; text-align: center;\"><a href=\"http://designsie.com/\" target=\"_blank\">www.com21.com.ec</a></td></tr><tr style=\"background-color: #E2E2E2;\"><td style=\"padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;\">Contacto:&nbsp;&nbsp;&nbsp;<span style=\"font-size: 14px; color: #000000\">Tel:(+593) 42-300539</span></td>" +
        "</tr></table></div></body></html>";

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

        lblcorrecto.Text = "Se ha enviado la información solicitada";
    }
    private DataSet consultaCorreo()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _dtinfo = _consulta.Com21_consulta_cliente_correo_clave(txtemail.Text);
        return _dtinfo;
    }
}