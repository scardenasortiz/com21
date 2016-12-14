using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classAutocompletador
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

        //public DataSet consulta_cancion()
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_cancion");
        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}


        //public DataSet consulta_cancion_id(int IdCancion)
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_cancion_id");

        //    //Crea el parametro @Codigo nchar(5)
        //    elemPrm = _xmlDatos.CreateElement("Parametro");
        //    elemPrm.SetAttribute("Nombre", "@IdCancion");
        //    elemPrm.SetAttribute("TipoDato", "Int");
        //    elemPrm.SetAttribute("Longitud", "4");
        //    elemPrm.SetAttribute("Valor", IdCancion.ToString());
        //    elemPrm.SetAttribute("Direccion", "Input");
        //    _xmlDatos.DocumentElement.AppendChild(elemPrm);

        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}

        //public DataSet consulta_cancion_prioridad(int Prioridad)
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_cancion_prioridad");

        //    //Crea el parametro @Codigo nchar(5)
        //    elemPrm = _xmlDatos.CreateElement("Parametro");
        //    elemPrm.SetAttribute("Nombre", "@Prioridad");
        //    elemPrm.SetAttribute("TipoDato", "Int");
        //    elemPrm.SetAttribute("Longitud", "4");
        //    elemPrm.SetAttribute("Valor", Prioridad.ToString());
        //    elemPrm.SetAttribute("Direccion", "Input");
        //    _xmlDatos.DocumentElement.AppendChild(elemPrm);

        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}

        public DataSet autocompletador(String Auto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_autocompletar");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Auto");
            elemPrm.SetAttribute("TipoDato", "Nvarchar");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Auto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
           
           return _solicitud;
        }
        #endregion

       
    }
}
