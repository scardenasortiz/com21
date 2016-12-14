using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_items : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarultimo();
            cargarproductos();
            cargarcategoria();
            cargarsubcategoria();
            cargarmarca();
        }
    }
    private void cargarultimo()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ultimo = _consulta.Com21_consulta_productos_ultimo();
        if (_ultimo.Tables[0].Rows.Count > 0)
        {
            int newid = 0;
            foreach (DataRow r in _ultimo.Tables[0].Rows)
            {
                newid = int.Parse(r[0].ToString()) + 1;
            }
            hfids.Value = Convert.ToString(newid);
        }
    }
    private void cargarproductos()
    {
        try
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _items = _consulta.Com21_consulta_productos();
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
        catch (Exception e)
        {
            Console.WriteLine("{0} Second exception caught.", e);
        }
    }
    #region "parat de ddl"
    protected void ddlcategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarsubcategoria();
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
    private void cargarmarca()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_marca();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            ddlmarca.DataSource = _categoria.Tables[1];
            ddlmarca.DataTextField = "Marca";
            ddlmarca.DataValueField = "Id_Marca";
            ddlmarca.DataBind();
        }
        else
        {
            ListItem _ddl = new ListItem();
            _ddl.Text = "No existen marcas";
            _ddl.Value = "0";
            ddlmarca.Items.Clear();

            ddlmarca.Items.Add(_ddl);
            ddlmarca.DataBind();
        }

    }
    #endregion
    #region "parat de GV"
    protected void GvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvItems.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                consultaletra(hfletra.Value);
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
            cod = (HiddenField)row.FindControl("Id_Producto");
            Id_producto = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_productos_id(int.Parse(Id_producto));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdproducto.Value = dr[0].ToString();
                    Session["hfIdproducto"] = dr[0].ToString();
                    this.txttitulo.Text = dr[1].ToString();
                    txtdescripcion.Content = dr[2].ToString();
                    this.txtcantidad.Text = dr[3].ToString();
                    hfinvent.Value = dr[3].ToString();
                    this.txtprecio.Text = dr[4].ToString();
                    this.txtpreciocompra.Text = dr["PrecioCompra"].ToString();
                    cargarcategoria();
                    int j = ValidaCategoria(dr[5].ToString());
                    if (j == 1)
                        this.ddlcategorias.SelectedValue = dr[5].ToString();
                    cargarsubcategoria();
                    int k = ValidaSubCategoria(dr[6].ToString());
                    if (k == 1)
                        this.ddlsubcategoria.SelectedValue = dr[6].ToString();
                    Image3.ImageUrl = dr[7].ToString();
                    if (Convert.ToBoolean(dr[8].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
                    cargarmarca();
                    int i = ValidaMarca(dr[12].ToString());
                    if(i == 1)
                        this.ddlmarca.SelectedValue = dr[12].ToString();
                    this.txtdescripcioncorta.Text = dr[13].ToString();
                    if (dr[14].ToString() == "1")
                    {
                        cbiva.Checked = true;
                    }
                    else
                    {
                        cbiva.Checked = false;
                    }
                    this.txtdescuento.Text = dr[15].ToString();
                    this.txtcodigo.Text = dr[16].ToString();
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
    #region "VALIDAR"
    private int ValidaMarca(string marca)
    {
        int i = 0;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_marca();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _categoria.Tables[1].Rows)
            {
                if (marca.Equals(r["Id_Marca"] + ""))
                {
                    i = 1;
                }
            }
        }
        return i;
    }
    private int ValidaCategoria(string cat)
    {
        int i = 0;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _categoria = _consulta.Com21_consulta_categoria();
        if (_categoria.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _categoria.Tables[1].Rows)
            {
                if (cat.Equals(r["Id_Categoria"] + ""))
                {
                    i = 1;
                }
            }
        }
        return i;
    }
    private int ValidaSubCategoria(string sub)
    {
        int i = 0;
        string ddlc = ddlcategorias.SelectedValue;
        if (int.Parse(ddlc) != 0)
        {
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
            DataSet _scategoria = _consulta.Com21_consulta_scategoria_id(int.Parse(ddlc));
            if (_scategoria.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow r in _scategoria.Tables[1].Rows)
                {
                    if (sub.Equals(r["Id_SubCategoria"] + ""))
                    {
                        i = 1;
                    }
                }
            }
        }
        return i;
    }
    #endregion
    protected void GvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Idproducto = GvItems.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_productos(int.Parse(Idproducto)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Producto eliminado');", true);
                //inactivar_productos(int.Parse(Idproducto));
            }
            Limpiar();
            cargarproductos();
            cargarsubcategoria();

        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    protected void GvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            //hfinsertid.Value = "1";
            //int index = int.Parse(e.CommandArgument.ToString());
            //GridViewRow row = GvItems.Rows[index];
            //HiddenField _id = default(HiddenField);
            //_id = (HiddenField)row.FindControl("Id_Producto");
            //cargarImagenesProductos(_id.Value);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GvItems.DataKeys[index].Value);
            cargarImagenesProductos(id);
        }
    }
    #endregion
   
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            ingresproducto();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese todo los campos');", true);
        }
    }
    private int validadatos()
    {
        int pro = 1;
        if (txttitulo.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtcantidad.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtcodigo.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtdescripcion.Content.Length == 0)
        {
            pro = 0;
        }
        if (txtdescripcioncorta.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtdescuento.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtprecio.Text.Length == 0)
        {
            pro = 0;
        }
        if (txtpreciocompra.Text.Length == 0)
        {
            pro = 0;
        }
        return pro;
    }
    private void ingresproducto()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Productos/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text.ToUpper());
            _xmlDatos.DocumentElement.SetAttribute("Codigo", txtcodigo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtdescripcion.Content);
            _xmlDatos.DocumentElement.SetAttribute("DescripcioCorta", txtdescripcioncorta.Text);
            _xmlDatos.DocumentElement.SetAttribute("Id_Categoria", ddlcategorias.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Id_SubCategoria", ddlsubcategoria.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Id_Marca", ddlmarca.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Cantidad", txtcantidad.Text);
            if (cbiva.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("ActIva", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("ActIva", "0");
            }
            _xmlDatos.DocumentElement.SetAttribute("Precio", txtprecio.Text.Replace(",","."));
            _xmlDatos.DocumentElement.SetAttribute("PrecioCompra", txtpreciocompra.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descuento", txtdescuento.Text.Replace(",", "."));
            _xmlDatos.DocumentElement.SetAttribute("Ruta", Image3.ImageUrl);
            String _dominio = Request.Url.Authority;
            if (_dominio == "localhost:2304")
            {
                //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfids.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue);
                String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfids.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                _xmlDatos.DocumentElement.SetAttribute("UrlProducto", _urlgenerada);
            }
            else
            {
                //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfids.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue);
                String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfids.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                _xmlDatos.DocumentElement.SetAttribute("UrlProducto", _urlgenerada);
            }
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
                if ((ddlcategorias.SelectedValue != "0") && (ddlmarca.SelectedValue != "0") && (ddlsubcategoria.SelectedValue != "0"))
                {
                    if (_administrador.Com21_ingresa_productos(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                        if (hfinvent.Value != txtcantidad.Text)
                        {
                            if (int.Parse(txtcantidad.Text) > int.Parse(hfinvent.Value))
                            {
                                hfinvent.Value = Convert.ToString(int.Parse(txtcantidad.Text) - int.Parse(hfinvent.Value));
                                ingresarinventario(int.Parse(hfids.Value), int.Parse(hfinvent.Value), txtprecio.Text.Replace(",", "."), txtpreciocompra.Text.Replace(",", "."), "I", "Compra");
                            }
                        }
                    }
                    Limpiar();
                    cargarproductos();
                    //cargarsubcategoria();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese: marcas, categorias, sub-categorias');", true);
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
        txtcantidad.Text = "";
        txtcodigo.Text = "";
        txtdescripcion.Content = "";
        txtdescripcioncorta.Text = "";
        txtdescuento.Text = "0";
        txtprecio.Text = "";
        txttitulo.Text = "";
        cbactivar.Checked = false;
        cbiva.Checked = false;
        Image3.ImageUrl = "~/images/SIN_IMAGEN.png";
        hfids.Value = "";
        txtpreciocompra.Text = "";
        hfinvent.Value = "";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        pnlProgress.Visible = true;
        int pro = validadatos();
        if (pro == 1)
        {
            editaproducto();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese todo los campos');", true);
        }
    }
    private void editaproducto()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Productos/>");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text.ToUpper());
            _xmlDatos.DocumentElement.SetAttribute("Codigo", txtcodigo.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descripcion", txtdescripcion.Content);
            _xmlDatos.DocumentElement.SetAttribute("DescripcioCorta", txtdescripcioncorta.Text);
            _xmlDatos.DocumentElement.SetAttribute("Id_Categoria", ddlcategorias.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Id_SubCategoria", ddlsubcategoria.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Id_Marca", ddlmarca.SelectedValue);
            _xmlDatos.DocumentElement.SetAttribute("Cantidad", txtcantidad.Text);
            if (cbiva.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("ActIva", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("ActIva", "0");
            }
            _xmlDatos.DocumentElement.SetAttribute("Precio", txtprecio.Text.Replace(',','.'));
            _xmlDatos.DocumentElement.SetAttribute("PrecioCompra", txtpreciocompra.Text);
            _xmlDatos.DocumentElement.SetAttribute("Descuento", txtdescuento.Text);
            _xmlDatos.DocumentElement.SetAttribute("Ruta", Image3.ImageUrl);

            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (hfIdproducto.Value != "")
            {
                
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if ((ddlcategorias.SelectedValue != "0") && (ddlmarca.SelectedValue != "0") && (ddlsubcategoria.SelectedValue != "0"))
                {
                    if (_administrador.Com21_edita_productos(_xmlDatos.OuterXml, int.Parse(hfIdproducto.Value)))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                        btninsert.Visible = true;
                        btnedit.Visible = false;
                        String _dominio = Request.Url.Authority;
                        if (_dominio == "localhost:2304")
                        {
                            //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            if (_administrador.Com21_edita_productos_Url(_urlgenerada, int.Parse(hfIdproducto.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                            if (hfinvent.Value != txtcantidad.Text)
                            {
                                if (int.Parse(txtcantidad.Text) > int.Parse(hfinvent.Value))
                                {
                                    hfinvent.Value = Convert.ToString(int.Parse(txtcantidad.Text) - int.Parse(hfinvent.Value));
                                    ingresarinventario(int.Parse(hfIdproducto.Value), int.Parse(hfinvent.Value), txtprecio.Text.Replace(",", "."), txtpreciocompra.Text.Replace(",", "."), "N", "Compra");
                                }
                            }
                        }
                        else
                        {
                            //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            if (_administrador.Com21_edita_productos_Url(_urlgenerada, int.Parse(hfIdproducto.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                            if (hfinvent.Value != txtcantidad.Text)
                            {
                                if (int.Parse(txtcantidad.Text) > int.Parse(hfinvent.Value))
                                {
                                    hfinvent.Value = Convert.ToString(int.Parse(txtcantidad.Text) - int.Parse(hfinvent.Value));
                                    ingresarinventario(int.Parse(hfIdproducto.Value), int.Parse(hfinvent.Value), txtprecio.Text.Replace(",", "."), txtpreciocompra.Text.Replace(",", "."), "N", "Compra");
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese: marcas, categorias, sub-categorias');", true);
                }
            }
            else
            {
                int idscategoria = int.Parse(Session["hfIdproducto"].ToString());
                XmlDocument _xmlResultado = new XmlDocument();
                //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
                if ((ddlcategorias.SelectedValue != "0") && (ddlmarca.SelectedValue != "0") && (ddlsubcategoria.SelectedValue != "0"))
                {
                    if (_administrador.Com21_edita_productos(_xmlDatos.OuterXml, idscategoria))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                        btninsert.Visible = true;
                        btnedit.Visible = false;
                        String _dominio = Request.Url.Authority;
                        if (_dominio == "localhost:2304")
                        {
                            //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            if (_administrador.Com21_edita_productos_Url(_urlgenerada, idscategoria))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                            if (hfinvent.Value != txtcantidad.Text)
                            {
                                if (int.Parse(txtcantidad.Text) > int.Parse(hfinvent.Value))
                                {
                                    hfinvent.Value = Convert.ToString(int.Parse(txtcantidad.Text) - int.Parse(hfinvent.Value));
                                    ingresarinventario(int.Parse(hfIdproducto.Value), int.Parse(hfinvent.Value), txtprecio.Text.Replace(",", "."), txtpreciocompra.Text.Replace(",", "."), "N", "Compra");
                                }
                            }
                        }
                        else
                        {
                            //String _urlgenerada = "http://designsie.com/com21/" + GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            String _urlgenerada = GenerateURLProducto(this.txttitulo.Text, hfIdproducto.Value, ddlcategorias.SelectedValue, ddlsubcategoria.SelectedValue, "P");
                            if (_administrador.Com21_edita_productos_Url(_urlgenerada, idscategoria))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            }
                            else
                            {
                            }
                            if (hfinvent.Value != txtcantidad.Text)
                            {
                                if (int.Parse(txtcantidad.Text) > int.Parse(hfinvent.Value))
                                {
                                    hfinvent.Value = Convert.ToString(int.Parse(txtcantidad.Text) - int.Parse(hfinvent.Value));
                                    ingresarinventario(int.Parse(hfIdproducto.Value), int.Parse(hfinvent.Value), txtprecio.Text.Replace(",", "."), txtpreciocompra.Text.Replace(",", "."), "I", "Compra");
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor ingrese: marcas, categorias, sub-categorias');", true);
                }
            }
            cargarproductos();
            Limpiar();
            txtbuscarproducto.Text = "";
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }

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

    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
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
    #endregion
    
    protected void lbvisualizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                double fileSize = fuimagen.PostedFile.ContentLength;
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {
                    if (fileSize <= 1024000)
                    {
                        classRandom sa = new classRandom();
                        savePath = "";
                        savePath += sa.NextString(6, true, false, true, false);
                        savePath += extension;
                        fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                        String ruta = Server.MapPath("..\\upload\\productos\\" + savePath);
                        System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
                        //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                        int ancho = int.Parse(objImage.Width.ToString());
                        int alto = int.Parse(objImage.Height.ToString());
                        objImage.Dispose();
                        objImage = null;

                        if ((ancho <= 600) && (alto <= 600))
                        {
                            Image3.ImageUrl = "~/upload/productos/" + savePath;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
                        }
                    }
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    protected void lbimagenes_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuimagen.HasFile)
            {
                string fileName = Server.HtmlEncode(fuimagen.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;
                    fuimagen.PostedFile.SaveAs(Server.MapPath("..\\upload\\productos\\") + savePath);

                    Image3.ImageUrl = "~/upload/productos/" + savePath;
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarproducto.Text.Length > 0)
        {
            string letra = txtbuscarproducto.Text.ToUpper();
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarproductos();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarproducto.Text = "";
        cargarproductos();
    }
    protected void lbasignar_Click(object sender, EventArgs e)
    {
        GridViewRow _asignar = this.GvItems.SelectedRow;

        HiddenField _cod = default(HiddenField);

    }
    protected void GvItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        String idproducto = GvItems.DataKeys[e.NewEditIndex].Value.ToString();
        cargarImagenesProductos(int.Parse(idproducto));
        //this.ModalPopupExtender.Show();
    }
    public static string GenerateURLProducto(object Title, object strId, object strCat, object strSub, object strTipo)
    {

        string strTitle = Title.ToString();

        #region Generate SEO Friendly URL based on Title
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');

        strTitle = strTitle.ToLower();
        char[] chars = @"$%#@!*?;:´~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        strTitle = strTitle.Replace("c#", "C-Sharp");
        strTitle = strTitle.Replace("vb.net", "VB-Net");
        strTitle = strTitle.Replace("asp.net", "Asp-Net");
        strTitle = strTitle.Replace("á", "a");
        strTitle = strTitle.Replace("é", "e");
        strTitle = strTitle.Replace("í", "i");
        strTitle = strTitle.Replace("ó", "o");
        strTitle = strTitle.Replace("ú", "u");
        strTitle = strTitle.Replace("Á", "A");
        strTitle = strTitle.Replace("É", "E");
        strTitle = strTitle.Replace("Í", "I");
        strTitle = strTitle.Replace("Ó", "O");
        strTitle = strTitle.Replace("Ú", "U");
        strTitle = strTitle.Replace("ç", "c");
        strTitle = strTitle.Replace("Ç", "C");
        strTitle = strTitle.Replace("Ä", "A");
        strTitle = strTitle.Replace("Ë", "E");
        strTitle = strTitle.Replace("Ï", "I");
        strTitle = strTitle.Replace("Ö", "O");
        strTitle = strTitle.Replace("Ü", "U");
        strTitle = strTitle.Replace("ä", "a");
        strTitle = strTitle.Replace("ë", "e");
        strTitle = strTitle.Replace("ï", "i");
        strTitle = strTitle.Replace("ö", "o");
        strTitle = strTitle.Replace("ü", "u");

        //Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
                strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("-----", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');


        #endregion

        //Append ID at the end of SEO Friendly URL
        strTitle = "" + strTitle + "-" + strId + "-" + strCat + "-" + strSub + "-" + strTipo +".aspx";

        return strTitle;
    }
    public static string RemoverSignosAcentos(object texto)
    {
        string texto2 = texto.ToString();
        var textoSinAcentos = string.Empty;

        foreach (var caracter in texto2)
        {
            var indexConAcento = ConSignos.IndexOf(caracter);
            if (indexConAcento > -1)
                textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
            else
                textoSinAcentos = textoSinAcentos + (caracter);
        }
        return textoSinAcentos;
    }
    private const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
    private const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
    #region "FUNCIONES INVENTARIO"
    private void ingresarinventario(int Id_Producto, int Cantidad, string Pvp, string PrecioCompra, string Ident, string IdentCV)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Ad_Productos/>");
        _xmlDatos.DocumentElement.SetAttribute("Id_Producto", Convert.ToString(Id_Producto));
        _xmlDatos.DocumentElement.SetAttribute("Cantidad", Convert.ToString(Cantidad));
        _xmlDatos.DocumentElement.SetAttribute("Precio", Pvp);
        _xmlDatos.DocumentElement.SetAttribute("PrecioCompra", PrecioCompra);
        _xmlDatos.DocumentElement.SetAttribute("Identificador", Ident);
        _xmlDatos.DocumentElement.SetAttribute("IdentificadorCV", IdentCV);

        if (_consulta.Com21_ingresa_inventario_productos(_xmlDatos.OuterXml))
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Inventario');", true);
        }
        else
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
        }
    }
    #endregion
    private void cargarImagenesProductos(int id)
    {
        //ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        //DataSet ds = _administrador.Com21_consulta_imagenes_id_producto(id);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        //seteo todos los valores de la consulta especifica
        //        this.IdImagenes.Value = dr[0].ToString();
        //        this.img.ImageUrl = dr[4].ToString();
        //        this.img0.ImageUrl = dr[1].ToString();
        //        this.img1.ImageUrl = dr[2].ToString();
        //        this.img2.ImageUrl = dr[3].ToString();
        //        if (Convert.ToBoolean(dr[6].ToString()) == true)
        //        {
        //            cbactivar.Checked = true;
        //        }
        //        else
        //        {
        //            cbactivar.Checked = false;
        //        }
        //        IdProductoPopup.Value = dr[7].ToString();
        //        lblproducto.Text = dr[8].ToString();
        //    }
        //    RadToolTip3.Show();
        //    btnedit.Visible = true;
        //    btninsert.Visible = false;
        //}
        //else
        //{
        //    btnedit.Visible = false;
        //    btninsert.Visible = true;
        //    RadToolTip3.Show();
        //}
        Response.Redirect("imagenes.aspx?ID=" + id);
    }
    protected void btninsert_imagenes_Click(object sender, EventArgs e)
    {

    }
    protected void btnedit_imagenes_Click(object sender, EventArgs e)
    {

    }

}