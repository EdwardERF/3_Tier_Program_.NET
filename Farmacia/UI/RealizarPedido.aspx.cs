using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class RealizarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                Session["ListaCompleta"] = LogicaMedicamento.Listar();
                Session["Seleccion"] = new List<Medicamento>();

                gvMedicamentos.DataSource = (List<Medicamento>)Session["ListaCompleta"];
                gvMedicamentos.DataBind();
                gvSeleccion.DataSource = (List<Medicamento>)Session["Seleccion"];
                gvMedicamentos.DataBind();

                txtCantidad.Enabled = false;
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
    }

    protected void gvMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow R = gvMedicamentos.SelectedRow;
        R.BackColor = System.Drawing.Color.Aqua;

        try
        {
            Int64 oRUC = Convert.ToInt64(gvMedicamentos.SelectedRow.Cells[1].Text.Trim());
            int oCodigo = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[2].Text.Trim());

            gvSeleccion.DataSource = LogicaMedicamento.ListarMedicamentoUnico(oRUC, oCodigo);
            gvSeleccion.DataBind();

            ActivarCalcularCosto();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void ActivarCalcularCosto()
    {
        txtCantidad.Enabled = true;
        btnCalcularCosto.Enabled = true;
    }

    protected void gvMedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMedicamentos.PageIndex = e.NewPageIndex;
        gvMedicamentos.DataSource = (List<Medicamento>)Session["ListaCompleta"];
        gvMedicamentos.DataBind();
    }

    protected void btnCalcularCosto_Click(object sender, EventArgs e)
    {
        try
        {
            int precio = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim());
            int costoFinal = Convert.ToInt32(txtCantidad.Text.Trim()) * precio;

            lblCostoTotal.Text = "Costo del Pedido: $" + costoFinal;
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 ruc;
            int codigo, precio, cantidad;
            Usuario oUsu;

            oUsu = (Usuario)Session["Cliente"];

            //Usuario oUsu = LogicaUsuario.BuscarUsuario("admin");

            ruc = Convert.ToInt64(gvMedicamentos.SelectedRow.Cells[1].Text.Trim());
            codigo = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[2].Text.Trim());
            precio = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim());
            cantidad = Convert.ToInt32(txtCantidad.Text.Trim());

            Pedido oPed = new Pedido(oUsu.nomUsu, ruc, codigo, cantidad, 0);

            LogicaPedido.Alta(oPed);
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}