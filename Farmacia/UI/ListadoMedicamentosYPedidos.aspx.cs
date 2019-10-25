using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListadoMedicamentosYPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                List<string> oLista = LogicaFarmaceutica.ListarFarmaceuticas();

                ddlListadoMedicamento.DataSource = oLista;
                ddlListadoMedicamento.DataBind();

                lblSeleccionEstado.Visible = false;
                ddlEstadoPedido.Visible = false;
                btnMostrarPedidos.Visible = false;
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            string Seleccion = ddlListadoMedicamento.SelectedValue;

            Farmaceutica oFar = LogicaFarmaceutica.BuscarXNombre(Seleccion);

            gvListadoMedicamento.DataSource = LogicaMedicamento.ListarMedicamentosXFarmaceutica(oFar.ruc);
            gvListadoMedicamento.DataBind();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnTodos_Click(object sender, EventArgs e)
    {
        try
        {
            string Seleccion = ddlListadoMedicamento.SelectedValue;

            Farmaceutica oFar = LogicaFarmaceutica.BuscarXNombre(Seleccion);

            gvListadoMedicamento.DataSource = LogicaMedicamento.ListarMedicamentosXFarmaceutica(oFar.ruc);
            gvListadoMedicamento.DataBind();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvListadoMedicamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblSeleccionEstado.Visible = true;
            ddlEstadoPedido.Visible = true;
            btnMostrarPedidos.Visible = true;

            gvListadoPedidos.DataSource = null;
            gvListadoPedidos.DataBind();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnMostrarPedidos_Click(object sender, EventArgs e)
    {
        try
        {
            if((Convert.ToInt32(ddlEstadoPedido.SelectedValue)) == 0)
            {
                Int64 oRUC = Convert.ToInt64(gvListadoMedicamento.SelectedRow.Cells[1].Text.Trim());
                int oCodigo = Convert.ToInt32(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim());

                List<Pedido> oLista = new List<Pedido>();
                oLista = LogicaPedido.ListarPedidosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();
            }
            else if ((Convert.ToInt32(ddlEstadoPedido.SelectedValue)) == 1)
            {
                Int64 oRUC = Convert.ToInt64(gvListadoMedicamento.SelectedRow.Cells[1].Text.Trim());
                int oCodigo = Convert.ToInt32(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim());

                List<Pedido> oLista = new List<Pedido>();
                oLista = LogicaPedido.ListarPedidosGeneradosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();
            }
            else
            {
                Int64 oRUC = Convert.ToInt64(gvListadoMedicamento.SelectedRow.Cells[1].Text.Trim());
                int oCodigo = Convert.ToInt32(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim());

                List<Pedido> oLista = new List<Pedido>();
                oLista = LogicaPedido.ListarPedidosEnviadosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}