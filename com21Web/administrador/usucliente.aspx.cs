using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using com21DLL;

public partial class administrador_usucliente : System.Web.UI.Page
{
    String savePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarUsuarios();
        }
    }
    private void cargarUsuarios()
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _scategoria = _consulta.Com21_consulta_cliente();
        if (_scategoria.Tables[0].Rows.Count > 0)
        {
            prosi.Visible = true;
            prono.Visible = false;
            //prosi.Visible = false;
            //prono.Visible = true;
            GvAdmin.DataSource = _scategoria.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            prosi.Visible = false;
            prono.Visible = true;
        }

    }
    private void cargarCompras()
    {
        ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
        DataSet dsCompras = _administrador.com21_clienteCom21_consulta_cliente_historial_compras(int.Parse(hfIdsuser.Value));
        if (dsCompras.Tables[0].Rows.Count > 0)
        {
            pSCompras.Visible = true;
            pNCompras.Visible = false;
            GvRTransacccion.DataSource = dsCompras.Tables[0];
            GvRTransacccion.DataBind();
        }
        else
        {
            pSCompras.Visible = false;
            pNCompras.Visible = true;
        }
    }
    #region "Eventos del GridView historial de compras"
    protected void GvRTransacccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvRTransacccion.PageIndex = e.NewPageIndex;
        //try
        //{
        //    if (idBuscar.Value == "0")
        //    {
        //        cargarRTransacciones();
        //    }
        //    if (idBuscar.Value == "3")
        //    {
        //        cargarIBFechas();
        //    }
        //    if (idBuscar.Value == "4")
        //    {
        //        cargarIBUsuario();
        //    }
        //}
        //catch { }
    }
    protected void GvRTransacccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow _gv = this.GvRTransacccion.SelectedRow;
        HiddenField _idt = default(HiddenField);
        HiddenField _idu = default(HiddenField);
        HiddenField _codUp = default(HiddenField);
        LinkButton _idt2 = default(LinkButton);


        _idt = (HiddenField)_gv.FindControl("IdTransaccion");
        _idu = (HiddenField)_gv.FindControl("IdUsuario");
        _codUp = (HiddenField)_gv.FindControl("CodUpdate");
        _idt2 = (LinkButton)_gv.FindControl("lbtransaccion");

        Response.Redirect("Detalletransaccion.aspx?IDT=" + _idt2.Text + "&IDU=" + _idu.Value + "&CODUP=" + _codUp.Value);
    }
    #endregion
    #region "parat de GV"
    protected void GvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAdmin.PageIndex = e.NewPageIndex;
        try
        {
            if (hfletra.Value != "")
            {
                txtbuscaradmin.Text = hfletra.Value;
                consultaletra(hfletra.Value);
            }
            else
            {
                cargarUsuarios();
            }
        }
        catch { }
    }
    protected void GvAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["envioslide"] = "editar";
            GridViewRow row = GvAdmin.SelectedRow;
            string Id_user = "";
            HiddenField cod = default(HiddenField);
            cod = (HiddenField)row.FindControl("Id_Clientes");
            Id_user = cod.Value;
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            DataSet ds = _administrador.Com21_consulta_cliente_id(int.Parse(Id_user));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //seteo todos los valores de la consulta especifica
                    this.hfIdsuser.Value = dr["Id_Clientes"].ToString();
                    Session["hfIdsuser"] = dr["Id_Clientes"].ToString();
                    this.lblusuario.Text = dr["Usuario"].ToString();
                    this.lblnombres.Text = dr["Nombres"].ToString();
                    lblapellidos.Text = dr["Apellidos"].ToString();
                    lblcorreo.Text = dr["Correo"].ToString();
                    lbltelefono.Text = dr["Telefono"].ToString();
                    lblcedula.Text = dr["Cedula"].ToString();
                    lblcelular.Text = dr["Celular"].ToString();
                    lbldireccion.Text = dr["Direccion"].ToString();
                    lblsexo.Text = dr["Sexo"].ToString();
                    //img.ImageUrl = dr[9].ToString();

                    //if (Convert.ToBoolean(dr[11].ToString()) == true)
                    //{
                    //    cbactivar.Checked = true;
                    //}
                    //else
                    //{
                    //    cbactivar.Checked = false;
                    //}
                }
                cargarCompras();
                //btnedit.Visible = true;
                //btninsert.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error Tecnico por favor espere unos minutos');", true);
        }
    }
    protected void GvAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Idadmin = GvAdmin.DataKeys[e.RowIndex].Value.ToString();
            ServicioCom21.ServicioCom21 _administrador = new ServicioCom21.ServicioCom21();
            if (_administrador.Com21_elimina_administrador(int.Parse(Idadmin)))
            {
                ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Error no se pudo Eliminar');", true);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Ciudad Eliminada');", true);
                //inactivar_productos(int.Parse(IdsCategorias));
            }
            //cargarsubcategoria();

        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('Problemas Tecnicos Por favor Comunicarse con el Administrador del Sitio');", true);
        }

    }
    #endregion
    #region "BUSCAR POR LETRA"
    private void consultaletra(string letra)
    {
        ServicioCom21.ServicioCom21 _consulta = new ServicioCom21.ServicioCom21();
        DataSet _letras = _consulta.Com21_consulta_cliente_letra(letra);
        if (_letras.Tables[0].Rows.Count > 0)
        {
            GvAdmin.DataSource = _letras.Tables[0];
            GvAdmin.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(upMantenimiento, upMantenimiento.GetType(), "click", "alert('No existen clientes para la busqueda: " + letra + "');", true);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        hfletra.Value = "A";
        consultaletra("A");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        hfletra.Value = "B";
        consultaletra("B");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        hfletra.Value = "C";
        consultaletra("C");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        hfletra.Value = "D";
        consultaletra("D");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        hfletra.Value = "E";
        consultaletra("E");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        hfletra.Value = "F";
        consultaletra("F");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        hfletra.Value = "G";
        consultaletra("G");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        hfletra.Value = "H";
        consultaletra("H");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        hfletra.Value = "I";
        consultaletra("I");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        hfletra.Value = "J";
        consultaletra("J");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        hfletra.Value = "K";
        consultaletra("K");
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        hfletra.Value = "L";
        consultaletra("L");
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        hfletra.Value = "M";
        consultaletra("M");
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        hfletra.Value = "N";
        consultaletra("N");
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Ñ";
        consultaletra("Ñ");
    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        hfletra.Value = "O";
        consultaletra("O");
    }
    protected void LinkButton17_Click(object sender, EventArgs e)
    {
        hfletra.Value = "P";
        consultaletra("P");
    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Q";
        consultaletra("Q");
    }
    protected void LinkButton19_Click(object sender, EventArgs e)
    {
        hfletra.Value = "R";
        consultaletra("R");
    }
    protected void LinkButton27_Click(object sender, EventArgs e)
    {
        hfletra.Value = "S";
        consultaletra("S");
    }
    protected void LinkButton20_Click(object sender, EventArgs e)
    {
        hfletra.Value = "T";
        consultaletra("T");
    }
    protected void LinkButton21_Click(object sender, EventArgs e)
    {
        hfletra.Value = "U";
        consultaletra("U");
    }
    protected void LinkButton22_Click(object sender, EventArgs e)
    {
        hfletra.Value = "V";
        consultaletra("V");
    }
    protected void LinkButton23_Click(object sender, EventArgs e)
    {
        hfletra.Value = "W";
        consultaletra("W");
    }
    protected void LinkButton24_Click(object sender, EventArgs e)
    {
        hfletra.Value = "X";
        consultaletra("X");
    }
    protected void LinkButton25_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Y";
        consultaletra("Y");
    }
    protected void LinkButton26_Click(object sender, EventArgs e)
    {
        hfletra.Value = "Z";
        consultaletra("Z");
    }
    protected void LinkButton28_Click(object sender, EventArgs e)
    {
        hfletra.Value = "";
        cargarUsuarios();
    }
    #endregion
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtbuscaradmin.Text.Length > 0)
        {
            string letra = txtbuscaradmin.Text;
            hfletra.Value = letra;
            consultaletra(letra);
        }
        else
        {
            cargarUsuarios();
        }
    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        hfletra.Value = "";
        txtbuscaradmin.Text = "";
        cargarUsuarios();
    }
}