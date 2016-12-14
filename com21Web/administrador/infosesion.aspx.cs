using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using com21DLL;
using System.Data;

public partial class administrador_infosesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            contadores();  
        }
    }
    private void contadores()
    {
        ServicioCom21.ServicioCom21 _admin = new ServicioCom21.ServicioCom21();
        DataSet _cont = _admin.Com21_consulta_general_contador_admin();
        if(_cont.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[0].Rows)
            {
                lblcategorias.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[1].Rows)
            {
                lbladmin.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[7].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[7].Rows)
            {
                lblproductos.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[8].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[8].Rows)
            {
                lblpromopubli.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[10].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[10].Rows)
            {
                lblgaleria.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[11].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[11].Rows)
            {
                lblsubcategorias.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[12].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[12].Rows)
            {
                lblnosotros.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[13].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[13].Rows)
            {
                lblmisionvision.Text = r[0].ToString();
            }
        }
        if (_cont.Tables[14].Rows.Count > 0)
        {
            foreach (DataRow r in _cont.Tables[14].Rows)
            {
                lblmarca.Text = r[0].ToString();
            }
        }
    }
}