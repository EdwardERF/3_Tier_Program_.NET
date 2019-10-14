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
                //ddlListadoMedicamento.DataTextField = "nombre";
                ddlListadoMedicamento.DataBind();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void ddlListadoMedicamento_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}