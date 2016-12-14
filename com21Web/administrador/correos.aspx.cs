using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_correos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarInbox();
            cargarOutbox();
        }
    }
    #region "Correos Entrantes"
    private void cargarInbox()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_inbox_outbox();
        if (_categoria.Tables[0].Rows.Count > 0)
        {
            pSBE.Visible = true;
            pNBE.Visible = false;
            GvCorreoE.DataSource = _categoria.Tables[0];
            GvCorreoE.DataBind();

            GridView row = this.GvCorreoE;
            HiddenField _leido = default(HiddenField);
            ImageButton _lei = default(ImageButton);
            foreach (GridViewRow r in row.Rows)
            {
                _leido = (HiddenField)r.FindControl("Leido");
                _lei = (ImageButton)r.FindControl("VerEditar");

                if (_leido.Value == "2")
                {
                    _lei.ImageUrl = "~/images/64_email.png";
                }
                else
                {
                    _lei.ImageUrl = "~/images/64_email2.png";
                }
            }
        }
        else
        {
            pSBE.Visible = false;
            pNBE.Visible = true;
        }

    }

    protected void GvCorreoE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCorreoE.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletraBE.Value != "")
            {
                consultaletraInbox(hfletraBE.Value);
            }
            else
            {
                cargarInbox();
            }
        }
        catch { }
    }
    protected void GvCorreoE_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvCorreoE.SelectedRow;
            string Id_InOut = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_InOut");
            Id_InOut = cod.Value;
            Response.Redirect("correosesp.aspx?IdInOut=" + cod.Value);
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvCorreoE_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Id_InOut = GvCorreoE.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_eliminar_inbox_outbox(int.Parse(Id_InOut)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
               // elimina_costo(int.Parse(IdCategorias));
            }
            cargarInbox();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }

    #region "BUSCAR POR LETRA"
    private void consultaletraInbox(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_categoria_letra(letra,2);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvCorreoE.DataSource = _letras.Tables[0];
            GvCorreoE.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias con la letra: " + letra + "');", true);
        }
    }
    #endregion

    #region "EVENTOS DE IMAGEN Y REFRESCAR CORREOS ENTRANTES"
    //protected void imgCE_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtbuscarinbox.Text.Length > 0)
    //    {
    //        string letra = txtbuscarinbox.Text;
    //        hfletraBE.Value = letra;
    //        consultaletraInbox(letra);
    //    }
    //    else
    //    {
    //        cargarInbox();
    //    }
    //}
    protected void refreshCE_Click(object sender, ImageClickEventArgs e)
    {
        hfletraBE.Value = "";
        //txtbuscarinbox.Text = "";
        cargarInbox();
    }
    #endregion
    #endregion
    #region "Correos Salientes"
    private void cargarOutbox()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_inbox_outbox();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            pSBS.Visible = true;
            pNBS.Visible = false;
            GvCorreoS.DataSource = _categoria.Tables[1];
            GvCorreoS.DataBind();
        }
        else
        {
            pSBS.Visible = false;
            pNBS.Visible = true;
        }

    }

    protected void GvCorreoS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCorreoS.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletraBS.Value != "")
            {
                consultaletraOutbox(hfletraBS.Value);
            }
            else
            {
                cargarInbox();
            }
        }
        catch { }
    }
    protected void GvCorreoS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvCorreoS.SelectedRow;
            string Id_InOut = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_InOut");
            Id_InOut = cod.Value;
            
                Response.Redirect("correosesp.aspx?IdInOut=" + cod.Value);
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvCorreoS_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Id_InOut = GvCorreoS.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_eliminar_inbox_outbox(int.Parse(Id_InOut)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
                // elimina_costo(int.Parse(IdCategorias));
            }
            cargarOutbox();

        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }

    #region "BUSCAR POR LETRA"
    private void consultaletraOutbox(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_categoria_letra(letra,2);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvCorreoS.DataSource = _letras.Tables[0];
            GvCorreoS.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias con la letra: " + letra + "');", true);
        }
    }
    #endregion
    #region "EVENTOS DE IMAGEN Y REFRESCAR CORREOS SALIENTES"
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtbuscaroutbox.Text.Length > 0)
    //    {
    //        string letra = txtbuscaroutbox.Text;
    //        hfletraBS.Value = letra;
    //        consultaletraOutbox(letra);
    //    }
    //    else
    //    {
    //        cargarOutbox();
    //    }
    //}
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletraBS.Value = "";
        //txtbuscaroutbox.Text = "";
        cargarOutbox();
    }
    #endregion
    #endregion
}