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
                //codigo para mostrar TODOS los pedidos
                //tengo que mostrar TODOS los pedidos del medicamento SELECCIONADO
            }
            else if ((Convert.ToInt32(ddlEstadoPedido.SelectedValue)) == 1)
            {
                //codigo para mostrar los pedidos GENERADOS
                //tengo que mostrar los pedidos GENERADOS del medicamento SELECCIONADO
            }
            else
            {
                //codigo para mostrar los pedidos ENVIADOS
                //tengo que mostrar los pedidos ENVIADOS del medicamento SELECCIONADO
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}