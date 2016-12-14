using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using com21DLL;

public partial class administrador_Default : System.Web.UI.Page
{
    private void ValidarIngresoPersona()
    {
        bool var = true;
        if (this.txt_usuario.Text == "")
        {
            var = false;
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "click", "alert('Debes de ingresar un Usuario!!! ');", true);
            return;
        }

        if (this.txt_password.Text == "")
        {
            var = false;
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "click", "alert('Debes de ingresar un Password!!! ');", true);
            return;
        }

        if (var == true)
        {
            Ingresa_Persona();
        }
        var = true;

    }
    private void Ingresa_Persona()
    {
        try
        {
            //System.Threading.Thread.Sleep(3000);
            ServicioCom21.ServicioCom21 _usuario = new ServicioCom21.ServicioCom21();
            //string claveCodificada = classMD5.encriptaClave(this.txt_password.Text);

            if (_usuario.valida_administrador(this.txt_usuario.Text, txt_password.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "click", "alert('El Usuario y Password ingresados son incorrectos');", true);
            }
            else
            {
                DataSet dsConsulta = new DataSet();
                dsConsulta = _usuario.consulta_id_admin(this.txt_usuario.Text, txt_password.Text);

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsConsulta.Tables[0].Rows)
                    {
                        Session["admin-id"] = dr[0].ToString();
                        Session["admin-user"] = txt_usuario.Text;
                    }
                }
                Session["admin"] = "admin";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "click", "window.location = \"items.aspx\";", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void BtnIniciarSesion_Click(object sender, EventArgs e)
    {
        this.ValidarIngresoPersona();
    }

}
