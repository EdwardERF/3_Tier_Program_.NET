using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMFarmaceutica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.LimpioFormulario();
            this.DesactivoValidadores();
        }
    }

    protected void LimpioFormulario()
    {
        btnAlta.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        btnBuscar.Enabled = true;

        txtRuc.Enabled = true;

        txtNomFar.Enabled = false;
        txtCorreo.Enabled = false;
        txtCalle.Enabled = false;
        txtNumero.Enabled = false;
        txtApto.Enabled = false;

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

    protected void ActivoValidadores()
    {
        valtxtruc.Enabled = true;

        valtxtnombre.Enabled = true;
        valtxtcorreo.Enabled = true;
        valtxtcalle.Enabled = true;
        valtxtnumero.Enabled = true;
    }

    protected void DesactivoValidadores()
    {
        valtxtnombre.Enabled = false;
        valtxtcorreo.Enabled = false;
        valtxtcalle.Enabled = false;
        valtxtnumero.Enabled = false;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 oRUC = Convert.ToInt64(txtRuc.Text);

            Farmaceutica oFar = Logica.LogicaFarmaceutica.Buscar(oRUC);

            if (oFar != null)
            {
                this.ActivoBotonesBM();
                this.ActivoValidadores();

                txtRuc.Text = Convert.ToString(oFar.ruc);
                txtNomFar.Text = Convert.ToString(oFar.nombre);
                txtCorreo.Text = Convert.ToString(oFar.correo);
                txtCalle.Text = Convert.ToString(oFar.calle);
                txtNumero.Text = Convert.ToString(oFar.numero);
                txtApto.Text = Convert.ToString(oFar.apto);

                Session["FarmaceuticaABM"] = oFar;

                lblError.Text = "";
            }
            else
            {
                this.ActivoBotonesA();
                this.ActivoValidadores();
                Session["FarmaceuticaABM"] = null;
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Farmaceutica oFar = new Farmaceutica(Convert.ToInt64(txtRuc.Text), txtNomFar.Text.Trim(), txtCorreo.Text.Trim(), txtCalle.Text.Trim(), Convert.ToInt32(txtNumero.Text), Convert.ToInt32(txtApto.Text));

            btnAlta.Enabled = false;
            btnBuscar.Enabled = false;

            Logica.LogicaFarmaceutica.Alta(oFar);

            lblError.Text = "Alta exitosa";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Farmaceutica oFar = (Farmaceutica)Session["FarmaceuticaABM"];

            oFar.nombre = txtNomFar.Text.Trim();
            oFar.correo = txtCorreo.Text.Trim();
            oFar.calle = txtCalle.Text.Trim();
            oFar.numero = Convert.ToInt32(txtNumero.Text.Trim());
            oFar.apto = Convert.ToInt32(txtApto.Text.Trim());

            Logica.LogicaFarmaceutica.Modificar(oFar);
            this.LimpioFormulario();
            lblError.Text = "Modificacion exitosa";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Farmaceutica oFar = (Farmaceutica)Session["FarmaceuticaABM"];

            Logica.LogicaFarmaceutica.Eliminar(oFar.ruc);

            this.LimpioFormulario();

            lblError.Text = "Eliminacion exitosa";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
        this.DesactivoValidadores();
    }
}