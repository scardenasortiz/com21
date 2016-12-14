using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;

namespace com21DLL
{
    public class classAlbum
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
       
        public DataSet consulta_album()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_album");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        

        public DataSet consulta_lista()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_lista");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet consulta_lista_dos(string Genero, int Crud, int IdGenero)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_lista_dos");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Genero");
            elemPrm.SetAttribute("TipoDato", "nvarchar");
            elemPrm.SetAttribute("Longitud", "25");
            elemPrm.SetAttribute("Valor", Genero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Crud");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Crud.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdGenero");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdGenero.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet contar_informacion()
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_contar_informacion");
            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

        public DataSet consulta_album_id(int IdAlbum)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_album_id");

            //Crea el parametro @Codigo nchar(5)
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@IdAlbum");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", IdAlbum.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }

       public bool proc_ingresa_album(string strXmlDatos)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Ingresar(xmlDatos, "musicalisimobd..sp_ingresa_album", "Album"));

        }

       public bool proc_edita_album(string strXmlDatos, int IdAlbum)
        {
            XmlDocument xmlDatos = new XmlDocument();
            xmlDatos.LoadXml(strXmlDatos);
            return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdAlbum, "musicalisimobd..sp_edita_album", "Album", "@IdAlbum"));
        }

       public bool proc_elimina_album(int IdAlbum)
        {
            return Verifica_Error(_objRetorno.Proc_Eliminacion(IdAlbum, "musicalisimobd..sp_elimina_album", "Album", "@IdAlbum"));

        }

       public DataSet consulta_album_prioridad(int Prioridad)
       {
           XmlDocument _xmlDatos = new XmlDocument();
           _xmlDatos.LoadXml("<Procedimiento />");
           _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_album_prioridad");

           //Crea el parametro @Codigo nchar(5)
           elemPrm = _xmlDatos.CreateElement("Parametro");
           elemPrm.SetAttribute("Nombre", "@Prioridad");
           elemPrm.SetAttribute("TipoDato", "Int");
           elemPrm.SetAttribute("Longitud", "4");
           elemPrm.SetAttribute("Valor", Prioridad.ToString());
           elemPrm.SetAttribute("Direccion", "Input");
           _xmlDatos.DocumentElement.AppendChild(elemPrm);

           //Ejecutar el Procedimiento
           DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
           return _solicitud;
       }

       public bool proc_edita_album_prioridad(string strXmlDatos, int IdAlbum)
       {
           XmlDocument xmlDatos = new XmlDocument();
           xmlDatos.LoadXml(strXmlDatos);
           return Verifica_Error(_objRetorno.Proc_Actualizar(xmlDatos, IdAlbum, "musicalisimobd..sp_edita_album_prioridad", "Album", "@IdAlbum"));
       }

       public DataSet consulta_filtro(string argumento)
       {
           XmlDocument _xmlDatos = new XmlDocument();
           _xmlDatos.LoadXml("<Procedimiento />");
           _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_filtro");

           //Crea el parametro @Codigo nchar(5)
           elemPrm = _xmlDatos.CreateElement("Parametro");
           elemPrm.SetAttribute("Nombre", "@argumento");
           elemPrm.SetAttribute("TipoDato", "nvarchar");
           elemPrm.SetAttribute("Longitud", "50");
           elemPrm.SetAttribute("Valor", argumento.ToString());
           elemPrm.SetAttribute("Direccion", "Input");
           _xmlDatos.DocumentElement.AppendChild(elemPrm);

           //Ejecutar el Procedimiento
           DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
           return _solicitud;
       }
       public DataSet consulta_filtro_dos(string argumento)
       {
           XmlDocument _xmlDatos = new XmlDocument();
           _xmlDatos.LoadXml("<Procedimiento />");
           _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_lista_dos");

           //Crea el parametro @Codigo nchar(5)
           elemPrm = _xmlDatos.CreateElement("Parametro");
           elemPrm.SetAttribute("Nombre", "@argumento");
           elemPrm.SetAttribute("TipoDato", "nvarchar");
           elemPrm.SetAttribute("Longitud", "25");
           elemPrm.SetAttribute("Valor", argumento.ToString());
           elemPrm.SetAttribute("Direccion", "Input");
           _xmlDatos.DocumentElement.AppendChild(elemPrm);

           //Ejecutar el Procedimiento
           DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
           return _solicitud;
       }
       public DataSet consulta_galeria_album(int IdProducto)
       {
           XmlDocument _xmlDatos = new XmlDocument();
           _xmlDatos.LoadXml("<Procedimiento />");
           _xmlDatos.DocumentElement.SetAttribute("Nombre", "musicalisimobd..sp_consulta_galeria_album");

           //Crea el parametro @Codigo nchar(5)
           elemPrm = _xmlDatos.CreateElement("Parametro");
           elemPrm.SetAttribute("Nombre", "@IdProducto");
           elemPrm.SetAttribute("TipoDato", "Int");
           elemPrm.SetAttribute("Longitud", "4");
           elemPrm.SetAttribute("Valor", IdProducto.ToString());
           elemPrm.SetAttribute("Direccion", "Input");
           _xmlDatos.DocumentElement.AppendChild(elemPrm);

           //Ejecutar el Procedimiento
           DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
           return _solicitud;
       }
        #endregion

    }
}
