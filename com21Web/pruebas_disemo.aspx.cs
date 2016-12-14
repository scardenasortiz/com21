using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebas_disemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _dominio = Request.Url.AbsoluteUri;
        String _dominio1 = Request.Url.AbsolutePath;
        String _dominio2 = Request.UserHostName;
        String _dominio3 = Request.UserHostAddress;
        String _dominio4 = Request.Url.Authority;
        String _dominio5 = Request.Url.Scheme;
        Console.WriteLine(_dominio4);
        //host.InnerHtml = _dominio + ":" + _dominio1 + ":" + _dominio2 + ":" + _dominio3 + ":" + Request.Url.Authority;
    }
}