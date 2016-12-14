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

public partial class editainfo : System.Web.UI.Page
{
    public String[] DataC;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                ConsultaDataCompra(int.Parse(Request.Cookies["IdCom21Web"].Value));
                cargarPais();
                cargarProvincia();
                cargarCiudad();
                cargarDireccionEnvio();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    #region "Ingresa, Edita, Consultar, Validar, Limpiar - DIRECCION DE ENVIO"
    private void cargarDireccionEnvio()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
        if (_direccion.Tables[0].Rows.Count > 0)
        {
            hfIdentDire.Value = "1";
            foreach (DataRow r in _direccion.Tables[0].Rows)
            {
                direccion.InnerHtml = "Dirección: " + r["Direccion"].ToString() + ", Teléfono: " + r["Telefono"].ToString() + " Lugar de envio: " + r["Pais"].ToString() + "/" + r["Provincia"].ToString() + "/" + r["Ciudad"].ToString() + " Nombre: " + r["ContactoNombre"].ToString();
                hfIdDire.Value = r[0].ToString();
                hfId1.Value = r["Id_Pais"].ToString();
                hfId2.Value = r["Id_Provincia"].ToString();
                hfId3.Value = r["Id_Ciudad"].ToString();
            }
        }
        else
        {
            hfIdentDire.Value = "0";
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
    private void cargarProvincia()
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
    private void cargarCiudad()
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
    protected void ddlpais_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincia();
        cargarCiudad();
    }
    protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarCiudad();
    }
    #endregion
    protected void btnsiguiente_Click(object sender, EventArgs e)
    {
        int i = ValidadatosN();
        if (i == 1)
        {
            if (rbTrans.Checked == true)
            {
                if (txttransferencia.Text.Length > 0)
                {
                    if (cbaplicar.Checked == true)
                    {
                        if (hfIdentDire.Value == "1")
                        {
                            lblcampos.Text = "";
                            registrarCambios();
                            
                        }
                        else
                        {
                            Label3.Text = "Debe ingresar una dirección de envio si activo la casilla";
                        }
                    }
                    else
                    {
                        Label3.Text = "";
                        lblcampos.Text = "";
                        registrarCambios();
                        
                    }
                }
                else
                {
                    lblcampos.Text = "Debe ingresar el numero de transferencia";
                }
            }
            else
            {
                if (cbaplicar.Checked == true)
                {
                    if (hfIdentDire.Value == "1")
                    {
                        lblcampos.Text = "";
                        registrarCambios();
                    }
                    else
                    {
                        Label3.Text = "Debe ingresar una dirección de envio si activo la casilla";
                    }
                }
                else
                {
                    Label3.Text = "";
                    lblcampos.Text = "";
                    registrarCambios();
                }
            }
        }
        else
        {
            if (cbaplicar.Checked == true)
            {
                if (hfIdentDire.Value == "0")
                {
                    Label3.Text = "Debe ingresar una dirección de envio si activo la casilla";
                }
                else
                {
                    Label3.Text = "";
                }
            }
            else
            {
                if (hfIdentDire.Value == "0")
                {
                    Label3.Text = "Debe ingresar una dirección de envio si desea que su compra llegue a un domicilio, oficina, etc";
                }
                else
                {
                    Label3.Text = "";
                }
            }
            lblcampos.Text = "Debe ingresar todos los campos para la factura y tipo de pago";
        }
    }
    private int ValidadatosN()
    {
        int i = 1;
        if (txtrucci.Text.Length == 0)
        {
            i = 0;
        }
        if (txtdireccionfact.Text.Length == 0)
        {
            i = 0;
        }
        if (txtnombreFact.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcontactofact.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void ConsultaDataCompra(int id)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_cliente_DatosCompra(id,1);
        String data = "";
        foreach(DataRow r in ds.Tables[0].Rows)
        {
            //idusuario+T+ActE+FormaP+CodUpdatePre
            data = r[1] + "" + "|" + r[2] + "" + "|" + r[3] + "" + "|" + r[4] + "" + "|" + r[5] + "";
        }
        ViewState["DataCompra"] = data;
    }
    private void registrarCambios()
    {
        String FP, Act = "";
        String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            if (DataC.Length > 0)
            {
                //if(Request.Cookies["CodUpdatePre"] != null)
                //{
                string _codUP = DataC[4]+"";
                XmlDocument _xmlDatos = new XmlDocument();
                _xmlDatos.LoadXml("<Prefactura/>");
                _xmlDatos.DocumentElement.SetAttribute("RucCiFact", txtrucci.Text);
                _xmlDatos.DocumentElement.SetAttribute("NombreFact", txtnombreFact.Text);
                _xmlDatos.DocumentElement.SetAttribute("DireccionFact", txtdireccionfact.Text);
                _xmlDatos.DocumentElement.SetAttribute("TelefonoFact", txtcontactofact.Text);

                if (rbTrans.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("TransAutori", txttransferencia.Text);
                    _xmlDatos.DocumentElement.SetAttribute("FormaPago", "1");
                    FP = "1";
                    //Response.Cookies["FormaP"].Value = "1";
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("TransAutori", "0");
                    _xmlDatos.DocumentElement.SetAttribute("FormaPago", "2");
                    FP = "2";
                    //Response.Cookies["FormaP"].Value = "2";
                }

                if (cbaplicar.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("ActCosto", "1");
                    Act = "1";
                    //Response.Cookies["ActE"].Value = "1";

                    DataSet _ds = cargarIdDireccion();
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in _ds.Tables[0].Rows)
                        {
                            _xmlDatos.DocumentElement.SetAttribute("PaisEnvio", r["Id_Pais"].ToString());
                            _xmlDatos.DocumentElement.SetAttribute("ProvinciaEnvio", r["Id_Provincia"].ToString());
                            _xmlDatos.DocumentElement.SetAttribute("CiudadEnvio", r["Id_Ciudad"].ToString());
                            _xmlDatos.DocumentElement.SetAttribute("TelefonoEnvio", r["Telefono"].ToString());
                            _xmlDatos.DocumentElement.SetAttribute("DireccionEnvio", r["Direccion"].ToString());
                            _xmlDatos.DocumentElement.SetAttribute("ContactoEnvio", r["ContactoNombre"].ToString());
                        }
                    }
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("ActCosto", "0");
                    _xmlDatos.DocumentElement.SetAttribute("PaisEnvio", "0");
                    _xmlDatos.DocumentElement.SetAttribute("ProvinciaEnvio", "0");
                    _xmlDatos.DocumentElement.SetAttribute("CiudadEnvio", "0");
                    _xmlDatos.DocumentElement.SetAttribute("TelefonoEnvio", "0");
                    _xmlDatos.DocumentElement.SetAttribute("DireccionEnvio", "0");
                    //Response.Cookies["ActE"].Value = "0";
                    Act = "0";
                }

                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                if (_consulta.proc_edita_prefacturado_producto_DatosUsuario_CodUpdate(_xmlDatos.OuterXml, _codUP))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al actualizar.');", true);
                }
                else
                {
                    ActualizarDataCompra(DataC[1]+"",FP,DataC[4]+"",Act);
                    Response.Redirect("carrito.aspx");
                }
                //}
            }
    }
    private void ActualizarDataCompra(string T, string FormaP, string CodUpdatePre, string ActE)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", Request.Cookies["IdCom21Web"].Value);
        _xmlDatos.DocumentElement.SetAttribute("T", T);
        _xmlDatos.DocumentElement.SetAttribute("FormaP", FormaP);
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", CodUpdatePre);
        _xmlDatos.DocumentElement.SetAttribute("ActE", ActE);
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml,int.Parse(Request.Cookies["IdCom21Web"].Value)))
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
    }
    private DataSet cargarIdDireccion()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
        return _direccion;
    }
    private void consultarCosto()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
    }
    protected void rbPaypal_CheckedChanged(object sender, EventArgs e)
    {
        pTrans.Visible = false;
    }
    protected void rbTrans_CheckedChanged(object sender, EventArgs e)
    {
        pTrans.Visible = true;
    }
}
