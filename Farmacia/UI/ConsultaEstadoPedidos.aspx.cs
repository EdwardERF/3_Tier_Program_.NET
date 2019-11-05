using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ConsultaEstadoPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Cliente oCli = (Cliente)Session["Cliente"];
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int oNum = Convert.ToInt32(txtNumPedido.Text.Trim());

            Pedido oPed = LogicaPedido.BuscarPorNumero(oNum);

            if(oPed != null)
            {
                lblError.Text = oPed.ToString();
            }
            else
            {
                lblError.Text = "El pedido que busca no existe";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lbVolver_Click(object sender, EventArgs e)
    {
        Usuario oUsu = null;

        oUsu = (Usuario)Session["Cliente"];

        if (oUsu == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("BienvenidaCliente.aspx");
        }
    }
}