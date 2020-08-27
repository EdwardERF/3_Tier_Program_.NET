using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Persistencia;

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

            Medicamento oMed = LogicaMedicamento.Buscar(oRUC, oCodigo);

            gvSeleccion.DataSource = LogicaMedicamento.ListarMedicamentoUnico(oMed);
            gvSeleccion.DataBind();

            ActivarCalcularCosto();

            if(txtCantidad.Text != null)
            {
                btnConfirmar.Enabled = true;
            }
            else
            {
                btnConfirmar.Enabled = false;
            }
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
            if(Convert.ToInt32(txtCantidad.Text.Trim()) > 0)
            {
                int cantMedicamentos = Convert.ToInt32(txtCantidad.Text.Trim());
                int precio = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim());
                int costoFinal = cantMedicamentos * precio;

                lblCostoTotal.Text = "Costo del Pedido: $" + costoFinal;
            }
            else
            {
                lblCostoTotal.Text = "Debe ingresar un valor valido";
            }

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

            Cliente oCli = LogicaUsuario.BuscarCliente(oUsu.nomUsu);

            ruc = Convert.ToInt64(gvMedicamentos.SelectedRow.Cells[1].Text.Trim());
            codigo = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[2].Text.Trim());
            precio = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim());
            cantidad = Convert.ToInt32(txtCantidad.Text.Trim());

            Medicamento oMed = LogicaMedicamento.Buscar(ruc, codigo);

            Pedido oPed = new Pedido(0, cantidad, 0, oCli, oMed);

            LogicaPedido.Alta(oPed);
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            gvSeleccion.DataSource = null;
            gvSeleccion.DataBind();

            txtCantidad.Text = "";
            lblCostoTotal.Text = "";
            lblError.Text = "";

            txtCantidad.Enabled = false;

            btnCalcularCosto.Enabled = false;
            btnConfirmar.Enabled = false;

            Session["ListaCompleta"] = LogicaMedicamento.Listar();
            Session["Seleccion"] = new List<Medicamento>();

            gvMedicamentos.DataSource = (List<Medicamento>)Session["ListaCompleta"];
            gvMedicamentos.DataBind();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}