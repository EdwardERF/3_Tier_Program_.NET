using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Persistencia;

public partial class CambioEstadoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                Session["ListaCompleta"] = LogicaPedido.ListarGeneradosYEnviados();

                gvEstadoPedido.DataSource = (List<Pedido>)Session["ListaCompleta"];
                gvEstadoPedido.DataBind();

                btnCambiarEstado.Visible = true;
                btnCambiarEstado.Enabled = false;
                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;
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

        Cliente oCli = LogicaUsuario.BuscarCliente(nomUsu);
        Medicamento oMed = LogicaMedicamento.Buscar(rucMedicamento, codMedicamento);

        Pedido oPed = new Pedido(numero, cantidad, estado, oCli, oMed);

        lblError.Text = oPed.ToString();

        btnCambiarEstado.Enabled = true;
    }

    protected void gvEstadoPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEstadoPedido.PageIndex = e.NewPageIndex;
        gvEstadoPedido.DataSource = (List<Pedido>)Session["ListaCompleta"];
        gvEstadoPedido.DataBind();
    }

    protected void btnCambiarEstado_Click(object sender, EventArgs e)
    {
        int numero = Convert.ToInt32(gvEstadoPedido.SelectedRow.Cells[1].Text.Trim());

        try
        {
            AlternarBotones();

            LogicaPedido.CambioEstadoPedido(numero);

            //lblError.Text = "Cambio de Estado realizado";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void AlternarBotones()
    {
        btnCambiarEstado.Visible = false;
        btnActualizar.Visible = true;
        btnActualizar.Enabled = true;
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ListaCompleta"] = LogicaPedido.ListarGeneradosYEnviados();

            gvEstadoPedido.DataSource = (List<Pedido>)Session["ListaCompleta"];
            gvEstadoPedido.DataBind();

            btnCambiarEstado.Visible = true;
            btnCambiarEstado.Enabled = false;
            btnActualizar.Visible = false;
            btnActualizar.Enabled = false;

            lblError.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}