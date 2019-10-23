using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario oUsu = (Usuario)Session["Empleado"];

        if(oUsu == null)
        {
            oUsu = (Usuario)Session["Cliente"];
        }

        lblUsuario.Text = "Usuario: " + Convert.ToString(oUsu.nomUsu);

        if (oUsu is Empleado)
        {
            lblTipoUsuario.Text = "Tipo: Empleado";
            MenuEmpleado.Visible = true;
            MenuCliente.Visible = false;
        }
        else if (oUsu is Cliente)
        {
            lblTipoUsuario.Text = "Tipo: Cliente";
            MenuCliente.Visible = true;
            MenuEmpleado.Visible = false;
        }
        else
            lblTipoUsuario.Text = "";

    }

    protected void lbDeslogueo_Click(object sender, EventArgs e)
    {
        lblTipoUsuario.Text = "";
        lblUsuario.Text = "";
        Session["Empleado"] = null;
        Session["Cliente"] = null;
        Response.Redirect("Default.aspx");
    }

}