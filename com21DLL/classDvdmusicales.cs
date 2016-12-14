using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classDvdmusicales
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

        public DataSet consulta_dvdmusicales()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_dvdmusicales");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }


        public DataSet consulta_dvdmusicales_id(int IdDvdmusicales)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_dvdmusicales_id");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdDvdmusicales");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdDvdmusicales.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public bool proc_ingresa_dvdmusicales(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "musicalisimobd..sp_ingresa_dvdmusicales", "Dvd"));

        }

        public bool proc_edita_dvdmusicales(string strXmlDatos, int IdDvdmusicales)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdDvdmusicales, "musicalisimobd..sp_edita_dvdmusicales", "Dvd", "@IdDvdmusicales"));
        }

        public bool proc_elimina_dvdmusicales(int IdDvdmusicales)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(IdDvdmusicales, "musicalisimobd..sp_elimina_dvdmusicales", "Dvd", "@IdDvdmusicales"));

        }

        public DataSet consulta_dvdmusicales_prioridad(int Prioridad)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_dvdmusicales_prioridad");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Prioridad");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Prioridad.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public bool proc_edita_dvdmusicales_prioridad(string strXmlDatos, int IdDvdmusicales)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdDvdmusicales, "musicalisimobd..sp_edita_dvdmusicales_prioridad", "Dvd", "@IdDvdmusicales"));
        }

        public DataSet consulta_lista_video()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_lista_video");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet consulta_lista_dos_video(string Genero, int Crud, int IdGenero)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_lista_dos_video");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Genero");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "25");
            elemPrm.SetAttribute("Valor", Genero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Crud");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Crud.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdGenero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdGenero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet consulta_filtro_dvd(string argumento)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_filtro_dvd");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@argumento");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", argumento.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet consulta_galeria_dvdmusicales(int IdProducto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_galeria_dvdmusicales");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdProducto");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdProducto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion
    }
}
