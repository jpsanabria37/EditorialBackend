using Domain.Common;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    [DataContract(IsReference = true)]
    public class CategoriaVehiculo : AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Marca> Marcas { get; set; }
    }
}
