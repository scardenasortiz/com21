using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class administrador_inventario : System.Web.UI.Page
{
    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarRInventario();
            cargarCategorias();
        }
    }
    private void cargarRInventario()
    {
        DataSet _cat = _consulta.Com21_consulta_inventario_productos();
        if (_cat.Tables[0].Rows.Count > 0)
        {
            pSi.Visible = true;
            pNo.Visible = false;
            GvRProductos.DataSource = _cat.Tables[0];
            GvRProductos.DataBind();
        }
        else
        {
            pSi.Visible = false;
            pNo.Visible = true;
        }

    }
    private void cargarCategorias()
    {
        DataSet _cat = _consulta.Com21_consulta_categoria();
        if (_cat.Tables[1].Rows.Count > 0)
        {
            //ddlCategorias.DataSource = _cat.Tables[1];
            //ddlCategorias.DataTextField = "Categoria";
            //ddlCategorias.DataValueField = "Id_Categoria";
            //ddlCategorias.DataBind();
        }
    }
    private void cargarMarcas()
    {
        DataSet _pre = _consulta.Com21_consulta_marca();
        if (_pre.Tables[1].Rows.Count > 0)
        {
            //ddlMarca.DataSource = _pre.Tables[1];
            //ddlMarca.DataTextField = "Marca";
            //ddlMarca.DataValueField = "Id_Marca";
            //ddlMarca.DataBind();
        }
    }
    protected void IBProducto_Click(object sender, ImageClickEventArgs e)
    {
        if (txtproducto.Text.Length > 0)
        {
            idBuscar.Value = "3";
            cargarIBProducto();
        }
        else
        {
            idBuscar.Value = "0";
        }
    }
    private void cargarIBProducto()
    {
            string _ddl = txtproducto.Text;
            DataSet _cant = _consulta.Com21_consulta_inventario_productos_nombre(_ddl);
            if (_cant.Tables[0].Rows.Count > 0)
            {
                GvRProductos.DataSource = _cant.Tables[0];
                GvRProductos.DataBind();
            }
    }
    #region "Eventos del GridView"
    protected void GvRProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvRProductos.PageIndex = e.NewPageIndex;
        try
        {
            if (idBuscar.Value == "0")
            {
                cargarRInventario();
            }
            if (idBuscar.Value == "3")
            {
                cargarIBProducto();
            }
        }
        catch { }
    }
    protected void GvRProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GvRProductos.SelectedRow;
        HiddenField codIven = default(HiddenField);
        HiddenField cod = default(HiddenField);
        codIven = (HiddenField)row.FindControl("Id_Inventario");
        cod = (HiddenField)row.FindControl("Id_Producto");
        Response.Redirect("Detalleinventario.aspx?Invet=" + codIven.Value + "&Prod=" + cod.Value);
    }
    #endregion
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        txtproducto.Text = "";
        cargarRInventario();
        idBuscar.Value = "0";
    }
}