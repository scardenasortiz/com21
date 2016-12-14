using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_provincia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarprovincias();
            cargarpais();
        }
    }
    private void cargarprovincias()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_provincias();
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvProvincia.DataSource = _provincias.Tables[0];
            GvProvincia.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
        
    }
    protected void GvProvincia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvProvincia.PageIndex = e.NewPageIndex;
        try
        {
            if (txtbuscarprovincias.Text.Length > 0)
            {
                txtbuscarprovincias.Text = hfletra.Value;
                consultaletra(txtbuscarprovincias.Text);
            }
            else
            {
                cargarprovincias();
            }
        }
        catch { }
    }
    protected void GvProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvProvincia.SelectedRow;
            string Id_Provincia = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Provincia");
            Id_Provincia = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_provincias_id(int.Parse(Id_Provincia));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.IDP.Value = dr[0].ToString();
                    Session["IDP"] = dr[0].ToString();
                    this.txtprovincia.Text = dr[1].ToString();
                    this.ddlpais.SelectedValue = dr[2].ToString();
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
    protected void GvProvincia_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdProvincias = GvProvincia.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_provincias(int.Parse(IdProvincias)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
                elimina_Ciudades_Costos(IdProvincias);
            }
            cargarprovincias();
            
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
            ingresoprovincias();
        }
    }
    private int validadatos()
    {
        int pro = 0;
        if (txtprovincia.Text.Length > 0)
        {
            pro = 1;
        }
        return pro;
    }
    private void ingresoprovincias()
    {
        try
        {
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Provincias/>");
            DataSet dsPro = _administrador.Com21_consulta_provincias_letra(txtprovincia.Text.ToUpper(),int.Parse(ddlpais.SelectedValue),2);
            if (dsPro.Tables[0].Rows.Count == 0)
            {
                _xmlDatos.DocumentElement.SetAttribute("Provincia", txtprovincia.Text.ToUpper());
                _xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);

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
                if (ddlpais.SelectedValue != "0")
                {
                    if (_administrador.Com21_ingresa_provincias(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
                    cargarprovincias();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar registro, no existen paises');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Provincia existente');", true);
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
        txtprovincia.Text = "";
        cbactivar.Checked = false;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editaprovincias();
        }
    }
    private void editaprovincias()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Provincias/>");
            _xmlDatos.DocumentElement.SetAttribute("Provincia", txtprovincia.Text.ToUpper());
            _xmlDatos.DocumentElement.SetAttribute("Id_Pais", ddlpais.SelectedValue);

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
            if (IDP.Value != "")
            {
                if (ddlpais.SelectedValue != "0")
                {
                    if (_administrador.Com21_edita_provincias(_xmlDatos.OuterXml, int.Parse(IDP.Value)))
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
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro, no existen paises');", true);
                }
            }
            else
            {
                int idp = int.Parse(Session["IDP"].ToString());
                if (ddlpais.SelectedValue != "0")
                {
                    if (_administrador.Com21_edita_provincias(_xmlDatos.OuterXml, idp))
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
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar registro, no existen paises');", true);
                }
            }
            cargarprovincias();
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
    private void elimina_Ciudades_Costos(String IdProvincias)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_ciudad_idprovincia(int.Parse(IdProvincias));
        if (_consulta.Com21_elimina_provincias_Ciudades(int.Parse(IdProvincias)))
        {
            
        }
        else
        {
            foreach (DataRow r in _provincias.Tables[0].Rows)
            {
                if (_consulta.Com21_elimina_ciudad_costo(int.Parse(r["Id_Ciudad"].ToString())))
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad y Costo Eliminados');", true);
                }
            }
        }
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_provincias_letra(letra,int.Parse(ddlpais.SelectedValue),1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvProvincia.DataSource = _letras.Tables[0];
            GvProvincia.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias para la busqueda: " + letra + "');", true);
        }
    }
    #endregion

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarprovincias.Text.Length > 0)
        {
            string letra = txtbuscarprovincias.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarprovincias();
        }
    }
    protected void txtbuscarprovincias_TextChanged(object sender, EventArgs e)
    {
        if (txtbuscarprovincias.Text.Length > 0)
        {
            string letra = txtbuscarprovincias.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarprovincias();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarprovincias.Text = "";
        cargarprovincias();
    }
}