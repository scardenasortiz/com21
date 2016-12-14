using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_asignarproducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarmarca();
            cargarproductos();
        }
    }
    #region "Productos"
    private void cargarproductos()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _items = _consulta.Com21_consulta_productos_marca();
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
            HiddenField cod = default(HiddenField);
            HiddenField cat = default(HiddenField);
            HiddenField sub = default(HiddenField);
            Label ti = default(Label);
            cod = (HiddenField)row.FindControl("Id_Producto");
            cat = (HiddenField)row.FindControl("Id_Categoria");
            sub = (HiddenField)row.FindControl("Id_SubCategoria");
            ti = (Label)row.FindControl("Titulo");

                    //seteo todos los valores de la consulta especifica
            this.hfIdproducto.Value = cod.Value;
            Session["hfIdproducto"] = cod.Value;
            this.lblproducto.Text = ti.Text;
            hfIdCat.Value = cat.Value;
            hfIdSubCat.Value = sub.Value;
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
    #region "MARCA"
    private void cargarmarca()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_marca();
        if (_categoria.Tables[0].Rows.Count > 0)
        {
            pMarcasi.Visible = true;
            pMarcano.Visible = false;
            GvMarca.DataSource = _categoria.Tables[0];
            GvMarca.DataBind();
        }
        else
        {
            pMarcasi.Visible = false;
            pMarcano.Visible = true;
        }

    }
    protected void GvMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvMarca.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarmarca();
            }
        }
        catch { }
    }
    protected void GvMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvMarca.SelectedRow;
            string Id_Marca = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Marca");
            Id_Marca = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_marca_id(int.Parse(Id_Marca));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdmarca.Value = dr[0].ToString();
                    Session["hfIdmarca"] = dr[0].ToString();
                    this.lblmarca.Text = dr[1].ToString();
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarmarca.Text = "";
        cargarmarca();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarmarca.Text.Length > 0)
        {
            string letra = txtbuscarmarca.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarmarca();
        }
    }
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_marca_letra(letra,1);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvMarca.DataSource = _letras.Tables[0];
            GvMarca.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen provincias con la letra: " + letra + "');", true);
        }
    }
    #endregion
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            asignarmarca();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione la marca y producto');", true);
        }
    }
    private int validadatos()
    {
        int pro = 1;
        if (lblmarca.Text == "**Sin marca seleccionada**")
        {
            pro = 0;
        }
        if (lblproducto.Text == "**Sin producto seleccionado**")
        {
            pro = 0;
        }
        return pro;
    }
    private void asignarmarca()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Productos/>");
            if (hfIdmarca.Value != "")
            {
                _xmlDatos.DocumentElement.SetAttribute("Id_Marca", hfIdmarca.Value);
                if ((hfIdCat.Value == "0") || (hfIdSubCat.Value == "0"))
                {
                    _xmlDatos.DocumentElement.SetAttribute("Estado", "2");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Estado", "1");
                }
            }
            else
            {
                string idmarca = Session["hfIdmarca"].ToString();
                _xmlDatos.DocumentElement.SetAttribute("Id_Marca", idmarca);
                if ((hfIdCat.Value == "0") || (hfIdSubCat.Value == "0"))
                {
                    _xmlDatos.DocumentElement.SetAttribute("Estado", "2");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Estado", "1");
                }
            }
            
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlResultado = new XmlDocument();

            if (_administrador.Com21_edita_productos_marca(_xmlDatos.OuterXml, int.Parse(hfIdproducto.Value)))
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al asignar la marca');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Marca asignada con exito');", true);
                    limpiar();
                    cargarproductos();
                    cargarmarca();
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
        lblmarca.Text = "**Sin marca seleccionada**";
        lblproducto.Text = "**Sin producto seleccionado**";
        hfIdmarca.Value = "";
        hfIdproducto.Value = "";
    }
}