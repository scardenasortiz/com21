using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using com21DLL;

namespace com21DLL
{
    public class classCom21Imagenes
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
        public DataSet Com21_consulta_imagenes()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Imagenes");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_imagenes_id(int Id_Imagenes)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ImagenesId");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Imagenes");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Imagenes.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Com21_ingresa_imagenes(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Imagenes", "Ad_Imagenes"));

        }
        public bool Com21_edita_imagenes(string strXmlDatos, int Id_Imagenes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Imagenes, "com21sa20102013_2015..sp_c_Actualiza_Imagenes", "Ad_Imagenes", "@Id_Imagenes"));
        }
        public bool Com21_elimina_imagenes(int Id_Imagenes)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Imagenes, "com21sa20102013_2015..sp_c_Elimina_Imagenes", "Ad_Imagenes", "@Id_Imagenes"));

        }
        public DataSet Com21_consulta_imagenes_mostrar()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Imagenes_Mostrar");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_productos_titulo(string titulo)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ImagenesId");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@titulo");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "500");
            elemPrm.SetAttribute("Valor", titulo.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_imagenes_id_producto(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ImagenesIdProducto");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Producto");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Producto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion
    }
}
