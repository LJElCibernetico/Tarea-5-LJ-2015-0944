using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaReportes.Consultas
{
    public partial class cCategorias : System.Web.UI.Page
    {
        BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CategoriaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CategoriaReportViewer.Reset();

                CategoriaReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\CategoriasReport.rdlc");

                CategoriaReportViewer.LocalReport.DataSources.Clear();

                CategoriaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CategoriaDataSet", repositorio.GetList(x => true)));
                CategoriaReportViewer.LocalReport.Refresh();
            }

        }

        Expression<Func<Categorias, bool>> filtro = x => true;

        protected void CuentaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<Categorias> rb = new RepositorioBase<Categorias>();
            CategoriaGridView.DataSource = rb.GetList(filtro);
            CategoriaGridView.PageIndex = e.NewPageIndex;
            CategoriaGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> rep = new RepositorioBase<Categorias>();
            int dato = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://CategoriaId
                    dato = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.CategoriaId == dato);
                    break;

                case 2://Descripcion
                    filtro = (x => x.Descripcion.Contains(TextBoxBuscar.Text));
                    break;

                case 3://Presupuesto
                    double balance = double.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Presupuesto == balance);
                    break;
            }
            CategoriaGridView.DataSource = rep.GetList(filtro);
            CategoriaGridView.DataBind();
        }
    }
}