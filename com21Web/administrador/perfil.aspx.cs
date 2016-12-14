using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com21DLL;
using System.Xml;
using System.Data;

public partial class administrador_perfil : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarAdministrador();
            cargarOpciones();
        }
    }
    private void cargarOpciones()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _opc = _consulta.Com21_consulta_perfil_opc(int.Parse(hfIdsadmin.Value));

        if (hfactivo.Value == "0")
        {
            if (_opc.Tables[0].Rows.Count > 0)
            {
                pMenu.Visible = true;
                pMenus.Visible = false;
                GvMenu.DataSource = _opc.Tables[0];
                GvMenu.DataBind();
                ViewState["Opc"] = _opc.Tables[0];
            }
            else
            {
                pMenu.Visible = false;
            }
        }
        else
        {
            if (_opc.Tables[1].Rows.Count > 0)
            {
                pMenus.Visible = true;
                pMenu.Visible = false;
                GvMenus.DataSource = _opc.Tables[1];
                GvMenus.DataBind();
                ViewState["Opc"] = _opc.Tables[1];
            }
            else
            {
                pMenus.Visible = false;
            }
        }
    }
    private void cargarAdministrador()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _scategoria = _consulta.Com21_consulta_administrador();
        if (_scategoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvAdmin.DataSource = _scategoria.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }

    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        
            ingresadministrador();
        
    }
    private void ingresadministrador()
    {
        try
        {

            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();

            GridView row = this.GvMenu;
            
            HiddenField cod = default(HiddenField);
            CheckBox _act = default(CheckBox);
            if (lbluser.Text != "**Sin administrador**")
            {
                foreach (GridViewRow r in row.Rows)
                {
                    cod = (HiddenField)r.FindControl("Id_Menu");
                    _act = (CheckBox)r.FindControl("Aplicar");

                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Ad_Perfil/>");
                    _xmlDatos.DocumentElement.SetAttribute("Id_Administrador", hfIdsadmin.Value);
                    _xmlDatos.DocumentElement.SetAttribute("Id_Menu", cod.Value);
                    if (_act.Checked == true)
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
                    }
                    else
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
                    }

                    if (_administrador.Com21_ingresa_perfil(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                        if (_administrador.Com21_activa_administrador(int.Parse(hfIdsadmin.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                        }
                        else
                        {

                        }

                    }
                }

                limpiar();
                cargarAdministrador();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccione un administrador');", true);
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void limpiar()
    {
        hfIdsadmin.Value = "";
        lbluser.Text = "**Sin administrador**";

        CheckBox _act = default(CheckBox);
        foreach (GridViewRow r in GvMenu.Rows)
        {
            _act = (CheckBox)r.FindControl("Aplicar");
            _act.Checked = false;
        }
        foreach (GridViewRow r in GvMenus.Rows)
        {
            _act = (CheckBox)r.FindControl("Aplicar");
            _act.Checked = false;
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        
            editaadministrador();
        
    }
    private void editaadministrador()
    {
        try
        {
            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Perfil/>");

            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();

            GridView row = this.GvMenus;
            
            HiddenField cod = default(HiddenField);
            HiddenField cods = default(HiddenField);
            CheckBox _act = default(CheckBox);
            if (lbluser.Text != "**Sin administrador**")
            {
                int i = ValidarRolSeleccionado(GvMenus);
                if (i > 0)
                {
                    foreach (GridViewRow r in row.Rows)
                    {
                        cods = (HiddenField)r.FindControl("Id_Perfil");
                        cod = (HiddenField)r.FindControl("Id_Menu");
                        _act = (CheckBox)r.FindControl("Aplicar");
                        _xmlDatos.DocumentElement.SetAttribute("Id_Administrador", hfIdsadmin.Value);
                        _xmlDatos.DocumentElement.SetAttribute("Id_Menu", cod.Value);
                        if (_act.Checked == true)
                        {
                            _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
                        }

                        if (_administrador.Com21_edita_perfil(_xmlDatos.OuterXml, int.Parse(cods.Value)))
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                            if (Session["admin-id"].ToString().Equals(hfIdsadmin.Value))
                            {
                                String _dominio = Request.Url.AbsoluteUri;
                                Response.Redirect(_dominio);
                            }

                        }
                    }
                }
                limpiar();
                cargarAdministrador();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Seleccione un administrador');", true);
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private int ValidarRolSeleccionado(GridView GMenus)
    {
        int i = 0;
        CheckBox _cbox = default(CheckBox);
        for (int j = 0; j < GMenus.Rows.Count; j++)
        {
            _cbox = (CheckBox)GMenus.Rows[j].FindControl("Aplicar");
            if (_cbox.Checked)
            {
                i = i + 1;
            }
        }

        if(i > 0)
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        return i;
    }
    #region "parat de GV"
    protected void GvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAdmin.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarAdministrador();
            }
        }
        catch { }
    }
    protected void GvAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvAdmin.SelectedRow;
            string Id_admin = "";
            HiddenField cod = default(HiddenField);
            Image _ruta = default(Image);
            Label _user = default(Label);
            CheckBox _act = default(CheckBox);

            cod = (HiddenField)row.FindControl("Id_Administrador");
            _ruta = (Image)row.FindControl("Imagen");
            _user = (Label)row.FindControl("Usuario");
            _act = (CheckBox)row.FindControl("Aplicar");

            Id_admin = cod.Value;
            hfIdsadmin.Value = cod.Value;
            lbluser.Text = _user.Text;
            if (_act.Checked == true)
            {
                hfactivo.Value = "1";
                btninsert.Visible = false;
                btnedit.Visible = true;
                cargarOpciones();
            }
            else
            {
                hfactivo.Value = "0";
                btninsert.Visible =  true;
                btnedit.Visible = false;
                cargarOpciones();
            }
            
            //puser.Visible = true;
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    #endregion
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_administrador_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvAdmin.DataSource = _letras.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen usuarios para la busqueda: " + letra + "');", true);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        hfletra.Value = "A";
        consultaletra("A");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        hfletra.Value = "B";
        consultaletra("B");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        hfletra.Value = "C";
        consultaletra("C");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        hfletra.Value = "D";
        consultaletra("D");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        hfletra.Value = "E";
        consultaletra("E");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        hfletra.Value = "F";
        consultaletra("F");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        hfletra.Value = "G";
        consultaletra("G");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        hfletra.Value = "H";
        consultaletra("H");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        hfletra.Value = "I";
        consultaletra("I");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        hfletra.Value = "J";
        consultaletra("J");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        hfletra.Value = "K";
        consultaletra("K");
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        hfletra.Value = "L";
        consultaletra("L");
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        hfletra.Value = "M";
        consultaletra("M");
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        hfletra.Value = "N";
        consultaletra("N");
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Ñ";
        consultaletra("Ñ");
    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        hfletra.Value = "O";
        consultaletra("O");
    }
    protected void LinkButton17_Click(object sender, EventArgs e)
    {
        hfletra.Value = "P";
        consultaletra("P");
    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Q";
        consultaletra("Q");
    }
    protected void LinkButton19_Click(object sender, EventArgs e)
    {
        hfletra.Value = "R";
        consultaletra("R");
    }
    protected void LinkButton27_Click(object sender, EventArgs e)
    {
        hfletra.Value = "S";
        consultaletra("S");
    }
    protected void LinkButton20_Click(object sender, EventArgs e)
    {
        hfletra.Value = "T";
        consultaletra("T");
    }
    protected void LinkButton21_Click(object sender, EventArgs e)
    {
        hfletra.Value = "U";
        consultaletra("U");
    }
    protected void LinkButton22_Click(object sender, EventArgs e)
    {
        hfletra.Value = "V";
        consultaletra("V");
    }
    protected void LinkButton23_Click(object sender, EventArgs e)
    {
        hfletra.Value = "W";
        consultaletra("W");
    }
    protected void LinkButton24_Click(object sender, EventArgs e)
    {
        hfletra.Value = "X";
        consultaletra("X");
    }
    protected void LinkButton25_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Y";
        consultaletra("Y");
    }
    protected void LinkButton26_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Z";
        consultaletra("Z");
    }
    protected void LinkButton28_Click(object sender, EventArgs e)
    {
        hfletra.Value = "";
        cargarAdministrador();
    }
    #endregion
    protected void cbasignaradmin_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)GvMenus.HeaderRow.FindControl("cbasignaradmin");
        if (chk.Checked)
        {
            for (int i = 0; i < GvMenus.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GvMenus.Rows[i].FindControl("Aplicar");
                chkrow.Checked = true;
            }

        }
        else
        {
            for (int i = 0; i < GvMenus.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GvMenus.Rows[i].FindControl("Aplicar");
                chkrow.Checked = false;
            }
        }
        /*GridView _opc = this.GvMenu;

        CheckBox _cb = default(CheckBox);
        
        if (hfactivo.Value == "0")
        {
            hfactivo.Value = "1";
            foreach (GridViewRow gr in _opc.Rows)
            {
                _cb = (CheckBox)gr.FindControl("Aplicar");

                _cb.Checked = true;
            }
        }
        else
        {
            hfactivo.Value = "0";
            foreach (GridViewRow gr in _opc.Rows)
            {
                _cb = (CheckBox)gr.FindControl("Aplicar");

                _cb.Checked = false;
            }
        }*/
    }
    protected void cbasignaradmins_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)GvMenu.HeaderRow.FindControl("cbasignaradmins");
        if (chk.Checked)
        {
            for (int i = 0; i < GvMenu.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GvMenu.Rows[i].FindControl("Aplicar");
                chkrow.Checked = true;
            }

        }
        else
        {
            for (int i = 0; i < GvMenu.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GvMenu.Rows[i].FindControl("Aplicar");
                chkrow.Checked = false;
            }
        }
    }
    protected void cbox()
    {
        GridView _opc = this.GvMenu;

        CheckBox _cb = default(CheckBox);

        foreach (GridViewRow gr in _opc.Rows)
        {
            _cb = (CheckBox)gr.FindControl("Menu");

            _cb.Checked = false;
        }

        CheckBox _cbox = default(CheckBox);
        _cbox = (CheckBox)_opc.FindControl("cbasignaradmin");
        _cbox.Checked = false;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscaradmin.Text.Length > 0)
        {
            string letra = txtbuscaradmin.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarAdministrador();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscaradmin.Text = "";
        cargarAdministrador();
    }
}