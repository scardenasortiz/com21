using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using com21DLL;
using System.Data;

public partial class administrador_pais : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Consulta_Paises();
        }
    }
    private void Consulta_Paises()
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet _consulta_pais = _administrador.Com21_consulta_pais();
        if (_consulta_pais.Tables[0].Rows.Count > 0)
        {
            pSi.Visible = true;
            pNo.Visible = false;
            GvPais.DataSource = _consulta_pais.Tables[0];
            GvPais.DataBind();
        }
        else
        {
            pSi.Visible = false;
            pNo.Visible = true;
        }
    }
    protected void GvPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPais.PageIndex = e.NewPageIndex;
        try
        {
            if (txtbuscarpais.Text.Length > 0)
            {
                string letra = hfletra.Value;
                txtbuscarpais.Text = letra;
                consultaletra(letra);
            }
            else
            {
                Consulta_Paises();
            }
        }
        catch { }
    }
    protected void GvPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = GvPais.SelectedRow;
            string IdPais = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Pais");
            IdPais = cod.Value;
            ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
            DataSet ds = _usuario.Com21_consulta_pais_id(int.Parse(IdPais));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdPais.Value = dr[0].ToString();
                    Session["hfIdPais"] = dr[0].ToString();
                    txtpais.Text = dr[1].ToString();
                    if (Convert.ToBoolean(dr[2].ToString()) == true)
                    {
                        cbpais.Checked = true;
                    }
                    else
                    {
                        cbpais.Checked = false;
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
    protected void GvPais_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            String IdPais = GvPais.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
            if (_usuario.Com21_elimina_pais(int.Parse(IdPais)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
                DataSet _provincias = _usuario.Com21_consulta_provincias_idpais(int.Parse(IdPais));
                if (_usuario.Com21_elimina_provincia_pais(int.Parse(IdPais)))
                { }
                else
                {
                    if (_provincias.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in _provincias.Tables[0].Rows)
                        {
                            DataSet _ciudad = _usuario.Com21_consulta_ciudad_idprovincia(int.Parse(r["Id_Provincia"].ToString()));
                            if (_usuario.Com21_elimina_provincias_Ciudades(int.Parse(r["Id_Provincia"].ToString())))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
                            }
                            else
                            {
                                if (_ciudad.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow rci in _ciudad.Tables[0].Rows)
                                    {
                                        if (_usuario.Com21_elimina_ciudad_costo(int.Parse(rci["Id_Ciudad"].ToString())))
                                        {
                                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Consulta_Paises();
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
        txtpais.Text = "";
        cbpais.Checked = false;
    }
    private int validadatos()
    {
        int j = 1;
        if (txtpais.Text.Length == 0)
        {
            j = 0;
        }
        return j;
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int j = validadatos();
        if (j == 1)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Pais/>");
            ServicioCom21.ServicioCom21 _Administrador = new ServicioCom21.ServicioCom21();
            DataSet dsPaisExistente = _Administrador.Com21_consulta_pais_letra(txtpais.Text,2);
            if (dsPaisExistente.Tables[0].Rows.Count == 0)
            {
                _xmlDatos.DocumentElement.SetAttribute("Pais", txtpais.Text.ToUpper());
                if (cbpais.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("Aplicar", "1");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Aplicar", "0");
                }


                if (_Administrador.Com21_ingresa_pais(_xmlDatos.OuterXml))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                }
                limpiar();
                Consulta_Paises();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('País existente');", true);
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int j = validadatos();
        if (j == 1)
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Pais/>");
            _xmlDatos.DocumentElement.SetAttribute("Pais", txtpais.Text.ToUpper());
            if (cbpais.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Aplicar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Aplicar", "0");
            }

            ServicioCom21.ServicioCom21 _Administrador = new ServicioCom21.ServicioCom21();
            if (hfIdPais.Value.Length > 0)
            {
                if (_Administrador.Com21_edita_pais(_xmlDatos.OuterXml, int.Parse(hfIdPais.Value)))
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
                Consulta_Paises();
            }
            else
            {
                string idpais = Session["hfIdPais"].ToString();
                if (_Administrador.Com21_edita_pais(_xmlDatos.OuterXml, int.Parse(idpais)))
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
                Consulta_Paises();
            }
            
        }
    }
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_pais_letra(letra,1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvPais.DataSource = _letras.Tables[0];
            GvPais.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen paises para la busqueda: " + letra + "');", true);
        }
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarpais.Text.Length > 0)
        {
            string letra = txtbuscarpais.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            Consulta_Paises();
        }
    }
    protected void txtbuscarpais_TextChanged(object sender, EventArgs e)
    {
        if (txtbuscarpais.Text.Length > 0)
        {
            string letra = txtbuscarpais.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            Consulta_Paises();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarpais.Text = "";
        Consulta_Paises();
    }
}