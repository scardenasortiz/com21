using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

namespace com21DLL
{
    public class com21DLL
    {
        #region "Propiedades Privadas"
            private SqlConnection _Con;
            private SqlCommand _Cmd;
            private SqlParameter _Prm;
            //private SqlTransaction _Trn;
            private SqlDataReader _Dr;
            private DataSet _Ds;
            private bool _Error;
            private string _MsgError;
            private XmlDocument _xmlRetorno;
        #endregion

        #region "Propiedades Públicas"
            public bool Error
            {
                get { return _Error; }
            }

            public string MsgError
            {
                get { return _MsgError; }
            }
        #endregion

        #region "Métodos Privados"

            #region"Seteo de Parametros"
                private void setParametros(XmlDocument xmlDatos)
                {
                    foreach (XmlNode Nodo in xmlDatos.SelectNodes("//Parametro"))
                    {//Procesar cada elemento parametro
                        XmlElement Elem = (XmlElement)Nodo; //Convertir el Nodo a Elemento
                        _Prm = new SqlParameter();
                        _Prm.ParameterName = Elem.GetAttribute("Nombre");
                        _Prm.Value = Elem.GetAttribute("Valor");
                        _Prm.Direction = getDireccion(Elem.GetAttribute("Direccion"));
                        _Prm.SqlDbType = getTipoDato(Elem.GetAttribute("TipoDato"));
                        _Prm.Size = int.Parse(Elem.GetAttribute("Longitud"));
                        _Cmd.Parameters.Add(_Prm); //Asig. el Prm al comando
                    }
                }
            #endregion

            #region"Obtiene la direccion del campo"
                private ParameterDirection getDireccion(string Direccion)
                {
                    ParameterDirection _retorna = ParameterDirection.Input;

                    switch (Direccion)
                    {
                        case "Input": _retorna = ParameterDirection.Input; break;
                        case "Output": _retorna = ParameterDirection.Output; break;
                        case "InputOutput": _retorna = ParameterDirection.InputOutput; break;
                        case "Return": _retorna = ParameterDirection.ReturnValue; break;
                    }

                    return _retorna;
                }
            #endregion

            #region"Obtiene el Tipo del Campo"
                private SqlDbType getTipoDato(string TipoDato)
                {
                    SqlDbType _retorna = SqlDbType.VarChar;

                    switch (TipoDato)
                    {
                        case "Char": _retorna = SqlDbType.Char; break;
                        case "varchar": _retorna = SqlDbType.VarChar; break;
                        case "integer": _retorna = SqlDbType.Int; break;
                        case "Date": _retorna = SqlDbType.DateTime; break;
                        case "smalldatetime": _retorna = SqlDbType.SmallDateTime; break;
                        case "decimal": _retorna = SqlDbType.Decimal; break;
                        case "double": _retorna = SqlDbType.Float; break;
                        case "text": _retorna = SqlDbType.Text; break;
                        case "NVarChar": _retorna = SqlDbType.NVarChar; break;
                        case "NChar": _retorna = SqlDbType.NChar; break;
                    }

                    return _retorna;
                }
            #endregion

            #region"Genera XML de Salida"
                private void GeneraXmlSalida()
                {
                    _xmlRetorno = new XmlDocument();
                    _xmlRetorno.LoadXml("<Recordset />");
                    XmlElement _elem;
                    while (_Dr.Read())
                    {
                        _elem = _xmlRetorno.CreateElement("Row");
                        foreach (DataRow dc in _Dr.GetSchemaTable().Rows)
                        {//Por cada columna llevamos un atributo
                            _elem.SetAttribute(dc[0].ToString(), _Dr[dc[0].ToString()].ToString());
                        }
                        _xmlRetorno.DocumentElement.AppendChild(_elem); //agregamos el registro
                    }
                }
            #endregion

        #endregion

        #region "Métodos Públicos"

            #region"Constructor de la Clase"
                public com21DLL()
                {
                    //SETEAR CONEXIÓN
                    StringBuilder StrCon = new StringBuilder();
                    _Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Com21ConnectionString"].ConnectionString);
                }    
            #endregion

            #region"Ejecuta Store Procedure y Devuele DataSet"
                public DataSet ExecSP(XmlDocument XmlDatos)
                {
                    try
                    {
                        _Error = false; _MsgError = "";
                        _Con.Open(); //Abrir conexion
                        _Cmd = new SqlCommand();
                        _Cmd.Connection = _Con; //Asociar el CMD a la Conexion
                        _Cmd.CommandType = CommandType.StoredProcedure;
                        _Cmd.CommandText = XmlDatos.DocumentElement.GetAttribute("Nombre");

                        //Setear Parametros
                        setParametros(XmlDatos);
                        SqlDataAdapter DA = new SqlDataAdapter();
                        DA.SelectCommand = _Cmd;
                        _Ds = new DataSet();
                        DA.Fill(_Ds); //Ejecutamos Procedimiento
                        _Cmd.Dispose();
                        _Con.Close();
                    }
                    catch (Exception ex)
                    {
                        _Error = true;
                        _MsgError = ex.Message;

                        classCorreo _correo = new classCorreo();
                        _correo.Enviar_Correo(ex.Message.ToString());
                    }
                    finally
                    {
                        if (_Con != null && _Con.State == ConnectionState.Open)
                            _Con.Close();
                    }

                    return _Ds; //Retornar el Dataset con los Datos
                }
            #endregion

            #region"Executa Store Procedure y devuelve XML"
                public XmlDocument ExecSP_XML(XmlDocument xmlDatos)
                {
                    try
                    {
                        _xmlRetorno = null;
                        _Error = false;
                        _MsgError = "";
                        _Con.Open(); //Abrir la conexion
                        _Cmd = new SqlCommand();
                        _Cmd.CommandType = CommandType.StoredProcedure;
                        _Cmd.CommandText = xmlDatos.DocumentElement.GetAttribute("Nombre");
                        _Cmd.Connection = _Con;
                        //Setear los parametro
                        setParametros(xmlDatos);
                        _Dr = _Cmd.ExecuteReader();
                        //Generar el Xml de Salida
                        GeneraXmlSalida();
                        _Dr.Close();
                        _Cmd.Dispose();
                        _Con.Close(); //Cerrar la conexion
                    }
                    catch (Exception ex)
                    {
                        _Error = true;
                        _MsgError = ex.Message;
                    }
                    finally
                    {
                        if (_Con != null && _Con.State == ConnectionState.Open)
                            _Con.Close();
                    }
                    return _xmlRetorno;//Retorna el XmlDoc con los datos
                }
            #endregion
    
        #endregion
    }
}
