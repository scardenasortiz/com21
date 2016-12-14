using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;
using System.Xml;
using System.Data;
using System.IO;
using System.Web;
using System.Xml.Linq;
using NPOI.HSSF.UserModel;


namespace com21DLL
{
    public class classCom21Reportes
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
        public DataSet Com21_consulta_ResportesInicial()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ReportesInicial");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_Resportes(int Ident, int Ddl, string Inicio, string Fin)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_Reportes");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ident");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ident.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Ddl");
            elemPrm.SetAttribute("TipoDato", "Int");
            elemPrm.SetAttribute("Longitud", "4");
            elemPrm.SetAttribute("Valor", Ddl.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);
            
            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Inicio");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Inicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@Fin");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", Fin.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_ResportesInicialTrans()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ReportesInicialTrans");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        public DataSet Com21_consulta_ResportesFechaTrans(string FecInicio, string FecFin, int Ident)
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ReportesTrans");

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@FecInicio");
            elemPrm.SetAttribute("TipoDato", "NVarcha");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", FecInicio.ToString());
            elemPrm.SetAttribute("Direccion", "Input");
            _xmlDatos.DocumentElement.AppendChild(elemPrm);

            elemPrm = _xmlDatos.CreateElement("Parametro");
            elemPrm.SetAttribute("Nombre", "@FecFin");
            elemPrm.SetAttribute("TipoDato", "NVarchar");
            elemPrm.SetAttribute("Longitud", "200");
            elemPrm.SetAttribute("Valor", FecFin.ToString());
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
        public DataSet Com21_consulta_ResportesTransaccion()
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Procedimiento />");
            _xmlDatos.DocumentElement.SetAttribute("Nombre", "com21sa20102013_2015..sp_c_Consulta_ReportesTransaccion");

            //Ejecutar el Procedimiento
            DataSet _solicitud = _objBaseDatos.ExecSP(_xmlDatos);
            return _solicitud;
        }
        #region "PARA GENERAR EN XLS"
        public void ExportarExcel(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string nombreSubCarpeta)
        {
            //Creamos el libro de Excel
            var workbook = new HSSFWorkbook();

            //Creamos una nueva hoja de Excel
            var sheet = workbook.CreateSheet(nombreArchivoXLS);

            // Creamos una cabezera para la fila
            var headerRow = sheet.CreateRow(0);

            // Establecemos los nombres de las columnas
            foreach (DataColumn column in Tabla.Columns)
            {
                if (column.ColumnName != "")
                {
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
            }
            // Obtenemos los valores de la consulta
            int rowIndex = 1;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }

            // Establecemos la condicion autosize a las columnas
            int columIndex = Tabla.Columns.Count;
            for (int a = 0; a < columIndex; a++)
            {
                sheet.AutoSizeColumn(a);
                //var font = workbook.CreateFont();
                //font.Boldweight();
            }

            // Escribimos el libro en una secuencia de memoria
            MemoryStream output_file = new MemoryStream();
            workbook.Write(output_file);
            output_file.Close();

            //int contador = 1;
            string file = null;
            file = nombreArchivoXLS + ".xls";

            //Establecemos la ruta donde se alojará el documento exportado
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\" + nombreSubCarpeta + "\\";
            //string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Notas\\" + nombreCarpeta + "\\";
            //string ruta = Path.Combine(Path.GetTempPath()) + nombreCarpeta + "\\";

            try
            {
                // Determina si existe el directorio
                if (!Directory.Exists(ruta))
                {
                    //Crea el directorio si no existe
                    Directory.CreateDirectory(ruta);

                    // Guarda y cierra el libro
                    FileStream fs = File.Create(ruta + file);
                    byte[] datafile = output_file.GetBuffer();
                    fs.Write(datafile, 0, datafile.Length);
                    fs.Close();
                }
                else
                {
                    // Guarda y cierra el libro
                    FileStream fs = File.Create(ruta + file);
                    byte[] datafile = output_file.GetBuffer();
                    fs.Write(datafile, 0, datafile.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //  System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public DataTable GenerarDataTableNueva(DataSet Data, int Ident)
        {
            DataTable datos = new DataTable();
            foreach (DataColumn _dtc in Data.Tables[0].Columns)
            {
                if ((_dtc.ToString() != "Id_Producto") && (_dtc.ToString() != "Id_Categoria") && (_dtc.ToString() != "Id_SubCategoria") && (_dtc.ToString() != "Ruta") && (_dtc.ToString() != "Activar") && (_dtc.ToString() != "Estado") && (_dtc.ToString() != "Id_Marca") && (_dtc.ToString() != "UrlProducto") && (_dtc.ToString() != "ActIva"))
                {
                    datos.Columns.Add(_dtc.ToString());
                }
            }
            datos.Columns.Add("Iva");
            foreach (DataRow _dtr in Data.Tables[0].Rows)
            {
                DataRow _datos = datos.NewRow();
                _datos[0] = _dtr[1].ToString();
                _datos[1] = _dtr[2].ToString();
                _datos[2] = _dtr[3].ToString();
                _datos[3] = _dtr[4].ToString();
                _datos[4] = _dtr[9].ToString();
                _datos[5] = _dtr[10].ToString();
                _datos[6] = _dtr[13].ToString();
                _datos[7] = _dtr[15].ToString();
                _datos[8] = _dtr[16].ToString();
                _datos[9] = _dtr[18].ToString();
                _datos[10] = _dtr[19].ToString();
                _datos[11] = _dtr[20].ToString();
                if (_dtr[14].ToString() == "1")
                {
                    _datos[12] = "12%";
                }
                else
                {
                    _datos[12] = "0%";
                }
                //_datos[13] = _dtr[20].ToString();

                datos.Rows.Add(_datos);
            }
            return datos;
        }
        public void DescargarArchivos(string NombreCarpeta, string NombreArchivo, bool forzarDescarga)
        {
            // Ruta y nombre del archivo
            //string path = Path.Combine(Path.GetTempPath()) + NombreArchivo;
            //string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\DatosExportados\\" + NombreArchivo;
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\administrador\\" + NombreCarpeta + "\\" + NombreArchivo;
            // Obtiene el nombre del archivo
            string nombre = Path.GetFileName(path);
            // Obtiene la extension del archivo
            string extension = Path.GetExtension(path);
            string type = "";

            // Verifica el tipo de extension
            if (extension != null)
            {
                switch (extension.ToLower())
                {
                    case ".htm":
                    case ".html":
                        type = "text/HTML";
                        break;

                    case ".txt":
                        type = "text/plain";
                        break;

                    case ".doc":
                    case ".rtf":
                    case ".docx":
                        type = "Application/msword";
                        break;

                    case ".xls":
                    case ".xlsx":
                        type = "Application/x-msexcel";
                        break;

                    case ".jpg":
                    case ".jpeg":
                        type = "image/jpeg";
                        break;

                    case ".gif":
                        type = "image/GIF";
                        break;

                    case ".pdf":
                        type = "application/pdf";
                        break;

                    case ".zip":
                        type = "application/octet-stream";
                        break;
                }
            }
            if (forzarDescarga)
            {
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre);
            }
            if (type != "")
            {
                System.Web.HttpContext.Current.Response.ContentType = type;
                System.Web.HttpContext.Current.Response.TransmitFile(path);
                System.Web.HttpContext.Current.Response.End();
            }
        }
        #endregion
        #endregion
    }
}
