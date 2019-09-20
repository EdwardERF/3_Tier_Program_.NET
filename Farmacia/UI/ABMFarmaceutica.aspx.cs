using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMFarmaceutica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.LimpioFormulario();
        }
    }

    protected void LimpioFormulario()
    {
        btnAlta.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        btnBuscar.Enabled = true;

        txtRuc.Enabled = true;

        txtRuc.Text = "";
        txtApto.Text = "";
        txtCalle.Text = "";
        txtCorreo.Text = "";
        txtNomFar.Text = "";
        txtNumero.Text = "";

        lblError.Text = "";
    }

    protected void ActivoBotonesA()
    {
        lblError.Text = "";

        btnAlta.Enabled = true;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        btnBuscar.Enabled = false;

        txtApto.Enabled = true;
        txtCalle.Enabled = true;
        txtCorreo.Enabled = true;
        txtNomFar.Enabled = true;
        txtNumero.Enabled = true;
    }

    protected void ActivoBotonesBM()
    {
        lblError.Text = "";

        btnAlta.Enabled = false;
        btnEliminar.Enabled = true;
        btnModificar.Enabled = true;

        btnBuscar.Enabled = false;

        txtApto.Enabled = true;
        txtCalle.Enabled = true;
        txtCorreo.Enabled = true;
        txtNomFar.Enabled = true;
        txtNumero.Enabled = true;
    }
}