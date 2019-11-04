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

            ddlPedidos.DataSource = LogicaPedido.ListarNumeroXCliente(oCli.nomUsu);
            ddlPedidos.DataBind();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario oUsu = (Usuario)Session["Cliente"];

            int oNum = Convert.ToInt32(ddlPedidos.SelectedValue);

            Pedido oPed = LogicaPedido.Buscar(oUsu.nomUsu, oNum);

            if(oPed != null)
            {
                lblError.Text = oPed.ToString();
            }
            else
            {
                lblError.Text = "El pedido que busca no existe o no esta asociado a usted";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}