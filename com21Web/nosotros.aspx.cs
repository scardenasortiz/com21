using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class nosotros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarnosotros();
        }
    }
    private void cargarnosotros()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _nosotros = _consulta.Com21_consulta_nosotros();
        if (_nosotros.Tables[4].Rows.Count > 0)
        {
            foreach (DataRow r in _nosotros.Tables[4].Rows)
            {
                productos_web.InnerHtml = "<h2 class=\"desc grid-desc\" style=\"padding-left:20px; padding-right:20px\">" + r["Informacion"].ToString() + "</h2>";
            }
        }
    }
}