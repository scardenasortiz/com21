using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Capturo para asignarlos 
        NameValueCollection coll = new NameValueCollection();
        coll = Request.Params;
        int i = coll.Count;
        String para = string.Empty;
        String npara = string.Empty;
        String result = string.Empty;
        for (int j = 0; j < coll.Count; j++)
        {
            para = coll.Get(j)+"";
            npara = coll.GetKey(j) + "";
            result = result + npara +":"+para +"/;/";
        }
        presentar.InnerHtml = result;
    }
}