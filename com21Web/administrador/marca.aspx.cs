using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_marca : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarmarca();
           
        }
    }
    private void cargarmarca()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_marca();
        if (_categoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvMarca.DataSource = _categoria.Tables[0];
            GvMarca.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    protected void GvMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvMarca.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarmarca();
            }
        }
        catch { }
    }
    protected void GvMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvMarca.SelectedRow;
            string Id_Marca = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Marca");
            Id_Marca = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_marca_id(int.Parse(Id_Marca));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdmarca.Value = dr[0].ToString();
                    Session["hfIdmarca"] = dr[0].ToString();
                    this.txtmarca.Text = dr[1].ToString();
                    //this.img.ImageUrl = dr["Ruta"].ToString();
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
    protected void GvMarca_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdMarcas = GvMarca.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_marca(int.Parse(IdMarcas)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
               // elimina_costo(int.Parse(IdCategorias));
                inactivar_productos(int.Parse(IdMarcas));
            }
            cargarmarca();
            
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
            ingresociudades();
        }
    }
    private int validadatos()
    {
        int pro = 0;
        if (txtmarca.Text.Length > 0)
        {
            pro = 1;
        }
        return pro;
    }
    private void ingresociudades()
    {
        try
        {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Marca/>");
            DataSet dsmarcas = _administrador.Com21_consulta_marca_letra(txtmarca.Text.ToUpper(),2);
            if (dsmarcas.Tables[0].Rows.Count == 0)
            {
                _xmlDatos.DocumentElement.SetAttribute("Marca", txtmarca.Text.ToUpper());
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
                if (_administrador.Com21_ingresa_marca(_xmlDatos.OuterXml))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                }
                cargarmarca();
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
        txtmarca.Text = "";
        cbactivar.Checked = false;
        //img.ImageUrl = "~/images/SIN_IMAGEN_Mar.png";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editaciudades();
        }
    }
    private void editaciudades()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Marca/>");
            _xmlDatos.DocumentElement.SetAttribute("Marca", txtmarca.Text.ToUpper());
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
            if (hfIdmarca.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_marca(_xmlDatos.OuterXml, int.Parse(hfIdmarca.Value)))
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
                int idcategoria = int.Parse(Session["hfIdmarca"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (_administrador.Com21_edita_marca(_xmlDatos.OuterXml, idcategoria))
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
            cargarmarca();
            Limpiar();
            txtbuscarmarca.Text = "";
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void inactivar_productos(int IdMarcas)
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_inactivar_productos_marca(IdMarcas))
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo inactivar los productos');", true);
        }
        else
        {

        }
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_marca_letra(letra,1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvMarca.DataSource = _letras.Tables[0];
            GvMarca.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen marcas para la busqueda: " + letra + "');", true);
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
    //    cargarmarca();
    //}
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarmarca.Text.Length > 0)
        {
            string letra = txtbuscarmarca.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarmarca();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarmarca.Text = "";
        cargarmarca();
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
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
    //                fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\marca\\") + savePath);

    //                img.ImageUrl = "~/upload/marca/" + savePath;
    //            }

    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        Console.WriteLine(Ex.Message);
    //        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
    //    }
    //}
}