using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ListadoPedidosGenerados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                Cliente oCli = (Cliente)Session["Cliente"];
                Session["ListaCompleta"] = LogicaPedido.ListarGeneradosXCliente(oCli.nomUsu);
                Session["Seleccion"] = new List<Pedido>();

                gvListadoPedidos.DataSource = (List<Pedido>)Session["ListaCompleta"];
                gvListadoPedidos.DataBind();
                gvSeleccion.DataSource = (List<Pedido>)Session["Seleccion"];
                gvSeleccion.DataBind();

                btnEliminar.Enabled = false;
                btnActualizar.Visible = false;
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void gvListadoPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow R = gvListadoPedidos.SelectedRow;
        R.BackColor = System.Drawing.Color.Aqua;

        btnEliminar.Visible = true;
        btnEliminar.Enabled = true;

        try
        {
            Usuario oCli = (Usuario)Session["Cliente"];
            int oNum = Convert.ToInt32(gvListadoPedidos.SelectedRow.Cells[1].Text.Trim());

            List<Pedido> oLista = new List<Pedido>();
            oLista.Add(LogicaPedido.Buscar(oCli.nomUsu, oNum));

            gvSeleccion.DataSource = oLista;
            gvSeleccion.DataBind();

            btnEliminar.Enabled = true;
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvListadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvListadoPedidos.PageIndex = e.NewPageIndex;
        gvListadoPedidos.DataSource = (List<Pedido>)Session["ListaCompleta"];
        gvListadoPedidos.DataBind();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int oNum = -1;
        try
        {
            oNum = Convert.ToInt32(gvListadoPedidos.SelectedRow.Cells[1].Text.Trim());
        }
        catch
        {
            lblError.Text = "No existe o no ha seleccionado ningun pedido para eliminar";
        }

        if (oNum != -1)
        {
            try
            {
                LogicaPedido.Eliminar(oNum);

                lblError.Text = "Eliminacion exitosa";

                AlternarBotones();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void AlternarBotones()
    {
        btnActualizar.Visible = true;
        btnActualizar.Enabled = true;
        btnEliminar.Visible = false;
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCli = (Cliente)Session["Cliente"];
            Session["ListaCompleta"] = LogicaPedido.ListarGeneradosXCliente(oCli.nomUsu);
            Session["Seleccion"] = new List<Pedido>();

            gvListadoPedidos.DataSource = (List<Pedido>)Session["ListaCompleta"];
            gvListadoPedidos.DataBind();
            gvSeleccion.DataSource = (List<Pedido>)Session["Seleccion"];
            gvSeleccion.DataBind();

            btnEliminar.Visible = true;
            btnEliminar.Enabled = false;
            btnActualizar.Visible = false;

            lblError.Text = "";
            lblCliente.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}