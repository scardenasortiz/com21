using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;
using System.Web.UI.WebControls;

namespace com21DLL
{
    public class classCom21Cliente
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
        public DataSet Com21_consulta_valida_cliente(String usuario, String clave)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_valida_cliente");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@usuario");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "500");
            elemPrm.SetAttribute("Valor", usuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@clave");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "32");
            elemPrm.SetAttribute("Valor", clave.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_cliente()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Cliente");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_cliente_id(int Id_Clientes)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ClienteId");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Clientes");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Clientes.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_recuperar_clave_cliente(String Dato, String Ident)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_recupera_clave_cliente");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Dato");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "500");
            elemPrm.SetAttribute("Valor", Dato.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Com21_ingresa_cliente(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Clientes", "Ad_Clientes"));

        }
        public bool Com21_edita_cliente(string strXmlDatos, int Id_Clientes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Clientes, "com21sa20102013_2015..sp_c_Actualiza_Clientes", "Ad_Clientes", "@Id_Clientes"));
        }
        public bool Com21_edita_clave_cliente(string strXmlDatos, int Id_Clientes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Clientes, "com21sa20102013_2015..sp_c_Actualiza_Clientes_Clave", "Ad_Clientes", "@Id_Clientes"));
        }
        public DataSet Com21_consulta_valida_user(String Usuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Cliente_User");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "NVarChar");
            elemPrm.SetAttribute("Longitud", "50");
            elemPrm.SetAttribute("Valor", Usuario.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_cliente_letra(String Letra)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Cliente_Letra");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Letra");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Letra.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_cliente_DatosCompra(int Id_Clientes, int Inicio)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_IdentCompras");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Clientes.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Com21_ingresa_cliente_DatosCompra(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_IdentCompras", "Actualizar"));

        }
        public bool Com21_edita_cliente_DatosCompra(string strXmlDatos, int Id_Clientes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Clientes, "com21sa20102013_2015..sp_c_Actualiza_IdentCompra", "Actualizar", "@IdUsuario"));
        }
        public bool Com21_elimina_cliente_DatosCompra(int Id_Clientes)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Clientes, "com21sa20102013_2015..sp_c_Elimina_IdentCompras", "Actualizar", "@IdUsuario"));

        }

        #region "METODOS DE direccion envio"
        public DataSet Com21_consulta_cliente_direccio_envio(int Id_Clientes)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Cliente_Direccion_Envio");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Clientes");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Clientes.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public bool Com21_ingresa_cliente_direccion(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Clientes_Direcciones", "Ad_Clientes"));

        }
        public bool Com21_edita_cliente_direccion(string strXmlDatos, int Id_Clientes)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Clientes, "com21sa20102013_2015..sp_c_Actualiza_Clientes_Direcciones", "Ad_Clientes", "@Id_Clientes"));
        }
        #endregion

        public DataSet Com21_consulta_cliente_correo_clave(string Correo)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ClienteCorreo");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Correo");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "1000");
            elemPrm.SetAttribute("Valor", Correo.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public XmlDocument Com21_consulta_clientesolo_prueba()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Cliente");

            //Ejecutar el Procedimiento
            XmlDocument _solicitud = new XmlDocument();
            _solicitud = _objBaseDatos.ExecSP_XML(_xmlDatos);
            return _solicitud;
        }

        #region "para consultar historial de compras del cliente en el administrador"
        public DataSet com21_clienteCom21_consulta_cliente_historial_compras(int IdUsuario)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_historial_Compras_Usuario");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdUsuario");
            elemPrm.SetAttribute("TipoDato", "int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdUsuario.ToString());
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
