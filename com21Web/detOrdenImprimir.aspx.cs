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

public partial class detOrden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                DataSet ds = cargarFA();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if ((r["FormaPago"].ToString() != "0") && (Request.QueryString["T"].ToString() != "0"))
                    {
                        int i = int.Parse(r["FormaPago"].ToString());
                        if (i == 0)
                        {
                            pSinCosto.Visible = true;
                            pConCosto.Visible = false;
                            //cambiarCodUpdate();
                        }
                        else
                        {
                            if (i == 1)
                            {
                                if (r["ActCosto"].ToString() == "1")
                                {
                                    pSinCosto.Visible = false;
                                    pConCosto.Visible = true;
                                    pEnvioAct.Visible = true;
                                }
                                else
                                {
                                    pSinCosto.Visible = true;
                                    pConCosto.Visible = false;
                                    pEnvioAct.Visible = false;
                                }
                            }
                            else
                            {
                                if (r["ActCosto"].ToString() == "1")
                                {
                                    pSinCosto.Visible = false;
                                    pConCosto.Visible = true;
                                    pEnvioAct.Visible = true;
                                }
                                else
                                {
                                    pSinCosto.Visible = true;
                                    pConCosto.Visible = false;
                                    pEnvioAct.Visible = false;
                                }
                            }
                        }
                        cargarCarrito(r["CodUpdate"].ToString(), r["ActCosto"].ToString());
                        recibeDatos(int.Parse(r["ActCosto"].ToString()), i);
                    }
                    else
                    {
                        Response.Redirect("default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx");   
            }
        }
    }
    public String[] DataC;
    private DataSet cargarFA()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String T = Request.QueryString["T"].ToString();
        String Cod = Request.QueryString["Cod"].ToString();
        DataSet ds = _consulta.consulta_detalle_orden(int.Parse(Request.Cookies["IdCom21Web"].Value),T,Cod);
        return ds;
    }
    private void cargarCarrito(String cod, String acte)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_producto_prefacturado_IdCod(int.Parse(Request.Cookies["IdCom21Web"].Value), cod);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            pProductSi.Visible = true;
            pProductNo.Visible = false;
            GvCarrito.DataSource = _ds.Tables[0];
            GvCarrito.DataBind();
            sumarTD(_ds,acte);
        }
    }
    private void sumarTD(DataSet ds, String acte)
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

        if (acte == "1")
        {
            Decimal _costo = costoenvio();
            sCostoEnv.InnerHtml = Convert.ToString(_costo.ToString("0.00"));

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
    }
    private decimal costoenvio()
    {
        Decimal a = 0;
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
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
    private void recibeDatos(int acte, int forma)
    {
        //cargarFA();
        if (forma == 1)
        {
            lblformaP.Text = "Transferencia";
        }
        
        cargarDatos();
        if (acte != 0)
        {
           cargarDireccionEnvio();
        }
    }
    private String cargarNombreApe()
    {
        String nom_ape = "";
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_cliente_id(id);
        if (_user.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _user.Tables[0].Rows)
            {
                nom_ape = r["Nombres"].ToString() + " " + r["Apellidos"].ToString();
            }
        }
        return nom_ape;
    }
    private void cargarDatos()
    {
        int id = int.Parse(Request.Cookies["IdCom21Web"].Value);
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _user = _consulta.Com21_consulta_cliente_id(id);
        if (_user.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _user.Tables[0].Rows)
            {
                lblnombres.Text = r["Nombres"].ToString();
                lblapellidos.Text = r["Apellidos"].ToString();
            }
        }
    }
    private void cargarDireccionEnvio()
    {
        string id = Request.Cookies["IdCom21Web"].Value;
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _direccion = _consulta.Com21_consulta_cliente_direccio_envio(int.Parse(id));
        if (_direccion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _direccion.Tables[0].Rows)
            {
                direccion.Text = "" + r["Direccion"].ToString() + ", Lugar de envio: " + r["Pais"].ToString() + "/" + r["Provincia"].ToString() + "/" + r["Ciudad"].ToString();
                lbltelefonoenvio.Text = r["Telefono"].ToString();
                lblnombreenvio.Text = r["ContactoNombre"].ToString();
            }
        }        
    }
    private void abreVentana(string ventana)
    {
        string Clientscript = "<script>window.open('" +
                              ventana +
                              "')</script>";

        if (!this.IsStartupScriptRegistered("WOpen"))
        {
            this.RegisterStartupScript("WOpen", Clientscript);
        }
    }
}