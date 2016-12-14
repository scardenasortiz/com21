using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_subcategoria : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarsubcategoria();
            cargarcategoria();
        }
    }
    private void cargarsubcategoria()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _scategoria = _consulta.Com21_consulta_scategoria();
        if (_scategoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvSubCategoria.DataSource = _scategoria.Tables[0];
            GvSubCategoria.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    protected void GvSubCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvSubCategoria.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarsubcategoria();
            }
        }
        catch { }
    }
    protected void GvSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvSubCategoria.SelectedRow;
            string Id_sCategoria = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_SubCategoria");
            Id_sCategoria = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_scategoria_id(int.Parse(Id_sCategoria));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdscategoria.Value = dr[0].ToString();
                    Session["hfIdscategoria"] = dr[0].ToString();
                    this.txtcategoria.Text = dr[1].ToString();
                    this.ddlcategorias.SelectedValue = dr[6].ToString();
                    //if (dr["Ruta"].ToString() == "")
                    //{
                    //    this.img.ImageUrl = "~/images/SIN_IMAGEN_CATSUB.png";
                    //}
                    //else
                    //{
                    //    this.img.ImageUrl = dr["Ruta"].ToString();
                    //}
                    if (Convert.ToBoolean(dr[2].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
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
    protected void GvSubCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdsCategorias = GvSubCategoria.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_scategoria(int.Parse(IdsCategorias)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
                inactivar_productos(int.Parse(IdsCategorias));
            }
            cargarsubcategoria();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    private void inactivar_productos(int id_subcategoria)
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_inactivar_productos_scategoria(id_subcategoria))
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo inactivar los productos');", true);
        }
        else
        {

        }
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            ingresosubcategorias();
        }
    }
    private int validadatos()
    {
        int pro = 0;
        if (txtcategoria.Text.Length > 0)
        {
            pro = 1;
        }
        return pro;
    }
    private void ingresosubcategorias()
    {
        try
        {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_SubCategoria/>");
            DataSet dssubcat = _administrador.Com21_consulta_scategoria_letra(txtcategoria.Text.ToUpper(),2,int.Parse(ddlcategorias.SelectedValue));
            if (dssubcat.Tables[0].Rows.Count == 0)
            {
                _xmlDatos.DocumentElement.SetAttribute("Titulo", txtcategoria.Text.ToUpper());
                _xmlDatos.DocumentElement.SetAttribute("Id_Categoria", ddlcategorias.SelectedValue);
                _xmlDatos.DocumentElement.SetAttribute("Ruta", "");

                if (cbactivar.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
                }

                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (ddlcategorias.SelectedValue != "0")
                {
                    if (_administrador.Com21_ingresa_scategoria(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }

                    cargarsubcategoria();
                    Limpiar();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro existente');", true);
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
        txtcategoria.Text = "";
        cbactivar.Checked = false;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editasubcategorias();
        }
    }
    private void editasubcategorias()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_SubCategoria/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txtcategoria.Text.ToUpper());
            _xmlDatos.DocumentElement.SetAttribute("Id_Categoria", ddlcategorias.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", "");
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (hfIdscategoria.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_scategoria(_xmlDatos.OuterXml, int.Parse(hfIdscategoria.Value)))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                    btninsert.Visible = true;
                    btnedit.Visible = false;
                }
            }
            else
            {
                int idscategoria = int.Parse(Session["hfIdscategoria"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_scategoria(_xmlDatos.OuterXml, idscategoria))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                    btninsert.Visible = true;
                    btnedit.Visible = false;
                }
            }
            cargarsubcategoria();
            Limpiar();
            txtbuscarsubcategoria.Text = "";
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }

    private void cargarcategoria()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_categoria();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            ddlcategorias.DataSource = _categoria.Tables[1];
            ddlcategorias.DataTextField = "Categoria";
            ddlcategorias.DataValueField = "Id_Categoria";
            ddlcategorias.DataBind();
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen ctageorias";
            _ddl.Value = "0";
            ddlcategorias.Items.Clear();

            ddlcategorias.Items.Add(_ddl);
            ddlcategorias.DataBind();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarsubcategoria.Text = "";
        cargarsubcategoria();
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_scategoria_letra(letra,1,0);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvSubCategoria.DataSource = _letras.Tables[0];
            GvSubCategoria.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen Sub-categorias para la busqueda: " + letra + "');", true);
        }
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "A";
    //    consultaletra("A");
    //}
    //protected void LinkButton2_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "B";
    //    consultaletra("B");
    //}
    //protected void LinkButton3_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "C";
    //    consultaletra("C");
    //}
    //protected void LinkButton4_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "D";
    //    consultaletra("D");
    //}
    //protected void LinkButton5_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "E";
    //    consultaletra("E");
    //}
    //protected void LinkButton6_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "F";
    //    consultaletra("F");
    //}
    //protected void LinkButton7_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "G";
    //    consultaletra("G");
    //}
    //protected void LinkButton8_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "H";
    //    consultaletra("H");
    //}
    //protected void LinkButton9_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "I";
    //    consultaletra("I");
    //}
    //protected void LinkButton10_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "J";
    //    consultaletra("J");
    //}
    //protected void LinkButton11_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "K";
    //    consultaletra("K");
    //}
    //protected void LinkButton12_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "L";
    //    consultaletra("L");
    //}
    //protected void LinkButton13_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "M";
    //    consultaletra("M");
    //}
    //protected void LinkButton14_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "N";
    //    consultaletra("N");
    //}
    //protected void LinkButton15_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "Ñ";
    //    consultaletra("Ñ");
    //}
    //protected void LinkButton16_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "O";
    //    consultaletra("O");
    //}
    //protected void LinkButton17_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "P";
    //    consultaletra("P");
    //}
    //protected void LinkButton18_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "Q";
    //    consultaletra("Q");
    //}
    //protected void LinkButton19_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "R";
    //    consultaletra("R");
    //}
    //protected void LinkButton27_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "S";
    //    consultaletra("S");
    //}
    //protected void LinkButton20_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "T";
    //    consultaletra("T");
    //}
    //protected void LinkButton21_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "U";
    //    consultaletra("U");
    //}
    //protected void LinkButton22_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "V";
    //    consultaletra("V");
    //}
    //protected void LinkButton23_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "W";
    //    consultaletra("W");
    //}
    //protected void LinkButton24_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "X";
    //    consultaletra("X");
    //}
    //protected void LinkButton25_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "Y";
    //    consultaletra("Y");
    //}
    //protected void LinkButton26_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "Z";
    //    consultaletra("Z");
    //}
    //protected void LinkButton28_Click(object sender, EventArgs e)
    //{
    //    hfletra.Value = "";
    //    cargarsubcategoria();
    //}
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarsubcategoria.Text.Length > 0)
        {
            string letra = txtbuscarsubcategoria.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarcategoria();
        }
    }
//    protected void lbvisualizar_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            if (fuimagen.HasFile)
//            {
//                string fileName = Server.HtmlEncode(fuimagen.FileName);
//                string extension = System.IO.Path.GetExtension(fileName);
//                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
//                {

//                    classRandom sa = new classRandom();
//                    savePath = "";
//                    savePath += sa.NextString(6, true, false, true, false);
//                    savePath += extension;
//                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\subcategoria\\") + savePath);
//                    String ruta = Server.MapPath("..\\upload\\subcategoria\\" + savePath);
//                    System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
//                    //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
//                    int ancho = int.Parse(objImage.Width.ToString());
//                    int alto = int.Parse(objImage.Height.ToString());
//                    objImage.Dispose();
//                    objImage = null;

//                    if ((ancho <= 300) && (alto <= 300))
//                    {
//                        img.ImageUrl = "~/upload/subcategoria/" + savePath;
//                    }
//                    else
//                    {
//                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
//                    }
//                }

//            }
//        }
//        catch (Exception Ex)
//        {
//            Console.WriteLine(Ex.Message);
//            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
//        }
//    }
}