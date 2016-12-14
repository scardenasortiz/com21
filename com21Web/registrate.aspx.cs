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

public partial class registrate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            cargarprovincias();
            cargarciudad();
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                
                Response.Redirect("Default.aspx");
            }
            
        }
    }
    protected void btncrearcuenta_Click(object sender, EventArgs e)
    {
        try
        {
            String mensajesInfo = string.Empty;
            String val = string.Empty;
            int i = ValidaDatos();
            if (i == 1)
            {
                val = ValidacionesCampos();
                if (String.IsNullOrEmpty(val))
                    ingresarCliente();
                else
                {
                    pMensajesAlertas.Visible = true;
                    DMensaje.Attributes.Add("class", "error");
                    DMensaje.InnerText = val;
                }
            }
            else
            {
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Todos los campos son obligatorios";
            }
        }
        catch (Exception ex)
        {
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("class", "error");
            DMensaje.InnerText = ex.Message;
        }
    }
    private String ValidacionesCampos()
    {
        String infoMen = string.Empty;
        String val = string.Empty;
        if (!email_bien_escrito(this.txtcorreo.Text))
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: correo inválido";
            else
                infoMen = infoMen + ", correo inválido";
        }
        val = validarCedula(txtcedula.Text);
        if ((txtcedula.Text.Length < 10) || ((String.IsNullOrEmpty(val)) && (!val.Equals("verdadero"))))
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: cédula incorrecta";
            else
                infoMen = infoMen + ", cédula incorrecta";
        }
        if ((txtclave.Text.Length > 12) && (txtclave.Text.Length < 6))
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: clave minimo 6 máximo 12";
            else
                infoMen = infoMen + ", clave minimo 6 máximo 12";
            
        }
        if (txtcelular.Text.Length < 10)
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: dígite un celular válido";
            else
                infoMen = infoMen + ", dígite un celular válido";

        }
        if (txttelefono.Text.Length < 9)
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: dígite un teléfono válido";
            else
                infoMen = infoMen + ", dígite un teléfono válido";

        }
        int j = consultarCorreo();
        if (j == 1)
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: correo dígitado ya pertenece a una cuenta";
            else
                infoMen = infoMen + ", correo dígitado ya pertenece a una cuenta";
        }

        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_valida_user(txtus.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (String.IsNullOrEmpty(infoMen))
                infoMen = "Error: usuario no disponible";
            else
                infoMen = infoMen + ", usuario no disponible";
        }

        return infoMen;
    }
    #region "Validar Cédula"
    public string validarCedula(String cedula)
    {
        string estado;

        // Verifica que tenga 10 dígitos y que contenga solo valores numéricos
        Regex r;
        r = new Regex("^[0-9]{10}$");

        if (!((cedula.Length == 10) && r.IsMatch(cedula)))
        {
            estado = "falso";
            return estado;
        }

        // Verifica que los dos primeros dígitos correspondan a un valor entre 1 y NUMERO_DE_PROVINCIAS
        int prov = Convert.ToInt32(cedula.Substring(0, 2));

        if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS)))
        {
            estado = "falso";
            return estado;
        }

        // Verifica que el último dígito de la cédula sea válido
        int[] d = new int[10];

        // Asignamos el string a un array
        for (int i = 0; i < d.Length; i++)
        {
            d[i] = int.Parse(cedula[i] + "");
        }

        int imp = 0;
        int par = 0;

        // Sumamos los duplos de posición impar
        for (int i = 0; i < d.Length; i += 2)
        {
            d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
            imp += d[i];
        }

        // Sumamos los digitos de posición par
        for (int i = 1; i < (d.Length - 1); i += 2)
        {
            par += d[i];
        }

        // Sumamos los dos resultados
        int suma = imp + par;

        // Restamos de la decena superior
        string s = Convert.ToString(suma + 10);
        int d10 = int.Parse(s.Substring(0, 1) + "0") - suma;

        // Si es diez el décimo dígito es cero        
        d10 = (d10 == 10) ? 0 : d10;

        // Si el décimo dígito calculado es igual al digitado la cédula es correcta
        if (d10 == d[9])
        {
            estado = "verdadero";
            return estado;
        }
        else
        {
            estado = "falso";
            return estado;
        }
    }
    public static int NUMERO_DE_PROVINCIAS = 24;
    #endregion
    private int consultarCorreo()
    {
        int i = 0;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _correo = _consulta.Com21_consulta_cliente_correo_clave(txtcorreo.Text);
        if (_correo.Tables[0].Rows.Count > 0)
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        return i;
    }
    private int ValidaDatos()
    {
        int i = 1;
        if(txtnombres.Text.Length == 0)
        {
            i = 0;
        }
        if (txtapellidos.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        if (txttelefono.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcelular.Text.Length == 0)
        {
            i = 0;
        }
        if (txtdireccion.Text.Length == 0)
        {
            i = 0;
        }
        if (txtus.Text.Length == 0)
        {
            i = 0;
        }
        if (txtclave.Text.Length == 0)
        {
            i = 0;
        }
        if (txtconfirmar.Text.Length == 0)
        {
            i = 0;
        }
        if (this.txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        string id = ddlprovincia.SelectedValue.ToString();
        if (int.Parse(id) == 0)
        {
            i = 0;
        }
        string ids = ddlciudad.SelectedValue.ToString();
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
    private void ingresarCliente()
    {
        //,,,,,,,Direccion,Telefono,Celular,CopiaClave)
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Clientes/>");
        _xmlDatos.DocumentElement.SetAttribute("Nombres", txtnombres.Text);
        _xmlDatos.DocumentElement.SetAttribute("Apellidos", txtapellidos.Text);
        _xmlDatos.DocumentElement.SetAttribute("Usuario", txtus.Text);
        String _clave = classMD5.encriptaClave(txtclave.Text);
        _xmlDatos.DocumentElement.SetAttribute("Clave", _clave);
        _xmlDatos.DocumentElement.SetAttribute("CopiaClave", txtclave.Text);
        _xmlDatos.DocumentElement.SetAttribute("Correo", txtcorreo.Text);
        _xmlDatos.DocumentElement.SetAttribute("Id_Sexo", ddlsexo.SelectedValue.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Sexo", ddlsexo.SelectedItem.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Direccion", txtdireccion.Text);
        _xmlDatos.DocumentElement.SetAttribute("Telefono", txttelefono.Text);
        _xmlDatos.DocumentElement.SetAttribute("Celular", txtcelular.Text);
        _xmlDatos.DocumentElement.SetAttribute("Id_Pais", "1");
        _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincia.SelectedValue.ToString());
        _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue.ToString());
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
        if (_administrador.Com21_ingresa_cliente(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
            enviarcorreo();
            cookiesSesion(_clave);
            limpiar();
        }
    }
    private void enviarcorreo()
    {
        MailMessage objMail = new MailMessage();
        objMail.IsBodyHtml = true;
        objMail.From = new MailAddress("info@com21.com.ec");

        objMail.To.Add(txtcorreo.Text);
        objMail.Subject = "Registro de Usuario";
        objMail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head runat='server'><title>Com21 S.A ::. Registro de Usuario</title></head><body><div style='width: 500px;margin-right: auto; margin-left: auto;'>"+
                       "<table style='border: 1px solid #ABCD43; width: 500px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;'><tr><td style='background-position: center top; padding: 5px; text-align: left; background-image: url(http://designsie.com/images/imagen_registro1.png); background-repeat: no-repeat; font-weight: bold;'>" +
                       "<table style='width: 100%;'><tr><td width='50%'><a href='http://designsie.com/' target='_blank'><img alt='' src='http://designsie.com/images/logocom21icon.png' width='120' /></a></td><td width='50%' style='text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold; padding-right: 10px;'>NUEVO CLIENTE</td>"+
                       "</tr></table></td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>&nbsp;</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>Estimado(a)</td></tr><tr><td style='padding: 5px 5px 15px 5px'>" + txtnombres.Text + " " + txtapellidos.Text + "</td>"+
                       "</tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 14px; font-family: Arial, Helvetica, sans-serif;'>¡Bienvenido(a) a Com21!</td></tr><tr><td style='padding: 5px 5px 15px 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>Los datos ingresados son:</td></tr><tr><td style='padding: 5px; font-weight: bold; font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>"+
                       "<table style='width:100%;'><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Usuario:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtus.Text + "</td>"+
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Correo:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcorreo.Text + "</td>"+
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Télefono:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txttelefono.Text + "</td>"+
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Celular:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtcelular.Text + "</td>"+
                       "</tr><tr><td style='width: 15%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; font-size: 13px;'>Dirección:</td><td style='width: 90%; vertical-align: top; padding-top: 1px; padding-bottom: 1px; padding-left: 2px; font-size: 14px; font-family: arial, Helvetica, sans-serif; font-weight: normal;'>" + txtdireccion.Text + "</td>"+
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

       // objSMTPClient.Send(objMail);
    }
    private void cookiesSesion(String clave)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_valida_cliente(txtus.Text, clave);
        HttpCookie aCookieIdCom21 = new HttpCookie("IdCom21Web");
        HttpCookie aCookieUserCom21 = new HttpCookie("UserCom21Web");
        HttpCookie aCookiePassCom21 = new HttpCookie("PassCom21Web");
        HttpCookie aCookieEmailCom21 = new HttpCookie("EmailCom21Web");
       /* HttpCookie aCookieUdPre = new HttpCookie("CodUpdatePre");
        HttpCookie aCookieFormaP = new HttpCookie("FormaP");
        HttpCookie aCookieActE = new HttpCookie("ActE");
        HttpCookie aCookieT = new HttpCookie("T");*/

        if (_user.Tables[0].Rows.Count > 0)
        {
            classRandom _rand = new classRandom();
            String _cod = _rand.NextString(11, true, true, true, false);

            foreach (DataRow r in _user.Tables[0].Rows)
            {
                aCookieIdCom21.Value = r["Id_Clientes"].ToString();
                Response.Cookies.Add(aCookieIdCom21);

                aCookieUserCom21.Value = txtus.Text;
                Response.Cookies.Add(aCookieUserCom21);


                aCookiePassCom21.Value = txtclave.Text;
                Response.Cookies.Add(aCookiePassCom21);

                aCookieEmailCom21.Value = txtcorreo.Text;
                Response.Cookies.Add(aCookieEmailCom21);

                /*aCookieUdPre.Value = _cod;
                Response.Cookies.Add(aCookieUdPre);

                aCookieFormaP.Value = "0";//transferencia
                Response.Cookies.Add(aCookieFormaP);

                aCookieActE.Value = "0";
                Response.Cookies.Add(aCookieActE);

                aCookieT.Value = "0";
                Response.Cookies.Add(aCookieT);*/
                IngresoDatosCompra(_cod, int.Parse(r["Id_Clientes"] + ""));
            }
            Response.Redirect("Default.aspx");
        }
    }
    private void IngresoDatosCompra(String _cod, int idusuario)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_ingresa_cliente_DatosCompra(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
        }
        else
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
        }
    }
    private void limpiar()
    {
        txtapellidos.Text = "";
        txtcelular.Text = "";
        txtclave.Text = "";
        txtconfirmar.Text = "";
        txtcorreo.Text = "";
        txtdireccion.Text = "";
        txtnombres.Text = "";
        txttelefono.Text = "";
        txtus.Text = "";
        lblvalida.Text = "";
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
    protected void txtus_Changed(object sender, EventArgs e)
    {
        if (txtus.Text != "")
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet ds = _consulta.Com21_consulta_valida_user(txtus.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["em"] = "0";
                Span1.InnerText = "Usuario no disponible";
                Span1.Attributes.Add("class", "Aviso");
                txtus.Focus();
            }
            else
            {

                Session["em"] = "1";
                Span1.InnerText = "Usuario Disponible";
                Span1.Attributes.Add("class", "AvisoVerde");
                txtclave.Focus();
            }
        }
        else
        {
            Span1.InnerText = "";
            txtus.Focus();
        }
    }
    protected void ddlprovincias_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlprovincia.SelectedValue.ToString();
        if (int.Parse(id) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlciudad.DataSource = _provincias.Tables[0];
                ddlciudad.DataTextField = "Ciudad";
                ddlciudad.DataValueField = "Id_Ciudad";
                ddlciudad.DataBind();
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
    private void cargarprovincias()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_provincias();
        if (_provincias.Tables[2].Rows.Count > 0)
        {
            ddlprovincia.DataSource = _provincias.Tables[2];
            ddlprovincia.DataTextField = "Provincia";
            ddlprovincia.DataValueField = "Id_Provincia";
            ddlprovincia.DataBind();
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen provincias";
            _ddl.Value = "0";
            ddlprovincia.Items.Clear();

            ddlprovincia.Items.Add(_ddl);
            ddlprovincia.DataBind();
        }
    }
    private void cargarciudad()
    {
        string id = ddlprovincia.SelectedValue.ToString();
        if (id != "0")
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlciudad.DataSource = _provincias.Tables[0];
                ddlciudad.DataTextField = "Ciudad";
                ddlciudad.DataValueField = "Id_Ciudad";
                ddlciudad.DataBind();
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
}