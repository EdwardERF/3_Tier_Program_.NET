using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.LimpioFormulario();
        }
    }

    protected void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAlta.Enabled = false;
        btnBuscar.Enabled = false;

        txtNomUsu.Enabled = false;
        txtPass.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtHoraInicio.Enabled = true;
        txtHoraFinal.Enabled = true;
    }

    protected void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAlta.Enabled = true;
        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = false;
        txtPass.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtHoraInicio.Enabled = true;
        txtHoraFinal.Enabled = true;
    }

    protected void LimpioFormulario()
    {
        btnAlta.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = true;

        txtPass.Enabled = false;
        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        txtHoraInicio.Enabled = false;
        txtHoraFinal.Enabled = false;

        txtNomUsu.Text = "";
        txtPass.Text = "";
        txtNombre.Text = ""; 
        txtApellido.Text = ""; 
        txtHoraInicio.Text = ""; 
        txtHoraFinal.Text = ""; 

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string nomUsu = txtNomUsu.Text;

            Empleado oEmp = LogicaUsuario.BuscarEmpleado(nomUsu);

            if (oEmp != null)
            {
                this.ActivoBotonesBM();

                txtNomUsu.Text = oEmp.nomUsu;
                txtPass.Text = oEmp.pass;
                txtNombre.Text = oEmp.nombre;
                txtApellido.Text = oEmp.apellido;
                txtHoraInicio.Text = oEmp.horaInicio;
                txtHoraFinal.Text = oEmp.horaFinal;

                Session["EmpleadoABM"] = oEmp;

                lblError.Text = "";
            }
            else
            {
                this.ActivoBotonesA();
                Session["EmpleadoABM"] = null;
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
            Empleado oEmp = new Empleado(txtNomUsu.Text.Trim(), txtPass.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtHoraInicio.Text.Trim(), txtHoraFinal.Text.Trim());

            LogicaUsuario.AltaEmpleado(oEmp);

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
            Empleado oEmp = (Empleado)Session["EmpleadoABM"];

            oEmp.pass = txtPass.Text.Trim();
            oEmp.nombre = txtNombre.Text.Trim();
            oEmp.apellido = txtApellido.Text.Trim();
            oEmp.horaInicio = txtHoraInicio.Text.Trim();
            oEmp.horaFinal = txtHoraFinal.Text.Trim();

            LogicaUsuario.ModificarEmpleado(oEmp);

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
            Empleado oEmp = (Empleado)Session["EmpleadoABM"];

            LogicaUsuario.EliminarEmpleado(oEmp.nomUsu);

            this.LimpioFormulario();
            lblError.Text = "Eliminacion exitosa";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}