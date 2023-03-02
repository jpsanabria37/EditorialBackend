using Domain.Common;

namespace Domain.Entities
{
    public class Vehiculo : AuditableBaseEntity
    {
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Kilometraje { get; set; }
        public string AnioModelo { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int ClienteId { get; set; }        
        public Cliente Cliente { get; set;}

    } 
}
