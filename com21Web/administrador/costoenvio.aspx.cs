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
            cargarcosto();
            cargarpais();
            cargarprovincias();
            cargarciudad();
            Consulta_Empresa();
        }
    }
    private void cargarcosto()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _costo = _consulta.Com21_consulta_costo();
        if (_costo.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvCosto.DataSource = _costo.Tables[0];
            GvCosto.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    private void Consulta_Empresa()
    {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet _empresa = _administrador.Com21_consulta_empresa();
            if (_empresa.Tables[3].Rows.Count > 0)
            {
                ddlsucursal.DataSource = _empresa.Tables[3];
                ddlsucursal.DataTextField = "Empresa";
                ddlsucursal.DataValueField = "Id_Empresa";
                ddlsucursal.DataBind();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen sucursales";
                _ddl.Value = "0";
                ddlsucursal.Items.Clear();

                ddlsucursal.Items.Add(_ddl);
                ddlsucursal.DataBind();
            }
    }
    private void cargarpais()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_pais();
        if (_provincias.Tables[1].Rows.Count > 0)
        {
            ddlpais.DataSource = _provincias.Tables[1];
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
    protected void GvCosto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCosto.PageIndex = e.NewPageIndex;
        try
        {
            cargarcosto();
        }
        catch { }
    }
    protected void GvCosto_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvCosto.SelectedRow;
            string Id_Costo = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Costo");
            Id_Costo = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_costo_id(int.Parse(Id_Costo));
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdcosto.Value = dr[0].ToString();
                    Session["hfIdcosto"] = dr[0].ToString();
                    this.txtcosto.Text = dr[1].ToString();
                    cargarpais();
                    ddlpais.SelectedValue = dr[5].ToString();
                    cargarprovincias();
                    this.ddlprovincia.SelectedValue = dr[4].ToString();
                    cargarciudad();
                    this.ddlciudad.SelectedValue = dr[2].ToString();
                    hfidciudad.Value = dr[2].ToString();
                    Session["hfIdciudad"] = dr[2].ToString();
                    Consulta_Empresa();
                    ddlsucursal.SelectedValue = dr[3].ToString();
                    if (Convert.ToBoolean(dr["Activar"].ToString()) == true)
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
    protected void GvCosto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdCiudades = GvCosto.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_costo(int.Parse(IdCiudades)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Costo de envio eliminado');", true);
            }
            cargarcosto();
            
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
            ingresocosto();
        }
    }
    private int validadatos()
    {
        int pro = 1;
        if (txtcosto.Text.Length == 0)
        {
            pro = 0;
        }
        return pro;
    }
    private void ingresocosto()
    {
        try
        {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
           
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Costo/>");
            _xmlDatos.DocumentElement.SetAttribute("Costo", txtcosto.Text.Replace(",","."));
            String ciudad = ddlciudad.SelectedValue;
            _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue);
            String provincia = ddlprovincia.SelectedValue;
            _xmlDatos.DocumentElement.SetAttribute("Id_Empresa", ddlsucursal.SelectedValue);
            String sucrusal = ddlsucursal.SelectedValue;
                if (cbactivar.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
                }
            
            
                XmlDocument _xmlResultado = new XmlDocument();
            
                if ((ciudad != "0") && (provincia != "0") && (ddlpais.SelectedValue != "0") && (ddlsucursal.SelectedValue != "0"))
                {
                    DataSet _validar = _administrador.Com21_consulta_valida_costo_existente_ciudadId(int.Parse(ciudad),int.Parse(sucrusal));
                    if (_validar.Tables[0].Rows.Count == 0)
                    {
                        if (_administrador.Com21_ingresa_costo(_xmlDatos.OuterXml))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con exito');", true);
                        }
                        cargarcosto();
                        Limpiar();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('El costo para la ciudad seleccionada ya existe');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccion una provincia y ciudad existente');", true);
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
        txtcosto.Text = "";
        cbactivar.Checked = false;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editacosto();
        }
    }
    private void editacosto()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Costo/>");
            _xmlDatos.DocumentElement.SetAttribute("Costo", txtcosto.Text.Replace(",", "."));
            String ciudad = ddlciudad.SelectedValue;
            _xmlDatos.DocumentElement.SetAttribute("Id_Ciudad", ddlciudad.SelectedValue);
            String provincia = ddlprovincia.SelectedValue;
            _xmlDatos.DocumentElement.SetAttribute("Id_Empresa", ddlsucursal.SelectedValue);

            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (hfIdcosto.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if ((ciudad != "0") && (provincia != "0") && (ddlpais.SelectedValue != "0") && (ddlsucursal.SelectedValue != "0"))
                {
                    if (hfidciudad.Value == ciudad)
                    {

                        if (_administrador.Com21_edita_costo(_xmlDatos.OuterXml, int.Parse(hfIdcosto.Value)))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con exito');", true);
                            btninsert.Visible = true;
                            btnedit.Visible = false;
                            Limpiar();
                        }
                    }
                    else
                    {
                        DataSet _validar = _administrador.Com21_consulta_valida_costo_existente_ciudadId(int.Parse(ciudad), int.Parse(ddlsucursal.SelectedValue));
                        if (_validar.Tables[0].Rows.Count == 0)
                        {
                            if (_administrador.Com21_edita_costo(_xmlDatos.OuterXml, int.Parse(hfIdcosto.Value)))
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con exito');", true);
                                btninsert.Visible = true;
                                btnedit.Visible = false;
                                Limpiar();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('El costo para la ciudad seleccionada ya existe');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccion una provincia y ciudad existente');", true);
                }
            }
            else
            {
                int idciuadad = int.Parse(Session["hfIdcosto"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if ((ciudad != "0") && (provincia != "0") && (ddlpais.SelectedValue != "0") && (ddlsucursal.SelectedValue != "0"))
                {
                    if (Session["hfIdciudad"].ToString() == ciudad)
                    {

                        if (_administrador.Com21_edita_costo(_xmlDatos.OuterXml, idciuadad))
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con exito');", true);
                                btninsert.Visible = true;
                                btnedit.Visible = false;
                                Limpiar();
                            }
                    }
                    else
                    {
                        DataSet _validar = _administrador.Com21_consulta_valida_costo_existente_ciudadId(int.Parse(ciudad), int.Parse(ddlsucursal.SelectedValue));
                        if (_validar.Tables[0].Rows.Count == 0)
                        {
                            if (_administrador.Com21_edita_costo(_xmlDatos.OuterXml, idciuadad))
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con exito');", true);
                                btninsert.Visible = true;
                                btnedit.Visible = false;
                                Limpiar();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('El costo para la ciudad seleccionada ya existe');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccion una provincia y ciudad existente');", true);
                }
            }
            cargarcosto();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
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
    private void cargarprovincias()
    {
        string id = ddlpais.SelectedValue.ToString();
        if (id != "0")
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_provincias_idpais(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlprovincia.DataSource = _provincias.Tables[0];
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
            Consulta_Empresa();
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
    protected void ddlpais_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddlpais.SelectedValue.ToString();
        if (int.Parse(id) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _provincias = _consulta.Com21_consulta_provincias_idpais(int.Parse(id));
            if (_provincias.Tables[0].Rows.Count > 0)
            {
                ddlprovincia.DataSource = _provincias.Tables[0];
                ddlprovincia.DataTextField = "Provincia";
                ddlprovincia.DataValueField = "Id_Provincia";
                ddlprovincia.DataBind();

                cargarciudad();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen provincias";
                _ddl.Value = "0";
                ddlprovincia.Items.Clear();

                ddlprovincia.Items.Add(_ddl);
                ddlprovincia.DataBind();

                cargarciudad();
            }
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen provincias";
            _ddl.Value = "0";
            ddlprovincia.Items.Clear();

            ddlprovincia.Items.Add(_ddl);
            ddlprovincia.DataBind();

            cargarciudad();
        }
    }
    protected void ddlciudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string id = ddlprovincia.SelectedValue.ToString();
        //if (int.Parse(id) != 0)
        //{
        //}
        //else
        //{
        //    ListItem _ddl = new ListItem();
        //    _ddl.Text = "No existen sucursales";
        //    _ddl.Value = "0";
        //    ddlsucursal.Items.Clear();

        //    ddlsucursal.Items.Add(_ddl);
        //    ddlsucursal.DataBind();

        //    cargarciudad();
        //}
    }
}