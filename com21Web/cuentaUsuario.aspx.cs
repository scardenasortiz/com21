using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

public partial class cuentaUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                cargarDatos();
                cargarPais();
                cargarProvincia();
                cargarCiudad();
                cargarDireccionEnvio();
                cargarprovinciasDatos();
                cargarciudadDatos();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    #region "Consultar, Editar, Validar, Limpiar - DATOS PERSONALES DEL USUARIO"
    private void cargarDatos()
    {
        try
        {
            int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _user = _consulta.Com21_consulta_cliente_id(id);
            if (_user.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in _user.Tables[0].Rows)
                {
                    txtnombres.Text = r["Nombres"].ToString();
                    txtapellidos.Text = r["Apellidos"].ToString();
                    ddlsexo.SelectedValue = r["Id_Sexo"].ToString();
                    txtcorreo.Text = r["Correo"].ToString();
                    txtdireccion.Text = r["Direccion"].ToString();
                    txttelefono.Text = r["Telefono"].ToString();
                    txtcelular.Text = r["Celular"].ToString();
                    txtcedula.Text = r["Cedula"].ToString();
                    cargarprovinciasDatos();
                    ddlprovinciadatos.SelectedValue = r["Id_Provincia"].ToString();
                    cargarciudadDatos();
                    ddlciudaddatos.SelectedValue = r["Id_Ciudad"].ToString();
                    if (Convert.ToBoolean(r["Notificaciones"].ToString()) == true)
                    {
                        cbboletin.Checked = true;
                    }
                    else
                    {
                        cbboletin.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lbleditar_Click(object sender, EventArgs e)
    {
        txtapellidos.Enabled = true;
        txtcelular.Enabled = true;
        txtcorreo.Enabled = true;
        txtdireccion.Enabled = true;
        txtnombres.Enabled = true;
        txttelefono.Enabled = true;
        ddlsexo.Enabled = true;
        ddlciudaddatos.Enabled = true;
        ddlprovinciadatos.Enabled = true;
        txtcedula.Enabled = true;
        cbboletin.Enabled = true;
        btneditardatos.Enabled = true;
    }
    private void editarDatos()
    {
        Response.Cookies["EmailCom21Web"].Value = txtcorreo.Text;
        string id = Request.Cookies["IdCom21Web"].Value;
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        _xmlDatos.DocumentElement.SetAttribute("Nombres", txtnombres.Text);
        _xmlDatos.DocumentElement.SetAttribute("Apellidos", txtapellidos.Text);
        _xmlDatos.DocumentElement.SetAttribute("Correo", txtcorreo.Text);
        _xmlDatos.DocumentElement.SetAttribute("Direccion", txtdireccion.Text);
        _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefono.Text);
        _xmlDatos.DocumentElement.SetAttribute("Celular", txtcelular.Text);
        _xmlDatos.DocumentElement.SetAttribute("Id_Sexo", ddlsexo.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("Sexo", ddlsexo.SelectedItem.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Id_Pais", "1");
        _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovinciadatos.SelectedValue.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudaddatos.SelectedValue.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Cedula", txtcedula.Text);
        if (cbboletin.Checked == true)
        {
            _xmlDatos.DocumentElement.SetAttribute("Notificaciones", "1");
        }
        else
        {
            _xmlDatos.DocumentElement.SetAttribute("Notificaciones", "0");
        }

        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente(_xmlDatos.OuterXml, int.Parse(id)))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al registrarte');", true);
        }
        else
        {
            enviarcorreoDatos();
            limpiarDatos();
            inhabilitar();
            cargarDatos();
        }
    }
    protected void btneditardatos_Click(object sender, EventArgs e)
    {
        int i = validardatosPersonales();
        if (i == 1)
        {
            editarDatos();
        }
    }
    private void limpiarDatos()
    {
        txtapellidos.Text = "";
        txtcelular.Text = "";
        txtcorreo.Text = "";
        txtdireccion.Text = "";
        txtnombres.Text = "";
        txttelefono.Text = "";
        cbboletin.Checked = false;
    }
    private void inhabilitar()
    {
        txtapellidos.Enabled = false;
        txtcelular.Enabled = false;
        txtcorreo.Enabled = false;
        txtdireccion.Enabled = false;
        txtnombres.Enabled = false;
        txttelefono.Enabled = false;
        ddlsexo.Enabled = false;
        ddlprovinciadatos.Enabled = false;
        ddlciudaddatos.Enabled = false;
        txtcedula.Enabled = false;
        cbboletin.Enabled = false;
        btneditardatos.Enabled = false;
    }
    private int validardatosPersonales()
    {
        int i = 1;
        if (txtapellidos.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcelular.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        if (txtdireccion.Text.Length == 0)
        {
            i = 0;
        }
        if (txtnombres.Text.Length == 0)
        {
            i = 0;
        }
        if (txttelefono.Text.Length == 0)
        {
            i = 0;
        }
        if (email_bien_escrito(txtcorreo.Text) == false)
        {
            i = 0;
        }
        string id = ddlprovinciadatos.SelectedValue.ToString();
        if (int.Parse(id) == 0)
        {
            i = 0;
        }
        string ids = ddlciudaddatos.SelectedValue.ToString();
        if (int.Parse(ids) == 0)
        {
            i = 0;
        }
        if (txtcedula.Text.Length == 0)
        {
            i = 0;
        }
        return i;
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
    private void enviarcorreoDatos()
    {
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");
        objMail.CC.Add("scardenas@hotmail.com");
        objMail.To.Add(txtcorreo.Text);
        objMail.Subject = "Edición de Usuario";
        objMail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head runat='server'><title>Com21 S.A ::. Registro de Usuario</title></head><body><div style='width: 500px;margin-right: auto; margin-left: auto;'>" +
                       "<table style='border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;'><tr><td style='background-position: center top; padding: 5px; text-align: left; background-image: url('http://designsie.com/images/imagen_registro1.png'); background-repeat: no-repeat; font-weight: bold;'>" +
                       "<table style='width: 100%;'><tr><td width='50%'><a href='http://designsie.com/' target='_blank'><img alt='' src='http://designsie.com/images/logocom21icon.png' width='120' /></a></td><td width='50%' style='text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;'>EDICIÓN DEL CLIENTE</td>" +
                       "</tr></table></td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>&nbsp;</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>Estimado(a)</td></tr><tr><td style='padding: 5px 5px 15px 5px'>" + txtnombres.Text + " " + txtapellidos.Text + "</td>" +
                       "</tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>Los datos editados son:</td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>" +
                       "<table style='width:100%;'><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Usuario:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + Request.Cookies["UserCom21Web"].Value + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Cédula:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcedula.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Correo:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcorreo.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Télefono:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txttelefono.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Celular:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcelular.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Dirección:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtdireccion.Text + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Provincia:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + ddlprovinciadatos.SelectedItem.ToString() + "</td>" +
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Ciudad:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + ddlciudaddatos.SelectedItem.ToString() + "</td>" +
                       "</tr></table></td></tr><tr style='background-color: #E2E2E2;'><td style='padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;'>Contacto:&nbsp;&nbsp;&nbsp;<span style='font-size: 14px; color: #000000'>Tel:(+593) 42-300539</span></td></tr></table></div></body></html>";
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
    protected void ddlprovinciadatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlprovinciadatos.SelectedValue.ToString();
        if (int.Parse(id) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlciudaddatos.DataSource = _provincias.Tables[0];
                ddlciudaddatos.DataTextField = "Ciudad";
                ddlciudaddatos.DataValueField = "Id_Ciudad";
                ddlciudaddatos.DataBind();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen ciudades";
                _ddl.Value = "0";
                ddlciudaddatos.Items.Clear();

                ddlciudaddatos.Items.Add(_ddl);
                ddlciudaddatos.DataBind();
            }
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen ciudades";
            _ddl.Value = "0";
            ddlciudaddatos.Items.Clear();

            ddlciudaddatos.Items.Add(_ddl);
            ddlciudaddatos.DataBind();
        }
    }
    private void cargarprovinciasDatos()
    {
        try
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_provincias();
            if (_provincias.Tables[2].Rows.Count > 0)
            {
                ddlprovinciadatos.DataSource = _provincias.Tables[2];
                ddlprovinciadatos.DataTextField = "Provincia";
                ddlprovinciadatos.DataValueField = "Id_Provincia";
                ddlprovinciadatos.DataBind();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen provincias";
                _ddl.Value = "0";
                ddlprovinciadatos.Items.Clear();

                ddlprovinciadatos.Items.Add(_ddl);
                ddlprovinciadatos.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void cargarciudadDatos()
    {
        try
        {
            string id = ddlprovinciadatos.SelectedValue.ToString();
            if (id != "0")
            {
                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(id));
                if (_provincias.Tables[0].Rows.Count > 0)
                {
                    ddlciudaddatos.DataSource = _provincias.Tables[0];
                    ddlciudaddatos.DataTextField = "Ciudad";
                    ddlciudaddatos.DataValueField = "Id_Ciudad";
                    ddlciudaddatos.DataBind();
                }
                else
                {
                    ListItem _ddl = new ListItem();
                    _ddl.Text = "No existen ciudades";
                    _ddl.Value = "0";
                    ddlciudaddatos.Items.Clear();

                    ddlciudaddatos.Items.Add(_ddl);
                    ddlciudaddatos.DataBind();
                }
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen ciudades";
                _ddl.Value = "0";
                ddlciudad.Items.Clear();

                ddlciudad.Items.Add(_ddl);
                ddlciudad.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region "Editar - CLAVE DEL USUARIO"
    protected void btneditarclave_Click(object sender, EventArgs e)
    {
        int i = ValidarClave();
        if (i == 1)
        {
            editarclave();
        }
        else
        {
            lblvalida.Text = "Por favor ingresar todo los campos";
        }
    }
    private int ValidarClave()
    {
        int i = 1;
        if (txtclave.Text.Length == 0)
        {
            i = 0;
        }
        if (txtconfirmar.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void editarclave()
    {
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        String _clave = classMD5.encriptaClave(txtclave.Text);
        _xmlDatos.DocumentElement.SetAttribute("Clave", _clave);
        _xmlDatos.DocumentElement.SetAttribute("CopiaClave", txtconfirmar.Text);

        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_clave_cliente(_xmlDatos.OuterXml, id))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al editar clave');", true);
        }
        else
        {
            enviarCorreoClave(txtcorreo.Text);
            limpiarclave();
        }
    }
    private void limpiarclave()
    {
        txtclave.Text = "";
        txtconfirmar.Text = "";
        lblvalida.Text = "";
    }
    private void enviarCorreoClave(String correo)
    {

        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(correo);
        objMail.Subject = "Cambio de Clave";
        objMail.Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title></head><body>" +
        "<div style=\"width: 500px;margin-right: auto; margin-left: auto;\"><table style=\"border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;\"><tr><td style=\"background-position: center top; padding: 5px; text-align: left; background-image: url(http://designsie.com/images/imagen_registro1.png); background-repeat: no-repeat; font-weight: bold;\">" +
        "<table style=\"width: 100%;\"><tr><td width=\"50%\"><a href=\"http://designsie.com/\" target=\"_blank\"><img alt=\"\" src=\"http://designsie.com/images/logocom21icon.png\" width=\"120\" /></a></td><td width=\"50%\" style=\"text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;\">CAMBIO DE CLAVE</td>" +
        "</tr></table></td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">&nbsp;</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">Estimado(a)</td></tr><tr><td style=\"padding: 5px 5px 15px 5px\">nombre-apellido</td></tr><tr>" +
        "<td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Su clave ha sido cambiada correctamente.</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\"><table style=\"width:100%;\"><tr><td style=\"width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;\">" +
        "Usuario:</td><td style=\"width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;\">" + Request.Cookies["UserCom21Web"].Value + "</td></tr><tr><td style=\"width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;\">" +
        "Clave:</td><td style=\"width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;\">" + txtclave.Text + "</td></tr></table></td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Para iniciar sesión de click en el link:&nbsp;&nbsp;<a href=\"http://designsie.com/iniciar.aspx\" target=\"_blank\">Iniciar Sesión</a>" +
        "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif; text-align: center;\"><a href=\"http://designsie.com/\" target=\"_blank\">www.com21.com.ec</a></td></tr><tr style=\"background-color: #E2E2E2;\"><td style=\"padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;\">Contacto:&nbsp;&nbsp;&nbsp;<span style=\"font-size: 14px; color: #000000\">Tel:(+593) 42-300539</span></td>" +
        "</tr></table></div></body></html>";

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
    #endregion

    #region "Ingresa, Edita, Consultar, Validar, Limpiar - DIRECCION DE ENVIO"
    private void cargarDireccionEnvio()
    {
        try
        {
            string id = Request.Cookies["IdCom21Web"].Value;
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
            if (_direccion.Tables[0].Rows.Count > 0)
            {
                hfIdentDire.Value = "1";
                foreach (DataRow r in _direccion.Tables[0].Rows)
                {
                    direccion.InnerHtml = "Dirección: " + r["Direccion"].ToString() + ", Teléfono: " + r["Telefono"].ToString() + ", Lugar de envio: " + r["Pais"].ToString() + "/" + r["Provincia"].ToString() + "/" + r["Ciudad"].ToString() + ", Nombre: " + r["ContactoNombre"].ToString();
                    hfIdDire.Value = r[0].ToString();
                }
            }
            else
            {
                hfIdentDire.Value = "0";
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btneditarenvio_Click(object sender, EventArgs e)
    {
        int i = validaDireEnvio();
        if (i == 1)
        {
            if (hfIdentDire.Value == "1")
            {
                editarDireccionEnvio();
            }
            else
            {
                ingresarDireccionEnvio();
            }
            limpiarDireccion();
        }
        else
        {
            Label3.Text = "Digite todos los campos y seleccione un país con provincias y ciudades existentes";
        }
    }
    private int validaDireEnvio()
    {
        int i = 1;
        if (txtdireccionenvio.Text.Length == 0)
        {
            i = 0;
        }
        if (txttelefonoenvio.Text.Length == 0)
        {
            i = 0;
        }
        if (txtNombrecontacto.Text.Length == 0)
        {
            i = 0;
        }
        if (ddlpais.SelectedValue == "Sin Paises")
        {
            i = 0;
        }
        if (ddlprovincia.SelectedValue == "Sin Provincias")
        {
            i = 0;
        }
        if (ddlciudad.SelectedValue == "Sin Ciudades")
        {
            i = 0;
        }
        return i;
    }
    private void editarDireccionEnvio()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        _xmlDatos.DocumentElement.SetAttribute("Id_Clientes", id);
        _xmlDatos.DocumentElement.SetAttribute("Direccion", txtdireccionenvio.Text);
        _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefonoenvio.Text);
        _xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincia.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("ContactoNombre", txtNombrecontacto.Text);

        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_direccion(_xmlDatos.OuterXml, int.Parse(hfIdDire.Value)))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al editar dirección de envio');", true);
        }
        else
        {
            limpiarDireccion();
            cargarDireccionEnvio();
            enviarCorreoClave();
        }
    }
    private void ingresarDireccionEnvio()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        _xmlDatos.DocumentElement.SetAttribute("Id_Clientes", id);
        _xmlDatos.DocumentElement.SetAttribute("Direccion", txtdireccionenvio.Text);
        _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefonoenvio.Text);
        _xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincia.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue);
        _xmlDatos.DocumentElement.SetAttribute("ContactoNombre", txtNombrecontacto.Text);

        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_ingresa_cliente_direccion(_xmlDatos.OuterXml))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al ingresar dirección de envio');", true);
        }
        else
        {
            limpiarDireccion();
            cargarDireccionEnvio();
            enviarCorreoClave();
        }
    }
    private void limpiarDireccion()
    {
        txttelefonoenvio.Text = "";
        txtdireccionenvio.Text = "";
        Label3.Text = "";
    }
    private void cargarPais()
    {
        try
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _pais = _consulta.Com21_consulta_pais();
            if (_pais.Tables[1].Rows.Count > 0)
            {
                ddlpais.Items.Clear();
                ddlpais.DataSource = _pais.Tables[1];
                ddlpais.DataTextField = "Pais";
                ddlpais.DataValueField = "Id_Pais";
                ddlpais.DataBind();
            }
            else
            {
                ddlpais.Items.Clear();
                ddlpais.Items.Insert(0, "Sin Paises");
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void cargarProvincia()
    {
        try
        {
            string pais = ddlpais.SelectedValue;
            if (pais != "Sin Paises")
            {
                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                DataSet _provincias = _consulta.Com21_consulta_provincias_idpais(int.Parse(pais));
                if (_provincias.Tables[0].Rows.Count > 0)
                {
                    ddlprovincia.Items.Clear();
                    ddlprovincia.DataSource = _provincias.Tables[0];
                    ddlprovincia.DataTextField = "Provincia";
                    ddlprovincia.DataValueField = "Id_Provincia";
                    ddlprovincia.DataBind();
                }
                else
                {
                    ddlprovincia.Items.Clear();
                    ddlprovincia.Items.Insert(0, "Sin Provincias");
                }
            }
            else
            {
                ddlprovincia.Items.Clear();
                ddlprovincia.Items.Insert(0, "Sin Provincias");
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void cargarCiudad()
    {
        try
        {
            string provincias = ddlprovincia.SelectedValue;
            if (provincias != "Sin Provincias")
            {
                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(provincias));
                if (_provincias.Tables[0].Rows.Count > 0)
                {
                    ddlciudad.Items.Clear();
                    ddlciudad.DataSource = _provincias.Tables[0];
                    ddlciudad.DataTextField = "Ciudad";
                    ddlciudad.DataValueField = "Id_Ciudad";
                    ddlciudad.DataBind();
                }
                else
                {
                    ddlciudad.Items.Clear();
                    ddlciudad.Items.Insert(0, "Sin Ciudades");
                }
            }
            else
            {
                ddlciudad.Items.Clear();
                ddlciudad.Items.Insert(0, "Sin Ciudades");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlpais_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincia();
        cargarCiudad();
    }
    protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarCiudad();
    }
    private void enviarCorreoClave()
    {

        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(txtcorreo.Text);
        objMail.Subject = "Cambio de Clave";
        objMail.Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title></head><body>" +
        "<div style=\"width: 500px;margin-right: auto; margin-left: auto;\"><table style=\"border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;\"><tr><td style=\"background-position: center top; padding: 5px; text-align: left; background-image: url('http://designsie.com/images/imagen_registro1.png'); background-repeat: no-repeat; font-weight: bold;\">" +
        "<table style=\"width: 100%;\"><tr><td width=\"50%\"><a href=\"http://designsie.com/\" target=\"_blank\"><img alt=\"\" src=\"http://designsie.com/images/logocom21icon.png\" width=\"120\" /></a></td><td width=\"50%\" style=\"text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;\">CAMBIO DE DIRECCIÓN</td>" +
        "</tr></table></td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">&nbsp;</td></tr><tr><td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;\">Estimado(a)</td></tr><tr><td style=\"padding: 5px 5px 15px 5px\">" + txtnombres + " " + txtapellidos.Text + "</td></tr><tr>" +
        "<td style=\"padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Su dirección de envio ha sido cambiada correctamente.</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">" + direccion.InnerHtml.ToString() + "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;\">Para iniciar sesión de click en el link:&nbsp;&nbsp;<a href=\"http://designsie.com/iniciar.aspx\" target=\"_blank\">Iniciar Sesión</a>" +
        "</td></tr><tr><td style=\"padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif; text-align: center;\"><a href=\"http://designsie.com/\" target=\"_blank\">www.com21.com.ec</a></td></tr><tr style=\"background-color: #E2E2E2;\"><td style=\"padding: 10px; font-weight: bold; font-size: 16px; font-family: Arial, Helvetica, sans-serif; text-align: right; color: #ABCD43;\">Contacto:&nbsp;&nbsp;&nbsp;<span style=\"font-size: 14px; color: #000000\">Tel:(+593) 42-300539</span></td>" +
        "</tr></table></div></body></html>";

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
    #endregion
}
