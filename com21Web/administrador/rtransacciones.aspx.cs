using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class administrador_rtransacciones : System.Web.UI.Page
{
    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarRTransacciones();
        }
    }
    private void cargarRTransacciones()
    {
        DataSet _cat = _consulta.Com21_consulta_ResportesInicialTrans();
        if (_cat.Tables[0].Rows.Count > 0)
        {
            pSi.Visible = true;
            pNo.Visible = false;
            GvRTransacccion.DataSource = _cat.Tables[0];
            GvRTransacccion.DataBind();
        }
        else
        {
            pSi.Visible = false;
            pNo.Visible = true;
            GvRTransacccion.EmptyDataText = "No exiten transacciones";
        }
    }
    protected void IBUsuario_Click(object sender, ImageClickEventArgs e)
    {
        if (txtusuario.Text.Length > 0)
        {
            idBuscar.Value = "4";
            cargarIBUsuario();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Digite el usuario para la busqueda');", true);
        }
    }
    private void cargarIBUsuario()
    {
            string _ddl = txtusuario.Text;
            DataSet _cant = _consulta.Com21_consulta_ResportesFechaTrans(txtusuario.Text, "0", int.Parse(idBuscar.Value));
            if (_cant.Tables[0].Rows.Count > 0)
            {
                GvRTransacccion.DataSource = _cant.Tables[0];
                GvRTransacccion.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exite transacciones para el usuario: "+ txtusuario.Text +"');", true);
                txtusuario.Text = string.Empty;
            }
    }
    #region "Eventos del GridView"
    protected void GvRTransacccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvRTransacccion.PageIndex = e.NewPageIndex;
        try
        {
            if (idBuscar.Value == "0")
            {
                cargarRTransacciones();
            }
            if (idBuscar.Value == "3")
            {
                cargarIBFechas();
            }
            if (idBuscar.Value == "4")
            {
                cargarIBUsuario();
            }
        }
        catch { }
    }
    protected void GvRTransacccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow _gv = this.GvRTransacccion.SelectedRow;
        HiddenField _idt = default(HiddenField);
        HiddenField _idu = default(HiddenField);
        HiddenField _codUp = default(HiddenField);
        LinkButton _idt2 = default(LinkButton);


        _idt = (HiddenField)_gv.FindControl("IdTransaccion");
        _idu = (HiddenField)_gv.FindControl("IdUsuario");
        _codUp = (HiddenField)_gv.FindControl("CodUpdate");
        _idt2 = (LinkButton)_gv.FindControl("lbtransaccion");
        
        Response.Redirect("Detalletransaccion.aspx?IDT=" + _idt2.Text + "&IDU=" + _idu.Value + "&CODUP=" + _codUp.Value);
    }
    #endregion
    protected void IBFechas_Click(object sender, ImageClickEventArgs e)
    {
        if ((txtfechaini.Text.Length > 0) && (txtfechafi.Text.Length > 0))
        {
            DateTime _ini = Convert.ToDateTime(txtfechaini.Text);
            DateTime _fin = Convert.ToDateTime(txtfechafi.Text);

            if (_ini <= _fin)
            {
                idBuscar.Value = "3";
                cargarIBFechas();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('La fecha final es menor a la fecha de inicio');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Para realiar la busqueda por fecha primero debe seleccionarlas');", true);
        }
    }
    private void cargarIBFechas()
    {
        
            DataSet _cat = _consulta.Com21_consulta_ResportesFechaTrans(txtfechaini.Text, txtfechafi.Text,int.Parse(idBuscar.Value));
            if (_cat.Tables[0].Rows.Count > 0)
            {
                GvRTransacccion.DataSource = _cat.Tables[0];
                GvRTransacccion.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('No exite transacciones para el rango de fecha: "+ txtfechaini.Text +" - " + txtfechafi.Text + "');", true);
                txtfechafi.Text = string.Empty;
                txtfechaini.Text = string.Empty;
            }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        txtfechafi.Text = "";
        txtfechaini.Text = "";
        txtusuario.Text = "";
        idBuscar.Value = "0";
        cargarRTransacciones();
    }
}