using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cerrarsession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_elimina_cliente_DatosCompra(int.Parse(Request.Cookies["IdCom21Web"].Value)))
        {
        }*/

        if (Request.Cookies["IdCom21Web"] != null)
        {
            HttpCookie myCookie = new HttpCookie("IdCom21Web");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["UserCom21Web"] != null)
        {
            HttpCookie myCookie = new HttpCookie("UserCom21Web");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["PassCom21Web"] != null)
        {
            HttpCookie myCookie = new HttpCookie("PassCom21Web");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["EmailCom21Web"] != null)
        {
            HttpCookie myCookie = new HttpCookie("EmailCom21Web");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["CodUpdatePre"] != null)
        {
            HttpCookie myCookie = new HttpCookie("CodUpdatePre");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["FormaP"] != null)
        {
            HttpCookie myCookie = new HttpCookie("FormaP");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["ActE"] != null)
        {
            HttpCookie myCookie = new HttpCookie("ActE");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (Request.Cookies["T"] != null)
        {
            HttpCookie myCookie = new HttpCookie("T");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        Response.Redirect("Default.aspx");
    }
}