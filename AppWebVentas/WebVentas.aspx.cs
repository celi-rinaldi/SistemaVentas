using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos.Admin;
using Datos.Models;

namespace AppWebVentas
{
    public partial class WebVentas : System.Web.UI.Page
    {
        private void MostrarDatos()
        {
            gridVendedores.DataSource = AdmVendedor.Listar();
            gridVendedores.DataBind();
        }
        private void LlenarCombo()
        {
            DataTable dt = AdmVendedor.listarComisiones();
            ddlComision.DataSource = dt;
            ddlComision.DataValueField = dt.Columns["Comision"].ToString();
            ddlComision.DataTextField = dt.Columns["Comision"].ToString();
            ddlComision.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                MostrarDatos();
                LlenarCombo();
                gridVendedores.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdmVendedor.Eliminar(id);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Vendedor v = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Comision = Convert.ToDecimal(ddlComision.DataSource)
            };
            int filasAfectadas = AdmVendedor.Insertar(v);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Vendedor v = new Vendedor()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Comision = Convert.ToDecimal(ddlComision.DataSource)
            };
            int filasAfectadas = AdmVendedor.Modificar(v);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void btnTraerPorId_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            gridVendedores.DataSource = AdmVendedor.TraerPorId(id);
            gridVendedores.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            MostrarDatos(); 
        }

        protected void btnTraerPorComision_Click(object sender, EventArgs e)
        {
            decimal comision = Convert.ToDecimal(ddlComision.SelectedValue);
            gridVendedores.DataSource = AdmVendedor.TraerVendedores(comision);
            gridVendedores.DataBind();
        }
    }
}