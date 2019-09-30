using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
//using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }

    protected void btnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Usuario oUsu = Logica.LogicaUsuario.Logueo(txtNomUsu.Text.Trim(), txtPass.Text.Trim());
            
            if(oUsu is EntidadesCompartidas.Empleado)
            {
                Session["Empleado"] = oUsu;
                Response.Redirect("Principal.aspx");
            }
            else if(oUsu is EntidadesCompartidas.Cliente)
            {
                Session["Cliente"] = oUsu;
                Response.Redirect("RealizarPedido.aspx");
            }
            else
            {
                lblError.Text = "Usuario inexistente";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}