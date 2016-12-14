using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarmv();
        }
    }
    private void cargarmv()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _nosotros = _consulta.Com21_consulta_nosotros();
        if (_nosotros.Tables[5].Rows.Count > 0)
        {
            String _generar = "";
            foreach (DataRow r in _nosotros.Tables[5].Rows)
            {
                _generar = _generar + "<div class=\"padding-s\"><div class=\"page-title category-title\"><h1>" + r["Titulo"].ToString() + "</h1></div>" +
                "<div class=\"category-products\"><h2 class=\"desc grid-desc\" style=\"padding-left:20px; padding-right:20px\">" + r["Informacion"].ToString() + "</h2></div></div>";
            }
            info_empresa.InnerHtml = _generar;
        }
    }
}