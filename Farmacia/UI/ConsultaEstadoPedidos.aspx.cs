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
        Cliente oCli = (Cliente)Session["Cliente"];
        int oNum = Convert.ToInt32(txtNumPedido.Text.Trim());

        //Por el momento, el cliente de session no va a funcionar, por tanto, coloco un nomUsu manualmente
        //LogicaPedido.Buscar(oCli.nomUsu, oNum);

        //TEMPORAL
        Pedido oPed = LogicaPedido.Buscar("Ramon", oNum);

        lblError.Text = oPed.ToString();
    }
}