using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using com21DLL;
using System.Net.Mail;

public partial class anapp_registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarDatos();
            String estado = Request.QueryString["Estado"];
            String nom = Request.QueryString["Nom"];
            String ape = Request.QueryString["Ape"];
            String email = Request.QueryString["Co"];
            if (estado != null)
            {
                PresentarMensaje(estado);
                if((nom != null) || (ape != null) || (email != null))
                {
                    txtnombre.Text = nom;
                    txtapellidos.Text = ape;
                    txtcorreo.Text = email;
                }
            }
        }
    }
    protected void btnValidar_Click(object sender, EventArgs e)
    {
    }
    private void PresentarMensaje(string E)
    {
        switch (E)
        {
            case "2":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Correo ingresado invalido";
                break;
            case "4":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Por favor ingrese todo los campos";
                break;
            case "3":
                pMensajesAlertas.Visible = true;
                DMensaje.Attributes.Add("class", "error");
                DMensaje.InnerText = "Correo ingresado ya existe para una cuenta";
                break;
        }
    }
    private void limpiar()
    {
        txtnombre.Text = "";
        txtcorreo.Text = "";
        txtapellidos.Text = "";
    }
    private int Validar()
    {
        int i = 1;
        if (txtnombre.Text.Length == 0)
        {
            i = 0;
        }
        if (txtcorreo.Text.Length == 0)
        {
            i = 0;
        }
        if (txtapellidos.Text.Length == 0)
        {
            i = 0;
        }
        return i;
    }
    private void Redireccionar(String E)
    {
        string url = string.Empty;
        String estado = Request.QueryString["Estado"];
        if (estado != null)
        {
            url = Request.Url.AbsoluteUri;
            String[] array = url.Split('?');
            if (E == "1")
            {
                url = "registroSi.aspx" + "?Nom=" + txtnombre.Text + "&Ape=" + txtapellidos.Text + "&Co=" + txtcorreo.Text + "&Ds=" + ddlsexo.SelectedValue;
            }
            else
            {
                url = array[0] + "?Estado=" + E + "&Nom=" + txtnombre.Text + "&Ape=" + txtapellidos.Text + "&Co=" + txtcorreo.Text + "&Ds=" + ddlsexo.SelectedValue;
            }
        }
        else
        {
            url = Request.Url.AbsoluteUri;
            if (E == "1")
            {
                url = "registroSi.aspx" + "?Nom=" + txtnombre.Text + "&Ape=" + txtapellidos.Text + "&Co=" + txtcorreo.Text + "&Ds=" + ddlsexo.SelectedValue;
            }
            else
            {
                url = url + "?Estado=" + E + "&Nom=" + txtnombre.Text + "&Ape=" + txtapellidos.Text + "&Co=" + txtcorreo.Text + "&Ds=" + ddlsexo.SelectedValue;
            }
        }
        Response.Redirect(url,false);
    }
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        int i = Validar();
        if (i > 0)
        {
            if (email_bien_escrito(txtcorreo.Text))
            {
                ServicioCom21.ServicioCom21 _app = new ServicioCom21.ServicioCom21();
                DataSet ds = _app.Com21_consulta_recuperar_clave_cliente(txtcorreo.Text,"2");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Redireccionar("3");
                }
                else
                {
                    Redireccionar("1");
                }
            }
            else
            {
                Redireccionar("2");
            }
        }
        else
        {
            Redireccionar("4");
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx",false);
    }
}