using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace com21DLL
{
    public class classCom21Correo
    {
        #region"Constructor de Clase"
        public classCom21Correo()
        {

        }
        #endregion

        #region"Metodos Publicos"
        #region "Envio de Correo Local - Nube"
        public String EnvioLN(int Ident, MailMessage html)
        {
            SmtpClient objSMTPClient = null;
            if (Ident == 1)
            {
                objSMTPClient = new SmtpClient("smtp.gmail.com", 587);//587
                objSMTPClient.EnableSsl = true;
                objSMTPClient.UseDefaultCredentials = false;
                objSMTPClient.Credentials = new NetworkCredential("com21pagos@gmail.com", "C21PC#1988");
               // objSMTPClient.Credentials = new NetworkCredential("infopagocom21sa@gmail.com", "Com21sa2015");
            }
            else
            {
                objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
                objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            }

            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                objSMTPClient.Send(html);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
        #endregion

    }
}
