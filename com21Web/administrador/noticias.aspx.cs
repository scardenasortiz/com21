using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_noticias : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarultimo();
            cargarnoticias();
        }
    }
    private void cargarultimo()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ultimo = _consulta.Com21_consulta_noticias_ultimo();
        if (_ultimo.Tables[0].Rows.Count > 0)
        {
            int newid = 0;
            foreach (DataRow r in _ultimo.Tables[0].Rows)
            {
                newid = int.Parse(r[0].ToString()) + 1;
            }
            hfIdNoticias.Value = Convert.ToString(newid);
        }
    }
    private void cargarnoticias()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_noticias();
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            slidesi.Visible = true;
            slideno.Visible = false;
            GvNoticias.DataSource = _provincias.Tables[0];
            GvNoticias.DataBind();
        }
        else
        {
            slidesi.Visible = false;
            slideno.Visible = true;
        }
        
    }
    protected void GvNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvNoticias.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarnoticias();
            }
        }
        catch { }
    }
    protected void GvNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = GvNoticias.SelectedRow;
            string Id_Noticia = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Noticia");
            Id_Noticia = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_noticias_id(int.Parse(Id_Noticia));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdNoticias.Value = dr[0].ToString();
                    this.txtinfo.Text = dr[2].ToString();
                    this.txttitulo.Text = dr[1].ToString();
                    this.txtdescripcion.Content = dr[3].ToString();
                    if (Convert.ToBoolean(dr[8].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
                    img.ImageUrl = dr[4].ToString();
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
    protected void GvNoticias_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Id_Noticia = GvNoticias.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_noticias(int.Parse(Id_Noticia)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
                cargarnoticias();
            }            
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
            ingresoservicios();
        }
    }
    private int validadatos()
    {
        int pro = 1;
        if (txtinfo.Text.Length == 0)
        {
            pro = 0;
        }
        if (this.txttitulo.Text.Length == 0)
        {
            pro = 0;
        }
        return pro;
    }
    private void ingresoservicios()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Noticias/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
            _xmlDatos.DocumentElement.SetAttribute("DescripcionCorta", txtinfo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtdescripcion.Content);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ident", "1");

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
                
                    if (_administrador.Com21_ingresa_noticias(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                        String _puerto = Request.Url.Authority;
                        if (_puerto == "localhost:2304")
                        {
                            String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "N");
                            if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "N");
                            if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                        }
                        cargarnoticias();
                        Limpiar();
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
        txtdescripcion.Content = "";
        cbactivar.Checked = false;
        img.ImageUrl = "~/images/SIN_IMAGEN_SERV.png";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editanoticias();
        }
    }
    private void editanoticias()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Noticias/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
            _xmlDatos.DocumentElement.SetAttribute("DescripcionCorta", txtinfo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtdescripcion.Content);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ident", "1");

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
            
                if (_administrador.Com21_edita_noticias(_xmlDatos.OuterXml, int.Parse(hfIdNoticias.Value)))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                    btninsert.Visible = true;
                    btnedit.Visible = false;
                    String _puerto = Request.Url.Authority;
                    if (_puerto == "localhost:2304")
                    {
                        String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "N");
                        if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "N");
                        if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                        }
                    }
                    cargarnoticias();
                    Limpiar();
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
                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\noticias\\") + savePath);
                    String ruta = Server.MapPath("..\\upload\\noticias\\" + savePath);
                    System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
                    //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                    int ancho = int.Parse(objImage.Width.ToString());
                    int alto = int.Parse(objImage.Height.ToString());
                    objImage.Dispose();
                    objImage = null;

                    if ((ancho <= 450) && (alto <= 450))
                    {
                        img.ImageUrl = "~/upload/noticias/" + savePath;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
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
    public static string GenerateURLNoticias(object Title, object strId, object strCat, object strSub, object strTipo)
    {

        string strTitle = Title.ToString();

        #region Generate SEO Friendly URL based on Title
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');

        strTitle = strTitle.ToLower();
        char[] chars = @"$%#@!*?;:´~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        strTitle = strTitle.Replace("c#", "C-Sharp");
        strTitle = strTitle.Replace("vb.net", "VB-Net");
        strTitle = strTitle.Replace("asp.net", "Asp-Net");
        strTitle = strTitle.Replace("á", "a");
        strTitle = strTitle.Replace("é", "e");
        strTitle = strTitle.Replace("í", "i");
        strTitle = strTitle.Replace("ó", "o");
        strTitle = strTitle.Replace("ú", "u");
        strTitle = strTitle.Replace("Á", "A");
        strTitle = strTitle.Replace("É", "E");
        strTitle = strTitle.Replace("Í", "I");
        strTitle = strTitle.Replace("Ó", "O");
        strTitle = strTitle.Replace("Ú", "U");
        strTitle = strTitle.Replace("ç", "c");
        strTitle = strTitle.Replace("Ç", "C");
        strTitle = strTitle.Replace("Ä", "A");
        strTitle = strTitle.Replace("Ë", "E");
        strTitle = strTitle.Replace("Ï", "I");
        strTitle = strTitle.Replace("Ö", "O");
        strTitle = strTitle.Replace("Ü", "U");
        strTitle = strTitle.Replace("ä", "a");
        strTitle = strTitle.Replace("ë", "e");
        strTitle = strTitle.Replace("ï", "i");
        strTitle = strTitle.Replace("ö", "o");
        strTitle = strTitle.Replace("ü", "u");

        //Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
                strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("-----", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');


        #endregion

        //Append ID at the end of SEO Friendly URL
        strTitle = "" + strTitle + "-" + strId + "-" + strCat + "-" + strSub + "-" + strTipo + ".aspx";

        return strTitle;
    }
    public static string RemoverSignosAcentos(object texto)
    {
        string texto2 = texto.ToString();
        var textoSinAcentos = string.Empty;

        foreach (var caracter in texto2)
        {
            var indexConAcento = ConSignos.IndexOf(caracter);
            if (indexConAcento > -1)
                textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
            else
                textoSinAcentos = textoSinAcentos + (caracter);
        }
        return textoSinAcentos;
    }
    private const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
    private const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarnoti.Text.Length > 0)
        {
            string letra = txtbuscarnoti.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarnoticias();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarnoti.Text = "";
        cargarnoticias();
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_noticias_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvNoticias.DataSource = _letras.Tables[0];
            GvNoticias.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen noticias para la busqueda: " + letra + "');", true);
        }
    }
    #endregion
}