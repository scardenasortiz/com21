using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
//using NPOI.HSSF.UserModel;
using System.IO;

namespace com21DLL
{
    public class classCom21Exportar
    {
        #region"Metodos Publicos"
        public void ExportarXML(DataTable dt, string nombreArchivoXML, string nombreCarpeta, string nombreSubCarpeta)
        {
            //Declaramos el documento y su definición
            XDocument document = new XDocument(
                new XDeclaration("1.0", "iso-8859-1", null));

            //Creamos el nodo raiz y lo añadimos al documento
            XElement nodoRegistros = new XElement("REGISTROS");
            document.Add(nodoRegistros);

            //Recorremos el datatable
            foreach (DataRow row in dt.Rows)
            {
                XElement nodoRegistro = new XElement("REGISTRO");
                foreach (DataColumn column in dt.Columns)
                {
                    XElement nodo = new XElement(column.ColumnName.ToLower());
                    nodo.Add(row[column]);
                    nodoRegistro.Add(nodo);
                }
                nodoRegistros.Add(nodoRegistro);
            }

            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\" + nombreSubCarpeta + "\\";
            string archivo = ruta + nombreArchivoXML + ".xml";

            try
            {
                // Determina si existe el directorio
                if (!Directory.Exists(ruta))
                {
                    //Crea el directorio si no existe
                    Directory.CreateDirectory(ruta);

                    // Guarda el xml en la ruta especificada
                    document.Save(archivo);
                }
                else
                {
                    // Guarda el xml en la ruta especificada
                    document.Save(archivo);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.ToString());
            }
        }

        public void ExportarExcel(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta)
        {
            //Creamos el libro de Excel
            var workbook = new HSSFWorkbook();

            //Creamos una nueva hoja de Excel
            var sheet = workbook.CreateSheet("Datos_Exportados");

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
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";

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

        public void ExportarExcel_PromedioMateria(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string materia, string institucion, string direccion, string telefono)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            var rowInstitucion = sheet.GetRow((short)1);
            rowInstitucion.GetCell((short)0).SetCellValue(institucion.ToUpper());

            var rowDireccion = sheet.GetRow((short)2);
            rowDireccion.GetCell((short)0).SetCellValue(direccion);

            var rowFono = sheet.GetRow((short)3);
            rowFono.GetCell((short)0).SetCellValue(telefono);

            var rowMateria = sheet.CreateRow((short)7);
            rowMateria.CreateCell((short)0).SetCellValue("MATERIA: " + materia);

            // Obtenemos los valores de la consulta
            int rowIndex = 12;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);
                    var cell = dataRow.GetCell(column.Ordinal);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }

        public void ExportarExcel_PromedioProfesor(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string materia, string profesor, string institucion, string direccion, string telefono)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            var rowInstitucion = sheet.GetRow((short)1);
            rowInstitucion.GetCell((short)0).SetCellValue(institucion.ToUpper());

            var rowDireccion = sheet.GetRow((short)2);
            rowDireccion.GetCell((short)0).SetCellValue(direccion);

            var rowFono = sheet.GetRow((short)3);
            rowFono.GetCell((short)0).SetCellValue(telefono);

            var rowMateria = sheet.CreateRow((short)7);
            rowMateria.CreateCell((short)0).SetCellValue("MATERIA: " + materia);
            var rowProfesor = sheet.CreateRow((short)8);
            rowProfesor.CreateCell((short)0).SetCellValue("PROFESOR: " + profesor);

