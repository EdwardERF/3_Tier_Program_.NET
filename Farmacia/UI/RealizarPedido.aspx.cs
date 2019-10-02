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
        try
        {
            gvMedicamentos.DataSource = LogicaMedicamento.Listar();
            gvMedicamentos.DataBind();

            txtCantidad.Enabled = false;
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Int64 oRUC = Convert.ToInt64(gvMedicamentos.SelectedRow.Cells[0].Text.Trim());
            int oCodigo = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[1].Text.Trim());

            Medicamento oMed = LogicaMedicamento.Buscar(oRUC, oCodigo);

            if(oMed != null)
            {
                lblError.Text = oMed.ToString();

                List<Medicamento> oLista = new List<Medicamento>();
                oLista.Add(oMed);

                gvSeleccion.DataSource = oLista;
                gvSeleccion.DataBind();
            }
            else
            {
                lblError.Text = "";
                gvSeleccion.DataSource = null;
                gvSeleccion.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}