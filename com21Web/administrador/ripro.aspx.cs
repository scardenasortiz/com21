using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class administrador_ripro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarRPro();
        }
    }
    private void cargarRPro()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        String _ident = Request.QueryString["Ident"].ToString();
        switch (_ident)
        {
            case "0":
                DataSet _cat = _consulta.Com21_consulta_ResportesInicial();
                if (_cat.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _cat.Tables[0];
                    GvRProductos.DataBind();
                }
                lblbusqueda.Text = "General";
                break;
            case "1":
                int _ddl = int.Parse(Request.QueryString["Cant"].ToString());
                DataSet _cant = _consulta.Com21_consulta_Resportes(1, _ddl, "0", "0");
                if (_cant.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _cant.Tables[0];
                    GvRProductos.DataBind();
                }
                lblbusqueda.Text = "Cantidad";
                break;
            case "2":
                int _ddlcat = int.Parse(Request.QueryString["Cat"].ToString());
                DataSet _cats = _consulta.Com21_consulta_Resportes(2, _ddlcat, "0", "0");
                if (_cats.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _cats.Tables[0];
                    GvRProductos.DataBind();
                }
                lblbusqueda.Text = "Categoria";
                break;
            case "3":
                String _inicio = "";
                String _fin = "";
                int _ddls = int.Parse(Request.QueryString["Pre"].ToString());
                if (_ddls == 0)
                {
                    _inicio = "0";
                    _fin = "500.00";
                }
                if (_ddls == 1)
                {
                    _inicio = "500.01";
                    _fin = "800.00";
                }
                if (_ddls == 2)
                {
                    _inicio = "800.01";
                    _fin = "1000.00";
                }
                if (_ddls == 3)
                {
                    _inicio = "1000.01";
                    _fin = "1500.00";
                }
                if (_ddls == 4)
                {
                    _inicio = "1500.01";
                    _fin = "1500.01";
                }
                DataSet _pre = _consulta.Com21_consulta_Resportes(3, _ddls, _inicio, _fin);
                if (_pre.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _pre.Tables[0];
                    GvRProductos.DataBind();
                }
                lblbusqueda.Text = "Precio";
                break;
            default:
                int _ddlmar = int.Parse(Request.QueryString["Mar"].ToString());
                DataSet _mar = _consulta.Com21_consulta_Resportes(4, _ddlmar, "0", "0");
                if (_mar.Tables[0].Rows.Count > 0)
                {
                    GvRProductos.DataSource = _mar.Tables[0];
                    GvRProductos.DataBind();
                }
                lblbusqueda.Text = "Marca";
                break;
        }
    }
}