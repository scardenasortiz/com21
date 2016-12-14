using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace com21DLL
{
    public class classCorreo
    {
        #region"Constructor de Clase"
        public classCorreo()
        {

        }
        #endregion

        #region"Metodos Publicos"
        #region"Envio de Correo"
        public bool Enviar_Correo(string body)
        {
            MailMessage MailObj = new MailMessage();

            MailObj.IsBodyHtml = false;
            MailObj.From = new MailAddress("info@com21.com.ec");
            MailObj.To.Add("so_cardenas@hotmail.com");
            MailObj.IsBodyHtml = true;
            MailObj.Priority = MailPriority.High;
            MailObj.Subject = "Error en la pagina de Com21 S.A.";
            MailObj.Body = "<table><tr><td>Ocurrio un error en : " + body + "</td></tr></table>";
            SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                objSMTPClient.Send(MailObj);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region"Envio de Password"
        public void Enviar_Password(DataSet datos, string mail)
        {
            if (datos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in datos.Tables[0].Rows)
                {
                    MailMessage MailObj = new MailMessage();

                    MailObj.IsBodyHtml = true;
                    MailObj.From = new MailAddress("info@musicalisimo.com.ec");
                    MailObj.To.Add(mail);
                    MailObj.IsBodyHtml = true;
                    MailObj.Priority = MailPriority.High;
                    MailObj.Subject = "Confirmación datos de Usuario Musicalisimo";
                    MailObj.Body = "<table><tr><td>Hola " + dr[2].ToString() + " " + dr[3].ToString() + ",</td></tr></tr><tr><td> </td></tr><tr><td> Tus datos de Usuario Musicalisimo para ingresar al Sistema son:</td></tr><tr><td>Usuario: " + dr[4].ToString() + "</td></tr><tr><td>Password: " + dr[5].ToString() + "</td></tr></tr><tr><td> </td></tr><tr><td>Ahora puedes Ingresar a <a href=\"musicalisimo.com.ec/Default.aspx\">Musicalisimo.com.ec</a> !!!</td></tr><tr><td>El equipo de Musicalisimo</td></tr></table>";
                    SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
                    //objSMTPClient.Credentials = new NetworkCredential("jgallegos@soluwebsa.com", "12345678");
                    objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    objSMTPClient.Send(MailObj);
                }
            }
        }
        #endregion

        #region"Envia Email al Nuevo Usuario"
        public void Enviar_Mail_Nuevo_Usuario(DataSet datos, string mail)
        {
            if (datos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in datos.Tables[0].Rows)
                {

                    MailMessage MailObj = new MailMessage();

                    MailObj.IsBodyHtml = false;
                    MailObj.From = new MailAddress("info@musicalisimo.com.ec");
                    MailObj.To.Add(mail);
                    MailObj.IsBodyHtml = true;
                    MailObj.Priority = MailPriority.High;
                    MailObj.Subject = "Bienvenido al Sistema Musicalisimo ";
                    MailObj.Body = "<table><tr><td>Hola " + dr[1].ToString() + " " + dr[2].ToString() + ",</td></tr></tr><tr><td> </td></tr><tr><td> Te damos la cordial Bienvenida al Sistema Musicalisimo.</td></tr><tr><td>Tus datos de Usuario Musicalisimo para ingresar al Sistema son:</td></tr><tr><td>Usuario: " + dr[13].ToString() + "</td></tr><tr><td>Password: " + dr[14].ToString() + "</td></tr></tr><tr><td> </td></tr><tr><td>Ahora puedes Ingresar a <a href=\"musicalisimo.com.ec/Default.aspx\">Musicalisimo</a> !!!</td></tr><tr><td>El equipo de Musicalisimo</td></tr></table>";
                    SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
                    objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    objSMTPClient.Send(MailObj);
                }
            }
        }
        #endregion

        #endregion
       
    }
}