            // Obtenemos los valores de la consulta
            int rowIndex = 13;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);
                    var cell = dataRow.GetCell(column.Ordinal);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }

        public void ExportarExcel_LeccionesMateria(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string materia, string aniolectivo)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            var rowAnioLectivo = sheet.GetRow((short)4);
            rowAnioLectivo.GetCell((short)0).SetCellValue(aniolectivo);

            var rowMateria = sheet.CreateRow((short)7);
            rowMateria.CreateCell((short)1).SetCellValue("MATERIA: " + materia);

            // Obtenemos los valores de la consulta
            int rowIndex = 12;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal + 1);
                    var cell = dataRow.GetCell(column.Ordinal + 1);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }

        public void ExportarExcel_Lecciones(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string materia, string variable, string inscritos, string unidades, string institucion, string direccion, string telefono, string aniolectivo)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            if (nombreArchivoXLS == "leccion_x_institucion.xls")
            {
                var rowInstitucion = sheet.GetRow((short)1);
                rowInstitucion.GetCell((short)0).SetCellValue(institucion.ToUpper());

                var rowDireccion = sheet.GetRow((short)2);
                rowDireccion.GetCell((short)0).SetCellValue(direccion);

                var rowFono = sheet.GetRow((short)3);
                rowFono.GetCell((short)0).SetCellValue(telefono);
            }

            var rowAnioLectivo = sheet.GetRow((short)4);
            rowAnioLectivo.GetCell((short)0).SetCellValue(aniolectivo);

            var rowPais = sheet.CreateRow((short)7);
            rowPais.CreateCell((short)1).SetCellValue(variable);

            var rowMateria = sheet.CreateRow((short)8);
            rowMateria.CreateCell((short)1).SetCellValue("MATERIA: " + materia);

            var rowInscritos = sheet.CreateRow((short)9);
            rowInscritos.CreateCell((short)1).SetCellValue("INSCRITOS: " + inscritos);

            var rowUnidades = sheet.CreateRow((short)10);
            rowUnidades.CreateCell((short)1).SetCellValue("UNIDADES: " + unidades);

            // Obtenemos los valores de la consulta
            int rowIndex = 15;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal + 1);
                    var cell = dataRow.GetCell(column.Ordinal + 1);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }

        public void ExportarExcel_Lecciones_CursoGeneral(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string grado, string institucion, string direccion, string telefono, string aniolectivo)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            var rowInstitucion = sheet.GetRow((short)1);
            rowInstitucion.GetCell((short)0).SetCellValue(institucion.ToUpper());

            var rowDireccion = sheet.GetRow((short)2);
            rowDireccion.GetCell((short)0).SetCellValue(direccion);

            var rowFono = sheet.GetRow((short)3);
            rowFono.GetCell((short)0).SetCellValue(telefono);

            var rowAnioLectivo = sheet.GetRow((short)4);
            rowAnioLectivo.GetCell((short)0).SetCellValue(aniolectivo);

            var rowGrado = sheet.CreateRow((short)7);
            rowGrado.CreateCell((short)1).SetCellValue("GRADO: " + grado);

            // Obtenemos los valores de la consulta
            int rowIndex = 12;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal + 1);
                    var cell = dataRow.GetCell(column.Ordinal + 1);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }

        public void ExportarExcel_CalificacionesPaisGeneral(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string pais, string materia, string grado, string año)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Formato\\" + nombreArchivoXLS, FileMode.Open, FileAccess.Read);

            var templateWorkbook = new HSSFWorkbook(fs, true);
            var sheet = templateWorkbook.GetSheet("Datos_Exportados");

            var rowPais = sheet.CreateRow((short)7);
            rowPais.CreateCell((short)1).SetCellValue("PAIS: " + pais);

            var rowMateria = sheet.CreateRow((short)8);
            rowMateria.CreateCell((short)1).SetCellValue("MATERIA: " + materia);

            var rowInscritos = sheet.CreateRow((short)9);
            rowInscritos.CreateCell((short)1).SetCellValue("GRADO: " + grado);

            var rowUnidades = sheet.CreateRow((short)10);
            rowUnidades.CreateCell((short)1).SetCellValue("AÑO: " + año);

            // Obtenemos los valores de la consulta
            int rowIndex = 15;

            foreach (DataRow row in Tabla.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in Tabla.Columns)
                {
                    var newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal + 1);
                    var cell = dataRow.GetCell(column.Ordinal + 1);
                    cell.CellStyle = templateWorkbook.CreateCellStyle();
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull":
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                    cell.CellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cell.CellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                }

                rowIndex++;
            }

            fs.Close();
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + nombreCarpeta + "\\";
            FileStream file = File.Create(ruta + nombreArchivoXLS);
            byte[] datafile = ms.GetBuffer();
            file.Write(datafile, 0, datafile.Length);
            file.Close();
        }
        #endregion
    }
}
