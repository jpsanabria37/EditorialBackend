using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : AuditableBaseEntity
    {
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int CategoriaId { get; set; } // clave foránea
        public Categoria Categoria { get; set; } // propiedad de navegación

        // otras propiedades y métodos
    }
}
