using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class Com21classPrefactura
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
        //private System.Data.DataSet _Dss;
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
        public bool proc_ingresa_prefactura(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_ingresa_prefactura", "Prefactura"));
        }
        public DataSet consulta_producto_prefacturado_id_user_cant_tot()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Info_Carrito_Cantidad_Total");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet consulta_producto_repetido(int IdUsuario, int IdProducto)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_consulta_producto_repetido");
            //Crea el primer parametro @Usuario varchar(50)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el primer parametro @Clave varchar(20)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdProducto");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdProducto.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);


            return _usuario;
        }
        public bool proc_actualiza_producto_repetido(string strXmlDatos, int IdUsuario, int IdProducto, string Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualiza_Producto_Repetido_Nuevo(xmlDatos, IdUsuario, IdProducto, Producto, "com21sa20102013_2015..sp_c_actualizar_producto_repetido", "Prefactura", "@IdUsuario", "@IdProducto", "@Producto"));
        }
        public DataSet consulta_producto_prefacturado(int IdUsuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_consulta_producto_prefacturado");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "6");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool proc_edita_producto_prefacturado_carrito(string strXmlDatos, int IdPrefactura)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdPrefactura, "com21sa20102013_2015..sp_c_actualizar_producto_cantidad_carrito", "Prefactura", "@IdPrefactura"));
        }
        public bool proc_elimina_producto_prefactura(int IdUsuario, int IdPrefactura)
        {
            return Verifica_Error(_objRetorno.Proc_Elimina_Producto_Prefactura(IdUsuario, IdPrefactura, "com21sa20102013_2015..sp_c_elimina_producto_prefacturado", "Prefactura", "@IdUsuario", "@IdPrefactura"));

        }
        public bool proc_edita_prefacturaDatosUsuario(string strXmlDatos, int IdUsuario)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdUsuario, "com21sa20102013_2015..sp_c_edita_prefaturaDatosUsuario", "Usuario", "@IdUsuario"));
        }
        public bool proc_edita_codupdate_prefactura(int IdProducto, int IdUsuario, string CodUpdate)
        {
            XmlDocument xmlDatos = new XmlDocument();

            return Verifica_Error(_objRetorno.Proc_Actualiza_Total_Prefactura(IdProducto, IdUsuario, CodUpdate, "com21sa20102013_2015..sp_c_edita_prefaturaCodUpdate", "Prefactura", "@IdProducto", "@IdUsuario", "@CodUpdate"));
        }
        public bool proc_edita_prefacturado_producto_DatosUsuario_CodUpdate(string strXmlDatos, string CodUpdate)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_ActualizarXString(xmlDatos, CodUpdate, "com21sa20102013_2015..sp_c_edita_prefaturaDatosUsuario_CodUpdate", "Prefactura", "@CodUpdate"));
        }
        public bool proc_edita_prefacturado_producto_Estado_CodUpdate(string strXmlDatos, string CodUpdate)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_ActualizarXString(xmlDatos, CodUpdate, "com21sa20102013_2015..sp_c_edita_prefaturaEstado_CodUpdate", "Prefactura", "@CodUpdate"));
        }
        public bool proc_Ingresa_Transaccion(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Transaccion", "Transaccion"));
        }
        public bool proc_Ingresa_DetalleTransaccion(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_DetalleTransaccion", "DetalleTransaccion"));
        }
        public bool proc_Actualiza_Transaccion(string strXmlDatos, string IdTransaccion)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar_IDPP(xmlDatos, IdTransaccion, "com21sa20102013_2015..sp_c_Actualiza_Transaccion", "Transaccion", "@IdTransaccion"));
        }
        public bool proc_actualiza_cantidad_producto_id(int Cant, int IdProducto)
        {
            return Verifica_Error(_objRetorno.Proc_Elimina_Producto_Prefactura(Cant, IdProducto, "com21sa20102013_2015..sp_c_actualiza_producto_cantidad_id", "Producto", "@Cant", "@IdProducto"));

        }
        public bool proc_actualiza_cantidad_producto_id_Menos(int Cant, int IdProducto)
        {
            return Verifica_Error(_objRetorno.Proc_Elimina_Producto_Prefactura(Cant, IdProducto, "com21sa20102013_2015..sp_c_actualiza_producto_cantidad_id_Menos", "Producto", "@Cant", "@IdProducto"));

        }
        public DataSet consulta_producto_prefacturado_IdCod(int IdUsuario, string CodUpdate)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_consulta_producto_prefacturado_IdCod");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "6");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@CodUpdate");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", CodUpdate.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet consulta_prefactura_trans_direccion(int Pais, int Provincia, int Ciudad)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Direccion_Trans_Admin");
            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Pais");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Pais.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Provincia");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Provincia.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ciudad");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ciudad.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);


            return _usuario;
        }
        public bool proc_edita_producto_prefacturado_Fact(string strXmlDatos, string IdTransaccion)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_ActualizarXString(xmlDatos, IdTransaccion, "com21sa20102013_2015..sp_c_edita_Facturado_IdT", "Prefactura", "@IdTransaccion"));
        }
        public DataSet consulta_transaccion_facturada_IdT(string IdTransaccion)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_consulta_producto_facturado_IdT");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdTransaccion");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", IdTransaccion.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #region "INGRESAR ORDENES"
        public bool proc_ingresa_ordenes(string Cod, int IdUsuario, string Trans)
        {
            XmlDocument xmlDatos = new XmlDocument();

            return Verifica_Error(_objRetorno.Proc_Actualiza_Ingreso_Ordenes(Cod, IdUsuario, Trans, "com21sa20102013_2015..sp_c_ingresa_ordenes", "Orden", "@CodUpdate", "@IdUsuario", "@Trans"));
        }
        public DataSet consulta_ordenes(int IdUsuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Ordenes");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);


            return _usuario;
        }
        public DataSet consulta_detalle_orden(int IdUsuario, string IdTransaccion, string cod)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Ordenes_Det");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);
            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdTransaccion");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", IdTransaccion.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@CodUpdate");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", cod.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);


            return _usuario;
        }
        #endregion
        //fin actuales usados





        //antiguos
        public bool proc_edita_producto_prefacturado(string strXmlDatos, int IdUsuario)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdUsuario, "com21sa20102013..edita_producto_prefacturado", "Prefactura", "@IdUsuario"));
        }
        public DataSet consulta_producto_prefacturado_accesorio(int IdUsuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_consulta_producto_prefacturado_accesorio");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        } 
        public bool proc_edita_total_prefactura(int IdProducto, int IdUsuario, string Producto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            
            return Verifica_Error(_objRetorno.Proc_Actualiza_Total_Prefactura(IdProducto, IdUsuario, Producto, "com21sa20102013_2015..sp_edita_total_prefactura", "Prefactura", "@IdProducto", "@IdUsuario", "@Producto"));
        }
        public bool proc_actualiza_stock_producto_accesorio(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_accesorio", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_producto_cancionero(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_cancionero", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_producto_album(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_album", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_producto_longplay(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_longplay", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_producto_instrumento(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_instrumento", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_producto_dvdmusicales(string strXmlDatos, int IdProducto)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdProducto, "com21sa20102013_2015..sp_edita_stock_dvdmusicales", "Producto", "@IdProducto"));
        }
        public bool proc_actualiza_stock_productos_general(string Tipo, int IdProducto, int Cantidad, int Id_Usuario)
        {
            /*XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);*/
            return Verifica_Error(_objRetorno.Proc_ActualizarGeneral(Tipo, IdProducto, Cantidad, Id_Usuario, "com21sa20102013_2015..sp_edita_stock_general", "Producto", "@Tipo", "@IdProducto", "@Cantidad", "@Id_Usuario"));
        }
        
        
        public DataSet consulta_producto_prefacturado_tarifa(int IdUsuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_consulta_producto_prefacturado_tarifa");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        /////costo envio
        public DataSet consulta_costoenvio_IdCiudad(string Ciudad)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_consulta_costoenvio_IdCiudad");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ciudad");
            elemPrm.SetAttribute("TipoDato", "NVarChar");
            elemPrm.SetAttribute("Longitud", "100");
            elemPrm.SetAttribute("Valor", Ciudad.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        #endregion
    }
}
