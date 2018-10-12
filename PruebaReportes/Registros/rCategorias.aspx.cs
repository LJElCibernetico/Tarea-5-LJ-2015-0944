using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaReportes.Registros
{
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        private void ClearALL()
        {
            TextBoxCategoriaID.Text = string.Empty;
            TextBoxDescripcion.Text = string.Empty;
            TextBoxPresupuesto.Text = string.Empty;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> rb = new RepositorioBase<Categorias>();
            Categorias c = rb.Buscar(int.Parse(TextBoxCategoriaID.Text));
            if (c != null)
            {
                TextBoxDescripcion.Text = c.Descripcion;
                TextBoxPresupuesto.Text = c.Presupuesto.ToString();
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> rb = new RepositorioBase<Categorias>();
            Categorias c = rb.Buscar(int.Parse(TextBoxCategoriaID.Text));

            if (c != null)
            {
                rb.Eliminar(int.Parse(TextBoxCategoriaID.Text));
                ClearALL();
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Categorias> rb = new RepositorioBase<Categorias>();

                int.TryParse(TextBoxCategoriaID.Text, out int id);

                if (id == 0)
                {
                    if (rb.Guardar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Categoria Guardada')", true);
                    ClearALL();
                }
                else
                {
                    if (rb.Modificar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Categoria Modificada')", true);
                    ClearALL();
                }
            }
        }

        private Categorias LlenaClase()
        {
            int id;
            if (TextBoxCategoriaID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxCategoriaID.Text);
            return new Categorias(
                id,
                TextBoxDescripcion.Text,
                double.Parse(TextBoxPresupuesto.Text)
                );
        }
    }
}