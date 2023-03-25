using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reparacion :AuditableBaseEntity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Comentarios { get; set; }
        public string Estado { get; set;}
        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }

    }
}
