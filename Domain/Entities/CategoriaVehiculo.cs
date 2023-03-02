using Domain.Common;

namespace Domain.Entities
{
    public class CategoriaVehiculo : AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Marca> Marcas { get; set; }
    }
}
