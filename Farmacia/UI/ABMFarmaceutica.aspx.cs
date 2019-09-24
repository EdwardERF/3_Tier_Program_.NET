﻿using System;
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 oRUC = Convert.ToInt64(txtRuc.Text);

            Farmaceutica oFar = Logica.LogicaFarmaceutica.Buscar(oRUC);
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

            Logica.LogicaFarmaceutica.Alta(oFar);

            lblError.Text = "Alta exitosa";
        }
        catch(Exception ex)
        {
            this.LimpioFormulario();
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Farmaceutica oFar = (Farmaceutica)Session["ClienteABM"];

            oFar.nombre = txtNomFar.Text.Trim();
            oFar.correo = txtCorreo.Text.Trim();
            oFar.calle = txtCalle.Text.Trim();
            oFar.numero = Convert.ToInt32(txtNumero);
            oFar.apto = Convert.ToInt32(txtApto);

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
            Farmaceutica oFar = (Farmaceutica)Session["ClienteABM"];

            Logica.LogicaFarmaceutica.Eliminar(oFar.ruc);

            this.LimpioFormulario();

            lblError.Text = "Eliminacion exitosa";
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}