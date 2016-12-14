using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_ciudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarciudad();
            cargarpais();
            cargarprovincias();
        }
    }
    private void cargarciudad()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ciudades = _consulta.Com21_consulta_ciudades();
        if (_ciudades.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvCiudad.DataSource = _ciudades.Tables[0];
            GvCiudad.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    protected void GvCiudad_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCiudad.PageIndex = e.NewPageIndex;
        try
        {
            if (txtbuscarciudades.Text.Length > 0)
            {
                txtbuscarciudades.Text = hfletra.Value;
                consultaletra(txtbuscarciudades.Text);
            }
            else
            {
                cargarciudad();
            }
        }
        catch { }
    }
    protected void GvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvCiudad.SelectedRow;
            string Id_Ciudad = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Ciudad");
            Id_Ciudad = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_ciudades_id(int.Parse(Id_Ciudad));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdciudad.Value = dr[0].ToString();
                    Session["hfIdciudad"] = dr[0].ToString();
                    this.txtciudad.Text = dr[1].ToString();
                    //this.ddlpais.SelectedValue = dr[3].ToString();
                    String idp = traerpaisid(dr[2].ToString());
                    cargarpais();
                    ddlpais.SelectedValue = idp;
                    this.ddlprovincias.SelectedValue = dr[2].ToString();
                    if (Convert.ToBoolean(dr[4].ToString()) == true)
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
    private string traerpaisid(String idpro)
    {
        string idp = "0";
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet _prop = _administrador.Com21_consulta_provincias_id(int.Parse(idpro));
        if (_prop.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _prop.Tables[0].Rows)
            {
                idp = r[2].ToString();
            }
        }
        return idp;
    }
    protected void GvCiudad_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            String IdCiudades = GvCiudad.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_ciudades(int.Parse(IdCiudades)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
                elimina_costo(int.Parse(IdCiudades));
            }
            cargarciudad();
            
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
        if (txtciudad.Text.Length > 0)
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
            if (txtciudad.Text.Length > 0)
            {
                DataSet ds = _administrador.Com21_consulta_ciudades_letra(txtciudad.Text.ToUpper(), int.Parse(ddlpais.SelectedValue), int.Parse(ddlprovincias.SelectedValue),2);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Ad_Ciudades/>");
                    _xmlDatos.DocumentElement.SetAttribute("Ciudad", txtciudad.Text.ToUpper());
                    _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincias.SelectedValue);
                    //_xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);
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
                    if (ddlprovincias.SelectedValue != "0")
                    {
                        if (_administrador.Com21_ingresa_ciudades(_xmlDatos.OuterXml))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con exito');", true);
                        }
                        txtbuscarciudades.Text = "";
                        cargarciudad();
                        Limpiar();
                    }
                    else
                    {
                        cargarciudad();
                        txtbuscarciudades.Text = "";
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar registro, no existe provincias para el país seleccionado');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad existente');", true);
                    txtciudad.Text = string.Empty;
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error técnico por favor espere unos minutos');", true);
        }
    }
    private void Limpiar()
    {
        txtciudad.Text = "";
        cbactivar.Checked = false;
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
            _xmlDatos.LoadXml("<Ad_Ciudades/>");
            _xmlDatos.DocumentElement.SetAttribute("Ciudad", txtciudad.Text.ToUpper());
            _xmlDatos.DocumentElement.SetAttribute("Id_Provincia", ddlprovincias.SelectedValue);
            //_xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (hfIdciudad.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (ddlprovincias.SelectedValue != "0")
                {
                    if (_administrador.Com21_edita_ciudades(_xmlDatos.OuterXml, int.Parse(hfIdciudad.Value)))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                        btninsert.Visible = true;
                        btnedit.Visible = false;
                        txtbuscarciudades.Text = "";
                    }
                }
                else
                {
                    txtbuscarciudades.Text = "";
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro, no existe provincias para el país seleccionado');", true);
                }
            }
            else
            {
                int idciuadad = int.Parse(Session["hfIdciudad"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if (ddlprovincias.SelectedValue != "0")
                {
                    if (_administrador.Com21_edita_ciudades(_xmlDatos.OuterXml, idciuadad))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                        btninsert.Visible = true;
                        btnedit.Visible = false;
                        txtbuscarciudades.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro, no existe provincias para el país seleccionado');", true);
                }
            }
            cargarciudad();
            Limpiar();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    
    private void cargarpais()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_pais();
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            ddlpais.DataSource = _provincias.Tables[0];
            ddlpais.DataTextField = "Pais";
            ddlpais.DataValueField = "Id_Pais";
            ddlpais.DataBind();
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen paises";
            _ddl.Value = "0";
            ddlpais.Items.Clear();

            ddlpais.Items.Add(_ddl);
            ddlpais.DataBind();
        }
    }
    private void cargarprovincias()
    {
        if (ddlpais.SelectedValue != "0")
        {
            int idpais = int.Parse(ddlpais.SelectedValue.ToString());
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _pro = _consulta.Com21_consulta_provincias_idpais(idpais);
            if (_pro.Tables[0].Rows.Count > 0)
            {
                ddlprovincias.DataSource = _pro.Tables[0];
                ddlprovincias.DataTextField = "Provincia";
                ddlprovincias.DataValueField = "Id_Provincia";
                ddlprovincias.DataBind();
            }
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen provincias";
            _ddl.Value = "0";
            ddlprovincias.Items.Clear();

            ddlprovincias.Items.Add(_ddl);
            ddlprovincias.DataBind();
        }
    }
    private void elimina_costo(int Id_Ciudad)
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_elimina_ciudad_costo(Id_Ciudad))
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad y Costo Eliminados');", true);
        }
    }

    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_ciudades_letra(letra, int.Parse(ddlpais.SelectedValue), int.Parse(ddlprovincias.SelectedValue), 1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvCiudad.DataSource = _letras.Tables[0];
            GvCiudad.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen ciudades con la busqueda: " + letra + "');", true);
        }
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarciudades.Text.Length > 0)
        {
            string letra = txtbuscarciudades.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarciudad();
        }
    }
    protected void txtbuscarciudades_TextChanged(object sender, EventArgs e)
    {
        if (txtbuscarciudades.Text.Length > 0)
        {
            string letra = txtbuscarciudades.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarciudad();
        }
    }
    protected void ddlpais_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlpais.SelectedValue.ToString();
        if (int.Parse(id) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_provincias_idpais(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlprovincias.DataSource = _provincias.Tables[0];
                ddlprovincias.DataTextField = "Provincia";
                ddlprovincias.DataValueField = "Id_Provincia";
                ddlprovincias.DataBind();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen provincias";
                _ddl.Value = "0";
                ddlprovincias.Items.Clear();

                ddlprovincias.Items.Add(_ddl);
                ddlprovincias.DataBind();
            }
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen provincias";
            _ddl.Value = "0";
            ddlprovincias.Items.Clear();

            ddlprovincias.Items.Add(_ddl);
            ddlprovincias.DataBind();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarciudades.Text = "";
        cargarciudad();
    }
}