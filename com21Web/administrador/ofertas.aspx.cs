using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;
using System.Net.Mail;

public partial class administrador_ofertas : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarultimo();
            cargarofertas();
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
    private void cargarofertas()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_noticias();
        if (_provincias.Tables[1].Rows.Count > 0)
        {
            slidesi.Visible = true;
            slideno.Visible = false;
            GvNoticias.DataSource = _provincias.Tables[1];
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
                cargarofertas();
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
            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
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
                cargarofertas();
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
            ingresoofertas();
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
    private void ingresoofertas()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Noticias/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
            _xmlDatos.DocumentElement.SetAttribute("DescripcionCorta", txtinfo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtdescripcion.Content);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Ident", "2");

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
                            String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "F");
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
                            String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "F");
                            if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                        }
                        cargarofertas();
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
            _xmlDatos.DocumentElement.SetAttribute("Ident", "2");
            String imagen = img.ImageUrl+"";
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
                        String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "F");
                        if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                            EnviarOfertas(imagen, txtinfo.Text, _urlgenerada);
                        }
                    }
                    else
                    {
                        String _urlgenerada = GenerateURLNoticias(this.txttitulo.Text, hfIdNoticias.Value, "0", "0", "F");
                        if (_administrador.Com21_edita_noticias_url(_urlgenerada, int.Parse(hfIdNoticias.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                            EnviarOfertas(imagen, txtinfo.Text, _urlgenerada);
                        }
                    }
                    cargarofertas();
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
                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\ofertas\\") + savePath);
                    String ruta = Server.MapPath("..\\upload\\ofertas\\" + savePath);
                    System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
                    //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                    int ancho = int.Parse(objImage.Width.ToString());
                    int alto = int.Parse(objImage.Height.ToString());
                    objImage.Dispose();
                    objImage = null;

                    if ((ancho <= 750) && (alto <= 750))
                    {
                        img.ImageUrl = "~/upload/ofertas/" + savePath;
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
            //Console.WriteLine(Ex.Message);
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
            cargarofertas();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarnoti.Text = "";
        cargarofertas();
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_noticias_letra(letra);
        if (_letras.Tables[1].Rows.Count > 0)
        {
            GvNoticias.DataSource = _letras.Tables[1];
            GvNoticias.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen ofertas para la busqueda: " + letra + "');", true);
        }
    }
    #endregion
    private void EnviarOfertas(String imagen, String texto, String url)
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        String diseño = @"<html xmlns='http://www.w3.org/1999/xhtml'>
        <head>
            <title></title>
        </head>
        <body>
            <table style='width: 65%; background:#ABCD43;'>
                <tr>
                    <td style='width: 50%'>
                        <img alt='' src='../images/logocom21icon.png' width='85' /></td>
                    <td style='width: 50%; text-align: right; vertical-align: bottom;'>
                        <div style='padding: 2px; font-size: 20px; font-weight: bold;'>OFERTAS ESPECIALES</div>
                        <div>
                            <img alt='' src='../images/face.png' />&nbsp;&nbsp;<img alt='' src='../images/twit.png' /></div>
                    </td>
                </tr>
                </table>
            <table style='width: 65%;'>
                <tr>
                    <td style='width: 25%; text-align: center; vertical-align: middle'>
                        <a ref="+ url+@" target='_blank'><img alt='' src='"+ imagen +@"' /></a>
                    </td>
                    <td style='background-color: #EEEEEE; color: #000000; width: 40%;'>
                            " + texto + @"
                    </td>
                </tr>
                </table>
        </body>
        </html>";

        try
        {
            DataSet dsUsuario = _administrador.Com21_consulta_cliente();
            if (dsUsuario.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in dsUsuario.Tables[1].Rows)
                {
                    MailMessage objMail = new MailMessage();
                    objMail.IsBodyHtml = true;
                    objMail.From = new MailAddress("info@com21.com.ec");
                    objMail.To.Add(row["Correo"] + "");
                    //objMail.To.Add("rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec");
                    objMail.Subject = "OFERTAS ESPECIALES";
                    objMail.Body = diseño;

                    //con puerto
                    //SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com", 587);
                    //objSMTPClient.EnableSsl = true;
                    //objSMTPClient.UseDefaultCredentials = false;
                    //objSMTPClient.Credentials = new NetworkCredential("steven.cardenas@bonsai.com.ec", "Steven!2012");
                    //fin con puertos

                    //sin puertos
                    SmtpClient objSMTPClient = new SmtpClient("relay-hosting.secureserver.net");
                    objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //fin de sin puertos

                    objSMTPClient.Send(objMail);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Su notificación no fue enviada.');", true);
        }
    }
}