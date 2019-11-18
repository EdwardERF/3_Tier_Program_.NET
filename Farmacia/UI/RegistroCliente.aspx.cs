using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class RegistroCliente : System.Web.UI.Page
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
        btnBuscar.Enabled = true;
        txtNomUsu.Enabled = true;

        btnAlta.Enabled = false;

        txtPass.Enabled = false;
        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        txtDireccion.Enabled = false;
        txtTelefono.Enabled = false;

        txtNomUsu.Text = "";
        txtPass.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";

        lblError.Text = "";

        btnAlta.Visible = true;
        btnActualizar.Visible = false;
    }

    protected void ActivoBotonesA()
    {
        btnAlta.Enabled = true;
        btnBuscar.Enabled = false;

        txtNomUsu.Enabled = false;

        txtPass.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtDireccion.Enabled = true;
        txtTelefono.Enabled = true;

        txtPass.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
    }

    protected void ActivoBotonesBM()
    {
        btnAlta.Enabled = false;
        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string nomUsu = txtNomUsu.Text.Trim();

        Cliente oCli = LogicaUsuario.BuscarCliente(nomUsu);

        Usuario oUsu = LogicaUsuario.BuscarEmpleado(nomUsu);

        if(oCli != null)
        {
            this.ActivoBotonesBM();

            txtNomUsu.Text = oCli.nomUsu;
            txtPass.Text = oCli.pass;
            txtNombre.Text = oCli.nombre;
            txtApellido.Text = oCli.apellido;
            txtDireccion.Text = oCli.dirEntrega;
            txtTelefono.Text = Convert.ToString(oCli.Telefono);

            lblError.Text = "El Cliente ya existe";
        }
        else if(oUsu != null)
        {
            lblError.Text = "Nombre en uso. Use otro.";
        }
        else
        {
            this.ActivoBotonesA();
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCli = new Cliente(txtNomUsu.Text.Trim(), txtPass.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtDireccion.Text.Trim(), Convert.ToInt32(txtTelefono.Text.Trim()));

            btnAlta.Visible = false;
            btnActualizar.Visible = true;

            LogicaUsuario.AltaCliente(oCli);

            lblError.Text = "Alta exitosa";

        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }

    protected void lbVolver_Click(object sender, EventArgs e)
    {
        Usuario oUsu = null;

        oUsu = (Usuario)Session["Cliente"];

        if(oUsu == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("BienvenidaCliente.aspx");
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}