using Domain.Common;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    [DataContract(IsReference = true)]
    public class Marca : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public int CategoriaVehiculoId { get; set; }
        public CategoriaVehiculo CategoriaVehiculo { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set;}
    }
}
