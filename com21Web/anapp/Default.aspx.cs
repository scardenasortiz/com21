using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using com21DLL;
using System.Text.RegularExpressions;
using OpenNETCF;
using System.Runtime.InteropServices;
using OpenNETCF.Tapi;


public partial class anapp_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getIMEIInfo();
            String Estado = Request.QueryString["Estado"];
            if ((Request.Cookies["IdCom21App"] != null) && (Request.Cookies["UserCom21App"] != null) && (Request.Cookies["PassCom21App"] != null) && (Request.Cookies["EmailCom21App"] != null))
            {
                Response.Redirect("usuario.aspx");
            }
            else
            {
                if (Estado != null)
                {
                    PresentarMensaje(Estado);
                }
            }
        }
    }
    private void getIMEIInfo()
    {
        try
        {
           /* string IMEI;
            Tapi t = new Tapi();
            t.Initialize();
            Line _line = t.CreateLine(0, LINEMEDIAMODE.INTERACTIVEVOICE, LINECALLPRIVILEGE.MONITOR);

            byte[] buffer = new byte[512];
            //write size
            BitConverter.GetBytes(512).CopyTo(buffer, 0);

            if (CellTSP.lineGetGeneralInfo(_line.hLine, buffer) != 0)
            {
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error(), "TAPI Error: " + System.Runtime.InteropServices.Marshal.GetLastWin32Error().ToString("X"));
            }

            int serialsize = BitConverter.ToInt32(buffer, 36);
            int serialoffset = BitConverter.ToInt32(buffer, 40);
            IMEI = System.Text.Encoding.Unicode.GetString(buffer, serialoffset, serialsize);
            IMEI = IMEI.Substring(0, IMEI.IndexOf(Convert.ToChar(0)));
            txtnombre.Text = IMEI;
            // AppSettings.SetIMEI(IMEI);
            _line.Dispose();
            t.Shutdown();*/
            
            
            

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }


    private void limpiar()
    {
        txtclave.Text = "";
        txtnombre.Text = "";
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        int i = validaringreso();
        if (i == 1)
        {
            //lblnologin.Visible = false;
            validaDatos();
        }
        else
        {
            limpiar();
            Resdireccionar(2);
        }
    }
    private int validaringreso()
    {
        int i = 1;
        if (txtclave.Text.Length == 0)
        {
            i = 0;
        }
        if (txtnombre.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void validaDatos()
    {
        try
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            String _clave = classMD5.encriptaClave(txtclave.Text);
            DataSet _user = _consulta.Com21_consulta_valida_cliente(txtnombre.Text, _clave);
            if (_user.Tables[0].Rows.Count > 0)
            {
                classRandom _rand = new classRandom();
                String _cod = _rand.NextString(11, true, true, true, false);
                //lblnologin.Visible = false;
                foreach (DataRow r in _user.Tables[0].Rows)
                {
                    HttpCookie aCookieIdCom21 = new HttpCookie("IdCom21App");
                    HttpCookie aCookieUserCom21 = new HttpCookie("UserCom21App");
                    HttpCookie aCookiePassCom21 = new HttpCookie("PassCom21App");
                    HttpCookie aCookieEmailCom21 = new HttpCookie("EmailCom21App");

                    aCookieIdCom21.Value = r["Id_Clientes"].ToString();
                    Response.Cookies.Add(aCookieIdCom21);

                    aCookieUserCom21.Value = txtnombre.Text;
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

                    Response.Redirect("default.aspx");
                }



            }
            else
            {
                limpiar();
                Resdireccionar(1);
            }
        }
        catch (Exception ex)
        {
        }
    }
    #region "Datos para realizar compras"
    private int ConsultaDatosCompra(int idusuario)
    {
        int dcompras = 0;
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet ds = _administrador.Com21_consulta_cliente_DatosCompra(idusuario,2);
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
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "2");
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
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "2");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, idusuario))
        { }
        else
        { }
    }
    #endregion
    private void PresentarMensaje(string E)
    {
        if (E == "1")
        {
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("class", "error");
            DMensaje.InnerText = "Usuario o Contraseña incorrectos";
        }
        else
        {
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("class", "error");
            DMensaje.InnerText = "Por favor ingrese todos los campos";
        }
    }
    private void Resdireccionar(int ident)
    {
        string url = string.Empty;
        String Estado = Request.QueryString["Estado"];
        if (Estado != null)
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            url = array[0];
        }
        else
        {
            url = Request.Url.AbsoluteUri;
        }
        if (ident == 1)
        {
            url = url + "?Estado=1";
        }
        else
        {
            url = url + "?Estado=2";
        }
        Response.Redirect(url,false);
    }
    protected void lbclave_Click(object sender, EventArgs e)
    {
        Response.Redirect("recuperar.aspx",false);
    }
    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        Response.Redirect("registro.aspx", false);
    }
}