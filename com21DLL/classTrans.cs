using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classTrans
    {
        #region "Propiedades Privadas"
        com21DLL _ObjBaseDatos = new com21DLL();
        XmlElement ElemPrm;
        XmlDocument _docXmlRetorno;
        private DataSet _Ds;
        public string _MsgError;
        #endregion

        #region "Propiedades Públicas"
        public DataSet DataSet
        {
            get { return _Ds; }
            set { _Ds = value; }

        }
        public string MsgError
        {
            get { return _MsgError; }
        }
        public XmlDocument DocXmlRetorno
        {
            get { return _docXmlRetorno; }

        }
        #endregion

        #region "Métodos Públicos"

        #region"Procedimiento de Ingresar"
        public bool Proc_Ingresar(XmlDocument xmlDatos, string Nombre_Procedimiento, string Nodo_Nombre)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Procedimiento de Actualizar"
        public bool Proc_Actualizar(XmlDocument xmlDatos, int Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_ActualizarUrl(string Url, int Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_ParametroUrl, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_ParametroUrl);
            ElemPrm.SetAttribute("TipoDato", "NVarchar");
            ElemPrm.SetAttribute("Longitud", Url.Length.ToString());
            ElemPrm.SetAttribute("Valor", Url);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_ActualizarXString(XmlDocument xmlDatos, string Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "50");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_ActualizarxStock(XmlDocument xmlDatos, int Id_Parametro, int IdParametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string NombreParametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", NombreParametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdParametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_ActualizarGeneral(string Tipo, int Id_Parametro, int cantidad, int Id_Usu, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Tipo, string Nombre_Parametro, string Nombre_cantidad, string Nombre_Usu)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Tipo);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "100");
            ElemPrm.SetAttribute("Valor", Tipo.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_cantidad);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", cantidad.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Usu);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Usu.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Procedimiento de Eliminacion"
        public bool Proc_Eliminacion(int Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "int");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _Ds = _ObjBaseDatos.ExecSP(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_Elimina_Producto_Prefactura(int IdUsuario, int IdPrefactura, string Nombre_Procedimiento, string Nodo_Nombre, string Usuario, string Prefactura)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Usuario);
            ElemPrm.SetAttribute("TipoDato", "int");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdUsuario.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);


            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Prefactura);
            ElemPrm.SetAttribute("TipoDato", "int");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdPrefactura.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);


            _Ds = _ObjBaseDatos.ExecSP(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Verifica Error"
        private bool Verificar_Error()
        {
            if (_ObjBaseDatos.Error)
            {
                _MsgError = _ObjBaseDatos.MsgError;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region"Generacion de XML de Salida"
        private static XmlDocument XMLGenera(string Nombre_Procedimiento, string Nodo_Nombre)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<" + Nodo_Nombre + "/>");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", Nombre_Procedimiento);
            return _xmlDatos;
        }
        #endregion

        //Metodos con ID

        #region"Ingresa Registro"
        public bool Proc_Ingresar_ID(XmlDocument xmlDatos, string Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Actualiza Registro"
        public bool Proc_Actualizar_ID(XmlDocument xmlDatos, string Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();

        }
        public bool Proc_Actualizar_IDPP(XmlDocument xmlDatos, string Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "NVarCar");
            ElemPrm.SetAttribute("Longitud", "50");
            ElemPrm.SetAttribute("Valor", Id_Parametro);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();

        }
        #endregion

        #region"Eliminacion de Registro"
        public bool Proc_Eliminacion_ID(string Id_Parametro, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "20");
            ElemPrm.SetAttribute("Valor", Id_Parametro);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _Ds = _ObjBaseDatos.ExecSP(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Actualiza Password"
        public bool Proc_Actualizar_Password(XmlDocument xmlDatos, int Id_Parametro, string Adm_Password, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Id_Parametro.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "10");
            ElemPrm.SetAttribute("Valor", Adm_Password);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);
            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #region"Ingresa Prefactura"
        public bool Proc_Ingresa_Prefacturas(XmlDocument xmlDatos, string Nombre_Procedimiento, string Nodo_Nombre)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_Ingresa_Prefactura(XmlDocument xmlDatos, int IdProducto, int Stock, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdProducto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", Stock.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        
        #endregion

        #region"Actualiza Prefactura"
        public bool Proc_Actualiza_Producto_Repetido(XmlDocument xmlDatos, int IdUsuario, int IdProducto, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdUsuario.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdProducto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        public bool Proc_Actualiza_Producto_Repetido_Nuevo(XmlDocument xmlDatos, int IdUsuario, int IdProducto, string Producto, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password, string Nombre_Producto)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", "@xmlDatos");
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", xmlDatos.OuterXml.Length.ToString());
            ElemPrm.SetAttribute("Valor", xmlDatos.OuterXml);
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdUsuario.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdProducto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Producto);
            ElemPrm.SetAttribute("TipoDato", "String");
            ElemPrm.SetAttribute("Longitud", "25");
            ElemPrm.SetAttribute("Valor", Producto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }

        public bool Proc_Actualiza_Total_Prefactura(int IdProducto, int IdUsuario, string Producto, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password, string Nombre_Producto)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdProducto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdUsuario.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Producto);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "50");
            ElemPrm.SetAttribute("Valor", Producto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }

        public bool Proc_Actualiza_Ingreso_Ordenes(string CodUpdate, int IdUsuario, string Producto, string Nombre_Procedimiento, string Nodo_Nombre, string Nombre_Parametro, string Nombre_Password, string Nombre_Producto)
        {
            XmlDocument _xmlDatos = XMLGenera(Nombre_Procedimiento, Nodo_Nombre);
            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Parametro);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "50");
            ElemPrm.SetAttribute("Valor", CodUpdate.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Password);
            ElemPrm.SetAttribute("TipoDato", "Integer");
            ElemPrm.SetAttribute("Longitud", "4");
            ElemPrm.SetAttribute("Valor", IdUsuario.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            ElemPrm = _xmlDatos.CreateElement("Parametro");
            ElemPrm.SetAttribute("Nombre", Nombre_Producto);
            ElemPrm.SetAttribute("TipoDato", "NVarChar");
            ElemPrm.SetAttribute("Longitud", "50");
            ElemPrm.SetAttribute("Valor", Producto.ToString());
            ElemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(ElemPrm);

            _docXmlRetorno = _ObjBaseDatos.ExecSP_XML(_xmlDatos);
            return Verificar_Error();
        }
        #endregion

        #endregion
    }
}
