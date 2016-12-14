using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using System.Xml;

public partial class cancel : System.Web.UI.Page
{
    public String[] DataC;
    private void ConsultaDataCompra(int id)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet ds = _consulta.Com21_consulta_cliente_DatosCompra(id, 1);
        String data = "";
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            //idusuario+T+ActE+FormaP+CodUpdatePre
            data = r[1] + "" + "|" + r[2] + "" + "|" + r[3] + "" + "|" + r[4] + "" + "|" + r[5] + "";
        }
        ViewState["DataCompra"] = data;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        /*NameValueCollection coll = new NameValueCollection();
        coll = Request.Params;
        int i = coll.Count;
        String para = string.Empty;
        String npara = string.Empty;
        String result = string.Empty;
        for (int j = 0; j < coll.Count; j++)
        {
            para = coll.Get(j) + "";
            npara = coll.GetKey(j) + "";
            result = result + npara + ":" + para + "/;/";
        }*/
        if ((Request.Cookies["IdCom21Web"] != null) && (Request.Cookies["UserCom21Web"] != null) && (Request.Cookies["PassCom21Web"] != null) && (Request.Cookies["EmailCom21Web"] != null))
        {
            ConsultaDataCompra(int.Parse(Request.Cookies["IdCom21Web"].Value));
            String data = ViewState["DataCompra"] + "";
            DataC = data.Split('|');
            if (DataC.Length > 0)
            {            //idusuario+T+ActE+FormaP+CodUpdatePre
                if (DataC[3] + "" == "2")
                {
                    ActualizarDataCompra("0", "0", DataC[4] + "", "-1");
                    Response.Redirect("carritoreply.aspx");
                }
            }
        }
    }
    private void ActualizarDataCompra(string T, string FormaP, string CodUpdatePre, string ActE)
    {
        XmlDocument _xmlDatos = new XmlDocument();
        _xmlDatos.LoadXml("<Actualizar/>");
        _xmlDatos.DocumentElement.SetAttribute("IdUsuario", Request.Cookies["IdCom21Web"].Value);
        _xmlDatos.DocumentElement.SetAttribute("T", T);
        _xmlDatos.DocumentElement.SetAttribute("FormaP", FormaP);
        _xmlDatos.DocumentElement.SetAttribute("CodUpdatePre", CodUpdatePre);
        _xmlDatos.DocumentElement.SetAttribute("ActE", ActE);
        _xmlDatos.DocumentElement.SetAttribute("Inicio", "1");
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        if (_administrador.Com21_edita_cliente_DatosCompra(_xmlDatos.OuterXml, int.Parse(Request.Cookies["IdCom21Web"].Value)))
        { }
        else
        { }
    }
}