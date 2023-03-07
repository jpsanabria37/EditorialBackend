using Domain.Common;

namespace Domain.Entities
{
    public class Servicio: AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int CategoriaVehiculoId { get; set; }

        public CategoriaVehiculo CategoriaVehiculo { get; set; }
    }
}
