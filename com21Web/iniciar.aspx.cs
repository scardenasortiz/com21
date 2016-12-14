using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using com21DLL;
using System.Xml;

public partial class iniciar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                Response.Redirect("Default.aspx");
            }
            
        }
    }
    //private void cargarnosotros()
    //{
    //    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    //    DataSet _nosotros = _consulta.Com21_consulta_nosotros();
    //    if (_nosotros.Tables[4].Rows.Count > 0)
    //    {
    //        foreach (DataRow r in _nosotros.Tables[4].Rows)
    //        {
    //            productos_web.InnerHtml = "<h2 class=\"desc grid-desc\" style=\"padding-left:20px; padding-right:20px\">" + r["Informacion"].ToString() + "</h2>";
    //        }
    //    }
    //}
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        int i = validaringreso();
        if (i == 1)
        {
            lblnologin.Visible = false;
            validaDatos();
        }
        else
        {
            limpiar();
            lblnologin.Visible = true;
            lblnologin.Text = "*Por favor ingrese todos los campos";
        }
    }
    private int validaringreso()
    {
        int i = 1;
        if (txtclave.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void validaDatos()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String _clave = classMD5.encriptaClave(txtclave.Text);
        DataSet _user = _consulta.Com21_consulta_valida_cliente(txtcorreo.Text, _clave);
        if (_user.Tables[0].Rows.Count > 0)
        {
            classRandom _rand = new classRandom();
            String _cod = _rand.NextString(11, true, true, true, false);
            lblnologin.Visible = false;
            foreach (DataRow r in _user.Tables[0].Rows)
            {
                HttpCookie aCookieIdCom21 = new HttpCookie("IdCom21Web");
                HttpCookie aCookieUserCom21 = new HttpCookie("UserCom21Web");
                HttpCookie aCookiePassCom21 = new HttpCookie("PassCom21Web");
                HttpCookie aCookieEmailCom21 = new HttpCookie("EmailCom21Web");
                /*HttpCookie aCookieUdPre = new HttpCookie("CodUpdatePre");
                HttpCookie aCookieFormaP = new HttpCookie("FormaP");
                HttpCookie aCookieActE = new HttpCookie("ActE");
                HttpCookie aCookieT = new HttpCookie("T");*/

                aCookieIdCom21.Value = r["Id_Clientes"].ToString();
                Response.Cookies.Add(aCookieIdCom21);

                aCookieUserCom21.Value = txtcorreo.Text;
                Response.Cookies.Add(aCookieUserCom21);


                aCookiePassCom21.Value = r["Clave"].ToString();
                Response.Cookies.Add(aCookiePassCom21);

                aCookieEmailCom21.Value = r["Correo"].ToString();
                Response.Cookies.Add(aCookieEmailCom21);

                
                /*aCookieUdPre.Value = _cod;
                Response.Cookies.Add(aCookieUdPre);

                aCookieFormaP.Value = "0";//transferencia
                Response.Cookies.Add(aCookieFormaP);

                aCookieActE.Value = "0";
                Response.Cookies.Add(aCookieActE);

                aCookieT.Value = "0";
                Response.Cookies.Add(aCookieT);*/
                int dcompras = ConsultaDatosCompra(int.Parse(r["Id_Clientes"] + ""));
                if (dcompras == 1)
                { EditarDatosCompra(_cod, int.Parse(r["Id_Clientes"] + "")); }
                else
                { IngresoDatosCompra(_cod, int.Parse(r["Id_Clientes"] + "")); }

                Response.Redirect("Default.aspx");
            }

            
            
        }
        else
        {
            limpiar();
            lblnologin.Visible = true;
            lblnologin.Text = "*Usuario o Clave incorrectos";
        }
    }
    #region "Datos para realizar compras"
    private int ConsultaDatosCompra(int idusuario)
    {
        int dcompras = 0;
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet ds = _administrador.Com21_consulta_cliente_DatosCompra(idusuario,1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dcompras = 1;
        }
        return dcompras;
    }
    private void IngresoDatosCompra(String _cod, int idusuario)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario+"");
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
    private void EditarDatosCompra(String _cod, int idusuario)
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
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, idusuario))
        { }
        else
        { }
    }
    #endregion
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
    protected void btncrearcuenta_Click(object sender, EventArgs e)
    {
        Response.Redirect("registrate.aspx");
    }
    private void limpiar()
    {
        txtclave.Text = "";
        txtcorreo.Text = "";
    }
}