using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com21DLL;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;


public partial class administrador_usuadministrador : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarAdministrador();
        }
    }
    private void cargarAdministrador()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _scategoria = _consulta.Com21_consulta_administrador();
        if (_scategoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvAdmin.DataSource = _scategoria.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }

    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            if (email_bien_escrito(txtcorreo.Text) == false)
            { ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor digite un correo valido');", true); }
            else
            { ingresadministrador(); }
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese todo los campos');", true);
        }
    }
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*([,;]\\s*\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)*";

        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private void ingresadministrador()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Administrador/>");
            _xmlDatos.DocumentElement.SetAttribute("Usuario", txtusuario.Text);
            _xmlDatos.DocumentElement.SetAttribute("Clave", txtclave.Text);
            _xmlDatos.DocumentElement.SetAttribute("Nombres", txtnombres.Text);
            _xmlDatos.DocumentElement.SetAttribute("Apellidos", txtapellidos.Text);
            _xmlDatos.DocumentElement.SetAttribute("Correo", txtcorreo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl);
            _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefono.Text);
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
            
                if (_administrador.Com21_ingresa_administrador(_xmlDatos.OuterXml))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    cargarAdministrador();
                    enviarcorreo();
                    Limpiar();
                    
                }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void enviarcorreo()
    {
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(txtcorreo.Text);
        objMail.Subject = "Creación de Usuario";
        objMail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head runat='server'><title>Com21 S.A ::. Registro de Usuario</title></head><body><div style='width: 500px;margin-right: auto; margin-left: auto;'>" +
                       "<table style='border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;'><tr><td style='background-position: center top; padding: 5px; text-align: left; background-image: url(http://designsie.com/images/imagen_registro1.png); background-repeat: no-repeat; font-weight: bold;'>" +
                       "<table style='width: 100%;'><tr><td width='50%'><a href='http://designsie.com/' target='_blank'><img alt='' src='http://designsie.com/images/logocom21icon.png' width='120' /></a></td><td width='50%' style='text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;'>NUEVO ADMINISTRADOR</td>" +
                       "</tr></table></td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>&nbsp;</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>Estimado(a)</td></tr><tr><td style='padding: 5px 5px 15px 5px'>" + txtnombres.Text + " " + txtapellidos.Text + "</td>" +
                       "</tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>¡Bienvenido(a) a Com21!</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>Los datos ingresados son:</td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>" +
                       "<table style='width:100%;'><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Usuario:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtusuario.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Correo:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcorreo.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Télefono:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txttelefono.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Clave:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtclave.Text + "</td>" +
                       "</tr></table></td></tr><tr style='background-color: #E2E2E2;'><td style='padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;'>Contacto:&nbsp;&nbsp;&nbsp;<span style='font-size: 14px; color: #000000'>Tel:(+593) 42-300539</span></td></tr></table></div></body></html>";
        
        //envio de correos al administrador
        classCom21Correo clCorreo = new classCom21Correo();
        String _dominio = Request.Url.Authority;
        if (_dominio == "localhost:2304")
        {
            clCorreo.EnvioLN(1, objMail);
        }
        else
        {
            clCorreo.EnvioLN(2, objMail);
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatosedit();
        if (pro == 1)
        {
            Span1.Visible = true;
            editaadministrador();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese todo los campos');", true);
        }
    }
    private void editaadministrador()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Administrador/>");
            _xmlDatos.DocumentElement.SetAttribute("Usuario", txtusuario.Text);
            _xmlDatos.DocumentElement.SetAttribute("Clave", txtclave.Text);
            _xmlDatos.DocumentElement.SetAttribute("Nombres", txtnombres.Text);
            _xmlDatos.DocumentElement.SetAttribute("Apellidos", txtapellidos.Text);
            _xmlDatos.DocumentElement.SetAttribute("Correo", txtcorreo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", img.ImageUrl);
            _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefono.Text);
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (hfIdsadmin.Value != "")
            {

                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));

                if (_administrador.Com21_edita_administrador(_xmlDatos.OuterXml, int.Parse(hfIdsadmin.Value)))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                        btninsert.Visible = true;
                        btnedit.Visible = false;
                        if(Session["admin-id"].ToString().Equals(hfIdsadmin.Value))
                        {
                            String _dominio = Request.Url.AbsoluteUri;
                            Response.Redirect(_dominio);
                        }
                    }
                
            }
            else
            {
                int idscategoria = int.Parse(Session["hfIdsadmin"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));

                if (_administrador.Com21_edita_administrador(_xmlDatos.OuterXml, idscategoria))
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
            cargarAdministrador();
            Limpiar();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private int validadatos()
    {
        int pro = 1;
        if (txtnombres.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtapellidos.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtclave.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            pro = 0;
        }
        if (txttelefono.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtusuario.Text.Length == 0)
        {
            pro = 0;
        }
        return pro;
    }
    private int validadatosedit()
    {
        int pro = 1;
        if (txtnombres.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtapellidos.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            pro = 0;
        }
        if (txttelefono.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtusuario.Text.Length == 0)
        {
            pro = 0;
        }
        return pro;
    }
    protected void lbvisualizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                double fileSize = fuimagen.PostedFile.ContentLength;
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {
                    if (fileSize <= 102400)
                    {
                        classRandom sa = new classRandom();
                        savePath = "";
                        savePath += sa.NextString(6, true, false, true, false);
                        savePath += extension;
                        fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\administradores\\") + savePath);

                        img.ImageUrl = "~/upload/administradores/" + savePath;
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
    private void Limpiar()
    {
        txtapellidos.Text = "";
        txtclave.Text = "";
        txtcorreo.Text = "";
        txtnombres.Text = "";
        txttelefono.Text = "";
        txtusuario.Text = "";
        cbactivar.Checked = false;
        img.ImageUrl = "~/images/users.png";
    }
    #region "parat de GV"
    protected void GvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAdmin.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                txtbuscaradmin.Text = hfletra.Value;
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarAdministrador();
            }
        }
        catch { }
    }
    protected void GvAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvAdmin.SelectedRow;
            string Id_admin = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Administrador");
            Id_admin = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_administrador_id(int.Parse(Id_admin));
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //seteo todos los valores de la consulta especifica
                        this.hfIdsadmin.Value = dr[0].ToString();
                        Session["hfIdsadmin"] = dr[0].ToString();
                        this.txtusuario.Text = dr[1].ToString();
                        this.txtnombres.Text = dr[3].ToString();
                        txtapellidos.Text = dr[4].ToString();
                        txtcorreo.Text = dr[5].ToString();
                        txttelefono.Text = dr[10].ToString();
                        img.ImageUrl = dr[9].ToString();

                        if (Convert.ToBoolean(dr[11].ToString()) == true)
                        {
                            cbactivar.Checked = true;
                        }
                        else
                        {
                            cbactivar.Checked = false;
                        }
                    }
                    Span1.Visible = false;
                    btnedit.Visible = true;
                    btninsert.Visible = false;
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Idadmin = GvAdmin.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_administrador(int.Parse(Idadmin)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
                //inactivar_productos(int.Parse(IdsCategorias));
            }
            //cargarsubcategoria();
            cargarAdministrador();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    #endregion
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_administrador_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvAdmin.DataSource = _letras.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen usuarios para la busqueda: " + letra + "');", true);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        hfletra.Value = "A";
        consultaletra("A");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        hfletra.Value = "B";
        consultaletra("B");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        hfletra.Value = "C";
        consultaletra("C");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        hfletra.Value = "D";
        consultaletra("D");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        hfletra.Value = "E";
        consultaletra("E");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        hfletra.Value = "F";
        consultaletra("F");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        hfletra.Value = "G";
        consultaletra("G");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        hfletra.Value = "H";
        consultaletra("H");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        hfletra.Value = "I";
        consultaletra("I");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        hfletra.Value = "J";
        consultaletra("J");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        hfletra.Value = "K";
        consultaletra("K");
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        hfletra.Value = "L";
        consultaletra("L");
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        hfletra.Value = "M";
        consultaletra("M");
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        hfletra.Value = "N";
        consultaletra("N");
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Ñ";
        consultaletra("Ñ");
    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        hfletra.Value = "O";
        consultaletra("O");
    }
    protected void LinkButton17_Click(object sender, EventArgs e)
    {
        hfletra.Value = "P";
        consultaletra("P");
    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Q";
        consultaletra("Q");
    }
    protected void LinkButton19_Click(object sender, EventArgs e)
    {
        hfletra.Value = "R";
        consultaletra("R");
    }
    protected void LinkButton27_Click(object sender, EventArgs e)
    {
        hfletra.Value = "S";
        consultaletra("S");
    }
    protected void LinkButton20_Click(object sender, EventArgs e)
    {
        hfletra.Value = "T";
        consultaletra("T");
    }
    protected void LinkButton21_Click(object sender, EventArgs e)
    {
        hfletra.Value = "U";
        consultaletra("U");
    }
    protected void LinkButton22_Click(object sender, EventArgs e)
    {
        hfletra.Value = "V";
        consultaletra("V");
    }
    protected void LinkButton23_Click(object sender, EventArgs e)
    {
        hfletra.Value = "W";
        consultaletra("W");
    }
    protected void LinkButton24_Click(object sender, EventArgs e)
    {
        hfletra.Value = "X";
        consultaletra("X");
    }
    protected void LinkButton25_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Y";
        consultaletra("Y");
    }
    protected void LinkButton26_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Z";
        consultaletra("Z");
    }
    protected void LinkButton28_Click(object sender, EventArgs e)
    {
        hfletra.Value = "";
        cargarAdministrador();
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscaradmin.Text.Length > 0)
        {
            string letra = txtbuscaradmin.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarAdministrador();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscaradmin.Text = "";
        cargarAdministrador();
    }
    protected void txtusuario_TextChanged(object sender, EventArgs e)
    {
        if (txtusuario.Text != "")
        {
            Span1.Visible = true;
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet dssuser = _consulta.Com21_consulta_administrador_user(txtusuario.Text);
            if (dssuser.Tables[0].Rows.Count > 0)
            {
                Session["em"] = "0";
                Span1.InnerText = "Usuario no disponible";
                Span1.Attributes.Add("class", "Aviso");
                Span1.Style.Add("color", "red");
                Span1.Style.Add("font-size", "11");
                txtusuario.Focus();
            }
            else
            {

                Session["em"] = "1";
                Span1.InnerText = "Usuario Disponible";
                Span1.Attributes.Add("class", "AvisoVerde");
                Span1.Style.Add("color", "green");
                Span1.Style.Add("font-size", "11");
                txtclave.Focus();
            }
        }
        else
        {
            Span1.InnerText = "";
            txtusuario.Focus();
        }
    }
}