using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class CambioEstadoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                Usuario oUsu = (Cliente)Session["Cliente"];
                /* Session["ListaCompleta"] = LogicaPedido.ListarGeneradosYEnviados(oUsu.nomUsu); 
                Me va a generar el error: 'Referencia a objeto no establecida como instancia de un objeto' hasta que deje
                funcionando todas las sesiones; si se coloca un usuario manualmente en vez del usuario de sesion, la GV
                funciona. */

                Session["ListaCompleta"] = LogicaPedido.ListarGeneradosYEnviados("Ramon");

                gvEstadoPedido.DataSource = (List<Pedido>)Session["ListaCompleta"];
                gvEstadoPedido.DataBind();

                btnCambiarEstado.Enabled = false;
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void gvEstadoPedido_SelectedIndexChanged(object sender, EventArgs e)
    {
        int numero = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[1].Text.Trim());
        string nomUsu = gvEstadoPedido.SelectedRow.Cells[2].Text.Trim();
        Int64 rucMedicamento = Convert.ToInt64(gvEstadoPedido.SelectedRow.Cells[3].Text.Trim());
        int codMedicamento = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[4].Text.Trim());
        int cantidad = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[5].Text.Trim());
        int estado = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[6].Text.Trim());

        Pedido oPed = new Pedido(numero, nomUsu, rucMedicamento, codMedicamento, cantidad, estado);

        lblError.Text = oPed.ToString();

        btnCambiarEstado.Enabled = true;
    }

    protected void btnCambiarEstado_Click(object sender, EventArgs e)
    {
        int numero = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[1].Text.Trim());

        try
        {
            LogicaPedido.CambioEstadoPedido(numero);

            lblError.Text = "Cambio de Estado realizado";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}