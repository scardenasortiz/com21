using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_imagenes : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                cargarimagenes();
                //cargarproductos();
            }
        }
    }
    private void cargarimagenes()
    {
        String id = Request.QueryString["ID"].ToString();
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        //DataSet _provincias = _consulta.Com21_consulta_imagenes();
        DataSet _provincias = _consulta.Com21_consulta_imagenes_id_producto(int.Parse(id));
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            imgsi.Visible = true;
            imgno.Visible = false;

            GvImagenes.DataSource = _provincias.Tables[0];
            GvImagenes.DataBind();
        }
        else
        {
            imgsi.Visible = false;
            imgno.Visible = true;
        }
        if(_provincias.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow dr in _provincias.Tables[1].Rows)
            {
                //seteo todos los valores de la consulta especifica
                IdProducto.Value = dr["Id_Producto"].ToString();
                lblproducto.Text = dr["Titulo"].ToString();
            }
        }
    }
    //private void cargarproductos()
    //{
    //    ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
    //    DataSet _pro = _administrador.Com21_consulta_productos();
    //    if (_pro.Tables[2].Rows.Count > 0)
    //    {
    //        prodsi.Visible = true;
    //        prodno.Visible = false;
    //        GvProducto.DataSource = _pro.Tables[2];
    //        GvProducto.DataBind();
    //    }
    //    else
    //    {
    //        prodno.Visible = true;
    //        prodsi.Visible = false;
    //    }
    //}
    protected void GvImagenes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvImagenes.PageIndex = e.NewPageIndex;
        try
        {
            cargarimagenes();
        }
        catch { }
    }
    protected void GvImagenes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvImagenes.SelectedRow;
            string Id_Imagenes = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Imagenes");
            Id_Imagenes = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_imagenes_id(int.Parse(Id_Imagenes));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.IdImagenes.Value = dr[0].ToString();
                    this.img.ImageUrl = dr[4].ToString();
                    this.img0.ImageUrl = dr[1].ToString();
                    this.img1.ImageUrl = dr[2].ToString();
                    this.img2.ImageUrl = dr[3].ToString();
                    if (Convert.ToBoolean(dr[6].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
                    IdProducto.Value = dr[7].ToString();
                    lblproducto.Text = dr[8].ToString();
                }
                btnedit.Visible = true;
                btninsert.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvImagenes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Id_Imagenes = GvImagenes.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_imagenes(int.Parse(Id_Imagenes)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
            }
            cargarimagenes();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
            ingresoimagenes();
    }
    
    private void ingresoimagenes()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Imagenes/>");
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img0.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ruta1", img1.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ruta2", img2.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Rutas3", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Id_Producto", IdProducto.Value);
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
                ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (IdProducto.Value != "")
                {
                    if (_administrador.Com21_ingresa_imagenes(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
                    Limpiar();
                    cargarimagenes();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccione un producto por favor');", true);
                }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void Limpiar()
    {
        img.ImageUrl = "~/images/imagenes/icons_variados_theme_negro/64_image.png";
        img0.ImageUrl = "~/images/imagenes/icons_variados_theme_negro/64_image.png";
        img1.ImageUrl = "~/images/imagenes/icons_variados_theme_negro/64_image.png";
        img2.ImageUrl = "~/images/imagenes/icons_variados_theme_negro/64_image.png";
        cbactivar.Checked = false;
        lblproducto.Text = "";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        //int pro = validadatos();
        //if (pro == 1)
        //{
            editimagenes();
       // }
    }
    private void editimagenes()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Imagenes/>");
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img0.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ruta1", img1.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ruta2", img2.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Rutas3", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Id_Producto", IdProducto.Value);
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlResultado = new XmlDocument();
            //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
            if (_administrador.Com21_edita_imagenes(_xmlDatos.OuterXml, int.Parse(IdImagenes.Value)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                btninsert.Visible = true;
                btnedit.Visible = false;
            }
            Limpiar();
            cargarimagenes();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    //protected void GvProducto_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //Session["envioslide"] = "editar";
    //        GridViewRow row = GvProducto.SelectedRow;
    //        string Id_Producto = "";
    //        HiddenField cod = default(HiddenField);
    //        Label _titulo = default(Label);
    //        cod = (HiddenField)row.FindControl("Id_Producto");
    //        _titulo = (Label)row.FindControl("Titulo");
    //        Id_Producto = cod.Value;
    //        IdProducto.Value = Id_Producto;
    //        lblproducto.Text = _titulo.Text;
    //    }
    //    catch (Exception Ex)
    //    {
    //        Console.WriteLine(Ex.Message);
    //        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
    //    }
    //}
    protected void lbvisualizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;
                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                    img.ImageUrl = "~/upload/productos/" + savePath;
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    protected void lbvisualizar1_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen0.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen0.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;
                    fuimagen0.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                    img0.ImageUrl = "~/upload/productos/" + savePath;
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    protected void lbvisualiza2_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen1.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen1.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;
                    fuimagen1.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                    img1.ImageUrl = "~/upload/productos/" + savePath;
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    protected void lbvisualizar3_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen2.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen2.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;
                    fuimagen2.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                    img2.ImageUrl = "~/upload/productos/" + savePath;
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtbuscarproducto.Text.Length > 0)
    //    {
    //        string letra = txtbuscarproducto.Text;
    //        hfletra.Value = letra;
    //        consultaletra(letra);
    //    }
    //    else
    //    {
    //        //cargarimagenes();
    //        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor digite para realizar la busqueda');", true);
    //    }
    //}
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarimagenes.Text.Length > 0)
        {
            string letra = txtbuscarimagenes.Text;
            hfletras.Value = letra;
            consultaletras(letra);
        }
        else
        {
            //cargarimagenes();
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor digite para realizar la busqueda');", true);
        }
    }
    //protected void refresh_Click(object sender, ImageClickEventArgs e)
    //{
    //    hfletra.Value = "";
    //    txtbuscarproducto.Text = "";
    //    cargarproductos();
    //}
    protected void refreshs_Click(object sender, ImageClickEventArgs e)
    {
        hfletras.Value = "";
        txtbuscarimagenes.Text = "";
        cargarimagenes();
    }
    #region "BUSCAR POR LETRA"
    //private void consultaletra(string letra)
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    DataSet _letras = _consulta.Com21_consulta_scategoria_letra(letra);
    //    if (_letras.Tables[0].Rows.Count > 0)
    //    {
    //        GvProducto.DataSource = _letras.Tables[0];
    //        GvProducto.DataBind();
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias con la letra: " + letra + "');", true);
    //    }
    //}
    private void consultaletras(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_scategoria_letra(letra,1,0);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvImagenes.DataSource = _letras.Tables[0];
            GvImagenes.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias con la letra: " + letra + "');", true);
        }
    }
    #endregion
}