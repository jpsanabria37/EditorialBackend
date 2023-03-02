using Domain.Common;

namespace Domain.Entities
{
    public class Categoria : AuditableBaseEntity
    {
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; } // propiedad de navegación

        // otras propiedades y métodos
    }
}
