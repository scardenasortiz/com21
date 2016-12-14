using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace com21DLL
{
    public class classCom21Descarga
    {
        #region"Descargas Archivos"
        public void Descargar(string NombreCarpeta, string NombreArchivo, bool forzarDescarga)
        {
            // Ruta y nombre del archivo
            //string path = Path.Combine(Path.GetTempPath()) + NombreArchivo;
            //string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\DatosExportados\\" + NombreArchivo;
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + NombreCarpeta + "\\" + NombreArchivo;
            // Obtiene el nombre del archivo
            string nombre = Path.GetFileName(path);
            // Obtiene la extension del archivo
            string extension = Path.GetExtension(path);
            string type = "";

            // Verifica el tipo de extension
            if (extension != null)
            {
                switch (extension.ToLower())
                {
                    case ".htm":
                    case ".html":
                        type = "text/HTML";
                        break;

                    case ".txt":
                        type = "text/plain";
                        break;

                    case ".doc":
                    case ".rtf":
                    case ".docx":
                        type = "Application/msword";
                        break;

                    case ".xls":
                    case ".xlsx":
                        type = "Application/x-msexcel";
                        break;

                    case ".jpg":
                    case ".jpeg":
                        type = "image/jpeg";
                        break;

                    case ".gif":
                        type = "image/GIF";
                        break;

                    case ".pdf":
                        type = "application/pdf";
                        break;

                    case ".zip":
                        type = "application/octet-stream";
                        break;
                }
            }
            if (forzarDescarga)
            {
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre);
            }
            if (type != "")
            {
                System.Web.HttpContext.Current.Response.ContentType = type;
                System.Web.HttpContext.Current.Response.TransmitFile(path);
                System.Web.HttpContext.Current.Response.End();
            }
        }
        #endregion

       
    }
}
