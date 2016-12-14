using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classAdministrador
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

        #region "Métodos Públicos Menú Costo de Envio"
        
        #region "País"
        public DataSet Consulta_CostoEnvio_Pais()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Pais");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_CostoEnvio_Pais_id(int Id_Pais)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Pais");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Pais.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_CostoEnvio_Pais(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Pais", "Ad_Pais"));

        }
        public bool Proc_edita_CostoEnvio_Pais(string strXmlDatos, int Id_Pais)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Pais, "..", "Ad_Pais", "@Id_Pais"));
        }
        public bool Proc_elimina_CostoEnvio_Pais(int Id_Pais)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Pais, "..", "Ad_Pais", "@Id_Pais"));

        }
        #endregion

        #region "Provincia"
        public DataSet Consulta_CostoEnvio_Provincia()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_CostoEnvio_Provincia_id(int Id_Provincia)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Provincia");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Provincia.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_CostoEnvio_Provincia(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Provincia"));

        }
        public bool Proc_edita_CostoEnvio_Provincia(string strXmlDatos, int Id_Provincia)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Provincia, "..", "Ad_Provincia", "@Id_Provincia"));
        }
        public bool Proc_elimina_CostoEnvio_Provincia(int Id_Provincia)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Provincia, "..", "Ad_Provincia", "@Id_Provincia"));

        }
        #endregion

        #region "Ciudades"
        //public DataSet Consulta_CostoEnvio_Ciudades()
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}
        //public DataSet Consulta_CostoEnvio_Ciudades_id(int Id_Ciudad)
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

        //    //Crea el parametro @Codigo nchar(5)
        //    elemPrm = _xmlDatos.CreateElement("Parametro");
        //    elemPrm.SetAttribute("Nombre", "@Id_Ciudad");
        //    elemPrm.SetAttribute("TipoDato", "Int");
        //    elemPrm.SetAttribute("Longitud", "4");
        //    elemPrm.SetAttribute("Valor", Id_Ciudad.ToString());
        //    elemPrm.SetAttribute("Direccion", "Input");
        //    _xmlDatos.DocumentElement.AppendChild(elemPrm);

        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}
        //public bool Proc_ingresa_CostoEnvio_Ciudades(string strXmlDatos)
        //{
        //    XmlDocument xmlDatos = new XmlDocument();
        //    xmlDatos.LoadXml(strXmlDatos);
        //    return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Ciudad"));

        //}
        //public bool Proc_edita_CostoEnvio_Ciudades(string strXmlDatos, int Id_Ciudad)
        //{
        //    XmlDocument xmlDatos = new XmlDocument();
        //    xmlDatos.LoadXml(strXmlDatos);
        //    return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Ciudad, "..", "Ad_Ciudad", "@Id_Ciudad"));
        //}
        //public bool Proc_elimina_CostoEnvio_Provincia(int Id_Ciudad)
        //{
        //    return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Ciudad, "..", "Ad_Ciudad", "@Id_Ciudad"));

        //}
        #endregion

        #region "Costo de Envio"
        public DataSet Consulta_CostoEnvio()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_CostoEnvio_id(int Id_Costo)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Costo");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Costo.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_CostoEnvio(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Costo"));

        }
        public bool Proc_edita_CostoEnvio(string strXmlDatos, int Id_Costo)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Costo, "..", "Ad_Costo", "@Id_Costo"));
        }
        public bool Proc_elimina_CostoEnvio(int Id_Costo)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Costo, "..", "Ad_Costo", "@Id_Costo"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Empresa"

        #region "Nosotros"
        public DataSet Consulta_Empresa_Nosotros()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Empresa_Nosotros_id(int Id_Nosotros)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Nosotros");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Nosotros.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Empresa_Nosotros(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Nosotros"));

        }
        public bool Proc_edita_Empresa_Nosotros(string strXmlDatos, int Id_Nosotros)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Nosotros, "..", "Ad_Nosotros", "@Id_Nosotros"));
        }
        public bool Proc_elimina_Empresa_Nosotros(int Id_Nosotros)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Nosotros, "..", "Ad_Nosotros", "@Id_Nosotros"));

        }
        #endregion

        #region "Misión y Visión"
        public DataSet Consulta_Empresa_MisionVision()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Empresa_MisionVision_id(int Id_Empresa)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Empresa");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Empresa.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Empresa_MisionVision(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_MV"));

        }
        public bool Proc_edita_Empresa_MisionVision(string strXmlDatos, int Id_Empresa)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Empresa, "..", "Ad_MV", "@Id_Empresa"));
        }
        public bool Proc_elimina_Empresa_MisionVision(int Id_Empresa)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Empresa, "..", "Ad_MV", "@Id_Empresa"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Productos"

        #region "Imagenes"
        public DataSet Consulta_Productos_Imagenes()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Productos_Imagenes_id(int Id_Imagenes)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

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
        public bool Proc_ingresa_Productos_Imagenes(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Imagenes"));

        }
        public bool Proc_edita_Productos_Imagenes(string strXmlDatos, int Id_Imagenes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Imagenes, "..", "Ad_Imagenes", "@Id_Imagenes"));
        }
        public bool Proc_elimina_Productos_Imagenes(int Id_Imagenes)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Imagenes, "..", "Ad_Imagenes", "@Id_Imagenes"));

        }
        #endregion

        #region "Items"
        public DataSet Consulta_Productos_Items()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Productos_Items_id(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

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
        public bool Proc_ingresa_Productos_Items(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Producto"));

        }
        public bool Proc_edita_Productos_Items(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "..", "Ad_Producto", "@Id_Producto"));
        }
        public bool Proc_elimina_Productos_Items(int Id_Producto)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Producto, "..", "Ad_Producto", "@Id_Producto"));

        }
        #endregion

        #region "Categoria"
        public DataSet Consulta_Productos_Categoria()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Productos_Categoria_id(int Id_Categoria)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Categoria");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Categoria.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Productos_Categoria(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Categoria"));

        }
        public bool Proc_edita_Productos_Categoria(string strXmlDatos, int Id_Categoria)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Categoria, "..", "Ad_Categoria", "@Id_Categoria"));
        }
        public bool Proc_elimina_Productos_Categoria(int Id_Categoria)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Categoria, "..", "Ad_Categoria", "@Id_Categoria"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Reportes"

        #region "Productos"
        public DataSet Consulta_Reportes_Productos()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Reportes_Productos_id(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

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
        public bool Proc_ingresa_Reportes_Productos(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Producto"));

        }
        public bool Proc_edita_Reportes_Productos(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "..", "Ad_Producto", "@Id_Producto"));
        }
        public bool Proc_elimina_Reportes_Productos(int Id_Producto)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Producto, "..", "Ad_Producto", "@Id_Producto"));

        }
        #endregion

        #region "Transacciones"
        public DataSet Consulta_Reportes_Transacciones()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Reportes_Transacciones_id(int Id_Transacciones)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Transacciones");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Transacciones.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Reportes_Transacciones(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Transacciones"));

        }
        public bool Proc_edita_Reportes_Transacciones(string strXmlDatos, int Id_Transacciones)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Transacciones, "..", "Ad_Transacciones", "@Id_Transacciones"));
        }
        public bool Proc_elimina_Reportes_Transacciones(int Id_Transacciones)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Transacciones, "..", "Ad_Transacciones", "@Id_Transacciones"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Galería Fotográfica"

        #region "Imagenes"
        public DataSet Consulta_Galeria_Imagenes()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Galeria_Imagenes_id(int Id_Slide)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Slide");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Slide.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Galeria_Imagenes(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Slide"));

        }
        public bool Proc_edita_Galeria_Imagenes(string strXmlDatos, int Id_Slide)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Slide, "..", "Ad_Slide", "@Id_Slide"));
        }
        public bool Proc_elimina_Galeria_Imagenes(int Id_Slide)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Slide, "..", "Ad_Slide", "@Id_Slide"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Videos Promocionales"

        #region "Videos"
        public DataSet Consulta_Promocionales_Videos()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Promocionales_Videos_id(int Id_VideosP)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_VideosP");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_VideosP.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Promocionales_Videos(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Videos"));

        }
        public bool Proc_edita_Promocionales_Videos(string strXmlDatos, int Id_VideosP)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_VideosP, "..", "Ad_Videos", "@Id_VideosP"));
        }
        public bool Proc_elimina_Promocionales_Videos(int Id_VideosP)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_VideosP, "..", "Ad_Videos", "@Id_VideosP"));

        }
        #endregion

        #endregion

        #region "Métodos Públicos Menú Usuarios Administradores"

        #region "Nuevo Usuario"
        public DataSet Consulta_Usuarios_Administradores()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_Usuarios_Administradores_id(int Id_Administradores)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Administradores");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Administradores.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_Usuarios_Administradores(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Administrador"));

        }
        public bool Proc_edita_Usuarios_Administradores(string strXmlDatos, int Id_Administradores)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Administradores, "..", "Ad_Administrador", "@Id_Administradores"));
        }
        public bool Proc_elimina_Usuarios_Administradores(int Id_Administradores)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Administradores, "..", "Ad_Administrador", "@Id_Administradores"));

        }
        #endregion

        #region "Asignar Perfil"
        //public DataSet Consulta_Usuarios_Administradores()
        //{

        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}
        //public DataSet Consulta_Usuarios_Administradores_id(int Id_Administradores)
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

        //    //Crea el parametro @Codigo nchar(5)
        //    elemPrm = _xmlDatos.CreateElement("Parametro");
        //    elemPrm.SetAttribute("Nombre", "@Id_Administradores");
        //    elemPrm.SetAttribute("TipoDato", "Int");
        //    elemPrm.SetAttribute("Longitud", "4");
        //    elemPrm.SetAttribute("Valor", Id_Administradores.ToString());
        //    elemPrm.SetAttribute("Direccion", "Input");
        //    _xmlDatos.DocumentElement.AppendChild(elemPrm);

        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}
        //public bool Proc_ingresa_Usuarios_Administradores(string strXmlDatos)
        //{
        //    XmlDocument xmlDatos = new XmlDocument();
        //    xmlDatos.LoadXml(strXmlDatos);
        //    return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Administrador"));

        //}
        //public bool Proc_edita_Usuarios_Administradores(string strXmlDatos, int Id_Administradores)
        //{
        //    XmlDocument xmlDatos = new XmlDocument();
        //    xmlDatos.LoadXml(strXmlDatos);
        //    return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Administradores, "..", "Ad_Administrador", "@Id_Administradores"));
        //}
        //public bool Proc_elimina_Usuarios_Administradores(int Id_Administradores)
        //{
        //    return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Administradores, "..", "Ad_Administrador", "@Id_Administradores"));

        //}
        #endregion

        #region "Cambiar Claves"
        #endregion

        #endregion

        #region "Métodos Públicos Menú Usuarios Cliente"

        #region "Consulta Usuario"
        public DataSet Consulta_UsuariosCliente_Usuario()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Consulta_UsuariosCliente_Usuario_id(int Id_Clientes)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "..");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Clientes");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Clientes.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Proc_ingresa_UsuariosCliente_Usuario(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "..", "Ad_Clientes"));

        }
        public bool Proc_edita_UsuariosCliente_Usuario(string strXmlDatos, int Id_Clientes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Clientes, "..", "Ad_Clientes", "@Id_Clientes"));
        }
        public bool Proc_elimina_UsuariosCliente_Usuario(int Id_Clientes)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Clientes, "..", "Ad_Clientes", "@Id_Clientes"));

        }
        #endregion

        #endregion

        #region "Metodos Administrador"
        public bool valida_administrador(string Usuario, string Clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_C_valida_administrador");
            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "100");
            elemPrm.SetAttribute("Valor", Usuario);
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Clave");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "32");
            elemPrm.SetAttribute("Valor", Clave);
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);
            if (_objBaseDatos.Error)
            {
                error = _objBaseDatos.MsgError;
                return true;
            }
            else
            {
                if (_usuario.Tables[0].Rows.Count == 0)
                {
                    error = "Usuario no Existe";
                    return true;
                }
                else
                    return false;
            }
        }
        public DataSet consulta_id_admin(string Usuario, string Clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_C_valida_administrador");

            //Crea el primer parametro @Usuario varchar(50)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "100");
            elemPrm.SetAttribute("Valor", Usuario);
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el primer parametro @Clave varchar(20)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Clave");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "32");
            elemPrm.SetAttribute("Valor", Clave);
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion


    }
}
