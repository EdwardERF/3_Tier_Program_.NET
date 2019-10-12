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
                List<Farmaceutica> oLista = LogicaFarmaceutica.ListarFarmaceuticas();

                int i = oLista.Count;

                throw new Exception("Ruc: " + oLista.Select<0,0>);

                while(i <= oLista.Count)
                {
                    ListItem Item = new ListItem(Convert.ToString(i), Convert.ToString(oLista[i]));
                    ddlListadoMedicamento.Items.Add(Item);
                    i++;
                }

                ddlListadoMedicamento.DataSource = oLista;
                ddlListadoMedicamento.DataTextField = "nombre";
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