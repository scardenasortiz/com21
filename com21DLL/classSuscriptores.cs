using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using com21DLL;

namespace com21DLL
{
    public class classSuscriptores
    {
        #region "Propiedades Privadas"
        com21DLL _objBaseDatos = new com21DLL();
        classTrans _objRetorno = new classTrans();
        XmlElement elemPrm;
        private DataSet _Ds;
        #endregion

        #region Atributos
        private string error;
        public string _MsgError;
        #endregion

        #region Propiedades Publicas
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        public string MsgError
        {
            get { return _MsgError; }
        }
        public DataSet DataSet
        {
            get { return _Ds; }
            set { _Ds = value; }
        }
        public bool Verifica_Error(bool Valor)
        {
            if (Valor)
            {
                error = _objRetorno._MsgError;
                return true;
            }
            else
            {
                DataSet = _objRetorno.DataSet;
                return false;
            }
        }
        #endregion

        #region "Métodos Públicos"

        public DataSet consulta_suscriptores()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_suscriptor");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet consulta_suscriptores_id(int IdSuscriptores)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_suscriptor_id");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdSuscriptores");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdSuscriptores.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool proc_ingresa_suscriptores(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "musicalisimobd..sp_ingresa_suscriptor", "Suscriptor"));

        }
        public bool proc_edita_suscriptores(string strXmlDatos, int IdSuscriptores)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdSuscriptores, "musicalisimobd..sp_edita_suscriptor", "Suscriptor", "@IdSuscriptores"));
        }
        public bool proc_elimina_suscriptores(int IdAgencia)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(IdAgencia, "musicalisimobd..sp_elimina_suscriptor", "Suscriptor", "@IdSuscriptores"));

        }
        public int obtener_usuario_id(string usuario, string clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_obtener_suscriptor_id");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", usuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@clave");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", clave.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            if (_objBaseDatos.Error)
            {
                error = _objBaseDatos.MsgError;
                return 0;
            }
            else
            {
                if (_solicitud.Tables[0].Rows.Count == 0)
                {
                    error = "Usuario no Existe";
                    return 0;
                }
                else
                {
                    int id = 0;
                    foreach (DataRow dr in _solicitud.Tables[0].Rows)
                    {
                        id = int.Parse(dr[0].ToString());
                    }
                    return id;
                }
            }
        }
        public DataSet consulta_usuario_especifico(string Usuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "sp_consulta_usuario_especifico");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "15");
            elemPrm.SetAttribute("Valor", Usuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet consulta_email_especifico(string Email)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "sp_consulta_email_especifico");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@mail");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", Email.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion
    }
}
