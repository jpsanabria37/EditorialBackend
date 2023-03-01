using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [DataContract(IsReference = true)]
    public class TipoDocumento : AuditableBaseEntity
    {

        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

    }
}
