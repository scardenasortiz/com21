using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using com21DLL;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class carrito : System.Web.UI.Page
{
    public String[] DataC;

    private void ConsultaDataCompra(int id)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_cliente_DatosCompra(id,1);
        String data = "";
        foreach(DataRow r in ds.Tables[0].Rows)
        {
            //idusuario+T+ActE+FormaP+CodUpdatePre
            data = r[1] + "" + "|" + r[2] + "" + "|" + r[3] + "" + "|" + r[4] + "" + "|" + r[5] + "";
        }
        ViewState["DataCompra"] = data;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                ConsultaDataCompra(int.Parse(Request.Cookies["IdCom21Web"].Value));
                String data = ViewState["DataCompra"]+"";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {
                    int i = int.Parse(DataC[3]+"");
                    if (i == 0)
                    {
                        btnsiguienteSC.Visible = true;
                        btnsiguienteCC.Visible = false;
                        btncomprarSC.Visible = false;
                        btncomprarCC.Visible = false;
                        pSinCosto.Visible = true;
                        pConCosto.Visible = false;
                        cambiarCodUpdate();
                    }
                    else
                    {
                        if (i == 1)
                        {
                            if (DataC[2] + "" == "1")
                            {
                                btnsiguienteSC.Visible = false;
                                btnsiguienteCC.Visible = false;
                                btncomprarSC.Visible = false;
                                btncomprarCC.Visible = true;
                                pSinCosto.Visible = false;
                                pConCosto.Visible = true;
                            }
                            else
                            {
                                btnsiguienteSC.Visible = false;
                                btnsiguienteCC.Visible = false;
                                btncomprarSC.Visible = true;
                                btncomprarCC.Visible = false;
                                pSinCosto.Visible = true;
                                pConCosto.Visible = false;
                            }
                        }
                        else
                        {
                            if (DataC[2] + "" == "1")
                            {
                                btnsiguienteSC.Visible = false;
                                btnsiguienteCC.Visible = false;
                                btncomprarSC.Visible = false;
                                btncomprarCC.Visible = true;
                                pSinCosto.Visible = false;
                                pConCosto.Visible = true;
                            }
                            else
                            {
                                btnsiguienteSC.Visible = false;
                                btnsiguienteCC.Visible = false;
                                btncomprarSC.Visible = true;
                                btncomprarCC.Visible = false;
                                pSinCosto.Visible = true;
                                pConCosto.Visible = false;
                            }
                        }
                    }
                    cargarCarrito();
                }
            }
            else
            {
                Response.Redirect("default.aspx");   
            }
        }
    }
    private void cargarCarrito()
    {
        int carga = 0;
        String data = ViewState["DataCompra"]+"";
        DataC = data.Split('|');
        String _cod = string.Empty;
        if (DataC.Length > 0)
        {
            _cod = DataC[4]+"";
            if (DataC[3] + "" == "0")
                carga = 0;
            else
                carga = 1;
        }
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(Request.Cookies["IdCom21Web"].Value));
        if (_ds.Tables[0].Rows.Count > 0)
        {
            lbcancelar.Visible = true;
            pProductSi.Visible = true;
            pProductNo.Visible = false;
            GvCarrito.DataSource = _ds.Tables[0];
            GvCarrito.DataBind();
            sumarTD(_ds, 0);
        }
        else
        {
            lbcancelar.Visible = false;
            pProductSi.Visible = false;
            pProductNo.Visible = true;
            productosN.InnerHtml = "No existen productos agregados a su carrito";
            //ActualizarDataCompra(DataC[1] + "", DataC[3] + "", DataC[4] + "", DataC[2] + "");
            EditarDatosCompra(_cod, int.Parse(Request.Cookies["IdCom21Web"].Value));
        }
    }
    private void cambiarCodUpdate()
    {
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        String codupdate = "";
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {
            codupdate = DataC[4] + "";
        }
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if (_consulta.proc_edita_codupdate_prefactura(0, id, codupdate))
        {
        }
        else
        {
        }
    }
    private void sumarTD(DataSet ds, int carga)
    {
        Decimal _tot = 0;
        Decimal _desc = 0;
        Decimal _totF = 0;
        Decimal _iva = 0;
        Decimal _cant = 0;
        foreach (DataRow r in ds.Tables[carga].Rows)
        {
            _tot = _tot + decimal.Parse(r["Total"].ToString());
            _desc = _desc + decimal.Parse(r["Descuento"].ToString());
            _cant = _cant + int.Parse(r["Cantidad"].ToString());
        }

        if (DataC[2]+"" == "1")
        {
            Decimal _costo = costoenvio();
            sCostoEnv.InnerHtml = _costo.ToString("0.00");

            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc + _costo;
        }
        else
        {
            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc;
        }

        iva.InnerHtml = Convert.ToString(_iva);
        sIvaCosto.InnerHtml = Convert.ToString(_iva);

        descuentos.InnerHtml = Convert.ToString(_desc);
        sDescCosto.InnerHtml = Convert.ToString(_desc);

        subtotal.InnerHtml = Convert.ToString(_tot);
        sSubCosto.InnerHtml = Convert.ToString(_tot);

        total.InnerHtml = Convert.ToString(_totF);
        sTotCosto.InnerHtml = Convert.ToString(_totF);

        contadorCant.Value = _cant + "";
    }
    private decimal costoenvio()
    {
        Decimal a = 0;
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_costo_IdUsuario_IdCiudad(id,0);
        if (_ds.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[1].Rows)
            {
                a = decimal.Parse(r["Costo"].ToString().Replace(".", ","));
            }
        }
        else
        {

        }
        return a;
    }
    protected void GvCarrito_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GvCarrito.SelectedRow;
        HiddenField cod = default(HiddenField);
        HiddenField codPro = default(HiddenField);
        HiddenField cantExt = default(HiddenField);
        HiddenField descuentoVal = default(HiddenField);
        Label _precio = default(Label);
        Label _descuento = default(Label);
        Label _cantidad = default(Label);
        TextBox txtcantidad = default(TextBox);
        txtcantidad = (TextBox)row.FindControl("txtcantidad");
        cod = (HiddenField)row.FindControl("hfPrefactura");
        codPro = (HiddenField)row.FindControl("IdProducto");
        cantExt = (HiddenField)row.FindControl("CantidadExt");
        descuentoVal = (HiddenField)row.FindControl("DescuentoVal");
        if ((txtcantidad.Text != "0") && (txtcantidad.Text.Length > 0))
        {
            _precio = (Label)row.FindControl("lblprecio");
            _descuento = (Label)row.FindControl("lbldescuento");
            _cantidad = (Label)row.FindControl("lblcantidad");
            ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();

            //operaciones
            if (hf1.Value == "2")
            {
                if (int.Parse(cantExt.Value) > int.Parse(txtcantidad.Text))
                {
                    int cant = int.Parse(txtcantidad.Text) + int.Parse(_cantidad.Text);
                    decimal tot = cant * decimal.Parse(_precio.Text);
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("Cantidad", Convert.ToString(cant));
                    _xmlDatos.DocumentElement.SetAttribute("Precio", _precio.Text.Replace(",", "."));

                    int _desc = int.Parse(descuentoVal.Value + "");
                    decimal _calcular = decimal.Parse(_precio.Text);
                    decimal _multi = ((_calcular * _desc) / 100);
                    String _precioesp = Convert.ToString(_multi * cant);
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", _precioesp.Replace(",", "."));

                    _xmlDatos.DocumentElement.SetAttribute("Total", tot.ToString().Replace(",", "."));


                    if (_consulta.proc_edita_producto_prefacturado_carrito(_xmlDatos.OuterXml, int.Parse(cod.Value)))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al actualizar cantidad');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Cantidad agregada con exito');", true);
                        if (_consulta.proc_actualiza_cantidad_producto_id_Menos(int.Parse(txtcantidad.Text), int.Parse(codPro.Value)))
                        {
                        }
                        else
                        {
                        }
                        cargarCarrito();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Cantidad digitada mayor a la existente, la cantidad actual es: " + cantExt.Value + ".');", true);
                }
            }
            else
            {
                if (int.Parse(_cantidad.Text) > int.Parse(txtcantidad.Text))
                {
                    int cant = int.Parse(_cantidad.Text) - int.Parse(txtcantidad.Text);
                    decimal tot = cant * decimal.Parse(_precio.Text);
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("Cantidad", Convert.ToString(cant));
                    _xmlDatos.DocumentElement.SetAttribute("Precio", _precio.Text.Replace(",", "."));

                    int _desc = int.Parse(descuentoVal.Value + "");
                    decimal _calcular = decimal.Parse(_precio.Text);
                    decimal _multi = ((_calcular * _desc) / 100);
                    String _precioesp = Convert.ToString(_multi * cant);
                    _xmlDatos.DocumentElement.SetAttribute("Descuento", _precioesp.Replace(",", "."));

                    _xmlDatos.DocumentElement.SetAttribute("Total", tot.ToString().Replace(",", "."));


                    if (_consulta.proc_edita_producto_prefacturado_carrito(_xmlDatos.OuterXml, int.Parse(cod.Value)))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al actualizar cantidad');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Cantidad eliminada con exito');", true);
                        if (_consulta.proc_actualiza_cantidad_producto_id(int.Parse(txtcantidad.Text), int.Parse(codPro.Value)))
                        {
                        }
                        else
                        {
                        }
                        cargarCarrito();
                    }
                }
                else
                {
                    if (int.Parse(txtcantidad.Text) == int.Parse(_cantidad.Text))
                    {
                        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
                        if (_administrador.proc_elimina_producto_prefactura(int.Parse(Request.Cookies["IdCom21Web"].Value), int.Parse(cod.Value)))
                        {
                            //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto eliminado con exito');", true);
                            if (_consulta.proc_actualiza_cantidad_producto_id_Menos(int.Parse(txtcantidad.Text), int.Parse(codPro.Value)))
                            {
                            }
                            else
                            {
                            }
                            cargarCarrito();
                        }
                    }
                    else
                    {
                    }
                }
            }
            //

        }
        else
        {
            if (hf1.Value == "1")
            {
                _cantidad = (Label)row.FindControl("lblcantidad");
                ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
                if (_administrador.proc_elimina_producto_prefactura(int.Parse(Request.Cookies["IdCom21Web"].Value), int.Parse(cod.Value)))
                {
                    //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto eliminado con exito');", true);
                    if (_administrador.proc_actualiza_cantidad_producto_id_Menos(int.Parse(_cantidad.Text), int.Parse(codPro.Value)))
                    {
                    }
                    else
                    {
                    }
                    cargarCarrito();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Digite una cantidad valida');", true);
            }
        }
    }
    protected void GvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument == "Eliminar")
        {
            String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            hf1.Value = "1";
        }
        if (e.CommandArgument == "Agregar")
        {
            String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            hf1.Value = "2";
        }
    }
    protected void GvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
            string IdPrefactura = GvCarrito.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.proc_elimina_producto_prefactura(int.Parse(Request.Cookies["IdCom21Web"].Value),int.Parse(IdPrefactura)))
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Producto eliminado con exito');", true);
                /*if (_consulta.proc_actualiza_cantidad_producto_id_Menos(int.Parse(txtcantidad.Text), int.Parse(codPro.Value)))
                {
                }
                else
                {
                }*/
                cargarCarrito();
            }
    }
    protected void lbcancelar_Click(object sender, EventArgs e)
    {
        cancelarCarrito();
    }
    private void EditarDatosCompra(String _cod, int idusuario)
    {
        classRandom _rand = new classRandom();
        String _cod2 = _rand.NextString(11, true, true, true, false);
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", idusuario + "");
        _xmlDatos.DocumentElement.SetAttribute("T", "0");
        _xmlDatos.DocumentElement.SetAttribute("FormaP", "0");
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", _cod2);
        _xmlDatos.DocumentElement.SetAttribute("ActE", "0");
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, idusuario))
        { }
        else
        { }
    }
    private void cancelarCarrito()
    {
        classRandom _rand = new classRandom();
        String _cod = _rand.NextString(11, true, true, true, false);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String data = ViewState["DataCompra"] + "";
        DataC = data.Split('|');
        if (DataC.Length > 0)
        {
            DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(Request.Cookies["IdCom21Web"].Value));
            if (_ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in _ds.Tables[0].Rows)
                {
                    if (_consulta.proc_actualiza_cantidad_producto_id(int.Parse(r["Cantidad"] + ""), int.Parse(r["Id_Producto"] + "")))
                    {
                    }
                    else
                    {
                        //cargarCarrito();
                    }
                }

                string _codUP = DataC[4] + "";
                XmlDocument _xmlDatos = new XmlDocument();
                _xmlDatos.LoadXml("<Prefactura/>");
                _xmlDatos.DocumentElement.SetAttribute("IdEstado", "2");

                if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP))
                {
                }
                else
                {
                    cargarCarrito();
                }

                EditarDatosCompra(_cod, int.Parse(Request.Cookies["IdCom21Web"].Value));
               // EditarDatosCompra(DataC[4] + "", int.Parse(Request.Cookies["IdCom21Web"].Value));
            }
        }
    }
    protected void btnsiguienteSC_Click(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(Request.Cookies["IdCom21Web"].Value));
        if (_ds.Tables[0].Rows.Count > 0)
        {
            if (GvCarrito.Rows.Count < _ds.Tables[0].Rows.Count)
            {
                ClasesAdd.Visible = true;
                ClasesAdd.Attributes.Add("class", "ok");
                imgMensaje.ImageUrl = "~/images/good_or_tick.png";
                pMensaje.Text = "Aviso: Se añadió productos a su carrito";
                cargarCarrito();
            }
            if (GvCarrito.Rows.Count > _ds.Tables[0].Rows.Count)
            {
                ClasesAdd.Visible = true;
                ClasesAdd.Attributes.Add("class", "no");
                imgMensaje.ImageUrl = "~/images/error.png";
                pMensaje.Text = "Aviso: Se ha eliminado productos de su carrito";
                cargarCarrito();
            }
            if(GvCarrito.Rows.Count == _ds.Tables[0].Rows.Count)
            {
                String data = ViewState["DataCompra"] + "";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {
                    string _codUP = DataC[4] + "";
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("IdEstado", "1");

                    if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP)) { }
                    else { }

                }
                Response.Redirect("editainfo.aspx");
            }
        }
        else
        {
            cancelarCarrito();
            Response.Redirect("default.aspx");
        }
            
    }
    protected void btncomprarSC_Click(object sender, EventArgs e)
    {
        Pago();
    }
    protected void btnsiguienteCC_Click(object sender, EventArgs e)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(Request.Cookies["IdCom21Web"].Value));
        if (_ds.Tables[0].Rows.Count > 0)
        {
            if (GvCarrito.Rows.Count > _ds.Tables[0].Rows.Count)
            {
                cargarCarrito();
                ClasesAdd.Visible = true;
                ClasesAdd.Attributes.Add("class", "no");
                imgMensaje.ImageUrl = "~/images/error.png";
                pMensaje.Text = "Aviso: Se ha eliminado productos de su carrito";
            }
            if (GvCarrito.Rows.Count < _ds.Tables[0].Rows.Count)
            {
                cargarCarrito();
                ClasesAdd.Visible = true;
                ClasesAdd.Attributes.Add("class", "ok");
                imgMensaje.ImageUrl = "~/images/good_or_tick.png";
                pMensaje.Text = "Aviso: Se añadió productos a su carrito";
            }
            if(GvCarrito.Rows.Count == _ds.Tables[0].Rows.Count)
            {
                String data = ViewState["DataCompra"] + "";
                DataC = data.Split('|');
                if (DataC.Length > 0)
                {
                    string _codUP = DataC[4] + "";
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("IdEstado", "1");

                    if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP)) { }
                    else { }

                }
                Response.Redirect("editainfo.aspx");
            }
        }
        else
        {
            cancelarCarrito();
            Response.Redirect("default.aspx");
        }
    }
    protected void btncomprarCC_Click(object sender, EventArgs e)
    {
        Pago();
    }
    public void Pago()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            if (DataC.Length > 0)
            {
                //Genero y Guardo Transaccion
                IngresarTransaccion();
                if (DataC[3] + "" == "1")
                {
                    string _codUP = DataC[4] + "";
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("IdEstado", "2");

                    if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP)) { }
                    else { }

                    Response.Redirect("carritoreply.aspx");
                }
                else
                {
                    string _codUP = DataC[4] + "";
                    XmlDocument _xmlDatos = new XmlDocument();
                    _xmlDatos.LoadXml("<Prefactura/>");
                    _xmlDatos.DocumentElement.SetAttribute("IdEstado", "2");

                    if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatos.OuterXml, _codUP)) { }
                    else { }
                    //Pay pal process Refer for what are the variable are need to send http://www.paypalobjects.com/IntegrationCenter/ic_std-variable-ref-buy-now.html
                    //IngresarTransaccion();
                    int contador = GvCarrito.Rows.Count;
                    string redirectUrl = "";

                    //Mention URL to redirect content to paypal site
                    redirectUrl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();

                    //First name I assign static based on login details assign this value
                    redirectUrl += "&first_name=Com21SA";

                    //Product Name
                    redirectUrl += "&item_name=Productos";

                    //Product Amount
                    if (DataC[2] == "1")
                    {
                        redirectUrl += "&amount=" + sTotCosto.InnerText.Replace(',','.');
                    }
                    else
                    {
                        redirectUrl += "&amount=" + total.InnerText.Replace(',', '.');
                    }

                    //Business contact paypal EmailID
                    redirectUrl += "&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();

                    //Shipping charges if any, or available or using shopping cart system
                    //redirectUrl += "&shipping=0";
                    
                    //Currency Code
                    redirectUrl += "&currency_code=USD";

                    //Return method
                    redirectUrl += "&rm=2";
                    
                    //Custom
                    redirectUrl += "&custom=Pago";

                    //Handling charges if any, or available or using shopping cart system
                    //redirectUrl += "&handling=0";

                    //Tax charges if any, or available or using shopping cart system
                    //redirectUrl += "&tax=0";

                    //Quantiy of product, Here statically added quantity 1
                    redirectUrl += "&quantity=" + contador+"";

                    //If transactioin has been successfully performed, redirect SuccessURL page- this page will be designed by developer
                    redirectUrl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"].ToString();

                    //If transactioin has been failed, redirect FailedURL page- this page will be designed by developer
                    redirectUrl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"].ToString();

                    Response.Redirect(redirectUrl);
                }
                //// Una vez guardada la transaccion la asigno al carro
                //String iUsuario = Request.Cookies["IdHMusicalisimo"].Value;
                //VPOSSend Plugin = new VPOSSend();

                //// Setear parametros de las propiedades del objeto plugin
                ////Campos Obligatorios

                //Plugin.SetCodigoAdquirente = "8"; // Asignado por Alignet
                //Plugin.SetCodigoMall = 0; // Asignado por Alignet
                //Plugin.SetCodigoComercio = "3375"; // Asignado por Alignet       
                //Plugin.SetCodigoTerminal = "0000000";
                //Plugin.SetCodigoOperacion = Session["IdTransaccion" + iUsuario + ""].ToString();
                //double total = double.Parse(lblTotal.Text);
                //// Envio el valor monetario en formato 10,00 no con (.) porque da error 
                //double valor = double.Parse(total.ToString("0.00"));
                //valor = valor * 100;
                //Plugin.SetMonto = (long)valor;
                //Plugin.SetCodigoMoneda = "840";
                //double subtotal = double.Parse(lblSubtotal.Text) + double.Parse(HFRecargo.Value);
                //double sub = double.Parse(subtotal.ToString("0.00"));
                //sub = sub * 100;
                //double totaliva = double.Parse(lblPorcentaje.Text);
                //double iva = double.Parse(totaliva.ToString("0.00"));
                //iva = iva * 100;
                //Plugin.SetReservado1 = sub.ToString();
                //Plugin.SetReservado2 = iva.ToString(); // IVA        
                //Plugin.SetReservado3 = "SP";




                ////// Campos Opcionales
                //ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
                //DataSet ds = _usuario.consulta_usuario_id(int.Parse(iUsuario));
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        //seteo todos los valores de la con
                //        //Plugin.SetReservado4 = "24hrs";
                //        Plugin.SetPrimerNombre = dr[1].ToString();
                //        Plugin.SetPrimerApellido = dr[2].ToString();
                //        //Plugin.SetSegundoNombre = "Segundo NOmbre";
                //        //Plugin.SetSegundoApellido = "Segundo Apellido";
                //        //Plugin.SetTelefono = "Numero de Telefono";
                //        Plugin.SetDireccionElectronica = dr[7].ToString();
                //        //Plugin.SetDireccionEntrega = "Direccion de Entrega";
                //        //Plugin.SetReservado5 = "Telefono al cual se pueda contactar";
                //        //Plugin.SetReservado6 = "Lista de 3 productos de la compra separados por | Ej: 01|Biblias|02|Libro|03|Player";
                //    }

                //}



                //// Envio de vevtor, Llave cifrada y llave publica
                //Plugin.vectorInicializacion = "af145513cd513566";
                //string R1 = Server.MapPath("Llaves\\LLAVE-PRIVADA-FIRMA-RSA.txt");
                //string R2 = Server.MapPath("Llaves\\ALIGNET.PRODUCCION.NOPHP.CRYPTO.PUBLIC.txt");
                //StreamReader srVPOSLlaveCifradoPublica = new StreamReader(R1);
                //StreamReader srLlavePublicaCifradoRSA = new StreamReader(R2);
                //string LlavePublicaFirmaVPOS = srVPOSLlaveCifradoPublica.ReadToEnd();
                //string LlavePublicaCifradoRSA = srLlavePublicaCifradoRSA.ReadToEnd();
                //Plugin.LlavePrivadaFirmaRSA = LlavePublicaFirmaVPOS;
                //Plugin.LlavePublicaCifradoRSA = LlavePublicaCifradoRSA;
                ////Ejecutar

                //Plugin.Ejecutar();

                ////envio de generados por plugin  al form frmSolicitudPago.htm
                //Session["XMLREQ"] = Plugin.XMLCifrado;
                //Session["DIGITALSIGN"] = Plugin.FirmaDigitalXML;
                //Session["SESSIONKEY"] = Plugin.llaveSesion;

                //Response.Redirect("frmSolicitudPago.aspx");
            }
    }
    public void IngresarTransaccion()
    {
        try
        {
            String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            if (DataC.Length > 0)
            {
                ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
                classRandom sa = new classRandom();
                String IdTransaccion = sa.NextString(15, true, true, true, false);
                String T = IdTransaccion;
                String iUsuario = Request.Cookies["IdCom21Web"].Value;
                HiddenField cod;
                HiddenField ID;
                Label Cantidad;
                XmlDocument _xmlDatos = new XmlDocument();
                _xmlDatos.LoadXml("<Transaccion/>");
                _xmlDatos.DocumentElement.SetAttribute("IdTransaccion", IdTransaccion);
                _xmlDatos.DocumentElement.SetAttribute("IdUsuario", iUsuario);
                _xmlDatos.DocumentElement.SetAttribute("Lote", "");
                _xmlDatos.DocumentElement.SetAttribute("Referencia", "");
                if (DataC[2]+"" == "1")
                {
                    _xmlDatos.DocumentElement.SetAttribute("Total", sTotCosto.InnerHtml.ToString());
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Total", total.InnerHtml.ToString());
                }
                if (DataC[3]+"" == "1")
                {
                    _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Realizada");
                    _xmlDatos.DocumentElement.SetAttribute("DescripcionFP", "Tranferencia");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("DescripcionFP", "PayPal");
                    _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Solicitada");
                }
                _xmlDatos.DocumentElement.SetAttribute("IdEstado", "1");
                DataSet _ds = _consulta.consulta_producto_prefacturado(int.Parse(iUsuario));
                if (_ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow r in _ds.Tables[0].Rows)
                    {
                        _xmlDatos.DocumentElement.SetAttribute("RucCiFact", r["RucCiFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("NombreFact", r["NombreFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("DireccionFact", r["DireccionFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("TelefonoFact", r["TelefonoFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("DireccionEnvio", r["DireccionEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("PaisEnvio", r["PaisEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("ProvinciaEnvio", r["ProvinciaEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("CiudadEnvio", r["CiudadEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("TelefonoEnvio", r["TelefonoEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("ContactoEnvio", r["ContactoEnvio"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("DireccionEntFact", r["DireccionEntFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("ProvinciaEntFact", r["ProvinciaEntFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("CiudadEntFact", r["CiudadEntFact"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("TransAutori", r["TransAutori"].ToString());
                        _xmlDatos.DocumentElement.SetAttribute("FormaPago", r["FormaPago"].ToString());
                    }
                }
                XmlDocument _XmlResultado = new XmlDocument();


                if (_consulta.proc_Ingresa_Transaccion(_xmlDatos.OuterXml))
                {
                    //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al Ingresar.');", true);
                }
                else
                {
                    //ingreso los detalles de la transaccion 

                    //Recorro todo el Grid
                    foreach (GridViewRow rowshopping in this.GvCarrito.Rows)
                    {
                        cod = (HiddenField)rowshopping.FindControl("IdProducto");
                        ID = (HiddenField)rowshopping.FindControl("hfPrefactura");
                        Cantidad = (Label)rowshopping.FindControl("lblcantidad");

                        XmlDocument _xmlDatos2 = new XmlDocument();
                        _xmlDatos2.LoadXml("<DetalleTransaccion/>");
                        _xmlDatos2.DocumentElement.SetAttribute("IdTransaccion", IdTransaccion);
                        _xmlDatos2.DocumentElement.SetAttribute("IdProducto", cod.Value.ToString());
                        _xmlDatos2.DocumentElement.SetAttribute("Cantidad", Cantidad.Text);
                        _xmlDatos2.DocumentElement.SetAttribute("IdPrefactura", ID.Value);

                        XmlDocument _XmlResultado2 = new XmlDocument();

                        if (_consulta.proc_Ingresa_DetalleTransaccion(_xmlDatos2.OuterXml))
                        {
                            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Error al Ingresar.');", true);
                        }
                    }

                    String _codupdate = DataC[4] + "";
                    XmlDocument _xmlDatosEst = new XmlDocument();
                    _xmlDatosEst.LoadXml("<Estado/>");
                    _xmlDatosEst.DocumentElement.SetAttribute("IdEstado", "2");
                    if (_consulta.proc_edita_prefacturado_producto_Estado_CodUpdate(_xmlDatosEst.OuterXml, _codupdate))
                    {
                    }
                    else
                    {
                    }
                    ActualizarDataCompra(T,DataC[3]+"",DataC[4]+"",DataC[2]+"");
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }
    }
    private void ActualizarDataCompra(string T, string FormaP, string CodUpdatePre, string ActE)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", Request.Cookies["IdCom21Web"].Value);
        _xmlDatos.DocumentElement.SetAttribute("T", T);
        _xmlDatos.DocumentElement.SetAttribute("FormaP", FormaP);
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", CodUpdatePre);
        _xmlDatos.DocumentElement.SetAttribute("ActE", ActE);
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml,int.Parse(Request.Cookies["IdCom21Web"].Value)))
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);
                    }
    }
}