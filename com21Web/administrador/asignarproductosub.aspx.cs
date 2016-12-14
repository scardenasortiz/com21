using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_asignarproductosub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarproductos();
            cargarcategoria();
            cargarsubcategoria();
        }
    }
    #region "Productos"
    private void cargarproductos()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _items = _consulta.Com21_consulta_productos_sub_categoria();
        if (_items.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            GvItems.DataSource = _items.Tables[0];
            GvItems.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }
    }
    protected void GvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvItems.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletras.Value != "")
            {
                consultaletras(hfletras.Value);
            }
            else
            {
                cargarproductos();
            }
        }
        catch { }
    }
    protected void GvItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvItems.SelectedRow;
            string Id_producto = "";
            HiddenField cod = default(HiddenField);
            HiddenField mar = default(HiddenField);
            Label tit = default(Label);
            cod = (HiddenField)row.FindControl("Id_Producto");
            mar = (HiddenField)row.FindControl("Id_Marca");
            tit = (Label)row.FindControl("Titulo");
            Id_producto = cod.Value;
                    //seteo todos los valores de la consulta especifica
            this.hfIdproducto.Value = cod.Value;
            Session["hfIdproducto"] = cod.Value;
            this.lblproducto.Text = tit.Text;
            hfIdmarca.Value = mar.Value;
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void consultaletras(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_productos_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvItems.DataSource = _letras.Tables[0];
            GvItems.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen productos para la busqueda: " + letra + "');", true);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarproducto.Text.Length > 0)
        {
            string letra = txtbuscarproducto.Text;
            hfletras.Value = letra;
            consultaletras(letra);
        }
        else
        {
            cargarproductos();
        }
    }
    protected void refreshs_Click(object sender, ImageClickEventArgs e)
    {
        hfletras.Value = "";
        txtbuscarproducto.Text = "";
        cargarproductos();
    }
    #endregion
    protected void btninsert_Click(object sender, EventArgs e)
    {
            asignarsubcategoria();
    }
    private void asignarsubcategoria()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Productos/>");
            if ((ddlcategorias.SelectedValue != "0") && (ddlsubcategoria.SelectedValue != "0"))
            {
                if (lblproducto.Text != "**Sin producto seleccionado**")
                {
                    _xmlDatos.DocumentElement.SetAttribute("Id_Categoria", ddlcategorias.SelectedValue);
                    _xmlDatos.DocumentElement.SetAttribute("Id_SubCategoria", ddlsubcategoria.SelectedValue);
                    if (hfIdmarca.Value == "0")
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Estado", "2");
                    }
                    else
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Estado", "1");
                    }

                    ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
                    XmlDocument _xmlResultado = new XmlDocument();

                    if (_administrador.Com21_edita_productos_sub_categoria(_xmlDatos.OuterXml, int.Parse(hfIdproducto.Value)))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al asignar');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Asignación correcta');", true);
                        limpiar();
                        cargarproductos();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione un producto');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no exiten categorias o sub-categorias');", true);
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
        lblproducto.Text = "**Sin producto seleccionado**";
        hfIdproducto.Value = "";
    }
    #region "SUB-CATEGORIA"
    private void cargarcategoria()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_categoria();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            ddlcategorias.DataSource = _categoria.Tables[1];
            ddlcategorias.DataTextField = "Categoria";
            ddlcategorias.DataValueField = "Id_Categoria";
            ddlcategorias.DataBind();
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen categorias";
            _ddl.Value = "0";
            ddlcategorias.Items.Clear();

            ddlcategorias.Items.Add(_ddl);
            ddlcategorias.DataBind();
        }
    }
    private void cargarsubcategoria()
    {
        string ddlc = ddlcategorias.SelectedValue;
        if (int.Parse(ddlc) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _scategoria = _consulta.Com21_consulta_scategoria_id(int.Parse(ddlc));
            if (_scategoria.Tables[1].Rows.Count > 0)
            {
                ddlsubcategoria.DataSource = _scategoria.Tables[1];
                ddlsubcategoria.DataTextField = "Titulo";
                ddlsubcategoria.DataValueField = "Id_SubCategoria";
                ddlsubcategoria.DataBind();
            }
            else
            {
                ListItem _ddl = new ListItem();
                _ddl.Text = "No existen sub-categorias";
                _ddl.Value = "0";
                ddlsubcategoria.Items.Clear();

                ddlsubcategoria.Items.Add(_ddl);
                ddlsubcategoria.DataBind();
            }
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen sub-categorias";
            _ddl.Value = "0";
            ddlsubcategoria.Items.Clear();

            ddlsubcategoria.Items.Add(_ddl);
            ddlsubcategoria.DataBind();

            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No exiten categorias, por ingrese.');", true);
        }

    }
    protected void ddlcategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarsubcategoria();
    }
    #endregion
}
