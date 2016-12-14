using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class timer_prueba_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // this.timers.InnerHtml = cargatimer();
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = "UpdatePanel1 refreshed at: " +
          DateTime.Now.ToLongTimeString();
        Label2.Text = "UpdatePanel2 refreshed at: " +
          DateTime.Now.ToLongTimeString();
    }
    //public String cargatimer()
    //{
    //    string timertiempo;
    //    return timertiempo;
    //}
}