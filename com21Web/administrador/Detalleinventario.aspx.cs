using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class administrador_Detalleinventario : System.Web.UI.Page
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
        if ((Request.QueryString["Invet"] != null) && (Request.QueryString["Prod"] != null))
        {
            int _ivent = int.Parse(Request.QueryString["Invet"].ToString());
            int _prod = int.Parse(Request.QueryString["Prod"].ToString());
            DataSet _cat = _consulta.Com21_consulta_inventario_productos_id(_ivent, _prod);
            if (_cat.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in _cat.Tables[0].Rows)
                {
                    lblcantidadini.Text = r["Cantidad"].ToString();
                    lblprecionini.Text = r["Precio"].ToString().Replace(".", ",");
                    lbltitulo.Text = r["Titulo"].ToString();
                    lblmarca.Text = r["Marca"].ToString();
                    lblpreciocompra.Text = r["PrecioCompra"].ToString().Replace(".",",");
                    lblsubcategoria.Text = r["SubCategoria"].ToString();
                    lblCategoria.Text = r["Categoria"].ToString();
                    imgRuta.ImageUrl = r["Ruta"].ToString();
                }
            }
            if (_cat.Tables[1].Rows.Count > 0)
            {
                pInvetS.Visible = true;
                pInvetN.Visible = false;
                decimal _totalC = 0;
                decimal _totalV = 0;
                foreach (DataRow r in _cat.Tables[1].Rows)
                {
                    if (r["IdentificadorCV"].ToString() == "Compra")
                    {
                        _totalC = _totalC + decimal.Parse(r["Subtotal"].ToString());
                    }
                    if (r["IdentificadorCV"].ToString() == "Venta")
                    {
                        _totalV = _totalV + decimal.Parse(r["Subtotal"].ToString());
                    }
                }
                lbltotalC.Text = "$" + Convert.ToString(_totalC);
                lbltotalV.Text = "$" + Convert.ToString(_totalV);
                lbltotalCV.Text = "$" + Convert.ToString(_totalC - _totalV);

                GvRProductos.DataSource = _cat.Tables[1];
                GvRProductos.DataBind();
            }
            else
            {
                pInvetS.Visible = false;
                pInvetN.Visible = true;
            }
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
            idBuscar.Value = "3";
            cargarIBProducto();
    }
    private void cargarIBProducto()
    {
            string _ddl = ddlfiltrar.SelectedValue.ToString();
            string cod = Request.QueryString["Prod"].ToString();
            if (_ddl == "0")
            {

                DataSet _cant = _consulta.Com21_consulta_inventario_productos_CV(int.Parse(_ddl),int.Parse(cod));
                if (_cant.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _cant.Tables[0];
                    GvRProductos.DataBind();
                }
            }
            if (_ddl == "1")
            {
                DataSet _cant = _consulta.Com21_consulta_inventario_productos_CV(int.Parse(_ddl),int.Parse(cod));
                if (_cant.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _cant.Tables[0];
                    GvRProductos.DataBind();
                }
            }
            if (_ddl == "2")
            {
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error filtrar por compra o venta');", true);
                cargarRInventario();
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
    }
    #endregion
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        idBuscar.Value = "0";
        cargarRInventario();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("inventario.aspx");
    }
}