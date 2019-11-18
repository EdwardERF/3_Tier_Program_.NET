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
                Session["ListaCompleta"] = oLista;

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

            List<Medicamento> oLista = LogicaMedicamento.ListarMedicamentosXFarmaceutica(oFar.ruc);

            if(oLista != null)
            {
                gvListadoMedicamento.DataSource = oLista;
                gvListadoMedicamento.DataBind();
            }
            else
            {
                lblError.Text = oFar.nombre + " aun no tiene medicamentos asociados.";
            }
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

    protected void gvListadoMedicamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvListadoMedicamento.PageIndex = e.NewPageIndex;
        gvListadoMedicamento.DataSource = (List<Medicamento>)Session["ListaCompleta"];
        gvListadoMedicamento.DataBind();
    }

    protected void gvListadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvListadoPedidos.PageIndex = e.NewPageIndex;
        gvListadoPedidos.DataSource = (List<Pedido>)Session["ListaPedidos"];
        gvListadoPedidos.DataBind();
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
                oLista = null;
                oLista = LogicaPedido.ListarPedidosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();

                Session["ListaPedidos"] = oLista;

                if(oLista.Count == 0)
                {
                    lblError.Text = "Este medicamento (" + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[3].Text.Trim())) 
                        + ", Codigo " + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim())) + ") no tiene pedidos asociados";
                }
                else
                {
                    lblError.Text = "";
                }
            }
            else if ((Convert.ToInt32(ddlEstadoPedido.SelectedValue)) == 1)
            {
                Int64 oRUC = Convert.ToInt64(gvListadoMedicamento.SelectedRow.Cells[1].Text.Trim());
                int oCodigo = Convert.ToInt32(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim());

                List<Pedido> oLista = new List<Pedido>();
                oLista = null;
                oLista = LogicaPedido.ListarPedidosGeneradosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();

                Session["ListaPedidos"] = oLista;

                if (oLista.Count == 0)
                {
                    lblError.Text = "Este medicamento (" + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[3].Text.Trim()))
                        + ", Codigo " + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim())) + ") no tiene pedidos asociados en estado Generado";
                }
                else
                {
                    lblError.Text = "";
                }
            }
            else
            {
                Int64 oRUC = Convert.ToInt64(gvListadoMedicamento.SelectedRow.Cells[1].Text.Trim());
                int oCodigo = Convert.ToInt32(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim());

                List<Pedido> oLista = new List<Pedido>();
                oLista = null;
                oLista = LogicaPedido.ListarPedidosEnviadosXMedicamento(oRUC, oCodigo);

                gvListadoPedidos.DataSource = oLista;
                gvListadoPedidos.DataBind();

                Session["ListaPedidos"] = oLista;

                if (oLista.Count == 0)
                {
                    lblError.Text = "Este medicamento (" + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[3].Text.Trim()))
                        + ", Codigo " + (Convert.ToString(gvListadoMedicamento.SelectedRow.Cells[2].Text.Trim())) + ") no tiene pedidos asociados en estado Enviado";
                }
                else
                {
                    lblError.Text = "";
                }
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}