using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public double Presupuesto { get; set; }

        public Categorias(int categoriaId, string descripcion, double presupuesto)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Presupuesto = presupuesto;
        }

        public Categorias()
        {
            CategoriaId = 0;
            Descripcion = String.Empty;
            Presupuesto = 0;
        }
    }
}
