using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_categoria : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarcategoria();
           
        }
    }
    private void cargarcategoria()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_categoria();
        if (_categoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvCategoria.DataSource = _categoria.Tables[0];
            GvCategoria.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    protected void GvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCategoria.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarcategoria();
            }
        }
        catch { }
    }
    protected void GvCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvCategoria.SelectedRow;
            string Id_Categoria = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Categoria");
            Id_Categoria = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_categoria_id(int.Parse(Id_Categoria));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdcategoria.Value = dr[0].ToString();
                    Session["hfIdcategoria"] = dr[0].ToString();
                    this.txtcategoria.Text = dr[1].ToString();
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
    protected void GvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdCategorias = GvCategoria.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_categoria(int.Parse(IdCategorias)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
               // elimina_costo(int.Parse(IdCategorias));
                eliminaSubCategorias(IdCategorias);
            }
            cargarcategoria();
            
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
            ingresocategorias();
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
    private void ingresocategorias()
    {
        try
        {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Categoria/>");
            DataSet dscat = _administrador.Com21_consulta_categoria_letra(txtcategoria.Text.ToUpper(),2);
            if (dscat.Tables[0].Rows.Count == 0)
            {
                _xmlDatos.DocumentElement.SetAttribute("Categoria", txtcategoria.Text.ToUpper());
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
                if (_administrador.Com21_ingresa_categoria(_xmlDatos.OuterXml))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                }
                cargarcategoria();
                Limpiar();
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
            editacategorias();
        }
    }
    private void editacategorias()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Categoria/>");
            _xmlDatos.DocumentElement.SetAttribute("Categoria", txtcategoria.Text.ToUpper());
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
            if (hfIdcategoria.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_categoria(_xmlDatos.OuterXml, int.Parse(hfIdcategoria.Value)))
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
                int idcategoria = int.Parse(Session["hfIdcategoria"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_categoria(_xmlDatos.OuterXml, idcategoria))
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
            cargarcategoria();
            Limpiar();
            txtbuscarcategoria.Text = "";
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_categoria_letra(letra,1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvCategoria.DataSource = _letras.Tables[0];
            GvCategoria.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen categorias para la busqueda: " + letra + "');", true);
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
       
    //}
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarcategoria.Text.Length > 0)
        {
            string letra = txtbuscarcategoria.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarcategoria();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarcategoria.Text = "";
        cargarcategoria();
    }
    //protected void lbvisualizar_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (fuimagen.HasFile)
    //        {
    //            string fileName = Server.HtmlEncode(fuimagen.FileName);
    //            string extension = System.IO.Path.GetExtension(fileName);
    //            if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
    //            {

    //                classRandom sa = new classRandom();
    //                savePath = "";
    //                savePath += sa.NextString(6, true, false, true, false);
    //                savePath += extension;
    //                fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\categorias\\") + savePath);
    //                String ruta = Server.MapPath("..\\upload\\categorias\\" + savePath);
    //                System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
    //                //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
    //                int ancho = int.Parse(objImage.Width.ToString());
    //                int alto = int.Parse(objImage.Height.ToString());
    //                objImage.Dispose();
    //                objImage = null;

    //                if ((ancho <= 300) && (alto <= 300))
    //                {
    //                    img.ImageUrl = "~/upload/categorias/" + savePath;
    //                }
    //                else
    //                {
    //                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
    //                }
    //            }

    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        Console.WriteLine(Ex.Message);
    //        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
    //    }
    //}
    private void eliminaSubCategorias(String IdCategorias)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _scategoria = _consulta.Com21_consulta_scategoria_id(int.Parse(IdCategorias));
        if (_scategoria.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _scategoria.Tables[1].Rows)
            {
                if (_consulta.Com21_elimina_scategoria(int.Parse(r["Id_SubCategoria"].ToString())))
                {
                }
                else
                {
                }
                if (_consulta.Com21_inactivar_productos_scategoria(int.Parse(r["Id_SubCategoria"].ToString())))
                {
                }
                else
                {
                }
            }
        }
    }
}