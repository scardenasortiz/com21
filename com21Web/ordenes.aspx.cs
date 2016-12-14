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

public partial class ordenes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
            {
                cargarOrdenes();
            }
            else
            {
                Response.Redirect("default.aspx");   
            }
        }
    }
    private void cargarOrdenes()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _ds = _consulta.consulta_ordenes(int.Parse(Request.Cookies["IdCom21Web"].Value));
        if (_ds.Tables[0].Rows.Count > 0)
        {
            pProductSi.Visible = true;
            pProductNo.Visible = false;
            GvCarrito.DataSource = _ds.Tables[0];
            GvCarrito.DataBind();
            
        }
        else
        {
            pProductSi.Visible = false;
            pProductNo.Visible = true;
            //productosN.InnerHtml = "No existen productos agregados a su carrito";
        }
    }
}