using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class administrador_nosotro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarinfo();
        }
    }
    private void cargarinfo()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _provincias = _consulta.Com21_consulta_nosotros();
        if (_provincias.Tables[0].Rows.Count > 0)
        {
            mvsi.Visible = true;
            mvno.Visible = false;
            GvMV.DataSource = _provincias.Tables[0];
            GvMV.DataBind();
        }
        else
        {
            mvsi.Visible = false;
            mvno.Visible = true;
        }
        
    }
    protected void GvMV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvMV.PageIndex = e.NewPageIndex;
        try
        {
            cargarinfo();
        }
        catch { }
    }
    protected void GvMV_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvMV.SelectedRow;
            string Id_Info = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_EmpresaInfo");
            Id_Info = cod.Value;
            IdNosotrosInfo.Value = Id_Info;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_nosotros_id(int.Parse(Id_Info));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    Session["IdNosotrosInfo"] = dr[0].ToString();
                    this.IdNosotrosInfo.Value = dr[0].ToString();
                    this.txtinfo.Content = dr[1].ToString();
                    this.txttitulo.Text = dr[7].ToString();
                    if (Convert.ToBoolean(dr[8].ToString()) == true)
                    {
                        cbactivar.Checked = true;
                    }
                    else
                    {
                        cbactivar.Checked = false;
                    }
                }
                btnedit.Visible = true;
                btninsert.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvMV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string IdInfo = GvMV.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_nosotros(int.Parse(IdInfo)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro Eliminado');", true);
            }
            cargarinfo();
            
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            ingresoinfo();
        }
    }
    private int validadatos()
    {
        int pro = 0;
        if (txtinfo.Content.Length > 0)
        {
            pro = 1;
        }
        if (this.txttitulo.Text.Length > 0)
        {
            pro = 1;
        }
        return pro;
    }
    private void ingresoinfo()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Info/>");
            _xmlDatos.DocumentElement.SetAttribute("Informacion", txtinfo.Content);
            _xmlDatos.DocumentElement.SetAttribute("Pagina", "NO");
            _xmlDatos.DocumentElement.SetAttribute("Id_pagina", "2");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
            String des = HttpUtility.HtmlEncode(txtinfo.Content);
            _xmlDatos.DocumentElement.SetAttribute("DescripcionCorta", des);
                if (cbactivar.Checked == true)
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
                }
                else
                {
                    _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
                }
                ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
                XmlDocument _xmlResultado = new XmlDocument();
                DataSet _noso = _administrador.Com21_consulta_nosotros();
                if (_noso.Tables[0].Rows.Count == 0)
                {
                    if (_administrador.Com21_ingresa_nosotros(_xmlDatos.OuterXml))
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al ingresar Registro');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro ingresado con Exito');", true);

                    }
                    cargarinfo();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Un solo resgistro para nosotros');", true);
                    Limpiar();
                }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    private void Limpiar()
    {
        txtinfo.Content = "";
        txttitulo.Text = "";
        cbactivar.Checked = false;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        int pro = validadatos();
        if (pro == 1)
        {
            editainfo();
        }
    }
    private void editainfo()
    {
        try
        {

            XmlDocument _xmlDatos = new XmlDocument();
            _xmlDatos.LoadXml("<Ad_Info/>");
            _xmlDatos.DocumentElement.SetAttribute("Informacion", txtinfo.Content);
            _xmlDatos.DocumentElement.SetAttribute("Pagina", "NO");
            _xmlDatos.DocumentElement.SetAttribute("Id_pagina", "2");
            _xmlDatos.DocumentElement.SetAttribute("Titulo", txttitulo.Text);
            string des = HttpUtility.HtmlDecode(txtinfo.Content);
            _xmlDatos.DocumentElement.SetAttribute("DescripcionCorta", des);
            if (cbactivar.Checked == true)
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "1");
            }
            else
            {
                _xmlDatos.DocumentElement.SetAttribute("Activar", "0");
            }
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            XmlDocument _xmlResultado = new XmlDocument();
            //_xmlResultado.LoadXml(_usuario.Proc_Ingresa_Usuario(_xmlDatos.OuterXml));
            if (_administrador.Com21_edita_nosotros(_xmlDatos.OuterXml, int.Parse(IdNosotrosInfo.Value)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error al editar Registro');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Registro editado con Exito');", true);
                btninsert.Visible = true;
                btnedit.Visible = false;
                
            }
            cargarinfo();
            Limpiar();
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    
}