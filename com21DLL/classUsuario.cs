using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using com21DLL;

namespace com21DLL
{
    public class classUsuario
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
        //public int Prioridad 
        //{ 
        //    get{|; set; 
        //}
        #endregion

        public bool editar_clave_administrador(string strXmlDatos, int Usuario, string Clave)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar_Password(xmlDatos, Usuario, Clave, "musicalisimobd..sp_edita_clave_admin", "Administrador", "@Usuario", "@Clave"));
        }

        

        public int obtener_id_usuario(string Usuario, string Clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_obtener_id_usuario");
            //Crea el primer parametro @Usuario varchar(50)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "15");
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
            DataSet _usuario = _objBaseDatos.ExecSP(_xmlDatos);
            if (_objBaseDatos.Error)
            {
                error = _objBaseDatos.MsgError;
                return 0;
            }
            else
            {
                if (_usuario.Tables[0].Rows.Count == 0)
                {
                    error = "Usuario no Existe";
                    return 0;
                }
                else
                {
                    int id = 0;
                    foreach (DataRow dr in _usuario.Tables[0].Rows)
                    {
                        id = int.Parse(dr[0].ToString());
                    }
                    return id;
                }
            }
        }

        

        public DataSet consulta_id_user(string Usuario, string Clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_valida_usuario");

            //Crea el primer parametro @Usuario varchar(50)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "15");
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

        public DataSet consulta_usuario()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_usuario");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet consulta_usuario_id(int IdUsuario)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_usuario_id");

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

        public bool editar_clave_usuario(string strXmlDatos, int IdUsuario, string Clave)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar_Password(xmlDatos, IdUsuario, Clave, "musicalisimobd..sp_edita_clave_user", "Usuario", "@IdUsuario", "@Clave"));
        }

        public bool valida_usuario(string Usuario, string Clave)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_valida_usuario");
            //Crea el primer parametro @Usuario varchar(50)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Usuario");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "15");
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

        public bool proc_ingresa_usuario(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "musicalisimobd..sp_ingresa_usuario", "Usuario"));

        }

        public bool proc_edita_usuario(string strXmlDatos, int IdUsuario)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdUsuario, "musicalisimobd..sp_edita_usuario", "Usuario", "@IdUsuario"));
        }

        public bool proc_elimina_usuario(int IdUsuario)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(IdUsuario, "musicalisimobd..sp_elimina_usuario", "Usuario", "@IdUsuario"));

        }
        public DataSet ConsultaCiudadesProv(int Provincia)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_nt_ConsultaCiudadesProvId");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Provincia");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "5");
            elemPrm.SetAttribute("Valor", Provincia.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _paciente = _objBaseDatos.ExecSP(_xmlDatos);
            return _paciente;
        }

       
        public DataSet ConsultaProvincia(int Pais)
        {
            
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_nt_consulta_ProvinciaPaisId");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Pais");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "5");
            elemPrm.SetAttribute("Valor", Pais.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _paciente = _objBaseDatos.ExecSP(_xmlDatos);
            return _paciente;
        }

        public DataSet ConsultaPrioridad(int Prioridad)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_nt_ConsultaPrioridadId");

            //Crea el parametro @Codigo nchar(5)
            //elemPrm = _xmlDatos.CreateElement("Parametro");
            //elemPrm.SetAttribute("Nombre", "@Provincia");
            //elemPrm.SetAttribute("TipoDato", "Int");
            //elemPrm.SetAttribute("Longitud", "5");
            //elemPrm.SetAttribute("Valor", Provincia.ToString());
            //elemPrm.SetAttribute("Direccion", "Input");
            //_xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _paciente = _objBaseDatos.ExecSP(_xmlDatos);
            return _paciente;
        }
    }
}
