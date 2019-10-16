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
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
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
}