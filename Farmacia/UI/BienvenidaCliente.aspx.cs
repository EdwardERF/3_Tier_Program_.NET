using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class BienvenidaCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario oUsu = (Cliente)Session["Cliente"];
        lblBienvenidaCliente.Text = "Bienvenido, " + Convert.ToString(oUsu.nomUsu); 
    }
}