using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using com21DLL;
using System.Xml.Linq;
using NPOI.HSSF.UserModel;


public partial class administrador_rproductos : System.Web.UI.Page
{
    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    classCom21Reportes _reportes = new classCom21Reportes();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarRProductos();
            cargarCategorias();
            cargarMarcas();
        }
    }
    private void cargarRProductos()
    {
        DataSet _cat = _consulta.Com21_consulta_ResportesInicial();
        if (_cat.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _cat.Tables[0];
            GvRProductos.DataBind();
            cuerpo_rptV.Visible = false;
        }
        else
        {
            cuerpo_rpt.Visible = true;
            GvRProductos.EmptyDataText = "NO EXISTEN PRODUCTOS";
        }
    }
    private void cargarCategorias()
    {
        DataSet _cat = _consulta.Com21_consulta_categoria();
        if (_cat.Tables[1].Rows.Count > 0)
        {
            ddlCategorias.DataSource = _cat.Tables[1];
            ddlCategorias.DataTextField = "Categoria";
            ddlCategorias.DataValueField = "Id_Categoria";
            ddlCategorias.DataBind();
        }
    }
    private void cargarMarcas()
    {
        DataSet _pre = _consulta.Com21_consulta_marca();
        if (_pre.Tables[1].Rows.Count > 0)
        {
            ddlMarca.DataSource = _pre.Tables[1];
            ddlMarca.DataTextField = "Marca";
            ddlMarca.DataValueField = "Id_Marca";
            ddlMarca.DataBind();
        }
    }
    protected void IBCantidad_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "1";
        cargarIBCantidad();
    }
    private void cargarIBCantidad()
    {
        int _ddl = int.Parse(ddlCantidad.SelectedValue.ToString());
        DataSet _cant = _consulta.Com21_consulta_Resportes(1, _ddl, "0", "0");
        if (_cant.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _cant.Tables[0];
            GvRProductos.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exiten registro para el rango de cantidad: " + ddlCantidad.SelectedItem + "" + "');", true);
        }
    }
    protected void IBCategoria_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "2";
        cargarIBCategoria();
    }
    private void cargarIBCategoria()
    {
        int _ddl = int.Parse(ddlCategorias.SelectedValue.ToString());
        DataSet _cant = _consulta.Com21_consulta_Resportes(2, _ddl, "0", "0");
        if (_cant.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _cant.Tables[0];
            GvRProductos.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exiten registro para la categoria: " + ddlCategorias.SelectedItem+"" + "');", true);
        }
    }
    protected void IBPrecio_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "3";
        cargarIBPrecio();
    }
    private void cargarIBPrecio()
    {
        String _inicio = "";
        String _fin = "";
        int _ddl = int.Parse(ddlPrecio.SelectedValue.ToString());
        if (ddlPrecio.SelectedValue == "0")
        {
            _inicio = "0";
            _fin = "500.00";
        }
        if (ddlPrecio.SelectedValue == "1")
        {
            _inicio = "500.01";
            _fin = "800.00";
        }
        if (ddlPrecio.SelectedValue == "2")
        {
            _inicio = "800.01";
            _fin = "1000.00";
        }
        if (ddlPrecio.SelectedValue == "3")
        {
            _inicio = "1000.01";
            _fin = "1500.00";
        }
        if (ddlPrecio.SelectedValue == "4")
        {
            _inicio = "1500.01";
            _fin = "1500.01";
        }
        DataSet _cant = _consulta.Com21_consulta_Resportes(3, _ddl, _inicio, _fin);
        if (_cant.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _cant.Tables[0];
            GvRProductos.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exiten registro para el rango de precios: " + ddlPrecio.SelectedItem + "" + "');", true);
        }
    }
    protected void IBMarcas_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "4";
        cargarIBMarcas();
    }
    private void cargarIBMarcas()
    {
        int _ddl = int.Parse(ddlMarca.SelectedValue.ToString());
        DataSet _cant = _consulta.Com21_consulta_Resportes(4, _ddl, "0", "0");
        if (_cant.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _cant.Tables[0];
            GvRProductos.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exiten registro para la marca: " + ddlMarca.SelectedItem + "" + "');", true);
        }
    }
    #region "Eventos del GridView"
    protected void GvRProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvRProductos.PageIndex = e.NewPageIndex;
        try
        {
            if (idBuscar.Value == "0")
            {
                cargarRProductos();
            }
            if (idBuscar.Value == "1")
            {
                cargarIBCantidad();
            }
            if (idBuscar.Value == "2")
            {
                cargarIBCategoria();
            }
            if (idBuscar.Value == "3")
            {
                cargarIBPrecio();
            }
            if (idBuscar.Value == "4")
            {
                cargarIBMarcas();
            }
        }
        catch { }
    }
    #endregion
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "0";
        cargarRProductos();
    }
    protected void imgImprimir_Click(object sender, ImageClickEventArgs e)
    {
        if (idBuscar.Value == "0")
        {
            Response.Redirect("ripro.aspx?Ident=" + idBuscar.Value);
        }
        if (idBuscar.Value == "1")
        {
            Response.Redirect("ripro.aspx?Ident=" + idBuscar.Value + "&Cant=" + ddlCantidad.SelectedValue.ToString());
        }
        if (idBuscar.Value == "2")
        {
            Response.Redirect("ripro.aspx?Ident=" + idBuscar.Value + "&Cat=" + ddlCategorias.SelectedValue.ToString());
        }
        if (idBuscar.Value == "3")
        {
            Response.Redirect("ripro.aspx?Ident=" + idBuscar.Value + "&Pre=" + ddlPrecio.SelectedValue.ToString());
        }
        if (idBuscar.Value == "4")
        {
            Response.Redirect("ripro.aspx?Ident=" + idBuscar.Value + "&Mar=" + ddlMarca.SelectedValue.ToString());
        }
    }
    protected void imgxlsprint_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataSet _report = ObtenerData();
            //DataTable _nueva = _reportes.GenerarDataTableNueva(_report, int.Parse(idBuscar.Value));
            DataTable _nueva = GenerarDataTableNuevas(_report, int.Parse(idBuscar.Value));
            String nombre = ObtenerNombre();
            //_reportes.ExportarExcel(_nueva, nombre, "administrador", "reportes");
            ExportarExcels(_nueva, nombre, "administrador", "reportes");
            nombre = nombre + ".xls";
            //_reportes.DescargarArchivos("reportes", nombre, true);
            //decargarArchivo(nombre);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('" + ex.Message + "');", true);
        }
    }
    private DataSet ObtenerData()
    {
        DataSet _data = new DataSet();
        if (idBuscar.Value == "0")
        {
            _data = _consulta.Com21_consulta_ResportesInicial();
        }
        if (idBuscar.Value == "1")
        {
            int _ddl = int.Parse(ddlCantidad.SelectedValue.ToString());
            _data = _consulta.Com21_consulta_Resportes(1, _ddl, "0", "0");
        }
        if (idBuscar.Value == "2")
        {
            int _ddl = int.Parse(ddlCategorias.SelectedValue.ToString());
            _data = _consulta.Com21_consulta_Resportes(2, _ddl, "0", "0");
        }
        if (idBuscar.Value == "3")
        {
            String _inicio = "";
            String _fin = "";
            int _ddl = int.Parse(ddlPrecio.SelectedValue.ToString());
            if (ddlPrecio.SelectedValue == "0")
            {
                _inicio = "0";
                _fin = "500.00";
            }
            if (ddlPrecio.SelectedValue == "1")
            {
                _inicio = "500.01";
                _fin = "800.00";
            }
            if (ddlPrecio.SelectedValue == "2")
            {
                _inicio = "800.01";
                _fin = "1000.00";
            }
            if (ddlPrecio.SelectedValue == "3")
            {
                _inicio = "1000.01";
                _fin = "1500.00";
            }
            if (ddlPrecio.SelectedValue == "4")
            {
                _inicio = "1500.01";
                _fin = "1500.01";
            }
            _data  = _consulta.Com21_consulta_Resportes(3, _ddl, _inicio, _fin);
        }
        if (idBuscar.Value == "4")
        {
            int _ddl = int.Parse(ddlMarca.SelectedValue.ToString());
            _data = _consulta.Com21_consulta_Resportes(4, _ddl, "0", "0");
        }
        return _data;
    }
    private string ObtenerNombre()
    {
        String nombre = "";
        if (idBuscar.Value == "0")
        {
            nombre = "ReporteProductosGeneral";
            hfNombreReporte.Value = nombre;
        }
        if (idBuscar.Value == "1")
        {
            nombre = "ReporteProductosCantidades";
            hfNombreReporte.Value = nombre;
        }
        if (idBuscar.Value == "2")
        {
            nombre = "ReporteProductosCategorias";
            hfNombreReporte.Value = nombre;
        }
        if (idBuscar.Value == "3")
        {
            nombre = "ReporteProductosPrecios";
            hfNombreReporte.Value = nombre;
        }
        if (idBuscar.Value == "4")
        {
            nombre = "ReporteProductosMarcas";
            hfNombreReporte.Value = nombre;
        }

        return nombre;
    }
    private void decargarArchivo(String nombre)
    {
        //try
        //{
        //    string filename = nombre;
        //    if (!String.IsNullOrEmpty(filename))
        //    {

        //        //String path = Server.MapPath(dlDir + filename);
        //        String path = Server.MapPath("~/administrador/reportes/" + filename);
        //        String dlDir = path;
        //        System.IO.FileInfo toDownload = new System.IO.FileInfo(path);

        //        if (toDownload.Exists)
        //        {
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = "application/xls";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
        //            Response.AddHeader("Content-Length", toDownload.Length.ToString());
        //            //Response.ContentType = "UTF-8";
        //            Response.WriteFile(dlDir);
        //            Response.End();
        //            //Response.ClearContent();
        //            //Response.AddHeader("content-disposition", "attachment; filename=" + toDownload.Name);
        //            //Response.ContentType = "application/excel";
        //            //StringWriter sw = new StringWriter();
        //            //HtmlTextWriter htw = new HtmlTextWriter(sw);

        //            //Response.Write(sw.ToString());
        //            //Response.End();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{

        //}


            // Ruta y nombre del archivo
            //string path = Path.Combine(Path.GetTempPath()) + NombreArchivo;
            //string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\DatosExportados\\" + NombreArchivo;
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\administrador\\reportes\\" + nombre;
            // Obtiene el nombre del archivo
            string nombres = Path.GetFileName(path);
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
            //if (forzarDescarga)
            //{
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombres);
            //}
            if (type != "")
            {
                System.Web.HttpContext.Current.Response.ContentType = type;
                System.Web.HttpContext.Current.Response.TransmitFile(path);
                System.Web.HttpContext.Current.Response.End();
            }
    }
    protected void lblexcel_Click(object sender, EventArgs e)
    {
        DataSet _report = ObtenerData();
        DataTable _nueva = _reportes.GenerarDataTableNueva(_report, int.Parse(idBuscar.Value));
        String nombre = ObtenerNombre();
        _reportes.ExportarExcel(_nueva, nombre, "administrador", "reportes");
        nombre = nombre + ".xls";
        //_reportes.DescargarArchivos("reportes", nombre, true);
        decargarArchivo(nombre);
    }
    private void ExportarExcels(DataTable Tabla, string nombreArchivoXLS, string nombreCarpeta, string nombreSubCarpeta)
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
        hfruta.Value = ruta;
        lblruta.Text = ruta;

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
    private DataTable GenerarDataTableNuevas(DataSet Data, int Ident)
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
}