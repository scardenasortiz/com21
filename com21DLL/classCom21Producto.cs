using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classCom21Producto
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
        public string ObtenerUrl(String puerto)
        {
            String result = string.Empty;
            if (puerto == "localhost:2304")
            {
            }
            else
            {
            }
            return result;
        }

        public DataSet Com21_consulta_productos()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_id(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ProductosId");

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

        public DataSet Com21_consulta_productos_id_Web(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ProductosId_Mostrar");

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

        public bool Com21_ingresa_productos(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Productos", "Ad_Productos"));

        }

        public bool Com21_edita_productos(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "com21sa20102013_2015..sp_c_Actualiza_Productos", "Ad_Productos", "@Id_Producto"));
        }

        public bool Com21_elimina_productos(int Id_Producto)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Producto, "com21sa20102013_2015..sp_c_Elimina_Productos", "Ad_Productos", "@Id_Producto"));

        }

        public DataSet Com21_consulta_productos_letra(string Letra)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Producto_Letra");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Letra");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", Letra.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_tituloid(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Producto_Titulo");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Producto");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Producto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public bool Com21_edita_productos_Url(string Url, int Id_Producto)
        {
            return Verifica_Error(_objRetorno.Proc_ActualizarUrl(Url, Id_Producto, "com21sa20102013_2015..sp_c_Actualiza_ProductosUrlProductos", "Ad_Productos", "@Url", "@Id_Producto"));
        }

        public bool Com21_edita_productos_marca(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "com21sa20102013_2015..sp_c_Actualiza_Productos_Marca", "Ad_Productos", "@Id_Producto"));
        }

        public bool Com21_edita_productos_sub_categoria(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "com21sa20102013_2015..sp_c_Actualiza_Productos_SubCat", "Ad_Productos", "@Id_Producto"));
        }

        public DataSet Com21_consulta_productos_marca()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Marca");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_sub_categoria()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Sub_Cat");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_web_numero(int Numero, int Sub, int Des)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Numero");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_web_precio(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Precio");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);
            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_ultimo()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Ultimo_Ingresado");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_marca_sub(int Id_SubCategoria)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Marca_SubCat");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_SubCategoria");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_SubCategoria.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_web_numero_marca_id(int Numero, int Sub, int Des, int Id_Marca)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Numero_Marca_Id");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Marca");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Marca.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_web_marcar(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident, int Id_Marca)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Marca_Id");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Marca");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Marca.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_web_categoria_nosub(int Cat, int Sub)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Categoria_NoSub");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Cat");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Cat.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_catalgo_productos_web()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Catalogo_Producto_Web");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        #region "Catalogo Productos"
        public DataSet Com21_consulta_productos_Catalogo_web_numero(int Numero, int Des)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Catalogo_Inicio");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //elemPrm = _xmlDatos.CreateElement("Parametro");
            //elemPrm.SetAttribute("Nombre", "@Sub");
            //elemPrm.SetAttribute("TipoDato", "Int");
            //elemPrm.SetAttribute("Longitud", "4");
            //elemPrm.SetAttribute("Valor", Sub.ToString());
            //elemPrm.SetAttribute("Direccion", "Input");
            //_xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_productos_Catalogo_web_numero_Sub(int Numero, int Sub, int Des)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Catalogo_Numero_Sub");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_productos_Catalogo_web_precio(string Inicio, string Fin, int Numero, int Des, int Ident)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Catalogo_Precio");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //elemPrm = _xmlDatos.CreateElement("Parametro");
            //elemPrm.SetAttribute("Nombre", "@Sub");
            //elemPrm.SetAttribute("TipoDato", "Int");
            //elemPrm.SetAttribute("Longitud", "4");
            //elemPrm.SetAttribute("Valor", Sub.ToString());
            //elemPrm.SetAttribute("Direccion", "Input");
            //_xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_productos_Catalogo_web_precio_Sub(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Catalogo_Precio_Sub");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Sub");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Sub.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion

        public DataSet Com21_consulta_productos_cantidad_id(int Id_Producto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Cantidad");

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

        public bool Com21_edita_productos_cantidad_restar(string strXmlDatos, int Id_Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Producto, "com21sa20102013_2015..sp_c_Actualiza_Productos_Cantidad_Restar", "Ad_Productos", "@Id_Producto"));
        }

        #region "BUSQUEDA"
        public DataSet Com21_consulta_productos_web_numero_busqueda(int Numero, string Texto, int Des)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Numero_Busqueda");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Texto");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Texto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_productos_web_precio_busqueda(string Inicio, string Fin, int Numero, string Texto, int Des, int Ident)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Precio_Busqueda");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Numero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Numero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Texto");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Texto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Des");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Des.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet Com21_consulta_productos_relacionados(int Id_Producto, int Id_Categoria, int Id_SubCategoria)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Productos_Relacionado");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Producto");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Producto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Categoria");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Categoria.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_SubCategoria");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_SubCategoria.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #endregion
        #endregion
    }
}
