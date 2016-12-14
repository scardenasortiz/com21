using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_promociones : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarpromopubli();
            cargarproductos();
        }
    }
    private void cargarpromopubli()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _items = _consulta.Com21_consulta_promo_publi();
        if (_items.Tables[0].Rows.Count > 0)
        {
            pPPsi.Visible = true;
            pPPno.Visible = false;

            // agrego una columna con la ruta y asigno valor de base
            DataColumn dcol = new DataColumn("UbicarP", typeof(System.String));
            _items.Tables[0].Columns.Add(dcol);
            int i = 0;
            foreach (DataRow row in _items.Tables[0].Rows)
            {
                if (row["Ubicar"].ToString() == "1")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Prioridad 1";
                    _items.Tables[0].AcceptChanges();
                }
                if (row["Ubicar"].ToString() == "2")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Prioridad 2";
                    _items.Tables[0].AcceptChanges();
                }
                if (row["Ubicar"].ToString() == "3")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Prioridad 3";
                    _items.Tables[0].AcceptChanges();
                }
                if (row["Ubicar"].ToString() == "4")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Prioridad 4";
                    _items.Tables[0].AcceptChanges();
                }
                if (row["Ubicar"].ToString() == "5")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Prioridad 5";
                    _items.Tables[0].AcceptChanges();
                }
                if (row["Ubicar"].ToString() == "6")
                {
                    _items.Tables[0].Rows[i][_items.Tables[0].Columns.Count - 1] = "Sin Prioridad";
                    _items.Tables[0].AcceptChanges();
                }
                i = i + 1;
            }
            
            GvPP.DataSource = _items.Tables[0];
            GvPP.DataBind();
        }
        else
        {
            pPPsi.Visible = false;
            pPPno.Visible = true;
        }
    }
    private void cargarproductos()
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
                    this.lbllink.Text = dr["UrlProducto"].ToString();
                    
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Error Tecnico por favor espere unos minutos";
        }
    }
    protected void GvPP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPP.PageIndex = e.NewPageIndex;
        try
        {
            if (ddlbuscarseleccionar.SelectedValue != "0")
            {
                if (ddlbuscarseleccionar.SelectedValue != "3")
                {
                    consultaletras(ddlbuscarseleccionar.SelectedValue, ddlbuscarprioridad.SelectedValue);
                }
                else
                {
                    consultaletras(ddlbuscarseleccionar.SelectedValue, "0");
                }
                
            }
            else
            {
                cargarpromopubli();
            }
        }
        catch { }
    }
    protected void GvPP_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvPP.SelectedRow;
            string Id_promo = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_ProPu");
            Id_promo = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_promo_publi_id(int.Parse(Id_promo));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdpromo.Value = dr[0].ToString();
                    Session["hfIdpromo"] = dr[0].ToString();
                    ddlSeleccionar.SelectedValue = dr["Seleccionar"].ToString();
                    ddlUbicar.SelectedValue = dr["Ubicar"].ToString();
                    if (dr["Seleccionar"].ToString() == "1")
                    {
                        pPromocion.Visible = true;
                        pPublicidad.Visible = false;
                        imgpropu.ImageUrl = dr["Ruta"].ToString();
                        if (dr["ActPro"].ToString() == "1")
                        {
                            cbproducto.Checked = true;
                        }
                        else
                        {
                            cbproducto.Checked = false;
                        }
                        lbllink.Text = dr["Link"].ToString();
                    }
                    if (dr["Seleccionar"].ToString() == "2")
                    {
                        pPromocion.Visible = false;
                        pPublicidad.Visible = true;
                        imgpropu.ImageUrl = dr["Ruta"].ToString();
                        txtlink.Text = dr["Link"].ToString();
                    }
                    if (Convert.ToBoolean(dr["Activar"].ToString()) == true)
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
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Error Tecnico por favor espere unos minutos";
        }
    }
    protected void GvPP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Idpromo = GvPP.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_promo_publi(int.Parse(Idpromo)))
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al Eliminar');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "Error al eliminar registro";
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro eliminado con exito');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "exito");
                DMensaje.InnerText = "Registro eliminado con exito";
                //inactivar_productos(int.Parse(Idproducto));
            }
            cargarpromopubli();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Problemas tecnicos por favor comunicarse con el administrador del sitio";
        }

    }
    #endregion
   
    protected void btninsert_Click(object sender, EventArgs e)
    {
       ingrespropu();
       //btninsert.Attributes.Add("OnClientClick", "insertar();");
    }

    private void ingrespropu()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_ProPu/>");
            if (ddlSeleccionar.SelectedValue == "0")
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor selecciona el tipo de registro');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "Por favor selecciona el tipo de registro";
            }
            if (ddlSeleccionar.SelectedValue == "1")
            {
                if (ddlUbicar.SelectedValue != "0")
                {
                    if (cbproducto.Checked == true)
                    {
                        if (lbllink.Text != "**No ha seleccionado el producto**")
                        {
                            _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                            if (cbproducto.Checked == true)
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                            }
                            else
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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

                            DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                            if (_prio.Tables[0].Rows.Count > 0)
                            {
                                String id = "";
                                foreach (DataRow r in _prio.Tables[0].Rows)
                                {
                                    id = r[0].ToString();
                                }
                                if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                                {

                                }
                                else
                                {
                                    if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Error al ingresar registro";
                                    }
                                    else
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "exito");
                                        DMensaje.InnerText = "Registro ingresado con exito";
                                        cargarproductos();
                                        cargarpromopubli();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al ingresar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro ingresado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Activo la casilla sin seleccionar un producto');", true);
                            pMensajesAlertas.Visible = true;
                            DMensaje.Attributes.Add("Class", "error");
                            DMensaje.InnerText = "Activo la casilla sin seleccionar un producto";
                        }
                    }
                    else
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                        if (cbproducto.Checked == true)
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                            _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                            _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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
                        DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                        if (_prio.Tables[0].Rows.Count > 0)
                        {
                            String id = "";
                            foreach (DataRow r in _prio.Tables[0].Rows)
                            {
                                id = r[0].ToString();
                            }
                            if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                            {

                            }
                            else
                            {
                                if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al ingresar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro ingresado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                        else
                        {
                            if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Error al ingresar registro";
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "exito");
                                DMensaje.InnerText = "Registro ingresado con exito";
                                cargarproductos();
                                cargarpromopubli();
                                Limpiar();
                            }
                        }
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                    pMensajesAlertas.Visible = true;
                    DMensaje.Attributes.Add("Class", "error");
                    DMensaje.InnerText = "Por favor seleccione una prioridad";
                }
            }
            if (ddlSeleccionar.SelectedValue == "2")
            {
                if (ddlUbicar.SelectedValue != "0")
                {
                    _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                    _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                    _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                    if (cbproducto.Checked == true)
                    {
                        _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                        _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
                    }
                    else
                    {
                        _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                        _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
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
                    DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                    if (_prio.Tables[0].Rows.Count > 0)
                    {
                        String id = "";
                        foreach (DataRow r in _prio.Tables[0].Rows)
                        {
                            id = r[0].ToString();
                        }
                        if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                        {

                        }
                        else
                        {
                            if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Error al ingresar registro";
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "exito");
                                DMensaje.InnerText = "Registro ingresado con exito";
                                cargarproductos();
                                cargarpromopubli();
                                Limpiar();
                            }
                        }
                    }
                    else
                    {
                        if (_administrador.Com21_ingresa_promo_publi(_xmlDatos.OuterXml))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                            pMensajesAlertas.Visible = true;
                            DMensaje.Attributes.Add("Class", "error");
                            DMensaje.InnerText = "Error al ingresar registro";
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                            pMensajesAlertas.Visible = true;
                            DMensaje.Attributes.Add("Class", "exito");
                            DMensaje.InnerText = "Registro ingresado con exito";
                            cargarproductos();
                            cargarpromopubli();
                            Limpiar();
                        }
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                    pMensajesAlertas.Visible = true;
                    DMensaje.Attributes.Add("Class", "error");
                    DMensaje.InnerText = "Por favor seleccione una prioridad";
                }
                
            }
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Error Tecnico por favor espere unos minutos";
        }
    }
    private void Limpiar()
    {
        imgpropu.ImageUrl = "~/images/promo_publi_sin.jpg";
        cbproducto.Checked = false;
        cbactivar.Checked = false;
        txtlink.Text = "";
        lbllink.Text = "**No ha seleccionado el producto**";
        pPromocion.Visible = false;
        pPublicidad.Visible = false;
        ddlSeleccionar.SelectedValue = "0";
        ddlUbicar.SelectedValue = "0";
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        
        editaproducto();
       // btnedit.Attributes.Add("OnClientClick", "editar();");
        
    }
    private void editaproducto()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_ProPu/>");
            if (hfIdpromo.Value != "")
            {
                if (ddlSeleccionar.SelectedValue == "0")
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione el tipo de registro');", true);
                    pMensajesAlertas.Visible = true;
                    DMensaje.Attributes.Add("Class", "error");
                    DMensaje.InnerText = "Por favor seleccione el tipo de registro";
                }
                if (ddlSeleccionar.SelectedValue == "1")
                {
                    if (ddlUbicar.SelectedValue != "0")
                    {
                        if (cbproducto.Checked == true)
                        {
                            if (lbllink.Text != "**No ha seleccionado el producto**")
                            {
                                _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                                _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                                _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                                if (cbproducto.Checked == true)
                                {
                                    _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                                    _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                                }
                                else
                                {
                                    _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                                    _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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
                                DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                                if (_prio.Tables[0].Rows.Count > 0)
                                {
                                    String id = "";
                                    foreach (DataRow r in _prio.Tables[0].Rows)
                                    {
                                        id = r[0].ToString();
                                    }
                                    if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                                    {

                                    }
                                    else
                                    {
                                        if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                        {
                                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                            pMensajesAlertas.Visible = true;
                                            DMensaje.Attributes.Add("Class", "error");
                                            DMensaje.InnerText = "Error al editar registro";
                                        }
                                        else
                                        {
                                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                                            pMensajesAlertas.Visible = true;
                                            DMensaje.Attributes.Add("Class", "exito");
                                            DMensaje.InnerText = "Registro editado con exito";
                                            cargarproductos();
                                            cargarpromopubli();
                                            Limpiar();
                                        }
                                    }
                                }
                                else
                                {
                                    if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Error al editar registro";
                                    }
                                    else
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "exito");
                                        DMensaje.InnerText = "Registro editado con exito";
                                        cargarproductos();
                                        cargarpromopubli();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Activo la casilla sin seleccionar un producto');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Activo la casilla sin seleccionar un producto";
                            }
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                            if (cbproducto.Checked == true)
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                            }
                            else
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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
                            DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                            if (_prio.Tables[0].Rows.Count > 0)
                            {
                                String id = "";
                                foreach (DataRow r in _prio.Tables[0].Rows)
                                {
                                    id = r[0].ToString();
                                }
                                if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                                {

                                }
                                else
                                {
                                    if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Error al editar registro";
                                    }
                                    else
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);        
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Registro editado con exito";
                                        cargarproductos();
                                        cargarpromopubli();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al editar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro editado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                        pMensajesAlertas.Visible = true;
                        DMensaje.Attributes.Add("Class", "error");
                        DMensaje.InnerText = "Por favor seleccione una prioridad";
                    }
                }
                if (ddlSeleccionar.SelectedValue == "2")
                {
                    if (ddlUbicar.SelectedValue != "0")
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                        if (cbproducto.Checked == true)
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                            _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                            _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
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
                        DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                        if (_prio.Tables[0].Rows.Count > 0)
                        {
                            String id = "";
                            foreach (DataRow r in _prio.Tables[0].Rows)
                            {
                                id = r[0].ToString();
                            }
                            if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                            {

                            }
                            else
                            {
                                if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al editar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro editado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                        else
                        {
                            if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Error al editar registro";
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "exito");
                                DMensaje.InnerText = "Registro editado con exito";
                                cargarproductos();
                                cargarpromopubli();
                                Limpiar();
                            }
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                        pMensajesAlertas.Visible = true;
                        DMensaje.Attributes.Add("Class", "error");
                        DMensaje.InnerText = "Por favor seleccione una prioridad";
                    }
                }
            }
            else
            {
                int idpromo = int.Parse(Session["hfIdpromo"].ToString());
                if (ddlSeleccionar.SelectedValue == "0")
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione tipo de registro');", true);
                    pMensajesAlertas.Visible = true;
                    DMensaje.Attributes.Add("Class", "error");
                    DMensaje.InnerText = "Por favor seleccione tipo de registro";
                }
                if (ddlSeleccionar.SelectedValue == "1")
                {
                    if (ddlUbicar.SelectedValue != "0")
                    {
                        if (cbproducto.Checked == true)
                        {
                            if (lbllink.Text != "**No ha seleccionado el producto**")
                            {
                                _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                                _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                                _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                                if (cbproducto.Checked == true)
                                {
                                    _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                                    _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                                }
                                else
                                {
                                    _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                                    _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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
                                DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                                if (_prio.Tables[0].Rows.Count > 0)
                                {
                                    String id = "";
                                    foreach (DataRow r in _prio.Tables[0].Rows)
                                    {
                                        id = r[0].ToString();
                                    }
                                    if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                                    {

                                    }
                                    else
                                    {
                                        if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                        {
                                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                            pMensajesAlertas.Visible = true;
                                            DMensaje.Attributes.Add("Class", "error");
                                            DMensaje.InnerText = "Error al editar registro";
                                        }
                                        else
                                        {
                                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                            pMensajesAlertas.Visible = true;
                                            DMensaje.Attributes.Add("Class", "exito");
                                            DMensaje.InnerText = "Registro editado con exito";
                                            cargarproductos();
                                            cargarpromopubli();
                                            Limpiar();
                                        }
                                    }
                                }
                                else
                                {
                                    if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Error al editar registro";
                                    }
                                    else
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "exito");
                                        DMensaje.InnerText = "Registro editado con exito";
                                        cargarproductos();
                                        cargarpromopubli();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Activo la casilla sin seleccionar un producto');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Activo la casilla sin seleccionar un producto";
                            }
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                            _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                            if (cbproducto.Checked == true)
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
                            }
                            else
                            {
                                _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                                _xmlDatos.DocumentElement.SetAttribute("Link", lbllink.Text);
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
                            DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                            if (_prio.Tables[0].Rows.Count > 0)
                            {
                                String id = "";
                                foreach (DataRow r in _prio.Tables[0].Rows)
                                {
                                    id = r[0].ToString();
                                }
                                if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                                {

                                }
                                else
                                {
                                    if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "error");
                                        DMensaje.InnerText = "Error al editar registro";
                                    }
                                    else
                                    {
                                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                        pMensajesAlertas.Visible = true;
                                        DMensaje.Attributes.Add("Class", "exito");
                                        DMensaje.InnerText = "Registro editado con Exito";
                                        cargarproductos();
                                        cargarpromopubli();
                                        Limpiar();
                                    }
                                }
                            }
                            else
                            {
                                if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al editar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro editado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                        pMensajesAlertas.Visible = true;
                        DMensaje.Attributes.Add("Class", "error");
                        DMensaje.InnerText = "Por favor seleccione una prioridad";
                    }
                }
                if (ddlSeleccionar.SelectedValue == "2")
                {
                    if (ddlUbicar.SelectedValue != "0")
                    {
                        _xmlDatos.DocumentElement.SetAttribute("Seleccionar", ddlSeleccionar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ubicar", ddlUbicar.SelectedValue.ToString());
                        _xmlDatos.DocumentElement.SetAttribute("Ruta", imgpropu.ImageUrl.ToString());
                        if (cbproducto.Checked == true)
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "1");
                            _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
                        }
                        else
                        {
                            _xmlDatos.DocumentElement.SetAttribute("ActPro", "0");
                            _xmlDatos.DocumentElement.SetAttribute("Link", txtlink.Text);
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
                        DataSet _prio = _administrador.Com21_consulta_promo_publi_prioridad(int.Parse(ddlUbicar.SelectedValue));
                        if (_prio.Tables[0].Rows.Count > 0)
                        {
                            String id = "";
                            foreach (DataRow r in _prio.Tables[0].Rows)
                            {
                                id = r[0].ToString();
                            }
                            if (_administrador.Com21_edita_promo_publi_prioridad(int.Parse(id)))
                            {

                            }
                            else
                            {
                                if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "error");
                                    DMensaje.InnerText = "Error al editar registro";
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                    pMensajesAlertas.Visible = true;
                                    DMensaje.Attributes.Add("Class", "exito");
                                    DMensaje.InnerText = "Registro editado con exito";
                                    cargarproductos();
                                    cargarpromopubli();
                                    Limpiar();
                                }
                            }
                        }
                        else
                        {
                            if (_administrador.Com21_edita_promo_publi(_xmlDatos.OuterXml, int.Parse(hfIdpromo.Value)))
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "error");
                                DMensaje.InnerText = "Error al editar registro";
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                                pMensajesAlertas.Visible = true;
                                DMensaje.Attributes.Add("Class", "exito");
                                DMensaje.InnerText = "Registro editado con exito";
                                cargarproductos();
                                cargarpromopubli();
                                Limpiar();
                            }
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad');", true);
                        pMensajesAlertas.Visible = true;
                        DMensaje.Attributes.Add("Class", "error");
                        DMensaje.InnerText = "Por favor seleccione una prioridad";
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Error Tecnico por favor espere unos minutos";
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
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen productos para busqueda: " + letra + "');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "No existen productos para busqueda: " + letra;
        }
    }
    private void consultaletras(string selec, string prio)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_promo_publi_letra(int.Parse(selec),int.Parse(prio));
        if (selec == "1")
        {
            if (_letras.Tables[0].Rows.Count > 0)
            {
                GvPP.DataSource = _letras.Tables[0];
                GvPP.DataBind();
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "No existen promociones";
            }
        }
        if (selec == "2")
        {
            if (_letras.Tables[0].Rows.Count > 0)
            {
                GvPP.DataSource = _letras.Tables[0];
                GvPP.DataBind();
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen publicidades');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "No existen publicidades";
            }
        }
        if (selec == "3")
        {
            if (_letras.Tables[0].Rows.Count > 0)
            {
                GvPP.DataSource = _letras.Tables[0];
                GvPP.DataBind();
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen promociones ni publicidades con la prioridad seleccionada');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "No existen promociones ni publicidades con la prioridad seleccionada";
            }
        }
    }
    #endregion
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscarproducto.Text.Length > 0)
        {
            string letra = txtbuscarproducto.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarproductos();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlbuscarseleccionar.SelectedValue == "0")
        {
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione un criterio para la busqueda');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = "Por favor seleccione un criterio para la busqueda";
            ddlbuscarprioridad.Visible = false;
        }
        if (ddlbuscarseleccionar.SelectedValue == "1")
        {
            ddlbuscarprioridad.Visible = false;
            string prio = "0";
            consultaletras(ddlbuscarseleccionar.SelectedValue, prio);
        }
        if (ddlbuscarseleccionar.SelectedValue == "2")
        {
            ddlbuscarprioridad.Visible = false;
            string prio = "0";
            consultaletras(ddlbuscarseleccionar.SelectedValue, prio);
        }
        if (ddlbuscarseleccionar.SelectedValue == "3")
        {
            if (ddlbuscarprioridad.SelectedValue != "0")
            {
                ddlbuscarprioridad.Visible = true;
                consultaletras(ddlbuscarseleccionar.SelectedValue, ddlbuscarprioridad.SelectedValue);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione una prioridad para la busqueda');", true);
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("Class", "error");
                DMensaje.InnerText = "Por favor seleccione una prioridad para la busqueda";
            }
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscarproducto.Text = "";
        cargarproductos();
    }
    protected void refresh1_Click(object sender, ImageClickEventArgs e)
    {
        cargarpromopubli();
        ddlbuscarprioridad.SelectedValue = "0";
        ddlbuscarseleccionar.SelectedValue = "0";
        ddlbuscarprioridad.Visible = false;
    }
    protected void lbasignar_Click(object sender, EventArgs e)
    {
        GridViewRow _asignar = this.GvItems.SelectedRow;

        HiddenField _cod = default(HiddenField);

    }
    protected void GvItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        String idproducto = GvItems.DataKeys[e.NewEditIndex].Value.ToString();
        //this.ModalPopupExtender.Show();
    }
    protected void lbvisualizarPro_Click(object sender, EventArgs e)
    {
        try
        {
            if (fimagenPro.HasFile)
            {
                string fileName = Server.HtmlEncode(fimagenPro.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".jpg") | (extension == ".bmp") | (extension == ".BMP") | (extension == ".JPG") | (extension == ".PNG") | (extension == ".png") | (extension == ".GIF") | (extension == ".gif"))
                {

                    classRandom sa = new classRandom();
                    savePath = "";
                    savePath += sa.NextString(6, true, false, true, false);
                    savePath += extension;

                    if (ddlSeleccionar.SelectedValue == "1")
                    {
                        fimagenPro.PostedFile.SaveAs(Server.MapPath("..\\upload\\promociones\\") + savePath);
                        string ruta = Server.MapPath("..\\upload\\promociones\\" + savePath);
                        System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta);
                        //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                        int ancho = int.Parse(objImage.Width.ToString());
                        int alto = int.Parse(objImage.Height.ToString());
                        objImage.Dispose();
                        objImage = null;
                        if ((ancho <= 768) && (alto <= 140))
                        {
                            imgpropu.ImageUrl = "~/upload/promociones/" + savePath;
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
                            pMensajesAlertas.Visible = true;
                            DMensaje.Attributes.Add("Class", "error");
                            DMensaje.InnerText = "Por favor seleccionar una imagen con el tamaño adecuado";
                        }
                    }

                    if (ddlSeleccionar.SelectedValue == "2")
                    {
                        fimagenPro.PostedFile.SaveAs(Server.MapPath("..\\upload\\publicidad\\") + savePath);
                        string ruta1 = Server.MapPath("..\\upload\\publicidad\\" + savePath);
                        System.Drawing.Image objImage = System.Drawing.Image.FromFile(ruta1);
                        //this.lbltamaño.Text = "Ancho de la imagen: " + objImage.Width.ToString() + "px, Alto de la imagen: " + objImage.Height.ToString() + "px";
                        int ancho = int.Parse(objImage.Width.ToString());
                        int alto = int.Parse(objImage.Height.ToString());
                        objImage.Dispose();
                        objImage = null;
                        if ((ancho <= 768) && (alto <= 140))
                        {
                            imgpropu.ImageUrl = "~/upload/publicidad/" + savePath;
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Por favor seleccionar una imagen con el tamaño adecuado');", true);
                            pMensajesAlertas.Visible = true;
                            DMensaje.Attributes.Add("Class", "error");
                            DMensaje.InnerText = "Por favor seleccionar una imagen con el tamaño adecuado";
                        }
                    }
                }

            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('" + Ex.Message + "');", true);
            pMensajesAlertas.Visible = true;
            DMensaje.Attributes.Add("Class", "error");
            DMensaje.InnerText = Ex.Message+"";
        }
    }
    protected void ddlSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSeleccionar.SelectedValue == "0")
        {
            pPromocion.Visible = false;
            pPublicidad.Visible = false;
        }
        if (ddlSeleccionar.SelectedValue == "1")
        {
            pPromocion.Visible = true;
            pPublicidad.Visible = false;
        }
        if (ddlSeleccionar.SelectedValue == "2")
        {
            pPromocion.Visible = false;
            pPublicidad.Visible = true;
        }
    }
    //protected void ddlbuscarseleccionar_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlbuscarseleccionar.SelectedValue == "0")
    //    {
    //        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Por favor seleccione un criterio para la busqueda');", true);
    //        ddlbuscarprioridad.Visible = false;
    //    }
    //    if (ddlbuscarseleccionar.SelectedValue == "1")
    //    {
    //        ddlbuscarprioridad.Visible = false;
    //    }
    //    if (ddlbuscarseleccionar.SelectedValue == "2")
    //    {
    //        ddlbuscarprioridad.Visible = false;
    //    }
    //    if (ddlbuscarseleccionar.SelectedValue == "3")
    //    {
    //        ddlbuscarprioridad.Visible = true;
    //    }
    //}
}