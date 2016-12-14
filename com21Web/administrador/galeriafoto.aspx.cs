using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_galeriafoto : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarslide();
        }
    }
    private void cargarslide()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_slide();
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            slidesi.Visible = true;
            slideno.Visible = false;
            GvSlide.DataSource = _provincias.Tables[0];
            GvSlide.DataBind();
        }
        else
        {
            slidesi.Visible = false;
            slideno.Visible = true;
        }
        
    }
    protected void GvSlide_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvSlide.PageIndex = e.NewPageIndex;
        try
        {
            cargarslide();
        }
        catch { }
    }
    protected void GvSlide_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvSlide.SelectedRow;
            string Id_Slide = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Slide");
            Id_Slide = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_slide_id(int.Parse(Id_Slide));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.IdSlide.Value = dr[0].ToString();
                    this.txtinfo.Text = dr[2].ToString();
                    this.txttitulo.Text = dr[1].ToString();
                    if (Convert.ToBoolean(dr[7].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
                    img.ImageUrl = dr[3].ToString();
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
    protected void GvSlide_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Id_Slide = GvSlide.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_slide(int.Parse(Id_Slide)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
            }
            cargarslide();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            ingresoslide();
        }
    }
    private int validadatos()
    {
        int pro = 0;
        if (txtinfo.Text.Length > 0)
        {
            pro = 1;
        }
        if (this.txttitulo.Text.Length > 0)
        {
            pro = 1;
        }
        return pro;
    }
    private void ingresoslide()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Slide/>");
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtinfo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
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
                if (img.ImageUrl.ToString() != "~/images/imagenes/icons_variados_theme_negro/64_image.png")
                {
                    if (_administrador.Com21_ingresa_slide(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
                    cargarslide();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccione una imagen para realizar el ingreso');", true);
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
        txtinfo.Text = "";
        txttitulo.Text = "";
        cbactivar.Checked = false;
        img.ImageUrl = "~/images/imagenes/icons_variados_theme_negro/64_image.png";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editaslide();
        }
    }
    private void editaslide()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Slide/>");
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtinfo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
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
            if (img.ImageUrl.ToString() != "~/images/imagenes/icons_variados_theme_negro/64_image.png")
            {
                if (_administrador.Com21_edita_slide(_xmlDatos.OuterXml, int.Parse(IdSlide.Value)))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                    btninsert.Visible = true;
                    btnedit.Visible = false;
                }
                cargarslide();
                Limpiar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccione una imagen para editar');", true);
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
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
                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\slide\\") + savePath);
                    string ruta1 = Server.MapPath("..\\upload\\slide\\" + savePath);
                    System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta1);
                    //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                    int ancho = int.Parse(objImage.Width.ToString());
                    int alto = int.Parse(objImage.Height.ToString());
                    objImage.Dispose();
                    objImage = null;

                    if ((ancho <= 770) && (alto <= 388))
                    {
                        img.ImageUrl = "~/upload/slide/" + savePath;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
                    }
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
}