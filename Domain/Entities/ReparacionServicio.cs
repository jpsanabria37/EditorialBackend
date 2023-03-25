using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReparacionServicio 
    {
        public int ServicioId { get; set; }
        public virtual Servicio Servicio { get; set; }
        public int ReparacionId { get; set; }
        public virtual Reparacion Reparacion { get; set; }
        public double Precio { get; set; }
    }
}
