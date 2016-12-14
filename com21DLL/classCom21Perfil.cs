using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classCom21Perfil
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

        public DataSet Com21_consulta_perfil_opc(int Id_Administrador)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Menu");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Id_Administrador");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Id_Administrador.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        //public DataSet Com21_consulta_pais_id(int Id_Pais)
        //{
        //    XmlDocument _xmlDatos = new XmlDocument();
        //    _xmlDatos.LoadXml("<Procedimiento />");
        //    _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_PaisId");

        //    //Crea el parametro @Codigo nchar(5)
        //    elemPrm = _xmlDatos.CreateElement("Parametro");
        //    elemPrm.SetAttribute("Nombre", "@Id_Pais");
        //    elemPrm.SetAttribute("TipoDato", "Int");
        //    elemPrm.SetAttribute("Longitud", "4");
        //    elemPrm.SetAttribute("Valor", Id_Pais.ToString());
        //    elemPrm.SetAttribute("Direccion", "Input");
        //    _xmlDatos.DocumentElement.AppendChild(elemPrm);

        //    //Ejecutar el Procedimiento
        //    DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
        //    return _solicitud;
        //}

        public bool Com21_ingresa_perfil(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "com21sa20102013_2015..sp_c_Ingresa_Menu", "Ad_Perfil"));

        }

        public bool Com21_edita_perfil(string strXmlDatos, int Id_Perfil)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, Id_Perfil, "com21sa20102013_2015..sp_c_Actualiza_Menu", "Ad_Perfil", "@Id_Perfil"));
        }

        public bool Com21_elimina_perfil(int Id_Perfil)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Perfil, "com21sa20102013_2015..sp_c_Elimina_Menu", "Ad_Perfil", "@Id_Perfil"));

        }

        public bool Com21_activa_administrador(int Id_Administrador)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(Id_Administrador, "com21sa20102013_2015..sp_c_Activar_Administrador", "Ad_Admin", "@Id_Administrador"));

        }
        #endregion
    }
}
