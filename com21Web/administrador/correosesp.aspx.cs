using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;
using System.Net.Mail;
using System.Net;

public partial class administrador_correosesp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["IdInOut"] != null)
            {
                cargarInboxOutbox();
            }
            else
            {
                Response.Redirect("correos.aspx");
            }
        }
    }
    #region "Correos Entrantes"
    private void cargarInboxOutbox()
    {
        string _id = Request.QueryString["IdInOut"].ToString();
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _inout = _consulta.Com21_consulta_inbox_outbox_id(int.Parse(_id));
        if (_inout.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _inout.Tables[0].Rows)
            {
                if (r["Tipo"].ToString() != "2")
                {
                    lblde.Text = r["De"].ToString();
                    lblpara.Text = r["Para"].ToString();
                    lblmensaje.Text = r["Descripcion"].ToString();
                    lblasunto.Text = r["Titulo"].ToString();
                    txtpara.Text = r["De"].ToString();
                    txtasunto.Text = r["Titulo"].ToString();
                    hfnombre.Value = r["Nombres"].ToString();
                    hfletraBS.Value = r["Tipo"].ToString();
                }
                else
                {
                    lblde.Text = r["De"].ToString();
                    lblpara.Text = r["Para"].ToString();
                    lblmensaje.Text = r["Descripcion"].ToString();
                    lblasunto.Text = r["Titulo"].ToString();
                    hfletraBS.Value = r["Tipo"].ToString();
                    btnenviar.Enabled = true;
                    txtmensaje.Enabled = true;
                }
            }
            editarCorreo();
        }
    }
    private void editarCorreo()
    {
        string _id = Request.QueryString["IdInOut"].ToString();
        ServicioCom21.ServicioCom21 _editar = new ServicioCom21.ServicioCom21();
        if (_editar.Com21_edita_inbox_outbox(int.Parse(_id)))
        {
        }
        else
        {
        }
    }
    #endregion

    protected void btnenviar_Click(object sender, EventArgs e)
    {
        int i = validar();
        if (i == 1)
        {
            if (hfletraBS.Value == "1")
            {
                enviarcorreo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Usted no puede enviar un correo');", true);
            }
        }
        else
        {
            if (hfletraBS.Value == "1")
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor debe llenar todos los campos');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Usted no puede enviar un correo');", true);
            }
        }
    }
    private int validar()
    {
        int i = 1;
        if (txtmensaje.Text.Length == 0)
        {
            i = 0;
        }
        if (txtasunto.Text.Length == 0)
        {
            i = 0;
        }
        if (txtde.Text.Length == 0)
        {
            i = 0;
        }
        if (txtpara.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void enviarcorreo()
    {
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(txtpara.Text);
        objMail.Subject = "Respuesta a: " + txtasunto.Text;
        objMail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head runat='server'><title>Com21 S.A ::. Registro de Usuario</title></head><body><div style='width: 500px;margin-right: auto; margin-left: auto;'>" +
                       "<table style='border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;'><tr><td style='background-position: center top; padding: 5px; text-align: left; background-image: url(http://designsie.com/images/imagen_registro1.png); background-repeat: no-repeat; font-weight: bold;'>" +
                       "<table style='width: 100%;'><tr><td width='50%'><a href='http://designsie.com/' target='_blank'><img alt='' src='http://designsie.com/images/logocom21icon.png' width='120' /></a></td><td width='50%' style='text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;'>RESPUESTA</td>" +
                       "</tr></table></td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>&nbsp;</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>Estimado(a)</td></tr><tr><td style='padding: 5px 5px 15px 5px'>" + hfnombre.Value + "</td>" +
                       "</tr><tr><td style='padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>" +
                       "<table style='width:100%;'><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Mensaje:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtmensaje.Text + "</td>" +
                       "</tr></table></td></tr><tr style='background-color: #E2E2E2;'><td style='padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;'>Contacto:&nbsp;&nbsp;&nbsp;<span style='font-size: 14px; color: #000000'>Tel:(+593) 42-300539</span></td></tr></table></div></body></html>";
        //con puerto
        //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
        //objSMTPClient.EnableSsl = true;
        //objSMTPClient.UseDefaultCredentials = false;
        //objSMTPClient.Credentials = new NetworkCredential("steven.cardenas@bonsai.com.ec", "Steven!2012");
        ////fin con puertos

        ////sin puertos
        ////SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
        ////objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        ////fin de sin puertos

        //objSMTPClient.Send(objMail);
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
    }
    private void limpiar()
    {
        txtmensaje.Text = "";
        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Respuesta enviada');", true);
    }
    private void ingresarinbox()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Inbox/>");
        _xmlDatos.DocumentElement.SetAttribute("Titulo", txtasunto.Text);
        _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtmensaje.Text);
        _xmlDatos.DocumentElement.SetAttribute("Para", txtpara.Text);
        _xmlDatos.DocumentElement.SetAttribute("De", "Com21 S.A");
        _xmlDatos.DocumentElement.SetAttribute("Tipo", "2");
        _xmlDatos.DocumentElement.SetAttribute("Nombres", hfnombre.Value);

        if (_consulta.Com21_ingresa_inbox_outbox(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
        }
    }
}