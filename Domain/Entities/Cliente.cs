using Domain.Common;

namespace Domain.Entities
{

    public class Cliente : AuditableBaseEntity
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public int Edad { get; set; }

        public string Imagen { get; set; } 

        public string NumeroDocumento { get; set; }

        public int TipoDocumentoId  { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        public IEnumerable<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    }
}
