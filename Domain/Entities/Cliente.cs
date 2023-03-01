using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [DataContract(IsReference = true)]
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

        public ICollection<Vehiculo> Vehiculos { get; set; }

    }
}
