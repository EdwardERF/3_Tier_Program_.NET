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
                //SE DEJA COMENTADA LA LINEA QUE TOMA LOS DATOS POR SESION. CAMBIAR
                //Session["ListaCompleta"] = LogicaPedido.ListarGenerados(oCli.nomUsu);
                Session["ListaCompleta"] = LogicaPedido.ListarGenerados("Ramon");
                Session["Seleccion"] = new List<Pedido>();

                gvListadoPedidos.DataSource = (List<Pedido>)Session["ListaCompleta"];
                gvListadoPedidos.DataBind();
                gvSeleccion.DataSource = (List<Pedido>)Session["Seleccion"];
                gvSeleccion.DataBind();
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

        try
        {
            //COMENTADO LA INSTANCIA POR SESION
            //Cliente oCli = (Cliente)Session["Cliente"];
            int oNum = Convert.ToInt32(gvListadoPedidos.SelectedRow.Cells[1].Text.Trim());
            string oCli = "Ramon";

            List<Pedido> oLista = new List<Pedido>();
            oLista.Add(LogicaPedido.Buscar(oCli, oNum));

            gvSeleccion.DataSource = oLista;
            gvSeleccion.DataBind();

            lblCliente.Text = (LogicaPedido.Buscar(oCli, oNum)).ToString();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
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
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}