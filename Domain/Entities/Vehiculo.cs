using Domain.Common;

namespace Domain.Entities
{
    public class Vehiculo : AuditableBaseEntity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public string NumeroPlaca { get; set; }
        public string NumeroMotor { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    } 
}
