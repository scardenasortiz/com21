using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class ejemplopru : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Pay pal process Refer for what are the variable are need to send http://www.paypalobjects.com/IntegrationCenter/ic_std-variable-ref-buy-now.html
 
        //    string redirectUrl = "";
 
        //    //Mention URL to redirect content to paypal site
        //    redirectUrl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();
 
        //    //First name I assign static based on login details assign this value
        //    redirectUrl += "&first_name=Andrea";
           
        //    //Product Name
        //    redirectUrl += "&item_name=Computadoras total";
 
        //    //Product Amount
        //    redirectUrl += "&amount=40";
 
        //    //Business contact paypal EmailID
        //    redirectUrl += "&business=ag_sobo-facilitator@hotmail.com";
 
        //    //Shipping charges if any, or available or using shopping cart system
        //    redirectUrl += "&shipping=5";
 
        //    //Handling charges if any, or available or using shopping cart system
        //    redirectUrl += "&handling=5";
 
        //    //Tax charges if any, or available or using shopping cart system
        //    redirectUrl += "&tax=5";
 
        //    //Quantiy of product, Here statically added quantity 1
        //    redirectUrl += "&quantity=1";
 
        //    //If transactioin has been successfully performed, redirect SuccessURL page- this page will be designed by developer
        //    redirectUrl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"].ToString();
 
        //    //If transactioin has been failed, redirect FailedURL page- this page will be designed by developer
        //    redirectUrl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"].ToString();
 
        //    Response.Redirect(redirectUrl);
        cambiarurl();
    }
    private void cambiarurl()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_productos();
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            String url = GenerateURLProducto(r["Titulo"] + "", r["Id_Producto"] + "", r["Id_Categoria"] + "", r["Id_SubCategoria"] + "", "P");
            if (_consulta.Com21_edita_productos_Url(url, int.Parse(r["Id_Producto"] + "")))
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
            }
            else
            {
            }
        }
    }
    public static string GenerateURLProducto(object Title, object strId, object strCat, object strSub, object strTipo)
    {

        string strTitle = Title.ToString();

        #region Generate SEO Friendly URL based on Title
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');

        strTitle = strTitle.ToLower();
        char[] chars = @"$%#@!*?;:´~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        strTitle = strTitle.Replace("c#", "C-Sharp");
        strTitle = strTitle.Replace("vb.net", "VB-Net");
        strTitle = strTitle.Replace("asp.net", "Asp-Net");
        strTitle = strTitle.Replace("á", "a");
        strTitle = strTitle.Replace("é", "e");
        strTitle = strTitle.Replace("í", "i");
        strTitle = strTitle.Replace("ó", "o");
        strTitle = strTitle.Replace("ú", "u");
        strTitle = strTitle.Replace("Á", "A");
        strTitle = strTitle.Replace("É", "E");
        strTitle = strTitle.Replace("Í", "I");
        strTitle = strTitle.Replace("Ó", "O");
        strTitle = strTitle.Replace("Ú", "U");
        strTitle = strTitle.Replace("ç", "c");
        strTitle = strTitle.Replace("Ç", "C");
        strTitle = strTitle.Replace("Ä", "A");
        strTitle = strTitle.Replace("Ë", "E");
        strTitle = strTitle.Replace("Ï", "I");
        strTitle = strTitle.Replace("Ö", "O");
        strTitle = strTitle.Replace("Ü", "U");
        strTitle = strTitle.Replace("ä", "a");
        strTitle = strTitle.Replace("ë", "e");
        strTitle = strTitle.Replace("ï", "i");
        strTitle = strTitle.Replace("ö", "o");
        strTitle = strTitle.Replace("ü", "u");

        //Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
                strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("-----", "-");
        strTitle = strTitle.Replace("----", "-");
        strTitle = strTitle.Replace("---", "-");
        strTitle = strTitle.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        strTitle = strTitle.Trim();

        //Trim "-" Hyphen
        strTitle = strTitle.Trim('-');


        #endregion

        //Append ID at the end of SEO Friendly URL
        strTitle = "" + strTitle + "-" + strId + "-" + strCat + "-" + strSub + "-" + strTipo + ".aspx";

        return strTitle;
    }
}