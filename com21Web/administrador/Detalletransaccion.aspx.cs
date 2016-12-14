using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_Detalletransaccion : System.Web.UI.Page
{
    ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.QueryString["IDT"] != null) && (Request.QueryString["IDU"] != null) && (Request.QueryString["CODUP"] != null))
            {
                cargarProPrefacturados();
                cargarFacturado();            
                cargarRDatos();
            }
            else
            {
                Response.Redirect("rtransacciones.aspx");
            }
            
        }
    }
    private void cargarRDatos()
    {
        if ((Request.QueryString["IDT"] != null) && (Request.QueryString["IDU"] != null) && (Request.QueryString["CODUP"] != null))
        {
            string _idt = Request.QueryString["IDT"].ToString();
            int idu = int.Parse(Request.QueryString["IDU"].ToString());
            DataSet _clie = _consulta.Com21_consulta_cliente_id(idu);
            if (_clie.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in _clie.Tables[0].Rows)
                {
                    lblnombres.Text = r["Nombres"].ToString();
                    lblapellidos.Text = r["Apellidos"].ToString();
                    lbldireccion.Text = r["Direccion"].ToString();

                    lbltelefono.Text = r["Telefono"].ToString();
                    lblcelular.Text = r["Celular"].ToString();
                    lblcorreo.Text = r["Correo"].ToString();
                    lblusuario.Text = r["Usuario"].ToString();
                    
                }
            }
        }
    }
    private void cargarProPrefacturados()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String idu = Request.QueryString["IDU"].ToString();
        String idcod = Request.QueryString["CODUP"].ToString();
        DataSet _ds = _consulta.consulta_producto_prefacturado_IdCod(int.Parse(idu),idcod);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            GvRProductos.DataSource = _ds.Tables[0];
            GvRProductos.DataBind();

            int i = 0;
            foreach (DataRow rs in _ds.Tables[0].Rows)
            {
                if (i == 0)
                {
                    hfact.Value = rs["ActCosto"].ToString();
                }
                i = i + 1;
            }
            if (hfact.Value == "1")
            {
                pActE.Visible = true;
                Sumar(_ds, 1);
            }
            else
            {
                pActE.Visible = false;
                Sumar(_ds, 2);
            }
        }
    }
    private void Sumar(DataSet ds, int d)
    {
        Decimal _tot = 0;
        Decimal _desc = 0;
        Decimal _totF = 0;
        Decimal _iva = 0;
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            _tot = _tot + decimal.Parse(r["Total"].ToString());
            _desc = _desc + decimal.Parse(r["Descuento"].ToString());

        }

        if (d == 1)
        {
            Decimal _costo = costoenvio();
            lblcosto.Text = "$" + _costo.ToString("0.00");

            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc + _costo;
        }
        else
        {
            lblcosto.Text = "$0,00";
            _iva = (_tot * 12) / 100;
            _totF = (_tot + _iva) - _desc;
        }

        lbliva.Text = "$" + Convert.ToString(_iva);

        lbltotalDesc.Text = "$" + Convert.ToString(_desc);

        lblsubtotal.Text = "$" + Convert.ToString(_tot);

        lbltotalF.Text = "$" + Convert.ToString(_totF);
    }
    private decimal costoenvio()
    {
        Decimal a = 0;
        int id = int.Parse(Request.QueryString["IDU"].ToString());
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.Com21_consulta_costo_IdUsuario_IdCiudad(id, 0);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[0].Rows)
            {
                a = decimal.Parse(r["Costo"].ToString().Replace(".", ","));
            }
        }
        else
        {

        }
        return a;
    }
    private void cargarFacturado()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_transaccion_facturada_IdT(Request.QueryString["IDT"].ToString());
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _ds.Tables[0].Rows)
            {
                if (Convert.ToBoolean(r["Facturado"].ToString()) == true)
                {
                    cbfacturado.Checked = true;
                }
                else
                {
                    cbfacturado.Checked = false;
                }
                if (hfact.Value == "1")
                {
                    lblnombrecontacto.Text = r["ContactoEnvio"].ToString();
                    lbltelefonoenvio.Text = r["TelefonoEnvio"].ToString();
                    DataSet _dsdire = _consulta.consulta_prefactura_trans_direccion(int.Parse(r["PaisEnvio"].ToString()), int.Parse(r["ProvinciaEnvio"].ToString()), int.Parse(r["CiudadEnvio"].ToString()));
                    if (_dsdire.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rs in _dsdire.Tables[0].Rows)
                        {
                            lbldireccionenvio.Text = r["DireccionEnvio"].ToString() + " Lugar: " + rs["Pais"].ToString() + "/" + rs["Provincia"].ToString() + "/" + rs["Ciudad"].ToString();
                        }
                    }
                }
                else
                {
                    pActE.Visible = false;
                }
                if (r["FormaPago"].ToString() == "1")
                {
                    lblformaP.Text = r["DescripcionFP"].ToString();
                    lblcodigotrans.Text = r["TransAutori"].ToString();
                    pcodtrans.Visible = true;
                }
                else
                {
                    lblformaP.Text = r["DescripcionFP"].ToString();
                    lblcodigotrans.Text = r["TransAutori"].ToString();
                    pcodtrans.Visible = false;
                }
                lblestado.Text = r["EstadoTransaccion"].ToString();
            }
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
                cargarProPrefacturados();
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
    protected void lblguardar_Click(object sender, EventArgs e)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Prefactura/>");
        if (cbfacturado.Checked == true)
        {
            _xmlDatos.DocumentElement.SetAttribute("Facturado", "1");
            _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Entregado");
        }
        else
        {
            _xmlDatos.DocumentElement.SetAttribute("Facturado", "0");
            _xmlDatos.DocumentElement.SetAttribute("EstadoTransaccion", "Solicitada");
        }

        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        if (_consulta.proc_edita_producto_prefacturado_Fact(_xmlDatos.OuterXml, Request.QueryString["IDT"].ToString()))
        {
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "click", "alert('Transaccion facturada con exito');", true);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("rtransacciones.aspx");
    }
}