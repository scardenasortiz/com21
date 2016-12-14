using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using com21DLL;
using System.Data;

public partial class administrador_empresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Consulta_Empresa();
            cargarprovincias();
            cargarciudad();
        }
    }
    private void Consulta_Empresa()
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet _empresa = _administrador.Com21_consulta_empresa();
        if (_empresa.Tables[0].Rows.Count > 0)
        {
            pSi.Visible = true;
            pNo.Visible = false;
            GvEmpresa.DataSource = _empresa.Tables[0];
            GvEmpresa.DataBind();
        }
        else
        {
            pSi.Visible = false;
            pNo.Visible = true;
        }
    }
    private int Consulta_EmpresaP()
    {
        int i = 0;
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet _empresa = _administrador.Com21_consulta_empresa();
        if (_empresa.Tables[2].Rows.Count > 0)
        {
            i = 1;
            foreach(DataRow r in _empresa.Tables[2].Rows)
            {
                hfIdEmpresaP.Value = r[0].ToString();
                Session["hfIdEmpresaP"] = r[0].ToString();
            }
        }
        return i;
    }
    private int consulta_Despacho(int despacho)
    {
        int i = 0;
        string idciudad = ddlciudad.SelectedValue.ToString();
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet _empresa = _administrador.Com21_consulta_empresa_idciudad(int.Parse(idciudad), despacho);
        if (_empresa.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _empresa.Tables[0].Rows)
            {
                i = int.Parse(r[0].ToString());
            }
        }
        return i;
    }
    protected void GvEmpresa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvEmpresa.PageIndex = e.NewPageIndex;
        try
        {
            if (txtbuscarempresa.Text.Length > 0)
            {
                string letra = hfletra.Value;
                txtbuscarempresa.Text = letra;
                consultaletra(letra);
            }
            else
            {
                Consulta_Empresa();
            }
        }
        catch { }
    }
    protected void GvEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = GvEmpresa.SelectedRow;
            string Id_Empresa = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Empresa");
            Id_Empresa = cod.Value;
            ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
            DataSet ds = _usuario.Com21_consulta_empresa_id(int.Parse(Id_Empresa));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdEmpresa.Value = dr[0].ToString();
                    Session["hfIdEmpresa"] = dr[0].ToString();
                    txtempresa.Text = dr[1].ToString();
                    if (Convert.ToBoolean(dr[2].ToString()) == true)
                    {
                        cbsucursal.Checked = true;
                    }
                    else
                    {
                        cbsucursal.Checked = false;
                    }
                    if (Convert.ToBoolean(dr[4].ToString()) == true)
                    {
                        cbsucursalp.Checked = true;
                    }
                    else
                    {
                        cbsucursalp.Checked = false;
                    }
                    if (dr["Despacho"].ToString() == "1")
                    {
                        cbdespacho.Checked = true;
                    }
                    else
                    {
                        cbdespacho.Checked = false;
                    }
                    cargarprovincias();
                    ddlprovincia.SelectedValue = dr["Id_Provincia"].ToString();
                    cargarciudad();
                    ddlciudad.SelectedValue = dr["Id_Ciudad"].ToString();
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
    protected void GvEmpresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdEmpresa = GvEmpresa.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
            if (_usuario.Com21_elimina_empresa(int.Parse(IdEmpresa)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
                if (_usuario.Com21_elimina_costo_idempresa(int.Parse(IdEmpresa)))
                {
                }
                else
                {
                }
                Consulta_Empresa();
            }
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    private void limpiar()
    {
        txtempresa.Text = "";
        cbsucursal.Checked = false;
        cbsucursalp.Checked = false;
        cbdespacho.Checked = false;
    }
    private int validadatos()
    {
        int j = 1;
        if (txtempresa.Text.Length == 0)
        {
            j = 0;
        }
        return j;
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int k = 0;
        int j = validadatos();
        if (j == 1)
        {
            ServicioCom21.ServicioCom21 _Administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Empresa/>");
            _xmlDatos.DocumentElement.SetAttribute("Empresa", txtempresa.Text);
            if (cbsucursal.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            if (cbsucursalp.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Principal", "1");
                k = Consulta_EmpresaP();
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Principal", "0");
            }
            _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincia.SelectedValue.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue.ToString());
            if (cbdespacho.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Despacho", "1");
                 int i = consulta_Despacho(1);
                 if (_Administrador.Com21_edita_empresa_despacho(i))
                 {
                 }
                 else
                 {
                 }
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Despacho", "0");
            }

            if ((ddlciudad.SelectedValue != "0") && (ddlprovincia.SelectedValue != "0"))
            {
                if (k != 1)
                {
                    if (_Administrador.Com21_ingresa_empresa(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
                    limpiar();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ya existe una sucursal como principal');", true);
                }
                Consulta_Empresa();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccion una provincia y ciudad existente');", true);
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _Administrador = new ServicioCom21.ServicioCom21();
        int k = 0;
        int j = validadatos();
        if (j == 1)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Empresa/>");
            _xmlDatos.DocumentElement.SetAttribute("Empresa", txtempresa.Text);
            if (cbsucursal.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            if (cbsucursalp.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Principal", "1");
                k = Consulta_EmpresaP();
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Principal", "0");
            }

            _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincia.SelectedValue.ToString());
            _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue.ToString());
            if (cbdespacho.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Despacho", "1");
                int i = consulta_Despacho(1);
                if (_Administrador.Com21_edita_empresa_despacho(i))
                {
                }
                else
                {
                }
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Despacho", "0");
            }
            if ((ddlciudad.SelectedValue != "0") && (ddlprovincia.SelectedValue != "0"))
            {
                if (hfIdEmpresa.Value.Length > 0)
                {
                    if (hfIdEmpresa.Value == hfIdEmpresaP.Value)
                    {
                        if (_Administrador.Com21_edita_empresa(_xmlDatos.OuterXml, int.Parse(hfIdEmpresa.Value)))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                            btnedit.Visible = false;
                            btninsert.Visible = true;
                            limpiar();
                        }
                        Consulta_Empresa();
                    }
                    else
                    {
                        if (k != 1)
                        {
                            if (_Administrador.Com21_edita_empresa(_xmlDatos.OuterXml, int.Parse(hfIdEmpresa.Value)))
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                                btnedit.Visible = false;
                                btninsert.Visible = true;
                                limpiar();
                            }
                            Consulta_Empresa();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ya existe una sucursal como principal');", true);
                        }
                    }

                }
                else
                {
                    string idempresa = Session["hfIdEmpresa"].ToString();
                    string idempresap = Session["hfIdEmpresaP"].ToString();
                    if (idempresa == idempresap)
                    {
                        if (_Administrador.Com21_edita_empresa(_xmlDatos.OuterXml, int.Parse(idempresa)))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                            btnedit.Visible = false;
                            btninsert.Visible = true;
                            limpiar();
                        }
                        Consulta_Empresa();
                    }
                    else
                    {
                        if (k != 1)
                        {
                            if (_Administrador.Com21_edita_empresa(_xmlDatos.OuterXml, int.Parse(hfIdEmpresa.Value)))
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                                btnedit.Visible = false;
                                btninsert.Visible = true;
                                limpiar();
                            }
                            Consulta_Empresa();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ya existe una sucursal como principal');", true);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccion una provincia y ciudad existente');", true);
            }
        }
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_empresa_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvEmpresa.DataSource = _letras.Tables[0];
            GvEmpresa.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen paises para la busqueda: " + letra + "');", true);
        }
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarempresa.Text.Length > 0)
        {
            string letra = txtbuscarempresa.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            Consulta_Empresa();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarempresa.Text = "";
        Consulta_Empresa();
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
    protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
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
}